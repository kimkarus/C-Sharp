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
    public partial class TaxAuthority : UserControl
    {
        public TaxAuthority()
        {
            InitializeComponent();
        }

        private void tax_authorityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tax_authorityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);

        }
    }
}
