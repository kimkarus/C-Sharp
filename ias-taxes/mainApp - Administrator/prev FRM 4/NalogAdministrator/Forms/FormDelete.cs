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
    public partial class FormDelete : Form
    {
        private string[] codeSubjects;
        private string[] subjectsTables = new string[]{
            "Source_data_1NOM",
            "Source_data_1NM",
            "Source_data_Population",
            "Source_data_Population_eea",
            //"Source_data_4NM",
            //"Source_data_Subject_index",
            //"Data_correlation_subject_values",
            //"Compare_eea_budget",
            //"Compare_tax_budget",
            //"Compare_tax_eea",
            //"Data_best_models_subject_tax",
            //"Data_correlation_subject_eea_budget_indexes",
            //"Data_correlation_subject_tax_budget_indexes",
            //"Data_correlation_subject_tax_eea_total",
            //"Data_correlation_subject_tax_indexes",
            //"Data_model_params",
            //"Data_model_subject_tax",
            //"Data_model_subject_tax_eea",
            //"Data_models",
            "Data_warehouse_subject",
            "Data_warehouse_subject_budget",
            "Data_warehouse_subject_eea_budget",
            "Data_warehouse_subject_eea_gks",
            "Data_warehouse_subject_tax",
            "Data_warehouse_subject_tax_budget"
        };
        //
        private Classes.Core cr;
        private base_nalogDataSet ds;
        public FormDelete()
        {
            InitializeComponent();
        }
        public FormDelete(Classes.Core Cr)
        {
            this.cr = Cr;
            this.ds = cr.Data.Base.Ds;
            cr.ImportData = new Classes.ImpData.ImportData(cr);
            InitializeComponent();
        }

        private void buttonClearRelativeTables_Click(object sender, EventArgs e)
        {
            codeSubjects = richTextBoxIdSubjects.Text.Split(';');
            if (textBoxYear.Text == "") return;
            startClearTables("year=" + textBoxYear.Text + ";", codeSubjects);
        }
        private void startClearTables(string settings = "", string[] codes = null)
        {
            #region считываем входные параметры
            string[] parametres = settings.Split(';');
            string year = "";
            //
            foreach (string str in parametres)
            {
                string[] param = str.Split('=');
                switch (param[0])
                {
                    case "year":
                        {
                            year = param[1];
                            break;
                        }
                }
            }
            #endregion считываем входные параметры

            //
            foreach (string table in subjectsTables)
            {
                fillTable(table);
                foreach (string code in codes)
                {
                    clearSubjectsTable(table, code, year);
                }
                doTableAdapter(table);
                cleanTable(table);

            }
        }
        private void clearSubjectsTable(string table="", string code="", string year="")
        {
            if(table=="" && code=="")return;
            string select = "";
            if (year != "")
            {
                if (table.Contains("Data_"))
                {
                    select = "SELECT " +
                    "dbo." + table + ".id " +
                    "FROM dbo.Subjects " + " " +
                    "INNER JOIN dbo." + table + " ON dbo.Subjects.id = dbo." + table + ".id_subject" + " " +
                    "INNER JOIN dbo.Time ON dbo." + table + ".id_time=dbo.Time.id " + " " +
                    "WHERE (dbo.Subjects.code=" + code + ") AND " + " " +
                    "(dbo.Time.calendar_year=" + year + ")";
                }
                else
                {
                    select = "SELECT " +
                    "dbo." + table + ".id " +
                    "FROM dbo.Subjects " + " " +
                    "INNER JOIN dbo." + table + " ON dbo.Subjects.id = dbo." + table + ".id_subject" + " " +
                    "WHERE (dbo.Subjects.code=" + code + ") AND " + " " +
                    "(dbo." + table + ".year_data=" + year + ")";
                }

            }
            else
            {
                select = "SELECT " +
                "dbo." + table + ".id " +
                "FROM dbo.Subjects " + " " +
                "INNER JOIN dbo." + table + " ON dbo.Subjects.id = dbo." + table + ".id_subject" + " " +
                 "WHERE dbo.Subjects.code=" + code;
            }
            
            cr.ImportData.Var.AgregationTable = cr.ImportData.ReturnSourceTable(select, table + "_" + code);
            foreach (DataRow row in cr.ImportData.Var.AgregationTable.Rows)
            {
                DataRow rowDelete = ds.Tables[table].Rows.Find(row["id"]);
                rowDelete.Delete();
            }
        }
        private void deleteRows(string id="")
        {
            if (id == "") return;
            cr.Data.Base.CustomTable = new DataTable();
            DataTable deleteRows = (DataTable)cr.Data.Base.CustomTable.GetChanges(DataRowState.Deleted);
        }
        private void doTableAdapter(string table)
        {
            cr.Data.Base.CustomTable = new DataTable();
            DataTable deleteRows = (DataTable)cr.Data.Base.CustomTable.GetChanges(DataRowState.Deleted);
            DataTable newRows = (DataTable)cr.Data.Base.CustomTable.GetChanges(DataRowState.Added);
            DataTable modifiedRows = (DataTable)cr.Data.Base.CustomTable.GetChanges(DataRowState.Modified);
            #region table
            switch (table)
            {
                case "Source_data_1NOM":
                    {
                        /*base_nalogDataSet.Data_warehouse_subjectDataTable */
                        deleteRows = (base_nalogDataSet.Source_data_1NOMDataTable)ds.Source_data_1NOM.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_subjectDataTable */
                        newRows = (base_nalogDataSet.Source_data_1NOMDataTable)ds.Source_data_1NOM.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_subjectDataTable */
                        modifiedRows = (base_nalogDataSet.Source_data_1NOMDataTable)ds.Source_data_1NOM.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Source_data_1NM":
                    {
                        /*base_nalogDataSet.Data_warehouse_subject_taxDataTable */
                        deleteRows = (base_nalogDataSet.Source_data_1NMDataTable)ds.Source_data_1NM.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_subject_taxDataTable */
                        newRows = (base_nalogDataSet.Source_data_1NMDataTable)ds.Source_data_1NM.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_subject_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Source_data_1NMDataTable)ds.Source_data_1NM.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Source_data_Population":
                    {
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        deleteRows = (base_nalogDataSet.Source_data_PopulationDataTable)ds.Source_data_Population.GetChanges(DataRowState.Deleted);
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        newRows = (base_nalogDataSet.Source_data_PopulationDataTable)ds.Source_data_Population.GetChanges(DataRowState.Added);
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        modifiedRows = (base_nalogDataSet.Source_data_PopulationDataTable)ds.Source_data_Population.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Source_data_Population_eea":
                    {
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        deleteRows = (base_nalogDataSet.Source_data_Population_eeaDataTable)ds.Source_data_Population_eea.GetChanges(DataRowState.Deleted);
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        newRows = (base_nalogDataSet.Source_data_Population_eeaDataTable)ds.Source_data_Population_eea.GetChanges(DataRowState.Added);
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        modifiedRows = (base_nalogDataSet.Source_data_Population_eeaDataTable)ds.Source_data_Population_eea.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Data_warehouse_subject":
                    {
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subjectDataTable)ds.Data_warehouse_subject.GetChanges(DataRowState.Deleted);
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subjectDataTable)ds.Data_warehouse_subject.GetChanges(DataRowState.Added);
                        /*Data_warehouse_subject_tax_budgetDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subjectDataTable)ds.Data_warehouse_subject.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Data_warehouse_subject_budget":
                    {
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subject_budgetDataTable)ds.Data_warehouse_subject_budget.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subject_budgetDataTable)ds.Data_warehouse_subject_budget.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subject_budgetDataTable)ds.Data_warehouse_subject_budget.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Data_warehouse_subject_eea_budget":
                    {
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subject_eea_budgetDataTable)ds.Data_warehouse_subject_eea_budget.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subject_eea_budgetDataTable)ds.Data_warehouse_subject_eea_budget.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subject_eea_budgetDataTable)ds.Data_warehouse_subject_eea_budget.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Data_warehouse_subject_eea_gks":
                    {
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)ds.Data_warehouse_subject_eea_gks.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)ds.Data_warehouse_subject_eea_gks.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)ds.Data_warehouse_subject_eea_gks.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Data_warehouse_subject_tax":
                    {
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subject_taxDataTable)ds.Data_warehouse_subject_tax.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subject_taxDataTable)ds.Data_warehouse_subject_tax.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subject_taxDataTable)ds.Data_warehouse_subject_tax.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "Data_warehouse_subject_tax_budget":
                    {
                        deleteRows = (base_nalogDataSet.Data_warehouse_subject_tax_budgetDataTable)ds.Data_warehouse_subject_tax_budget.GetChanges(DataRowState.Deleted);
                        newRows = (base_nalogDataSet.Data_warehouse_subject_tax_budgetDataTable)ds.Data_warehouse_subject_tax_budget.GetChanges(DataRowState.Added);
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subject_tax_budgetDataTable)ds.Data_warehouse_subject_tax_budget.GetChanges(DataRowState.Modified);
                        break;
                    }
            }
            #endregion method
            //
            try
            {
                #region deleteRows
                if (deleteRows != null)
                {
                    switch (table)
                    {
                        case "Source_data_1NOM":
                            {
                                cr.Data.Base.SourceData1NOMTableAdapter.Update((base_nalogDataSet.Source_data_1NOMDataTable)deleteRows);
                                break;
                            }
                        case "Source_data_1NM":
                            {
                                cr.Data.Base.SourceData1NMTableAdapter.Update((base_nalogDataSet.Source_data_1NMDataTable)deleteRows);
                                break;
                            }
                        case "Source_data_Population":
                            {
                                cr.Data.Base.SourceDataPopulationTableAdapter.Update((base_nalogDataSet.Source_data_PopulationDataTable)deleteRows);
                                break;
                            }
                        case "Source_data_Population_eea":
                            {
                                cr.Data.Base.SourceDataPopulationEeaTableAdapter.Update((base_nalogDataSet.Source_data_Population_eeaDataTable)deleteRows);
                                break;
                            }
                        case "Data_warehouse_subject":
                            {
                                cr.Data.Base.DataWarehouseSubjectTableAdapter.Update((base_nalogDataSet.Data_warehouse_subjectDataTable)deleteRows);
                                break;
                            }
                        case "Data_warehouse_subject_budget":
                            {
                                cr.Data.Base.DataWarehouseSubjectBudgetsTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_budgetDataTable)deleteRows);
                                break;
                            }
                        case "Data_warehouse_subject_eea_budget":
                            {
                                cr.Data.Base.DataWarehouseSubjectEeaBudgetsTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_eea_budgetDataTable)deleteRows);
                                break;
                            }
                        case "Data_warehouse_subject_eea_gks":
                            {
                                cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)deleteRows);
                                break;
                            }
                        case "Data_warehouse_subject_tax":
                            {
                                cr.Data.Base.DataWarehouseSubjectTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_taxDataTable)deleteRows);
                                break;
                            }
                        case "Data_warehouse_subject_tax_budget":
                            {
                                cr.Data.Base.DataWarehouseSubjectTaxBudgetsTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_tax_budgetDataTable)deleteRows);
                                break;
                            }

                    }
                }
                #endregion deleteRows

            }

            catch (System.Exception ex)
            {
                #region error
                string er = ex.Message.ToString();
                #endregion error
            }

            finally
            {
                #region finally
                if (deleteRows != null)
                {
                    deleteRows.Dispose();
                }
                #endregion finally
            }
        }
        private void fillTable(string table="", string code="")
        {
            switch (table)
            {
                case "Source_data_1NOM":
                    {
                        if (cr.Data.Base.SourceData1NOMTableAdapter == null) cr.Data.Base.SourceData1NOMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter();
                        cr.Data.Base.SourceData1NOMTableAdapter.Fill(ds.Source_data_1NOM);
                        break;
                    }
                case "Source_data_1NM":
                    {
                        if (cr.Data.Base.SourceData1NMTableAdapter == null) cr.Data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter();
                        cr.Data.Base.SourceData1NMTableAdapter.Fill(ds.Source_data_1NM);
                        break;
                    }
                case "Source_data_Population":
                    {
                        if (cr.Data.Base.SourceDataPopulationTableAdapter == null) cr.Data.Base.SourceDataPopulationTableAdapter = new base_nalogDataSetTableAdapters.Source_data_PopulationTableAdapter();
                        cr.Data.Base.SourceDataPopulationTableAdapter.Fill(ds.Source_data_Population);
                        break;
                    }
                case "Source_data_Population_eea":
                    {
                        if (cr.Data.Base.SourceDataPopulationEeaTableAdapter == null) cr.Data.Base.SourceDataPopulationEeaTableAdapter = new base_nalogDataSetTableAdapters.Source_data_Population_eeaTableAdapter();
                        cr.Data.Base.SourceDataPopulationEeaTableAdapter.Fill(ds.Source_data_Population_eea);
                        break;
                    }
                case "Data_warehouse_subject":
                    {
                        if (cr.Data.Base.DataWarehouseSubjectTableAdapter == null) cr.Data.Base.DataWarehouseSubjectTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subjectTableAdapter();
                        cr.Data.Base.DataWarehouseSubjectTableAdapter.Fill(ds.Data_warehouse_subject);
                        break;
                    }
                case "Data_warehouse_subject_budget":
                    {
                        if (cr.Data.Base.DataWarehouseSubjectBudgetsTableAdapter == null) cr.Data.Base.DataWarehouseSubjectBudgetsTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subject_budgetTableAdapter();
                        cr.Data.Base.DataWarehouseSubjectBudgetsTableAdapter.Fill(ds.Data_warehouse_subject_budget);
                        break;
                    }
                case "Data_warehouse_subject_eea_budget":
                    {
                        if (cr.Data.Base.DataWarehouseSubjectEeaBudgetsTableAdapter == null) cr.Data.Base.DataWarehouseSubjectEeaBudgetsTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subject_eea_budgetTableAdapter();
                        cr.Data.Base.DataWarehouseSubjectEeaBudgetsTableAdapter.Fill(ds.Data_warehouse_subject_eea_budget);
                        break;
                    }
                case "Data_warehouse_subject_eea_gks":
                    {
                        if (cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter == null) cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subject_eea_gksTableAdapter();
                        cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter.Fill(ds.Data_warehouse_subject_eea_gks);
                        break;
                    }
                case "Data_warehouse_subject_tax":
                    {
                        if (cr.Data.Base.DataWarehouseSubjectTaxTableAdapter == null) cr.Data.Base.DataWarehouseSubjectTaxTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subject_taxTableAdapter();
                        cr.Data.Base.DataWarehouseSubjectTaxTableAdapter.Fill(ds.Data_warehouse_subject_tax);
                        break;
                    }
                case "Data_warehouse_subject_tax_budget":
                    {
                        if (cr.Data.Base.DataWarehouseSubjectTaxBudgetsTableAdapter == null) cr.Data.Base.DataWarehouseSubjectTaxBudgetsTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subject_tax_budgetTableAdapter();
                        cr.Data.Base.DataWarehouseSubjectTaxBudgetsTableAdapter.Fill(ds.Data_warehouse_subject_tax_budget);
                        break;
                    }
            }
        }
        private void cleanTable(string table)
        {
            ds.Tables[table].Clear();
            ds.Tables[table].Dispose();
        }
    }
}
