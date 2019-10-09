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
            decimal maxValue = 0;
            decimal minValue = 0;
            decimal step = 0;
            decimal divide = 1;
            decimal v = 0;
            decimal v1 = 0;
            string sizeValueScale = "";

            decimal[,] values = new decimal[cr.AnalysData.Var.CountIntervals, 2];
            foreach (DataRow row in cr.AnalysData.Var.SourceTable.Rows)
            {
                decimal value = cr.AnalysData.returnNullDecimal(row[cr.AnalysData.Var.NameParam]);
                if (value >= maxValue) maxValue = value;
            }
            foreach (DataRow row in cr.AnalysData.Var.SourceTable.Rows)
            {
                decimal value = cr.AnalysData.returnNullDecimal(row[cr.AnalysData.Var.NameParam]);
                if (value <= minValue) minValue = value;
            }
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
            step = (Math.Abs(maxValue) + Math.Abs(minValue)) / cr.AnalysData.Var.CountIntervals;
            decimal sumSteps = minValue;
            values[0, 0] = minValue;
            //Создаем класс для характеристики распределения
            spr = new Classes.AnalysisData.Spreading();
            spr.CmnVal.OuVal._arX = new double[cr.AnalysData.Var.SourceTable.Rows.Count];
            int indexArX = 0;
            //
            foreach (DataRow row in cr.AnalysData.Var.SourceTable.Rows)
            {
                decimal value = cr.AnalysData.returnNullDecimal(row[cr.AnalysData.Var.NameParam]);
                spr.CmnVal.OuVal._arX[indexArX] = Convert.ToDouble(value);
                indexArX++;
            }
            //Выводим характеристики распределения
            spr.CmnVal.EnVal._N = cr.AnalysData.Var.CountIntervals;

            //
            for (int i = 1; i < cr.AnalysData.Var.CountIntervals; i++)
            {
                sumSteps = sumSteps + step;
                values[i, 0] = sumSteps;
                foreach (DataRow row in cr.AnalysData.Var.SourceTable.Rows)
                {
                    decimal value = cr.AnalysData.returnNullDecimal(row[cr.AnalysData.Var.NameParam]);
                    if (value >= values[i - 1, 0] && value < values[i, 0])
                    {
                        values[i, 1]++;
                    }
                }
            }
            //Выводим характеристики распределения

            spr.Proc.Calculation(); //Расчет характеристик
            //Вывод
            this.txtMatO.Text = Math.Round(spr.CmnVal.OuVal._MatO, 5).ToString();
            this.txtDisp.Text = Math.Round(spr.CmnVal.OuVal._Disp, 5).ToString();
            this.txtSko.Text = Math.Round(spr.CmnVal.OuVal._Sko, 5).ToString();
            this.txtXi2.Text = Math.Round(spr.CmnVal.OuVal._Xi2, 5).ToString();
            decimal maxValueG = 0;
            decimal minValueG = 0;
            for (int i = 0; i < values.Length / 2; i++)
            {
                if (values[i, 1] >= maxValueG) maxValueG = values[i, 1];
                if (values[i, 1] <= maxValueG) minValueG = values[i, 1];
            }


            //Все эти настроки можно сделать через визуальный редактор
            //Visual Studio. Необходимо только данные о точках
            // Програмно присваиваем свофства для графика
            chart2D1.Dock = DockStyle.Fill;
            chart2D1.C2ChartArea.ChartBackColor = Color.White;
            ds = new DataSeries();
            chart2D1.C2Legend.IsLegendVisible = true;
            //Запускаем процедуру
            //////////////////
            chart2D1.C2XAxis.XLimMin = cr.AnalysData.returnNullFloat(minValue / divide, 1);
            chart2D1.C2XAxis.XLimMax = cr.AnalysData.returnNullFloat(maxValue / divide, 1);
            chart2D1.C2YAxis.YLimMin = cr.AnalysData.returnNullFloat(0);
            chart2D1.C2YAxis.YLimMax = cr.AnalysData.returnNullFloat(maxValueG);
            chart2D1.C2XAxis.XTick = cr.AnalysData.returnNullFloat(step / divide, 1);
            chart2D1.C2YAxis.YTick = cr.AnalysData.returnNullFloat((maxValueG / cr.AnalysData.Var.CountIntervals), 1);
            chart2D1.C2Label.XLabel = "";
            chart2D1.C2Label.YLabel = "";
            chart2D1.C2Title.Title = cr.AnalysData.Var.NameTextReport;
            chart2D1.C2DataCollection.DataSeriesList.Clear();
            // Добавляем точки графиков первой линии
            ds = new DataSeries();
            ds.LineStyle.LineColor = Color.Red;
            ds.LineStyle.Thickness = 2f;
            ds.LineStyle.Pattern = DashStyle.Dash;
            ds.LineStyle.PlotMethod = LineStyle.PlotLinesMethodEnum.Splines;
            if (sizeValueScale.Length > 0)
            {
                ds.SeriesName = cr.AnalysData.Var.NameParam + ", " + sizeValueScale;
            }
            else
            {
                ds.SeriesName = cr.AnalysData.Var.NameParam;
            }
            ds.SymbolStyle.SymbolType = SymbolStyle.SymbolTypeEnum.Diamond;
            ds.SymbolStyle.BorderColor = Color.Red;
            ds.SymbolStyle.FillColor = Color.Yellow;
            ds.SymbolStyle.BorderThickness = 1f;
            //
            sumSteps = minValue;
            //
            for (int i = 0; i < values.Length / 2; i++)
            {
                //if (cr.AnalysData.returnNullFloat(values[i, 1]) > 0)
                //{
                ds.AddPoint(new PointF(cr.AnalysData.returnNullFloat(values[i, 0] / divide, 1), cr.AnalysData.returnNullFloat(values[i, 1], 1)));
                //}
            }
            chart2D1.C2DataCollection.Add(ds);
        }

        private void comboBoxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            cr.AnalysData.Var.YearBefore = (short)cr.AnalysData.returnNullInt(this.comboBoxYears.Text);
            cr.AnalysData.Var.YearAfter = (short)cr.AnalysData.returnNullInt(this.comboBoxYears.Text);
            cr.AnalysData.selectReport(1);
            if (cr.AnalysData.Var.SourceTable.Rows.Count > 0)
            {
                if (cr.AnalysData.returnNullFloat(cr.AnalysData.Var.SourceTable.Rows[0][cr.AnalysData.Var.NameParam]) > 0)
                {
                    fill();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.EveScrShot(this.chart2D1.Width, this.chart2D1.Height, this.chart2D1.Location.X,this.chart2D1.Location.Y);
        }
    }
}
