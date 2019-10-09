namespace NalogUser.Controls.AnalysisData
{
    partial class UserControlTaxes
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
            this.btClearAll = new System.Windows.Forms.Button();
            this.btDone = new System.Windows.Forms.Button();
            this.chkLstTaxes = new System.Windows.Forms.CheckedListBox();
            this.base_nalogDataSet = new NalogUser.base_nalogDataSet();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.taxesTableAdapter = new NalogUser.base_nalogDataSetTableAdapters.TaxesTableAdapter();
            this.taxesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btClearAll
            // 
            this.btClearAll.Location = new System.Drawing.Point(177, 7);
            this.btClearAll.Name = "btClearAll";
            this.btClearAll.Size = new System.Drawing.Size(135, 23);
            this.btClearAll.TabIndex = 6;
            this.btClearAll.Text = "Очистить выбор";
            this.btClearAll.UseVisualStyleBackColor = true;
            // 
            // btDone
            // 
            this.btDone.Location = new System.Drawing.Point(237, 383);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(75, 23);
            this.btDone.TabIndex = 5;
            this.btDone.Text = "Готово";
            this.btDone.UseVisualStyleBackColor = true;
            // 
            // chkLstTaxes
            // 
            this.chkLstTaxes.FormattingEnabled = true;
            this.chkLstTaxes.Location = new System.Drawing.Point(3, 36);
            this.chkLstTaxes.Name = "chkLstTaxes";
            this.chkLstTaxes.Size = new System.Drawing.Size(309, 334);
            this.chkLstTaxes.TabIndex = 4;
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(6, 7);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(135, 23);
            this.btSelectAll.TabIndex = 7;
            this.btSelectAll.Text = "Выбрать все";
            this.btSelectAll.UseVisualStyleBackColor = true;
            // 
            // taxesTableAdapter
            // 
            this.taxesTableAdapter.ClearBeforeFill = true;
            // 
            // taxesBindingSource
            // 
            this.taxesBindingSource.DataMember = "Taxes";
            this.taxesBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // UserControlTaxes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btClearAll);
            this.Controls.Add(this.btDone);
            this.Controls.Add(this.chkLstTaxes);
            this.Controls.Add(this.btSelectAll);
            this.Name = "UserControlTaxes";
            this.Size = new System.Drawing.Size(324, 416);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClearAll;
        public System.Windows.Forms.Button btDone;
        public System.Windows.Forms.CheckedListBox chkLstTaxes;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.Button btSelectAll;
        private base_nalogDataSetTableAdapters.TaxesTableAdapter taxesTableAdapter;
        private System.Windows.Forms.BindingSource taxesBindingSource;
    }
}
