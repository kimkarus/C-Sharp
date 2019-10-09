namespace NalogAdministrator.Controls.Reference
{
    partial class TaxesView
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
            System.Windows.Forms.Label кодLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label full_nameLabel;
            System.Windows.Forms.Label discriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxesView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.taxes_viewBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.taxes_viewBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.taxes_viewBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBoxTaxes = new System.Windows.Forms.GroupBox();
            this.dataGridViewTaxes = new System.Windows.Forms.DataGridView();
            this.taxesFK00BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxTaxesView = new System.Windows.Forms.GroupBox();
            this.кодTextBox = new System.Windows.Forms.TextBox();
            this.discriptionTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.full_nameTextBox = new System.Windows.Forms.TextBox();
            this.taxes_viewTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Taxes_viewTableAdapter();
            this.tableAdapterManager = new NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager();
            this.taxesTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.TaxesTableAdapter();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            кодLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            full_nameLabel = new System.Windows.Forms.Label();
            discriptionLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxes_viewBindingNavigator)).BeginInit();
            this.taxes_viewBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxes_viewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBoxTaxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesFK00BindingSource)).BeginInit();
            this.groupBoxTaxesView.SuspendLayout();
            this.SuspendLayout();
            // 
            // кодLabel
            // 
            кодLabel.AutoSize = true;
            кодLabel.Location = new System.Drawing.Point(227, 22);
            кодLabel.Name = "кодLabel";
            кодLabel.Size = new System.Drawing.Size(29, 13);
            кодLabel.TabIndex = 0;
            кодLabel.Text = "Код:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(6, 66);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(60, 13);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Название:";
            // 
            // full_nameLabel
            // 
            full_nameLabel.AutoSize = true;
            full_nameLabel.Location = new System.Drawing.Point(6, 92);
            full_nameLabel.Name = "full_nameLabel";
            full_nameLabel.Size = new System.Drawing.Size(99, 13);
            full_nameLabel.TabIndex = 4;
            full_nameLabel.Text = "Полное название:";
            // 
            // discriptionLabel
            // 
            discriptionLabel.AutoSize = true;
            discriptionLabel.Location = new System.Drawing.Point(6, 118);
            discriptionLabel.Name = "discriptionLabel";
            discriptionLabel.Size = new System.Drawing.Size(60, 13);
            discriptionLabel.TabIndex = 6;
            discriptionLabel.Text = "Описание:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.taxes_viewBindingNavigator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(679, 100);
            this.panel2.TabIndex = 1;
            // 
            // taxes_viewBindingNavigator
            // 
            this.taxes_viewBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.taxes_viewBindingNavigator.BindingSource = this.taxes_viewBindingSource;
            this.taxes_viewBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.taxes_viewBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.taxes_viewBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.taxes_viewBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.taxes_viewBindingNavigatorSaveItem});
            this.taxes_viewBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.taxes_viewBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.taxes_viewBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.taxes_viewBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.taxes_viewBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.taxes_viewBindingNavigator.Name = "taxes_viewBindingNavigator";
            this.taxes_viewBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.taxes_viewBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.taxes_viewBindingNavigator.Size = new System.Drawing.Size(679, 25);
            this.taxes_viewBindingNavigator.TabIndex = 3;
            this.taxes_viewBindingNavigator.Tag = "Виды налогов";
            this.taxes_viewBindingNavigator.Text = "bindingNavigator1";
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
            // taxes_viewBindingSource
            // 
            this.taxes_viewBindingSource.DataMember = "Taxes_view";
            this.taxes_viewBindingSource.DataSource = this.base_nalogDataSet;
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
            // taxes_viewBindingNavigatorSaveItem
            // 
            this.taxes_viewBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.taxes_viewBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("taxes_viewBindingNavigatorSaveItem.Image")));
            this.taxes_viewBindingNavigatorSaveItem.Name = "taxes_viewBindingNavigatorSaveItem";
            this.taxes_viewBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.taxes_viewBindingNavigatorSaveItem.Text = "Save Data";
            this.taxes_viewBindingNavigatorSaveItem.Click += new System.EventHandler(this.taxes_viewBindingNavigatorSaveItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBoxTaxes);
            this.panel3.Controls.Add(this.groupBoxTaxesView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(679, 236);
            this.panel3.TabIndex = 2;
            // 
            // groupBoxTaxes
            // 
            this.groupBoxTaxes.Controls.Add(this.dataGridViewTaxes);
            this.groupBoxTaxes.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxTaxes.Location = new System.Drawing.Point(371, 0);
            this.groupBoxTaxes.Name = "groupBoxTaxes";
            this.groupBoxTaxes.Size = new System.Drawing.Size(308, 236);
            this.groupBoxTaxes.TabIndex = 9;
            this.groupBoxTaxes.TabStop = false;
            this.groupBoxTaxes.Text = "Налоги";
            // 
            // dataGridViewTaxes
            // 
            this.dataGridViewTaxes.AutoGenerateColumns = false;
            this.dataGridViewTaxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.taxnameDataGridViewTextBoxColumn});
            this.dataGridViewTaxes.DataSource = this.taxesFK00BindingSource;
            this.dataGridViewTaxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTaxes.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewTaxes.Name = "dataGridViewTaxes";
            this.dataGridViewTaxes.RowHeadersWidth = 25;
            this.dataGridViewTaxes.Size = new System.Drawing.Size(302, 217);
            this.dataGridViewTaxes.TabIndex = 0;
            // 
            // taxesFK00BindingSource
            // 
            this.taxesFK00BindingSource.DataMember = "Taxes_FK00";
            this.taxesFK00BindingSource.DataSource = this.taxes_viewBindingSource;
            // 
            // groupBoxTaxesView
            // 
            this.groupBoxTaxesView.Controls.Add(this.кодTextBox);
            this.groupBoxTaxesView.Controls.Add(discriptionLabel);
            this.groupBoxTaxesView.Controls.Add(кодLabel);
            this.groupBoxTaxesView.Controls.Add(this.discriptionTextBox);
            this.groupBoxTaxesView.Controls.Add(this.nameTextBox);
            this.groupBoxTaxesView.Controls.Add(full_nameLabel);
            this.groupBoxTaxesView.Controls.Add(nameLabel);
            this.groupBoxTaxesView.Controls.Add(this.full_nameTextBox);
            this.groupBoxTaxesView.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxTaxesView.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTaxesView.Name = "groupBoxTaxesView";
            this.groupBoxTaxesView.Size = new System.Drawing.Size(368, 236);
            this.groupBoxTaxesView.TabIndex = 8;
            this.groupBoxTaxesView.TabStop = false;
            this.groupBoxTaxesView.Text = "Виды налогов";
            // 
            // кодTextBox
            // 
            this.кодTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxes_viewBindingSource, "id", true));
            this.кодTextBox.Enabled = false;
            this.кодTextBox.Location = new System.Drawing.Point(262, 19);
            this.кодTextBox.Name = "кодTextBox";
            this.кодTextBox.Size = new System.Drawing.Size(100, 20);
            this.кодTextBox.TabIndex = 1;
            // 
            // discriptionTextBox
            // 
            this.discriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxes_viewBindingSource, "discription", true));
            this.discriptionTextBox.Location = new System.Drawing.Point(72, 115);
            this.discriptionTextBox.Multiline = true;
            this.discriptionTextBox.Name = "discriptionTextBox";
            this.discriptionTextBox.Size = new System.Drawing.Size(290, 106);
            this.discriptionTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxes_viewBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(72, 63);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(290, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // full_nameTextBox
            // 
            this.full_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxes_viewBindingSource, "full_name", true));
            this.full_nameTextBox.Location = new System.Drawing.Point(111, 89);
            this.full_nameTextBox.Name = "full_nameTextBox";
            this.full_nameTextBox.Size = new System.Drawing.Size(251, 20);
            this.full_nameTextBox.TabIndex = 5;
            // 
            // taxes_viewTableAdapter
            // 
            this.taxes_viewTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.SubjectsTableAdapter = null;
            this.tableAdapterManager.Tax_authorityTableAdapter = null;
            this.tableAdapterManager.Taxes_vedTableAdapter = null;
            this.tableAdapterManager.Taxes_viewTableAdapter = this.taxes_viewTableAdapter;
            this.tableAdapterManager.TaxesTableAdapter = this.taxesTableAdapter;
            this.tableAdapterManager.UpdateOrder = NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // taxesTableAdapter
            // 
            this.taxesTableAdapter.ClearBeforeFill = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Код";
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // taxnameDataGridViewTextBoxColumn
            // 
            this.taxnameDataGridViewTextBoxColumn.DataPropertyName = "tax_name";
            this.taxnameDataGridViewTextBoxColumn.HeaderText = "Название налога";
            this.taxnameDataGridViewTextBoxColumn.Name = "taxnameDataGridViewTextBoxColumn";
            this.taxnameDataGridViewTextBoxColumn.Width = 210;
            // 
            // TaxesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TaxesView";
            this.Size = new System.Drawing.Size(679, 436);
            this.Load += new System.EventHandler(this.TaxesView_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxes_viewBindingNavigator)).EndInit();
            this.taxes_viewBindingNavigator.ResumeLayout(false);
            this.taxes_viewBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxes_viewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBoxTaxes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxesFK00BindingSource)).EndInit();
            this.groupBoxTaxesView.ResumeLayout(false);
            this.groupBoxTaxesView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource taxes_viewBindingSource;
        private base_nalogDataSetTableAdapters.Taxes_viewTableAdapter taxes_viewTableAdapter;
        private base_nalogDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator taxes_viewBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton taxes_viewBindingNavigatorSaveItem;
        private System.Windows.Forms.GroupBox groupBoxTaxes;
        private System.Windows.Forms.GroupBox groupBoxTaxesView;
        private System.Windows.Forms.TextBox кодTextBox;
        private System.Windows.Forms.TextBox discriptionTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox full_nameTextBox;
        private System.Windows.Forms.DataGridView dataGridViewTaxes;
        private System.Windows.Forms.BindingSource taxesFK00BindingSource;
        private base_nalogDataSetTableAdapters.TaxesTableAdapter taxesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxnameDataGridViewTextBoxColumn;

    }
}
