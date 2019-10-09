namespace NalogAdministrator.Controls.ImportData
{
    partial class UserControlImportDataSubjectIndex
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
            this.groupBoxImportIndex = new System.Windows.Forms.GroupBox();
            this.radioButtonCPI = new System.Windows.Forms.RadioButton();
            this.radioButtonDRP = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewPopulation = new System.Windows.Forms.DataGridView();
            this.btStart = new System.Windows.Forms.Button();
            this.groupBoxListViewBox = new System.Windows.Forms.GroupBox();
            this.listTablesView = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxImportIndex.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopulation)).BeginInit();
            this.groupBoxListViewBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFolderData);
            this.groupBox1.Controls.Add(this.btSelectFolderData);
            this.groupBox1.Location = new System.Drawing.Point(15, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 49);
            this.groupBox1.TabIndex = 19;
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
            // groupBoxImportIndex
            // 
            this.groupBoxImportIndex.Controls.Add(this.radioButtonDRP);
            this.groupBoxImportIndex.Controls.Add(this.radioButtonCPI);
            this.groupBoxImportIndex.Location = new System.Drawing.Point(9, 58);
            this.groupBoxImportIndex.Name = "groupBoxImportIndex";
            this.groupBoxImportIndex.Size = new System.Drawing.Size(581, 55);
            this.groupBoxImportIndex.TabIndex = 20;
            this.groupBoxImportIndex.TabStop = false;
            this.groupBoxImportIndex.Text = "Импортируемые показатели";
            // 
            // radioButtonCPI
            // 
            this.radioButtonCPI.AutoSize = true;
            this.radioButtonCPI.Location = new System.Drawing.Point(6, 19);
            this.radioButtonCPI.Name = "radioButtonCPI";
            this.radioButtonCPI.Size = new System.Drawing.Size(49, 17);
            this.radioButtonCPI.TabIndex = 0;
            this.radioButtonCPI.TabStop = true;
            this.radioButtonCPI.Text = "ИПЦ";
            this.radioButtonCPI.UseVisualStyleBackColor = true;
            // 
            // radioButtonDRP
            // 
            this.radioButtonDRP.AutoSize = true;
            this.radioButtonDRP.Location = new System.Drawing.Point(61, 19);
            this.radioButtonDRP.Name = "radioButtonDRP";
            this.radioButtonDRP.Size = new System.Drawing.Size(47, 17);
            this.radioButtonDRP.TabIndex = 1;
            this.radioButtonDRP.TabStop = true;
            this.radioButtonDRP.Text = "ВРП";
            this.radioButtonDRP.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxListViewBox);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxImportIndex);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewPopulation);
            this.splitContainer1.Size = new System.Drawing.Size(606, 610);
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.TabIndex = 21;
            // 
            // dataGridViewPopulation
            // 
            this.dataGridViewPopulation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPopulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPopulation.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPopulation.Name = "dataGridViewPopulation";
            this.dataGridViewPopulation.RowTemplate.Height = 24;
            this.dataGridViewPopulation.Size = new System.Drawing.Size(606, 301);
            this.dataGridViewPopulation.TabIndex = 1;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(199, 78);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 21;
            this.btStart.Text = "Добавить";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // groupBoxListViewBox
            // 
            this.groupBoxListViewBox.Controls.Add(this.btStart);
            this.groupBoxListViewBox.Controls.Add(this.listTablesView);
            this.groupBoxListViewBox.Location = new System.Drawing.Point(9, 119);
            this.groupBoxListViewBox.Name = "groupBoxListViewBox";
            this.groupBoxListViewBox.Size = new System.Drawing.Size(581, 110);
            this.groupBoxListViewBox.TabIndex = 21;
            this.groupBoxListViewBox.TabStop = false;
            this.groupBoxListViewBox.Text = "Листы";
            // 
            // listTablesView
            // 
            this.listTablesView.FormattingEnabled = true;
            this.listTablesView.Location = new System.Drawing.Point(6, 19);
            this.listTablesView.Name = "listTablesView";
            this.listTablesView.Size = new System.Drawing.Size(187, 82);
            this.listTablesView.TabIndex = 1;
            // 
            // UserControlImportDataSubjectIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlImportDataSubjectIndex";
            this.Size = new System.Drawing.Size(606, 610);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxImportIndex.ResumeLayout(false);
            this.groupBoxImportIndex.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopulation)).EndInit();
            this.groupBoxListViewBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFolderData;
        private System.Windows.Forms.Button btSelectFolderData;
        private System.Windows.Forms.GroupBox groupBoxImportIndex;
        private System.Windows.Forms.RadioButton radioButtonDRP;
        private System.Windows.Forms.RadioButton radioButtonCPI;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.DataGridView dataGridViewPopulation;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.GroupBox groupBoxListViewBox;
        public System.Windows.Forms.ListBox listTablesView;
    }
}
