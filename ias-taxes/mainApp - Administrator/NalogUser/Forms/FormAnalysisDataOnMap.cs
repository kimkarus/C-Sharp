using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace NalogUser.Forms
{
    
    public partial class FormAnalysisDataOnMap : Form
    {
        private Classes.Core cr;
        //
        #region Переменные для расчета
        private int year = 2008;
        private decimal rfPopulation = 0;
        private decimal rfPopulationOld = 0;
        private decimal rfRaisePopulation = 0;
        private decimal rfBusyed = 0;
        private decimal rfBusyedOld = 0;
        private decimal rfRaiseBusyed = 0;
        private decimal rfUnemployed = 0;
        private decimal rfUnemployedOld = 0;
        private decimal rfRaiseUnemployed = 0;
        private decimal rfTi = 0;
        private decimal subTi = 0;
        private decimal subTiOld = 0;
        private decimal rfTiOld = 0;
        private decimal rfRaiseTi = 0;
        private int mathRound2=2;
        private int mathRound0 = 0;
        private string million = "млн.";
        private string thousand = "тыс.";
        private bool rowsCountTi = false;

        private double kdolError = 0.05;

        private bool dataFromChoiceForm = false;

        private string colGr1 = "";
        private string col1 = "";
        private string colGr2 = "";
        private string col2 = "";

        private DataTable dtTi;
        private DataTable dtSource;
        private DataTable dtPopulation;
        #endregion Переменные для расчета

        List<decimal> listParams = new List<decimal>();
        private System.Drawing.Color[] specialColors = new Color[] { Color.Green, Color.Coral, Color.Yellow };

        List<System.Drawing.Color> listColors = new List<System.Drawing.Color>();
        List<decimal> listRangesSourveValue = new List<decimal>();

        private System.Windows.Media.SolidColorBrush solidColorBr;
        private System.Windows.Media.SolidColorBrush cbr1;
        private object item;

        private int frmHeight = 0;
        private int frmWidth = 0;

        private int pnael2Height = 0;
        private int panel2Width = 0;
        private bool maximized = false;
        //
        private decimal maxSourceValue;
        private decimal minSourceValue;
        private int countOfColors;
        private string sizeValueScale = "";
        //
        public FormAnalysisDataOnMap(Classes.Core Cr)
        {
            this.cr = Cr;
            InitializeComponent();
            //mapControl = new NalogUser.Controls.MapControl(this.cr);
            //
            cr.AnalysData.Var.IdDistrict = 0;
            cr.AnalysData.Var.IdSubject = 0;
            cr.AnalysData.Var.IdTax = 0;
            cr.AnalysData.Var.IdEea = 0;
            cr.AnalysData.Var.YearAfter = 0;
            cr.AnalysData.Var.YearBefore = 0;
            cr.AnalysData.Var.NameReport = "";
            
            cr.AnalysData.Var.SourceTable.Clear();
            fillYears();
            frmHeight = this.Height;
            frmWidth = this.Width;
            pnael2Height=this.splitContainer1.Panel2.Height;
            panel2Width = this.splitContainer1.Panel2.Width;
            hideMorePanel(true);
            //clearMapElements();
        }
        public FormAnalysisDataOnMap(Classes.Core Cr, bool DataFromChoiceForm)
        {
            this.cr = Cr;
            InitializeComponent();
            //mapControl = new NalogUser.Controls.MapControl(this.cr);
            //
            dataFromChoiceForm = DataFromChoiceForm;
            if (DataFromChoiceForm)
            {
                this.tabControlCommon.SelectedIndex = 1;
                selectDataSubjects();
                year = cr.AnalysData.Var.YearBefore;
                this.comboBoxYearSubjects.Text = year.ToString();
            }
            fillYears();
            frmHeight = this.Height;
            frmWidth = this.Width;
            pnael2Height = this.splitContainer1.Panel2.Height;
            panel2Width = this.splitContainer1.Panel2.Width;

            hideMorePanel(true);
            //clearMapElements();
        }

        private void selectDataRf()
        {
            rfPopulation = 0;
            rfPopulationOld = 0;
            rfRaisePopulation = 0;
            rfRaiseBusyed = 0;
            rfRaiseUnemployed = 0;
            rfRaiseTi = 0;
            rfBusyed = 0;
            rfBusyedOld = 0;
            rfUnemployed = 0;
            rfUnemployed = rfUnemployedOld = 0;
            rfTi = 0;
            rfTiOld = 0;
            
            try { year = Convert.ToInt16(this.comboBoxYear.Text); }
            catch (System.Exception err) { }
            //
            dtTi = new DataTable();
            dtPopulation = new DataTable();
            foreach (DataColumn col in this.base_nalog_viewsDataSet.View_stat_ti_districts.Columns)
            {
                dtTi.Columns.Add(col.ColumnName, col.DataType);
            }
            foreach (DataColumn col in this.base_nalog_viewsDataSet.View_stat_population_districts.Columns)
            {
                dtPopulation.Columns.Add(col.ColumnName, col.DataType);
            }
            for (int i = 0; i < this.base_nalog_viewsDataSet.View_stat_ti_districts.Rows.Count; i++)
            {
                if (year.ToString() == this.base_nalog_viewsDataSet.View_stat_ti_districts.Rows[i]["year"].ToString())
                {
                    dtTi.Rows.Add(this.base_nalog_viewsDataSet.View_stat_ti_districts.Rows[i].ItemArray);
                }
            }
            for (int i = 0; i < this.base_nalog_viewsDataSet.View_stat_population_districts.Rows.Count; i++)
            {
                if (year.ToString() == this.base_nalog_viewsDataSet.View_stat_population_districts.Rows[i]["year"].ToString())
                {
                    dtPopulation.Rows.Add(this.base_nalog_viewsDataSet.View_stat_population_districts.Rows[i].ItemArray);
                }
            }
            
            this.dataGridViewStatsData.Rows.Clear();
            if (dtTi.Rows.Count <= 1) { this.dataGridViewStatsData.RowCount = dtPopulation.Rows.Count; rowsCountTi = false; }
            else { this.dataGridViewStatsData.RowCount = dtTi.Rows.Count; rowsCountTi = true; }
            #region НД
            for (int i = 0; i < dtTi.Rows.Count; i++)
            {
                decimal ti = cr.AnalysData.returnNullDecimal(dtTi.Rows[i][this.base_nalog_viewsDataSet.View_stat_ti_districts.total_ti_districtColumn.ColumnName.ToString()]);
                decimal tiOld = cr.AnalysData.returnNullDecimal(dtTi.Rows[i][this.base_nalog_viewsDataSet.View_stat_ti_districts.total_ti_district2Column.ColumnName.ToString()]);
                decimal raiseTi = cr.AnalysData.returnNullDecimal(dtTi.Rows[i][this.base_nalog_viewsDataSet.View_stat_ti_districts.raise_total_ti_districtColumn.ColumnName.ToString()]);
                if (rowsCountTi)
                {
                    this.dataGridViewStatsData.Rows[i].Cells["FD"].Value = dtTi.Rows[i][this.base_nalog_viewsDataSet.View_stat_ti_districts.district_nameColumn.ColumnName.ToString()].ToString();
                }
                //RF
                rfTi += ti;
                rfTiOld += tiOld;
                //
                this.dataGridViewStatsData.Rows[i].Cells["TI"].Value = Math.Round(ti, 2);
                this.dataGridViewStatsData.Rows[i].Cells["RaiseTI"].Value = Math.Round((raiseTi / ti * 100), 2);
            }
            #endregion НД
            #region Население
            for (int i = 0; i < dtPopulation.Rows.Count; i++)
            {
               /* decimal population = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.sum_totalColumn.ColumnName.ToString()]);
                decimal populationOld = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.sum_total2Column.ColumnName.ToString()]);
                decimal raisePopulation = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.raise_sum_totalColumn.ColumnName.ToString()]);
                decimal busyed = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.sum_busyedColumn.ColumnName.ToString()]);
                decimal busyedOld = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.sum_busyed2Column.ColumnName.ToString()]);
                decimal raiseBusyed = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.raise_sum_busyedColumn.ColumnName.ToString()]);
                decimal unemployed = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.sum_unemployedColumn.ColumnName.ToString()]);
                decimal unemployedOld = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.sum_unemployed2Column.ColumnName.ToString()]);
                decimal raiseUnemployed = cr.AnalysData.returnNullDecimal(dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.raise_sum_unemployedColumn.ColumnName.ToString()]);*/
                if (!rowsCountTi)
                {
                    //this.dataGridViewStatsData.Rows[i].Cells["FD"].Value = dtPopulation.Rows[i][this.base_nalog_viewsDataSet.View_stat_population_districts.district_nameColumn.ColumnName.ToString()].ToString();
                }

                /*rfPopulation += population;
                rfPopulationOld += populationOld;
                rfBusyed += busyed;
                rfBusyedOld += busyedOld;
                rfUnemployed += unemployed;
                rfRaiseUnemployed += raiseUnemployed;
                rfUnemployedOld += unemployedOld;

                this.dataGridViewStatsData.Rows[i].Cells["Population"].Value = population;
                this.dataGridViewStatsData.Rows[i].Cells["RaisePopulation"].Value = Math.Round((raisePopulation / population * 100), 2);
                this.dataGridViewStatsData.Rows[i].Cells["Busyed"].Value = busyed;
                this.dataGridViewStatsData.Rows[i].Cells["RaiseBusyed"].Value = Math.Round((raiseBusyed / busyed * 100), 2);
                this.dataGridViewStatsData.Rows[i].Cells["Unemployed"].Value = unemployed;
                this.dataGridViewStatsData.Rows[i].Cells["RaiseUnemployed"].Value = Math.Round((raiseUnemployed / unemployed * 100), 2);*/
            }
            #endregion Население
            //
            this.labelTI.Text = rfNum(Math.Round(rfTi, mathRound0));
            this.labelPopulation.Text = rfNum(Math.Round(rfPopulation, mathRound0)) + " " + million;
            this.labelBusyed.Text = rfNum(Math.Round(rfBusyed, mathRound0)) + " " + million;
            this.labelUnemployed.Text = rfNum(Math.Round(rfUnemployed, mathRound0)) + " " + million;
            this.labelYear.Text = year.ToString();
            //Raise
            rfRaisePopulation = (rfPopulation - rfPopulationOld) / rfPopulationOld;
            rfRaiseBusyed = (rfBusyed - rfBusyedOld) / rfBusyedOld;
            rfRaiseUnemployed = (rfUnemployed - rfUnemployedOld) / rfUnemployedOld;
            rfRaiseTi = (rfTi - rfTiOld) / rfTiOld;

            this.labelRaisePopulation.Text = rfRaise(rfRaisePopulation);
            this.labelRaiseBusyed.Text = rfRaise(rfRaiseBusyed);
            this.labelRaiseUnemployed.Text = rfRaise(rfRaiseUnemployed);
            this.labelRaiseTI.Text = rfRaise(rfRaiseTi);
            //
            fillMap(0);
            //
        }
        private void selectDataSubjects()
        {
            try { year = Convert.ToInt16(this.comboBoxYearSubjects.Text); }
            catch (System.Exception err) { }
            //
            clearMapElements();
            dtSource = new DataTable();
            //if (!dataFromChoiceForm) { cr.AnalysData.Var.IdReport = Convert.ToInt32(comboBoxReportsOnMap.SelectedValue); }
            //cr.AnalysData.Var.NameReport = "kdol_subjects";
            if (cr.AnalysData.Var.YearAfter < 2000 || cr.AnalysData.Var.YearBefore < 2000)
            {
                cr.AnalysData.Var.YearBefore = (short)year;
                cr.AnalysData.Var.YearAfter = (short)year;
            }
            if (!dataFromChoiceForm) { cr.AnalysData.selectReport(1); } else { cr.AnalysData.selectReport(0); } //загружаем данные для карты и таблицы
            dtSource = cr.AnalysData.Var.SourceTable;

            this.dataGridViewSubjects.Rows.Clear();
            this.dataGridViewSubjects.Columns.Clear();
            if (dtSource.Rows.Count <= 0) { return; }
            this.dataGridViewSubjects.RowCount = dtSource.Rows.Count;
            #region НД
            colGr1 = cr.ClNames.Subject_name.nameCol;
            col1 = cr.ClNames.Subject_name.nameSQL;
            //dtSource.DefaultView.Sort = cr.ClNames.total_ti_subject.nameSQL + " ASC";
            #region Выбираем поля из таблицы запроса
            
            #endregion Выбираем поля из таблицы запроса
            DataView dv = new DataView(dtSource);
            dv.Sort = cr.AnalysData.Var.ActiveColSourceTable + " desc";
            dtSource.DefaultView.Sort = dv.Sort;
            dtSource = dv.ToTable();
            maxSourceValue = cr.AnalysData.returnNullDecimal(dtSource.Rows[0][cr.AnalysData.Var.ActiveColSourceTable].ToString());
            minSourceValue = cr.AnalysData.returnNullDecimal(dtSource.Rows[0][cr.AnalysData.Var.ActiveColSourceTable].ToString());

            //Определить макс и мин значения в активных значениях
            for (int i = 0; i < dtSource.Rows.Count; i++) { decimal selectedSourceValue = cr.AnalysData.returnNullDecimal(dtSource.Rows[i][cr.AnalysData.Var.ActiveColSourceTable].ToString()); if (selectedSourceValue >= maxSourceValue) { maxSourceValue = selectedSourceValue; } if (selectedSourceValue <= minSourceValue) { minSourceValue = selectedSourceValue; } }
            //Чило диапазонов равно количеству цветов для заливки карты
            //запись в массив числового диапазона
            //
            this.dataGridViewSubjects.Columns.Add(col1, colGr1);
            this.dataGridViewSubjects.Columns.Add(cr.AnalysData.Var.ActiveColSourceTable, cr.AnalysData.Var.ActiveColSourceTableText);
            this.dataGridViewSubjects.Columns[cr.AnalysData.Var.ActiveColSourceTable].DefaultCellStyle.Format = "0.00";
            //
            listColors.Clear();
            int step = 0;
            int stepSum = 0;
            //Определение необходимого количества диапазонов
            int intervals = 0;
            int countSourceRows = dtSource.Rows.Count;
            int[,] matches = { { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 }, { 2, 3, 5, 7, 7, 8, 8, 9, 11, 12, 14, 15, 17, 18, 19, 21, 21, 21, 21, 21 } };
            //
            for (int i = 0; i < matches.Length/2; i++)
            {
                if (countSourceRows <= matches[0, i])
                {
                    intervals = matches[1, i];
                }

            }

            countOfColors = intervals; //Количесвто цветов, используемы для заполнения карты
            if (countOfColors <= 0) { return; MessageBox.Show("Выборка данных слишком мала. Попробуйте изменить год"); }
            step = Convert.ToInt32(Math.Floor((decimal)255 / countOfColors));

            //Добавляем цвета в лист
            for (int i = 0; i < countOfColors; i++) { stepSum += step; listColors.Add(System.Drawing.Color.FromArgb(255, stepSum, stepSum)); }
            //Добавляем диапазоны значений
            listRangesSourveValue.Clear();
            decimal range = maxSourceValue / countOfColors;
            decimal rangeSum=0;
            for (int i = 0; i < countOfColors + 1; i++) { listRangesSourveValue.Add(rangeSum); rangeSum += range; }
            //заполняем таблицу пользователя
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                decimal selectedActiveSourceValue =cr.AnalysData.returnNullDecimal(dtSource.Rows[i][cr.AnalysData.Var.ActiveColSourceTable]);
                decimal selectedActiveSourceValueDouble = cr.AnalysData.returnNullDecimal(selectedActiveSourceValue);
                string selectedActiveSourceValueString = rfNum(selectedActiveSourceValueDouble);

                //Присваиваю цвета для субъектов
                for (int j = 1; j < listRangesSourveValue.Count; j++)
                {
                    if (selectedActiveSourceValue >= listRangesSourveValue[j - 1] &&
                        selectedActiveSourceValue <= listRangesSourveValue[j])
                    {
                        fillMapSubjects(dtSource.Rows[i][cr.ClNames.Subject_latin_name.nameSQL].ToString(), j - 1, false, Color.White,
                            dtSource.Rows[i][cr.ClNames.Subject_name.nameSQL].ToString(), cr.AnalysData.Var.ActiveColSourceTableText, selectedActiveSourceValueString);
                    }
                }
                //
                string name = dtSource.Rows[i][col1].ToString();
                //
                this.dataGridViewSubjects.Rows[i].Cells[col1].Value = name;
                this.dataGridViewSubjects.Rows[i].Cells[cr.AnalysData.Var.ActiveColSourceTable].Value = (object)selectedActiveSourceValue;

                double kdol = cr.AnalysData.returnNullDouble(dtSource.Rows[i][cr.AnalysData.Var.ActiveColSourceTable]);
                #region Для КДол
                if (cr.AnalysData.Var.NameParam == "kdol_subjects")
                {
                    if (kdol >= 1 - kdolError / 2 && kdol <= 1 + kdolError / 2)
                    {
                        fillMapSubjects(dtSource.Rows[i][cr.ClNames.Subject_latin_name.nameSQL].ToString(), i, true, specialColors[0],
                            dtSource.Rows[i][cr.ClNames.Subject_name.nameSQL].ToString(), cr.AnalysData.Var.ActiveColSourceTableText, selectedActiveSourceValueString);
                    }
                    if (kdol >= 1 + (kdolError / 2 + 1 / 2))
                    {
                        fillMapSubjects(dtSource.Rows[i][cr.ClNames.Subject_latin_name.nameSQL].ToString(), i, true, specialColors[2],
                            dtSource.Rows[i][cr.ClNames.Subject_name.nameSQL].ToString(), cr.AnalysData.Var.ActiveColSourceTableText, selectedActiveSourceValueString);
                    }
                    if (kdol <= 1 - (kdolError / 2 + 1 / 2))
                    {
                        fillMapSubjects(dtSource.Rows[i][cr.ClNames.Subject_latin_name.nameSQL].ToString(), i, true, specialColors[1],
                            dtSource.Rows[i][cr.ClNames.Subject_name.nameSQL].ToString(), cr.AnalysData.Var.ActiveColSourceTableText, selectedActiveSourceValueString);
                    }
                    
                }
                else
                {
                    fillMapSubjects(dtSource.Rows[i][cr.ClNames.Subject_latin_name.nameSQL].ToString(), i, false, Color.White,
                        dtSource.Rows[i][cr.ClNames.Subject_name.nameSQL].ToString(), cr.AnalysData.Var.ActiveColSourceTableText, selectedActiveSourceValueString);
                }
                #endregion Для КДол
            }

            dv.Sort = cr.ClNames.Subject_name.nameSQL + " desc";
            object item = mapControl.FindName("labelNameOfReport");
            System.Windows.Controls.Label lbl = (System.Windows.Controls.Label)item;
            lbl.Content = cr.AnalysData.Var.NameTextReport + " " + cr.AnalysData.Var.StrYears;
            if (cr.AnalysData.Var.StrNameTextSelectedTax.Length > 0) { lbl.Content += ": " + cr.AnalysData.Var.StrNameTextSelectedTax; }
            if (cr.AnalysData.Var.StrNameTextSelectedEea.Length > 0) { lbl.Content += ": " + cr.AnalysData.Var.StrNameTextSelectedEea; }
            item = lbl;
            #endregion НД
            #region Население
            #endregion Население
            //
            //
            MapHeatScale();
        }
        private string rfRaise(decimal num)
        {
            string str = "";
            string simb="";
            if (num > 0) { simb = "+"; } else { simb = "-"; }
            str = "(" + simb + Math.Round(num, mathRound2).ToString() + "%)";
            return str;
        }
        private string rfNum(decimal num)
        {
            string str = "";
            string strNum=num.ToString();
            int count=0;
            for (int i = 0; i < strNum.Length; i++)
            {
                str += strNum[strNum.Length - i - 1];
                count++;
                if (count == 3) { str += " "; count = 0; }
            }
            strNum = str;
            str = "";
            for (int i = 0; i < strNum.Length; i++)
            {
                str += strNum[strNum.Length - i - 1];
            }
            return str;
        }
        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectDataRf();
        }
        private void fillMap(int setting)
        {
            int step = 0;
            int stepSum = 0;
            listColors.Clear();
            switch (setting)
            {
                case 0:
                    {
                        #region РФ
                        if (dtTi.Rows.Count <= 0) return;
                        step = Convert.ToInt32(Math.Floor((double)255 / dtTi.Rows.Count));
                        for (int i = 0; i < dtTi.Rows.Count; i++)
                        {
                            stepSum += step;
                            listColors.Add(System.Drawing.Color.FromArgb(255, stepSum, stepSum));
                        }
                        decimal kRfTI = rfTi / listColors.Count; //разница межу диапазоном цветов
                        listParams.Clear();
                        listParams.Add(kRfTI);
                        for (int i = 1; i < listColors.Count; i++)
                        {
                            listParams.Add(listParams[i - 1] + kRfTI);
                        }
                        for (int i = 0; i < dtTi.Rows.Count; i++)
                        {
                            for (int j = 0; j < listParams.Count; j++)
                            {
                                decimal param = cr.AnalysData.returnNullDecimal(dtTi.Rows[i][this.base_nalog_viewsDataSet.View_stat_ti_districts.total_ti_districtColumn.ColumnName.ToString()], 2);
                                string strDistrct = dtTi.Rows[i][this.base_nalog_viewsDataSet.View_stat_ti_districts.latin_nameColumn.ToString()].ToString();
                                if (param < listParams[j] && param > listParams[j] - kRfTI)
                                {
                                    System.Drawing.Color color = listColors[listColors.Count - 1 - j];
                                    System.Windows.Media.Color mColor = System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
                                    solidColorBr = new System.Windows.Media.SolidColorBrush(mColor);
                                    solidColorBr.Color = mColor;

                                    object item = mapControl.FindName(strDistrct);
                                    System.Windows.Shapes.Shape sh = (System.Windows.Shapes.Shape)item;
                                    sh.Fill = solidColorBr;
                                    item = sh;
                                    string dd = sh.Name.ToString();
                                }
                                else
                                {

                                }
                            }
                        }
                        break;
                        #endregion РФ
                    }
                case 1:
                    {
                        if (dtSource.Rows.Count <= 0) return;
                        step = Convert.ToInt32(Math.Floor((double)255 / Math.Floor((double)(dtSource.Rows.Count / 10))));
                        for (int i = 0; i < dtSource.Rows.Count; i++)
                        {
                            stepSum += step;
                            listColors.Add(System.Drawing.Color.FromArgb(255, stepSum, stepSum));
                        }
                        for (int i = 0; i < dtSource.Rows.Count; i++)
                        {
                            System.Drawing.Color color = listColors[i];
                            System.Windows.Media.Color mColor = System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
                            solidColorBr = new System.Windows.Media.SolidColorBrush(mColor);
                            solidColorBr.Color = mColor;

                            object item = mapControl.FindName(dtSource.Rows[i][cr.ClNames.Subject_latin_name.nameSQL].ToString());
                            if (item != null)
                            {
                                System.Windows.Shapes.Shape sh = (System.Windows.Shapes.Shape)item;
                                sh.Fill = solidColorBr;
                                item = sh;
                                string dd = sh.Name.ToString();
                                //item
                            }
                        }
                        break;
                    }
            }

        }
        private void fillMapSubjects(string name, int index, bool specColor, System.Drawing.Color specialColor, string subject_name, string field, string value)
        {
            switch (specColor)
            {
                case true:
                    {
                    #region Специальные цвета
                        System.Drawing.Color color = specialColor;
                        System.Windows.Media.Color mColor = System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
                        solidColorBr = new System.Windows.Media.SolidColorBrush(mColor);
                        solidColorBr.Color = mColor;

                        object item = mapControl.FindName(name);
                        if (item != null)
                        {
                            System.Windows.Shapes.Shape sh = (System.Windows.Shapes.Shape)item;
                            sh.Fill = solidColorBr;
                            item = sh;
                            string dd = sh.Name.ToString();
                        }
                        break;
                        #endregion Специальные цвета
                    }
                case false:
                    {
                        if (index >= listColors.Count) { index = listColors.Count - 1; }
                        System.Drawing.Color color = listColors[index];
                        System.Windows.Media.Color mColor = System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
                        solidColorBr = new System.Windows.Media.SolidColorBrush(mColor);
                        solidColorBr.Color = mColor;
                        

                        object item = mapControl.FindName(name);
                        //System.Windows.fra = mapControl1.FindName(name);
                        //ToolTip tt=new ToolTip();
                        //tt.Tag=name;
                        if (item != null)
                        {
                            System.Windows.Shapes.Shape sh = (System.Windows.Shapes.Shape)item;
                            sh.Fill = solidColorBr;
                            item = sh;
                            //string dd = sh.Name.ToString();

                            System.Windows.Shapes.Path pth = (System.Windows.Shapes.Path)item;
                            pth.ToolTip = subject_name + "\n" + field + " - " + value;
                            item = pth;
                            //System.Windows.FrameworkElement.
                        }
                        break;
                    }
            }

        }
        private void MapHeatScale()
        {
            #region Тепловая шкала
            int countScale = 7;
            int step = Convert.ToInt32(Math.Floor((decimal)countOfColors / (decimal)countScale));
            int stepSum = countOfColors;

            for (int i = 0; i < countScale; i++)
            {
                object item = mapControl.FindName("cvsScale" + ((int)i + (int)1).ToString());
                ApplyMapHeatScale(item, stepSum);
                stepSum -= step;
            }
            string format = "{0:f2}";
            //
            object itemLable = mapControl.FindName("HeatScaleLableL");
            ApplyMapHeatLables(itemLable, " >= " + string.Format(MapHeatLableValue(minSourceValue).ToString(), format) + " " + sizeValueScale);
            itemLable = mapControl.FindName("HeatScaleLableM");
            ApplyMapHeatLables(itemLable, " ~ " + string.Format(MapHeatLableValue((maxSourceValue + minSourceValue) / 2).ToString(), format) + " " + sizeValueScale + " ~ ");
            itemLable = mapControl.FindName("HeatScaleLableR");
            ApplyMapHeatLables(itemLable, " <= " + string.Format(MapHeatLableValue(maxSourceValue).ToString(), format) + " " + sizeValueScale);
            #endregion Тепловая шкала
        }
        private void ApplyMapHeatScale(object item, int index)
        {
            if (index >= listColors.Count) { index = listColors.Count - 1; }
            System.Drawing.Color color = listColors[index];
            System.Windows.Media.Color mColor = System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
            solidColorBr = new System.Windows.Media.SolidColorBrush(mColor);
            solidColorBr.Color = mColor;

            if (item != null)
            {
                System.Windows.Controls.Canvas cvs = (System.Windows.Controls.Canvas)item;
                cvs.Background = solidColorBr;
                item = cvs;
            }

        }
        private void ApplyMapHeatLables(object item, string content)
        {
            System.Windows.Controls.Label lbl = (System.Windows.Controls.Label)item;
            lbl.Content = content;
            item = lbl;
        }
        private decimal MapHeatLableValue(decimal value)
        {
            decimal v = value;
            decimal v1 = v;
            int iv = Convert.ToInt32(v);
            sizeValueScale = "тыс.";
            v = v / 1000;
            iv = Convert.ToInt32(v);
            if (iv > 0 || iv < 0)
            {
                sizeValueScale = "млн.";
                v1 = v;
                v = v / 1000;
                iv = Convert.ToInt32(v);
                if (iv > 0 || iv < 0)
                {
                    sizeValueScale = "млрд.";
                    v1 = v;
                    v = v / 1000;
                    iv = Convert.ToInt32(v);
                    if (iv > 0 || iv < 0)
                    {
                        sizeValueScale = "трлн.";
                        v1 = v;
                        v = v / 1000;
                        iv = Convert.ToInt32(v);
                        if (iv > 0 || iv < 0)
                        {
                            sizeValueScale = "блн.";
                            v1 = v;
                            v = v / 1000;
                            iv = Convert.ToInt32(v);
                            if (iv > 0 || iv < 0)
                            {
                                sizeValueScale = "много";
                                v1 = v;
                            }
                        }
                    }
                }
            }
            return Math.Round(v1, 2);
        }
        private void FormAnalysisDataOnMap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'base_nalogDataSet.Subjects' table. You can move, or remove it, as needed.
            //this.subjectsTableAdapter.Fill(cr.AnalysData.Ds.Subjects);
            //cr.AnalysData.DistrictTableAdapter.Fill(cr.AnalysData.Ds.Federal_district);
            //cr.AnalysData.SubjectsTableAdapter.Fill(cr.AnalysData.Ds.Subjects);
            // TODO: This line of code loads data into the 'base_nalogDataSet.Federal_district' table. You can move, or remove it, as needed.
            //this.federal_districtTableAdapter.Fill(cr.AnalysData.Ds.Federal_district);
            // TODO: This line of code loads data into the 'base_nalogDataSet.Reports' table. You can move, or remove it, as needed.
            //this.reportsTableAdapter.Fill(this.base_nalogDataSet.Reports);
            //this.reportsBindingSource.Filter = "id_report_type=3";
            // TODO: This line of code loads data into the 'base_nalog_viewsDataSet.View_stat_ti_districts' table. You can move, or remove it, as needed.
            //this.view_stat_ti_districtsTableAdapter.Fill(this.base_nalog_viewsDataSet.View_stat_ti_districts);
            // TODO: This line of code loads data into the 'base_nalog_viewsDataSet.View_stat_population_district' table. You can move, or remove it, as needed.
            //this.view_stat_population_districtsTableAdapter.Fill(this.base_nalog_viewsDataSet.View_stat_population_districts);
            //cr.AnalysData.DistrictTableAdapter = new base_nalogDataSetTableAdapters.Federal_districtTableAdapter();
            //cr.AnalysData.Var.DistrictTableAdapter.Fill(cr.AnalysData.Ds.Federal_district);
            //
            /*if (cr.AnalysData.Ds.Federal_district.Rows.Count < 1)
            {
                cr.AnalysData.DistrictTableAdapter = new base_nalogDataSetTableAdapters.Federal_districtTableAdapter();
                cr.AnalysData.DistrictTableAdapter.Fill(cr.AnalysData.Ds.Federal_district);
            }
            if (cr.AnalysData.Ds.Subjects.Rows.Count < 1) { cr.AnalysData.SubjectsTableAdapter = new base_nalogDataSetTableAdapters.SubjectsTableAdapter(); cr.AnalysData.SubjectsTableAdapter.Fill(cr.AnalysData.Ds.Subjects); }
            selectDataRf();*/
            //
            
        }
        private void fillYears()
        {
            string str = "";
            foreach (short year in cr.AnalysData.Var.ArrYears)
            {
                this.comboBoxYear.Items.Add(year);
                this.comboBoxYearSubjects.Items.Add(year);
                str = year.ToString();
            }
            
        }
        private void tabControlCommon_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectDataSubjects();
        }

        public void clearMapElements()
        {
            object item = new object();
            bool findItem = false;

            foreach (DataRow strDistrict in cr.AnalysData.Ds.Federal_district)
            {

                try
                {
                    item = mapControl.FindName(strDistrict[cr.ClNames.District_latin_name.nameSQL].ToString());
                    if (item != null) { findItem = true; }
                }
                catch (System.Exception ex)
                {
                    findItem = false;
                }
                if (findItem && item != null)
                {
                    System.Windows.Shapes.Shape sh = (System.Windows.Shapes.Shape)item;
                    System.Drawing.Color color = Color.White;
                    System.Windows.Media.Color mColor = System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
                    solidColorBr = new System.Windows.Media.SolidColorBrush(mColor);
                    solidColorBr.Color = mColor;
                    sh.Fill = solidColorBr;
                    item = sh;

                    System.Windows.Shapes.Path pth = (System.Windows.Shapes.Path)item;
                    pth.ToolTip = "";
                    item = pth;
                }
            }
            foreach (DataRow strSubject in cr.AnalysData.Ds.Subjects)
            {
                try
                {
                    item = mapControl.FindName(strSubject[cr.ClNames.Subject_latin_name.nameSQL].ToString());
                    if (item != null) { findItem = true; }
                }
                catch (System.Exception ex)
                {
                    findItem = false;
                }
                if (findItem && item!=null)
                {
                    System.Windows.Shapes.Shape sh = (System.Windows.Shapes.Shape)item;
                    System.Drawing.Color color = Color.White;
                    System.Windows.Media.Color mColor = System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
                    solidColorBr = new System.Windows.Media.SolidColorBrush(mColor);
                    solidColorBr.Color = mColor;
                    sh.Fill = solidColorBr;
                    item = sh;

                    System.Windows.Shapes.Path pth = (System.Windows.Shapes.Path)item;
                    pth.ToolTip = "";
                    item = pth;
                }
            }
        }

        private void FormAnalysisDataOnMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            cr.FrmAnalysisDataOnMap = null;
        }

        private void chHideBottomPanel_CheckedChanged(object sender, EventArgs e)
        {
            hideMorePanel(chHideBottomPanel.Checked);
        }
        private void hideMorePanel(bool hide)
        {
            if (hide) { chHideBottomPanel.Checked = true; } else { chHideBottomPanel.Checked = false; }
            if (hide)
            {
                splitContainer1.Panel2.Hide();
                chHideBottomPanel.Location = new System.Drawing.Point(3, chHideBottomPanel.Location.Y + splitContainer1.Panel2.Height);
                splitContainer1.SplitterDistance += splitContainer1.Panel2.Height;
                chHideBottomPanel.Refresh();

            }
            else
            {
                splitContainer1.Panel2.Show();
                splitContainer1.SplitterDistance = 495;
                chHideBottomPanel.Location = new System.Drawing.Point(3, chHideBottomPanel.Location.Y - splitContainer1.Panel2.Height);
                chHideBottomPanel.Refresh();
            }
        }
        private void FormAnalysisDataOnMap_ResizeEnd(object sender, EventArgs e)
        {
            /*chHideBottomPanel.Location = new System.Drawing.Point(3, chHideBottomPanel.Location.Y + (this.Height - frmHeight));
            chHideBottomPanel.Refresh();
            frmHeight = this.Height;
            frmWidth = this.Width;*/

        }

        private void FormAnalysisDataOnMap_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void FormAnalysisDataOnMap_Resize(object sender, EventArgs e)
        {
            /*if (this.WindowState == FormWindowState.Maximized)
            {
                chHideBottomPanel.Location = new System.Drawing.Point(3, chHideBottomPanel.Location.Y + (this.splitContainer1.Panel2.Height - pnael2Height) + (this.Height - frmHeight));
                chHideBottomPanel.Refresh();
                frmHeight = this.Height;
                frmWidth = this.Width;
                pnael2Height = this.splitContainer1.Panel2.Height;
                panel2Width = this.splitContainer1.Panel2.Width;
                maximized = true;
            }
            if (this.WindowState == FormWindowState.Minimized)
            {
                chHideBottomPanel.Location = new System.Drawing.Point(3, chHideBottomPanel.Location.Y + (this.splitContainer1.Panel2.Height - pnael2Height)+(this.Height - frmHeight));
                chHideBottomPanel.Refresh();
                frmHeight = this.Height;
                frmWidth = this.Width;
                pnael2Height = this.splitContainer1.Panel2.Height;
                panel2Width = this.splitContainer1.Panel2.Width;
            }*/
        }

        private void elementHost2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void comboBoxYearSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = cr.AnalysData.returnNullInt(comboBoxYearSubjects.SelectedItem);

            cr.AnalysData.Var.YearAfter = (short)year;
            cr.AnalysData.Var.YearBefore = (short)year;
            if ((cr.AnalysData.Var.YearBefore - cr.AnalysData.Var.YearAfter) > 1) { cr.AnalysData.Var.StrYears = cr.AnalysData.Var.YearAfter + " - " + cr.AnalysData.Var.YearBefore; } else { cr.AnalysData.Var.StrYears = " " + cr.AnalysData.Var.YearAfter; }
            selectDataSubjects();
        }

    }
}
