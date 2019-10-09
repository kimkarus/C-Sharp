using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Controls
{
    public partial class UserControlImportDataPopulation : UserControl
    {
        private Classes.Core cr;

        private ImportData.ComponentImportData commImpData;
        public UserControlImportDataPopulation(Classes.Core Cr)
        {
            this.cr = Cr;
            commImpData = new ImportData.ComponentImportData();
            InitializeComponent();
        }

        private void btSelectFolderData_Click(object sender, EventArgs e)
        {
            if (commImpData.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFolderData.Text = commImpData.openFileDialog.FileName.ToString();
                listFilesViewVoid();
            }
        }
        private void listFilesViewVoid()
        {
            cr.ImportData.ListPathFiles.Add(this.txtFolderData.Text);
            cr.ImportData.Var.PathFile = this.txtFolderData.Text;
            this.listTablesView.Items.Clear();
            foreach (string list in cr.ImportData.GetListSheets(0))
            {
                this.listTablesView.Items.Add(list);
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (chAddEea.Checked)
            {
                cr.ImportData.ImpPopulation.AddRecordsEea(this.listTablesView.Items[this.listTablesView.SelectedIndex].ToString());
            }
            else
            {
                cr.ImportData.ImpPopulation.AddRecords(this.listTablesView.Items[this.listTablesView.SelectedIndex].ToString());
            }
        }

        private void listTablesView_Click(object sender, EventArgs e)
        {
            cr.ImportData.Var.TakeIntervalOleDb(cr.ImportData.Var.PathFile, this.listTablesView.Items[this.listTablesView.SelectedIndex].ToString());
            this.dataGridViewPopulation.DataSource = cr.ImportData.Var.InternalTable;
        }

        private void btAddDb_Click(object sender, EventArgs e)
        {
            cr.ImportData.ImpPopulation.UpdateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
