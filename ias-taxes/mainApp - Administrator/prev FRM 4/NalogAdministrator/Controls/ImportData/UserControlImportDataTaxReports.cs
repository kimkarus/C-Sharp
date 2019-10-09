using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NalogAdministrator.Controls
{
    public partial class UserControlImportDataReportDefaultTools : UserControl
    {
        private Classes.Core cr;
        private Forms.FormTableView frmTableView;
        private ImportData.ComponentImportData commImpData;
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter = new base_nalogDataSetTableAdapters.SubjectsTableAdapter();
        

        public UserControlImportDataReportDefaultTools(Classes.Core Cr)
        {
            this.cr = Cr;
            commImpData = new ImportData.ComponentImportData();
            InitializeComponent();
        }
        private void UserControlImportDataReportDefaultTools_Load(object sender, EventArgs e)
        {
            this.subjectsTableAdapter.Fill(cr.Data.Base.Ds.Subjects);
            this.subjectsBindingSource.DataSource = cr.Data.Base.Ds.Subjects;
        }
        private void btSelectFolderData_Click(object sender, EventArgs e)
        {
            if (commImpData.selectFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFolderData.Text = commImpData.selectFolderBrowserDialog.SelectedPath.ToString();
            }
        }
        private void btLoadFolders_Click(object sender, EventArgs e)
        {
            /*
             * Показываем все папки и файлы
             * */
            this.FoldersDataTreeView.Nodes.Clear();
            this.FoldersDataTreeView.Nodes.Add(cr.ImportData.GetTreeNode(this.txtFolderData.Text));
            cr.ImportData.GetListFiles(this.txtFolderData.Text);
            cr.ImportData.Var.PathSourceFolder = this.txtFolderData.Text;
            //this.importDataFileBindingSource.DataSource = null;
            //this.importDataFileBindingSource.DataSource = cr.ImportData.Var.LibraryFiles;
            this.listBoxFolderFiles.Items.Clear();
            foreach(Classes.ImpData.ImportDataFile impFile in cr.ImportData.Var.LibraryFiles)
            {
                this.listBoxFolderFiles.Items.Add(impFile.FileName);
            }
            //this.dataGridViewFolderFiles.DataSource = importDataFileBindingSource.DataSource;
            //this.dataGridViewFolderFiles.Columns.Add("fileName1", "Файл");
            //this.dataGridViewFolderFiles.Columns.Add("fileName2", "Файл");
            //this.dataGridViewFolderFiles.Columns.Add("fileName3", "Файл");
            //this.dataGridViewFolderFiles.Columns["fileName"]. = cr.ImportData.ImpDataFile.FileName;
        }
        private void FoldersDataTreeView_DoubleClick(object sender, EventArgs e)
        {
            /*
             * Обновляем список файлов
             * */
            this.importDataFileBindingSource.DataSource = null;
            if (this.FoldersDataTreeView.SelectedNode != null)
            {
                this.importDataFileBindingSource.DataSource = cr.ImportData.GetListFolderFiles(this.FoldersDataTreeView.SelectedNode.Text, this.FoldersDataTreeView.SelectedNode.Tag.ToString());
                this.lblSubjectName.Text = this.FoldersDataTreeView.SelectedNode.Text;
                this.listBoxFolderFiles.Items.Clear();
                foreach (Classes.ImpData.ImportDataFile impFile in cr.ImportData.Var.LibraryFolderFiles)
                {
                    this.listBoxFolderFiles.Items.Add(impFile.FileName);
                }
            }
            //this.dataGridViewFolderFiles.Refresh();
            //this.dataGridViewFolderFiles.Update();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            cr.SWatch.Start();
            cr.ProcessingEventAddToBase.Clear();
            cr.ImportData.Var.Ch1NM = this.ch1NM.Checked;
            cr.ImportData.Var.Ch1NOM = this.ch1NOM.Checked;
            cr.ImportData.Var.Ch4NM = this.ch4NM.Checked;
            cr.ImportData.Var.Ch1PATENT = this.ch1Patent.Checked;
            cr.ImportData.Var.Ch5ENVD = this.ch5ENVD.Checked;
            cr.ImportData.Var.Ch5USN = this.ch5USN.Checked;
            if (this.chYear.Checked)
            {
                try
                {
                    cr.ImportData.Var.ChYearAfter = Convert.ToInt16(this.txtChoceYearAfter.Text);
                    cr.ImportData.Var.ChYearBefore = Convert.ToInt16(this.txtChoceYearBefore.Text);
                    cr.ImportData.Var.IsImportOneList = this.checkBoxIsImportOneList.Checked;
                    //
                    if (checkBoxSelectSubject.Checked)
                    {
                        cr.ImportData.Var.IdSubject = cr.ImportData.returnNullInt(comboBoxSelectedSubject.SelectedValue);
                    }
                    else
                    {
                        cr.ImportData.Var.IdSubject = 0;
                    }
                }
                catch(System.Exception err)
                {
                    MessageBox.Show("Не верно указан диапазон: год");
                    return;
                }
            }
            cr.ImportData.mReportImport.AddRecords(this.chFolder.Checked,this.chYear.Checked);
            
        }

        private void btViewSheet_Click(object sender, EventArgs e)
        {
            //cr.ImportData.Var.TakeIntervalTable(this.listTablesView.Items[this.listTablesView.SelectedIndex].ToString());
            if (frmTableView == null || frmTableView.IsDisposed == true)
            {
                frmTableView = new Forms.FormTableView(cr.ImportData.Var.InternalTable);
                frmTableView.MdiParent = cr.FrmApp;
                frmTableView.Show();
            }
            else
            {
                frmTableView.dataGridViewSourceTable.DataSource = cr.ImportData.Var.InternalTable;
                frmTableView.Refresh();
                frmTableView.Focus();
            }
        }

        private void chExcel_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.MethExcel = chExcel.Enabled;
        }

        private void txtFolderData_TextChanged(object sender, EventArgs e)
        {
        }

        private void chYear_CheckedChanged(object sender, EventArgs e)
        {
            this.txtChoceYearAfter.Enabled = this.chYear.Checked;
            this.txtChoceYearBefore.Enabled = this.chYear.Checked;
        }

        private void ch1NOM_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.Ch1NOM = this.ch1NOM.Checked;
        }

        private void ch1NM_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.Ch1NM = this.ch1NM.Checked;
        }

        private void btCalculate1NOM_Click(object sender, EventArgs e)
        {
            setParams();
            cr.ImportData.mReportImport.CompareReportsTaxEea();
        }

        private void checkBoxForcast_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.ChForcast = this.checkBoxForcast.Checked;
            if (this.checkBoxForcast.Checked)
            {
                this.txtTarget.Text = "Прогнозное значение";
            }
            else
            {
                this.txtTarget.Text = "";
            }
        }

        private void listBoxFolderFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Classes.ImpData.ImportDataFile bb=(Classes.ImpData.ImportDataFile)cr.ImportData.Var.LibraryFolderFiles[this.listBoxFolderFiles.SelectedIndex];
            this.label2.Text = bb.Type + " " + bb.DataYear;
        }

        private void chAllinOne_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.ChAllInOne = this.chAllInOne.Checked;
        }

        private void comboBoxSelectedSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxSelectedSubject.SelectedValue != null)
            {
                if ((int)this.comboBoxSelectedSubject.SelectedValue > 0)
                {
                    if (cr.ImportData != null) cr.ImportData.Var.IdSubject = (int)this.comboBoxSelectedSubject.SelectedValue;
                }
            }
        }

        private void btSpreadOnBydgets_Click(object sender, EventArgs e)
        {
            setParams();
            cr.ImportData.mReportImport.SpreadOnBudgetsTax();
        }

        private void btSpreadOnBudgetsEea_Click(object sender, EventArgs e)
        {
            setParams();
            cr.ImportData.mReportImport.SpreadOnBudgetsEea();
        }

        private void checkBoxSelectSubject_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBoxSelectedSubject.Enabled = this.checkBoxSelectSubject.Checked;
        }

        private void chListSubjects_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.AddByListOfSubject = this.chListSubjects.Checked;
        }

        private void ch4NM_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.Ch4NM = this.ch4NM.Checked;
        }
        private void setParams()
        {
            setParamYears();
        }
        private void setParamYears()
        {
            if (this.txtChoceYearAfter.Text.Length > 0)
            {
                cr.ImportData.Var.YearAfter = (short)cr.ImportData.returnNullInt(this.txtChoceYearAfter.Text);
            }
            if (this.txtChoceYearBefore.Text.Length > 0)
            {
                cr.ImportData.Var.YearBefore = (short)cr.ImportData.returnNullInt(this.txtChoceYearBefore.Text);
            }
        }

        private void ch5USN_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.Ch5USN = this.ch5USN.Checked;
        }

        private void ch5ENVD_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.Ch5ENVD = this.ch5ENVD.Checked;
        }

        private void ch1Patent_CheckedChanged(object sender, EventArgs e)
        {
            cr.ImportData.Var.Ch1PATENT = this.ch1Patent.Checked;
        }



    }
}
