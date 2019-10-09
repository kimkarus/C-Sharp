namespace NalogAdministrator.Controls
{
    partial class UserControlImportDataPopulation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFolderData = new System.Windows.Forms.TextBox();
            this.btSelectFolderData = new System.Windows.Forms.Button();
            this.groupBoxExcelSheets = new System.Windows.Forms.GroupBox();
            this.listTablesView = new System.Windows.Forms.ListBox();
            this.dataGridViewPopulation = new System.Windows.Forms.DataGridView();
            this.btAdd = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chAddEea = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxExcelSheets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopulation)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFolderData);
            this.groupBox1.Controls.Add(this.btSelectFolderData);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 49);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите папку";
            // 
            // txtFolderData
            // 
            this.txtFolderData.Location = new System.Drawing.Point(6, 19);
            this.txtFolderData.Name = "txtFolderData";
            this.txtFolderData.Size = new System.Drawing.Size(467, 20);
            this.txtFolderData.TabIndex = 12;
            // 
            // btSelectFolderData
            // 
            this.btSelectFolderData.Location = new System.Drawing.Point(479, 17);
            this.btSelectFolderData.Name = "btSelectFolderData";
            this.btSelectFolderData.Size = new System.Drawing.Size(83, 23);
            this.btSelectFolderData.TabIndex = 13;
            this.btSelectFolderData.Text = "Выбрать";
            this.btSelectFolderData.UseVisualStyleBackColor = true;
            this.btSelectFolderData.Click += new System.EventHandler(this.btSelectFolderData_Click);
            // 
            // groupBoxExcelSheets
            // 
            this.groupBoxExcelSheets.Controls.Add(this.listTablesView);
            this.groupBoxExcelSheets.Location = new System.Drawing.Point(3, 59);
            this.groupBoxExcelSheets.Name = "groupBoxExcelSheets";
            this.groupBoxExcelSheets.Size = new System.Drawing.Size(200, 115);
            this.groupBoxExcelSheets.TabIndex = 19;
            this.groupBoxExcelSheets.TabStop = false;
            this.groupBoxExcelSheets.Text = "Листы";
            // 
            // listTablesView
            // 
            this.listTablesView.FormattingEnabled = true;
            this.listTablesView.Location = new System.Drawing.Point(7, 20);
            this.listTablesView.Name = "listTablesView";
            this.listTablesView.Size = new System.Drawing.Size(187, 82);
            this.listTablesView.TabIndex = 0;
            this.listTablesView.Click += new System.EventHandler(this.listTablesView_Click);
            // 
            // dataGridViewPopulation
            // 
            this.dataGridViewPopulation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPopulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPopulation.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPopulation.Name = "dataGridViewPopulation";
            this.dataGridViewPopulation.RowTemplate.Height = 24;
            this.dataGridViewPopulation.Size = new System.Drawing.Size(587, 356);
            this.dataGridViewPopulation.TabIndex = 0;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(209, 151);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 21;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chAddEea);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btAdd);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxExcelSheets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewPopulation);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(587, 581);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 22;
            // 
            // chAddEea
            // 
            this.chAddEea.AutoSize = true;
            this.chAddEea.Location = new System.Drawing.Point(210, 79);
            this.chAddEea.Name = "chAddEea";
            this.chAddEea.Size = new System.Drawing.Size(66, 17);
            this.chAddEea.TabIndex = 22;
            this.chAddEea.Text = "По ВЭД";
            this.chAddEea.UseVisualStyleBackColor = true;
            // 
            // UserControlImportDataPopulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlImportDataPopulation";
            this.Size = new System.Drawing.Size(587, 581);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxExcelSheets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopulation)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFolderData;
        private System.Windows.Forms.Button btSelectFolderData;
        private System.Windows.Forms.GroupBox groupBoxExcelSheets;
        private System.Windows.Forms.Button btAdd;
        public System.Windows.Forms.ListBox listTablesView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.DataGridView dataGridViewPopulation;
        private System.Windows.Forms.CheckBox chAddEea;

    }
}
