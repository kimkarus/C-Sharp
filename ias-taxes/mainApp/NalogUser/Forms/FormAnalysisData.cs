using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogUser.Forms
{
    public partial class FormAnalysisData : Form
    {
        private Classes.Core cr;
        private int idReportType;
        private Controls.UserControlAnalysisDataDefault ucDefaultChoice;
        private Forms.FormAnalysisDataOnMap frmAnDataMap;
        private bool selectReport = false;
        //public Controls.UserControlAnalysisDataDefault UcDefaultChoice { get { return ucDefaultChoice; } set { ucDefaultChoice = value; } }
        public FormAnalysisData(Classes.Core Cr, int type_report)
        {
            InitializeComponent();
            this.cr = Cr;
            this.idReportType = type_report;
            //cr.FrmReportView = new FormReport(cr);
            ucDefaultChoice = new Controls.UserControlAnalysisDataDefault(cr);
            this.groupBoxParams.Controls.Add(ucDefaultChoice);
            cr.AnalysData = new Classes.AnalysisData.AnalysisData(cr, base_nalogDataSet, this);
            ucDefaultChoice.comboBoxYearAfter.Text = cr.AnalysData.Var.YearAfter.ToString();
            ucDefaultChoice.comboBoxYearBefore.Text = cr.AnalysData.Var.YearBefore.ToString();
        }

        private void FormAnalysisData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'base_nalogDataSet.Reports' table. You can move, or remove it, as needed.
            if (NalogUser.App.Default.Username.ToString() != "admin")
            {
                this.reportsTableAdapter.FillBy1(this.base_nalogDataSet.Reports, true);
            }
            else
            {
                this.reportsTableAdapter.Fill(this.base_nalogDataSet.Reports);
            }
            // TODO: This line of code loads data into the 'base_nalogDataSet.Report_view' table. You can move, or remove it, as needed.
            this.report_viewTableAdapter.Fill(this.base_nalogDataSet.Report_view);
            // TODO: This line of code loads data into the 'base_nalogDataSet.Report_view' table. You can move, or remove it, as needed.
            this.report_viewTableAdapter.Fill(this.base_nalogDataSet.Report_view);
            ucDefaultChoice.comboBoxDistrict.SelectedValue = 1;
            if (this.base_nalogDataSet.Reports.Rows.Count > 0)
            {
                this.fKReportsReportview1BindingSource.Filter = "id_report_type=" + idReportType + " and enable<>false";
            }
            // TODO: This line of code loads data into the 'base_nalogDataSet.Report_view' table. You can move, or remove it, as needed.
            this.base_nalogDataSet.EnforceConstraints = false;
            //
            //cr.AnalysData.Ds = this.base_nalogDataSet;
            //cr.AnalysData.Var.IdReport = Convert.ToInt32(this.listBoxReports.SelectedValue);
            
            cr.AnalysData.Var.IdDistrict = Convert.ToInt32(ucDefaultChoice.comboBoxDistrict.SelectedValue);
            cr.AnalysData.Var.YearBefore = Convert.ToInt16(ucDefaultChoice.comboBoxYearBefore.Text);
            ucDefaultChoice.comboBoxYearBefore.Text = cr.AnalysData.Var.YearBefore.ToString();
            ucDefaultChoice.comboBoxYearAfter.Text = cr.AnalysData.Var.YearAfter.ToString();
            //setDefaultIDReport();
        }

        private void listBoxReports_Click(object sender, EventArgs e)
        {
            cr.AnalysData.Var.IdReport = Convert.ToInt32(this.listBoxReports.SelectedValue);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cr.AnalysData.Var.IdDistrict = Convert.ToInt32(ucDefaultChoice.comboBoxDistrict.SelectedValue);
        }

        private void comboBoxYearAfter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cr.AnalysData.Var.YearAfter = Convert.ToInt16(ucDefaultChoice.comboBoxYearAfter.Text);
            }
            catch (System.Exception err)
            {
            }
        }

        private void comboBoxYearBefore_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cr.AnalysData.Var.YearBefore = Convert.ToInt16(ucDefaultChoice.comboBoxYearBefore.Text);
            }
            catch (System.Exception err)
            {
            }
        }

        private void cmbTaxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cr.AnalysData.Var.IdTax = Convert.ToInt32(ucDefaultChoice.comboBoxTaxes.SelectedValue);
            }
            catch (System.Exception err)
            {
            }
        }

        private void setParams()
        {
            try
            {
                if (ucDefaultChoice.checkBoxDistrict.Checked)
                {
                    cr.AnalysData.Var.IdDistrict = Convert.ToInt32(ucDefaultChoice.comboBoxDistrict.SelectedValue);
                }
                else
                {
                    cr.AnalysData.Var.IdDistrict = 0;
                }
                if (ucDefaultChoice.checkBoxSubject.Checked)
                {
                    cr.AnalysData.Var.IdSubject = cr.AnalysData.returnNullInt(ucDefaultChoice.comboBoxSubjetcs.SelectedValue);
                    cr.AnalysData.Var.StrSubject = ucDefaultChoice.comboBoxSubjetcs.Text;
                }
                else
                {
                    cr.AnalysData.Var.IdSubject = 0;
                    cr.AnalysData.Var.StrSubject = "";
                }
                if (ucDefaultChoice.checkBoxTax.Checked)
                {
                    cr.AnalysData.Var.IdTax = Convert.ToInt32(ucDefaultChoice.comboBoxTaxes.SelectedValue);
                }
                else
                {
                    cr.AnalysData.Var.IdTax = 0;
                }
                if (ucDefaultChoice.checkBoxTaxEea.Checked)
                {
                    cr.AnalysData.Var.IdEea = Convert.ToInt32(ucDefaultChoice.comboBoxTaxesEea.SelectedValue);
                }
                else
                {
                    cr.AnalysData.Var.IdEea = 0;
                }
                if (ucDefaultChoice.checkBoxYears.Checked)
                {
                    cr.AnalysData.Var.YearBefore = Convert.ToInt16(ucDefaultChoice.comboBoxYearBefore.Text);
                    cr.AnalysData.Var.YearAfter = Convert.ToInt16(ucDefaultChoice.comboBoxYearAfter.Text);
                }
                else
                {
                    cr.AnalysData.Var.YearBefore = 0;
                    cr.AnalysData.Var.YearAfter = 0;
                }
                if (ucDefaultChoice.checkBoxBudget.Checked)
                {
                    cr.AnalysData.Var.IdBudget = Convert.ToInt32(ucDefaultChoice.comboBoxBudgets.SelectedValue);
                }
                else
                {
                    cr.AnalysData.Var.IdBudget = 0;
                }
            }
            catch (System.Exception err)
            {
                return;
            }
            try
            {
                cr.AnalysData.Var.IdReport = Convert.ToInt32(this.listBoxReports.SelectedValue);
            }
            catch (System.Exception err)
            {
            }
            //
            cr.AnalysData.Var.IsYears = this.ucDefaultChoice.checkBoxYears.Checked;
            cr.AnalysData.Var.IsIdSubject = this.ucDefaultChoice.checkBoxSubject.Checked;
            cr.AnalysData.Var.IsIdTax = this.ucDefaultChoice.checkBoxTax.Checked;
            cr.AnalysData.Var.IsIdEea = this.ucDefaultChoice.checkBoxTaxEea.Checked;
            cr.AnalysData.Var.IsYears = this.ucDefaultChoice.checkBoxYears.Checked;
            cr.AnalysData.Var.IsBudget = this.ucDefaultChoice.checkBoxBudget.Checked;
            //
            cr.AnalysData.Var.StrDistrict = this.ucDefaultChoice.comboBoxDistrict.Text.ToString();
            cr.AnalysData.Var.StrTax = this.ucDefaultChoice.comboBoxTaxes.Text.ToString();
            cr.AnalysData.Var.StrEea = this.ucDefaultChoice.comboBoxTaxesEea.Text.ToString();
            //
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (!selectReport)
            {
                MessageBox.Show("Выберите вариант отчета");
            }
            else
            {
                Classes.TimeWatcher t = new Classes.TimeWatcher();
                setParams();
                //cr.FrmReportView = new FormReport(cr);
                //cr.FrmReportView.Text=
                cr.AnalysData.Var.NameTextReport = this.listBoxReports.Text;
                /*ЗАХУЯРИТЬ УСЛОВИЯ на ноль*/

                cr.FrmReportView = cr.AnalysData.SwitchReport(true, 0);
                if (checkVilidateSourceData())
                {
                    cr.FrmReportView.Show();
                    cr.FrmReportView.reportViewerData.RefreshReport();
                    cr.FrmReportView.reportViewerData.Update();
                    //
                    if (checkBoxSetOnMap.Checked)
                    {
                        if (chechParamsForMap())
                        {
                            if (this.ucDefaultChoice.checkBoxTax.Checked)
                            {
                                cr.AnalysData.Var.StrNameTextSelectedTax = this.ucDefaultChoice.comboBoxTaxes.Text;
                            }
                            if (this.ucDefaultChoice.checkBoxTaxEea.Checked)
                            {
                                cr.AnalysData.Var.StrNameTextSelectedTax = this.ucDefaultChoice.comboBoxTaxesEea.Text;
                            }
                            frmAnDataMap = new FormAnalysisDataOnMap(cr, true);
                            frmAnDataMap.MdiParent = this.MdiParent;
                            frmAnDataMap.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Недостаточно данных для вывода");
                }
                if (this.checkBoxSpreading.Checked)
                {
                    Forms.FormSpreading frmSpr = new FormSpreading(cr);
                    frmSpr.MdiParent = this.MdiParent;
                    frmSpr.Show();
                }
                this.textBoxError.Clear();
                t.StopTimer();
                textBoxError.Text = t.LeftSeconds + " секунд";
            }

        }
        private void listBoxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!selectReport)
            //{
                setReport();
            //}
        }
        private void listBoxReports_Click_1(object sender, EventArgs e)
        {
            try
            {
                cr.AnalysData.Var.IdReport = Convert.ToInt32(this.listBoxReports.SelectedValue);
            }
            catch (System.Exception err)
            {
            }
        }
        private bool chechParamsForMap()
        {
            bool y = false;
            //Поверка введеных параметров пользователем и возможность использования выбранного отчета для наложения на карту РФ
            //Шаг 1
            if (cr.AnalysData.GetItForMap())
            {
                //Шаг 2
                //Проверяем год
                if (cr.AnalysData.Var.YearBefore != cr.AnalysData.Var.YearAfter)
                {
                    textBoxError.Clear();
                    textBoxError.Text = "Неверно указан год. Укажите один год";
                }
                else
                {
                    //Шаг 3
                    if (cr.AnalysData.GetCountField() > 1)
                    {
                        //Шаг 4
                        if (cr.AnalysData.GetXmlType() == "eea")
                        {
                            if (ucDefaultChoice.checkBoxTaxEea.Checked)
                            {
                                y = true;
                            }
                            else
                            {
                                textBoxError.Clear();
                                textBoxError.Text = "Выберите один пункт ВЭД";
                            }
                        }
                        if (cr.AnalysData.GetXmlType() == "tax")
                        {
                            if (ucDefaultChoice.checkBoxTax.Checked)
                            {
                                y = true;
                            }
                            else
                            {
                                textBoxError.Clear();
                                textBoxError.Text = "Выберите один пункт Налоги";
                            }
                        }

                    }
                    if (cr.AnalysData.GetCountField() == 1) { y = true; }
                    
                }
            }
            else
            {
                textBoxError.Clear();
                textBoxError.Text = "Невозможно наложить данные на карту";
            }

            return y;

        }

        private void FormAnalysisData_FormClosed(object sender, FormClosedEventArgs e)
        {
            cr.CloseForm(this);
        }

        private bool checkVilidateSourceData()
        {
            bool valid = false;
            if (cr.AnalysData.Var.SourceTable.Rows.Count > 0) { valid = true; } else { valid = false; }
            return valid;
        }

        private void comboBoxReportView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.reportsTableAdapter.ClearBeforeFill = true;
            
            //this.base_nalogDataSet.Reports.Clear();
            
            //this.reportsTableAdapter.FillBy(this.base_nalogDataSet.Reports, cr.AnalysData.returnNullInt(this.comboBoxReportView.SelectedValue), idReportType);
            if (this.base_nalogDataSet.Reports.Rows.Count > 0)
            {
                this.fKReportsReportview1BindingSource.Filter = "id_report_type=" + idReportType + " and enable<>false";
            }
        }

        private void comboBoxListValuesForMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            cr.AnalysData.Var.NameParam = comboBoxListValuesForMap.SelectedItem.ToString();
        }

        private void checkBoxSetOnMap_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxListValuesForMap.SelectedIndex = 0;
        }

        private void checkBoxSpreading_CheckedChanged(object sender, EventArgs e)
        {
            this.buttonSpreading.Enabled = this.checkBoxSpreading.Checked;
        }

        private void buttonSpreading_Click(object sender, EventArgs e)
        {
            Forms.FormParamsSpreading frmSprParams = new FormParamsSpreading(cr);
            frmSprParams.MdiParent = this.MdiParent;
            frmSprParams.Show();
        }

        private void setReport()
        {
            string er = "";
            try
            {
                string documentText = "";
                DataRowView drv = (DataRowView)this.listBoxReports.SelectedItem;
                cr.AnalysData.readXmlParams(drv.Row[base_nalogDataSet.Reports.report_settingsColumn].ToString());
                cr.AnalysData.Var.IdReport = Convert.ToInt32(this.listBoxReports.SelectedValue);
                documentText = drv.Row[base_nalogDataSet.Reports.discription_htmlColumn].ToString();
                if (documentText.Length > 0)
                {
                    webBrowserDisription.DocumentText = documentText;
                }
                else
                {
                    webBrowserDisription.DocumentText = documentText;
                }
                //drv = (DataRowView)this.listBoxReports.SelectedItem;
                //cr.AnalysData.readXmlParams(ds.Reports.FindByid(var.IdReport)[ds.Reports.discription_htmlColumn].ToString());

            }
            catch (System.Exception err)
            {
                er = err.Message.ToString();
                selectReport = false;
            }
            finally
            {
                if (er.Length <= 0)
                {
                    selectReport = true;
                }
            }
            comboBoxListValuesForMap.Items.Clear();
            if (cr.AnalysData.Var.ArrayParamsXML != null)
            {
                comboBoxListValuesForMap.Items.AddRange(cr.AnalysData.Var.ArrayParamsXML);
                comboBoxListValuesForMap.SelectedIndex = 0;
            }
            if (this.comboBoxListValuesForMap.Items.Count > 0)
            {
                cr.AnalysData.Var.NameParam = this.comboBoxListValuesForMap.Items[0].ToString();
            }
        }
        private void setDefaultIDReport()
        {
            if (this.listBoxReports.Items.Count > 0)
            {
                this.listBoxReports.SelectedIndex = 0;
                setReport();
            }
        }
    }
}
