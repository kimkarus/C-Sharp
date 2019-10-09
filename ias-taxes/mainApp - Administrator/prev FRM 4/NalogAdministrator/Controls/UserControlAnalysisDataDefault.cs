using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Controls
{
    public partial class UserControlAnalysisDataDefault : UserControl
    {
        private Classes.Core cr;
        public UserControlAnalysisDataDefault(Classes.Core Cr)
        {
            this.cr = Cr;
            //this.base_nalogDataSet = cr.AnalysData.Ds;
            InitializeComponent();

            /*foreach (short year in cr.AnalysData.Var.ArrYears)
            {
                this.comboBoxYearAfter.Items.Add(year);
                this.comboBoxYearBefore.Items.Add(year);
            }*/
        }

        private void checkBoxDistrict_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxDistrict.Checked) { this.comboBoxDistrict.Enabled = true; subjectsBindingSource.Filter = "id_district=" + comboBoxDistrict.SelectedValue; }
            else { this.comboBoxDistrict.Enabled = false; cr.ImportData.Var.IdDistrict = 0; subjectsBindingSource.Filter = ""; }
        }

        private void checkBoxSubject_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxSubject.Checked) { this.comboBoxSubjetcs.Enabled = false; cr.ImportData.Var.IdSubject = 0; }
            this.comboBoxSubjetcs.Enabled = this.checkBoxSubject.Checked;
        }

        private void checkBoxTax_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxTax.Checked) { this.comboBoxTaxes.Enabled = true; } else { this.comboBoxTaxes.Enabled = false; cr.ImportData.Var.IdTax = 0; }
        }

        private void checkBoxYears_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxYears.Checked) { this.comboBoxYearBefore.Enabled = true; this.comboBoxYearAfter.Enabled = true; }
            else { this.comboBoxYearAfter.Enabled = false; this.comboBoxYearBefore.Enabled = false; cr.ImportData.Var.YearAfter = 0; cr.ImportData.Var.YearBefore = 0; }
            comboBoxYearBefore.SelectedIndex = comboBoxYearAfter.SelectedIndex;
        }

        private void checkBoxTaxEea_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxTaxEea.Checked) { this.comboBoxTaxesEea.Enabled = true; } else { this.comboBoxTaxesEea.Enabled = false; cr.ImportData.Var.IdEea = 0; }
        }

        private void UserControlAnalysisDataDefault_Load(object sender, EventArgs e)
        {
            //this.base_nalogDataSet.Taxes.Rows.
            // TODO: This line of code loads data into the 'base_nalogDataSet.Taxes_ved' table. You can move, or remove it, as needed.
            this.taxes_vedTableAdapter.Fill(this.base_nalogDataSet.Taxes_ved);
            // TODO: This line of code loads data into the 'base_nalogDataSet.Taxes' table. You can move, or remove it, as needed.
            this.taxesTableAdapter.Fill(this.base_nalogDataSet.Taxes);
            // TODO: This line of code loads data into the 'base_nalogDataSet.Subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.base_nalogDataSet.Subjects);
            subjectsBindingSource.Sort = "subject_name";
            // TODO: This line of code loads data into the 'base_nalogDataSet.Federal_district' table. You can move, or remove it, as needed.
            this.federal_districtTableAdapter.Fill(this.base_nalogDataSet.Federal_district);
            federaldistrictBindingSource.Sort = "district_name";
            //

        }

        private void comboBoxYearAfter_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxYearBefore.SelectedIndex = comboBoxYearAfter.SelectedIndex;
        }

        private void comboBoxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            subjectsBindingSource.Filter = "id_district=" + comboBoxDistrict.SelectedValue;
        }

    }
}
