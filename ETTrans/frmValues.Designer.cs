namespace ETTrans
{
	partial class frmValues
	{
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Liberare le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Codice generato da Progettazione Windows Form

		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblInfo = new System.Windows.Forms.Label();
			this.dgvValues = new System.Windows.Forms.DataGridView();
			this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvValues)).BeginInit();
			this.SuspendLayout();
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(13, 13);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(35, 13);
			this.lblInfo.TabIndex = 0;
			this.lblInfo.Text = "label1";
			// 
			// dgvValues
			// 
			this.dgvValues.AllowUserToAddRows = false;
			this.dgvValues.AllowUserToDeleteRows = false;
			this.dgvValues.AllowUserToResizeRows = false;
			this.dgvValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvValues.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dgvValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colRef,
            this.colTrans});
			this.dgvValues.Location = new System.Drawing.Point(16, 29);
			this.dgvValues.Name = "dgvValues";
			this.dgvValues.RowHeadersVisible = false;
			this.dgvValues.Size = new System.Drawing.Size(506, 306);
			this.dgvValues.TabIndex = 1;
			this.dgvValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvValues_KeyDown);
			// 
			// colID
			// 
			this.colID.DataPropertyName = "ID";
			this.colID.FillWeight = 50F;
			this.colID.HeaderText = "ID";
			this.colID.Name = "colID";
			this.colID.ReadOnly = true;
			// 
			// colRef
			// 
			this.colRef.DataPropertyName = "Ref";
			this.colRef.HeaderText = "Reference";
			this.colRef.Name = "colRef";
			this.colRef.ReadOnly = true;
			// 
			// colTrans
			// 
			this.colTrans.DataPropertyName = "Trans";
			this.colTrans.HeaderText = "Translated";
			this.colTrans.Name = "colTrans";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(230, 341);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmValues
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(534, 376);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.dgvValues);
			this.Controls.Add(this.lblInfo);
			this.Name = "frmValues";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit item values";
			((System.ComponentModel.ISupportInitialize)(this.dgvValues)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.DataGridView dgvValues;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.DataGridViewTextBoxColumn colID;
		private System.Windows.Forms.DataGridViewTextBoxColumn colRef;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTrans;
	}
}