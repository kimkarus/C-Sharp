namespace NalogUser.Controls.AnalysisData
{
    partial class UserControlSubjects
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
            this.chkLstSubjects = new System.Windows.Forms.CheckedListBox();
            this.base_nalogDataSet = new NalogUser.base_nalogDataSet();
            this.subjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectsTableAdapter = new NalogUser.base_nalogDataSetTableAdapters.SubjectsTableAdapter();
            this.btDone = new System.Windows.Forms.Button();
            this.btClearAll = new System.Windows.Forms.Button();
            this.btSelectAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chkLstSubjects
            // 
            this.chkLstSubjects.FormattingEnabled = true;
            this.chkLstSubjects.Location = new System.Drawing.Point(3, 32);
            this.chkLstSubjects.Name = "chkLstSubjects";
            this.chkLstSubjects.Size = new System.Drawing.Size(309, 334);
            this.chkLstSubjects.TabIndex = 0;
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // subjectsBindingSource
            // 
            this.subjectsBindingSource.DataMember = "Subjects";
            this.subjectsBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // subjectsTableAdapter
            // 
            this.subjectsTableAdapter.ClearBeforeFill = true;
            // 
            // btDone
            // 
            this.btDone.Location = new System.Drawing.Point(237, 379);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(75, 23);
            this.btDone.TabIndex = 1;
            this.btDone.Text = "Готово";
            this.btDone.UseVisualStyleBackColor = true;
            // 
            // btClearAll
            // 
            this.btClearAll.Location = new System.Drawing.Point(177, 3);
            this.btClearAll.Name = "btClearAll";
            this.btClearAll.Size = new System.Drawing.Size(135, 23);
            this.btClearAll.TabIndex = 2;
            this.btClearAll.Text = "Очистить выбор";
            this.btClearAll.UseVisualStyleBackColor = true;
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(6, 3);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(135, 23);
            this.btSelectAll.TabIndex = 3;
            this.btSelectAll.Text = "Выбрать все";
            this.btSelectAll.UseVisualStyleBackColor = true;
            // 
            // UserControlSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btSelectAll);
            this.Controls.Add(this.btClearAll);
            this.Controls.Add(this.btDone);
            this.Controls.Add(this.chkLstSubjects);
            this.Name = "UserControlSubjects";
            this.Size = new System.Drawing.Size(319, 405);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource subjectsBindingSource;
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter;
        private System.Windows.Forms.Button btClearAll;
        private System.Windows.Forms.Button btSelectAll;
        public System.Windows.Forms.CheckedListBox chkLstSubjects;
        public System.Windows.Forms.Button btDone;
    }
}
