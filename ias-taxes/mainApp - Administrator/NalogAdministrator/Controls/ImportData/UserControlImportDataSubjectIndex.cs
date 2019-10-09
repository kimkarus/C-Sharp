using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Controls.ImportData
{
    public partial class UserControlImportDataSubjectIndex : UserControl
    {
        private Classes.Core cr;

        private ImportData.ComponentImportData commImpData;
        public UserControlImportDataSubjectIndex(Classes.Core Cr)
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

        private void btStart_Click(object sender, EventArgs e)
        {
            //
            string tagIndex = "";
           // if (radioButtonCPI.Checked) tagIndex = radioButtonCPI.Tag.ToString();
           // if (radioButtonDRP.Checked) tagIndex = radioButtonDRP.Tag.ToString();
            //
            cr.ImportData.ImpSubjectIndex.AddRecords(this.listTablesView.Items[this.listTablesView.SelectedIndex].ToString(), tagIndex);
        }

        private void radioButtonDevide100_CheckedChanged(object sender, EventArgs e)
        {
            setParamDevideMultiply(radioButtonDevide100.Tag.ToString());
        }

        private void radioButtonNone_CheckedChanged(object sender, EventArgs e)
        {
            setParamDevideMultiply(radioButtonNone.Tag.ToString());
        }
        private void setParamDevideMultiply(string tag)
        {
            string[] strParams = tag.Split(';');
            if (strParams.Length < 2)
            {
                cr.ImportData.Var.IsMultiplyValue = false;
                cr.ImportData.Var.IsDevideValue = false;
            }
            else
            {
                if (strParams[1] == "m")
                {
                    cr.ImportData.Var.IsMultiplyValue = true;
                    cr.ImportData.Var.IsDevideValue = false;
                    cr.ImportData.Var.DevideMultiplyValue = cr.ImportData.returnNullInt(strParams[0]);
                }
                else if (strParams[1] == "d")
                {
                    cr.ImportData.Var.IsMultiplyValue = false;
                    cr.ImportData.Var.IsDevideValue = true;
                    cr.ImportData.Var.DevideMultiplyValue = cr.ImportData.returnNullInt(strParams[0]);
                }
                else
                {
                    cr.ImportData.Var.IsMultiplyValue = false;
                    cr.ImportData.Var.IsDevideValue = false;
                }
            }
        }

        private void radioButtonВумшву1000_CheckedChanged(object sender, EventArgs e)
        {
            setParamDevideMultiply(radioButtonВумшву1000.Tag.ToString());
        }

        private void radioButtonMultiply100_CheckedChanged(object sender, EventArgs e)
        {
            setParamDevideMultiply(radioButtonMultiply100.Tag.ToString());
        }

        private void radioButtonMultiply1000_CheckedChanged(object sender, EventArgs e)
        {
            setParamDevideMultiply(radioButtonMultiply1000.Tag.ToString());
        }
    }
}
