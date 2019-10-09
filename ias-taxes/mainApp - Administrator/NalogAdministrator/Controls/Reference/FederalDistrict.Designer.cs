namespace NalogAdministrator.Controls.Reference
{
    partial class FederalDistrict
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
            System.Windows.Forms.Label district_nameLabel;
            System.Windows.Forms.Label full_nameLabel;
            System.Windows.Forms.Label discriptionLabel;
            System.Windows.Forms.Label latin_nameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FederalDistrict));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.federal_districtBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.federal_districtBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.federal_districtBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBoxSubjects = new System.Windows.Forms.GroupBox();
            this.dataGridViewSubjects = new System.Windows.Forms.DataGridView();
            this.subjectnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectsFK00BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxFederalDistrict = new System.Windows.Forms.GroupBox();
            this.discriptionTextBox = new System.Windows.Forms.TextBox();
            this.district_nameTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.latin_nameTextBox = new System.Windows.Forms.TextBox();
            this.full_nameTextBox = new System.Windows.Forms.TextBox();
            this.federal_districtTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Federal_districtTableAdapter();
            this.tableAdapterManager = new NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager();
            this.subjectsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.SubjectsTableAdapter();
            idLabel = new System.Windows.Forms.Label();
            district_nameLabel = new System.Windows.Forms.Label();
            full_nameLabel = new System.Windows.Forms.Label();
            discriptionLabel = new System.Windows.Forms.Label();
            latin_nameLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.federal_districtBindingNavigator)).BeginInit();
            this.federal_districtBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.federal_districtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBoxSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsFK00BindingSource)).BeginInit();
            this.groupBoxFederalDistrict.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(175, 34);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(29, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Код:";
            // 
            // district_nameLabel
            // 
            district_nameLabel.AutoSize = true;
            district_nameLabel.Location = new System.Drawing.Point(9, 78);
            district_nameLabel.Name = "district_nameLabel";
            district_nameLabel.Size = new System.Drawing.Size(60, 13);
            district_nameLabel.TabIndex = 2;
            district_nameLabel.Text = "Название:";
            // 
            // full_nameLabel
            // 
            full_nameLabel.AutoSize = true;
            full_nameLabel.Location = new System.Drawing.Point(24, 104);
            full_nameLabel.Name = "full_nameLabel";
            full_nameLabel.Size = new System.Drawing.Size(48, 13);
            full_nameLabel.TabIndex = 4;
            full_nameLabel.Text = "Полное:";
            // 
            // discriptionLabel
            // 
            discriptionLabel.AutoSize = true;
            discriptionLabel.Location = new System.Drawing.Point(10, 130);
            discriptionLabel.Name = "discriptionLabel";
            discriptionLabel.Size = new System.Drawing.Size(60, 13);
            discriptionLabel.TabIndex = 6;
            discriptionLabel.Text = "Описание:";
            // 
            // latin_nameLabel
            // 
            latin_nameLabel.AutoSize = true;
            latin_nameLabel.Location = new System.Drawing.Point(11, 236);
            latin_nameLabel.Name = "latin_nameLabel";
            latin_nameLabel.Size = new System.Drawing.Size(59, 13);
            latin_nameLabel.TabIndex = 8;
            latin_nameLabel.Text = "Латиница:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.federal_districtBindingNavigator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 100);
            this.panel2.TabIndex = 1;
            // 
            // federal_districtBindingNavigator
            // 
            this.federal_districtBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.federal_districtBindingNavigator.BindingSource = this.federal_districtBindingSource;
            this.federal_districtBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.federal_districtBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.federal_districtBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.federal_districtBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorDeleteItem,
            this.federal_districtBindingNavigatorSaveItem});
            this.federal_districtBindingNavigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.federal_districtBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.federal_districtBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.federal_districtBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.federal_districtBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.federal_districtBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.federal_districtBindingNavigator.Name = "federal_districtBindingNavigator";
            this.federal_districtBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.federal_districtBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.federal_districtBindingNavigator.Size = new System.Drawing.Size(630, 25);
            this.federal_districtBindingNavigator.TabIndex = 2;
            this.federal_districtBindingNavigator.Tag = "Федеральные округа";
            this.federal_districtBindingNavigator.Text = "bindingNavigator1";
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
            // federal_districtBindingSource
            // 
            this.federal_districtBindingSource.DataMember = "Federal_district";
            this.federal_districtBindingSource.DataSource = this.base_nalogDataSet;
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
            // federal_districtBindingNavigatorSaveItem
            // 
            this.federal_districtBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.federal_districtBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("federal_districtBindingNavigatorSaveItem.Image")));
            this.federal_districtBindingNavigatorSaveItem.Name = "federal_districtBindingNavigatorSaveItem";
            this.federal_districtBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.federal_districtBindingNavigatorSaveItem.Text = "Save Data";
            this.federal_districtBindingNavigatorSaveItem.Click += new System.EventHandler(this.federal_districtBindingNavigatorSaveItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBoxSubjects);
            this.panel3.Controls.Add(this.groupBoxFederalDistrict);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(630, 267);
            this.panel3.TabIndex = 1;
            // 
            // groupBoxSubjects
            // 
            this.groupBoxSubjects.Controls.Add(this.dataGridViewSubjects);
            this.groupBoxSubjects.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxSubjects.Location = new System.Drawing.Point(322, 0);
            this.groupBoxSubjects.Name = "groupBoxSubjects";
            this.groupBoxSubjects.Size = new System.Drawing.Size(308, 267);
            this.groupBoxSubjects.TabIndex = 11;
            this.groupBoxSubjects.TabStop = false;
            this.groupBoxSubjects.Text = "Субъекты";
            // 
            // dataGridViewSubjects
            // 
            this.dataGridViewSubjects.AutoGenerateColumns = false;
            this.dataGridViewSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subjectnameDataGridViewTextBoxColumn});
            this.dataGridViewSubjects.DataSource = this.subjectsFK00BindingSource;
            this.dataGridViewSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSubjects.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewSubjects.Name = "dataGridViewSubjects";
            this.dataGridViewSubjects.RowHeadersWidth = 25;
            this.dataGridViewSubjects.Size = new System.Drawing.Size(302, 248);
            this.dataGridViewSubjects.TabIndex = 0;
            // 
            // subjectnameDataGridViewTextBoxColumn
            // 
            this.subjectnameDataGridViewTextBoxColumn.DataPropertyName = "subject_name";
            this.subjectnameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.subjectnameDataGridViewTextBoxColumn.Name = "subjectnameDataGridViewTextBoxColumn";
            this.subjectnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // subjectsFK00BindingSource
            // 
            this.subjectsFK00BindingSource.DataMember = "Subjects_FK00";
            this.subjectsFK00BindingSource.DataSource = this.federal_districtBindingSource;
            // 
            // groupBoxFederalDistrict
            // 
            this.groupBoxFederalDistrict.Controls.Add(this.discriptionTextBox);
            this.groupBoxFederalDistrict.Controls.Add(this.district_nameTextBox);
            this.groupBoxFederalDistrict.Controls.Add(idLabel);
            this.groupBoxFederalDistrict.Controls.Add(latin_nameLabel);
            this.groupBoxFederalDistrict.Controls.Add(this.idTextBox);
            this.groupBoxFederalDistrict.Controls.Add(district_nameLabel);
            this.groupBoxFederalDistrict.Controls.Add(this.latin_nameTextBox);
            this.groupBoxFederalDistrict.Controls.Add(this.full_nameTextBox);
            this.groupBoxFederalDistrict.Controls.Add(discriptionLabel);
            this.groupBoxFederalDistrict.Controls.Add(full_nameLabel);
            this.groupBoxFederalDistrict.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxFederalDistrict.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFederalDistrict.Name = "groupBoxFederalDistrict";
            this.groupBoxFederalDistrict.Size = new System.Drawing.Size(316, 267);
            this.groupBoxFederalDistrict.TabIndex = 10;
            this.groupBoxFederalDistrict.TabStop = false;
            this.groupBoxFederalDistrict.Text = "Федеральный округ";
            // 
            // discriptionTextBox
            // 
            this.discriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.federal_districtBindingSource, "discription", true));
            this.discriptionTextBox.Location = new System.Drawing.Point(75, 127);
            this.discriptionTextBox.Multiline = true;
            this.discriptionTextBox.Name = "discriptionTextBox";
            this.discriptionTextBox.Size = new System.Drawing.Size(235, 100);
            this.discriptionTextBox.TabIndex = 7;
            // 
            // district_nameTextBox
            // 
            this.district_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.federal_districtBindingSource, "district_name", true));
            this.district_nameTextBox.Location = new System.Drawing.Point(75, 75);
            this.district_nameTextBox.Name = "district_nameTextBox";
            this.district_nameTextBox.Size = new System.Drawing.Size(235, 20);
            this.district_nameTextBox.TabIndex = 3;
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.federal_districtBindingSource, "id", true));
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(199, 31);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 1;
            // 
            // latin_nameTextBox
            // 
            this.latin_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.federal_districtBindingSource, "latin_name", true));
            this.latin_nameTextBox.Location = new System.Drawing.Point(75, 233);
            this.latin_nameTextBox.Name = "latin_nameTextBox";
            this.latin_nameTextBox.Size = new System.Drawing.Size(235, 20);
            this.latin_nameTextBox.TabIndex = 9;
            // 
            // full_nameTextBox
            // 
            this.full_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.federal_districtBindingSource, "full_name", true));
            this.full_nameTextBox.Location = new System.Drawing.Point(75, 101);
            this.full_nameTextBox.Name = "full_nameTextBox";
            this.full_nameTextBox.Size = new System.Drawing.Size(235, 20);
            this.full_nameTextBox.TabIndex = 5;
            // 
            // federal_districtTableAdapter
            // 
            this.federal_districtTableAdapter.ClearBeforeFill = true;
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
            // subjectsTableAdapter
            // 
            this.subjectsTableAdapter.ClearBeforeFill = true;
            // 
            // FederalDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FederalDistrict";
            this.Size = new System.Drawing.Size(630, 467);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.federal_districtBindingNavigator)).EndInit();
            this.federal_districtBindingNavigator.ResumeLayout(false);
            this.federal_districtBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.federal_districtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBoxSubjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsFK00BindingSource)).EndInit();
            this.groupBoxFederalDistrict.ResumeLayout(false);
            this.groupBoxFederalDistrict.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource federal_districtBindingSource;
        private base_nalogDataSetTableAdapters.Federal_districtTableAdapter federal_districtTableAdapter;
        private base_nalogDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator federal_districtBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton federal_districtBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox latin_nameTextBox;
        private System.Windows.Forms.TextBox discriptionTextBox;
        private System.Windows.Forms.TextBox full_nameTextBox;
        private System.Windows.Forms.TextBox district_nameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.GroupBox groupBoxSubjects;
        private System.Windows.Forms.GroupBox groupBoxFederalDistrict;
        private System.Windows.Forms.DataGridView dataGridViewSubjects;
        private System.Windows.Forms.BindingSource subjectsFK00BindingSource;
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectnameDataGridViewTextBoxColumn;
    }
}
