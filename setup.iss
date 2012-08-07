[Setup]
AppName=ETTrans
AppVersion=1.0
DefaultDirName={pf}\ETTrans
DefaultGroupName=.
UninstallDisplayIcon={app}\ETTrans.exe
Compression=lzma2
SolidCompression=yes
OutputDir=.
LicenseFile=LICENSE

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "pt_br"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "ca"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "cs"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "da"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "nl"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "fi"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "fs"; MessagesFile: "compiler:Languages\French.isl"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"
Name: "el"; MessagesFile: "compiler:Languages\Greek.isl"
Name: "he"; MessagesFile: "compiler:Languages\Hebrew.isl"
Name: "hu"; MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "it"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "ja"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "no"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "pl"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "pt"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "ru"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "sr_c"; MessagesFile: "compiler:Languages\SerbianCyrillic.isl"
Name: "sr_l"; MessagesFile: "compiler:Languages\SerbianLatin.isl"
Name: "sl"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "es"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "uk"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Files]
Source: "ETTrans\bin\Debug\ETTrans.exe"; DestDir: "{app}"
Source: "LICENSE"; DestDir: "{app}"

[Icons]
Name: "{group}\ETTrans"; Filename: "{app}\ETTrans.exe"

[Registry]
Root: HKCU; Subkey: "Software\ETTrans"; Flags: uninsdeletekey

[CustomMessages]
en.dotnet_missing=This setup requires the .NET Framework v2.0. Please download and install the .NET Framework v.2 and run this setup again. Do you want to download the framework now?
de.dotnet_missing=Dieses Programm benötigt Microsoft .NET Framework v2.0. Bitte downloaden und installieren Sie Microsoft .NET Framework v2.0 und führen Sie anschliessend die Installation erneut aus. Wollen Sie das Framework jetzt downloaden?
it.dotnet_missing=Questo programma richiete il .NET Framework v2.0. È necessario scaricare ed installare il .NET Framework v.2 e in seguito eseguire nuovamente il presente programma di installazione. Di desidera scaricare il framework adesso?
en.dotnet_url=http://www.microsoft.com/en-us/download/details.aspx?id=19
pt_br.dotnet_url=http://www.microsoft.com/pt-br/download/details.aspx?id=19
cs.dotnet_url=http://www.microsoft.com/cs-cz/download/details.aspx?id=19
da.dotnet_url=http://www.microsoft.com/da-dk/download/details.aspx?id=19
nl.dotnet_url=http://www.microsoft.com/nl-nl/download/details.aspx?id=19
fi.dotnet_url=http://www.microsoft.com/fi-fi/download/details.aspx?id=19
fs.dotnet_url=http://www.microsoft.com/fr-fr/download/details.aspx?id=19
de.dotnet_url=http://www.microsoft.com/de-de/download/details.aspx?id=19
el.dotnet_url=http://www.microsoft.com/el-gr/download/details.aspx?id=19
he.dotnet_url=http://www.microsoft.com/downloads/details.aspx?familyid=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=he
hu.dotnet_url=http://www.microsoft.com/hu-hu/download/details.aspx?id=19
it.dotnet_url=http://www.microsoft.com/it-it/download/details.aspx?id=19
ja.dotnet_url=http://www.microsoft.com/ja-jp/download/details.aspx?id=19
no.dotnet_url=http://www.microsoft.com/nb-no/download/details.aspx?id=19
pl.dotnet_url=http://www.microsoft.com/pl-pl/download/details.aspx?id=19
pt.dotnet_url=http://www.microsoft.com/pt-pt/download/details.aspx?id=19
ru.dotnet_url=http://www.microsoft.com/ru-ru/download/details.aspx?id=19
es.dotnet_url=http://www.microsoft.com/es-es/download/details.aspx?id=19


[Code]
const
	dotnetfx20_url = 'http://download.microsoft.com/download/5/6/7/567758a3-759e-473e-bf8f-52154438565a/dotnetfx.exe';
	dotnetfx20_url_x64 = 'http://download.microsoft.com/download/a/3/f/a3f1bf98-18f3-4036-9b68-8e6de530ce0a/NetFx64.exe';
	dotnetfx20_url_ia64 = 'http://download.microsoft.com/download/f/8/6/f86148a4-e8f7-4d08-a484-b4107f238728/NetFx64.exe';

function InitializeSetup(): Boolean;
var
    ErrorCode: Integer;
begin
	if RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v2.0') then begin
		Result := true;
	end else begin
		if MsgBox(ExpandConstant('{cm:dotnet_missing}'), mbConfirmation, MB_YESNO) = idYes then begin
			ShellExec('open', ExpandConstant('{cm:dotnet_url}'), '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode);
		end;
		Result := False
	end;
end;
