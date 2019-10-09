using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Controls.Reference
{
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
            this.report_typeTableAdapter.Fill(this.base_nalogDataSet.Report_type);
            this.report_viewTableAdapter.Fill(this.base_nalogDataSet.Report_view);
            this.reportsTableAdapter.Fill(this.base_nalogDataSet.Reports);
        }

        private void reportsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.reportsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private void id_report_viewComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.id_report_viewComboBox.Text = this.id_report_viewComboBox.SelectedValue.ToString();
            //this.textBox1.Text = this.id_report_viewComboBox.SelectedValue.ToString();
            //this.base_nalogDataSet.Reports.FindByid(Convert.ToInt32(this.idTextBox));
            //this.id_report_viewComboBox.Text = this.id_report_viewComboBox.SelectedValue.ToString();
            //this.id_report_viewComboBox.ValueMember = this.id_report_viewComboBox.SelectedValue.ToString();
        }

        private void comboBoxIdReportView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxIdReportView != null)
            {
                if (this.comboBoxIdReportView.SelectedValue != null)
                {
                    this.id_report_viewTextBox.Text = this.comboBoxIdReportView.SelectedValue.ToString();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxIdType != null)
            {
                if (this.comboBoxIdType.SelectedValue != null)
                {
                    this.id_report_typeTextBox.Text = this.comboBoxIdType.SelectedValue.ToString();
                }
            }
        }

        private void toolStripButtonSearchList_Click(object sender, EventArgs e)
        {
            string[] needViewColumn = { "id", "name" };
            Forms.FormSearch frmSrch = new Forms.FormSearch(this, reportsBindingSource, needViewColumn);
            frmSrch.Show();
        }
    }
}
