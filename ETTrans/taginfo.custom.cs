using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ETTrans
{
	public partial class taginfoType
	{
		private static XmlSerializer _serializer;
		private static XmlSerializer Serializer
		{
			get
			{
				if (taginfoType._serializer == null)
				{
					taginfoType._serializer = new XmlSerializer(typeof(taginfoType));
				}
				return taginfoType._serializer;
			}
		}
		public static taginfoType Deserialize(string filename)
		{
			using (FileStream filestream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				return (taginfoType)taginfoType.Serializer.Deserialize(filestream);
			}
		}
		public void Serialize(string filename)
		{
			byte[] ba;
			using (MemoryStream ms = new MemoryStream())
			{
				using (MyXmlTextWriter xmlwriter = new MyXmlTextWriter(ms))
				{
					
					XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
					ns.Add("", "");
					taginfoType.Serializer.Serialize(xmlwriter, this, ns);
					xmlwriter.Flush();
					ms.Flush();
					ms.Position = 0;
					ba = new byte[ms.Length];
					ms.Read(ba, 0, ba.Length);
					string s = Encoding.UTF8.GetString(ba);
					s = s.Replace("<values />", "<values>\r\n  </values>");
					s = s.Replace("&apos;", "&#39;");
					s = s.Replace("</taginfo>", "\r\n\r\n</taginfo>\r\n");
					StringBuilder done = new StringBuilder();
					Regex rx = new Regex(">([^<>]*['\"][^<>]*)<", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Singleline);
					int i = 0;
					Match m;
					while ((m = rx.Match(s, i)).Success)
					{
						if (m.Index > i)
						{
							done.Append(s.Substring(i, m.Index - i));
						}
						done.Append(m.Value.Replace("'", "&#39;").Replace("\"", "&quot;"));
						i = m.Index + m.Length;
					}
					if (i < (s.Length - 1))
					{
						done.Append(s.Substring(i));
					}

					s = done.ToString();
					done = new StringBuilder();
					i = 0;
					rx = new Regex("<(?<name>val|key) [^<>]* />", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Singleline);
					while ((m = rx.Match(s, i)).Success)
					{
						if (m.Index > i)
						{
							done.Append(s.Substring(i, m.Index - i));
						}
						done.Append(m.Value.Replace(" />", string.Format("></{0}>", m.Groups["name"].Value)));
						i = m.Index + m.Length;
					}
					if (i < (s.Length - 1))
					{
						done.Append(s.Substring(i));
					}

					using (FileStream filestream = new FileStream(filename, FileMode.Create, FileAccess.Write))
					{
						ba = Encoding.UTF8.GetBytes(done.ToString());
						filestream.Write(ba, 0, ba.Length);
						filestream.Flush();
					}
				}
			}
		}
		private class MyXmlTextWriter : XmlTextWriter
		{
			public MyXmlTextWriter(Stream w)
				: base(w, Encoding.UTF8)
			{
				this.Formatting = Formatting.Indented;
				this.Indentation = 1;
				this.IndentChar = ' ';
				this.Namespaces = false;
				this.QuoteChar = '\'';
			}
			public override void WriteStartDocument()
			{
				this.WriteRaw("<?xml version='1.0' encoding='UTF-8'?>");
			}
			public override void WriteStartElement(string prefix, string localName, string ns)
			{
				switch (localName)
				{
					case "table":
						this.WriteRaw("\r\n\r\n");
						break;
				}
				base.WriteStartElement(prefix, localName, ns);
			}
		}
	}
}
