namespace NalogAdministrator.Controls.Reference
{
    partial class Taxes
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
            System.Windows.Forms.Label tax_nameLabel;
            System.Windows.Forms.Label discriptionLabel;
            System.Windows.Forms.Label id_viewLabel;
            System.Windows.Forms.Label fbLabel;
            System.Windows.Forms.Label useLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Taxes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.taxesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.taxesBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.taxesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxTaxesView = new System.Windows.Forms.ComboBox();
            this.taxesviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_viewTextBox = new System.Windows.Forms.TextBox();
            this.useCheckBox = new System.Windows.Forms.CheckBox();
            this.fbCheckBox = new System.Windows.Forms.CheckBox();
            this.discriptionTextBox = new System.Windows.Forms.TextBox();
            this.tax_nameTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.taxesTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.TaxesTableAdapter();
            this.tableAdapterManager = new NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager();
            this.taxes_viewTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Taxes_viewTableAdapter();
            idLabel = new System.Windows.Forms.Label();
            tax_nameLabel = new System.Windows.Forms.Label();
            discriptionLabel = new System.Windows.Forms.Label();
            id_viewLabel = new System.Windows.Forms.Label();
            fbLabel = new System.Windows.Forms.Label();
            useLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingNavigator)).BeginInit();
            this.taxesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesviewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(394, 12);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(29, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Код:";
            // 
            // tax_nameLabel
            // 
            tax_nameLabel.AutoSize = true;
            tax_nameLabel.Location = new System.Drawing.Point(25, 38);
            tax_nameLabel.Name = "tax_nameLabel";
            tax_nameLabel.Size = new System.Drawing.Size(60, 13);
            tax_nameLabel.TabIndex = 2;
            tax_nameLabel.Text = "Название:";
            // 
            // discriptionLabel
            // 
            discriptionLabel.AutoSize = true;
            discriptionLabel.Location = new System.Drawing.Point(25, 64);
            discriptionLabel.Name = "discriptionLabel";
            discriptionLabel.Size = new System.Drawing.Size(60, 13);
            discriptionLabel.TabIndex = 4;
            discriptionLabel.Text = "Описание:";
            // 
            // id_viewLabel
            // 
            id_viewLabel.AutoSize = true;
            id_viewLabel.Location = new System.Drawing.Point(56, 12);
            id_viewLabel.Name = "id_viewLabel";
            id_viewLabel.Size = new System.Drawing.Size(29, 13);
            id_viewLabel.TabIndex = 6;
            id_viewLabel.Text = "Вид:";
            // 
            // fbLabel
            // 
            fbLabel.AutoSize = true;
            fbLabel.Location = new System.Drawing.Point(3, 211);
            fbLabel.Name = "fbLabel";
            fbLabel.Size = new System.Drawing.Size(19, 13);
            fbLabel.TabIndex = 10;
            fbLabel.Text = "fb:";
            // 
            // useLabel
            // 
            useLabel.AutoSize = true;
            useLabel.Location = new System.Drawing.Point(105, 211);
            useLabel.Name = "useLabel";
            useLabel.Size = new System.Drawing.Size(27, 13);
            useLabel.TabIndex = 12;
            useLabel.Text = "use:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.taxesBindingNavigator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 100);
            this.panel2.TabIndex = 1;
            // 
            // taxesBindingNavigator
            // 
            this.taxesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.taxesBindingNavigator.BindingSource = this.taxesBindingSource;
            this.taxesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.taxesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.taxesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.taxesBindingNavigatorSaveItem});
            this.taxesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.taxesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.taxesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.taxesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.taxesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.taxesBindingNavigator.Name = "taxesBindingNavigator";
            this.taxesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.taxesBindingNavigator.Size = new System.Drawing.Size(503, 25);
            this.taxesBindingNavigator.TabIndex = 3;
            this.taxesBindingNavigator.Text = "bindingNavigator1";
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
            // taxesBindingSource
            // 
            this.taxesBindingSource.DataMember = "Taxes";
            this.taxesBindingSource.DataSource = this.base_nalogDataSet;
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
            // taxesBindingNavigatorSaveItem
            // 
            this.taxesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.taxesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("taxesBindingNavigatorSaveItem.Image")));
            this.taxesBindingNavigatorSaveItem.Name = "taxesBindingNavigatorSaveItem";
            this.taxesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.taxesBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBoxTaxesView);
            this.panel3.Controls.Add(this.id_viewTextBox);
            this.panel3.Controls.Add(useLabel);
            this.panel3.Controls.Add(this.useCheckBox);
            this.panel3.Controls.Add(fbLabel);
            this.panel3.Controls.Add(this.fbCheckBox);
            this.panel3.Controls.Add(id_viewLabel);
            this.panel3.Controls.Add(discriptionLabel);
            this.panel3.Controls.Add(this.discriptionTextBox);
            this.panel3.Controls.Add(tax_nameLabel);
            this.panel3.Controls.Add(this.tax_nameTextBox);
            this.panel3.Controls.Add(idLabel);
            this.panel3.Controls.Add(this.idTextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(503, 250);
            this.panel3.TabIndex = 2;
            // 
            // comboBoxTaxesView
            // 
            this.comboBoxTaxesView.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.taxesBindingSource, "id_view", true));
            this.comboBoxTaxesView.DataSource = this.taxesviewBindingSource;
            this.comboBoxTaxesView.DisplayMember = "name";
            this.comboBoxTaxesView.FormattingEnabled = true;
            this.comboBoxTaxesView.Location = new System.Drawing.Point(125, 8);
            this.comboBoxTaxesView.Name = "comboBoxTaxesView";
            this.comboBoxTaxesView.Size = new System.Drawing.Size(249, 21);
            this.comboBoxTaxesView.TabIndex = 15;
            this.comboBoxTaxesView.ValueMember = "id";
            this.comboBoxTaxesView.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaxesView_SelectedIndexChanged);
            // 
            // taxesviewBindingSource
            // 
            this.taxesviewBindingSource.DataMember = "Taxes_view";
            this.taxesviewBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // id_viewTextBox
            // 
            this.id_viewTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesBindingSource, "id_view", true));
            this.id_viewTextBox.Location = new System.Drawing.Point(91, 9);
            this.id_viewTextBox.Name = "id_viewTextBox";
            this.id_viewTextBox.Size = new System.Drawing.Size(28, 20);
            this.id_viewTextBox.TabIndex = 14;
            // 
            // useCheckBox
            // 
            this.useCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.taxesBindingSource, "use", true));
            this.useCheckBox.Location = new System.Drawing.Point(138, 206);
            this.useCheckBox.Name = "useCheckBox";
            this.useCheckBox.Size = new System.Drawing.Size(104, 24);
            this.useCheckBox.TabIndex = 13;
            this.useCheckBox.Text = "checkBox1";
            this.useCheckBox.UseVisualStyleBackColor = true;
            // 
            // fbCheckBox
            // 
            this.fbCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.taxesBindingSource, "fb", true));
            this.fbCheckBox.Location = new System.Drawing.Point(28, 206);
            this.fbCheckBox.Name = "fbCheckBox";
            this.fbCheckBox.Size = new System.Drawing.Size(104, 24);
            this.fbCheckBox.TabIndex = 11;
            this.fbCheckBox.Text = "checkBox1";
            this.fbCheckBox.UseVisualStyleBackColor = true;
            // 
            // discriptionTextBox
            // 
            this.discriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesBindingSource, "discription", true));
            this.discriptionTextBox.Location = new System.Drawing.Point(91, 61);
            this.discriptionTextBox.Multiline = true;
            this.discriptionTextBox.Name = "discriptionTextBox";
            this.discriptionTextBox.Size = new System.Drawing.Size(392, 77);
            this.discriptionTextBox.TabIndex = 5;
            // 
            // tax_nameTextBox
            // 
            this.tax_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesBindingSource, "tax_name", true));
            this.tax_nameTextBox.Location = new System.Drawing.Point(91, 35);
            this.tax_nameTextBox.Name = "tax_nameTextBox";
            this.tax_nameTextBox.Size = new System.Drawing.Size(392, 20);
            this.tax_nameTextBox.TabIndex = 3;
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxesBindingSource, "id", true));
            this.idTextBox.Location = new System.Drawing.Point(429, 9);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(54, 20);
            this.idTextBox.TabIndex = 1;
            // 
            // taxesTableAdapter
            // 
            this.taxesTableAdapter.ClearBeforeFill = true;
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
            // taxes_viewTableAdapter
            // 
            this.taxes_viewTableAdapter.ClearBeforeFill = true;
            // 
            // Taxes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Taxes";
            this.Size = new System.Drawing.Size(503, 450);
            this.Tag = "Налоги";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingNavigator)).EndInit();
            this.taxesBindingNavigator.ResumeLayout(false);
            this.taxesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxesviewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource taxesBindingSource;
        private base_nalogDataSetTableAdapters.TaxesTableAdapter taxesTableAdapter;
        private base_nalogDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator taxesBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton taxesBindingNavigatorSaveItem;
        private System.Windows.Forms.CheckBox useCheckBox;
        private System.Windows.Forms.CheckBox fbCheckBox;
        private System.Windows.Forms.TextBox discriptionTextBox;
        private System.Windows.Forms.TextBox tax_nameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.BindingSource taxesviewBindingSource;
        private base_nalogDataSetTableAdapters.Taxes_viewTableAdapter taxes_viewTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxTaxesView;
        private System.Windows.Forms.TextBox id_viewTextBox;
    }
}
