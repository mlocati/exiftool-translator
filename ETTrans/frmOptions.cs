using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ETTrans
{
	public partial class frmOptions : Form
	{
		public interface IConfigApply
		{
			void ApplyConfig();
		}
		private class FontWrapper
		{
			public readonly FontFamily Font;
			public FontWrapper(FontFamily font)
			{
				this.Font = font;
			}
			public string FontName
			{
				get
				{
					return this.Font.Name;
				}
			}
			public override string ToString()
			{
				return this.FontName;
			}
		}
		public frmOptions()
		{
			InitializeComponent();
			this.Icon = Utils.AppIcon;
			this.lbxGridFontName.Items.Clear();
			foreach(FontFamily font in System.Drawing.FontFamily.Families)
			{
				this.lbxGridFontName.Items.Add(new FontWrapper(font));
			}
			string s;
			s = Config.GridFontName;
			foreach (FontWrapper fw in this.lbxGridFontName.Items)
			{
				if (string.Compare(fw.FontName, s, true) == 0)
				{
					this.lbxGridFontName.SelectedItem = fw;
					break;
				}
			}
			this.nudGridFontSize.Value = Convert.ToDecimal(Config.GridFontSize);
			this.CheckDirty();
		}

		private bool CheckDirty()
		{
			bool dirty = false;
			FontWrapper fw = this.lbxGridFontName.SelectedItem as FontWrapper;
			if((fw == null)||(string.Compare(fw.FontName, Config.GridFontName, true) != 0))
			{
				dirty = true;
			}
			float f = Convert.ToSingle(this.nudGridFontSize.Value);
			if (f != Config.GridFontSize)
			{
				dirty = true;
			}
			this.btnApply.Enabled = this.btnSave.Enabled = dirty;
			return dirty;
		}

		private void lbxGridFontName_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CheckDirty();
		}

		private void nudGridFontSize_ValueChanged(object sender, EventArgs e)
		{
			this.CheckDirty();
		}

		private bool ApplyConfig()
		{
			if (true || this.CheckDirty())
			{
				try
				{
					FontWrapper fw = this.lbxGridFontName.SelectedItem as FontWrapper;
					if (fw == null)
					{
						MessageBox.Show("Please select the font", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.lbxGridFontName.Focus();
						return false;
					}
					float f = Convert.ToSingle(this.nudGridFontSize.Value);
					Config.GridFontName = fw.FontName;
					Config.GridFontSize = f;
					frmOptions.IConfigApply i = this.Owner as frmOptions.IConfigApply;
					if (i != null)
					{
						i.ApplyConfig();
					}
				}
				catch (Exception x)
				{
					MessageBox.Show(x.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}
			return true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (this.ApplyConfig())
			{
				this.Close();
			}
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			this.ApplyConfig();
		}

	}
}