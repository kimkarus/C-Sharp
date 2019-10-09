using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Chart2DLib; //Подключаем библиотеку

namespace NalogUser.Forms
{
    public partial class FormSpreading : Form
    {
        private Classes.Core cr;
        private Classes.AnalysisData.Spreading spr;
        private DataSeries ds; // для коллекции графиков

        public FormSpreading(Classes.Core Cr)
        {
            InitializeComponent();
            this.cr = Cr;
            this.comboBoxYears.Text = cr.AnalysData.Var.YearBefore.ToString();
            foreach (short year in cr.AnalysData.Var.ArrYears)
            {
                this.comboBoxYears.Items.Add(year);
            }
            foreach (string item in cr.AnalysData.Var.NameTypeSpreadings)
            {
                this.comboBoxSpreadings.Items.Add(item);
            }
        }
        private void FormSpreading_Load(object sender, EventArgs e)
        {
            if (cr.AnalysData.Var.SourceTable.Rows.Count > 0)
            {
                if (cr.AnalysData.returnNullFloat(cr.AnalysData.Var.SourceTable.Rows[0][cr.AnalysData.Var.NameParam]) > 0)
                {
                    fill();
                }
            }
        }
        private void fill()
        {
            /*
             * ФОРМИРОВАНИЕ РАСПРЕДЕЛЕНИЯ
             * */
            if (cr.AnalysData.Var.CountIntervals > cr.AnalysData.Var.SourceTable.Rows.Count) return;
            decimal divide = 1;
            decimal v = 0;
            decimal v1 = 0;
            decimal maxValue = 0;
            decimal minValue = 0;
            string sizeValueScale = "";
            //
            spr = new Classes.AnalysisData.Spreading(cr);
            if (cr.AnalysData.Var.CountIntervals <= 0) cr.AnalysData.Var.CountIntervals = cr.AnalysData.Var.SourceTable.Rows.Count / 10;
            if (cr.AnalysData.Var.CountIntervals > cr.AnalysData.Var.SourceTable.Rows.Count / 10) cr.AnalysData.Var.CountIntervals = cr.AnalysData.Var.SourceTable.Rows.Count / 10;
            if (this.comboBoxSpreadings.SelectedIndex < 0)
            {
                spr.CmnVal.EnVal._TypeSpreading = Classes.AnalysisData.Spreading.CommonValues.EnterValues.TypeSpreading.Normal;
            }
            else
            {
                spr.CmnVal.EnVal._TypeSpreading = (Classes.AnalysisData.Spreading.CommonValues.EnterValues.TypeSpreading)this.comboBoxSpreadings.SelectedIndex;
            }
            spr.Process.Calculation();
            maxValue = (decimal)spr.CmnVal.OuVal._MaxValue;
            minValue = (decimal)spr.CmnVal.OuVal._MinValue;
            #region Проверка на необъодимость уменьшение порядка чисел
            v = maxValue;
            int iv = Convert.ToInt32(v);
            if (iv.ToString().Length > 3)
            {
                sizeValueScale = "тыс.";
                divide = 1000;
                v1 = v;
                v = v / 1000;
                iv = Convert.ToInt32(v);
                if (iv.ToString().Length > 3)
                {
                    sizeValueScale = "млрд.";
                    divide = 1000000;
                    v1 = v;
                    v = v / 1000;
                    iv = Convert.ToInt32(v);

                    if (iv.ToString().Length > 3)
                    {
                        sizeValueScale = "трлн.";
                        divide = 1000000000;
                        v1 = v;
                        v = v / 1000;
                        iv = Convert.ToInt32(v);
                    }
                    if (iv.ToString().Length > 3)
                    {
                        sizeValueScale = "блн.";
                        divide = 1000000000000;
                        v1 = v;
                        v = v / 1000;
                        iv = Convert.ToInt32(v);

                        if (iv.ToString().Length > 3)
                        {
                            sizeValueScale = "много";
                            v1 = v;
                        }
                    }
                }

            }
            #endregion Проверка на необъодимость уменьшение порядка чисел
            this.dataGridViewSpreading.DataSource = spr.CmnVal.OuVal._Dt;
            //
            int maxRowLen = 0;
            foreach (DataRow row in spr.CmnVal.OuVal._Dt.Rows)
            {
                int len = row[0].ToString().Length;
                if (len > maxRowLen) maxRowLen = len;
            }
            this.dataGridViewSpreading.Columns[0].Width = maxRowLen * 6;
            //
            decimal maxValueG = 0;
            decimal minValueG = 0;
            for (int i = 0; i < spr.CmnVal.OuVal._arTable.Length / 7; i++)
            {
                if ((decimal)spr.CmnVal.OuVal._arTable[i, 2] >= maxValueG) maxValueG = (decimal)spr.CmnVal.OuVal._arTable[i, 2];
                if ((decimal)spr.CmnVal.OuVal._arTable[i, 2] <= maxValueG) minValueG = (decimal)spr.CmnVal.OuVal._arTable[i, 2];
            }


            //Все эти настроки можно сделать через визуальный редактор
            //Visual Studio. Необходимо только данные о точках
            // Програмно присваиваем свойства для графика
            //chart2D1.Dock = DockStyle.Fill;
            //chart2D1.C2ChartArea.ChartBackColor = Color.White;
            ds = new DataSeries();
            //chart2D1.C2Legend.IsLegendVisible = true;
            //Запускаем процедуру
            //////////////////
            chart2D1.C2DataCollection.DataSeriesList.Clear();
            chart2D1.C2Title.Title = cr.AnalysData.Var.NameTextReport;
            chart2D1.C2XAxis.XLimMin = cr.AnalysData.returnNullFloat(minValue / divide, 1);
            chart2D1.C2XAxis.XLimMax = cr.AnalysData.returnNullFloat(maxValue / divide, 1);
            chart2D1.C2YAxis.YLimMin = cr.AnalysData.returnNullFloat(0);
            chart2D1.C2YAxis.YLimMax = cr.AnalysData.returnNullFloat(maxValueG) + 5f;
            chart2D1.C2XAxis.XTick = cr.AnalysData.returnNullFloat((decimal)spr.CmnVal.EnVal._Step / divide, 1);
            chart2D1.C2YAxis.YTick = cr.AnalysData.returnNullFloat((maxValueG / cr.AnalysData.Var.CountIntervals), 1);
            chart2D1.C2Label.XLabel = "Конец интервала";
            chart2D1.C2Label.YLabel = "Абсолютная частота";
            chart2D1.C2XAxis.XCount = spr.CmnVal.EnVal._Ntb; //количесвто столбцов для Bars
            //
            // Добавляем точки графиков первой линии
            //ДИАГРАММА
            ds = new DataSeries(DataSeries.ChartStyleEnum.BarStyle);
            ds.BarStyle.BorderColor = Color.Red;
            ds.BarStyle.FillColor = Color.Lime;
            ds.BarStyle.BorderThickness = 2f;
            for (int i = 0; i < spr.CmnVal.EnVal._Ntb; i++)
            {
                ds.AddPoint(new PointF(cr.AnalysData.returnNullFloat((decimal)spr.CmnVal.OuVal._arTable[i, 1] / divide, 1),
                    cr.AnalysData.returnNullFloat(spr.CmnVal.OuVal._arTable[i, 2], 1)));
            }
            chart2D1.C2DataCollection.Add(ds);
            //ГРАФИК
            ds = new DataSeries();
            ds.LineStyle.LineColor = Color.Red;
            ds.LineStyle.Thickness = 2f;
            ds.LineStyle.Pattern = DashStyle.Dash;
            ds.LineStyle.PlotMethod = LineStyle.PlotLinesMethodEnum.Splines;
            ds.SymbolStyle.SymbolType = SymbolStyle.SymbolTypeEnum.Diamond;
            ds.SymbolStyle.BorderColor = Color.Red;
            ds.SymbolStyle.FillColor = Color.Yellow;
            ds.SymbolStyle.BorderThickness = 1f;
            //
            for (int i = 0; i < spr.CmnVal.EnVal._Ntb; i++)
            {
                ds.AddPoint(new PointF(cr.AnalysData.returnNullFloat((decimal)(spr.CmnVal.OuVal._arTable[i, 1] - spr.CmnVal.EnVal._Step / 2) / divide, 1),
                    cr.AnalysData.returnNullFloat(spr.CmnVal.OuVal._arTable[i, 3], 1)));
            }
            chart2D1.C2DataCollection.Add(ds);
            //
            this.comboBoxSpreadings.Text = cr.AnalysData.Var.NameTypeSpreadings[(int)spr.CmnVal.EnVal._TypeSpreading];
        }

