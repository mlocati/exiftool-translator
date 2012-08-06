using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ETTrans
{
	public partial class frmMain : Form, frmOptions.IConfigApply
	{
		private enum UnloadReson
		{
			Quitting,
			OpeningOther,
		}
		private readonly string InitialFile;
		private TagInfoUI _currentTagInfo = null;

		private TagInfoUI CurrentTagInfo
		{
			get
			{
				return this._currentTagInfo;
			}
			set
			{
				this._currentTagInfo = value;
				this.UpdateFilter();
				this.mniSaveAs.Enabled = this.mniSave.Enabled = value != null;
				this.Dirty = false;
			}
		}
		private bool _dirty;

		public bool Dirty
		{
			get
			{
				return (this._currentTagInfo != null) && this._dirty;
			}
			set
			{
				this._dirty = value;
				if (this.CurrentTagInfo == null)
				{
					this.Text = Application.ProductName;
				}
				else
				{
					this.Text = string.Format("{0} [{1}]{2}", Application.ProductName, this.CurrentTagInfo.Filename, this._dirty ? " *" : "");
				}
			}
		}
		private string CurrentG0
		{
			get
			{
				if ((this.CurrentTagInfo != null) && (this.cbxFilterG0.SelectedIndex > 0))
				{
					return (string)this.cbxFilterG0.SelectedItem;
				}
				else
				{
					return "";
				}
			}
		}
		private string CurrentG1
		{
			get
			{
				if ((this.CurrentTagInfo != null) && (this.cbxFilterG1.SelectedIndex > 0))
				{
					return (string)this.cbxFilterG1.SelectedItem;
				}
				else
				{
					return "";
				}
			}
		}
		private string CurrentG2
		{
			get
			{
				if ((this.CurrentTagInfo != null) && (this.cbxFilterG2.SelectedIndex > 0))
				{
					return (string)this.cbxFilterG2.SelectedItem;
				}
				else
				{
					return "";
				}
			}
		}
		private string CurrentLanguageReference
		{
			get
			{
				if ((this.CurrentTagInfo != null) && (this.cbxFilterRefLanguage.SelectedIndex >= 0))
				{
					return ((ShownName)this.cbxFilterRefLanguage.SelectedItem).Value;
				}
				else
				{
					return "";
				}
			}
		}
		private string CurrentLanguageTranslate
		{
			get
			{
				if ((this.CurrentTagInfo != null) && (this.cbxFilterTransLang.SelectedIndex >= 0))
				{
					return ((ShownName)this.cbxFilterTransLang.SelectedItem).Value;
				}
				else
				{
					return "";
				}
			}
		}
		public frmMain()
			: this(null)
		{
		}
		public frmMain(string initialFile)
		{
			InitializeComponent();
			this.Icon = Utils.AppIcon;
			this.dgvTrans.AutoGenerateColumns = false;
			this.CurrentTagInfo = null;
			this.InitialFile = initialFile;
			try
			{
				this.ApplyConfig();
			}
			catch
			{ }
		}
		private void frmMain_Shown(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.InitialFile))
			{
				try
				{
					this.LoadXml(this.InitialFile);
				}
				catch (Exception x)
				{
					MessageBox.Show(x.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void LoadXml(string filename)
		{
			this.CurrentTagInfo = new TagInfoUI(filename);
		}


		private void UpdateFilter()
		{
			this.gbxFilter.Visible = this.CurrentTagInfo != null;
			this.dgvTrans.Visible = false;
			if (this.CurrentTagInfo != null)
			{
				this.cbxFilterG0.Items.Clear();
				this.cbxFilterG0.Items.Add("<all>");
				foreach (KeyValuePair<string, Dictionary<string, List<string>>> g0 in this.CurrentTagInfo.Groups)
				{
					this.cbxFilterG0.Items.Add(g0.Key);
				}
				this.cbxFilterG0.SelectedIndex = 0;
				this.cbxFilterRefLanguage.Items.Clear();
				this.cbxFilterTransLang.Items.Clear();
				foreach (KeyValuePair<string, string> kv in this.CurrentTagInfo.Languages)
				{
					ShownName sn = new ShownName(kv.Key, kv.Value);
					this.cbxFilterRefLanguage.Items.Add(sn);
					this.cbxFilterTransLang.Items.Add(sn);
				}
				this.cbxFilterRefLanguage.SelectedIndex = 0;
				this.cbxFilterTransLang.SelectedIndex = 0;
				foreach (ShownName sn in this.cbxFilterRefLanguage.Items)
				{
					if (sn.Value == "en")
					{
						this.cbxFilterRefLanguage.SelectedItem = sn;
						break;
					}
				}
				System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
				foreach (ShownName sn in this.cbxFilterTransLang.Items)
				{
					if (sn.Value.Equals(ci.TwoLetterISOLanguageName))
					{
						this.cbxFilterTransLang.SelectedItem = sn;
						break;
					}
				}
			}
		}

		private void btnFilter_Click(object sender, EventArgs e)
		{
			if (this.CurrentTagInfo != null)
			{
				bool inlineValues = this.chkFilterInlinevalues.Checked;
				this.colRef.HeaderText = Utils.GetLanguageName(this.CurrentLanguageReference);
				this.colTrans.HeaderText = Utils.GetLanguageName(this.CurrentLanguageTranslate);
				this.colValues.Visible = !inlineValues;
				this.dgvTrans.DataSource = new TranslateItemsSortable<TranslateItem>(this.CurrentTagInfo.GetTranslateTable(this, this.CurrentG0, this.CurrentG1, this.CurrentG2, this.CurrentLanguageReference, this.CurrentLanguageTranslate, inlineValues));
				this.dgvTrans.Visible = true;
			}
		}
		private class TranslateItemsSortable<T> : BindingList<T>
		{
			private bool _isSorted;
			private ListSortDirection _sortDirection;
			private PropertyDescriptor _sortProperty;

			protected override bool SupportsSortingCore
			{
				get
				{
					return true;
				}
			}
			protected override bool IsSortedCore
			{
				get
				{
					return this._isSorted;
				}
			}
			protected override ListSortDirection SortDirectionCore
			{
				get
				{
					return this._sortDirection;
				}
			}
			protected override PropertyDescriptor SortPropertyCore
			{
				get
				{
					return this._sortProperty;
				}
			}
			public TranslateItemsSortable(List<T> items)
				: base(items)
			{
				this._isSorted = false;
				this._sortDirection = ListSortDirection.Ascending;
				this._sortProperty = null;
			}

			protected override void ApplySortCore(PropertyDescriptor sortProperty, ListSortDirection sortDirection)
			{
				this._isSorted = true;
				this._sortProperty = sortProperty;
				this._sortDirection = sortDirection;
				List<T> items = this.Items as List<T>;
				if ((items == null) || (sortProperty == null))
				{
					_isSorted = false;
				}
				else
				{
					items.Sort(delegate(T a, T b)
					{
						object v;
						string Sa, Sb;
						v = sortProperty.GetValue(a);
						Sa = (v == null) ? "" : v.ToString();
						v = sortProperty.GetValue(b);
						Sb = (v == null) ? "" : v.ToString();
						return string.Compare(Sa, Sb, false);
					});
					_isSorted = true;
				}
			}
		}

		private void cbxFilterG0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.CurrentTagInfo != null)
			{
				this.cbxFilterG1.Items.Clear();
				this.cbxFilterG1.Items.Add("<all>");
				if (this.cbxFilterG0.SelectedIndex > 0)
				{
					foreach (KeyValuePair<string, List<string>> g1 in this.CurrentTagInfo.Groups[(string)this.cbxFilterG0.SelectedItem])
					{
						this.cbxFilterG1.Items.Add(g1.Key);
					}
				}
				this.cbxFilterG1.SelectedIndex = (this.cbxFilterG1.Items.Count == 2) ? 1 : 0;
			}
		}
		private void cbxFilterG1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.CurrentTagInfo != null)
			{
				this.cbxFilterG2.Items.Clear();
				this.cbxFilterG2.Items.Add("<all>");
				if (this.cbxFilterG1.SelectedIndex > 0)
				{
					foreach (string g2 in this.CurrentTagInfo.Groups[(string)this.cbxFilterG0.SelectedItem][(string)this.cbxFilterG1.SelectedItem])
					{
						this.cbxFilterG2.Items.Add(g2);
					}
				}
				this.cbxFilterG2.SelectedIndex = (this.cbxFilterG2.Items.Count == 2) ? 1 : 0;
			}
		}

		private class ShownName
		{
			public readonly string Value;
			public readonly string Name;
			public ShownName(string value, string name)
			{
				this.Value = value;
				this.Name = name;
			}
			public override string ToString()
			{
				return this.Name;
			}
		}



		private void mniOpen_Click(object sender, EventArgs e)
		{
			if (!CheckUnloadableCurrent(UnloadReson.OpeningOther))
			{
				return;
			}
			try
			{
				using (OpenFileDialog ofd = new OpenFileDialog())
				{
					ofd.AddExtension = true;
					ofd.CheckFileExists = true;
					ofd.CheckPathExists = true;
					ofd.DefaultExt = ".xml";
					ofd.DereferenceLinks = true;
					ofd.FileName = "";
					ofd.Filter = "Xml files|*.xml|All files|*.*";
					ofd.FilterIndex = 0;
					ofd.Multiselect = false;
					ofd.Title = "Select the file to open";
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						this.LoadXml(ofd.FileName);
					}
				}
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void mniSave_Click(object sender, EventArgs e)
		{
			if (this.CurrentTagInfo != null)
			{
				try
				{
					this.CurrentTagInfo.Save();
					this.Dirty = false;
				}
				catch (Exception x)
				{
					MessageBox.Show(x.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void mniSaveAs_Click(object sender, EventArgs e)
		{
			if (this.CurrentTagInfo != null)
			{
				try
				{
					using (SaveFileDialog sfd = new SaveFileDialog())
					{
						sfd.AddExtension = true;
						sfd.CheckFileExists = false;
						sfd.CheckPathExists = true;
						sfd.CreatePrompt = false;
						sfd.DefaultExt = ".xml";
						sfd.DereferenceLinks = true;
						sfd.Filter = "Xml files|*.xml|All files|*.*";
						sfd.FilterIndex = 0;
						sfd.InitialDirectory = Path.GetDirectoryName(this.CurrentTagInfo.Filename);
						sfd.FileName = Path.GetFileName(this.CurrentTagInfo.Filename);
						sfd.OverwritePrompt = true;
						sfd.Title = "Save the file as";
						if (sfd.ShowDialog(this) == DialogResult.OK)
						{
							this.CurrentTagInfo.SaveAs(sfd.FileName);
							this.Dirty = false;
						}
					}
				}
				catch (Exception x)
				{
					MessageBox.Show(x.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void mniNew_Click(object sender, EventArgs e)
		{
			try
			{
				using (OpenFileDialog ofd = new OpenFileDialog())
				{
					ofd.AddExtension = true;
					ofd.CheckFileExists = true;
					ofd.CheckPathExists = true;
					ofd.DefaultExt = ".exe";
					ofd.DereferenceLinks = true;
					ofd.FileName = "";
					ofd.Filter = "ExifTool program|exiftool*.exe|All programs|*.exe|All files|*.*";
					ofd.FilterIndex = 0;
					ofd.Multiselect = false;
					ofd.Title = "Locate the ExifTool program";
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						ProcessStartInfo psi = new ProcessStartInfo();
						psi.FileName = ofd.FileName;
						psi.Arguments = "-listx";
						psi.CreateNoWindow = true;
						psi.ErrorDialog = false;
						psi.RedirectStandardError = true;
						psi.RedirectStandardOutput = true;
						psi.StandardErrorEncoding = Encoding.UTF8;
						psi.StandardOutputEncoding = Encoding.UTF8;
						psi.UseShellExecute = false;
						psi.WindowStyle = ProcessWindowStyle.Hidden;
						string xml;
						using (System.Diagnostics.Process process = new Process())
						{
							process.StartInfo = psi;
							process.Start();
							xml = process.StandardOutput.ReadToEnd();
							process.WaitForExit();
						}
						using (SaveFileDialog sfd = new SaveFileDialog())
						{
							sfd.AddExtension = true;
							sfd.CheckFileExists = false;
							sfd.CheckPathExists = true;
							sfd.CreatePrompt = false;
							sfd.DefaultExt = ".xml";
							sfd.DereferenceLinks = true;
							sfd.Filter = "Xml files|*.xml|All files|*.*";
							sfd.FilterIndex = 0;
							if (this.CurrentTagInfo != null)
							{
								sfd.InitialDirectory = Path.GetDirectoryName(this.CurrentTagInfo.Filename);
							}
							sfd.FileName = "";
							sfd.OverwritePrompt = true;
							sfd.Title = "Save the file as";
							if (sfd.ShowDialog(this) == DialogResult.OK)
							{
								using (FileStream filestream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.Read))
								{
									byte[] ba = Encoding.UTF8.GetBytes(xml);
									filestream.Write(ba, 0, ba.Length);
									filestream.Flush();
								}
								this.LoadXml(sfd.FileName);
							}
						}
					}
				}
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvTrans_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
			{
				if (e.ColumnIndex == this.colValues.Index)
				{
					TagTranslateItem tagItem = this.dgvTrans.Rows[e.RowIndex].DataBoundItem as TagTranslateItem;
					if ((tagItem != null) && tagItem.HasValues)
					{
						using (frmValues frm = new frmValues(tagItem))
						{
							frm.ShowDialog(this);
						}
					}
				}
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.CheckUnloadableCurrent(UnloadReson.Quitting))
			{
				e.Cancel = true;
			}
		}

		private bool CheckUnloadableCurrent(UnloadReson reason)
		{
			if (this.Dirty)
			{
				string text;
				switch (reason)
				{
					case UnloadReson.Quitting:
						text = string.Format("The file is not saved.{0}{0}Save it before exiting?", Environment.NewLine);
						break;
					case UnloadReson.OpeningOther:
						text = string.Format("The file is not saved.{0}{0}Save it before opening another one?", Environment.NewLine);
						break;
					default:
						text = string.Format("The file is not saved.{0}{0}Save it before continuing?", Environment.NewLine);
						break;
				}
				switch (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
				{
					case DialogResult.Yes:
						try
						{
							this.CurrentTagInfo.Save();
							this.Dirty = false;
							return true;
						}
						catch (Exception x)
						{
							MessageBox.Show(x.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
					case DialogResult.No:
						return true;
					default:
						return false;
				}
			}
			else
			{
				return true;
			}
		}

		private void dgvTrans_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.V))
				{
					Utils.PasteIntoGrid(this.dgvTrans, this.colTrans.Index);
				}
			}
			catch
			{ }
		}

		private void mniOptions_Click(object sender, EventArgs e)
		{
			using (frmOptions frm = new frmOptions())
			{
				frm.ShowDialog(this);
			}
		}

		public void ApplyConfig()
		{
			this.dgvTrans.Font = new System.Drawing.Font(Config.GridFontName, Config.GridFontSize);
		}

	}
}

