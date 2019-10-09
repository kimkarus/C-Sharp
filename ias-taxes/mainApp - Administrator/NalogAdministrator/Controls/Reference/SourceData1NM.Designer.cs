namespace NalogAdministrator.Controls.Reference
{
    partial class SourceData1NM
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.source_data_1NMDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.source_data_1NMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.comboBoxSelectYear = new System.Windows.Forms.ComboBox();
            this.comboBoxSelectSubject = new System.Windows.Forms.ComboBox();
            this.subjectsFK00BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.federaldistrictBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxSelectDistrcit = new System.Windows.Forms.ComboBox();
            this.federal_districtTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Federal_districtTableAdapter();
            this.subjectsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.SubjectsTableAdapter();
            this.tableAdapterManager = new NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager();
            this.source_data_1NMTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter();
            this.sourcedata1NMFK01BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.source_data_1NMDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.source_data_1NMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsFK00BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.federaldistrictBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcedata1NMFK01BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 652);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1104, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.source_data_1NMDataGridView);
            this.panel3.Controls.Add(this.comboBoxSelectYear);
            this.panel3.Controls.Add(this.comboBoxSelectSubject);
            this.panel3.Controls.Add(this.comboBoxSelectDistrcit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1104, 552);
            this.panel3.TabIndex = 2;
            // 
            // source_data_1NMDataGridView
            // 
            this.source_data_1NMDataGridView.AutoGenerateColumns = false;
            this.source_data_1NMDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.source_data_1NMDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewCheckBoxColumn1});
            this.source_data_1NMDataGridView.DataSource = this.sourcedata1NMFK01BindingSource;
            this.source_data_1NMDataGridView.Location = new System.Drawing.Point(3, 33);
            this.source_data_1NMDataGridView.Name = "source_data_1NMDataGridView";
            this.source_data_1NMDataGridView.Size = new System.Drawing.Size(1098, 513);
            this.source_data_1NMDataGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "id_subject";
            this.dataGridViewTextBoxColumn2.HeaderText = "id_subject";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "id_tax";
            this.dataGridViewTextBoxColumn3.HeaderText = "id_tax";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "1";
            this.dataGridViewTextBoxColumn4.HeaderText = "1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "2";
            this.dataGridViewTextBoxColumn5.HeaderText = "2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "3";
            this.dataGridViewTextBoxColumn6.HeaderText = "3";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "4";
            this.dataGridViewTextBoxColumn7.HeaderText = "4";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "5";
            this.dataGridViewTextBoxColumn8.HeaderText = "5";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "6";
            this.dataGridViewTextBoxColumn9.HeaderText = "6";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "7";
            this.dataGridViewTextBoxColumn10.HeaderText = "7";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TI";
            this.dataGridViewTextBoxColumn11.HeaderText = "TI";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "year_data";
            this.dataGridViewTextBoxColumn12.HeaderText = "year_data";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "comments";
            this.dataGridViewTextBoxColumn13.HeaderText = "comments";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "forcast";
            this.dataGridViewCheckBoxColumn1.HeaderText = "forcast";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // source_data_1NMBindingSource
            // 
            this.source_data_1NMBindingSource.DataMember = "Source_data_1NM";
            this.source_data_1NMBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxSelectYear
            // 
            this.comboBoxSelectYear.FormattingEnabled = true;
            this.comboBoxSelectYear.Items.AddRange(new object[] {
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011"});
            this.comboBoxSelectYear.Location = new System.Drawing.Point(550, 6);
            this.comboBoxSelectYear.Name = "comboBoxSelectYear";
            this.comboBoxSelectYear.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectYear.TabIndex = 2;
            // 
            // comboBoxSelectSubject
            // 
            this.comboBoxSelectSubject.DataSource = this.subjectsFK00BindingSource;
            this.comboBoxSelectSubject.DisplayMember = "subject_name";
            this.comboBoxSelectSubject.FormattingEnabled = true;
            this.comboBoxSelectSubject.Location = new System.Drawing.Point(286, 6);
            this.comboBoxSelectSubject.Name = "comboBoxSelectSubject";
            this.comboBoxSelectSubject.Size = new System.Drawing.Size(258, 21);
            this.comboBoxSelectSubject.TabIndex = 1;
            this.comboBoxSelectSubject.ValueMember = "id";
            this.comboBoxSelectSubject.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectSubject_SelectedIndexChanged);
            // 
            // subjectsFK00BindingSource
            // 
            this.subjectsFK00BindingSource.DataMember = "Subjects_FK00";
            this.subjectsFK00BindingSource.DataSource = this.federaldistrictBindingSource;
            // 
            // federaldistrictBindingSource
            // 
            this.federaldistrictBindingSource.DataMember = "Federal_district";
            this.federaldistrictBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // comboBoxSelectDistrcit
            // 
            this.comboBoxSelectDistrcit.DataSource = this.federaldistrictBindingSource;
            this.comboBoxSelectDistrcit.DisplayMember = "district_name";
            this.comboBoxSelectDistrcit.FormattingEnabled = true;
            this.comboBoxSelectDistrcit.Location = new System.Drawing.Point(3, 6);
            this.comboBoxSelectDistrcit.Name = "comboBoxSelectDistrcit";
            this.comboBoxSelectDistrcit.Size = new System.Drawing.Size(214, 21);
            this.comboBoxSelectDistrcit.TabIndex = 0;
            this.comboBoxSelectDistrcit.ValueMember = "id";
            // 
            // federal_districtTableAdapter
            // 
            this.federal_districtTableAdapter.ClearBeforeFill = true;
            // 
            // subjectsTableAdapter
            // 
            this.subjectsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CityTableAdapter = null;
            this.tableAdapterManager.Compare_tax_eeaTableAdapter = null;
            this.tableAdapterManager.Data_viewTableAdapter = null;
            this.tableAdapterManager.Federal_districtTableAdapter = this.federal_districtTableAdapter;
            this.tableAdapterManager.LogTableAdapter = null;
            this.tableAdapterManager.Report_typeTableAdapter = null;
            this.tableAdapterManager.Report_viewTableAdapter = null;
            this.tableAdapterManager.ReportsTableAdapter = null;
            this.tableAdapterManager.Source_data_1NMTableAdapter = null;
            this.tableAdapterManager.Source_data_1NOM_schemeTableAdapter = null;
            this.tableAdapterManager.Source_data_1NOMTableAdapter = null;
            this.tableAdapterManager.Source_data_PopulationTableAdapter = null;
            this.tableAdapterManager.Source_data_viewTableAdapter = null;
            this.tableAdapterManager.Subject_typeTableAdapter = null;
            this.tableAdapterManager.SubjectsTableAdapter = this.subjectsTableAdapter;
            this.tableAdapterManager.Tax_authorityTableAdapter = null;
            this.tableAdapterManager.Taxes_vedTableAdapter = null;
            this.tableAdapterManager.Taxes_viewTableAdapter = null;
            this.tableAdapterManager.TaxesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // source_data_1NMTableAdapter
            // 
            this.source_data_1NMTableAdapter.ClearBeforeFill = true;
            // 
            // sourcedata1NMFK01BindingSource
            // 
            this.sourcedata1NMFK01BindingSource.DataMember = "Source_data_1NM_FK01";
            this.sourcedata1NMFK01BindingSource.DataSource = this.subjectsFK00BindingSource;
            // 
            // SourceData1NM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SourceData1NM";
            this.Size = new System.Drawing.Size(1104, 752);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.source_data_1NMDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.source_data_1NMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsFK00BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.federaldistrictBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcedata1NMFK01BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxSelectSubject;
        private System.Windows.Forms.BindingSource subjectsFK00BindingSource;
        private System.Windows.Forms.BindingSource federaldistrictBindingSource;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.ComboBox comboBoxSelectDistrcit;
        private base_nalogDataSetTableAdapters.Federal_districtTableAdapter federal_districtTableAdapter;
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxSelectYear;
        private base_nalogDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView source_data_1NMDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.BindingSource source_data_1NMBindingSource;
        private base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter source_data_1NMTableAdapter;
        private System.Windows.Forms.BindingSource sourcedata1NMFK01BindingSource;
    }
}
