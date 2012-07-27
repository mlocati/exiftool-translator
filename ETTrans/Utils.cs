using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Globalization;

namespace ETTrans
{
	internal static class Utils
	{
		private static Icon _appIcon = null;
		public static Icon AppIcon
		{
			get
			{
				if (Utils._appIcon == null)
				{
					try
					{
						Utils._appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
					}
					catch
					{
					}
				}
				return Utils._appIcon;
			}
		}
		public static string GetLanguageName(string languageId)
		{
			if (string.IsNullOrEmpty(languageId))
			{
				return "";
			}
			languageId = languageId.Replace('_', '-');
			try
			{
				CultureInfo ci = new CultureInfo(languageId);
				if (ci != null)
				{
					if ((!string.IsNullOrEmpty(ci.DisplayName)) && (!languageId.Replace('_', '-').Equals(ci.DisplayName)))
					{
						return ci.DisplayName;
					}
				}
			}
			catch
			{ }
			switch (languageId.ToLowerInvariant())
			{
				case "cs":
					return "Czech";
				case "de":
					return "German";
				case "en":
					return "English";
				case "en-ca":
					return "English (Canada)";
				case "en-gb":
					return "English (United Kingdom)";
				case "es":
					return "Spanish";
				case "fi":
					return "Finnish";
				case "ja":
					return "Japanese";
				case "fr":
					return "French";
				case "it":
					return "Italian";
				case "ko":
					return "Korean";
				case "nl":
					return "Dutch";
				case "pl":
					return "Polish";
				case "ru":
					return "Russian";
				case "sv":
					return "Swedish";
				case "tr":
					return "Turkish";
				case "zh-cn":
					return "Chinese (Simplified)";
				case "zh-tw":
					return "Chinese (Traditional)";
			}
			return languageId;
		}

		public static void PasteIntoGrid(DataGridView dgv, int transColumn)
		{
			string text = Clipboard.ContainsText() ? Clipboard.GetText() : null;
			if (text != null)
			{
				string[] lines = text.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
				bool isMultiline = lines.Length > 0;
				int[] rowIndexes;
				if(dgv.SelectedCells.Count == 0)
				{
					rowIndexes = null;
				}
				else
				{
					rowIndexes = new int[dgv.SelectedCells.Count];
					for(int i = 0; i < rowIndexes.Length; i++)
					{
						TranslateItem item = (dgv.SelectedCells[i].ColumnIndex == transColumn) ? (dgv.Rows[dgv.SelectedCells[i].RowIndex].DataBoundItem as TranslateItem) : null;
						if(item == null)
						{
							rowIndexes = null;
							break;
						}
						else
						{
							rowIndexes[i] = dgv.SelectedCells[i].RowIndex;
						}
					}
				}
				if(rowIndexes != null)
				{
					if(rowIndexes.Length == lines.Length)
					{
						for(int i = 0; i < rowIndexes.Length; i++)
						{
							dgv.Rows[rowIndexes[i]].Cells[transColumn].Value = lines[i];
						}
					}
					else if (lines.Length == 1)
					{
						for (int i = 0; i < rowIndexes.Length; i++)
						{
							dgv.Rows[rowIndexes[i]].Cells[transColumn].Value = text;
						}
					}
					else if (rowIndexes.Length == 1)
					{
						if (lines.Length + rowIndexes[0] < dgv.Rows.Count)
						{
							switch (MessageBox.Show(string.Format("Paste text into {0:N0} cells?", lines.Length), Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button1))
							{
								case DialogResult.Yes:

									for (int i = 0; i < lines.Length; i++)
									{
										dgv.Rows[rowIndexes[0] + i].Cells[transColumn].Value = lines[i];
									}
									break;
								case DialogResult.No:
									dgv.Rows[0].Cells[transColumn].Value = text;
									break;
							}
						}
						else
						{
							dgv.Rows[0].Cells[transColumn].Value = text;
						}
					}
				}
			}
		}
	}
}
