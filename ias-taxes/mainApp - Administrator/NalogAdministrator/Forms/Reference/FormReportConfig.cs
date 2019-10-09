using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Forms.Reference
{
    public partial class FormReportConfig : Form
    {
        public FormReportConfig()
        {
            InitializeComponent();
        }

        private void reportsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.reportsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);

        }

        private void FormReportConfig_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'base_nalogDataSet.Reports' table. You can move, or remove it, as needed.
            this.reportsTableAdapter.Fill(this.base_nalogDataSet.Reports);

        }
    }
}
