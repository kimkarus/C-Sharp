namespace NalogAdministrator.Controls.Reference
{
    partial class Subjects
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label subject_nameLabel;
            System.Windows.Forms.Label short_nameLabel;
            System.Windows.Forms.Label full_nameLabel;
            System.Windows.Forms.Label discriptionLabel;
            System.Windows.Forms.Label areaLabel;
            System.Windows.Forms.Label parentLabel;
            System.Windows.Forms.Label tax_authorityLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subjects));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bindingNavigatorSubjects = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.subjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.federaldistrictBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCityes = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityFK00BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parentTextBox = new System.Windows.Forms.TextBox();
            this.tax_authorityTextBox = new System.Windows.Forms.TextBox();
            this.id_districtTextBox = new System.Windows.Forms.TextBox();
            this.discriptionTextBox = new System.Windows.Forms.TextBox();
            this.full_nameTextBox = new System.Windows.Forms.TextBox();
            this.short_nameTextBox = new System.Windows.Forms.TextBox();
            this.subject_nameTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.cityTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.CityTableAdapter();
            this.federal_districtTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Federal_districtTableAdapter();
            this.subjectsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.SubjectsTableAdapter();
            this.tableAdapterManager = new NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager();
            idLabel = new System.Windows.Forms.Label();
            subject_nameLabel = new System.Windows.Forms.Label();
            short_nameLabel = new System.Windows.Forms.Label();
            full_nameLabel = new System.Windows.Forms.Label();
            discriptionLabel = new System.Windows.Forms.Label();
            areaLabel = new System.Windows.Forms.Label();
            parentLabel = new System.Windows.Forms.Label();
            tax_authorityLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorSubjects)).BeginInit();
            this.bindingNavigatorSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.federaldistrictBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCityes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityFK00BindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Enabled = false;
            idLabel.Location = new System.Drawing.Point(218, 22);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(29, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Код:";
            // 
            // subject_nameLabel
            // 
            subject_nameLabel.AutoSize = true;
            subject_nameLabel.Location = new System.Drawing.Point(16, 55);
            subject_nameLabel.Name = "subject_nameLabel";
            subject_nameLabel.Size = new System.Drawing.Size(110, 13);
            subject_nameLabel.TabIndex = 2;
            subject_nameLabel.Text = "Название субъекта:";
            // 
            // short_nameLabel
            // 
            short_nameLabel.AutoSize = true;
            short_nameLabel.Location = new System.Drawing.Point(16, 81);
            short_nameLabel.Name = "short_nameLabel";
            short_nameLabel.Size = new System.Drawing.Size(109, 13);
            short_nameLabel.TabIndex = 4;
            short_nameLabel.Text = "Короткое название:";
            // 
            // full_nameLabel
            // 
            full_nameLabel.AutoSize = true;
            full_nameLabel.Location = new System.Drawing.Point(16, 107);
            full_nameLabel.Name = "full_nameLabel";
            full_nameLabel.Size = new System.Drawing.Size(99, 13);
            full_nameLabel.TabIndex = 6;
            full_nameLabel.Text = "Полное название:";
            // 
            // discriptionLabel
            // 
            discriptionLabel.AutoSize = true;
            discriptionLabel.Location = new System.Drawing.Point(16, 211);
            discriptionLabel.Name = "discriptionLabel";
            discriptionLabel.Size = new System.Drawing.Size(60, 13);
            discriptionLabel.TabIndex = 8;
            discriptionLabel.Text = "Описание:";
            // 
            // areaLabel
            // 
            areaLabel.AutoSize = true;
            areaLabel.Location = new System.Drawing.Point(16, 133);
            areaLabel.Name = "areaLabel";
            areaLabel.Size = new System.Drawing.Size(57, 13);
            areaLabel.TabIndex = 10;
            areaLabel.Text = "Площадь:";
            // 
            // parentLabel
            // 
            parentLabel.AutoSize = true;
            parentLabel.Location = new System.Drawing.Point(16, 159);
            parentLabel.Name = "parentLabel";
            parentLabel.Size = new System.Drawing.Size(169, 13);
            parentLabel.TabIndex = 12;
            parentLabel.Text = "Входит в состав (код субъекта):";
            // 
            // tax_authorityLabel
            // 
            tax_authorityLabel.AutoSize = true;
            tax_authorityLabel.Location = new System.Drawing.Point(16, 185);
            tax_authorityLabel.Name = "tax_authorityLabel";
            tax_authorityLabel.Size = new System.Drawing.Size(126, 13);
            tax_authorityLabel.TabIndex = 14;
            tax_authorityLabel.Text = "Налоговый орган (код):";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bindingNavigatorSubjects);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 443);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 100);
            this.panel2.TabIndex = 1;
            // 
            // bindingNavigatorSubjects
            // 
            this.bindingNavigatorSubjects.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorSubjects.BindingSource = this.subjectsBindingSource;
            this.bindingNavigatorSubjects.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorSubjects.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorSubjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigatorSubjects.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorSubjects.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorSubjects.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorSubjects.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorSubjects.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorSubjects.Name = "bindingNavigatorSubjects";
            this.bindingNavigatorSubjects.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorSubjects.Size = new System.Drawing.Size(602, 25);
            this.bindingNavigatorSubjects.TabIndex = 0;
            this.bindingNavigatorSubjects.Text = "bindingNavigatorSubjects";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // subjectsBindingSource
            // 
            this.subjectsBindingSource.DataMember = "Subjects_FK00";
            this.subjectsBindingSource.DataSource = this.federaldistrictBindingSource;
            // 
            // federaldistrictBindingSource
            // 
            this.federaldistrictBindingSource.DataMember = "Federal_district";
            this.federaldistrictBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 343);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewCityes);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(366, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 343);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Города";
            // 
            // dataGridViewCityes
            // 
            this.dataGridViewCityes.AutoGenerateColumns = false;
            this.dataGridViewCityes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCityes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewCityes.DataSource = this.cityFK00BindingSource;
            this.dataGridViewCityes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCityes.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewCityes.Name = "dataGridViewCityes";
            this.dataGridViewCityes.Size = new System.Drawing.Size(230, 324);
            this.dataGridViewCityes.TabIndex = 1;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // cityFK00BindingSource
            // 
            this.cityFK00BindingSource.DataMember = "City_FK00";
            this.cityFK00BindingSource.DataSource = this.subjectsBindingSource;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parentTextBox);
            this.groupBox1.Controls.Add(this.tax_authorityTextBox);
            this.groupBox1.Controls.Add(this.id_districtTextBox);
            this.groupBox1.Controls.Add(this.discriptionTextBox);
            this.groupBox1.Controls.Add(this.full_nameTextBox);
            this.groupBox1.Controls.Add(this.short_nameTextBox);
            this.groupBox1.Controls.Add(this.subject_nameTextBox);
            this.groupBox1.Controls.Add(this.idTextBox);
            this.groupBox1.Controls.Add(this.comboBoxSubject);
            this.groupBox1.Controls.Add(tax_authorityLabel);
            this.groupBox1.Controls.Add(parentLabel);
            this.groupBox1.Controls.Add(areaLabel);
            this.groupBox1.Controls.Add(discriptionLabel);
            this.groupBox1.Controls.Add(full_nameLabel);
            this.groupBox1.Controls.Add(short_nameLabel);
            this.groupBox1.Controls.Add(subject_nameLabel);
            this.groupBox1.Controls.Add(idLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Субъект";
            // 
            // parentTextBox
            // 
            this.parentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subjectsBindingSource, "parent", true));
            this.parentTextBox.Location = new System.Drawing.Point(191, 156);
            this.parentTextBox.Name = "parentTextBox";
            this.parentTextBox.Size = new System.Drawing.Size(162, 20);
            this.parentTextBox.TabIndex = 24;
            // 
            // tax_authorityTextBox
            // 
            this.tax_authorityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subjectsBindingSource, "tax_authority", true));
            this.tax_authorityTextBox.Location = new System.Drawing.Point(147, 182);
            this.tax_authorityTextBox.Name = "tax_authorityTextBox";
            this.tax_authorityTextBox.Size = new System.Drawing.Size(206, 20);
            this.tax_authorityTextBox.TabIndex = 23;
            // 
            // id_districtTextBox
            // 
            this.id_districtTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subjectsBindingSource, "id_district", true));
            this.id_districtTextBox.Location = new System.Drawing.Point(79, 130);
            this.id_districtTextBox.Name = "id_districtTextBox";
            this.id_districtTextBox.Size = new System.Drawing.Size(274, 20);
            this.id_districtTextBox.TabIndex = 22;
            // 
            // discriptionTextBox
            // 
            this.discriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subjectsBindingSource, "discription", true));
            this.discriptionTextBox.Location = new System.Drawing.Point(82, 208);
            this.discriptionTextBox.Multiline = true;
            this.discriptionTextBox.Name = "discriptionTextBox";
            this.discriptionTextBox.Size = new System.Drawing.Size(271, 118);
            this.discriptionTextBox.TabIndex = 21;
            // 
            // full_nameTextBox
            // 
            this.full_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subjectsBindingSource, "full_name", true));
            this.full_nameTextBox.Location = new System.Drawing.Point(132, 104);
            this.full_nameTextBox.Name = "full_nameTextBox";
            this.full_nameTextBox.Size = new System.Drawing.Size(221, 20);
            this.full_nameTextBox.TabIndex = 20;
            // 
            // short_nameTextBox
            // 
            this.short_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subjectsBindingSource, "short_name", true));
            this.short_nameTextBox.Location = new System.Drawing.Point(132, 78);
            this.short_nameTextBox.Name = "short_nameTextBox";
            this.short_nameTextBox.Size = new System.Drawing.Size(221, 20);
            this.short_nameTextBox.TabIndex = 19;
            // 
            // subject_nameTextBox
            // 
            this.subject_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subjectsBindingSource, "subject_name", true));
            this.subject_nameTextBox.Location = new System.Drawing.Point(132, 52);
            this.subject_nameTextBox.Name = "subject_nameTextBox";
            this.subject_nameTextBox.Size = new System.Drawing.Size(221, 20);
            this.subject_nameTextBox.TabIndex = 18;
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.subjectsBindingSource, "id", true));
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(253, 19);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 17;
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.DataSource = this.federaldistrictBindingSource;
            this.comboBoxSubject.DisplayMember = "district_name";
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(19, 19);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(193, 21);
            this.comboBoxSubject.TabIndex = 16;
            this.comboBoxSubject.ValueMember = "id";
            // 
            // cityTableAdapter
            // 
            this.cityTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.CityTableAdapter = this.cityTableAdapter;
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
            // Subjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Subjects";
            this.Size = new System.Drawing.Size(602, 543);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorSubjects)).EndInit();
            this.bindingNavigatorSubjects.ResumeLayout(false);
            this.bindingNavigatorSubjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.federaldistrictBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCityes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityFK00BindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewCityes;
        private base_nalogDataSetTableAdapters.CityTableAdapter cityTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.BindingSource federaldistrictBindingSource;
        private base_nalogDataSetTableAdapters.Federal_districtTableAdapter federal_districtTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource cityFK00BindingSource;
        private System.Windows.Forms.BindingSource subjectsBindingSource;
        private System.Windows.Forms.TextBox parentTextBox;
        private System.Windows.Forms.TextBox tax_authorityTextBox;
        private System.Windows.Forms.TextBox id_districtTextBox;
        private System.Windows.Forms.TextBox discriptionTextBox;
        private System.Windows.Forms.TextBox full_nameTextBox;
        private System.Windows.Forms.TextBox short_nameTextBox;
        private System.Windows.Forms.TextBox subject_nameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter;
        private base_nalogDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator bindingNavigatorSubjects;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    }
}
