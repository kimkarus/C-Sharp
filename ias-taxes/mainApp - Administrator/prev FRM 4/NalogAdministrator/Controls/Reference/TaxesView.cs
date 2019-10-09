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
    public partial class TaxesView : UserControl
    {
        public TaxesView()
        {
            InitializeComponent();
            this.taxes_viewTableAdapter.Fill(this.base_nalogDataSet.Taxes_view);
            this.taxesTableAdapter.Fill(this.base_nalogDataSet.Taxes);
        }

        private void TaxesView_Load(object sender, EventArgs e)
        {

        }

        private void taxes_viewBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.taxes_viewBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);

        }
    }
}
