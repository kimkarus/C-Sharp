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
            Chart2DLib.DataCollection dataCollection1 = new Chart2DLib.DataCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpreading));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart2D1 = new Chart2DLib.Chart2D();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXi2 = new System.Windows.Forms.TextBox();
            this.txtSko = new System.Windows.Forms.TextBox();
            this.txtDisp = new System.Windows.Forms.TextBox();
            this.txtMatO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSaveGraph = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxYears = new System.Windows.Forms.ComboBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSaveGraph);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxYears);
            this.splitContainer1.Size = new System.Drawing.Size(675, 603);
            this.splitContainer1.SplitterDistance = 453;
            this.splitContainer1.TabIndex = 0;
            // 
            // chart2D1
            // 
            this.chart2D1.C2ChartArea.ChartBackColor = System.Drawing.SystemColors.Control;
            this.chart2D1.C2ChartArea.ChartBorderColor = System.Drawing.SystemColors.Control;
            this.chart2D1.C2ChartArea.PlotBackColor = System.Drawing.Color.White;
            this.chart2D1.C2ChartArea.PlotBorderColor = System.Drawing.Color.Black;
            dataCollection1.DataSeriesIndex = 0;
            dataCollection1.DataSeriesList = ((System.Collections.ArrayList)(resources.GetObject("dataCollection1.DataSeriesList")));
            this.chart2D1.C2DataCollection = dataCollection1;
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
            this.chart2D1.Size = new System.Drawing.Size(675, 453);
            this.chart2D1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(16, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 95);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Характеристика закона распределения";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtXi2);
            this.groupBox2.Controls.Add(this.txtSko);
            this.groupBox2.Controls.Add(this.txtDisp);
            this.groupBox2.Controls.Add(this.txtMatO);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 67);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расчетные величины";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Хи-2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "С.К.О.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Дисп";
            // 
            // txtXi2
            // 
            this.txtXi2.BackColor = System.Drawing.SystemColors.Control;
            this.txtXi2.Enabled = false;
            this.txtXi2.Location = new System.Drawing.Point(189, 32);
            this.txtXi2.Name = "txtXi2";
            this.txtXi2.Size = new System.Drawing.Size(53, 20);
            this.txtXi2.TabIndex = 18;
            // 
            // txtSko
            // 
            this.txtSko.BackColor = System.Drawing.SystemColors.Control;
            this.txtSko.Enabled = false;
            this.txtSko.Location = new System.Drawing.Point(130, 32);
            this.txtSko.Name = "txtSko";
            this.txtSko.Size = new System.Drawing.Size(53, 20);
            this.txtSko.TabIndex = 17;
            // 
            // txtDisp
            // 
            this.txtDisp.BackColor = System.Drawing.SystemColors.Control;
            this.txtDisp.Enabled = false;
            this.txtDisp.Location = new System.Drawing.Point(71, 32);
            this.txtDisp.Name = "txtDisp";
            this.txtDisp.Size = new System.Drawing.Size(53, 20);
            this.txtDisp.TabIndex = 16;
            // 
            // txtMatO
            // 
            this.txtMatO.BackColor = System.Drawing.SystemColors.Control;
            this.txtMatO.Enabled = false;
            this.txtMatO.Location = new System.Drawing.Point(12, 32);
            this.txtMatO.Name = "txtMatO";
            this.txtMatO.Size = new System.Drawing.Size(53, 20);
            this.txtMatO.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Мат. О";
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Location = new System.Drawing.Point(543, 8);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(120, 23);
            this.buttonSaveGraph.TabIndex = 2;
            this.buttonSaveGraph.Text = "Сохранить график";
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            this.buttonSaveGraph.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Год";
            // 
            // comboBoxYears
            // 
            this.comboBoxYears.FormattingEnabled = true;
            this.comboBoxYears.Location = new System.Drawing.Point(54, 8);
            this.comboBoxYears.Name = "comboBoxYears";
            this.comboBoxYears.Size = new System.Drawing.Size(121, 21);
            this.comboBoxYears.TabIndex = 0;
            this.comboBoxYears.SelectedIndexChanged += new System.EventHandler(this.comboBoxYears_SelectedIndexChanged);
            // 
            // FormSpreading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 603);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSpreading";
            this.Text = "FormSpreading";
            this.Load += new System.EventHandler(this.FormSpreading_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Chart2DLib.Chart2D chart2D1;
        private System.Windows.Forms.ComboBox comboBoxYears;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSaveGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXi2;
        private System.Windows.Forms.TextBox txtSko;
        private System.Windows.Forms.TextBox txtDisp;
        private System.Windows.Forms.TextBox txtMatO;
        private System.Windows.Forms.Label label2;

    }
}