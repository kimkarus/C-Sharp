using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Forms
{
    public partial class FormSearch : Form
    {
        private Control cntrl;
        private DataTable dt;
        private BindingSource bs;
        private string[] needViewColumn;
        //private Tablea
        public FormSearch(Control Ctrl, BindingSource Bs, string[] NeedViewColumn)
        {
            InitializeComponent();
            this.cntrl = Ctrl;
            this.bs = Bs;
            this.needViewColumn = NeedViewColumn;
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'base_nalogDataSet.Reports' table. You can move, or remove it, as needed.
            dataGridView.DataSource = bs;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                int countNeed = 0;
                for (int i = 0; i < needViewColumn.Length; i++)
                {
                    if (column.Name == needViewColumn[i])
                    {
                        countNeed++;
                    }
                }
                if (countNeed > 0)
                {
                    column.Visible = true;
                    int index = column.Index;
                    switch (column.Name)
                    {
                        case "id":
                            {
                                column.HeaderText = "Код";
                                column.Width = 45;
                                break;
                            }
                        case "name":
                            {
                                column.HeaderText = "Название";
                                column.Width = 600;
                                break;
                            }

                    }
                    
                }
                else
                {
                    column.Visible = false;
                }
            }

        }

        private void dataGridViewReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
