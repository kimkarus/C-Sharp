namespace NalogAdministrator.Forms
{
    partial class FormCreaterModel
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
            this.groupBoxAdvParams = new System.Windows.Forms.GroupBox();
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCountIntervals = new System.Windows.Forms.TextBox();
            this.btCreateModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectTypeModel = new System.Windows.Forms.ComboBox();
            this.groupBoxTypeModel = new System.Windows.Forms.GroupBox();
            this.comboBoxTypeModel = new System.Windows.Forms.ComboBox();
            this.modeltypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.buttonChooseTheBest = new System.Windows.Forms.Button();
            this.buttonCorrelation = new System.Windows.Forms.Button();
            this.textBoxForecastPeriod = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCorrelationTaxIndexes = new System.Windows.Forms.Button();
            this.buttonCorrelationTaxBudgetIndexes = new System.Windows.Forms.Button();
            this.buttonCorrelationEeaBudgetIndexes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabTaxes = new System.Windows.Forms.TabControl();
            this.tabPageTaxes = new System.Windows.Forms.TabPage();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.groupBoxCorrelationParams = new System.Windows.Forms.GroupBox();
            this.checkBoxCleanCorrelation = new System.Windows.Forms.CheckBox();
            this.checkBoxTakeCorrelationAgain = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes = new System.Windows.Forms.CheckBox();
            this.checkBoxCleanModels = new System.Windows.Forms.CheckBox();
            this.buttonThreeInOne = new System.Windows.Forms.Button();
            this.buttonFunctions = new System.Windows.Forms.Button();
            this.buttonFilterFactors = new System.Windows.Forms.Button();
            this.checkBoxCleanBeforeFill = new System.Windows.Forms.CheckBox();
            this.buttonCollect = new System.Windows.Forms.Button();
            this.buttonCorrelValues = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBoxSearching = new System.Windows.Forms.TabPage();
            this.groupBoxParams.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxTypeModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modeltypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabTaxes.SuspendLayout();
            this.tabPageTaxes.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.groupBoxCorrelationParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAdvParams
            // 
            this.groupBoxAdvParams.Location = new System.Drawing.Point(0, 177);
            this.groupBoxAdvParams.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxAdvParams.Name = "groupBoxAdvParams";
            this.groupBoxAdvParams.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxAdvParams.Size = new System.Drawing.Size(398, 238);
            this.groupBoxAdvParams.TabIndex = 0;
            this.groupBoxAdvParams.TabStop = false;
            this.groupBoxAdvParams.Text = "Параметры";
            // 
            // groupBoxParams
            // 
            this.groupBoxParams.Controls.Add(this.label1);
            this.groupBoxParams.Controls.Add(this.textBoxCountIntervals);
            this.groupBoxParams.Location = new System.Drawing.Point(5, 5);
            this.groupBoxParams.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxParams.Name = "groupBoxParams";
            this.groupBoxParams.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxParams.Size = new System.Drawing.Size(220, 57);
            this.groupBoxParams.TabIndex = 1;
            this.groupBoxParams.TabStop = false;
            this.groupBoxParams.Text = "Основные";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество интервалов";
            // 
            // textBoxCountIntervals
            // 
            this.textBoxCountIntervals.Location = new System.Drawing.Point(134, 24);
            this.textBoxCountIntervals.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCountIntervals.Name = "textBoxCountIntervals";
            this.textBoxCountIntervals.Size = new System.Drawing.Size(76, 20);
            this.textBoxCountIntervals.TabIndex = 0;
            this.textBoxCountIntervals.Text = "3";
            // 
            // btCreateModel
            // 
            this.btCreateModel.Location = new System.Drawing.Point(328, 419);
            this.btCreateModel.Margin = new System.Windows.Forms.Padding(2);
            this.btCreateModel.Name = "btCreateModel";
            this.btCreateModel.Size = new System.Drawing.Size(73, 30);
            this.btCreateModel.TabIndex = 2;
            this.btCreateModel.Text = "Построить";
            this.btCreateModel.UseVisualStyleBackColor = true;
            this.btCreateModel.Click += new System.EventHandler(this.btCreateModel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxSelectTypeModel);
            this.groupBox1.Location = new System.Drawing.Point(5, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 49);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Построить для:";
            // 
            // comboBoxSelectTypeModel
            // 
            this.comboBoxSelectTypeModel.FormattingEnabled = true;
            this.comboBoxSelectTypeModel.Location = new System.Drawing.Point(11, 17);
            this.comboBoxSelectTypeModel.Name = "comboBoxSelectTypeModel";
            this.comboBoxSelectTypeModel.Size = new System.Drawing.Size(376, 21);
            this.comboBoxSelectTypeModel.TabIndex = 0;
            // 
            // groupBoxTypeModel
            // 
            this.groupBoxTypeModel.Controls.Add(this.comboBoxTypeModel);
            this.groupBoxTypeModel.Location = new System.Drawing.Point(5, 122);
            this.groupBoxTypeModel.Name = "groupBoxTypeModel";
            this.groupBoxTypeModel.Size = new System.Drawing.Size(393, 50);
            this.groupBoxTypeModel.TabIndex = 4;
            this.groupBoxTypeModel.TabStop = false;
            this.groupBoxTypeModel.Text = "Тип модели";
            // 
            // comboBoxTypeModel
            // 
            this.comboBoxTypeModel.DataSource = this.modeltypeBindingSource;
            this.comboBoxTypeModel.DisplayMember = "name";
            this.comboBoxTypeModel.FormattingEnabled = true;
            this.comboBoxTypeModel.Location = new System.Drawing.Point(7, 19);
            this.comboBoxTypeModel.Name = "comboBoxTypeModel";
            this.comboBoxTypeModel.Size = new System.Drawing.Size(380, 21);
            this.comboBoxTypeModel.TabIndex = 0;
            this.comboBoxTypeModel.ValueMember = "id";
            // 
            // modeltypeBindingSource
            // 
            this.modeltypeBindingSource.DataMember = "Model_type";
            this.modeltypeBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonChooseTheBest
            // 
            this.buttonChooseTheBest.Location = new System.Drawing.Point(116, 420);
            this.buttonChooseTheBest.Name = "buttonChooseTheBest";
            this.buttonChooseTheBest.Size = new System.Drawing.Size(207, 29);
            this.buttonChooseTheBest.TabIndex = 5;
            this.buttonChooseTheBest.Text = "Подобрать лучшие модели";
            this.buttonChooseTheBest.UseVisualStyleBackColor = true;
            this.buttonChooseTheBest.Click += new System.EventHandler(this.buttonChooseTheBest_Click);
            // 
            // buttonCorrelation
            // 
            this.buttonCorrelation.Location = new System.Drawing.Point(6, 19);
            this.buttonCorrelation.Name = "buttonCorrelation";
            this.buttonCorrelation.Size = new System.Drawing.Size(188, 29);
            this.buttonCorrelation.TabIndex = 6;
            this.buttonCorrelation.Text = "Виды налогов и ВЭД";
            this.buttonCorrelation.UseVisualStyleBackColor = true;
            this.buttonCorrelation.Click += new System.EventHandler(this.buttonCorrelation_Click);
            // 
            // textBoxForecastPeriod
            // 
            this.textBoxForecastPeriod.Location = new System.Drawing.Point(162, 464);
            this.textBoxForecastPeriod.Name = "textBoxForecastPeriod";
            this.textBoxForecastPeriod.Size = new System.Drawing.Size(110, 20);
            this.textBoxForecastPeriod.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сделать прогноз";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Периодов";
            // 
            // buttonCorrelationTaxIndexes
            // 
            this.buttonCorrelationTaxIndexes.Location = new System.Drawing.Point(6, 54);
            this.buttonCorrelationTaxIndexes.Name = "buttonCorrelationTaxIndexes";
            this.buttonCorrelationTaxIndexes.Size = new System.Drawing.Size(188, 29);
            this.buttonCorrelationTaxIndexes.TabIndex = 10;
            this.buttonCorrelationTaxIndexes.Text = "Налоги, соц-эко";
            this.buttonCorrelationTaxIndexes.UseVisualStyleBackColor = true;
            this.buttonCorrelationTaxIndexes.Click += new System.EventHandler(this.buttonCorrelationTaxIndexes_Click);
            // 
            // buttonCorrelationTaxBudgetIndexes
            // 
            this.buttonCorrelationTaxBudgetIndexes.Location = new System.Drawing.Point(6, 89);
            this.buttonCorrelationTaxBudgetIndexes.Name = "buttonCorrelationTaxBudgetIndexes";
            this.buttonCorrelationTaxBudgetIndexes.Size = new System.Drawing.Size(188, 29);
            this.buttonCorrelationTaxBudgetIndexes.TabIndex = 11;
            this.buttonCorrelationTaxBudgetIndexes.Text = "Бюджеты, налоги, соц-эко";
            this.buttonCorrelationTaxBudgetIndexes.UseVisualStyleBackColor = true;
            this.buttonCorrelationTaxBudgetIndexes.Click += new System.EventHandler(this.buttonCorrelationTaxBudgetIndexes_Click);
            // 
            // buttonCorrelationEeaBudgetIndexes
            // 
            this.buttonCorrelationEeaBudgetIndexes.Location = new System.Drawing.Point(6, 124);
            this.buttonCorrelationEeaBudgetIndexes.Name = "buttonCorrelationEeaBudgetIndexes";
            this.buttonCorrelationEeaBudgetIndexes.Size = new System.Drawing.Size(188, 29);
            this.buttonCorrelationEeaBudgetIndexes.TabIndex = 12;
            this.buttonCorrelationEeaBudgetIndexes.Text = "Виды бюджетов и ВЭД";
            this.buttonCorrelationEeaBudgetIndexes.UseVisualStyleBackColor = true;
            this.buttonCorrelationEeaBudgetIndexes.Click += new System.EventHandler(this.buttonCorrelationEeaBudgetIndexes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.buttonCorrelation);
            this.groupBox2.Controls.Add(this.buttonCorrelationTaxIndexes);
            this.groupBox2.Controls.Add(this.buttonCorrelationEeaBudgetIndexes);
            this.groupBox2.Controls.Add(this.buttonCorrelationTaxBudgetIndexes);
            this.groupBox2.Location = new System.Drawing.Point(403, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 408);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Корреляции";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(32, 293);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 49);
            this.button4.TabIndex = 16;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 29);
            this.button3.TabIndex = 15;
            this.button3.Text = "Бюджеты, соц.-эко.";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "Бюджеты, налоги, коэфф.";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(230, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 52);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Кол. факторов";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(63, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Много";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Один";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabTaxes
            // 
            this.tabTaxes.Controls.Add(this.tabPageTaxes);
            this.tabTaxes.Controls.Add(this.tabPageCommon);
            this.tabTaxes.Controls.Add(this.groupBoxSearching);
            this.tabTaxes.Location = new System.Drawing.Point(12, 12);
            this.tabTaxes.Name = "tabTaxes";
            this.tabTaxes.SelectedIndex = 0;
            this.tabTaxes.Size = new System.Drawing.Size(666, 526);
            this.tabTaxes.TabIndex = 0;
            // 
            // tabPageTaxes
            // 
            this.tabPageTaxes.Controls.Add(this.groupBoxParams);
            this.tabPageTaxes.Controls.Add(this.groupBox3);
            this.tabPageTaxes.Controls.Add(this.groupBoxAdvParams);
            this.tabPageTaxes.Controls.Add(this.groupBox2);
            this.tabPageTaxes.Controls.Add(this.btCreateModel);
            this.tabPageTaxes.Controls.Add(this.label2);
            this.tabPageTaxes.Controls.Add(this.groupBox1);
            this.tabPageTaxes.Controls.Add(this.button1);
            this.tabPageTaxes.Controls.Add(this.groupBoxTypeModel);
            this.tabPageTaxes.Controls.Add(this.textBoxForecastPeriod);
            this.tabPageTaxes.Controls.Add(this.buttonChooseTheBest);
            this.tabPageTaxes.Location = new System.Drawing.Point(4, 22);
            this.tabPageTaxes.Name = "tabPageTaxes";
            this.tabPageTaxes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTaxes.Size = new System.Drawing.Size(658, 500);
            this.tabPageTaxes.TabIndex = 0;
            this.tabPageTaxes.Text = "Налоги";
            this.tabPageTaxes.UseVisualStyleBackColor = true;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.groupBoxCorrelationParams);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(658, 500);
            this.tabPageCommon.TabIndex = 1;
            this.tabPageCommon.Text = "Общее";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // groupBoxCorrelationParams
            // 
            this.groupBoxCorrelationParams.Controls.Add(this.checkBoxCleanCorrelation);
            this.groupBoxCorrelationParams.Controls.Add(this.checkBoxTakeCorrelationAgain);
            this.groupBoxCorrelationParams.Controls.Add(this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes);
            this.groupBoxCorrelationParams.Controls.Add(this.checkBoxCleanModels);
            this.groupBoxCorrelationParams.Controls.Add(this.buttonThreeInOne);
            this.groupBoxCorrelationParams.Controls.Add(this.buttonFunctions);
            this.groupBoxCorrelationParams.Controls.Add(this.buttonFilterFactors);
            this.groupBoxCorrelationParams.Controls.Add(this.checkBoxCleanBeforeFill);
            this.groupBoxCorrelationParams.Controls.Add(this.buttonCollect);
            this.groupBoxCorrelationParams.Controls.Add(this.buttonCorrelValues);
            this.groupBoxCorrelationParams.Controls.Add(this.label4);
            this.groupBoxCorrelationParams.Controls.Add(this.label3);
            this.groupBoxCorrelationParams.Controls.Add(this.textBox2);
            this.groupBoxCorrelationParams.Controls.Add(this.textBox1);
            this.groupBoxCorrelationParams.Controls.Add(this.checkedListBox1);
            this.groupBoxCorrelationParams.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCorrelationParams.Name = "groupBoxCorrelationParams";
            this.groupBoxCorrelationParams.Size = new System.Drawing.Size(634, 488);
            this.groupBoxCorrelationParams.TabIndex = 0;
            this.groupBoxCorrelationParams.TabStop = false;
            this.groupBoxCorrelationParams.Text = "Параметры корреляции";
            // 
            // checkBoxCleanCorrelation
            // 
            this.checkBoxCleanCorrelation.AutoSize = true;
            this.checkBoxCleanCorrelation.Location = new System.Drawing.Point(265, 302);
            this.checkBoxCleanCorrelation.Name = "checkBoxCleanCorrelation";
            this.checkBoxCleanCorrelation.Size = new System.Drawing.Size(136, 17);
            this.checkBoxCleanCorrelation.TabIndex = 15;
            this.checkBoxCleanCorrelation.Text = "Очистить корреляции";
            this.checkBoxCleanCorrelation.UseVisualStyleBackColor = true;
            // 
            // checkBoxTakeCorrelationAgain
            // 
            this.checkBoxTakeCorrelationAgain.AutoSize = true;
            this.checkBoxTakeCorrelationAgain.Location = new System.Drawing.Point(74, 302);
            this.checkBoxTakeCorrelationAgain.Name = "checkBoxTakeCorrelationAgain";
            this.checkBoxTakeCorrelationAgain.Size = new System.Drawing.Size(185, 17);
            this.checkBoxTakeCorrelationAgain.TabIndex = 13;
            this.checkBoxTakeCorrelationAgain.Text = "Сделать все корреляции снова";
            this.checkBoxTakeCorrelationAgain.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes
            // 
            this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.AutoSize = true;
            this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.Location = new System.Drawing.Point(74, 279);
            this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.Name = "checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes";
            this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.Size = new System.Drawing.Size(235, 17);
            this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.TabIndex = 12;
            this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.Text = "Удалить все модели: налог, бюджет, сэп";
            this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.UseVisualStyleBackColor = true;
            // 
            // checkBoxCleanModels
            // 
            this.checkBoxCleanModels.AutoSize = true;
            this.checkBoxCleanModels.Checked = true;
            this.checkBoxCleanModels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCleanModels.Location = new System.Drawing.Point(74, 256);
            this.checkBoxCleanModels.Name = "checkBoxCleanModels";
            this.checkBoxCleanModels.Size = new System.Drawing.Size(398, 17);
            this.checkBoxCleanModels.TabIndex = 11;
            this.checkBoxCleanModels.Text = "Очищать перед заполнением модели (удалить несуществующие ссылки)";
            this.checkBoxCleanModels.UseVisualStyleBackColor = true;
            // 
            // buttonThreeInOne
            // 
            this.buttonThreeInOne.Location = new System.Drawing.Point(201, 346);
            this.buttonThreeInOne.Name = "buttonThreeInOne";
            this.buttonThreeInOne.Size = new System.Drawing.Size(87, 81);
            this.buttonThreeInOne.TabIndex = 10;
            this.buttonThreeInOne.Text = "4 в 1";
            this.buttonThreeInOne.UseVisualStyleBackColor = true;
            this.buttonThreeInOne.Click += new System.EventHandler(this.buttonThreeInOne_Click);
            // 
            // buttonFunctions
            // 
            this.buttonFunctions.Location = new System.Drawing.Point(120, 404);
            this.buttonFunctions.Name = "buttonFunctions";
            this.buttonFunctions.Size = new System.Drawing.Size(75, 23);
            this.buttonFunctions.TabIndex = 9;
            this.buttonFunctions.Text = "Уравнения";
            this.buttonFunctions.UseVisualStyleBackColor = true;
            this.buttonFunctions.Click += new System.EventHandler(this.buttonFunctions_Click);
            // 
            // buttonFilterFactors
            // 
            this.buttonFilterFactors.Location = new System.Drawing.Point(120, 375);
            this.buttonFilterFactors.Name = "buttonFilterFactors";
            this.buttonFilterFactors.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterFactors.TabIndex = 8;
            this.buttonFilterFactors.Text = "Отбор";
            this.buttonFilterFactors.UseVisualStyleBackColor = true;
            this.buttonFilterFactors.Click += new System.EventHandler(this.buttonFilterFactors_Click);
            // 
            // checkBoxCleanBeforeFill
            // 
            this.checkBoxCleanBeforeFill.AutoSize = true;
            this.checkBoxCleanBeforeFill.Checked = true;
            this.checkBoxCleanBeforeFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCleanBeforeFill.Location = new System.Drawing.Point(74, 233);
            this.checkBoxCleanBeforeFill.Name = "checkBoxCleanBeforeFill";
            this.checkBoxCleanBeforeFill.Size = new System.Drawing.Size(175, 17);
            this.checkBoxCleanBeforeFill.TabIndex = 7;
            this.checkBoxCleanBeforeFill.Text = "Очищать перед заполнением";
            this.checkBoxCleanBeforeFill.UseVisualStyleBackColor = true;
            // 
            // buttonCollect
            // 
            this.buttonCollect.Location = new System.Drawing.Point(120, 346);
            this.buttonCollect.Name = "buttonCollect";
            this.buttonCollect.Size = new System.Drawing.Size(75, 23);
            this.buttonCollect.TabIndex = 6;
            this.buttonCollect.Text = "Объеденить";
            this.buttonCollect.UseVisualStyleBackColor = true;
            this.buttonCollect.Click += new System.EventHandler(this.buttonCollect_Click);
            // 
            // buttonCorrelValues
            // 
            this.buttonCorrelValues.Location = new System.Drawing.Point(123, 204);
            this.buttonCorrelValues.Name = "buttonCorrelValues";
            this.buttonCorrelValues.Size = new System.Drawing.Size(75, 23);
            this.buttonCorrelValues.TabIndex = 5;
            this.buttonCorrelValues.Text = "button3";
            this.buttonCorrelValues.UseVisualStyleBackColor = true;
            this.buttonCorrelValues.Click += new System.EventHandler(this.buttonCorrelValues_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Код налога";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Код субъекта";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(91, 158);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "index",
            "eea",
            "tax",
            "eea_gks",
            "coeff"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(98, 79);
            this.checkedListBox1.TabIndex = 0;
            // 
            // groupBoxSearching
            // 
            this.groupBoxSearching.Location = new System.Drawing.Point(4, 22);
            this.groupBoxSearching.Name = "groupBoxSearching";
            this.groupBoxSearching.Padding = new System.Windows.Forms.Padding(3);
            this.groupBoxSearching.Size = new System.Drawing.Size(658, 500);
            this.groupBoxSearching.TabIndex = 2;
            this.groupBoxSearching.Text = "Поиск решений";
            this.groupBoxSearching.UseVisualStyleBackColor = true;
            // 
            // FormCreaterModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 550);
            this.Controls.Add(this.tabTaxes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCreaterModel";
            this.Text = "FormCreaterModel";
            this.Load += new System.EventHandler(this.FormCreaterModel_Load);
            this.groupBoxParams.ResumeLayout(false);
            this.groupBoxParams.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxTypeModel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modeltypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabTaxes.ResumeLayout(false);
            this.tabPageTaxes.ResumeLayout(false);
            this.tabPageTaxes.PerformLayout();
            this.tabPageCommon.ResumeLayout(false);
            this.groupBoxCorrelationParams.ResumeLayout(false);
            this.groupBoxCorrelationParams.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAdvParams;
        private System.Windows.Forms.GroupBox groupBoxParams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCountIntervals;
        private System.Windows.Forms.Button btCreateModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxSelectTypeModel;
        private System.Windows.Forms.GroupBox groupBoxTypeModel;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource modeltypeBindingSource;
        private base_nalogDataSetTableAdapters.Model_typeTableAdapter model_typeTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxTypeModel;
        private System.Windows.Forms.Button buttonChooseTheBest;
        private System.Windows.Forms.Button buttonCorrelation;
        private System.Windows.Forms.TextBox textBoxForecastPeriod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCorrelationTaxIndexes;
        private System.Windows.Forms.Button buttonCorrelationTaxBudgetIndexes;
        private System.Windows.Forms.Button buttonCorrelationEeaBudgetIndexes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabControl tabTaxes;
        private System.Windows.Forms.TabPage tabPageTaxes;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.GroupBox groupBoxCorrelationParams;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonCorrelValues;
        private System.Windows.Forms.Button buttonCollect;
        private System.Windows.Forms.CheckBox checkBoxCleanBeforeFill;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonFilterFactors;
        private System.Windows.Forms.Button buttonFunctions;
        private System.Windows.Forms.Button buttonThreeInOne;
        private System.Windows.Forms.CheckBox checkBoxCleanModels;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes;
        private System.Windows.Forms.CheckBox checkBoxTakeCorrelationAgain;
        private System.Windows.Forms.CheckBox checkBoxCleanCorrelation;
        private System.Windows.Forms.TabPage groupBoxSearching;
    }
}