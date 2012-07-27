namespace ETTrans
{
    partial class frmMain
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
			  this.dgvTrans = new System.Windows.Forms.DataGridView();
			  this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.colRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.colTrans = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.colValues = new System.Windows.Forms.DataGridViewLinkColumn();
			  this.gbxFilter = new System.Windows.Forms.GroupBox();
			  this.chkFilterInlinevalues = new System.Windows.Forms.CheckBox();
			  this.cbxFilterTransLang = new System.Windows.Forms.ComboBox();
			  this.lblFilterTransLang = new System.Windows.Forms.Label();
			  this.cbxFilterRefLanguage = new System.Windows.Forms.ComboBox();
			  this.lblFilterRefLanguage = new System.Windows.Forms.Label();
			  this.btnFilter = new System.Windows.Forms.Button();
			  this.cbxFilterG2 = new System.Windows.Forms.ComboBox();
			  this.lblFilterG2 = new System.Windows.Forms.Label();
			  this.cbxFilterG1 = new System.Windows.Forms.ComboBox();
			  this.lblFilterG1 = new System.Windows.Forms.Label();
			  this.cbxFilterG0 = new System.Windows.Forms.ComboBox();
			  this.lblFilterG0 = new System.Windows.Forms.Label();
			  this.mnuMain = new System.Windows.Forms.MenuStrip();
			  this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			  this.mniNew = new System.Windows.Forms.ToolStripMenuItem();
			  this.mniOpen = new System.Windows.Forms.ToolStripMenuItem();
			  this.mniSave = new System.Windows.Forms.ToolStripMenuItem();
			  this.mniSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			  ((System.ComponentModel.ISupportInitialize)(this.dgvTrans)).BeginInit();
			  this.gbxFilter.SuspendLayout();
			  this.mnuMain.SuspendLayout();
			  this.SuspendLayout();
			  // 
			  // dgvTrans
			  // 
			  this.dgvTrans.AllowUserToAddRows = false;
			  this.dgvTrans.AllowUserToDeleteRows = false;
			  this.dgvTrans.AllowUserToResizeRows = false;
			  this.dgvTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							  | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.dgvTrans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			  this.dgvTrans.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			  this.dgvTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			  this.dgvTrans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colRef,
            this.colTrans,
            this.colValues});
			  this.dgvTrans.Location = new System.Drawing.Point(12, 104);
			  this.dgvTrans.Name = "dgvTrans";
			  this.dgvTrans.RowHeadersVisible = false;
			  this.dgvTrans.Size = new System.Drawing.Size(736, 401);
			  this.dgvTrans.TabIndex = 2;
			  this.dgvTrans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrans_CellClick);
			  this.dgvTrans.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTrans_KeyDown);
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
			  // colValues
			  // 
			  this.colValues.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			  this.colValues.DataPropertyName = "Values";
			  this.colValues.HeaderText = "Values";
			  this.colValues.LinkColor = System.Drawing.Color.Blue;
			  this.colValues.Name = "colValues";
			  this.colValues.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			  this.colValues.VisitedLinkColor = System.Drawing.Color.Blue;
			  this.colValues.Width = 50;
			  // 
			  // gbxFilter
			  // 
			  this.gbxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.gbxFilter.Controls.Add(this.chkFilterInlinevalues);
			  this.gbxFilter.Controls.Add(this.cbxFilterTransLang);
			  this.gbxFilter.Controls.Add(this.lblFilterTransLang);
			  this.gbxFilter.Controls.Add(this.cbxFilterRefLanguage);
			  this.gbxFilter.Controls.Add(this.lblFilterRefLanguage);
			  this.gbxFilter.Controls.Add(this.btnFilter);
			  this.gbxFilter.Controls.Add(this.cbxFilterG2);
			  this.gbxFilter.Controls.Add(this.lblFilterG2);
			  this.gbxFilter.Controls.Add(this.cbxFilterG1);
			  this.gbxFilter.Controls.Add(this.lblFilterG1);
			  this.gbxFilter.Controls.Add(this.cbxFilterG0);
			  this.gbxFilter.Controls.Add(this.lblFilterG0);
			  this.gbxFilter.Location = new System.Drawing.Point(12, 27);
			  this.gbxFilter.Name = "gbxFilter";
			  this.gbxFilter.Size = new System.Drawing.Size(736, 71);
			  this.gbxFilter.TabIndex = 1;
			  this.gbxFilter.TabStop = false;
			  this.gbxFilter.Text = "Filter";
			  // 
			  // chkFilterInlinevalues
			  // 
			  this.chkFilterInlinevalues.AutoSize = true;
			  this.chkFilterInlinevalues.Location = new System.Drawing.Point(486, 49);
			  this.chkFilterInlinevalues.Name = "chkFilterInlinevalues";
			  this.chkFilterInlinevalues.Size = new System.Drawing.Size(84, 17);
			  this.chkFilterInlinevalues.TabIndex = 10;
			  this.chkFilterInlinevalues.Text = "inline-values";
			  this.chkFilterInlinevalues.UseVisualStyleBackColor = true;
			  // 
			  // cbxFilterTransLang
			  // 
			  this.cbxFilterTransLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			  this.cbxFilterTransLang.FormattingEnabled = true;
			  this.cbxFilterTransLang.Location = new System.Drawing.Point(359, 46);
			  this.cbxFilterTransLang.Name = "cbxFilterTransLang";
			  this.cbxFilterTransLang.Size = new System.Drawing.Size(121, 21);
			  this.cbxFilterTransLang.TabIndex = 9;
			  // 
			  // lblFilterTransLang
			  // 
			  this.lblFilterTransLang.AutoSize = true;
			  this.lblFilterTransLang.Location = new System.Drawing.Point(243, 50);
			  this.lblFilterTransLang.Name = "lblFilterTransLang";
			  this.lblFilterTransLang.Size = new System.Drawing.Size(110, 13);
			  this.lblFilterTransLang.TabIndex = 8;
			  this.lblFilterTransLang.Text = "Language to translate";
			  // 
			  // cbxFilterRefLanguage
			  // 
			  this.cbxFilterRefLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			  this.cbxFilterRefLanguage.FormattingEnabled = true;
			  this.cbxFilterRefLanguage.Location = new System.Drawing.Point(116, 46);
			  this.cbxFilterRefLanguage.Name = "cbxFilterRefLanguage";
			  this.cbxFilterRefLanguage.Size = new System.Drawing.Size(121, 21);
			  this.cbxFilterRefLanguage.TabIndex = 7;
			  // 
			  // lblFilterRefLanguage
			  // 
			  this.lblFilterRefLanguage.AutoSize = true;
			  this.lblFilterRefLanguage.Location = new System.Drawing.Point(6, 50);
			  this.lblFilterRefLanguage.Name = "lblFilterRefLanguage";
			  this.lblFilterRefLanguage.Size = new System.Drawing.Size(104, 13);
			  this.lblFilterRefLanguage.TabIndex = 6;
			  this.lblFilterRefLanguage.Text = "Reference language";
			  // 
			  // btnFilter
			  // 
			  this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			  this.btnFilter.Location = new System.Drawing.Point(655, 17);
			  this.btnFilter.Name = "btnFilter";
			  this.btnFilter.Size = new System.Drawing.Size(75, 46);
			  this.btnFilter.TabIndex = 11;
			  this.btnFilter.Text = "Apply";
			  this.btnFilter.UseVisualStyleBackColor = true;
			  this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			  // 
			  // cbxFilterG2
			  // 
			  this.cbxFilterG2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			  this.cbxFilterG2.FormattingEnabled = true;
			  this.cbxFilterG2.Location = new System.Drawing.Point(413, 19);
			  this.cbxFilterG2.Name = "cbxFilterG2";
			  this.cbxFilterG2.Size = new System.Drawing.Size(121, 21);
			  this.cbxFilterG2.TabIndex = 5;
			  // 
			  // lblFilterG2
			  // 
			  this.lblFilterG2.AutoSize = true;
			  this.lblFilterG2.Location = new System.Drawing.Point(362, 22);
			  this.lblFilterG2.Name = "lblFilterG2";
			  this.lblFilterG2.Size = new System.Drawing.Size(45, 13);
			  this.lblFilterG2.TabIndex = 4;
			  this.lblFilterG2.Text = "Group 2";
			  // 
			  // cbxFilterG1
			  // 
			  this.cbxFilterG1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			  this.cbxFilterG1.FormattingEnabled = true;
			  this.cbxFilterG1.Location = new System.Drawing.Point(235, 19);
			  this.cbxFilterG1.Name = "cbxFilterG1";
			  this.cbxFilterG1.Size = new System.Drawing.Size(121, 21);
			  this.cbxFilterG1.TabIndex = 3;
			  this.cbxFilterG1.SelectedIndexChanged += new System.EventHandler(this.cbxFilterG1_SelectedIndexChanged);
			  // 
			  // lblFilterG1
			  // 
			  this.lblFilterG1.AutoSize = true;
			  this.lblFilterG1.Location = new System.Drawing.Point(184, 22);
			  this.lblFilterG1.Name = "lblFilterG1";
			  this.lblFilterG1.Size = new System.Drawing.Size(45, 13);
			  this.lblFilterG1.TabIndex = 2;
			  this.lblFilterG1.Text = "Group 1";
			  // 
			  // cbxFilterG0
			  // 
			  this.cbxFilterG0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			  this.cbxFilterG0.FormattingEnabled = true;
			  this.cbxFilterG0.Location = new System.Drawing.Point(57, 19);
			  this.cbxFilterG0.Name = "cbxFilterG0";
			  this.cbxFilterG0.Size = new System.Drawing.Size(121, 21);
			  this.cbxFilterG0.TabIndex = 1;
			  this.cbxFilterG0.SelectedIndexChanged += new System.EventHandler(this.cbxFilterG0_SelectedIndexChanged);
			  // 
			  // lblFilterG0
			  // 
			  this.lblFilterG0.AutoSize = true;
			  this.lblFilterG0.Location = new System.Drawing.Point(6, 22);
			  this.lblFilterG0.Name = "lblFilterG0";
			  this.lblFilterG0.Size = new System.Drawing.Size(45, 13);
			  this.lblFilterG0.TabIndex = 0;
			  this.lblFilterG0.Text = "Group 0";
			  // 
			  // mnuMain
			  // 
			  this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
			  this.mnuMain.Location = new System.Drawing.Point(0, 0);
			  this.mnuMain.Name = "mnuMain";
			  this.mnuMain.Size = new System.Drawing.Size(760, 24);
			  this.mnuMain.TabIndex = 0;
			  // 
			  // mnuFile
			  // 
			  this.mnuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			  this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniNew,
            this.mniOpen,
            this.mniSave,
            this.mniSaveAs});
			  this.mnuFile.Name = "mnuFile";
			  this.mnuFile.Size = new System.Drawing.Size(37, 20);
			  this.mnuFile.Text = "&File";
			  // 
			  // mniNew
			  // 
			  this.mniNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			  this.mniNew.Name = "mniNew";
			  this.mniNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			  this.mniNew.Size = new System.Drawing.Size(222, 22);
			  this.mniNew.Text = "New...";
			  this.mniNew.Click += new System.EventHandler(this.mniNew_Click);
			  // 
			  // mniOpen
			  // 
			  this.mniOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			  this.mniOpen.Name = "mniOpen";
			  this.mniOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			  this.mniOpen.Size = new System.Drawing.Size(222, 22);
			  this.mniOpen.Text = "&Open...";
			  this.mniOpen.Click += new System.EventHandler(this.mniOpen_Click);
			  // 
			  // mniSave
			  // 
			  this.mniSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			  this.mniSave.Name = "mniSave";
			  this.mniSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			  this.mniSave.Size = new System.Drawing.Size(222, 22);
			  this.mniSave.Text = "&Save";
			  this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
			  // 
			  // mniSaveAs
			  // 
			  this.mniSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			  this.mniSaveAs.Name = "mniSaveAs";
			  this.mniSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
							  | System.Windows.Forms.Keys.S)));
			  this.mniSaveAs.Size = new System.Drawing.Size(222, 22);
			  this.mniSaveAs.Text = "Save &as...";
			  this.mniSaveAs.Click += new System.EventHandler(this.mniSaveAs_Click);
			  // 
			  // frmMain
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			  this.ClientSize = new System.Drawing.Size(760, 517);
			  this.Controls.Add(this.gbxFilter);
			  this.Controls.Add(this.dgvTrans);
			  this.Controls.Add(this.mnuMain);
			  this.MainMenuStrip = this.mnuMain;
			  this.Name = "frmMain";
			  this.Text = "ETTrans";
			  this.Shown += new System.EventHandler(this.frmMain_Shown);
			  this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			  ((System.ComponentModel.ISupportInitialize)(this.dgvTrans)).EndInit();
			  this.gbxFilter.ResumeLayout(false);
			  this.gbxFilter.PerformLayout();
			  this.mnuMain.ResumeLayout(false);
			  this.mnuMain.PerformLayout();
			  this.ResumeLayout(false);
			  this.PerformLayout();

        }

        #endregion

		 private System.Windows.Forms.DataGridView dgvTrans;
		 private System.Windows.Forms.GroupBox gbxFilter;
		 private System.Windows.Forms.Label lblFilterG0;
		 private System.Windows.Forms.ComboBox cbxFilterG0;
		 private System.Windows.Forms.ComboBox cbxFilterG2;
		 private System.Windows.Forms.Label lblFilterG2;
		 private System.Windows.Forms.ComboBox cbxFilterG1;
		 private System.Windows.Forms.Label lblFilterG1;
		 private System.Windows.Forms.Button btnFilter;
		 private System.Windows.Forms.ComboBox cbxFilterRefLanguage;
		 private System.Windows.Forms.Label lblFilterRefLanguage;
		 private System.Windows.Forms.ComboBox cbxFilterTransLang;
		 private System.Windows.Forms.Label lblFilterTransLang;
		 private System.Windows.Forms.MenuStrip mnuMain;
		 private System.Windows.Forms.ToolStripMenuItem mnuFile;
		 private System.Windows.Forms.ToolStripMenuItem mniOpen;
		 private System.Windows.Forms.ToolStripMenuItem mniSave;
		 private System.Windows.Forms.ToolStripMenuItem mniSaveAs;
		 private System.Windows.Forms.ToolStripMenuItem mniNew;
		 private System.Windows.Forms.DataGridViewTextBoxColumn colID;
		 private System.Windows.Forms.DataGridViewTextBoxColumn colRef;
		 private System.Windows.Forms.DataGridViewTextBoxColumn colTrans;
		 private System.Windows.Forms.DataGridViewLinkColumn colValues;
		 private System.Windows.Forms.CheckBox chkFilterInlinevalues;
    }
}

