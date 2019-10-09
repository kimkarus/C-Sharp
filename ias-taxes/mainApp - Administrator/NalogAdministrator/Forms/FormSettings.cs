using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            //this.txtConnectionString.Text = NalogAdministrator.Properties.Settings.Default.base_nalogConnectionString.ToString();
            //this.txtConnectionString.Text = this.txtConnectionString.Tag.ToString();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            //NalogAdministrator.Properties.Settings.Default.base_nalogConnectionString. = this.txtConnectionString.Text;
        }
    }
}
