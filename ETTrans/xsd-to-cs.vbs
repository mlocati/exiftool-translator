Option Explicit

Dim fso, shell, cmdLine, lines, out, k, tLine

Set shell = WScript.CreateObject("WScript.Shell")
Set fso = WScript.CreateObject("Scripting.FileSystemObject")

ForceCScript

If Not RunCommandLine("""C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\x64\xsd.exe"" taginfo.xsd /nologo /language:CS /classes /namespace:ETTrans") Then
	DoQuit
End If
out = ""
lines = Split(Replace(Replace(ReadFile("taginfo.cs"), vbCrLf, vbCr, 1, -1, 0), vbLf, vbCr, 1, -1, 0), vbCr, -1, 0)
For k = LBound(lines) To UBound(lines)
	tLine = Trim(lines(k))
	Select Case tLine
		Case "[System.Diagnostics.DebuggerStepThroughAttribute()]"
		Case "[System.Xml.Serialization.XmlTypeAttribute(Namespace=""http://tempuri.org/XMLSchema.xsd"")]"
		Case "[System.ComponentModel.DesignerCategoryAttribute(""code"")]"
		Case Else
			If InStr(1, tLine, "[System.CodeDom.Compiler.GeneratedCodeAttribute(""xsd"", """, 0) <> 1 Then
				If InStr(1, tLine, "//", 0) <> 1 Then
					lines(k) = Replace(lines(k), ", Namespace=""http://tempuri.org/XMLSchema.xsd""", "", 1, -1, 0)
					lines(k) = Replace(lines(k), "keyType[][]", "keyType[]", 1, -1, 0)
					out = out & lines(k) & vbCrLf
				End If
			End If
	End Select
Next
WriteFile out, "taginfo.cs", True, False

Sub ForceCScript()
	Dim s, p, oShell, cmdLine
	s = WScript.FullName
	p = InStrRev(s, "\", -1, 0)
	If p > 0 Then
		s = Mid(s, p + 1)
	End If
	If StrComp(s, "cscript.exe", 1) <> 0 Then
		Set oShell = WScript.CreateObject("WScript.Shell")
		cmdLine = "CScript.exe //NoLogo " & Quote(WScript.ScriptFullName)
		cmdLine = cmdLine & " /AskKey"
		For p = 0 To WScript.Arguments.Count - 1
			cmdLine = cmdLine & " " & Quote(WScript.Arguments(p))
		Next
		oShell.Run cmdLine
		Set oShell = Nothing
		WScript.Quit
	End If
End Sub

Function Quote(value)
	Dim doQuote, s
	s = "" & value
	doQuote = False
	If InStr(1, s, " ", 0) > 0 Then
		doQuote = True
		If Len(s) >= 2 Then
			If (Left(s, 1) = """") And (Right(s, 1) = """") Then
				doQuote = False
			End If
		End If
	End If
	If doQuote Then
		Quote = """" & s & """"
	Else
		Quote = s
	End If
End Function

Function RunCommandLine(ByVal cmdLine)
	Dim process

	Set process = shell.Exec(cmdLine)
	Do
		WScript.Sleep 100
		If process.Status <> 0 Then
			Exit Do
		End If
	Loop
	If process.ExitCode <> 0 Then
		WScript.StdErr.Write "Error " & process.ExitCode & ": "
		If process.StdErr.AtEndOfStream Then
			If process.StdOut.AtEndOfStream Then
				WScript.StdErr.WriteLine "unknown error description."
			Else
				WScript.StdErr.WriteLine process.StdOut.ReadAll()
			End If
		Else
			WScript.StdErr.WriteLine process.StdErr.ReadAll()
		End If
		Set process = Nothing
		RunCommandLine = False
	Else
		RunCommandLine = True
	End If
	Set process = Nothing
End Function

Sub DoQuit()
	Dim k, doAskKey
	doAskKey = False
	For k = 0 To WScript.Arguments.Count - 1
		If StrComp(WScript.Arguments(k), "/AskKey", 1) = 0 Then
			doAskKey = True
			Exit For
		End If
	Next
	If doAskKey Then
		WScript.StdOut.WriteLine ""
		WScript.StdOut.Write "Press RETURN"
		WScript.StdIn.ReadLine()
	End If
	Set temp = Nothing
	Set fso = Nothing
	WScript.Quit
End Sub

Function ReadFile(ByVal filename)
	Dim oStream, s
	Set oStream = WScript.CreateObject("ADODB.Stream")
	oStream.Type = 2 'adTypeText
	oStream.Mode = 3 'adModeReadWrite
	oStream.CharSet = "utf-8"
	oStream.Open
	oStream.LoadFromFile filename
	s = oStream.ReadText
	oStream.Close
	Set oStream = Nothing
	ReadFile = s
End Function

Function WriteFile(ByVal text, ByVal filename, ByVal overwrite, ByVal skipBOM)
	Dim myStream, outStream
	Set myStream = WScript.CreateObject("ADODB.Stream")
	myStream.Type = 2 'adTypeText
	myStream.Mode = 3 'adModeReadWrite
	myStream.Charset = "utf-8"
	myStream.LineSeparator = -1 'adCRLF
	myStream.Open
	myStream.WriteText text, 0
	If fso.FileExists(filename) Then
		If overwrite Then
			fso.DeleteFile filename
		Else
			Err.Raise 1,, "File already exists"
		End If
	End If
	myStream.Flush
	Set outStream = WScript.CreateObject("ADODB.Stream")
	outStream.Type = 1 'adTypeBinary
	outStream.Mode = 3 'adModeReadWrite
	outStream.Open
	If skipBOM Then	
		myStream.Position = 3
	Else
		myStream.Position = 0
	End If
	myStream.CopyTo outStream
	outStream.SaveToFile filename, 2 'adSaveCreateOverWrite
	outStream.Flush
	outStream.Close
	Set outStream = Nothing
	myStream.Close
	Set myStream = Nothing
End Function
