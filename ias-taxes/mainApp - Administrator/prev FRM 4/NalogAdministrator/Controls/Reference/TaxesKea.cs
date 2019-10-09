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
    public partial class TaxesKea : UserControl
    {
        public TaxesKea()
        {
            InitializeComponent();
            this.taxes_vedTableAdapter.Fill(this.base_nalogDataSet.Taxes_ved);
        }

        private void taxes_vedBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.taxes_vedBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);

        }
    }
}
