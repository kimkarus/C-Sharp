namespace NalogUser.Forms
{
    partial class FormSpreading
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
            Chart2DLib.DataCollection dataCollection2 = new Chart2DLib.DataCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpreading));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart2D1 = new Chart2DLib.Chart2D();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSpreadings = new System.Windows.Forms.ComboBox();
            this.comboBoxYears = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSpreading = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpreading)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.chart2D1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(721, 706);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 0;
            // 
            // chart2D1
            // 
            this.chart2D1.C2ChartArea.ChartBackColor = System.Drawing.SystemColors.Control;
            this.chart2D1.C2ChartArea.ChartBorderColor = System.Drawing.SystemColors.Control;
            this.chart2D1.C2ChartArea.PlotBackColor = System.Drawing.Color.White;
            this.chart2D1.C2ChartArea.PlotBorderColor = System.Drawing.Color.Black;
            dataCollection2.DataSeriesIndex = 0;
            dataCollection2.DataSeriesList = ((System.Collections.ArrayList)(resources.GetObject("dataCollection2.DataSeriesList")));
            this.chart2D1.C2DataCollection = dataCollection2;
            this.chart2D1.C2Grid.GridColor = System.Drawing.Color.LightGray;
            this.chart2D1.C2Grid.GridPattern = System.Drawing.Drawing2D.DashStyle.Solid;
            this.chart2D1.C2Grid.GridThickness = 1F;
            this.chart2D1.C2Grid.IsXGrid = true;
            this.chart2D1.C2Grid.IsYGrid = true;
            this.chart2D1.C2Label.LabelFont = new System.Drawing.Font("Arial", 10F);
            this.chart2D1.C2Label.LabelFontColor = System.Drawing.Color.Black;
            this.chart2D1.C2Label.TickFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chart2D1.C2Label.TickFontColor = System.Drawing.Color.Black;
            this.chart2D1.C2Label.XLabel = "X Axis";
            this.chart2D1.C2Label.Y2Label = "Y2 Axis";
            this.chart2D1.C2Label.YLabel = "Y Axis";
            this.chart2D1.C2Legend.IsBorderVisible = true;
            this.chart2D1.C2Legend.IsLegendVisible = false;
            this.chart2D1.C2Legend.LegendBackColor = System.Drawing.Color.White;
            this.chart2D1.C2Legend.LegendBorderColor = System.Drawing.Color.Black;
            this.chart2D1.C2Legend.LegendFont = new System.Drawing.Font("Arial", 8F);
            this.chart2D1.C2Legend.LegendPosition = Chart2DLib.Legend.LegendPositionEnum.NorthEast;
            this.chart2D1.C2Legend.TextColor = System.Drawing.Color.Black;
            this.chart2D1.C2Title.Title = "Title";
            this.chart2D1.C2Title.TitleFont = new System.Drawing.Font("Arial", 12F);
            this.chart2D1.C2Title.TitleFontColor = System.Drawing.Color.Black;
            this.chart2D1.C2XAxis.XCount = 0;
            this.chart2D1.C2XAxis.XLimMax = 10F;
            this.chart2D1.C2XAxis.XLimMin = 0F;
            this.chart2D1.C2XAxis.XTick = 2F;
            this.chart2D1.C2Y2Axis.IsY2Axis = false;
            this.chart2D1.C2Y2Axis.Y2LimMax = 100F;
            this.chart2D1.C2Y2Axis.Y2LimMin = 0F;
            this.chart2D1.C2Y2Axis.Y2Tick = 20F;
            this.chart2D1.C2YAxis.YLimMax = 10F;
            this.chart2D1.C2YAxis.YLimMin = 0F;
            this.chart2D1.C2YAxis.YTick = 2F;
            this.chart2D1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2D1.Location = new System.Drawing.Point(0, 0);
            this.chart2D1.Name = "chart2D1";
            this.chart2D1.Size = new System.Drawing.Size(721, 394);
            this.chart2D1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.comboBoxSpreadings);
            this.splitContainer2.Panel1.Controls.Add(this.comboBoxYears);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(721, 308);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Закон распределения";
            // 
            // comboBoxSpreadings
            // 
            this.comboBoxSpreadings.FormattingEnabled = true;
            this.comboBoxSpreadings.Location = new System.Drawing.Point(485, 3);
            this.comboBoxSpreadings.Name = "comboBoxSpreadings";
            this.comboBoxSpreadings.Size = new System.Drawing.Size(224, 21);
            this.comboBoxSpreadings.TabIndex = 3;
            this.comboBoxSpreadings.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpreadings_SelectedIndexChanged);
            // 
            // comboBoxYears
            // 
            this.comboBoxYears.FormattingEnabled = true;
            this.comboBoxYears.Location = new System.Drawing.Point(49, 3);
            this.comboBoxYears.Name = "comboBoxYears";
            this.comboBoxYears.Size = new System.Drawing.Size(121, 21);
            this.comboBoxYears.TabIndex = 0;
            this.comboBoxYears.SelectedIndexChanged += new System.EventHandler(this.comboBoxYears_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Год";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewSpreading);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 279);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Характеристика распределения значений";
            // 
            // dataGridViewSpreading
            // 
            this.dataGridViewSpreading.AllowUserToAddRows = false;
            this.dataGridViewSpreading.AllowUserToDeleteRows = false;
            this.dataGridViewSpreading.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpreading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSpreading.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewSpreading.Name = "dataGridViewSpreading";
            this.dataGridViewSpreading.ReadOnly = true;
            this.dataGridViewSpreading.Size = new System.Drawing.Size(715, 260);
            this.dataGridViewSpreading.TabIndex = 0;
            // 
            // FormSpreading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 706);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSpreading";
            this.Text = "Плотность распоеления значений";
            this.Load += new System.EventHandler(this.FormSpreading_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpreading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Chart2DLib.Chart2D chart2D1;
        private System.Windows.Forms.ComboBox comboBoxYears;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewSpreading;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSpreadings;

    }
}