 namespace NalogAdministrator.Controls
{
    partial class UserControlAnalysisDataDefault
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
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxDistrict = new System.Windows.Forms.CheckBox();
            this.comboBoxDistrict = new System.Windows.Forms.ComboBox();
            this.federaldistrictBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxSubject = new System.Windows.Forms.CheckBox();
            this.comboBoxSubjetcs = new System.Windows.Forms.ComboBox();
            this.subjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxTax = new System.Windows.Forms.CheckBox();
            this.comboBoxTaxes = new System.Windows.Forms.ComboBox();
            this.taxesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxTaxEea = new System.Windows.Forms.CheckBox();
            this.comboBoxTaxesEea = new System.Windows.Forms.ComboBox();
            this.taxesvedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxYears = new System.Windows.Forms.CheckBox();
            this.comboBoxYearAfter = new System.Windows.Forms.ComboBox();
            this.comboBoxYearBefore = new System.Windows.Forms.ComboBox();
            this.federal_districtTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Federal_districtTableAdapter();
            this.taxesTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.TaxesTableAdapter();
            this.taxes_vedTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Taxes_vedTableAdapter();
            this.subjectsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.SubjectsTableAdapter();
            this.checkBoxBudget = new System.Windows.Forms.CheckBox();
            this.comboBoxBudgets = new System.Windows.Forms.ComboBox();
            this.taxesbudgetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taxes_budgetsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Taxes_budgetsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.federaldistrictBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesvedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesbudgetsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.checkBoxDistrict);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxDistrict);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSubject);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxSubjetcs);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxTax);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxTaxes);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxTaxEea);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxTaxesEea);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxBudget);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxBudgets);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxYears);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxYearAfter);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxYearBefore);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15, 10, 15, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(368, 182);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // checkBoxDistrict
            // 
            this.checkBoxDistrict.AutoSize = true;
            this.checkBoxDistrict.Location = new System.Drawing.Point(18, 13);
            this.checkBoxDistrict.Name = "checkBoxDistrict";
            this.checkBoxDistrict.Size = new System.Drawing.Size(130, 17);
            this.checkBoxDistrict.TabIndex = 13;
            this.checkBoxDistrict.Text = "Федеральный округ";
            this.checkBoxDistrict.UseVisualStyleBackColor = true;
            this.checkBoxDistrict.CheckedChanged += new System.EventHandler(this.checkBoxDistrict_CheckedChanged);
            // 
            // comboBoxDistrict
            // 
            this.comboBoxDistrict.DataSource = this.federaldistrictBindingSource;
            this.comboBoxDistrict.DisplayMember = "district_name";
            this.comboBoxDistrict.Enabled = false;
            this.comboBoxDistrict.FormattingEnabled = true;
            this.comboBoxDistrict.Location = new System.Drawing.Point(154, 13);
            this.comboBoxDistrict.Name = "comboBoxDistrict";
            this.comboBoxDistrict.Size = new System.Drawing.Size(163, 21);
            this.comboBoxDistrict.TabIndex = 4;
            this.comboBoxDistrict.ValueMember = "id";
            this.comboBoxDistrict.SelectedIndexChanged += new System.EventHandler(this.comboBoxDistrict_SelectedIndexChanged);
            // 
            // federaldistrictBindingSource
            // 
            this.federaldistrictBindingSource.DataMember = "Federal_district";
            this.federaldistrictBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // checkBoxSubject
            // 
            this.checkBoxSubject.AutoSize = true;
            this.checkBoxSubject.Location = new System.Drawing.Point(18, 40);
            this.checkBoxSubject.Name = "checkBoxSubject";
            this.checkBoxSubject.Size = new System.Drawing.Size(68, 17);
            this.checkBoxSubject.TabIndex = 12;
            this.checkBoxSubject.Text = "Субъект";
            this.checkBoxSubject.UseVisualStyleBackColor = true;
            this.checkBoxSubject.CheckedChanged += new System.EventHandler(this.checkBoxSubject_CheckedChanged);
            // 
            // comboBoxSubjetcs
            // 
            this.comboBoxSubjetcs.DataSource = this.subjectsBindingSource;
            this.comboBoxSubjetcs.DisplayMember = "subject_name";
            this.comboBoxSubjetcs.Enabled = false;
            this.comboBoxSubjetcs.FormattingEnabled = true;
            this.comboBoxSubjetcs.Location = new System.Drawing.Point(92, 40);
            this.comboBoxSubjetcs.Name = "comboBoxSubjetcs";
            this.comboBoxSubjetcs.Size = new System.Drawing.Size(225, 21);
            this.comboBoxSubjetcs.TabIndex = 20;
            this.comboBoxSubjetcs.ValueMember = "id";
            // 
            // subjectsBindingSource
            // 
            this.subjectsBindingSource.DataMember = "Subjects";
            this.subjectsBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // checkBoxTax
            // 
            this.checkBoxTax.AutoSize = true;
            this.checkBoxTax.Location = new System.Drawing.Point(18, 67);
            this.checkBoxTax.Name = "checkBoxTax";
            this.checkBoxTax.Size = new System.Drawing.Size(57, 17);
            this.checkBoxTax.TabIndex = 11;
            this.checkBoxTax.Text = "Налог";
            this.checkBoxTax.UseVisualStyleBackColor = true;
            this.checkBoxTax.CheckedChanged += new System.EventHandler(this.checkBoxTax_CheckedChanged);
            // 
            // comboBoxTaxes
            // 
            this.comboBoxTaxes.DataSource = this.taxesBindingSource;
            this.comboBoxTaxes.DisplayMember = "tax_name";
            this.comboBoxTaxes.DropDownWidth = 450;
            this.comboBoxTaxes.Enabled = false;
            this.comboBoxTaxes.FormattingEnabled = true;
            this.comboBoxTaxes.Location = new System.Drawing.Point(81, 67);
            this.comboBoxTaxes.Name = "comboBoxTaxes";
            this.comboBoxTaxes.Size = new System.Drawing.Size(236, 21);
            this.comboBoxTaxes.TabIndex = 7;
            this.comboBoxTaxes.ValueMember = "id";
            // 
            // taxesBindingSource
            // 
            this.taxesBindingSource.DataMember = "Taxes";
            this.taxesBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // checkBoxTaxEea
            // 
            this.checkBoxTaxEea.AutoSize = true;
            this.checkBoxTaxEea.Location = new System.Drawing.Point(18, 94);
            this.checkBoxTaxEea.Name = "checkBoxTaxEea";
            this.checkBoxTaxEea.Size = new System.Drawing.Size(49, 17);
            this.checkBoxTaxEea.TabIndex = 15;
            this.checkBoxTaxEea.Text = "ВЭД";
            this.checkBoxTaxEea.UseVisualStyleBackColor = true;
            this.checkBoxTaxEea.CheckedChanged += new System.EventHandler(this.checkBoxTaxEea_CheckedChanged);
            // 
            // comboBoxTaxesEea
            // 
            this.comboBoxTaxesEea.DataSource = this.taxesvedBindingSource;
            this.comboBoxTaxesEea.DisplayMember = "name";
            this.comboBoxTaxesEea.DropDownWidth = 450;
            this.comboBoxTaxesEea.Enabled = false;
            this.comboBoxTaxesEea.FormattingEnabled = true;
            this.comboBoxTaxesEea.Location = new System.Drawing.Point(73, 94);
            this.comboBoxTaxesEea.Name = "comboBoxTaxesEea";
            this.comboBoxTaxesEea.Size = new System.Drawing.Size(244, 21);
            this.comboBoxTaxesEea.TabIndex = 16;
            this.comboBoxTaxesEea.ValueMember = "id";
            // 
            // taxesvedBindingSource
            // 
            this.taxesvedBindingSource.DataMember = "Taxes_ved";
            this.taxesvedBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // checkBoxYears
            // 
            this.checkBoxYears.AutoSize = true;
            this.checkBoxYears.Location = new System.Drawing.Point(18, 148);
            this.checkBoxYears.Name = "checkBoxYears";
            this.checkBoxYears.Size = new System.Drawing.Size(44, 17);
            this.checkBoxYears.TabIndex = 14;
            this.checkBoxYears.Text = "Год";
            this.checkBoxYears.UseVisualStyleBackColor = true;
            this.checkBoxYears.CheckedChanged += new System.EventHandler(this.checkBoxYears_CheckedChanged);
            // 
            // comboBoxYearAfter
            // 
            this.comboBoxYearAfter.Enabled = false;
            this.comboBoxYearAfter.FormattingEnabled = true;
            this.comboBoxYearAfter.Location = new System.Drawing.Point(68, 148);
            this.comboBoxYearAfter.Name = "comboBoxYearAfter";
            this.comboBoxYearAfter.Size = new System.Drawing.Size(49, 21);
            this.comboBoxYearAfter.TabIndex = 18;
            this.comboBoxYearAfter.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearAfter_SelectedIndexChanged);
            // 
            // comboBoxYearBefore
            // 
            this.comboBoxYearBefore.Enabled = false;
            this.comboBoxYearBefore.FormattingEnabled = true;
            this.comboBoxYearBefore.Location = new System.Drawing.Point(123, 148);
            this.comboBoxYearBefore.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.comboBoxYearBefore.Name = "comboBoxYearBefore";
            this.comboBoxYearBefore.Size = new System.Drawing.Size(49, 21);
            this.comboBoxYearBefore.TabIndex = 19;
            // 
            // federal_districtTableAdapter
            // 
            this.federal_districtTableAdapter.ClearBeforeFill = true;
            // 
            // taxesTableAdapter
            // 
            this.taxesTableAdapter.ClearBeforeFill = true;
            // 
            // taxes_vedTableAdapter
            // 
            this.taxes_vedTableAdapter.ClearBeforeFill = true;
            // 
            // subjectsTableAdapter
            // 
            this.subjectsTableAdapter.ClearBeforeFill = true;
            // 
            // checkBoxBudget
            // 
            this.checkBoxBudget.AutoSize = true;
            this.checkBoxBudget.Location = new System.Drawing.Point(18, 121);
            this.checkBoxBudget.Name = "checkBoxBudget";
            this.checkBoxBudget.Size = new System.Drawing.Size(66, 17);
            this.checkBoxBudget.TabIndex = 27;
            this.checkBoxBudget.Text = "Бюджет";
            this.checkBoxBudget.UseVisualStyleBackColor = true;
            this.checkBoxBudget.CheckedChanged += new System.EventHandler(this.checkBoxBudget_CheckedChanged);
            // 
            // comboBoxBudgets
            // 
            this.comboBoxBudgets.DataSource = this.taxesbudgetsBindingSource;
            this.comboBoxBudgets.DisplayMember = "name";
            this.comboBoxBudgets.Enabled = false;
            this.comboBoxBudgets.FormattingEnabled = true;
            this.comboBoxBudgets.Location = new System.Drawing.Point(90, 121);
            this.comboBoxBudgets.Name = "comboBoxBudgets";
            this.comboBoxBudgets.Size = new System.Drawing.Size(227, 21);
            this.comboBoxBudgets.TabIndex = 28;
            this.comboBoxBudgets.ValueMember = "id";
            this.comboBoxBudgets.SelectedIndexChanged += new System.EventHandler(this.comboBoxBudgets_SelectedIndexChanged);
            // 
            // taxesbudgetsBindingSource
            // 
            this.taxesbudgetsBindingSource.DataMember = "Taxes_budgets";
            this.taxesbudgetsBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // taxes_budgetsTableAdapter
            // 
            this.taxes_budgetsTableAdapter.ClearBeforeFill = true;
            // 
            // UserControlAnalysisDataDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UserControlAnalysisDataDefault";
            this.Size = new System.Drawing.Size(368, 182);
            this.Load += new System.EventHandler(this.UserControlAnalysisDataDefault_Load);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.federaldistrictBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesvedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesbudgetsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.CheckBox checkBoxDistrict;
        public System.Windows.Forms.ComboBox comboBoxDistrict;
        public System.Windows.Forms.CheckBox checkBoxSubject;
        public System.Windows.Forms.CheckBox checkBoxTax;
        public System.Windows.Forms.ComboBox comboBoxTaxes;
        public System.Windows.Forms.CheckBox checkBoxTaxEea;
        public System.Windows.Forms.ComboBox comboBoxTaxesEea;
        public System.Windows.Forms.CheckBox checkBoxYears;
        public System.Windows.Forms.ComboBox comboBoxYearAfter;
        public System.Windows.Forms.ComboBox comboBoxYearBefore;
        public System.Windows.Forms.ComboBox comboBoxSubjetcs;
        public System.Windows.Forms.CheckBox checkBoxBudget;
        public System.Windows.Forms.ComboBox comboBoxBudgets;
        private NalogAdministrator.base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource federaldistrictBindingSource;
        private System.Windows.Forms.BindingSource taxesBindingSource;
        private System.Windows.Forms.BindingSource taxesvedBindingSource;
        private base_nalogDataSetTableAdapters.Federal_districtTableAdapter federal_districtTableAdapter;
        private base_nalogDataSetTableAdapters.TaxesTableAdapter taxesTableAdapter;
        private base_nalogDataSetTableAdapters.Taxes_vedTableAdapter taxes_vedTableAdapter;
        private System.Windows.Forms.BindingSource subjectsBindingSource;
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter;

        private System.Windows.Forms.BindingSource taxesbudgetsBindingSource;
        private base_nalogDataSetTableAdapters.Taxes_budgetsTableAdapter taxes_budgetsTableAdapter;
    }
}