        private void comboBoxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            cr.AnalysData.Var.YearBefore = (short)cr.AnalysData.returnNullInt(this.comboBoxYears.Text);
            cr.AnalysData.Var.YearAfter = (short)cr.AnalysData.returnNullInt(this.comboBoxYears.Text);
            cr.AnalysData.selectReport(1);
            if (cr.AnalysData.Var.SourceTable.Rows.Count > cr.AnalysData.Var.CountIntervals && cr.AnalysData.Var.SourceTable.Rows.Count > 0)
            {
                fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.EveScrShot(this.chart2D1.Width, this.chart2D1.Height, this.chart2D1.Location.X, this.chart2D1.Location.Y);
        }

        private void comboBoxSpreadings_SelectedIndexChanged(object sender, EventArgs e)
        {
            cr.AnalysData.Var.YearBefore = (short)cr.AnalysData.returnNullInt(this.comboBoxYears.Text);
            cr.AnalysData.Var.YearAfter = (short)cr.AnalysData.returnNullInt(this.comboBoxYears.Text);
            cr.AnalysData.selectReport(1);
            if (cr.AnalysData.Var.SourceTable.Rows.Count > cr.AnalysData.Var.CountIntervals && cr.AnalysData.Var.SourceTable.Rows.Count > 0)
            {
                fill();
            }
        }
    }
}
