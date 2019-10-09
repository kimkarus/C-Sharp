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
    public partial class Subjects : UserControl
    {
        public Subjects()
        {
            InitializeComponent();
            this.federal_districtTableAdapter.Fill(this.base_nalogDataSet.Federal_district);
            this.subjectsTableAdapter.Fill(this.base_nalogDataSet.Subjects);
        }

        private void subjectsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.subjectsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);

        }
    }
}
