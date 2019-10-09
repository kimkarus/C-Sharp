namespace NalogAdministrator.Controls.Reference
{
    partial class Reports
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label id_report_viewLabel;
            System.Windows.Forms.Label id_report_typeLabel;
            System.Windows.Forms.Label report_settingsLabel;
            System.Windows.Forms.Label report_schemeLabel;
            System.Windows.Forms.Label discription_htmlLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label discriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBoxReport = new System.Windows.Forms.GroupBox();
            this.discriptionTextBox = new System.Windows.Forms.TextBox();
            this.reportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.viewCheckBox = new System.Windows.Forms.CheckBox();
            this.enableCheckBox = new System.Windows.Forms.CheckBox();
            this.report_settingsTextBox = new System.Windows.Forms.TextBox();
            this.report_schemeTextBox = new System.Windows.Forms.TextBox();
            this.discription_htmlTextBox = new System.Windows.Forms.TextBox();
            this.comboBoxIdType = new System.Windows.Forms.ComboBox();
            this.reporttypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxIdReportView = new System.Windows.Forms.ComboBox();
            this.reportviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id_report_typeTextBox = new System.Windows.Forms.TextBox();
            this.id_report_viewTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.toolStripButtonSearchList = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.ReportsTableAdapter();
            this.tableAdapterManager = new NalogAdministrator.base_nalogDataSetTableAdapters.TableAdapterManager();
            this.report_typeTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Report_typeTableAdapter();
            this.report_viewTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.Report_viewTableAdapter();
            this.add_zeroCheckBox = new System.Windows.Forms.CheckBox();
            idLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            id_report_viewLabel = new System.Windows.Forms.Label();
            id_report_typeLabel = new System.Windows.Forms.Label();
            report_settingsLabel = new System.Windows.Forms.Label();
            report_schemeLabel = new System.Windows.Forms.Label();
            discription_htmlLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            discriptionLabel = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.groupBoxReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporttypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportviewBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingNavigator)).BeginInit();
            this.reportsBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Enabled = false;
            idLabel.Location = new System.Drawing.Point(436, 22);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(29, 13);
            idLabel.TabIndex = 0;
            idLabel.Text = "Код:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(15, 49);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(60, 13);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Название:";
            // 
            // id_report_viewLabel
            // 
            id_report_viewLabel.AutoSize = true;
            id_report_viewLabel.Location = new System.Drawing.Point(376, 75);
            id_report_viewLabel.Name = "id_report_viewLabel";
            id_report_viewLabel.Size = new System.Drawing.Size(29, 13);
            id_report_viewLabel.TabIndex = 12;
            id_report_viewLabel.Text = "Вид:";
            // 
            // id_report_typeLabel
            // 
            id_report_typeLabel.AutoSize = true;
            id_report_typeLabel.Location = new System.Drawing.Point(376, 48);
            id_report_typeLabel.Name = "id_report_typeLabel";
            id_report_typeLabel.Size = new System.Drawing.Size(29, 13);
            id_report_typeLabel.TabIndex = 13;
            id_report_typeLabel.Text = "Тип:";
            // 
            // report_settingsLabel
            // 
            report_settingsLabel.AutoSize = true;
            report_settingsLabel.Location = new System.Drawing.Point(37, 319);
            report_settingsLabel.Name = "report_settingsLabel";
            report_settingsLabel.Size = new System.Drawing.Size(69, 13);
            report_settingsLabel.TabIndex = 25;
            report_settingsLabel.Text = "Параметры:";
            // 
            // report_schemeLabel
            // 
            report_schemeLabel.AutoSize = true;
            report_schemeLabel.Location = new System.Drawing.Point(64, 241);
            report_schemeLabel.Name = "report_schemeLabel";
            report_schemeLabel.Size = new System.Drawing.Size(42, 13);
            report_schemeLabel.TabIndex = 24;
            report_schemeLabel.Text = "Схема:";
            // 
            // discription_htmlLabel
            // 
            discription_htmlLabel.AutoSize = true;
            discription_htmlLabel.Location = new System.Drawing.Point(13, 163);
            discription_htmlLabel.Name = "discription_htmlLabel";
            discription_htmlLabel.Size = new System.Drawing.Size(93, 13);
            discription_htmlLabel.TabIndex = 22;
            discription_htmlLabel.Text = "Описание HTML:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 75);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 13);
            label1.TabIndex = 30;
            label1.Text = "Кодовое название:";
            // 
            // discriptionLabel
            // 
            discriptionLabel.AutoSize = true;
            discriptionLabel.Location = new System.Drawing.Point(15, 104);
            discriptionLabel.Name = "discriptionLabel";
            discriptionLabel.Size = new System.Drawing.Size(60, 13);
            discriptionLabel.TabIndex = 32;
            discriptionLabel.Text = "Описание:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBoxReport);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(579, 431);
            this.panel3.TabIndex = 4;
            // 
            // groupBoxReport
            // 
            this.groupBoxReport.Controls.Add(this.add_zeroCheckBox);
            this.groupBoxReport.Controls.Add(discriptionLabel);
            this.groupBoxReport.Controls.Add(this.discriptionTextBox);
            this.groupBoxReport.Controls.Add(label1);
            this.groupBoxReport.Controls.Add(this.textBox1);
            this.groupBoxReport.Controls.Add(this.viewCheckBox);
            this.groupBoxReport.Controls.Add(this.enableCheckBox);
            this.groupBoxReport.Controls.Add(report_settingsLabel);
            this.groupBoxReport.Controls.Add(this.report_settingsTextBox);
            this.groupBoxReport.Controls.Add(report_schemeLabel);
            this.groupBoxReport.Controls.Add(this.report_schemeTextBox);
            this.groupBoxReport.Controls.Add(discription_htmlLabel);
            this.groupBoxReport.Controls.Add(this.discription_htmlTextBox);
            this.groupBoxReport.Controls.Add(this.comboBoxIdType);
            this.groupBoxReport.Controls.Add(this.comboBoxIdReportView);
            this.groupBoxReport.Controls.Add(id_report_typeLabel);
            this.groupBoxReport.Controls.Add(this.id_report_typeTextBox);
            this.groupBoxReport.Controls.Add(id_report_viewLabel);
            this.groupBoxReport.Controls.Add(this.id_report_viewTextBox);
            this.groupBoxReport.Controls.Add(nameLabel);
            this.groupBoxReport.Controls.Add(this.nameTextBox);
            this.groupBoxReport.Controls.Add(idLabel);
            this.groupBoxReport.Controls.Add(this.idTextBox);
            this.groupBoxReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxReport.Location = new System.Drawing.Point(0, 0);
            this.groupBoxReport.Name = "groupBoxReport";
            this.groupBoxReport.Size = new System.Drawing.Size(687, 431);
            this.groupBoxReport.TabIndex = 10;
            this.groupBoxReport.TabStop = false;
            this.groupBoxReport.Text = "Отчет";
            // 
            // discriptionTextBox
            // 
            this.discriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "discription", true));
            this.discriptionTextBox.Location = new System.Drawing.Point(81, 101);
            this.discriptionTextBox.Multiline = true;
            this.discriptionTextBox.Name = "discriptionTextBox";
            this.discriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.discriptionTextBox.Size = new System.Drawing.Size(289, 53);
            this.discriptionTextBox.TabIndex = 33;
            // 
            // reportsBindingSource
            // 
            this.reportsBindingSource.DataMember = "Reports";
            this.reportsBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "code_name", true));
            this.textBox1.Location = new System.Drawing.Point(125, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 20);
            this.textBox1.TabIndex = 31;
            // 
            // viewCheckBox
            // 
            this.viewCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.reportsBindingSource, "view", true));
            this.viewCheckBox.Location = new System.Drawing.Point(379, 130);
            this.viewCheckBox.Name = "viewCheckBox";
            this.viewCheckBox.Size = new System.Drawing.Size(104, 24);
            this.viewCheckBox.TabIndex = 29;
            this.viewCheckBox.Text = "Отображается";
            this.viewCheckBox.UseVisualStyleBackColor = true;
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.reportsBindingSource, "enable", true));
            this.enableCheckBox.Location = new System.Drawing.Point(379, 98);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(104, 24);
            this.enableCheckBox.TabIndex = 28;
            this.enableCheckBox.Text = "Используется";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            // 
            // report_settingsTextBox
            // 
            this.report_settingsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "report_settings", true));
            this.report_settingsTextBox.Location = new System.Drawing.Point(110, 316);
            this.report_settingsTextBox.Multiline = true;
            this.report_settingsTextBox.Name = "report_settingsTextBox";
            this.report_settingsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.report_settingsTextBox.Size = new System.Drawing.Size(460, 106);
            this.report_settingsTextBox.TabIndex = 27;
            // 
            // report_schemeTextBox
            // 
            this.report_schemeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "report_scheme", true));
            this.report_schemeTextBox.Location = new System.Drawing.Point(112, 238);
            this.report_schemeTextBox.Multiline = true;
            this.report_schemeTextBox.Name = "report_schemeTextBox";
            this.report_schemeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.report_schemeTextBox.Size = new System.Drawing.Size(459, 72);
            this.report_schemeTextBox.TabIndex = 26;
            // 
            // discription_htmlTextBox
            // 
            this.discription_htmlTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "discription_html", true));
            this.discription_htmlTextBox.Location = new System.Drawing.Point(112, 160);
            this.discription_htmlTextBox.Multiline = true;
            this.discription_htmlTextBox.Name = "discription_htmlTextBox";
            this.discription_htmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.discription_htmlTextBox.Size = new System.Drawing.Size(458, 72);
            this.discription_htmlTextBox.TabIndex = 23;
            // 
            // comboBoxIdType
            // 
            this.comboBoxIdType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.reportsBindingSource, "id_report_type", true));
            this.comboBoxIdType.DataSource = this.reporttypeBindingSource;
            this.comboBoxIdType.DisplayMember = "name";
            this.comboBoxIdType.FormattingEnabled = true;
            this.comboBoxIdType.Location = new System.Drawing.Point(439, 45);
            this.comboBoxIdType.Name = "comboBoxIdType";
            this.comboBoxIdType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIdType.TabIndex = 16;
            this.comboBoxIdType.ValueMember = "id";
            this.comboBoxIdType.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // reporttypeBindingSource
            // 
            this.reporttypeBindingSource.DataMember = "Report_type";
            this.reporttypeBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // comboBoxIdReportView
            // 
            this.comboBoxIdReportView.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.reportsBindingSource, "id_report_view", true));
            this.comboBoxIdReportView.DataSource = this.reportviewBindingSource;
            this.comboBoxIdReportView.DisplayMember = "name";
            this.comboBoxIdReportView.FormattingEnabled = true;
            this.comboBoxIdReportView.Location = new System.Drawing.Point(439, 72);
            this.comboBoxIdReportView.Name = "comboBoxIdReportView";
            this.comboBoxIdReportView.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIdReportView.TabIndex = 15;
            this.comboBoxIdReportView.ValueMember = "id";
            this.comboBoxIdReportView.SelectedIndexChanged += new System.EventHandler(this.comboBoxIdReportView_SelectedIndexChanged);
            // 
            // reportviewBindingSource
            // 
            this.reportviewBindingSource.DataMember = "Report_view";
            this.reportviewBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // id_report_typeTextBox
            // 
            this.id_report_typeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "id_report_type", true));
            this.id_report_typeTextBox.Enabled = false;
            this.id_report_typeTextBox.Location = new System.Drawing.Point(411, 46);
            this.id_report_typeTextBox.Name = "id_report_typeTextBox";
            this.id_report_typeTextBox.Size = new System.Drawing.Size(22, 20);
            this.id_report_typeTextBox.TabIndex = 14;
            // 
            // id_report_viewTextBox
            // 
            this.id_report_viewTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "id_report_view", true));
            this.id_report_viewTextBox.Enabled = false;
            this.id_report_viewTextBox.Location = new System.Drawing.Point(411, 72);
            this.id_report_viewTextBox.Name = "id_report_viewTextBox";
            this.id_report_viewTextBox.Size = new System.Drawing.Size(22, 20);
            this.id_report_viewTextBox.TabIndex = 13;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(81, 46);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(289, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reportsBindingSource, "id", true));
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(460, 19);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportsBindingNavigator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 100);
            this.panel2.TabIndex = 3;
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
            this.reportsBindingNavigatorSaveItem,
            this.toolStripButtonSearchList});
            this.reportsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.reportsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.reportsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.reportsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.reportsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.reportsBindingNavigator.Name = "reportsBindingNavigator";
            this.reportsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.reportsBindingNavigator.Size = new System.Drawing.Size(579, 25);
            this.reportsBindingNavigator.TabIndex = 5;
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
            // toolStripButtonSearchList
            // 
            this.toolStripButtonSearchList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSearchList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearchList.Name = "toolStripButtonSearchList";
            this.toolStripButtonSearchList.Size = new System.Drawing.Size(98, 22);
            this.toolStripButtonSearchList.Tag = "Reports";
            this.toolStripButtonSearchList.Text = "Поиск / Список";
            this.toolStripButtonSearchList.Click += new System.EventHandler(this.toolStripButtonSearchList_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 100);
            this.panel1.TabIndex = 2;
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
            this.tableAdapterManager.Data_warehouse_district_eea_gksTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_district_eeaTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_district_taxTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_districtTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_eea_gksTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_eeaTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_subject_eea_gksTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_subject_eeaTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_subject_taxTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_subjectTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_taxTableAdapter = null;
            this.tableAdapterManager.Data_warehouse_updatesTableAdapter = null;
            this.tableAdapterManager.Federal_districtTableAdapter = null;
            this.tableAdapterManager.LogTableAdapter = null;
            this.tableAdapterManager.Report_typeTableAdapter = this.report_typeTableAdapter;
            this.tableAdapterManager.Report_viewTableAdapter = this.report_viewTableAdapter;
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
            // report_typeTableAdapter
            // 
            this.report_typeTableAdapter.ClearBeforeFill = true;
            // 
            // report_viewTableAdapter
            // 
            this.report_viewTableAdapter.ClearBeforeFill = true;
            // 
            // add_zeroCheckBox
            // 
            this.add_zeroCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.reportsBindingSource, "add_zero", true));
            this.add_zeroCheckBox.Location = new System.Drawing.Point(489, 98);
            this.add_zeroCheckBox.Name = "add_zeroCheckBox";
            this.add_zeroCheckBox.Size = new System.Drawing.Size(81, 24);
            this.add_zeroCheckBox.TabIndex = 34;
            this.add_zeroCheckBox.Text = "Ноль";
            this.add_zeroCheckBox.UseVisualStyleBackColor = true;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Reports";
            this.Size = new System.Drawing.Size(579, 631);
            this.Tag = "Reports";
            this.panel3.ResumeLayout(false);
            this.groupBoxReport.ResumeLayout(false);
            this.groupBoxReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporttypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportviewBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingNavigator)).EndInit();
            this.reportsBindingNavigator.ResumeLayout(false);
            this.reportsBindingNavigator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBoxReport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource reportsBindingSource;
        private base_nalogDataSetTableAdapters.ReportsTableAdapter reportsTableAdapter;
        private base_nalogDataSetTableAdapters.TableAdapterManager tableAdapterManager;
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
        private System.Windows.Forms.BindingSource reporttypeBindingSource;
        private System.Windows.Forms.BindingSource reportviewBindingSource;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private base_nalogDataSetTableAdapters.Report_typeTableAdapter report_typeTableAdapter;
        private base_nalogDataSetTableAdapters.Report_viewTableAdapter report_viewTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxIdType;
        private System.Windows.Forms.ComboBox comboBoxIdReportView;
        private System.Windows.Forms.TextBox id_report_typeTextBox;
        private System.Windows.Forms.TextBox id_report_viewTextBox;
        private System.Windows.Forms.TextBox report_settingsTextBox;
        private System.Windows.Forms.TextBox report_schemeTextBox;
        private System.Windows.Forms.TextBox discription_htmlTextBox;
        private System.Windows.Forms.CheckBox viewCheckBox;
        private System.Windows.Forms.CheckBox enableCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox discriptionTextBox;
        public System.Windows.Forms.BindingNavigator reportsBindingNavigator;
        public System.Windows.Forms.ToolStripButton toolStripButtonSearchList;
        private System.Windows.Forms.CheckBox add_zeroCheckBox;
    }
}
