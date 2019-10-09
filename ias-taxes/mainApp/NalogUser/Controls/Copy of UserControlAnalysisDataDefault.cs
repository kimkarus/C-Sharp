using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogUser.Controls
{
    public partial class UserControlAnalysisDataDefault : UserControl
    {
        private Classes.Core cr;
        public UserControlAnalysisDataDefault(Classes.Core Cr)
        {
            this.cr = Cr;
            //this.base_nalogDataSet = cr.AnalysData.Ds;
            InitializeComponent();

            foreach (short year in cr.AnalysData.Var.ArrYears)
            {
                this.comboBoxYearAfter.Items.Add(year);
                this.comboBoxYearBefore.Items.Add(year);
            }
        }

        private void checkBoxDistrict_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxDistrict.Checked) { this.comboBoxDistrict.Enabled = true; subjectsBindingSource.Filter = "id_district=" + comboBoxDistrict.SelectedValue; }
            else { this.comboBoxDistrict.Enabled = false; cr.AnalysData.Var.IdDistrict = 0; subjectsBindingSource.Filter = ""; }
        }

        private void checkBoxSubject_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxSubject.Checked) { this.comboBoxSubjetcs.Enabled = false; cr.AnalysData.Var.IdSubject = 0; cr.AnalysData.Var.IdsSubjects = null; }
            this.comboBoxSubjetcs.Enabled = this.checkBoxSubject.Checked;
            this.buttonSelectSubjects.Enabled = this.checkBoxSubject.Checked;
        }

        private void checkBoxTax_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxTax.Checked) { this.comboBoxTaxes.Enabled = true; } else { this.comboBoxTaxes.Enabled = false; cr.AnalysData.Var.IdTax = 0; cr.AnalysData.Var.IdsTaxes = null; }
        }

        private void checkBoxYears_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxYears.Checked) { this.comboBoxYearBefore.Enabled = true; this.comboBoxYearAfter.Enabled = true; }
            else { this.comboBoxYearAfter.Enabled = false; this.comboBoxYearBefore.Enabled = false; cr.AnalysData.Var.YearAfter = 0; cr.AnalysData.Var.YearBefore = 0; }
            comboBoxYearBefore.SelectedIndex = comboBoxYearAfter.SelectedIndex;
        }

        private void checkBoxTaxEea_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxTaxEea.Checked) { this.comboBoxTaxesEea.Enabled = true; } else { this.comboBoxTaxesEea.Enabled = false; cr.AnalysData.Var.IdEea = 0; cr.AnalysData.Var.IdsEea = null; }
        }

        private void UserControlAnalysisDataDefault_Load(object sender, EventArgs e)
        {
            //this.base_nalogDataSet.Taxes.Rows.
            // TODO: This line of code loads data into the 'base_nalogDataSet.Taxes_ved' table. You can move, or remove it, as needed.
            this.taxes_vedTableAdapter.Fill(this.base_nalogDataSet.Taxes_ved);
            // TODO: This line of code loads data into the 'base_nalogDataSet.Taxes' table. You can move, or remove it, as needed.
            this.taxesTableAdapter1.Fill(this.base_nalogDataSet.Taxes);
            // TODO: This line of code loads data into the 'base_nalogDataSet.Subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.base_nalogDataSet.Subjects);
            subjectsBindingSource.Sort = "subject_name";
            // TODO: This line of code loads data into the 'base_nalogDataSet.Federal_district' table. You can move, or remove it, as needed.
            this.federal_districtTableAdapter.Fill(this.base_nalogDataSet.Federal_district);
            federaldistrictBindingSource.Sort = "district_name";

            for (int i = 0; i < this.base_nalogDataSet.Federal_district.Count; i++)
            {
                cr.AnalysData.Var.ArrFederalDistricts.Add(this.base_nalogDataSet.Federal_district.Rows[i]["latin_name"].ToString());
            }
            //

        }

        private void buttonSelectSubjects_Click(object sender, EventArgs e)
        {
            OpenFormForSelectParams(this.subjectsBindingSource, this.comboBoxSubjetcs.DisplayMember, this.comboBoxSubjetcs.ValueMember, "s");
        }
        private void OpenFormForSelectParams(BindingSource bs, string DisplayMember, string ValueMember, string Type)
        {
            Forms.FormParams frmParams = new Forms.FormParams(cr, bs, DisplayMember, ValueMember, Type);
            frmParams.MdiParent = cr.FrmApp;
            frmParams.Show();
        }

        private void comboBoxSubjetcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            cr.AnalysData.Var.IdsSubjects = null;
            cr.AnalysData.Var.StrSubjects = null;
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
