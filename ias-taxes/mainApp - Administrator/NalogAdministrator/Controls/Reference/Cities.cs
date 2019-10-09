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
    public partial class Cities : UserControl
    {
        public Cities()
        {
            InitializeComponent();
            this.federal_districtTableAdapter.Fill(this.base_nalogDataSet.Federal_district);
            this.subjectsTableAdapter.Fill(this.base_nalogDataSet.Subjects);
            this.cityTableAdapter.Fill(this.base_nalogDataSet.City);
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.id_subjectTextBox.Text = this.comboBoxSubject.SelectedValue.ToString();
        }
    }
}
