namespace NalogAdministrator.Forms.Reference
{
    partial class FormReportConfig
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label discriptionLabel;
            System.Windows.Forms.Label code_nameLabel;
            System.Windows.Forms.Label id_report_viewLabel;
            System.Windows.Forms.Label id_report_typeLabel;
            System.Windows.Forms.Label discription_htmlLabel;
            System.Windows.Forms.Label report_schemeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportConfig));
            System.Windows.Forms.Label report_settingsLabel;
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.reportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.ReportsTableAdapter();
            this.tableAdapterManager = new NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager();
            this.reportsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
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
            this.reportsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.discriptionTextBox = new System.Windows.Forms.TextBox();
            this.code_nameTextBox = new System.Windows.Forms.TextBox();
            this.id_report_viewTextBox = new System.Windows.Forms.TextBox();
            this.id_report_typeTextBox = new System.Windows.Forms.TextBox();
            this.enableCheckBox = new System.Windows.Forms.CheckBox();
            this.viewCheckBox = new System.Windows.Forms.CheckBox();
            this.discription_htmlTextBox = new System.Windows.Forms.TextBox();
            this.report_schemeTextBox = new System.Windows.Forms.TextBox();
            this.report_settingsTextBox = new System.Windows.Forms.TextBox();
            idLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            discriptionLabel = new System.Windows.Forms.Label();
            code_nameLabel = new System.Windows.Forms.Label();
            id_report_viewLabel = new System.Windows.Forms.Label();
            id_report_typeLabel = new System.Windows.Forms.Label();
            discription_htmlLabel = new System.Windows.Forms.Label();
            report_schemeLabel = new System.Windows.Forms.Label();
            report_settingsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingNavigator)).BeginInit();
            this.reportsBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(410, 31);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(29, 13);
            idLabel.TabIndex = 1;
            idLabel.Text = "Код:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(10, 57);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(86, 13);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Наименование:";
            // 
            // discriptionLabel
            // 
            discriptionLabel.AutoSize = true;
            discriptionLabel.Location = new System.Drawing.Point(36, 87);
            discriptionLabel.Name = "discriptionLabel";
            discriptionLabel.Size = new System.Drawing.Size(60, 13);
            discriptionLabel.TabIndex = 5;
            discriptionLabel.Text = "Описание:";
            // 
            // code_nameLabel
            // 
            code_nameLabel.AutoSize = true;
            code_nameLabel.Location = new System.Drawing.Point(335, 57);
            code_nameLabel.Name = "code_nameLabel";
            code_nameLabel.Size = new System.Drawing.Size(104, 13);
            code_nameLabel.TabIndex = 7;
            code_nameLabel.Text = "Кодовое название:";
            // 
            // id_report_viewLabel
            // 
            id_report_viewLabel.AutoSize = true;
            id_report_viewLabel.Location = new System.Drawing.Point(383, 83);
            id_report_viewLabel.Name = "id_report_viewLabel";
            id_report_viewLabel.Size = new System.Drawing.Size(56, 13);
            id_report_viewLabel.TabIndex = 9;
            id_report_viewLabel.Text = "Код вида:";
            // 
            // id_report_typeLabel
            // 
            id_report_typeLabel.AutoSize = true;
            id_report_typeLabel.Location = new System.Drawing.Point(384, 109);
            id_report_typeLabel.Name = "id_report_typeLabel";
            id_report_typeLabel.Size = new System.Drawing.Size(55, 13);
            id_report_typeLabel.TabIndex = 11;
            id_report_typeLabel.Text = "Код типа:";
            // 
            // discription_htmlLabel
            // 
            discription_htmlLabel.AutoSize = true;
            discription_htmlLabel.Location = new System.Drawing.Point(3, 172);
            discription_htmlLabel.Name = "discription_htmlLabel";
            discription_htmlLabel.Size = new System.Drawing.Size(93, 13);
            discription_htmlLabel.TabIndex = 17;
            discription_htmlLabel.Text = "Описание HTML:";
            // 
            // report_schemeLabel
            // 
            report_schemeLabel.AutoSize = true;
            report_schemeLabel.Location = new System.Drawing.Point(54, 250);
            report_schemeLabel.Name = "report_schemeLabel";
            report_schemeLabel.Size = new System.Drawing.Size(42, 13);
            report_schemeLabel.TabIndex = 19;
            report_schemeLabel.Text = "Схема:";
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportsBindingSource
            // 
            this.reportsBindingSource.DataMember = "Reports";
            this.reportsBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // reportsTableAdapter
            // 
            this.reportsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CityTableAdapter = null;
            this.tableAdapterManager.Compare_tax_eeaTableAdapter = null;
            this.tableAdapterManager.Data_viewTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_eea_gksTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_eeaTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_subject_eea_gksTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_subject_eeaTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_subject_taxTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_subjectTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_taxTableAdapter = null;
            this.tableAdapterManager.Federal_districtTableAdapter = null;
            this.tableAdapterManager.LogTableAdapter = null;
            this.tableAdapterManager.Report_typeTableAdapter = null;
            this.tableAdapterManager.Report_viewTableAdapter = null;
            this.tableAdapterManager.ReportsTableAdapter = this.reportsTableAdapter;
            this.tableAdapterManager.Source_data_1NMTableAdapter = null;
            this.tableAdapterManager.Source_data_1NOM_schemeTableAdapter = null;
            this.tableAdapterManager.Source_data_1NOMTableAdapter = null;
            this.tableAdapterManager.Source_data_Population_eeaTableAdapter = null;
            this.tableAdapterManager.Source_data_PopulationTableAdapter = null;
            this.tableAdapterManager.Source_data_Subject_indexTableAdapter = null;
            this.tableAdapterManager.Source_data_viewTableAdapter = null;
            this.tableAdapterManager.Subject_typeTableAdapter = null;
            this.tableAdapterManager.SubjectsTableAdapter = null;
            this.tableAdapterManager.Tax_authorityTableAdapter = null;
            this.tableAdapterManager.Taxes_vedTableAdapter = null;
            this.tableAdapterManager.Taxes_viewTableAdapter = null;
            this.tableAdapterManager.TaxesTableAdapter = null;
            this.tableAdapterManager.TimeTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // reportsBindingNavigator
            // 
            this.reportsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.reportsBindingNavigator.BindingSource = this.reportsBindingSource;
            this.reportsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.reportsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.reportsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.reportsBindingNavigatorSaveItem});
            this.reportsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.reportsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.reportsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.reportsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.reportsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.reportsBindingNavigator.Name = "reportsBindingNavigator";
            this.reportsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.reportsBindingNavigator.Size = new System.Drawing.Size(581, 25);
            this.reportsBindingNavigator.TabIndex = 0;
            this.reportsBindingNavigator.Text = "bindingNavigator1";
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
            // reportsBindingNavigatorSaveItem
            // 
            this.reportsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reportsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("reportsBindingNavigatorSaveItem.Image")));
            this.reportsBindingNavigatorSaveItem.Name = "reportsBindingNavigatorSaveItem";
            this.reportsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.reportsBindingNavigatorSaveItem.Text = "Save Data";
            this.reportsBindingNavigatorSaveItem.Click += new System.EventHandler(this.reportsBindingNavigatorSaveItem_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "id", true));
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(445, 28);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(115, 20);
            this.idTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(102, 54);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(227, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // discriptionTextBox
            // 
            this.discriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "discription", true));
            this.discriptionTextBox.Location = new System.Drawing.Point(102, 80);
            this.discriptionTextBox.Multiline = true;
            this.discriptionTextBox.Name = "discriptionTextBox";
            this.discriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.discriptionTextBox.Size = new System.Drawing.Size(227, 53);
            this.discriptionTextBox.TabIndex = 6;
            // 
            // code_nameTextBox
            // 
            this.code_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "code_name", true));
            this.code_nameTextBox.Location = new System.Drawing.Point(445, 54);
            this.code_nameTextBox.Name = "code_nameTextBox";
            this.code_nameTextBox.Size = new System.Drawing.Size(115, 20);
            this.code_nameTextBox.TabIndex = 8;
            // 
            // id_report_viewTextBox
            // 
            this.id_report_viewTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "id_report_view", true));
            this.id_report_viewTextBox.Location = new System.Drawing.Point(445, 80);
            this.id_report_viewTextBox.Name = "id_report_viewTextBox";
            this.id_report_viewTextBox.Size = new System.Drawing.Size(115, 20);
            this.id_report_viewTextBox.TabIndex = 10;
            // 
            // id_report_typeTextBox
            // 
            this.id_report_typeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "id_report_type", true));
            this.id_report_typeTextBox.Location = new System.Drawing.Point(445, 106);
            this.id_report_typeTextBox.Name = "id_report_typeTextBox";
            this.id_report_typeTextBox.Size = new System.Drawing.Size(115, 20);
            this.id_report_typeTextBox.TabIndex = 12;
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.reportsBindingSource, "enable", true));
            this.enableCheckBox.Location = new System.Drawing.Point(100, 139);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(104, 24);
            this.enableCheckBox.TabIndex = 14;
            this.enableCheckBox.Text = "Используется";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewCheckBox
            // 
            this.viewCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.reportsBindingSource, "view", true));
            this.viewCheckBox.Location = new System.Drawing.Point(210, 139);
            this.viewCheckBox.Name = "viewCheckBox";
            this.viewCheckBox.Size = new System.Drawing.Size(104, 24);
            this.viewCheckBox.TabIndex = 16;
            this.viewCheckBox.Text = "Отображается";
            this.viewCheckBox.UseVisualStyleBackColor = true;
            // 
            // discription_htmlTextBox
            // 
            this.discription_htmlTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "discription_html", true));
            this.discription_htmlTextBox.Location = new System.Drawing.Point(102, 169);
            this.discription_htmlTextBox.Multiline = true;
            this.discription_htmlTextBox.Name = "discription_htmlTextBox";
            this.discription_htmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.discription_htmlTextBox.Size = new System.Drawing.Size(458, 72);
            this.discription_htmlTextBox.TabIndex = 18;
            // 
            // report_schemeTextBox
            // 
            this.report_schemeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "report_scheme", true));
            this.report_schemeTextBox.Location = new System.Drawing.Point(102, 247);
            this.report_schemeTextBox.Multiline = true;
            this.report_schemeTextBox.Name = "report_schemeTextBox";
            this.report_schemeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.report_schemeTextBox.Size = new System.Drawing.Size(459, 72);
            this.report_schemeTextBox.TabIndex = 20;
            // 
            // report_settingsLabel
            // 
            report_settingsLabel.AutoSize = true;
            report_settingsLabel.Location = new System.Drawing.Point(27, 328);
            report_settingsLabel.Name = "report_settingsLabel";
            report_settingsLabel.Size = new System.Drawing.Size(69, 13);
            report_settingsLabel.TabIndex = 20;
            report_settingsLabel.Text = "Параметры:";
            // 
            // report_settingsTextBox
            // 
            this.report_settingsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "report_settings", true));
            this.report_settingsTextBox.Location = new System.Drawing.Point(100, 325);
            this.report_settingsTextBox.Multiline = true;
            this.report_settingsTextBox.Name = "report_settingsTextBox";
            this.report_settingsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.report_settingsTextBox.Size = new System.Drawing.Size(460, 106);
            this.report_settingsTextBox.TabIndex = 21;
            // 
            // FormReportConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 443);
            this.Controls.Add(report_settingsLabel);
            this.Controls.Add(this.report_settingsTextBox);
            this.Controls.Add(report_schemeLabel);
            this.Controls.Add(this.report_schemeTextBox);
            this.Controls.Add(discription_htmlLabel);
            this.Controls.Add(this.discription_htmlTextBox);
            this.Controls.Add(this.viewCheckBox);
            this.Controls.Add(this.enableCheckBox);
            this.Controls.Add(id_report_typeLabel);
            this.Controls.Add(this.id_report_typeTextBox);
            this.Controls.Add(id_report_viewLabel);
            this.Controls.Add(this.id_report_viewTextBox);
            this.Controls.Add(code_nameLabel);
            this.Controls.Add(this.code_nameTextBox);
            this.Controls.Add(discriptionLabel);
            this.Controls.Add(this.discriptionTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.reportsBindingNavigator);
            this.Name = "FormReportConfig";
            this.Text = "FormReportConfig";
            this.Load += new System.EventHandler(this.FormReportConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingNavigator)).EndInit();
            this.reportsBindingNavigator.ResumeLayout(false);
            this.reportsBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource reportsBindingSource;
        private base_nalogDataSetTableAdapters.ReportsTableAdapter reportsTableAdapter;
        private base_nalogDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator reportsBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton reportsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox discriptionTextBox;
        private System.Windows.Forms.TextBox code_nameTextBox;
        private System.Windows.Forms.TextBox id_report_viewTextBox;
        private System.Windows.Forms.TextBox id_report_typeTextBox;
        private System.Windows.Forms.CheckBox enableCheckBox;
        private System.Windows.Forms.CheckBox viewCheckBox;
        private System.Windows.Forms.TextBox discription_htmlTextBox;
        private System.Windows.Forms.TextBox report_schemeTextBox;
        private System.Windows.Forms.TextBox report_settingsTextBox;
    }
}