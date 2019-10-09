using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Forms
{
    public partial class FormTableView : Form
    {
        public FormTableView(DataTable dt)
        {
            InitializeComponent();
            this.dataGridViewSourceTable.DataSource = dt;
        }
    }
}
