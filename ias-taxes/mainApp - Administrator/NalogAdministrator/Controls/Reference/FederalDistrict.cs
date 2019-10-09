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
    public partial class FederalDistrict : UserControl
    {
        public FederalDistrict()
        {
            InitializeComponent();
            this.federal_districtTableAdapter.Fill(this.base_nalogDataSet.Federal_district);
            this.subjectsTableAdapter.Fill(this.base_nalogDataSet.Subjects);
        }

        private void federal_districtBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.federal_districtBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Close();
        }
    }
}
