namespace NalogUser.Forms
{
    partial class FormAnalysisData
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
            this.base_nalogDataSet = new NalogUser.base_nalogDataSet();
            this.groupBoxChoiceReport = new System.Windows.Forms.GroupBox();
            this.listBoxReports = new System.Windows.Forms.ListBox();
            this.reportviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxReportView = new System.Windows.Forms.ComboBox();
            this.comboBoxListValuesForMap = new System.Windows.Forms.ComboBox();
            this.checkBoxSetOnMap = new System.Windows.Forms.CheckBox();
            this.groupBoxAbout = new System.Windows.Forms.GroupBox();
            this.webBrowserDisription = new System.Windows.Forms.WebBrowser();
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.btView = new System.Windows.Forms.Button();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.report_viewTableAdapter = new NalogUser.base_nalogDataSetTableAdapters.Report_viewTableAdapter();
            this.reportsTableAdapter = new NalogUser.base_nalogDataSetTableAdapters.ReportsTableAdapter();
            this.groupBoxVisualization = new System.Windows.Forms.GroupBox();
            this.buttonSpreading = new System.Windows.Forms.Button();
            this.checkBoxSpreading = new System.Windows.Forms.CheckBox();
            this.reportviewReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.groupBoxChoiceReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportviewBindingSource)).BeginInit();
            this.groupBoxAbout.SuspendLayout();
            this.groupBoxVisualization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportviewReportsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBoxChoiceReport
            // 
            this.groupBoxChoiceReport.Controls.Add(this.listBoxReports);
            this.groupBoxChoiceReport.Controls.Add(this.comboBoxReportView);
            this.groupBoxChoiceReport.Location = new System.Drawing.Point(12, 12);
            this.groupBoxChoiceReport.Name = "groupBoxChoiceReport";
            this.groupBoxChoiceReport.Size = new System.Drawing.Size(399, 200);
            this.groupBoxChoiceReport.TabIndex = 10;
            this.groupBoxChoiceReport.TabStop = false;
            this.groupBoxChoiceReport.Text = "Отчеты";
            // 
            // listBoxReports
            // 
            this.listBoxReports.DataSource = this.reportviewReportsBindingSource;
            this.listBoxReports.DisplayMember = "name";
            this.listBoxReports.FormattingEnabled = true;
            this.listBoxReports.Location = new System.Drawing.Point(0, 42);
            this.listBoxReports.Name = "listBoxReports";
            this.listBoxReports.Size = new System.Drawing.Size(393, 147);
            this.listBoxReports.TabIndex = 0;
            this.listBoxReports.ValueMember = "id";
            this.listBoxReports.SelectedIndexChanged += new System.EventHandler(this.listBoxReports_SelectedIndexChanged);
            // 
            // reportviewBindingSource
            // 
            this.reportviewBindingSource.DataMember = "Report_view";
            this.reportviewBindingSource.DataSource = this.base_nalogDataSet;
            // 
            // comboBoxReportView
            // 
            this.comboBoxReportView.DataSource = this.reportviewBindingSource;
            this.comboBoxReportView.DisplayMember = "name";
            this.comboBoxReportView.FormattingEnabled = true;
            this.comboBoxReportView.Location = new System.Drawing.Point(6, 19);
            this.comboBoxReportView.Name = "comboBoxReportView";
            this.comboBoxReportView.Size = new System.Drawing.Size(101, 21);
            this.comboBoxReportView.TabIndex = 5;
            this.comboBoxReportView.ValueMember = "id";
            this.comboBoxReportView.SelectedIndexChanged += new System.EventHandler(this.comboBoxReportView_SelectedIndexChanged);
            // 
            // comboBoxListValuesForMap
            // 
            this.comboBoxListValuesForMap.FormattingEnabled = true;
            this.comboBoxListValuesForMap.Location = new System.Drawing.Point(153, 17);
            this.comboBoxListValuesForMap.Name = "comboBoxListValuesForMap";
            this.comboBoxListValuesForMap.Size = new System.Drawing.Size(173, 21);
            this.comboBoxListValuesForMap.TabIndex = 7;
            this.comboBoxListValuesForMap.SelectedIndexChanged += new System.EventHandler(this.comboBoxListValuesForMap_SelectedIndexChanged);
            // 
            // checkBoxSetOnMap
            // 
            this.checkBoxSetOnMap.AutoSize = true;
            this.checkBoxSetOnMap.Location = new System.Drawing.Point(6, 19);
            this.checkBoxSetOnMap.Name = "checkBoxSetOnMap";
            this.checkBoxSetOnMap.Size = new System.Drawing.Size(144, 17);
            this.checkBoxSetOnMap.TabIndex = 6;
            this.checkBoxSetOnMap.Text = "Наложить на карту РФ";
            this.checkBoxSetOnMap.UseVisualStyleBackColor = true;
            this.checkBoxSetOnMap.CheckedChanged += new System.EventHandler(this.checkBoxSetOnMap_CheckedChanged);
            // 
            // groupBoxAbout
            // 
            this.groupBoxAbout.Controls.Add(this.webBrowserDisription);
            this.groupBoxAbout.Location = new System.Drawing.Point(417, 12);
            this.groupBoxAbout.Name = "groupBoxAbout";
            this.groupBoxAbout.Size = new System.Drawing.Size(302, 330);
            this.groupBoxAbout.TabIndex = 8;
            this.groupBoxAbout.TabStop = false;
            this.groupBoxAbout.Text = "Описание";
            // 
            // webBrowserDisription
            // 
            this.webBrowserDisription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserDisription.Location = new System.Drawing.Point(3, 16);
            this.webBrowserDisription.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserDisription.Name = "webBrowserDisription";
            this.webBrowserDisription.Size = new System.Drawing.Size(296, 311);
            this.webBrowserDisription.TabIndex = 0;
            // 
            // groupBoxParams
            // 
            this.groupBoxParams.Location = new System.Drawing.Point(12, 308);
            this.groupBoxParams.Name = "groupBoxParams";
            this.groupBoxParams.Padding = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.groupBoxParams.Size = new System.Drawing.Size(393, 184);
            this.groupBoxParams.TabIndex = 7;
            this.groupBoxParams.TabStop = false;
            this.groupBoxParams.Text = "Параметры";
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(606, 391);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(110, 23);
            this.btView.TabIndex = 9;
            this.btView.Text = "Показать";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(417, 348);
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(302, 20);
            this.textBoxError.TabIndex = 11;
            // 
            // report_viewTableAdapter
            // 
            this.report_viewTableAdapter.ClearBeforeFill = true;
            // 
            // reportsTableAdapter
            // 
            this.reportsTableAdapter.ClearBeforeFill = true;
            // 
            // groupBoxVisualization
            // 
            this.groupBoxVisualization.Controls.Add(this.buttonSpreading);
            this.groupBoxVisualization.Controls.Add(this.checkBoxSpreading);
            this.groupBoxVisualization.Controls.Add(this.comboBoxListValuesForMap);
            this.groupBoxVisualization.Controls.Add(this.checkBoxSetOnMap);
            this.groupBoxVisualization.Location = new System.Drawing.Point(12, 218);
            this.groupBoxVisualization.Name = "groupBoxVisualization";
            this.groupBoxVisualization.Size = new System.Drawing.Size(393, 84);
            this.groupBoxVisualization.TabIndex = 12;
            this.groupBoxVisualization.TabStop = false;
            this.groupBoxVisualization.Text = "Визуализация";
            // 
            // buttonSpreading
            // 
            this.buttonSpreading.Enabled = false;
            this.buttonSpreading.Location = new System.Drawing.Point(153, 45);
            this.buttonSpreading.Name = "buttonSpreading";
            this.buttonSpreading.Size = new System.Drawing.Size(173, 23);
            this.buttonSpreading.TabIndex = 9;
            this.buttonSpreading.Text = "Праметры распределения";
            this.buttonSpreading.UseVisualStyleBackColor = true;
            this.buttonSpreading.Click += new System.EventHandler(this.buttonSpreading_Click);
            // 
            // checkBoxSpreading
            // 
            this.checkBoxSpreading.AutoSize = true;
            this.checkBoxSpreading.Location = new System.Drawing.Point(6, 49);
            this.checkBoxSpreading.Name = "checkBoxSpreading";
            this.checkBoxSpreading.Size = new System.Drawing.Size(105, 17);
            this.checkBoxSpreading.TabIndex = 8;
            this.checkBoxSpreading.Text = "Распределение";
            this.checkBoxSpreading.UseVisualStyleBackColor = true;
            this.checkBoxSpreading.CheckedChanged += new System.EventHandler(this.checkBoxSpreading_CheckedChanged);
            // 
            // reportviewReportsBindingSource
            // 
            this.reportviewReportsBindingSource.DataMember = "Report_view_Reports";
            this.reportviewReportsBindingSource.DataSource = this.reportviewBindingSource;
            // 
            // FormAnalysisData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 500);
            this.Controls.Add(this.groupBoxVisualization);
            this.Controls.Add(this.textBoxError);
            this.Controls.Add(this.groupBoxChoiceReport);
            this.Controls.Add(this.groupBoxAbout);
            this.Controls.Add(this.groupBoxParams);
            this.Controls.Add(this.btView);
            this.MinimumSize = new System.Drawing.Size(690, 450);
            this.Name = "FormAnalysisData";
            this.Text = "FormAnalysisData";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAnalysisData_FormClosed);
            this.Load += new System.EventHandler(this.FormAnalysisData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.groupBoxChoiceReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportviewBindingSource)).EndInit();
            this.groupBoxAbout.ResumeLayout(false);
            this.groupBoxVisualization.ResumeLayout(false);
            this.groupBoxVisualization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportviewReportsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private base_nalogDataSet base_nalogDataSet;
        public Microsoft.Reporting.WinForms.ReportDataSource reportDataSource;
        private base_nalogDataSetTableAdapters.TaxesTableAdapter taxesTableAdapter;
        private System.Windows.Forms.GroupBox groupBoxChoiceReport;
        public System.Windows.Forms.ListBox listBoxReports;
        private System.Windows.Forms.GroupBox groupBoxAbout;
        private System.Windows.Forms.GroupBox groupBoxParams;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.TextBox textBoxError;
        public System.Windows.Forms.ComboBox comboBoxReportView;
        private System.Windows.Forms.CheckBox checkBoxSetOnMap;
        private System.Windows.Forms.WebBrowser webBrowserDisription;
        private System.Windows.Forms.ComboBox comboBoxListValuesForMap;
        private System.Windows.Forms.BindingSource reportviewBindingSource;
        private base_nalogDataSetTableAdapters.Report_viewTableAdapter report_viewTableAdapter;
        private base_nalogDataSetTableAdapters.ReportsTableAdapter reportsTableAdapter;
        private System.Windows.Forms.GroupBox groupBoxVisualization;
        private System.Windows.Forms.Button buttonSpreading;
        private System.Windows.Forms.CheckBox checkBoxSpreading;
        private System.Windows.Forms.BindingSource reportviewReportsBindingSource;

    }
}