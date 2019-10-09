using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void source_data_Population_eeaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.source_data_Population_eeaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base_nalogDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'base_nalogDataSet.Source_data_Population_eea' table. You can move, or remove it, as needed.
            this.source_data_Population_eeaTableAdapter.Fill(this.base_nalogDataSet.Source_data_Population_eea);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }
    }
}
