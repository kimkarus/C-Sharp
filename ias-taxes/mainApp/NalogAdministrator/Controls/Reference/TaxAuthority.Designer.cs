namespace NalogAdministrator.Controls.Reference
{
    partial class TaxAuthority
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxAuthority));
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label discriptionLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.tax_authorityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tax_authorityTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Tax_authorityTableAdapter();
            this.tableAdapterManager = new NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager();
            this.tax_authorityBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tax_authorityBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.discriptionTextBox = new System.Windows.Forms.TextBox();
            this.subjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.SubjectsTableAdapter();
            this.subjectsDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxTaxAuthority = new System.Windows.Forms.GroupBox();
            this.groupBoxSubjects = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            idLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            discriptionLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tax_authorityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tax_authorityBindingNavigator)).BeginInit();
            this.tax_authorityBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsDataGridView)).BeginInit();
            this.groupBoxTaxAuthority.SuspendLayout();
            this.groupBoxSubjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tax_authorityBindingNavigator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBoxSubjects);
            this.panel3.Controls.Add(this.groupBoxTaxAuthority);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(918, 213);
            this.panel3.TabIndex = 2;
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tax_authorityBindingSource
            // 
            this.tax_authorityBindingSource.DataMember = "Tax_authority";
            this.tax_authorityBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // tax_authorityTableAdapter
            // 
            this.tax_authorityTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CityTableAdapter = null;
            this.tableAdapterManager.Compare_tax_eeaTableAdapter = null;
            this.tableAdapterManager.Data_viewTableAdapter = null;
            this.tableAdapterManager.Federal_districtTableAdapter = null;
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
            this.tableAdapterManager.Tax_authorityTableAdapter = this.tax_authorityTableAdapter;
            this.tableAdapterManager.Taxes_vedTableAdapter = null;
            this.tableAdapterManager.Taxes_viewTableAdapter = null;
            this.tableAdapterManager.TaxesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tax_authorityBindingNavigator
            // 
            this.tax_authorityBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tax_authorityBindingNavigator.BindingSource = this.tax_authorityBindingSource;
            this.tax_authorityBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tax_authorityBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tax_authorityBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tax_authorityBindingNavigatorSaveItem});
            this.tax_authorityBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tax_authorityBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tax_authorityBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tax_authorityBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tax_authorityBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tax_authorityBindingNavigator.Name = "tax_authorityBindingNavigator";
            this.tax_authorityBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tax_authorityBindingNavigator.Size = new System.Drawing.Size(918, 25);
            this.tax_authorityBindingNavigator.TabIndex = 3;
            this.tax_authorityBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // tax_authorityBindingNavigatorSaveItem
            // 
            this.tax_authorityBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tax_authorityBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tax_authorityBindingNavigatorSaveItem.Image")));
            this.tax_authorityBindingNavigatorSaveItem.Name = "tax_authorityBindingNavigatorSaveItem";
            this.tax_authorityBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tax_authorityBindingNavigatorSaveItem.Text = "Save Data";
            this.tax_authorityBindingNavigatorSaveItem.Click += new System.EventHandler(this.tax_authorityBindingNavigatorSaveItem_Click);
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(360, 34);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(29, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Код:";
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tax_authorityBindingSource, "id", true));
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(395, 31);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(11, 34);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(60, 13);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Название:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tax_authorityBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(74, 31);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(280, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // discriptionLabel
            // 
            discriptionLabel.AutoSize = true;
            discriptionLabel.Location = new System.Drawing.Point(11, 60);
            discriptionLabel.Name = "discriptionLabel";
            discriptionLabel.Size = new System.Drawing.Size(60, 13);
            discriptionLabel.TabIndex = 4;
            discriptionLabel.Text = "Описание:";
            // 
            // discriptionTextBox
            // 
            this.discriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tax_authorityBindingSource, "discription", true));
            this.discriptionTextBox.Location = new System.Drawing.Point(74, 57);
            this.discriptionTextBox.Multiline = true;
            this.discriptionTextBox.Name = "discriptionTextBox";
            this.discriptionTextBox.Size = new System.Drawing.Size(280, 117);
            this.discriptionTextBox.TabIndex = 5;
            // 
            // subjectsBindingSource
            // 
            this.subjectsBindingSource.DataMember = "FK_Subjects_Tax_authority";
            this.subjectsBindingSource.DataSource = this.tax_authorityBindingSource;
            // 
            // subjectsTableAdapter
            // 
            this.subjectsTableAdapter.ClearBeforeFill = true;
            // 
            // subjectsDataGridView
            // 
            this.subjectsDataGridView.AutoGenerateColumns = false;
            this.subjectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn9});
            this.subjectsDataGridView.DataSource = this.subjectsBindingSource;
            this.subjectsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.subjectsDataGridView.Name = "subjectsDataGridView";
            this.subjectsDataGridView.Size = new System.Drawing.Size(398, 194);
            this.subjectsDataGridView.TabIndex = 6;
            // 
            // groupBoxTaxAuthority
            // 
            this.groupBoxTaxAuthority.Controls.Add(this.idTextBox);
            this.groupBoxTaxAuthority.Controls.Add(discriptionLabel);
            this.groupBoxTaxAuthority.Controls.Add(idLabel);
            this.groupBoxTaxAuthority.Controls.Add(this.discriptionTextBox);
            this.groupBoxTaxAuthority.Controls.Add(this.nameTextBox);
            this.groupBoxTaxAuthority.Controls.Add(nameLabel);
            this.groupBoxTaxAuthority.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxTaxAuthority.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTaxAuthority.Name = "groupBoxTaxAuthority";
            this.groupBoxTaxAuthority.Size = new System.Drawing.Size(514, 213);
            this.groupBoxTaxAuthority.TabIndex = 6;
            this.groupBoxTaxAuthority.TabStop = false;
            this.groupBoxTaxAuthority.Text = "Налоговый орган";
            // 
            // groupBoxSubjects
            // 
            this.groupBoxSubjects.Controls.Add(this.subjectsDataGridView);
            this.groupBoxSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSubjects.Location = new System.Drawing.Point(514, 0);
            this.groupBoxSubjects.Name = "groupBoxSubjects";
            this.groupBoxSubjects.Size = new System.Drawing.Size(404, 213);
            this.groupBoxSubjects.TabIndex = 7;
            this.groupBoxSubjects.TabStop = false;
            this.groupBoxSubjects.Text = "Субъекты";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "subject_name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 175;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "tax_authority";
            this.dataGridViewTextBoxColumn9.HeaderText = "Налоговый орган";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // TaxAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TaxAuthority";
            this.Size = new System.Drawing.Size(918, 413);
            this.Tag = "TaxAuthority";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tax_authorityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tax_authorityBindingNavigator)).EndInit();
            this.tax_authorityBindingNavigator.ResumeLayout(false);
            this.tax_authorityBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsDataGridView)).EndInit();
            this.groupBoxTaxAuthority.ResumeLayout(false);
            this.groupBoxTaxAuthority.PerformLayout();
            this.groupBoxSubjects.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource tax_authorityBindingSource;
        private base_nalogDataSetTableAdapters.Tax_authorityTableAdapter tax_authorityTableAdapter;
        private base_nalogDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tax_authorityBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton tax_authorityBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView subjectsDataGridView;
        private System.Windows.Forms.BindingSource subjectsBindingSource;
        private System.Windows.Forms.TextBox discriptionTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter;
        private System.Windows.Forms.GroupBox groupBoxSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.GroupBox groupBoxTaxAuthority;
    }
}
