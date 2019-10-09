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
    public partial class Taxes : UserControl
    {
        public Taxes()
        {
            InitializeComponent();
            this.taxes_viewTableAdapter.Fill(this.base_nalogDataSet.Taxes_view);
            this.taxesTableAdapter.Fill(this.base_nalogDataSet.Taxes);
        }

        private void comboBoxTaxesView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.id_viewTextBox.Text = this.comboBoxTaxesView.SelectedValue.ToString();
        }

    }
}
