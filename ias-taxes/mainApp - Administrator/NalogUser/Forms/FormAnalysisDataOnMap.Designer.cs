namespace NalogUser.Forms
{
    partial class FormAnalysisDataOnMap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chHideBottomPanel = new System.Windows.Forms.CheckBox();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.mapControl = new NalogUser.Controls.MapControl(cr);
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.tabControlCommon = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxRF = new System.Windows.Forms.GroupBox();
            this.labelRaiseTI = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.labelYearChoice = new System.Windows.Forms.Label();
            this.labelRaisePopulation = new System.Windows.Forms.Label();
            this.labelRaiseUnemployed = new System.Windows.Forms.Label();
            this.labelRaiseBusyed = new System.Windows.Forms.Label();
            this.labelUnemployed = new System.Windows.Forms.Label();
            this.labelBusyed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPopulation = new System.Windows.Forms.Label();
            this.labelBP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTI = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewStatsData = new System.Windows.Forms.DataGridView();
            this.FD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Population = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaisePopulation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Busyed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaiseBusyed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unemployed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaiseUnemployed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaiseTI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageSubjects = new System.Windows.Forms.TabPage();
            this.groupBoxSubjectsParams = new System.Windows.Forms.GroupBox();
            this.reportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.base_nalogDataSet = new NalogUser.base_nalogDataSet();
            this.comboBoxYearSubjects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSubjects = new System.Windows.Forms.DataGridView();
            this.base_nalog_viewsDataSet = new NalogUser.base_nalog_viewsDataSet();
            this.view_stat_population_districtsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.view_stat_population_districtsTableAdapter = new NalogUser.base_nalog_viewsDataSetTableAdapters.View_stat_population_districtsTableAdapter();
            this.view_stat_ti_districtsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_stat_ti_districtsTableAdapter = new NalogUser.base_nalog_viewsDataSetTableAdapters.View_stat_ti_districtsTableAdapter();
            this.reportsTableAdapter = new NalogUser.base_nalogDataSetTableAdapters.ReportsTableAdapter();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlCommon.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxRF.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatsData)).BeginInit();
            this.tabPageSubjects.SuspendLayout();
            this.groupBoxSubjectsParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalog_viewsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_stat_population_districtsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_stat_ti_districtsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chHideBottomPanel);
            this.splitContainer1.Panel1.Controls.Add(this.elementHost2);
            this.splitContainer1.Panel1.Controls.Add(this.elementHost1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlCommon);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1133, 784);
            this.splitContainer1.SplitterDistance = 495;
            this.splitContainer1.TabIndex = 1;
            // 
            // chHideBottomPanel
            // 
            this.chHideBottomPanel.AutoSize = true;
            this.chHideBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chHideBottomPanel.Location = new System.Drawing.Point(0, 478);
            this.chHideBottomPanel.Name = "chHideBottomPanel";
            this.chHideBottomPanel.Size = new System.Drawing.Size(1133, 17);
            this.chHideBottomPanel.TabIndex = 16;
            this.chHideBottomPanel.Text = "Скрыть панель";
            this.chHideBottomPanel.UseVisualStyleBackColor = true;
            this.chHideBottomPanel.CheckedChanged += new System.EventHandler(this.chHideBottomPanel_CheckedChanged);
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(0, 0);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(1133, 495);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost2_ChildChanged);
            this.elementHost2.Child = this.mapControl;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1133, 495);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // tabControlCommon
            // 
            this.tabControlCommon.Controls.Add(this.tabPageCommon);
            this.tabControlCommon.Controls.Add(this.tabPageSubjects);
            this.tabControlCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCommon.Location = new System.Drawing.Point(0, 0);
            this.tabControlCommon.Name = "tabControlCommon";
            this.tabControlCommon.SelectedIndex = 0;
            this.tabControlCommon.Size = new System.Drawing.Size(1133, 285);
            this.tabControlCommon.TabIndex = 0;
            this.tabControlCommon.SelectedIndexChanged += new System.EventHandler(this.tabControlCommon_SelectedIndexChanged);
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.AutoScroll = true;
            this.tabPageCommon.Controls.Add(this.splitContainer2);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(1125, 259);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Общее";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxRF);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1119, 253);
            this.splitContainer2.SplitterDistance = 433;
            this.splitContainer2.TabIndex = 4;
            // 
            // groupBoxRF
            // 
            this.groupBoxRF.Controls.Add(this.labelRaiseTI);
            this.groupBoxRF.Controls.Add(this.comboBoxYear);
            this.groupBoxRF.Controls.Add(this.labelYearChoice);
            this.groupBoxRF.Controls.Add(this.labelRaisePopulation);
            this.groupBoxRF.Controls.Add(this.labelRaiseUnemployed);
            this.groupBoxRF.Controls.Add(this.labelRaiseBusyed);
            this.groupBoxRF.Controls.Add(this.labelUnemployed);
            this.groupBoxRF.Controls.Add(this.labelBusyed);
            this.groupBoxRF.Controls.Add(this.label6);
            this.groupBoxRF.Controls.Add(this.label5);
            this.groupBoxRF.Controls.Add(this.labelPopulation);
            this.groupBoxRF.Controls.Add(this.labelBP);
            this.groupBoxRF.Controls.Add(this.label3);
            this.groupBoxRF.Controls.Add(this.labelTI);
            this.groupBoxRF.Controls.Add(this.label4);
            this.groupBoxRF.Controls.Add(this.labelYear);
            this.groupBoxRF.Controls.Add(this.label1);
            this.groupBoxRF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRF.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRF.Name = "groupBoxRF";
            this.groupBoxRF.Size = new System.Drawing.Size(433, 253);
            this.groupBoxRF.TabIndex = 2;
            this.groupBoxRF.TabStop = false;
            this.groupBoxRF.Text = "Данные по РФ:";
            // 
            // labelRaiseTI
            // 
            this.labelRaiseTI.AutoSize = true;
            this.labelRaiseTI.Location = new System.Drawing.Point(356, 54);
            this.labelRaiseTI.Name = "labelRaiseTI";
            this.labelRaiseTI.Size = new System.Drawing.Size(33, 13);
            this.labelRaiseTI.TabIndex = 16;
            this.labelRaiseTI.Text = "(+5%)";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(43, 19);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(74, 21);
            this.comboBoxYear.TabIndex = 11;
            this.comboBoxYear.Text = "2008";
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // labelYearChoice
            // 
            this.labelYearChoice.AutoSize = true;
            this.labelYearChoice.Location = new System.Drawing.Point(12, 22);
            this.labelYearChoice.Name = "labelYearChoice";
            this.labelYearChoice.Size = new System.Drawing.Size(25, 13);
            this.labelYearChoice.TabIndex = 12;
            this.labelYearChoice.Text = "Год";
            // 
            // labelRaisePopulation
            // 
            this.labelRaisePopulation.AutoSize = true;
            this.labelRaisePopulation.Location = new System.Drawing.Point(196, 79);
            this.labelRaisePopulation.Name = "labelRaisePopulation";
            this.labelRaisePopulation.Size = new System.Drawing.Size(33, 13);
            this.labelRaisePopulation.TabIndex = 15;
            this.labelRaisePopulation.Text = "(+5%)";
            // 
            // labelRaiseUnemployed
            // 
            this.labelRaiseUnemployed.AutoSize = true;
            this.labelRaiseUnemployed.Location = new System.Drawing.Point(215, 128);
            this.labelRaiseUnemployed.Name = "labelRaiseUnemployed";
            this.labelRaiseUnemployed.Size = new System.Drawing.Size(36, 13);
            this.labelRaiseUnemployed.TabIndex = 14;
            this.labelRaiseUnemployed.Text = "(-14%)";
            // 
            // labelRaiseBusyed
            // 
            this.labelRaiseBusyed.AutoSize = true;
            this.labelRaiseBusyed.Location = new System.Drawing.Point(197, 103);
            this.labelRaiseBusyed.Name = "labelRaiseBusyed";
            this.labelRaiseBusyed.Size = new System.Drawing.Size(36, 13);
            this.labelRaiseBusyed.TabIndex = 13;
            this.labelRaiseBusyed.Text = "(-14%)";
            // 
            // labelUnemployed
            // 
            this.labelUnemployed.AutoSize = true;
            this.labelUnemployed.Location = new System.Drawing.Point(154, 128);
            this.labelUnemployed.Name = "labelUnemployed";
            this.labelUnemployed.Size = new System.Drawing.Size(55, 13);
            this.labelUnemployed.TabIndex = 10;
            this.labelUnemployed.Text = "6 373 000";
            // 
            // labelBusyed
            // 
            this.labelBusyed.AutoSize = true;
            this.labelBusyed.Location = new System.Drawing.Point(130, 103);
            this.labelBusyed.Name = "labelBusyed";
            this.labelBusyed.Size = new System.Drawing.Size(61, 13);
            this.labelBusyed.TabIndex = 9;
            this.labelBusyed.Text = "67 343 300";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Безработное население = ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Занятое население = ";
            // 
            // labelPopulation
            // 
            this.labelPopulation.AutoSize = true;
            this.labelPopulation.Location = new System.Drawing.Point(123, 79);
            this.labelPopulation.Name = "labelPopulation";
            this.labelPopulation.Size = new System.Drawing.Size(67, 13);
            this.labelPopulation.TabIndex = 6;
            this.labelPopulation.Text = "141 956 400";
            // 
            // labelBP
            // 
            this.labelBP.AutoSize = true;
            this.labelBP.Location = new System.Drawing.Point(6, 79);
            this.labelBP.Name = "labelBP";
            this.labelBP.Size = new System.Drawing.Size(111, 13);
            this.labelBP.TabIndex = 5;
            this.labelBP.Text = "Общее население = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "рублей";
            // 
            // labelTI
            // 
            this.labelTI.AutoSize = true;
            this.labelTI.Location = new System.Drawing.Point(214, 54);
            this.labelTI.Name = "labelTI";
            this.labelTI.Size = new System.Drawing.Size(76, 13);
            this.labelTI.TabIndex = 3;
            this.labelTI.Text = "6 233 053 953";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "составил";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(117, 54);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(31, 13);
            this.labelYear.TabIndex = 1;
            this.labelYear.Text = "2009";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Налоговый доход в";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewStatsData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 253);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные по округам:";
            // 
            // dataGridViewStatsData
            // 
            this.dataGridViewStatsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatsData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FD,
            this.Population,
            this.RaisePopulation,
            this.Busyed,
            this.RaiseBusyed,
            this.Unemployed,
            this.RaiseUnemployed,
            this.TI,
            this.RaiseTI});
            this.dataGridViewStatsData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStatsData.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewStatsData.Name = "dataGridViewStatsData";
            this.dataGridViewStatsData.ReadOnly = true;
            this.dataGridViewStatsData.RowHeadersVisible = false;
            this.dataGridViewStatsData.Size = new System.Drawing.Size(676, 234);
            this.dataGridViewStatsData.TabIndex = 0;
            // 
            // FD
            // 
            this.FD.HeaderText = "ФО";
            this.FD.Name = "FD";
            this.FD.ReadOnly = true;
            this.FD.Width = 175;
            // 
            // Population
            // 
            this.Population.HeaderText = "Население";
            this.Population.Name = "Population";
            this.Population.ReadOnly = true;
            this.Population.Width = 80;
            // 
            // RaisePopulation
            // 
            this.RaisePopulation.HeaderText = "+-";
            this.RaisePopulation.Name = "RaisePopulation";
            this.RaisePopulation.ReadOnly = true;
            this.RaisePopulation.Width = 40;
            // 
            // Busyed
            // 
            this.Busyed.HeaderText = "Занятое";
            this.Busyed.Name = "Busyed";
            this.Busyed.ReadOnly = true;
            this.Busyed.Width = 80;
            // 
            // RaiseBusyed
            // 
            this.RaiseBusyed.HeaderText = "-+";
            this.RaiseBusyed.Name = "RaiseBusyed";
            this.RaiseBusyed.ReadOnly = true;
            this.RaiseBusyed.Width = 40;
            // 
            // Unemployed
            // 
            this.Unemployed.HeaderText = "Безработное";
            this.Unemployed.Name = "Unemployed";
            this.Unemployed.ReadOnly = true;
            this.Unemployed.Width = 80;
            // 
            // RaiseUnemployed
            // 
            this.RaiseUnemployed.HeaderText = "-+";
            this.RaiseUnemployed.Name = "RaiseUnemployed";
            this.RaiseUnemployed.ReadOnly = true;
            this.RaiseUnemployed.Width = 40;
            // 
            // TI
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TI.DefaultCellStyle = dataGridViewCellStyle1;
            this.TI.HeaderText = "НД";
            this.TI.Name = "TI";
            this.TI.ReadOnly = true;
            this.TI.Width = 80;
            // 
            // RaiseTI
            // 
            this.RaiseTI.HeaderText = "-+";
            this.RaiseTI.Name = "RaiseTI";
            this.RaiseTI.ReadOnly = true;
            this.RaiseTI.Width = 40;
            // 
            // tabPageSubjects
            // 
            this.tabPageSubjects.Controls.Add(this.groupBoxSubjectsParams);
            this.tabPageSubjects.Controls.Add(this.groupBox2);
            this.tabPageSubjects.Location = new System.Drawing.Point(4, 22);
            this.tabPageSubjects.Name = "tabPageSubjects";
            this.tabPageSubjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSubjects.Size = new System.Drawing.Size(1125, 259);
            this.tabPageSubjects.TabIndex = 1;
            this.tabPageSubjects.Text = "Субъекты";
            this.tabPageSubjects.UseVisualStyleBackColor = true;
            // 
            // groupBoxSubjectsParams
            // 
            this.groupBoxSubjectsParams.Controls.Add(this.comboBoxYearSubjects);
            this.groupBoxSubjectsParams.Controls.Add(this.label2);
            this.groupBoxSubjectsParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSubjectsParams.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSubjectsParams.Name = "groupBoxSubjectsParams";
            this.groupBoxSubjectsParams.Size = new System.Drawing.Size(1119, 51);
            this.groupBoxSubjectsParams.TabIndex = 15;
            this.groupBoxSubjectsParams.TabStop = false;
            this.groupBoxSubjectsParams.Text = "Параметры";
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
            // comboBoxYearSubjects
            // 
            this.comboBoxYearSubjects.FormattingEnabled = true;
            this.comboBoxYearSubjects.Location = new System.Drawing.Point(36, 19);
            this.comboBoxYearSubjects.Name = "comboBoxYearSubjects";
            this.comboBoxYearSubjects.Size = new System.Drawing.Size(74, 21);
            this.comboBoxYearSubjects.TabIndex = 13;
            this.comboBoxYearSubjects.Text = "2008";
            this.comboBoxYearSubjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxYearSubjects_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Год";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewSubjects);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1119, 253);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные по субъектам:";
            // 
            // dataGridViewSubjects
            // 
            this.dataGridViewSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubjects.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewSubjects.Location = new System.Drawing.Point(3, 55);
            this.dataGridViewSubjects.Name = "dataGridViewSubjects";
            this.dataGridViewSubjects.ReadOnly = true;
            this.dataGridViewSubjects.RowHeadersVisible = false;
            this.dataGridViewSubjects.Size = new System.Drawing.Size(1113, 195);
            this.dataGridViewSubjects.TabIndex = 0;
            // 
            // base_nalog_viewsDataSet
            // 
            this.base_nalog_viewsDataSet.DataSetName = "base_nalog_viewsDataSet";
            this.base_nalog_viewsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_stat_population_districtsBindingSource
            // 
            this.view_stat_population_districtsBindingSource.DataMember = "View_stat_population_districts";
            this.view_stat_population_districtsBindingSource.DataSource = this.base_nalog_viewsDataSet;
            // 
            // view_stat_population_districtsTableAdapter
            // 
            //this.view_stat_population_districtsTableAdapter.ClearBeforeFill = true;
            // 
            // view_stat_ti_districtsBindingSource
            // 
            this.view_stat_ti_districtsBindingSource.DataMember = "View_stat_ti_districts";
            this.view_stat_ti_districtsBindingSource.DataSource = this.base_nalog_viewsDataSet;
            // 
            // view_stat_ti_districtsTableAdapter
            // 
            this.view_stat_ti_districtsTableAdapter.ClearBeforeFill = true;
            // 
            // reportsTableAdapter
            // 
            this.reportsTableAdapter.ClearBeforeFill = true;
            // 
            // FormAnalysisDataOnMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 784);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormAnalysisDataOnMap";
            this.Text = "Карта РФ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAnalysisDataOnMap_FormClosed);
            this.Load += new System.EventHandler(this.FormAnalysisDataOnMap_Load);
            this.ResizeEnd += new System.EventHandler(this.FormAnalysisDataOnMap_ResizeEnd);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FormAnalysisDataOnMap_Layout);
            this.Resize += new System.EventHandler(this.FormAnalysisDataOnMap_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControlCommon.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxRF.ResumeLayout(false);
            this.groupBoxRF.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatsData)).EndInit();
            this.tabPageSubjects.ResumeLayout(false);
            this.groupBoxSubjectsParams.ResumeLayout(false);
            this.groupBoxSubjectsParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalog_viewsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_stat_population_districtsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_stat_ti_districtsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private Controls.MapControl mapControl;
        private base_nalog_viewsDataSet base_nalog_viewsDataSet;
        private System.Windows.Forms.BindingSource view_stat_population_districtsBindingSource;
        //private base_nalog_viewsDataSetTableAdapters.View_stat_population_districtsTableAdapter view_stat_population_districtsTableAdapter;
        private System.Windows.Forms.BindingSource view_stat_ti_districtsBindingSource;
        private base_nalog_viewsDataSetTableAdapters.View_stat_ti_districtsTableAdapter view_stat_ti_districtsTableAdapter;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource reportsBindingSource;
        private base_nalogDataSetTableAdapters.ReportsTableAdapter reportsTableAdapter;
        private System.Windows.Forms.CheckBox chHideBottomPanel;
        private System.Windows.Forms.TabControl tabControlCommon;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBoxRF;
        private System.Windows.Forms.Label labelRaiseTI;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label labelYearChoice;
        private System.Windows.Forms.Label labelRaisePopulation;
        private System.Windows.Forms.Label labelRaiseUnemployed;
        private System.Windows.Forms.Label labelRaiseBusyed;
        private System.Windows.Forms.Label labelUnemployed;
        private System.Windows.Forms.Label labelBusyed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPopulation;
        private System.Windows.Forms.Label labelBP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewStatsData;
        private System.Windows.Forms.DataGridViewTextBoxColumn FD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Population;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaisePopulation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Busyed;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaiseBusyed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unemployed;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaiseUnemployed;
        private System.Windows.Forms.DataGridViewTextBoxColumn TI;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaiseTI;
        private System.Windows.Forms.TabPage tabPageSubjects;
        private System.Windows.Forms.GroupBox groupBoxSubjectsParams;
        private System.Windows.Forms.ComboBox comboBoxYearSubjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewSubjects;

    }
}