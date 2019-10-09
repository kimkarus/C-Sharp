namespace NalogAdministrator.Controls
{
    partial class UserControlImportDataReportDefaultTools
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
            this.components = new System.ComponentModel.Container();
            this.btLoadFolders = new System.Windows.Forms.Button();
            this.btSelectFolderData = new System.Windows.Forms.Button();
            this.txtFolderData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxListFiles = new System.Windows.Forms.GroupBox();
            this.listBoxFolderFiles = new System.Windows.Forms.ListBox();
            this.importDataFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FoldersDataTreeView = new System.Windows.Forms.TreeView();
            this.groupBoxTree = new System.Windows.Forms.GroupBox();
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.btAdd = new System.Windows.Forms.Button();
            this.selectFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.chExcel = new System.Windows.Forms.CheckBox();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.txtChoceYearAfter = new System.Windows.Forms.TextBox();
            this.chYear = new System.Windows.Forms.CheckBox();
            this.chFolder = new System.Windows.Forms.CheckBox();
            this.txtChoceYearBefore = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxListOfTaxes = new System.Windows.Forms.CheckBox();
            this.checkBoxIsImportOneList = new System.Windows.Forms.CheckBox();
            this.chListSubjects = new System.Windows.Forms.CheckBox();
            this.chAllInOne = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxForcast = new System.Windows.Forms.CheckBox();
            this.ch1NOM = new System.Windows.Forms.CheckBox();
            this.ch1NM = new System.Windows.Forms.CheckBox();
            this.btCalculate1NOM = new System.Windows.Forms.Button();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxListFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importDataFileBindingSource)).BeginInit();
            this.groupBoxTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLoadFolders
            // 
            this.btLoadFolders.Location = new System.Drawing.Point(414, 17);
            this.btLoadFolders.Name = "btLoadFolders";
            this.btLoadFolders.Size = new System.Drawing.Size(103, 23);
            this.btLoadFolders.TabIndex = 14;
            this.btLoadFolders.Text = "Показать папки";
            this.btLoadFolders.UseVisualStyleBackColor = true;
            this.btLoadFolders.Click += new System.EventHandler(this.btLoadFolders_Click);
            // 
            // btSelectFolderData
            // 
            this.btSelectFolderData.Location = new System.Drawing.Point(325, 17);
            this.btSelectFolderData.Name = "btSelectFolderData";
            this.btSelectFolderData.Size = new System.Drawing.Size(83, 23);
            this.btSelectFolderData.TabIndex = 13;
            this.btSelectFolderData.Text = "Выбрать";
            this.btSelectFolderData.UseVisualStyleBackColor = true;
            this.btSelectFolderData.Click += new System.EventHandler(this.btSelectFolderData_Click);
            // 
            // txtFolderData
            // 
            this.txtFolderData.Location = new System.Drawing.Point(6, 19);
            this.txtFolderData.Name = "txtFolderData";
            this.txtFolderData.Size = new System.Drawing.Size(313, 20);
            this.txtFolderData.TabIndex = 12;
            this.txtFolderData.TextChanged += new System.EventHandler(this.txtFolderData_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFolderData);
            this.groupBox1.Controls.Add(this.btSelectFolderData);
            this.groupBox1.Controls.Add(this.btLoadFolders);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 49);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите папку";
            // 
            // groupBoxListFiles
            // 
            this.groupBoxListFiles.Controls.Add(this.listBoxFolderFiles);
            this.groupBoxListFiles.Location = new System.Drawing.Point(256, 58);
            this.groupBoxListFiles.Name = "groupBoxListFiles";
            this.groupBoxListFiles.Size = new System.Drawing.Size(270, 148);
            this.groupBoxListFiles.TabIndex = 18;
            this.groupBoxListFiles.TabStop = false;
            this.groupBoxListFiles.Text = "Список файлов";
            // 
            // listBoxFolderFiles
            // 
            this.listBoxFolderFiles.FormattingEnabled = true;
            this.listBoxFolderFiles.Location = new System.Drawing.Point(12, 19);
            this.listBoxFolderFiles.Name = "listBoxFolderFiles";
            this.listBoxFolderFiles.Size = new System.Drawing.Size(252, 121);
            this.listBoxFolderFiles.TabIndex = 0;
            this.listBoxFolderFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFolderFiles_SelectedIndexChanged);
            // 
            // FoldersDataTreeView
            // 
            this.FoldersDataTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoldersDataTreeView.Location = new System.Drawing.Point(3, 16);
            this.FoldersDataTreeView.Name = "FoldersDataTreeView";
            this.FoldersDataTreeView.Size = new System.Drawing.Size(235, 343);
            this.FoldersDataTreeView.TabIndex = 20;
            this.FoldersDataTreeView.DoubleClick += new System.EventHandler(this.FoldersDataTreeView_DoubleClick);
            // 
            // groupBoxTree
            // 
            this.groupBoxTree.Controls.Add(this.FoldersDataTreeView);
            this.groupBoxTree.Location = new System.Drawing.Point(9, 58);
            this.groupBoxTree.Name = "groupBoxTree";
            this.groupBoxTree.Size = new System.Drawing.Size(241, 362);
            this.groupBoxTree.TabIndex = 21;
            this.groupBoxTree.TabStop = false;
            this.groupBoxTree.Text = "Древо папок";
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(416, 397);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(107, 23);
            this.btAdd.TabIndex = 22;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // chExcel
            // 
            this.chExcel.AutoSize = true;
            this.chExcel.Checked = true;
            this.chExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chExcel.Location = new System.Drawing.Point(128, 19);
            this.chExcel.Name = "chExcel";
            this.chExcel.Size = new System.Drawing.Size(52, 17);
            this.chExcel.TabIndex = 33;
            this.chExcel.Text = "Excel";
            this.chExcel.UseVisualStyleBackColor = true;
            this.chExcel.CheckedChanged += new System.EventHandler(this.chExcel_CheckedChanged);
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.AutoSize = true;
            this.lblSubjectName.Location = new System.Drawing.Point(256, 214);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(0, 13);
            this.lblSubjectName.TabIndex = 34;
            // 
            // txtChoceYearAfter
            // 
            this.txtChoceYearAfter.Enabled = false;
            this.txtChoceYearAfter.Location = new System.Drawing.Point(6, 42);
            this.txtChoceYearAfter.Name = "txtChoceYearAfter";
            this.txtChoceYearAfter.Size = new System.Drawing.Size(54, 20);
            this.txtChoceYearAfter.TabIndex = 35;
            // 
            // chYear
            // 
            this.chYear.AutoSize = true;
            this.chYear.Location = new System.Drawing.Point(6, 19);
            this.chYear.Name = "chYear";
            this.chYear.Size = new System.Drawing.Size(44, 17);
            this.chYear.TabIndex = 37;
            this.chYear.Text = "Год";
            this.chYear.UseVisualStyleBackColor = true;
            this.chYear.CheckedChanged += new System.EventHandler(this.chYear_CheckedChanged);
            // 
            // chFolder
            // 
            this.chFolder.AutoSize = true;
            this.chFolder.Checked = true;
            this.chFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chFolder.Location = new System.Drawing.Point(186, 19);
            this.chFolder.Name = "chFolder";
            this.chFolder.Size = new System.Drawing.Size(58, 17);
            this.chFolder.TabIndex = 38;
            this.chFolder.Text = "Папка";
            this.chFolder.UseVisualStyleBackColor = true;
            // 
            // txtChoceYearBefore
            // 
            this.txtChoceYearBefore.Enabled = false;
            this.txtChoceYearBefore.Location = new System.Drawing.Point(66, 42);
            this.txtChoceYearBefore.Name = "txtChoceYearBefore";
            this.txtChoceYearBefore.Size = new System.Drawing.Size(54, 20);
            this.txtChoceYearBefore.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxListOfTaxes);
            this.groupBox2.Controls.Add(this.checkBoxIsImportOneList);
            this.groupBox2.Controls.Add(this.chListSubjects);
            this.groupBox2.Controls.Add(this.chAllInOne);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkBoxForcast);
            this.groupBox2.Controls.Add(this.ch1NOM);
            this.groupBox2.Controls.Add(this.ch1NM);
            this.groupBox2.Controls.Add(this.chYear);
            this.groupBox2.Controls.Add(this.txtChoceYearBefore);
            this.groupBox2.Controls.Add(this.chExcel);
            this.groupBox2.Controls.Add(this.chFolder);
            this.groupBox2.Controls.Add(this.txtChoceYearAfter);
            this.groupBox2.Location = new System.Drawing.Point(262, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 164);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // checkBoxListOfTaxes
            // 
            this.checkBoxListOfTaxes.AutoSize = true;
            this.checkBoxListOfTaxes.Location = new System.Drawing.Point(6, 114);
            this.checkBoxListOfTaxes.Name = "checkBoxListOfTaxes";
            this.checkBoxListOfTaxes.Size = new System.Drawing.Size(107, 17);
            this.checkBoxListOfTaxes.TabIndex = 47;
            this.checkBoxListOfTaxes.Text = "Список налогов";
            this.checkBoxListOfTaxes.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsImportOneList
            // 
            this.checkBoxIsImportOneList.AutoSize = true;
            this.checkBoxIsImportOneList.Location = new System.Drawing.Point(100, 68);
            this.checkBoxIsImportOneList.Name = "checkBoxIsImportOneList";
            this.checkBoxIsImportOneList.Size = new System.Drawing.Size(111, 17);
            this.checkBoxIsImportOneList.TabIndex = 46;
            this.checkBoxIsImportOneList.Text = "Импорт по листу";
            this.checkBoxIsImportOneList.UseVisualStyleBackColor = true;
            // 
            // chListSubjects
            // 
            this.chListSubjects.AutoSize = true;
            this.chListSubjects.Location = new System.Drawing.Point(101, 91);
            this.chListSubjects.Name = "chListSubjects";
            this.chListSubjects.Size = new System.Drawing.Size(168, 17);
            this.chListSubjects.TabIndex = 45;
            this.chListSubjects.Text = "Из списка кодов субъектов";
            this.chListSubjects.UseVisualStyleBackColor = true;
            // 
            // chAllInOne
            // 
            this.chAllInOne.AutoSize = true;
            this.chAllInOne.Location = new System.Drawing.Point(6, 91);
            this.chAllInOne.Name = "chAllInOne";
            this.chAllInOne.Size = new System.Drawing.Size(89, 17);
            this.chAllInOne.TabIndex = 44;
            this.chAllInOne.Text = "Все в одном";
            this.chAllInOne.UseVisualStyleBackColor = true;
            this.chAllInOne.CheckedChanged += new System.EventHandler(this.chAllinOne_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 43;
            // 
            // checkBoxForcast
            // 
            this.checkBoxForcast.AutoSize = true;
            this.checkBoxForcast.Location = new System.Drawing.Point(6, 68);
            this.checkBoxForcast.Name = "checkBoxForcast";
            this.checkBoxForcast.Size = new System.Drawing.Size(87, 17);
            this.checkBoxForcast.TabIndex = 42;
            this.checkBoxForcast.Text = "Прогнозное";
            this.checkBoxForcast.UseVisualStyleBackColor = true;
            this.checkBoxForcast.CheckedChanged += new System.EventHandler(this.checkBoxForcast_CheckedChanged);
            // 
            // ch1NOM
            // 
            this.ch1NOM.AutoSize = true;
            this.ch1NOM.Checked = true;
            this.ch1NOM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch1NOM.Location = new System.Drawing.Point(128, 42);
            this.ch1NOM.Name = "ch1NOM";
            this.ch1NOM.Size = new System.Drawing.Size(60, 17);
            this.ch1NOM.TabIndex = 41;
            this.ch1NOM.Text = "1-НОМ";
            this.ch1NOM.UseVisualStyleBackColor = true;
            this.ch1NOM.CheckedChanged += new System.EventHandler(this.ch1NOM_CheckedChanged);
            // 
            // ch1NM
            // 
            this.ch1NM.AutoSize = true;
            this.ch1NM.Checked = true;
            this.ch1NM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch1NM.Location = new System.Drawing.Point(186, 42);
            this.ch1NM.Name = "ch1NM";
            this.ch1NM.Size = new System.Drawing.Size(52, 17);
            this.ch1NM.TabIndex = 40;
            this.ch1NM.Text = "1-НМ";
            this.ch1NM.UseVisualStyleBackColor = true;
            this.ch1NM.CheckedChanged += new System.EventHandler(this.ch1NM_CheckedChanged);
            // 
            // btCalculate1NOM
            // 
            this.btCalculate1NOM.Location = new System.Drawing.Point(259, 397);
            this.btCalculate1NOM.Name = "btCalculate1NOM";
            this.btCalculate1NOM.Size = new System.Drawing.Size(148, 23);
            this.btCalculate1NOM.TabIndex = 41;
            this.btCalculate1NOM.Text = "Скалькулировать 1-НОМ";
            this.btCalculate1NOM.UseVisualStyleBackColor = true;
            this.btCalculate1NOM.Click += new System.EventHandler(this.btCalculate1NOM_Click);
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(423, 207);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(100, 20);
            this.txtTarget.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Метка";
            // 
            // UserControlImportDataReportDefaultTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.btCalculate1NOM);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblSubjectName);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.groupBoxTree);
            this.Controls.Add(this.groupBoxListFiles);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlImportDataReportDefaultTools";
            this.Size = new System.Drawing.Size(539, 423);
            this.Load += new System.EventHandler(this.UserControlImportDataReportDefaultTools_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxListFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.importDataFileBindingSource)).EndInit();
            this.groupBoxTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLoadFolders;
        private System.Windows.Forms.Button btSelectFolderData;
        private System.Windows.Forms.TextBox txtFolderData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxListFiles;
        private System.Windows.Forms.GroupBox groupBoxTree;
        private System.Windows.Forms.Button btAdd;
        public System.Windows.Forms.TreeView FoldersDataTreeView;
        public base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.FolderBrowserDialog selectFolderBrowserDialog;
        private System.Windows.Forms.BindingSource importDataFileBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblSubjectName;
        private System.Windows.Forms.TextBox txtChoceYearAfter;
        private System.Windows.Forms.CheckBox chYear;
        private System.Windows.Forms.CheckBox chFolder;
        public System.Windows.Forms.CheckBox chExcel;
        private System.Windows.Forms.TextBox txtChoceYearBefore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ch1NOM;
        private System.Windows.Forms.CheckBox ch1NM;
        private System.Windows.Forms.Button btCalculate1NOM;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.CheckBox checkBoxForcast;
        private System.Windows.Forms.ListBox listBoxFolderFiles;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox chAllInOne;
        public System.Windows.Forms.CheckBox chListSubjects;
        private System.Windows.Forms.CheckBox checkBoxIsImportOneList;
        public System.Windows.Forms.CheckBox checkBoxListOfTaxes;
    }
}
