namespace NalogAdministrator.Forms
{
    partial class FormDataAggregation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxAgregationParam = new System.Windows.Forms.GroupBox();
            this.checkBoxPrefix = new System.Windows.Forms.CheckBox();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.checkBoxFilterSubject = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterYears = new System.Windows.Forms.CheckBox();
            this.comboBoxSubjects = new System.Windows.Forms.ComboBox();
            this.subjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.base_nalogDataSet = new NalogAdministrator.base_nalogDataSet();
            this.textBoxYearAfter = new System.Windows.Forms.TextBox();
            this.textBoxYearBefore = new System.Windows.Forms.TextBox();
            this.checkBoxMergeTable = new System.Windows.Forms.CheckBox();
            this.btStartAgregation = new System.Windows.Forms.Button();
            this.comboBoxSelectTypeAgregation = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chSetAll = new System.Windows.Forms.CheckBox();
            this.chkListBoxAgregationParam = new System.Windows.Forms.CheckedListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarAgregation = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelStep = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.subjectsTableAdapter = new NalogAdministrator.base_nalogDataSetTableAdapters.SubjectsTableAdapter();
            this.panel1.SuspendLayout();
            this.groupBoxAgregationParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxAgregationParam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 100);
            this.panel1.TabIndex = 0;
            // 
            // groupBoxAgregationParam
            // 
            this.groupBoxAgregationParam.Controls.Add(this.checkBoxPrefix);
            this.groupBoxAgregationParam.Controls.Add(this.textBoxPrefix);
            this.groupBoxAgregationParam.Controls.Add(this.checkBoxFilterSubject);
            this.groupBoxAgregationParam.Controls.Add(this.checkBoxFilterYears);
            this.groupBoxAgregationParam.Controls.Add(this.comboBoxSubjects);
            this.groupBoxAgregationParam.Controls.Add(this.textBoxYearAfter);
            this.groupBoxAgregationParam.Controls.Add(this.textBoxYearBefore);
            this.groupBoxAgregationParam.Controls.Add(this.checkBoxMergeTable);
            this.groupBoxAgregationParam.Controls.Add(this.btStartAgregation);
            this.groupBoxAgregationParam.Controls.Add(this.comboBoxSelectTypeAgregation);
            this.groupBoxAgregationParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAgregationParam.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAgregationParam.Name = "groupBoxAgregationParam";
            this.groupBoxAgregationParam.Size = new System.Drawing.Size(695, 100);
            this.groupBoxAgregationParam.TabIndex = 0;
            this.groupBoxAgregationParam.TabStop = false;
            this.groupBoxAgregationParam.Text = "Параметры агрегации данных";
            // 
            // checkBoxPrefix
            // 
            this.checkBoxPrefix.AutoSize = true;
            this.checkBoxPrefix.Location = new System.Drawing.Point(481, 47);
            this.checkBoxPrefix.Name = "checkBoxPrefix";
            this.checkBoxPrefix.Size = new System.Drawing.Size(57, 17);
            this.checkBoxPrefix.TabIndex = 9;
            this.checkBoxPrefix.Text = "Преф.";
            this.checkBoxPrefix.UseVisualStyleBackColor = true;
            this.checkBoxPrefix.CheckedChanged += new System.EventHandler(this.checkBoxPrefix_CheckedChanged);
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Enabled = false;
            this.textBoxPrefix.Location = new System.Drawing.Point(544, 46);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrefix.TabIndex = 8;
            this.textBoxPrefix.Text = "[tax-177_nalog]";
            // 
            // checkBoxFilterSubject
            // 
            this.checkBoxFilterSubject.AutoSize = true;
            this.checkBoxFilterSubject.Location = new System.Drawing.Point(252, 77);
            this.checkBoxFilterSubject.Name = "checkBoxFilterSubject";
            this.checkBoxFilterSubject.Size = new System.Drawing.Size(104, 17);
            this.checkBoxFilterSubject.TabIndex = 7;
            this.checkBoxFilterSubject.Text = "Отбор, субъект";
            this.checkBoxFilterSubject.UseVisualStyleBackColor = true;
            this.checkBoxFilterSubject.CheckedChanged += new System.EventHandler(this.checkBoxFilterSubject_CheckedChanged);
            // 
            // checkBoxFilterYears
            // 
            this.checkBoxFilterYears.AutoSize = true;
            this.checkBoxFilterYears.Location = new System.Drawing.Point(252, 49);
            this.checkBoxFilterYears.Name = "checkBoxFilterYears";
            this.checkBoxFilterYears.Size = new System.Drawing.Size(88, 17);
            this.checkBoxFilterYears.TabIndex = 6;
            this.checkBoxFilterYears.Text = "Отбор, годы";
            this.checkBoxFilterYears.UseVisualStyleBackColor = true;
            this.checkBoxFilterYears.CheckedChanged += new System.EventHandler(this.checkBoxFilterYears_CheckedChanged);
            // 
            // comboBoxSubjects
            // 
            this.comboBoxSubjects.DataSource = this.subjectsBindingSource;
            this.comboBoxSubjects.DisplayMember = "subject_name";
            this.comboBoxSubjects.Enabled = false;
            this.comboBoxSubjects.FormattingEnabled = true;
            this.comboBoxSubjects.Location = new System.Drawing.Point(365, 73);
            this.comboBoxSubjects.Name = "comboBoxSubjects";
            this.comboBoxSubjects.Size = new System.Drawing.Size(279, 21);
            this.comboBoxSubjects.TabIndex = 5;
            this.comboBoxSubjects.ValueMember = "id";
            // 
            // subjectsBindingSource
            // 
            this.subjectsBindingSource.DataMember = "Subjects";
            this.subjectsBindingSource.DataSource = this.base_nalogDataSet;
            this.subjectsBindingSource.Sort = "subject_name asc";
            // 
            // base_nalogDataSet
            // 
            this.base_nalogDataSet.DataSetName = "base_nalogDataSet";
            this.base_nalogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxYearAfter
            // 
            this.textBoxYearAfter.Enabled = false;
            this.textBoxYearAfter.Location = new System.Drawing.Point(365, 47);
            this.textBoxYearAfter.Name = "textBoxYearAfter";
            this.textBoxYearAfter.Size = new System.Drawing.Size(53, 20);
            this.textBoxYearAfter.TabIndex = 4;
            // 
            // textBoxYearBefore
            // 
            this.textBoxYearBefore.Enabled = false;
            this.textBoxYearBefore.Location = new System.Drawing.Point(424, 47);
            this.textBoxYearBefore.Name = "textBoxYearBefore";
            this.textBoxYearBefore.Size = new System.Drawing.Size(53, 20);
            this.textBoxYearBefore.TabIndex = 3;
            // 
            // checkBoxMergeTable
            // 
            this.checkBoxMergeTable.AutoSize = true;
            this.checkBoxMergeTable.Location = new System.Drawing.Point(12, 46);
            this.checkBoxMergeTable.Name = "checkBoxMergeTable";
            this.checkBoxMergeTable.Size = new System.Drawing.Size(166, 17);
            this.checkBoxMergeTable.TabIndex = 2;
            this.checkBoxMergeTable.Text = "Объединять в одну таблицу";
            this.checkBoxMergeTable.UseVisualStyleBackColor = true;
            // 
            // btStartAgregation
            // 
            this.btStartAgregation.Enabled = false;
            this.btStartAgregation.Location = new System.Drawing.Point(12, 68);
            this.btStartAgregation.Name = "btStartAgregation";
            this.btStartAgregation.Size = new System.Drawing.Size(125, 23);
            this.btStartAgregation.TabIndex = 1;
            this.btStartAgregation.Text = "Агрегация данных";
            this.btStartAgregation.UseVisualStyleBackColor = true;
            this.btStartAgregation.Click += new System.EventHandler(this.btStartAgregation_Click);
            // 
            // comboBoxSelectTypeAgregation
            // 
            this.comboBoxSelectTypeAgregation.FormattingEnabled = true;
            this.comboBoxSelectTypeAgregation.Items.AddRange(new object[] {
            "Агрегация данных по итоговым показателям видов налогов"});
            this.comboBoxSelectTypeAgregation.Location = new System.Drawing.Point(12, 19);
            this.comboBoxSelectTypeAgregation.Name = "comboBoxSelectTypeAgregation";
            this.comboBoxSelectTypeAgregation.Size = new System.Drawing.Size(659, 21);
            this.comboBoxSelectTypeAgregation.TabIndex = 0;
            this.comboBoxSelectTypeAgregation.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectTypeAgregation_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.chkListBoxAgregationParam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 432);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chSetAll);
            this.panel4.Location = new System.Drawing.Point(12, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 35);
            this.panel4.TabIndex = 1;
            // 
            // chSetAll
            // 
            this.chSetAll.AutoSize = true;
            this.chSetAll.Location = new System.Drawing.Point(3, 3);
            this.chSetAll.Name = "chSetAll";
            this.chSetAll.Size = new System.Drawing.Size(125, 17);
            this.chSetAll.TabIndex = 0;
            this.chSetAll.Text = "Выбрать/снять все";
            this.chSetAll.UseVisualStyleBackColor = true;
            this.chSetAll.CheckedChanged += new System.EventHandler(this.chSetAll_CheckedChanged);
            // 
            // chkListBoxAgregationParam
            // 
            this.chkListBoxAgregationParam.FormattingEnabled = true;
            this.chkListBoxAgregationParam.HorizontalScrollbar = true;
            this.chkListBoxAgregationParam.Location = new System.Drawing.Point(12, 45);
            this.chkListBoxAgregationParam.Name = "chkListBoxAgregationParam";
            this.chkListBoxAgregationParam.Size = new System.Drawing.Size(182, 274);
            this.chkListBoxAgregationParam.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarAgregation,
            this.toolStripStatusLabelStep,
            this.toolStripStatusLabelAction});
            this.statusStrip.Location = new System.Drawing.Point(200, 510);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(495, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBarAgregation
            // 
            this.toolStripProgressBarAgregation.Name = "toolStripProgressBarAgregation";
            this.toolStripProgressBarAgregation.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelStep
            // 
            this.toolStripStatusLabelStep.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelStep.Name = "toolStripStatusLabelStep";
            this.toolStripStatusLabelStep.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelAction
            // 
            this.toolStripStatusLabelAction.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelAction.Name = "toolStripStatusLabelAction";
            this.toolStripStatusLabelAction.Size = new System.Drawing.Size(0, 17);
            // 
            // subjectsTableAdapter
            // 
            this.subjectsTableAdapter.ClearBeforeFill = true;
            // 
            // FormDataAggregation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 532);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormDataAggregation";
            this.Text = "FormDataAggregation";
            this.Load += new System.EventHandler(this.FormDataAggregation_Load);
            this.panel1.ResumeLayout(false);
            this.groupBoxAgregationParam.ResumeLayout(false);
            this.groupBoxAgregationParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.base_nalogDataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBoxAgregationParam;
        private System.Windows.Forms.ComboBox comboBoxSelectTypeAgregation;
        private System.Windows.Forms.Button btStartAgregation;
        public System.Windows.Forms.CheckedListBox chkListBoxAgregationParam;
        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBarAgregation;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStep;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAction;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chSetAll;
        public System.Windows.Forms.CheckBox checkBoxMergeTable;
        public System.Windows.Forms.ComboBox comboBoxSubjects;
        public System.Windows.Forms.TextBox textBoxYearAfter;
        public System.Windows.Forms.TextBox textBoxYearBefore;
        public System.Windows.Forms.CheckBox checkBoxFilterYears;
        private base_nalogDataSet base_nalogDataSet;
        private System.Windows.Forms.BindingSource subjectsBindingSource;
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter;
        public System.Windows.Forms.CheckBox checkBoxFilterSubject;
        private System.Windows.Forms.CheckBox checkBoxPrefix;
        public System.Windows.Forms.TextBox textBoxPrefix;
    }
}