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
    public partial class FormChoiceParamAdvance : Form
    {
        private Classes.Core cr;
        private Controls.UserControlAnalysisDataDefault ucDefaultChoice;
        
        public FormChoiceParamAdvance(Classes.Core Cr)
        {
            InitializeComponent();
            this.cr = Cr;
            ucDefaultChoice = new Controls.UserControlAnalysisDataDefault(cr);
            this.Controls.Add(ucDefaultChoice);
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            setParams();
            //cr.FrmReportView = new FormReport();
            //cr.FrmReportView.Text=
            //cr.AnalysData.Var.NameTextReport = this.listBoxReports.Text;
            cr.FrmReportView = cr.AnalysData.SwitchReport(true,0);
            //cr.FrmReportView.Show();
            cr.FrmReportView.reportViewerData.Refresh();
            cr.FrmReportView.reportViewerData.RefreshReport();
            //cr.FrmReportView.reportViewerData.Show();
           // cr.FrmReportView.reportViewerData.ref
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
                    /*cr.AnalysData.Var.IdsSubjects = new int[ucDefaultChoice.listBoxSubjects.SelectedItems.Count];
                    cr.AnalysData.Var.StrSubjects = new string[ucDefaultChoice.listBoxSubjects.SelectedItems.Count];
                    for (int i = 0; i < ucDefaultChoice.listBoxSubjects.SelectedItems.Count; i++)
                    {
                        DataRowView rowView = (DataRowView)ucDefaultChoice.listBoxSubjects.SelectedItems[i];
                        cr.AnalysData.Var.IdsSubjects[i] = cr.AnalysData.returnNullInt(rowView.Row.ItemArray[0]);
                        cr.AnalysData.Var.StrSubjects[i] = rowView.Row.ItemArray[1].ToString();
                    }
                    if (ucDefaultChoice.listBoxSubjects.SelectedItems.Count == 1)
                    {
                        cr.AnalysData.Var.IdSubject = cr.AnalysData.Var.IdsSubjects[0];
                        cr.AnalysData.Var.StrSubject = cr.AnalysData.Var.StrSubjects[0];
                    }*/
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
            }
            catch (System.Exception err)
            {
                return;
            }
            try
            {
                //cr.AnalysData.Var.IdReport = Convert.ToInt32(this.listBoxReports.SelectedValue);
            }
            catch (System.Exception err)
            {
            }
            cr.AnalysData.Var.IsYears = this.ucDefaultChoice.checkBoxYears.Checked;
            cr.AnalysData.Var.IsIdSubject = this.ucDefaultChoice.checkBoxSubject.Checked;
            cr.AnalysData.Var.IsIdTax = this.ucDefaultChoice.checkBoxTax.Checked;
            cr.AnalysData.Var.IsIdEea = this.ucDefaultChoice.checkBoxTaxEea.Checked;
            cr.AnalysData.Var.IsYears = this.ucDefaultChoice.checkBoxYears.Checked;
            //
            cr.AnalysData.Var.StrDistrict = this.ucDefaultChoice.comboBoxDistrict.Text.ToString();
            cr.AnalysData.Var.StrTax = this.ucDefaultChoice.comboBoxTaxes.Text.ToString();
            cr.AnalysData.Var.StrEea = this.ucDefaultChoice.comboBoxTaxesEea.Text.ToString();
        }
    }
}
