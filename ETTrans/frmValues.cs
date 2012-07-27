using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ETTrans
{
	public partial class frmValues : Form
	{
		public frmValues(TagTranslateItem tagItem)
		{
			InitializeComponent();
			this.Icon = Utils.AppIcon;
			this.lblInfo.Text = tagItem.ID;
			this.dgvValues.AutoGenerateColumns = false;
			this.dgvValues.DataSource = tagItem.GetTranslateValues();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dgvValues_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.V))
				{
					Utils.PasteIntoGrid(this.dgvValues, this.colTrans.Index);
				}
			}
			catch
			{ }
		}
	}
}