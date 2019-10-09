using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using RDotNet;
//using alglibnet2.dll;

namespace NalogAdministrator.Classes
{
    public class CreaterModel
    {
        private Core cr;
        private DataTable taxDataTable;
        private DataTable budgetDataTable;
        private DataTable eeaDataTable;
        private DataTable indexDataTable;
        private DataTable indexesDataTable;
        private DataSet ds;
        private DataTable dt;
        private DataTable dt_add;
        private DataTable idSubjects;
        private string nameColumnValues = "";
        private string tableModel = "";
        private string dwTableModel = "";
        private string targetTableModel = "";
        private string sourceColumn = "";
        private int id_model_params = 0;
        private int[] ids_model_params;
        private int id_model = 0;
        private int id_type_model = 0;
        private int id_model_adv = 0;
        private int[] ids_model_adv;
        private DataTable dt_prm;
        private DataTable dt_db;
        private double[] x, y, k1;
        private decimal a1, a0, v;
        private double[,] paramValues;
        private DateTime model_date_create;
        //
        base_nalogDataSet.Data_model_subject_taxRow modelSubjectTaxRow;
        base_nalogDataSet.Data_model_subject_taxDataTable modelSubjectTaxDataTable;
        base_nalogDataSet.Data_model_subject_tax_eeaRow modelSubjectTaxEeaRow;
        base_nalogDataSet.Data_model_subject_tax_eeaDataTable modelSubjectTaxEeaDataTable;
        base_nalogDataSet.Data_model_paramsDataTable modelParamsDataTable;
        base_nalogDataSet.Data_model_paramsRow modelParamsRow;
        base_nalogDataSet.Data_modelsRow modelsRow;
        base_nalogDataSet.Data_modelsDataTable modelsDataTable;
        base_nalogDataSet.Model_typeDataTable modelTypeDataTable;
        base_nalogDataSet.Data_model_subject_budget_tax_indexesDataTable dataModelSubjectBudgetTaxIndexesDataTable;
        base_nalogDataSet.Data_model_subject_budget_tax_indexesRow dataModelSubjectBudgetTaxIndexesRow;
        base_nalogDataSet.Data_best_models_subject_taxDataTable bestModelSubjectTaxDataTable;
        base_nalogDataSet.Data_best_models_subject_taxRow bestModelSubjectTaxRow;
        base_nalogDataSet.SubjectsDataTable subjectsDataTable;
        base_nalogDataSet.Data_correlation_subject_tax_eea_totalDataTable correlationSubjectTaxEeaTotalDataTable;
        base_nalogDataSet.Data_correlation_subject_tax_eea_totalRow correlationSubjectTaxEeaTotalRow;
        base_nalogDataSet.Data_correlation_subject_tax_indexesDataTable correlationSubjectTaxIndexesDataTable;
        base_nalogDataSet.Data_correlation_subject_tax_indexesRow correlationSubjectTaxIndexesRow;
        base_nalogDataSet.Data_correlation_subject_tax_budget_indexesDataTable correlationSubjectTaxBudgetIndexesDataTable;
        base_nalogDataSet.Data_correlation_subject_tax_budget_indexesRow correlationSubjectTaxBudgetIndexesRow;
        base_nalogDataSet.Data_correlation_subject_budget_indexesDataTable correlationSubjectBudgetIndexesDataTable;
        base_nalogDataSet.Data_correlation_subject_budget_indexesRow correlationSubjectBudgetIndexesRow;
        base_nalogDataSet.Data_correlation_subject_eea_budget_indexesDataTable correlationSubjectEeaBudgetIndexesDataTable;
        base_nalogDataSet.Data_correlation_subject_eea_budget_indexesRow correlationSubjectEeaBudgetIndexesRow;
        base_nalogDataSet.Data_correlation_subject_valuesDataTable correlationSubjectValuesDataTable;
        base_nalogDataSet.Data_correlation_subject_valuesRow correlationSubjectValuesRow;
        base_nalogDataSet.Table_correlationsDataTable correlationCollectionDataTable;
        base_nalogDataSet.Table_correlationsRow correlationCollectionRow;
        //

        public CreaterModel(Core Cr = null, string table = "")
        {
            this.cr = Cr;
            tableModel = table;
            checkParams();
            ds = new DataSet();
        }
        public void createModel()
        {
            //Выборка
            if (tableModel == "Data_warehouse_subject_tax") sourceColumn = "ti_tax_subject";
            if (tableModel == "Compare_tax_eea") sourceColumn = "TI";
            //Подготавливаем таблицы для видов налогов


            nameColumnValues = sourceColumn;
            //Data_warehouse_subject_tax
            if (tableModel == "Data_warehouse_subject_tax")
            {
                dwTableModel = "Data_model_subject_tax";
                taxDataTable = new DataTable();
                taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM  " + tableModel + " GROUP BY id_tax, id_subject HAVING (id_subject = " + cr.ImportData.Var.IdSubject + ")", tableModel);
            }
            //Compare_tax_eea
            if (tableModel == "Compare_tax_eea")
            {
                dwTableModel = "Data_model_subject_tax_eea";
                taxDataTable = new DataTable();
                taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM  " + tableModel + " GROUP BY id_tax, id_subject HAVING (id_subject = " + cr.ImportData.Var.IdSubject + ")", tableModel);
                taxDataTable.TableName = "tax";
                eeaDataTable = new DataTable();
                eeaDataTable = cr.ImportData.ReturnSourceTable("SELECT id_eea FROM  " + tableModel + " GROUP BY id_eea, id_subject HAVING (id_subject = " + cr.ImportData.Var.IdSubject + ")", tableModel);
                eeaDataTable.TableName = "eea";
            }
            int id_subject = cr.ImportData.Var.IdSubject;
            int id_tax = 0;
            int id_eea = 0;
            int id_time = 0;
            ds = new DataSet();
            if (tableModel == "Data_warehouse_subject_tax") cr.Data.Base.DataModelSubjectTaxTableAdapter = new base_nalogDataSetTableAdapters.Data_model_subject_taxTableAdapter(); modelSubjectTaxDataTable = new base_nalogDataSet.Data_model_subject_taxDataTable(); targetTableModel = modelSubjectTaxDataTable.TableName; ds.Clear();
            if (tableModel == "Compare_tax_eea") cr.Data.Base.DataModelSubjectTaxEeaTableAdapter = new base_nalogDataSetTableAdapters.Data_model_subject_tax_eeaTableAdapter(); modelSubjectTaxEeaDataTable = new base_nalogDataSet.Data_model_subject_tax_eeaDataTable(); targetTableModel = modelSubjectTaxEeaDataTable.TableName; ds.Clear();

            for (int i = 0; i < taxDataTable.Rows.Count; i++)
            {
                id_tax = cr.ImportData.returnNullInt(taxDataTable.Rows[i]["id_tax"]);
                cr.ImportData.Var.IdTax = id_tax;
                #region tax
                //Data_warehouse_subject_tax
                if (tableModel == "Data_warehouse_subject_tax")
                {
                    dt = returnDt(i);
                    if (dt != null)
                    {
                        //
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            id_time = (int)dt.Rows[r]["id_time"];
                            cr.ImportData.Var.IdTime = id_time;
                            //Data_warehouse_subject_tax
                            modelSubjectTaxRow = modelSubjectTaxDataTable.NewData_model_subject_taxRow();
                            modelSubjectTaxRow.id_subject = id_subject;
                            modelSubjectTaxRow.id_tax = id_tax;
                            modelSubjectTaxRow.id_time = id_time;
                            modelSubjectTaxRow.id_model = id_model;
                            modelSubjectTaxRow.S = cr.ImportData.returnNullDecimal(dt.Rows[r]["Si"]);
                            modelSubjectTaxRow.E = cr.ImportData.returnNullDecimal(dt.Rows[r]["E"]);
                            modelSubjectTaxDataTable.Rows.Add(modelSubjectTaxRow);
                        }
                    }
                }
                #endregion tax
                #region tax_eea
                //Compare_tax_eea
                if (tableModel == "Compare_tax_eea")
                {
                    for (int j = 0; j < eeaDataTable.Rows.Count; j++)
                    {
                        id_eea = cr.ImportData.returnNullInt(eeaDataTable.Rows[j]["id_eea"]);
                        dt = returnDt(i, j);
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            id_time = (int)dt.Rows[r]["id_time"];

                            modelSubjectTaxEeaRow = modelSubjectTaxEeaDataTable.NewData_model_subject_tax_eeaRow();
                            modelSubjectTaxEeaRow.id_subject = id_subject;
                            modelSubjectTaxEeaRow.id_tax = id_tax;
                            modelSubjectTaxEeaRow.id_eea = id_eea;
                            modelSubjectTaxEeaRow.id_time = id_time;

                            modelSubjectTaxEeaRow.T1 = cr.ImportData.returnNullDecimal(dt.Rows[r]["Ta0"]);
                            modelSubjectTaxEeaRow.T2 = cr.ImportData.returnNullDecimal(dt.Rows[r]["Ta1"]);
                            modelSubjectTaxEeaRow.S = cr.ImportData.returnNullDecimal(dt.Rows[r]["Si"]);
                            modelSubjectTaxEeaRow.E = cr.ImportData.returnNullDecimal(dt.Rows[r]["E"]);
                            modelSubjectTaxEeaRow.R2 = cr.ImportData.returnNullDecimal(dt.Rows[r]["R2"]);
                            modelSubjectTaxEeaRow.F = cr.ImportData.returnNullDecimal(dt.Rows[r]["F"]);
                            modelSubjectTaxEeaRow.F001 = cr.ImportData.returnNullDecimal(dt.Rows[r]["F001"]);
                            modelSubjectTaxEeaRow.F005 = cr.ImportData.returnNullDecimal(dt.Rows[r]["F005"]);

                            modelSubjectTaxEeaDataTable.Rows.Add(modelSubjectTaxEeaRow);
                        }
                    }
                    //Compare_tax_eea
                    if (tableModel == "Compare_tax_eea")
                    {
                        cr.Data.Base.DataModelSubjectTaxEeaTableAdapter.Update(modelSubjectTaxEeaDataTable);
                    }
                #endregion tax_eea
                }
                //Data_warehouse_subject_tax
                if (tableModel == "Data_warehouse_subject_tax")
                {
                    cr.Data.Base.DataModelSubjectTaxTableAdapter.Update(modelSubjectTaxDataTable);
                }

            }

        }
        private void checkParams()
        {
            //cr.ImportData.Var.IdSubject = 81;
            cr.Data.Base.DataModelParamsTableAdapter = new base_nalogDataSetTableAdapters.Data_model_paramsTableAdapter();
            id_type_model = cr.ImportData.Var.IdTypeModel;
            //createModel();
        }

        private decimal returnAvg(DataTable dt, string col = "")
        {
            decimal value = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                value += cr.ImportData.returnNullDecimal(dt.Rows[i][col]) / dt.Rows.Count;
            }
            return value;
        }
        private decimal returnAmplitude(DataTable dt, int i, string col = "", decimal avg = 0)
        {
            decimal value = 0;
            if (avg != 0) value = cr.ImportData.returnNullDecimal(dt.Rows[i][col]) / avg;
            return value;
        }
        private decimal returnAvgOffset(DataTable dt, int i, string col = "")
        {
            decimal value = 0;
            int intervals = cr.ImportData.Var.CountIntervals;
            double d = intervals / (double)2;
            int p = (int)d;
            double fact = d - p;

            if (fact != 0)
            {
                int before = p;
                int after = p;
                decimal sum = 0;
                int countBefore = 0;
                int countAfter = 0;
                for (int r = 1; r < before + 1; r++)
                {
                    if (i - r >= 0) countBefore++;
                }
                for (int r = 1; r < after + 1; r++)
                {
                    if (i + r <= dt.Rows.Count - 1) countAfter++;
                }
                if (countAfter == after && countBefore == before)
                {
                    for (int r = 1; r < before + 1; r++)
                    {
                        sum += cr.ImportData.returnNullDecimal(dt.Rows[i - r][col]);
                    }
                    for (int r = 1; r < after + 1; r++)
                    {
                        sum += cr.ImportData.returnNullDecimal(dt.Rows[i + r][col]);
                    }
                    sum += cr.ImportData.returnNullDecimal(dt.Rows[i][col]);
                    //
                    value = sum / intervals;
                }
            }
            else
            {
                int before = p;
                int after = p;
                decimal sum = 0;
                int countBefore = 0;
                int countAfter = 0;
                for (int r = 1; r < before + 1; r++)
                {
                    if (i - r >= 0) countBefore++;
                }
                for (int r = 0; r < after; r++)
                {
                    if (i + r <= dt.Rows.Count - 1) countAfter++;
                }
                if (countAfter == after && countBefore == before)
                {
                    for (int r = 1; r < before + 1; r++)
                    {
                        sum += cr.ImportData.returnNullDecimal(dt.Rows[i - r][col]);
                    }
                    for (int r = 0; r < after; r++)
                    {
                        sum += cr.ImportData.returnNullDecimal(dt.Rows[i + r][col]);
                    }
                    sum += cr.ImportData.returnNullDecimal(dt.Rows[i][col]);
                    //
                    value = sum / intervals;
                }
            }
            return value;
        }
        private decimal returnAvgCenterOffset(DataTable dt, int i, string col = "")
        {
            decimal value = 0;
            if (i - 1 >= 0 && i + 1 != dt.Rows.Count)
            {
                if (cr.ImportData.returnNullDecimal(dt.Rows[i - 1]["avg_offset"]) > 0 && cr.ImportData.returnNullDecimal(dt.Rows[i]["avg_offset"]) > 0) value = (cr.ImportData.returnNullDecimal(dt.Rows[i]["avg_offset"]) + cr.ImportData.returnNullDecimal(dt.Rows[i - 1]["avg_offset"])) / 2;
            }
            return value;
        }
        private decimal returnSeason(DataTable dt, int i, string col = "")
        {
            decimal value = 0;
            if ((decimal)dt.Rows[i]["avg_center_offset"] != 0) value = cr.ImportData.returnNullDecimal(dt.Rows[i][nameColumnValues]) / cr.ImportData.returnNullDecimal(dt.Rows[i]["avg_center_offset"]);
            return value;
        }
        private int returnT2(DataTable dt, int i, string col = "")
        {
            int value = cr.ImportData.returnNullInt(dt.Rows[i][col]) * cr.ImportData.returnNullInt(dt.Rows[i][col]);
            return value;
        }
        private decimal returnY2(DataTable dt, int i, string col = "")
        {
            //квадрат
            decimal value = cr.ImportData.returnNullDecimal(dt.Rows[i][col]) * cr.ImportData.returnNullDecimal(dt.Rows[i][col]);
            return value;
        }
        private decimal returnTY(DataTable dt, int i, string col1 = "", string col2 = "")
        {
            //теория и факт, умножение
            decimal value = cr.ImportData.returnNullInt(dt.Rows[i][col1]) * cr.ImportData.returnNullDecimal(dt.Rows[i][col2]);
            return value;
        }
        private decimal returnTYcp(DataTable dt, DataTable dtY, int i, string col1 = "", string col2 = "")
        {
            //теория и факт, квадрат
            decimal value =
                (cr.ImportData.returnNullInt(dtY.Rows[i][col2]) - cr.ImportData.returnNullDecimal(dt.Rows[i][col1])) *
                (cr.ImportData.returnNullInt(dtY.Rows[i][col2]) - cr.ImportData.returnNullDecimal(dt.Rows[i][col1]));
            return value;
        }
        private decimal returnYYcp(DataTable dt, int i, string col = "", decimal avg = 0)
        {
            decimal value = (cr.ImportData.returnNullDecimal(dt.Rows[i][col]) - avg) * (cr.ImportData.returnNullDecimal(dt.Rows[i][col]) - avg);
            return value;
        }
        private decimal returnSum(DataTable dt, string col = "")
        {
            decimal value = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                value += cr.ImportData.returnNullDecimal(dt.Rows[i][col]);
            }
            return value;
        }
        private decimal returnSi(DataTable dt, int i, decimal[] arr)
        {
            decimal value = 0;

            return value;
        }
        private decimal returnSqrt(DataRow row, string col = "")
        {
            decimal sqrt = 0;
            double value = cr.ImportData.returnNullDouble(row[col]);
            if (value <= 0) { sqrt = 0; }
            else
            {
                try
                {
                    sqrt = (decimal)Math.Sqrt(value);
                }
                catch (System.Exception ex)
                {
                    sqrt = 0;
                }

            }
            return sqrt;
        }
        private decimal returnDISP(DataTable dt, string col = "")
        {
            decimal disp = 0;
            if (dt == null || col.Length < 1) return disp;
            decimal SumXX2 = 0;
            decimal avg = returnAvg(dt,col);
            for (int i=0;i<dt.Rows.Count;i++)
            {
                SumXX2 += returnYYcp(dt, i, col, avg);
            }
            disp = SumXX2 / (dt.Rows.Count - 1);
            return disp;
        }
        private decimal returnDispUnbiased(DataTable dt, string col = "", int m=0)
        {
            decimal disp = 0;
            if (dt == null || col.Length < 1 || m < 1) return disp;
            decimal SumXX2 = 0;
            decimal avg = returnAvg(dt, col);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SumXX2 += returnYYcp(dt, i, col, avg);
            }
            disp = SumXX2 / (dt.Rows.Count - m - 1);
            return disp;
        }
        private decimal returnDispQuery(DataTable dt, string col = "")
        {
            decimal disp = 0;
            if (dt == null || col.Length < 1) return disp;
            decimal SumX2 = 0;
            decimal avg = returnAvg(dt, col);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SumX2 += returnY2(dt, i, col);
            }
            disp = (SumX2 / (dt.Rows.Count)) - (avg * avg);
            return disp;
        }
        private string returnSqlSelect(int i = 0, int j = 0, string sorceTable = "", int id_subject = 0, int id_budget = 0, int id_tax = 0, int id_index = 0)
        {
            string select = "";
            if (tableModel == "Compare_tax_eea")
            {
                select = "SELECT " + tableModel + ".id_subject, " + tableModel + ".id_tax, " + tableModel + ".id_eea, " + tableModel + ".TI, " + tableModel + ".year_data, Time.id AS id_time FROM " + tableModel + " INNER JOIN Time ON " + tableModel + ".year_data = Time.calendar_year WHERE (" + tableModel + ".id_subject = " + cr.ImportData.Var.IdSubject + ") AND (" + tableModel + ".id_tax = " + (int)taxDataTable.Rows[i]["id_tax"] + ") AND (" + tableModel + ".id_eea = " + (int)eeaDataTable.Rows[j]["id_eea"] + ") ORDER BY " + tableModel + ".year_data";
            }
            if (tableModel == "Data_warehouse_subject_tax")
            {
                string years = "";
                string year1 = "";
                string year2 = "";
                if (cr.ImportData.Var.YearAfter > 0) year1 = " AND (Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ")"; years = year1;
                if (cr.ImportData.Var.YearBefore > 0) year2 = "AND (Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ")"; years = year2;
                if (cr.ImportData.Var.YearBefore > 0 && cr.ImportData.Var.YearAfter > 0) years = year1 + year2;
                select = "SELECT " + tableModel + ".id_subject, " + tableModel + ".id_tax, " + tableModel + "." + sourceColumn + ", Time.id AS id_time, Time.calendar_year AS year FROM  " + tableModel + " INNER JOIN Time ON " + tableModel + ".id_time = Time.id WHERE (" + tableModel + ".id_subject = " + cr.ImportData.Var.IdSubject + ") AND (" + tableModel + ".id_tax = " + (int)taxDataTable.Rows[i]["id_tax"] + ") " + years + "ORDER BY Time.calendar_year";
            }
            if (sorceTable == "Data_warehouse_subject_tax_budget")
            {
                string years = "";
                string year1 = "";
                string year2 = "";
                if (cr.ImportData.Var.YearAfter > 0) year1 = " AND (Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ")"; years = year1;
                if (cr.ImportData.Var.YearBefore > 0) year2 = "AND (Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ")"; years = year2;
                if (cr.ImportData.Var.YearBefore > 0 && cr.ImportData.Var.YearAfter > 0) years = year1 + year2;
                select =
                    "SELECT dbo.Data_warehouse_subject_tax_budget.ti" +
                    " FROM dbo.Data_warehouse_subject_tax_budget INNER JOIN" +
                        " dbo.Time ON dbo.Data_warehouse_subject_tax_budget.id_time = dbo.Time.id" +
                    " WHERE" +
                    " (dbo.Data_warehouse_subject_tax_budget.id_subject = " + id_subject + ")" +
                    " AND (dbo.Data_warehouse_subject_tax_budget.id_tax = " + id_tax + ")" +
                    " AND (dbo.Data_warehouse_subject_tax_budget.id_budget = " + id_budget + ")" +
                    " " + years +
                    "ORDER BY dbo.Time.calendar_year";
                select = "SELECT " + tableModel + ".id_subject, " + tableModel + ".id_tax, " + tableModel + "." + sourceColumn + ", Time.id AS id_time, Time.calendar_year AS year FROM  " + tableModel + " INNER JOIN Time ON " + tableModel + ".id_time = Time.id WHERE (" + tableModel + ".id_subject = " + cr.ImportData.Var.IdSubject + ") AND (" + tableModel + ".id_tax = " + (int)taxDataTable.Rows[i]["id_tax"] + ") " + years + "ORDER BY Time.calendar_year";
            }
            if (sorceTable == "Data_model_subject_budget_tax_indexes")
            {
                //
                DataTable dt2 = cr.Data.Base.SchemeValuesTableAdapters.GetDataBy(id_index);
                DataRow row2 = null;
                if (dt2.Rows.Count > 0)
                {
                    row2 = dt2.Rows[0];
                }
                string years = "";
                string year1 = "";
                string year2 = "";
                if (cr.ImportData.Var.YearAfter > 0) year1 = " AND (Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ")"; years = year1;
                if (cr.ImportData.Var.YearBefore > 0) year2 = "AND (Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ")"; years = year2;
                if (cr.ImportData.Var.YearBefore > 0 && cr.ImportData.Var.YearAfter > 0) years = year1 + year2;
                select =
                            "SELECT " + row2["name_source_view"] + "." + row2["name_field_view"] + " AS index_" + id_index +
                            " FROM " + row2["name_source_view"] + " INNER JOIN " +
                                "dbo.Time ON " + row2["name_source_view"] + ".id_time = dbo.Time.id" +
                            " WHERE" +
                            " (" + row2["name_source_view"] + ".id_subject = " + id_subject + ")" +
                            " " + years +
                            " ORDER BY dbo.Time.calendar_year";
            }
            return select;
        }
        private int checkExistingModels(DataTable dt, int p1 = 0, int p2 = 0, int p3 = 0)
        {
            /*
             * 0 - добавить
             * 1 - изменить
             * 2 - удалить
             * 3 - частично изменить
             * */
            int y = 0;
            switch (tableModel)
            {
                case "Data_warehouse_subject_tax":
                    {
                        y = checkExistingModelSubjectTax(dt, p1, p2, p3);
                        break;
                    }
                case "Compare_tax_eea":
                    {
                        y = checkExistingModelSubjectTax(dt, p1, p2, p3);
                        break;
                    }
                case "Data_model_subject_budget_tax_indexes":
                    {
                        y = checkExistingModelSubjectBudgetTaxIndexes(dt, p1, p2, p3);
                        break;
                    }
            }
            //
            //
            return y;
        }
        private int checkExistingModelSubjectTax(DataTable dt, int p1 = 0, int p2 = 0, int p3 = 0)
        {
            int y = 0;
            id_model = 0;
            id_model_params = 0;
            id_model_adv = 0;
            if (p1 > 0 && p2 <= 0)
            {
                dt_db = cr.ImportData.ReturnSourceTable("SELECT id, id_subject, id_tax, id_time, S, E, id_model FROM Data_model_subject_tax WHERE (id_subject=" + cr.ImportData.Var.IdSubject + ")", dwTableModel);
                if (dt_db.Rows.Count > 0) { y = 1; } else y = 0;
            }
            if (p2 > 0 && p1 > 0)
            {
                dt_db = cr.ImportData.ReturnSourceTable("SELECT " + dwTableModel + ".id, " + dwTableModel + ".id_subject, " + dwTableModel + ".id_tax, " + dwTableModel + ".id_time, " + dwTableModel + ".S, " + dwTableModel + ".E, " + dwTableModel + ".id_model, Data_models.type_model FROM " + dwTableModel + " INNER JOIN Data_models ON " + dwTableModel + ".id_model = Data_models.id WHERE (id_subject=" + cr.ImportData.Var.IdSubject + ") AND (id_tax=" + cr.ImportData.Var.IdTax + ") AND (Data_models.type_model = " + cr.ImportData.Var.IdTypeModel + ")", dwTableModel);
                if (dt_db.Rows.Count > 0) { y = 2; id_model = cr.ImportData.returnNullInt(dt_db.Rows[0]["id_model"]); } else y = 0;
            }
            if (y > 1 && dt_db.Rows.Count > 0)
            {
                ids_model_adv = new int[dt_db.Rows.Count];
                for (int i = 0; i < dt_db.Rows.Count; i++)
                {
                    ids_model_adv[i] = cr.ImportData.returnNullInt(dt_db.Rows[i]["id"]);
                }
                //
                dt_db = cr.ImportData.ReturnSourceTable("SELECT id, id_model FROM dbo.Data_model_params WHERE (id_model = " + id_model + ")", dwTableModel);
                ids_model_params = new int[dt_db.Rows.Count];
                for (int i = 0; i < dt_db.Rows.Count; i++)
                {
                    ids_model_params[i] = cr.ImportData.returnNullInt(dt_db.Rows[i]["id"]);
                }
            }

            return y;
        }
        private int checkExistingModelSubjectBudgetTaxIndexes(DataTable dt, int p1 = 0, int p2 = 0, int p3 = 0)
        {
            int y = 0;
            id_model = 0;
            id_model_params = 0;
            id_model_adv = 0;
            if (p1 > 0 && p2 <= 0)
            {
                dt_db = cr.ImportData.ReturnSourceTable("SELECT id, id_subject, id_tax, id_time, S, E, id_model FROM Data_model_subject_tax WHERE (id_subject=" + cr.ImportData.Var.IdSubject + ")", dwTableModel);
                if (dt_db.Rows.Count > 0) { y = 1; } else y = 0;
            }
            if (p2 > 0 && p1 > 0)
            {
                dt_db = cr.ImportData.ReturnSourceTable("SELECT " + dwTableModel + ".id, " + dwTableModel + ".id_subject, " + dwTableModel + ".id_tax, " + dwTableModel + ".id_time, " + dwTableModel + ".S, " + dwTableModel + ".E, " + dwTableModel + ".id_model, Data_models.type_model FROM " + dwTableModel + " INNER JOIN Data_models ON " + dwTableModel + ".id_model = Data_models.id WHERE (id_subject=" + cr.ImportData.Var.IdSubject + ") AND (id_tax=" + cr.ImportData.Var.IdTax + ") AND (Data_models.type_model = " + cr.ImportData.Var.IdTypeModel + ")", dwTableModel);
                if (dt_db.Rows.Count > 0) { y = 2; id_model = cr.ImportData.returnNullInt(dt_db.Rows[0]["id_model"]); } else y = 0;
            }
            if (y > 1 && dt_db.Rows.Count > 0)
            {
                ids_model_adv = new int[dt_db.Rows.Count];
                for (int i = 0; i < dt_db.Rows.Count; i++)
                {
                    ids_model_adv[i] = cr.ImportData.returnNullInt(dt_db.Rows[i]["id"]);
                }
                //
                dt_db = cr.ImportData.ReturnSourceTable("SELECT id, id_model FROM dbo.Data_model_params WHERE (id_model = " + id_model + ")", dwTableModel);
                ids_model_params = new int[dt_db.Rows.Count];
                for (int i = 0; i < dt_db.Rows.Count; i++)
                {
                    ids_model_params[i] = cr.ImportData.returnNullInt(dt_db.Rows[i]["id"]);
                }
            }

            return y;
        }
        private DataTable returnDinamicsDt(DataTable Dt0, string c_s = "", string c_d = "", bool one_col = false)
        {
            DataTable Dt1 = Dt0.Copy();
            DataTable Dt2 = Dt0.Copy();
            Dt1.TableName = Dt1.TableName + "_1";
            //обработка выборки
            int count = Dt1.Rows.Count;
            if (count <= 0) return Dt2;
            for (int i = 1; i < count; i++)
            {
                decimal prev = cr.ImportData.returnNullDecimal(Dt1.Rows[i - 1][c_s]);
                decimal cur = cr.ImportData.returnNullDecimal(Dt1.Rows[i][c_s]);
                Dt2.Rows[i][c_s] = returnDinamicsK(prev, cur);
                //
                if (!one_col)
                {
                    prev = cr.ImportData.returnNullDecimal(Dt1.Rows[i - 1][c_d]);
                    cur = cr.ImportData.returnNullDecimal(Dt1.Rows[i][c_d]);
                    Dt2.Rows[i][c_d] = returnDinamicsK(prev, cur);
                }
            }
            Dt2.Rows[0].Delete();
            Dt2.AcceptChanges();
            //
            return Dt2;
        }
        private DataTable returnMultiDinamicsDt(DataTable Dt0, int startIndexRow = 1, int startIndexCol = 1)
        {
            DataTable Dt1 = Dt0.Copy();
            DataTable Dt2 = Dt0.Copy();
            Dt1.TableName = Dt1.TableName + "_1";
            //обработка выборки
            int countR = Dt1.Rows.Count;
            int countC = Dt1.Columns.Count;
            if (countR <= 0 || countC <=0) return Dt2;
            for (int j = startIndexCol; j < countC; j++)
            {
                for (int i = startIndexRow; i < countR; i++)
                {
                decimal prev = cr.ImportData.returnNullDecimal(Dt1.Rows[i - 1][j]);
                decimal cur = cr.ImportData.returnNullDecimal(Dt1.Rows[i][j]);
                Dt2.Rows[i][j] = returnDinamicsK(prev, cur);
                }
            }
            Dt2.Rows[0].Delete();
            Dt2.AcceptChanges();
            //
            return Dt2;
        }
        private decimal returnDinamicsK(decimal prev, decimal curr)
        {
            if (prev == 0 || prev == null) return 0;
            return curr / prev;
        }
        public void ChooseBestModels()
        {
            int id_subject, id_tax;
            cr.Data.Base.DataBestModelsSubjectTaxTableAdapter = new base_nalogDataSetTableAdapters.Data_best_models_subject_taxTableAdapter();
            cr.Data.Base.SubjectsTableAdapter = new base_nalogDataSetTableAdapters.SubjectsTableAdapter();
            DataTable templ = new DataTable();
            DataRow templRow;
            bestModelSubjectTaxDataTable = new base_nalogDataSet.Data_best_models_subject_taxDataTable();
            idSubjects = new DataTable();
            idSubjects = cr.ImportData.ReturnSourceTable("SELECT id_subject FROM Data_model_subject_tax GROUP BY id_subject", "Data_model_subject_tax");
            taxDataTable = new DataTable();
            taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM Data_model_subject_tax GROUP BY id_tax", "Data_model_subject_tax");
            //Выбираем модели по налогам и субъектам
            //
            // SELECT Data_models.id, Data_model_subject_tax.id_subject, Data_model_subject_tax.id_tax, Data_model_subject_tax.id_model, Data_models.R2, Data_models.F, Data_models.F001, Data_models.F005 FROM Data_model_subject_tax INNER JOIN Data_models ON Data_model_subject_tax.id_model = Data_models.id GROUP BY Data_model_subject_tax.id_subject, Data_model_subject_tax.id_tax, Data_model_subject_tax.id_model, Data_models.R2, Data_models.F, Data_models.F001, Data_models.F005, Data_models.id HAVING (dbo.Data_model_subject_tax.id_subject = 78) AND (dbo.Data_model_subject_tax.id_tax = 1520)
            //id_subject, id_tax, id_model, R2, F, F001, F005
            //SELECT     Data_model_subject_tax.id, Data_models.id AS id_model, Data_model_subject_tax.id_subject, Data_model_subject_tax.id_tax, Data_models.R2, Data_models.F, Data_models.F001, Data_models.F005 FROM Data_model_subject_tax INNER JOIN Data_models ON Data_model_subject_tax.id_model = Data_models.id GROUP BY Data_model_subject_tax.id_subject, Data_model_subject_tax.id_tax, Data_models.R2, Data_models.F, Data_models.F001, Data_models.F005, Data_models.id, Data_model_subject_tax.id HAVING (Data_model_subject_tax.id_subject = 78) AND (Data_model_subject_tax.id_tax = 1520)
            //
            for (int i = 0; i < idSubjects.Rows.Count; i++)
            {
                id_subject = cr.ImportData.returnNullInt(idSubjects.Rows[i]["id_subject"]);
                for (int j = 0; j < taxDataTable.Rows.Count; j++)
                {
                    id_tax = cr.ImportData.returnNullInt(taxDataTable.Rows[j]["id_tax"]);
                    DataTable best1 = cr.ImportData.ReturnSourceTable("SELECT Data_model_subject_tax.id, Data_models.id AS id_model, Data_model_subject_tax.id_subject, Data_model_subject_tax.id_tax, Data_models.R2, Data_models.F, Data_models.F001, Data_models.F005 FROM Data_model_subject_tax INNER JOIN Data_models ON Data_model_subject_tax.id_model = Data_models.id GROUP BY Data_model_subject_tax.id_subject, Data_model_subject_tax.id_tax, Data_models.R2, Data_models.F, Data_models.F001, Data_models.F005, Data_models.id, Data_model_subject_tax.id HAVING (Data_model_subject_tax.id_subject = " + id_subject + ") AND (Data_model_subject_tax.id_tax = " + id_tax + ")", "Data_model_subject_tax");
                    templ = best1.Clone();
                    //Выбираем лучшую
                    decimal R2, F, F001, F005, R2t, Ft;
                    int id;
                    foreach (DataRow row in best1.Rows)
                    {
                        R2 = cr.ImportData.returnNullDecimal(row["R2"]);
                        F = cr.ImportData.returnNullDecimal(row["F"]);
                        F001 = cr.ImportData.returnNullDecimal(row["F001"]);
                        F005 = cr.ImportData.returnNullDecimal(row["F005"]);
                        if (templ.Rows.Count < 1)
                        {
                            templ.ImportRow(row);
                        }
                        else
                        {
                            R2t = cr.ImportData.returnNullDecimal(templ.Rows[0]["R2"]);
                            Ft = cr.ImportData.returnNullDecimal(templ.Rows[0]["F"]);
                            if (((R2 >= (decimal)0.6 && R2 > R2t) || (R2 <= (decimal)-0.6 && R2 < R2t)) && (F > F005 && F > Ft))
                            {
                                templ.Rows.Clear();
                                templ.ImportRow(row);
                            }
                        }
                    }
                    if (templ.Rows.Count > 0)
                    {
                        bestModelSubjectTaxRow = bestModelSubjectTaxDataTable.NewData_best_models_subject_taxRow();
                        bestModelSubjectTaxRow.id_model = (int)templ.Rows[0]["id_model"];
                        bestModelSubjectTaxRow.id_model_subject_tax = (int)templ.Rows[0]["id"];
                        bestModelSubjectTaxRow.id_subject = (int)templ.Rows[0]["id_subject"];
                        bestModelSubjectTaxRow.id_tax = (int)templ.Rows[0]["id_tax"];
                        bestModelSubjectTaxDataTable.Rows.Add(bestModelSubjectTaxRow);
                        cr.Data.Base.DataBestModelsSubjectTaxTableAdapter.Update(bestModelSubjectTaxDataTable);
                        templ.Rows.Clear();
                    }
                }
            }
            //Clean th bests
            cr.Data.Base.DataBestModelsSubjectTaxTableAdapter.Fill(bestModelSubjectTaxDataTable);
            for (int i = 0; i < bestModelSubjectTaxDataTable.Rows.Count; i++)
            {
                DataTable clean = cr.ImportData.ReturnSourceTable("SELECT id FROM Data_models WHERE (id = " + cr.ImportData.returnNullInt(bestModelSubjectTaxDataTable.Rows[i]["id_model"]) + ")", "Data_models");
                if (clean == null) bestModelSubjectTaxDataTable.Rows[i].Delete();
                if (clean.Rows.Count <= 0) bestModelSubjectTaxDataTable.Rows[i].Delete();
            }
            base_nalogDataSet.Data_best_models_subject_taxDataTable deletedRows = (base_nalogDataSet.Data_best_models_subject_taxDataTable)bestModelSubjectTaxDataTable.GetChanges(DataRowState.Deleted);
            try
            {
                if (deletedRows != null)
                {
                    cr.Data.Base.DataBestModelsSubjectTaxTableAdapter.Update(deletedRows);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (deletedRows != null)
                {
                    deletedRows.Dispose();
                }
            }


            //
        }
        public void TakeCorrelationTaxEea(bool isCleaning = false)
        {
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id_subject FROM         dbo.Data_warehouse_subject_tax GROUP BY id_subject", "idSubjects");
            }
            //
            foreach (DataRow rowSubject in idSubjects.Rows)
            {
                int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);
                bool y = true;
                if (cr.ImportData.Var.IsIdSubject)
                {
                    y = false;
                    if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                }
                createTablesAndAdapters(id_subject);
                if (y)
                {
                    //

                    //
                    foreach (DataRow rowTax in taxDataTable.Rows)
                    {
                        //Выбираем налог
                        int id_tax = cr.ImportData.returnNullInt(rowTax["id_tax"]);
                        foreach (DataRow rowEea in eeaDataTable.Rows)
                        {
                            int id_eea = cr.ImportData.returnNullInt(rowEea["id_eea"]);
                            string query = "SELECT dbo.Data_warehouse_subject_tax.id_subject, dbo.Data_warehouse_subject_tax.id_tax, dbo.Data_warehouse_subject_eea.id_eea, dbo.Time.id, " +
                                " dbo.Time.calendar_year AS year, dbo.Data_warehouse_subject_eea.ti_eea_subject, dbo.Data_warehouse_subject_tax.ti_tax_subject" +
                                " FROM         dbo.Data_warehouse_subject_eea INNER JOIN" +
                                    " dbo.Data_warehouse_subject_tax ON dbo.Data_warehouse_subject_eea.id_subject = dbo.Data_warehouse_subject_tax.id_subject INNER JOIN" +
                                    " dbo.Time ON dbo.Data_warehouse_subject_eea.id_time = dbo.Time.id AND dbo.Data_warehouse_subject_tax.id_time = dbo.Time.id" +
                                " WHERE     (dbo.Data_warehouse_subject_tax.id_subject = " + id_subject + ") AND (dbo.Data_warehouse_subject_tax.id_tax = " + id_tax + ") AND (dbo.Data_warehouse_subject_eea.id_eea = " + id_eea + ")" +
                                " ORDER BY year";
                            dt = cr.ImportData.ReturnSourceTable(query, "Correlation");
                            decimal R2 = calculateCorrelation("P", dt, "ti_tax_subject", "ti_eea_subject");
                            decimal R2_significance = (decimal)calculateCorrelationSignificance("P", dt.Rows.Count, (double)R2);
                            decimal R2_Spirmen = calculateCorrelation("S", dt, "ti_tax_subject", "ti_eea_subject");
                            decimal R2_Spirmen_significance = (decimal)calculateCorrelationSignificance("S", dt.Rows.Count, (double)R2);
                            if ((R2 > (decimal)0.7 || R2 < (decimal)-0.7) &&
                                (R2_significance <= (decimal)0.05) ||
                             ((R2_Spirmen > (decimal)0.7 || R2_Spirmen < (decimal)-0.7) && (R2_Spirmen_significance <= (decimal)0.05)))
                            {
                                correlationSubjectTaxEeaTotalRow = correlationSubjectTaxEeaTotalDataTable.NewData_correlation_subject_tax_eea_totalRow();
                                correlationSubjectTaxEeaTotalRow.id_subject = id_subject;
                                correlationSubjectTaxEeaTotalRow.id_tax = id_tax;
                                correlationSubjectTaxEeaTotalRow.id_eea = id_eea;
                                correlationSubjectTaxEeaTotalRow.R2 = R2;
                                correlationSubjectTaxEeaTotalRow.R2_significance = R2_significance;
                                correlationSubjectTaxEeaTotalRow.R2_Spirmen = R2_Spirmen;
                                correlationSubjectTaxEeaTotalRow.R2_Spirmen_significance = R2_Spirmen_significance;
                                correlationSubjectTaxEeaTotalDataTable.AddData_correlation_subject_tax_eea_totalRow(correlationSubjectTaxEeaTotalRow);
                            }
                        }
                        //
                    }
                }
                cr.Data.Base.CorrelationSubjectTaxEeaTotalTableAdapter.Update(correlationSubjectTaxEeaTotalDataTable);
            }
        }
        public void TakeCorrelationTaxIndexes(bool isCleaning = false)
        {
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            //
            //years
            string whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }
            tableModel = "Scheme_values";
            indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            if (cr.ImportData.Var.IdSubject > 0)
            {
                createCorrelationTaxIndexes(cr.ImportData.Var.IdSubject, whereYears,isCleaning);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);
                    createCorrelationTaxIndexes(id_subject, whereYears,isCleaning);
                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                }
            }
        }
        private void createCorrelationTaxIndexes(int id_subject = 0, string whereYears = "", bool isCleaning = false)
        {
            if (id_subject == 0 || whereYears.Length <= 0) return;

            createTablesAndAdaptersTaxIndexes(id_subject);
            //cleaning
            if (isCleaning)
            {
                cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter.DeleteQuery(id_subject);
            }
            foreach (DataRow rowTax in taxDataTable.Rows)
            {
                //Выбираем налог
                int id_tax = cr.ImportData.returnNullInt(rowTax["id_tax"]);
                foreach (DataRow row in indexesDataTable.Rows)
                {
                    int id_index = cr.ImportData.returnNullInt(row["id"]);
                    string query =
                        "SELECT " + row["name_source_view"] + "." + row["name_field_view"] + ", dbo.Data_warehouse_subject_tax.ti_tax_subject " +
                        "FROM " + row["name_source_view"] + " INNER JOIN " +
                            "dbo.Data_warehouse_subject_tax ON " + row["name_source_view"] + ".id_subject = dbo.Data_warehouse_subject_tax.id_subject INNER JOIN " +
                            "dbo.Time ON " + row["name_source_view"] + ".id_time = dbo.Time.id AND dbo.Data_warehouse_subject_tax.id_time = dbo.Time.id " +
                        "WHERE     (dbo.Data_warehouse_subject_tax.id_subject = " + id_subject + ") AND (dbo.Data_warehouse_subject_tax.id_tax = " + id_tax + ") " + whereYears +
                        "ORDER BY year";
                    dt = cr.ImportData.ReturnSourceTable(query, "Correlation");
                    string c_s = "ti_tax_subject";
                    string c_d = row["name_field_view"].ToString().Trim();
                    dt = returnDinamicsDt(dt, c_s, c_d);
                    decimal R2 = calculateCorrelation("P", dt, c_s, c_d);
                    decimal R2_significance = (decimal)calculateCorrelationSignificance("P", dt.Rows.Count, (double)R2);
                    decimal R2_Spirmen = calculateCorrelation("S", dt, c_s, c_d);
                    decimal R2_Spirmen_significance = (decimal)calculateCorrelationSignificance("S", dt.Rows.Count, (double)R2);
                    if (((R2 > (decimal)0.7 || R2 < (decimal)-0.7) &&
                           (R2_significance <= (decimal)0.05)) ||
                        ((R2_Spirmen > (decimal)0.7 || R2_Spirmen < (decimal)-0.7) && (R2_Spirmen_significance <= (decimal)0.05)))
                    {
                        correlationSubjectTaxIndexesRow = correlationSubjectTaxIndexesDataTable.NewData_correlation_subject_tax_indexesRow();
                        correlationSubjectTaxIndexesRow.id_subject = id_subject;
                        correlationSubjectTaxIndexesRow.id_tax = id_tax;
                        correlationSubjectTaxIndexesRow.id_index = id_index;
                        correlationSubjectTaxIndexesRow.R2 = R2;
                        correlationSubjectTaxIndexesRow.R2_significance = R2_significance;
                        correlationSubjectTaxIndexesRow.R2_Spirmen = R2_Spirmen;
                        correlationSubjectTaxIndexesRow.R2_Spirmen_significance = R2_Spirmen_significance;
                        correlationSubjectTaxIndexesDataTable.AddData_correlation_subject_tax_indexesRow(correlationSubjectTaxIndexesRow);
                    }
                }
                //
            }
            cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter.Update(correlationSubjectTaxIndexesDataTable);
        }
        public void TakeCorrelationSubjectValues(bool isCleaning = false)
        {
            #region отбираем субъекты
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            #endregion отбираем субъекты
            #region устанавливаем параметр лет
            //
            //years
            string whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }
            #endregion устанавливаем параметр лет
            tableModel = "Scheme_values";
            indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            //DataTable indexesDataTable2 = new DataTable();
            //indexesDataTable2 = indexesDataTable;
            if (cr.ImportData.Var.IdSubject > 0)
            {
                createCorrelationSubjectValues(cr.ImportData.Var.IdSubject, whereYears, isCleaning);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);
                    
                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                    if (!y) continue;
                    createCorrelationSubjectValues(id_subject, whereYears, isCleaning);
                }
            }
        }
        private void createCorrelationSubjectValues(int id_subject = 0, string whereYears = "", bool isCleaning = false)
        {
            if (id_subject == 0 || whereYears.Length <= 0) return;

            createTablesAndAdaptersSubjectValues(id_subject);
            if (isCleaning)
            {
                cr.Data.Base.CorrelationSubjectValuesTableAdapter.DeleteQuery(id_subject);
            }
            //Выбираем первый показатель
            foreach (DataRow row in indexDataTable.Rows)
            {
                //Выбираем показатель
                int id_index1 = cr.ImportData.returnNullInt(row["id"]);
                foreach (DataRow row2 in indexesDataTable.Rows)
                {
                    int id_index2 = cr.ImportData.returnNullInt(row2["id"]);
                    string query =
                        "SELECT vks1." + row["name_field_view"] + " AS index_name1, vks2." + row2["name_field_view"] + " AS index_name2 " +
                        "FROM " + row["name_source_view"] + " AS vks1 INNER JOIN " +
                            row2["name_source_view"] + " AS vks2 ON vks1.id_subject = vks2.id_subject INNER JOIN " +
                            "dbo.Time ON vks1.id_time = dbo.Time.id AND vks2.id_time = dbo.Time.id " +
                        " WHERE (vks1.id_subject = " + id_subject + ") AND (vks2.id_subject = " + id_subject + ") " + whereYears +
                        " ORDER BY vks1.year";
                    dt = cr.ImportData.ReturnSourceTable(query, "Correlation");
                    string c_s = "index_name1";
                    string c_d = "index_name2";
                    dt = returnDinamicsDt(dt, c_s, c_d);
                    decimal R2 = calculateCorrelation("P", dt, c_s, c_d);
                    decimal R2_significance = (decimal)calculateCorrelationSignificance("P", dt.Rows.Count, (double)R2);
                    decimal R2_Spirmen = calculateCorrelation("S", dt, c_s, c_d);
                    decimal R2_Spirmen_significance = (decimal)calculateCorrelationSignificance("S", dt.Rows.Count, (double)R2);
                    if (((R2 > (decimal)0.5 || R2 < (decimal)-0.5) &&
                           (R2_significance <= (decimal)0.05)) ||
                        ((R2_Spirmen > (decimal)0.5 || R2_Spirmen < (decimal)-0.5) && (R2_Spirmen_significance <= (decimal)0.05)))
                    {
                        correlationSubjectValuesRow = correlationSubjectValuesDataTable.NewData_correlation_subject_valuesRow();
                        correlationSubjectValuesRow.id_subject = id_subject;
                        correlationSubjectValuesRow.id_value1 = id_index1;
                        correlationSubjectValuesRow.id_value2 = id_index2;
                        correlationSubjectValuesRow.R2 = R2;
                        correlationSubjectValuesRow.R2_significance = R2_significance;
                        correlationSubjectValuesRow.R2_Spirmen = R2_Spirmen;
                        correlationSubjectValuesRow.R2_Spirmen_significance = R2_Spirmen_significance;
                        correlationSubjectValuesRow.count_spreading = dt.Rows.Count;
                        correlationSubjectValuesRow.low_spreading = false;
                        if (dt.Rows.Count < 100) correlationSubjectValuesRow.low_spreading = true;
                        correlationSubjectValuesDataTable.AddData_correlation_subject_valuesRow(correlationSubjectValuesRow);
                    }
                }
                //
            }
            cr.Data.Base.CorrelationSubjectValuesTableAdapter.Update(correlationSubjectValuesDataTable);
        }  
        public void TakeCorrelationCollectionTaxIndexesSubjectValues(bool isCleaning = false)
        {
            #region отбираем субъекты
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            #endregion отбираем субъекты

            //tableModel = "Scheme_values";
            //indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);

            if (cr.ImportData.Var.IdSubject > 0)
            {
                createCorrelationCollectionTaxIndexesSubjectValues(cr.ImportData.Var.IdSubject, isCleaning);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);

                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                    if (!y) continue;
                    createCorrelationCollectionTaxIndexesSubjectValues(id_subject, isCleaning);
                }
            }
        }
        private void createCorrelationCollectionTaxIndexesSubjectValues(int id_subject = 0, bool isCleaning = false)
        {
            if (id_subject == 0) return;
            //if (id_subject < 82) return;

            createTablesAndAdaptersTaxIndexesnSubjectValues(id_subject);

            //cleaning
            if (isCleaning)
            {
                cr.Data.Base.CorrelationCollectionTableAdapter.DeleteQuery(id_subject);
            }

            //1
            //
            correlationCollectionDataTable.Clear();
            string query = "SELECT id, id_subject, id_tax, id_index, id_budget, R2, R2_Spirmen, R2_significance, R2_Spirmen_significance, time_period, elasticity_linear, count_spreading, low_spreading FROM dbo.Data_correlation_subject_tax_budget_indexes" +
                            " WHERE (id_subject = " + id_subject + ")";

            dt = cr.ImportData.ReturnSourceTable(query, "Correlation1");
            foreach (DataRow row in dt.Rows)
            {
                correlationCollectionRow = correlationCollectionDataTable.NewTable_correlationsRow();
                correlationCollectionRow.id_subject = cr.ImportData.returnNullInt(row["id_subject"]);
                correlationCollectionRow.id_budget = cr.ImportData.returnNullInt(row["id_budget"]);
                correlationCollectionRow.id_index1 = cr.ImportData.returnNullInt(row["id_tax"]);
                correlationCollectionRow.id_index2 = cr.ImportData.returnNullInt(row["id_index"]);
                correlationCollectionRow.R2 = cr.ImportData.returnNullDecimal(row["R2"]);
                correlationCollectionRow.R2_Spirmen = cr.ImportData.returnNullDecimal(row["R2_Spirmen"]);
                correlationCollectionRow.R2_Spirmen_significance = cr.ImportData.returnNullDecimal(row["R2_Spirmen_significance"]);
                correlationCollectionRow.R2_significance = cr.ImportData.returnNullDecimal(row["R2_significance"]);
                correlationCollectionRow.type_index1 = "tax_budget";
                correlationCollectionRow.type_index2 = "index";
                correlationCollectionRow.count_spreading = cr.ImportData.returnNullInt(row["count_spreading"]);
                correlationCollectionRow.low_spreading = cr.ImportData.returnNullBool(row["low_spreading"]);
                correlationCollectionRow.source_table = "Data_correlation_subject_tax_budget_indexes";
                //
                query = "SELECT tax_name, short_tax_name FROM dbo.Taxes WHERE (id = " + correlationCollectionRow.id_index1 + ")";
                dt_add = cr.ImportData.ReturnSourceTable(query, "index1");
                //
                if (dt_add.Rows.Count > 0)
                {
                    correlationCollectionRow.index1_name = dt_add.Rows[0]["tax_name"].ToString();
                    correlationCollectionRow.index1_short_name = dt_add.Rows[0]["short_tax_name"].ToString();
                }
                //
                query = "SELECT name, latin_name, name_short FROM dbo.Scheme_values WHERE (id = " + correlationCollectionRow.id_index2 + ")";
                dt_add = cr.ImportData.ReturnSourceTable(query, "index2");
                //
                if (dt_add.Rows.Count > 0)
                {
                    correlationCollectionRow.index2_name = dt_add.Rows[0]["name_short"].ToString();
                    correlationCollectionRow.index2_short_name = dt_add.Rows[0]["name_short"].ToString();
                    correlationCollectionRow.index2_latin_name = dt_add.Rows[0]["name"].ToString();
                }
                //
                correlationCollectionDataTable.AddTable_correlationsRow(correlationCollectionRow);
            }
            cr.Data.Base.CorrelationCollectionTableAdapter.Update(correlationCollectionDataTable);

            //2
            correlationCollectionDataTable.Clear();
            query = "SELECT id, id_subject, id_value1, id_value2, R2,R2_significance,R2_Spirmen,R2_Spirmen_significance, count_spreading, low_spreading FROM dbo.Data_correlation_subject_values" +
                            " WHERE (id_subject = " + id_subject + ")";
            dt = cr.ImportData.ReturnSourceTable(query, "Correlation2");
            foreach (DataRow row in dt.Rows)
            {
                correlationCollectionRow = correlationCollectionDataTable.NewTable_correlationsRow();
                correlationCollectionRow.id_subject = cr.ImportData.returnNullInt(row["id_subject"]);
                //correlationCollectionRow.id_budget = cr.ImportData.returnNullInt(row["id_budget"]);
                correlationCollectionRow.id_index1 = cr.ImportData.returnNullInt(row["id_value1"]);
                correlationCollectionRow.id_index2 = cr.ImportData.returnNullInt(row["id_value2"]);
                correlationCollectionRow.R2 = cr.ImportData.returnNullDecimal(row["R2"]);
                correlationCollectionRow.R2_Spirmen = cr.ImportData.returnNullDecimal(row["R2_Spirmen"]);
                correlationCollectionRow.R2_Spirmen_significance = cr.ImportData.returnNullDecimal(row["R2_Spirmen_significance"]);
                correlationCollectionRow.R2_significance = cr.ImportData.returnNullDecimal(row["R2_significance"]);
                correlationCollectionRow.type_index1 = "index";
                correlationCollectionRow.type_index2 = "index";
                correlationCollectionRow.count_spreading = cr.ImportData.returnNullInt(row["count_spreading"]);
                correlationCollectionRow.low_spreading = cr.ImportData.returnNullBool(row["low_spreading"]);
                correlationCollectionRow.source_table = "Data_correlation_subject_values";
                //
                query = "SELECT name, latin_name, name_short FROM dbo.Scheme_values WHERE (id = " + correlationCollectionRow.id_index1 + ")";
                dt_add = cr.ImportData.ReturnSourceTable(query, "index1");
                //
                if (dt_add.Rows.Count > 0)
                {
                    correlationCollectionRow.index1_name = dt_add.Rows[0]["name_short"].ToString();
                    correlationCollectionRow.index1_short_name = dt_add.Rows[0]["name_short"].ToString();
                    correlationCollectionRow.index1_latin_name = dt_add.Rows[0]["name"].ToString();
                }
                //
                query = "SELECT name, latin_name, name_short FROM dbo.Scheme_values WHERE (id = " + correlationCollectionRow.id_index2 + ")";
                dt_add = cr.ImportData.ReturnSourceTable(query, "index2");
                //
                if (dt_add.Rows.Count > 0)
                {
                    correlationCollectionRow.index2_name = dt_add.Rows[0]["name_short"].ToString();
                    correlationCollectionRow.index2_short_name = dt_add.Rows[0]["name_short"].ToString();
                    correlationCollectionRow.index2_latin_name = dt_add.Rows[0]["name"].ToString();
                }
                //
                correlationCollectionDataTable.AddTable_correlationsRow(correlationCollectionRow);
            }
            cr.Data.Base.CorrelationCollectionTableAdapter.Update(correlationCollectionDataTable);
            //3
            /*correlationCollectionDataTable.Clear();
            query = "SELECT id, id_subject, id_index, id_budget, R2, R2_Spirmen, R2_significance, R2_Spirmen_significance, time_period, elasticity_linear FROM dbo.Data_correlation_subject_budget_indexes" +
                            " WHERE (id_subject = " + id_subject + ")";

            dt = cr.ImportData.ReturnSourceTable(query, "Correlation3");
            foreach (DataRow row in dt.Rows)
            {
                correlationCollectionRow = correlationCollectionDataTable.NewTable_correlationsRow();
                correlationCollectionRow.id_subject = cr.ImportData.returnNullInt(row["id_subject"]);
                correlationCollectionRow.id_budget = cr.ImportData.returnNullInt(row["id_budget"]);
                //correlationCollectionRow.id_index1 = cr.ImportData.returnNullInt(row["id_tax"]);
                correlationCollectionRow.id_index2 = cr.ImportData.returnNullInt(row["id_index"]);
                correlationCollectionRow.R2 = cr.ImportData.returnNullDecimal(row["R2"]);
                correlationCollectionRow.R2_Spirmen = cr.ImportData.returnNullDecimal(row["R2_Spirmen"]);
                correlationCollectionRow.R2_Spirmen_significance = cr.ImportData.returnNullDecimal(row["R2_Spirmen_significance"]);
                correlationCollectionRow.R2_significance = cr.ImportData.returnNullDecimal(row["R2_significance"]);
                correlationCollectionRow.type_index1 = "budget";
                correlationCollectionRow.type_index2 = "index";
                correlationCollectionRow.source_table = "Data_correlation_subject_budget_indexes";
                //
                query = "SELECT name, latin_name, name_short FROM dbo.Scheme_values WHERE (id = " + correlationCollectionRow.id_index2 + ")";
                dt_add = cr.ImportData.ReturnSourceTable(query, "index2");
                //
                if (dt_add.Rows.Count > 0)
                {
                    correlationCollectionRow.index2_name = dt_add.Rows[0]["name_short"].ToString();
                    correlationCollectionRow.index2_short_name = dt_add.Rows[0]["name_short"].ToString();
                    correlationCollectionRow.index2_latin_name = dt_add.Rows[0]["name"].ToString();
                }
                //
                correlationCollectionDataTable.AddTable_correlationsRow(correlationCollectionRow);
            }
            cr.Data.Base.CorrelationCollectionTableAdapter.Update(correlationCollectionDataTable);*/
        }
        public void TakeCorrelationBudgetIndexes(bool isCleaning = false)
        {
            #region отбираем субъекты
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            #endregion отбираем субъекты
            #region устанавливаем параметр лет
            //
            //years
            string whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }
            #endregion устанавливаем параметр лет
            tableModel = "Scheme_values";
            indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            //DataTable indexesDataTable2 = new DataTable();
            //indexesDataTable2 = indexesDataTable;
            if (cr.ImportData.Var.IdSubject > 0)
            {
                createCorrelationBudgetIndexes(cr.ImportData.Var.IdSubject, whereYears, isCleaning);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);

                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                    if (!y) continue;
                    createCorrelationBudgetIndexes(id_subject, whereYears, isCleaning);
                }
            }
            /******************/
        }
        private void createCorrelationBudgetIndexes(int id_subject = 0, string whereYears = "", bool isCleaning = false)
        {
            if (id_subject == 0 || whereYears.Length <= 0) return;

            createTablesAndAdaptersBudgetIndexes(id_subject);
            if (isCleaning)
            {
                cr.Data.Base.CorrelationSubjectBudgetIndexesTableAdapter.DeleteQuery(id_subject);
            }
            foreach (DataRow rowBudget in budgetDataTable.Rows)
            {
                //Выбираем бюджет
                int id_budget = cr.ImportData.returnNullInt(rowBudget["id_budget"]);
                foreach (DataRow row in indexesDataTable.Rows)
                {
                    int id_index = cr.ImportData.returnNullInt(row["id"]);
                    string query =
                        "SELECT " + row["name_source_view"] + "." + row["name_field_view"] + ", vks1.total_ti_budget " +
                        "FROM " + row["name_source_view"] + " INNER JOIN " +
                            "[tax-177_nalog].View_dw_total_ti_budgets_subjects AS vks1 ON " + row["name_source_view"] + ".id_subject = vks1.id_subject INNER JOIN " +
                            "dbo.Time ON " + row["name_source_view"] + ".id_time = dbo.Time.id AND vks1.id_t = dbo.Time.id " +
                        "WHERE     (vks1.id_subject = " + id_subject + ") " +
                                    "AND (vks1.id_budget = " + id_budget + ") " + whereYears +
                        "ORDER BY vks1.year";

                    dt = cr.ImportData.ReturnSourceTable(query, "Correlation");
                    string c_s = "total_ti_budget";
                    string c_d = row["name_field_view"].ToString().Trim();
                    dt = returnDinamicsDt(dt, c_s, c_d);
                    decimal R2 = calculateCorrelation("P", dt, c_s, c_d);
                    decimal R2_significance = (decimal)calculateCorrelationSignificance("P", dt.Rows.Count, (double)R2);
                    decimal R2_Spirmen = calculateCorrelation("S", dt, c_s, c_d);
                    decimal R2_Spirmen_significance = (decimal)calculateCorrelationSignificance("S", dt.Rows.Count, (double)R2);
                    if ((R2 > (decimal)0.7 || R2 < (decimal)-0.7) &&
                           (R2_significance <= (decimal)0.05) ||
                        ((R2_Spirmen > (decimal)0.7 || R2_Spirmen < (decimal)-0.7) && (R2_Spirmen_significance <= (decimal)0.05)))
                    {
                        if (CheckCorrelationBudgetIndexes(id_subject, id_index, id_budget, "Data_correlation_subject_budget_indexes") == 0)
                        {
                            correlationSubjectBudgetIndexesRow = correlationSubjectBudgetIndexesDataTable.NewData_correlation_subject_budget_indexesRow();
                            correlationSubjectBudgetIndexesRow.id_subject = id_subject;
                            correlationSubjectBudgetIndexesRow.id_index = id_index;
                            correlationSubjectBudgetIndexesRow.id_budget = id_budget;
                            correlationSubjectBudgetIndexesRow.R2 = R2;
                            correlationSubjectBudgetIndexesRow.R2_significance = R2_significance;
                            correlationSubjectBudgetIndexesRow.R2_Spirmen = R2_Spirmen;
                            correlationSubjectBudgetIndexesRow.R2_Spirmen_significance = R2_Spirmen_significance;
                            if (whereYears.Length > 0)
                            {
                                correlationSubjectBudgetIndexesRow.time_period = cr.ImportData.Var.YearAfter + "-" + cr.ImportData.Var.YearBefore;
                            }
                            correlationSubjectBudgetIndexesDataTable.AddData_correlation_subject_budget_indexesRow(correlationSubjectBudgetIndexesRow);
                        }
                    }
                }
                //
            }
            cr.Data.Base.CorrelationSubjectBudgetIndexesTableAdapter.Update(correlationSubjectBudgetIndexesDataTable);
        }
        
        public void TakeCorrelationSubjectСoefficientsTaxBudget(bool isCleaning = false)
        {
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            //
            //years
            string whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }

            indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + "[dbo].Scheme_values" + " WHERE (type_value LIKE 'coeff')", "[dbo].Scheme_values");
            
            if (cr.ImportData.Var.IdSubject > 0)
            {
               createCorrelationTaxIndexes(cr.ImportData.Var.IdSubject, whereYears, isCleaning);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);
                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                    if (!y) continue;

                    createCorrelationTaxIndexes(id_subject, whereYears, isCleaning);
                }
            }
            ////////////////////////
        }
        private void createCorrelationSubjectСoefficientsTaxBudget(int id_subject = 0, string whereYears = "", bool isCleaning = false)
        {
            if (id_subject == 0 || whereYears.Length <= 0) return;
            //
            createTablesAndAdaptersTaxBudgetIndexes(id_subject, false);
            //years
            if (isCleaning)
            {
                cr.Data.Base.CorrelationSubjectTaxBudgetIndexesTableAdapter.DeleteQuery(id_subject);
            }

            //

            //
            foreach (DataRow rowTax in taxDataTable.Rows)
            {
                //Выбираем налог
                int id_tax = cr.ImportData.returnNullInt(rowTax["id_tax"]);
                foreach (DataRow rowBudget in budgetDataTable.Rows)
                {
                    int id_budget = cr.ImportData.returnNullInt(rowBudget["id_budget"]);
                    foreach (DataRow row in indexesDataTable.Rows)
                    {
                        int id_index = cr.ImportData.returnNullInt(row["id"]);
                        string query =
                            "SELECT " + row["name_source_view"] + "." + row["name_field_view"] + ", dbo.Data_warehouse_subject_budget.ti " +
                            "FROM " + row["name_source_view"] + " INNER JOIN " +
                                "dbo.Data_warehouse_subject_budget ON " +
                                row["name_source_view"] + ".id_subject = dbo.Data_warehouse_subject_budget.id_subject AND " +
                                row["name_source_view"] + ".id_budget = dbo.Data_warehouse_subject_budget.id_budget INNER JOIN " +
                                "dbo.Time ON " + row["name_source_view"] + ".id_time = dbo.Time.id AND dbo.Data_warehouse_subject_budget.id_time = dbo.Time.id " +
                            "WHERE     (" + row["name_source_view"] + ".id_subject = " + id_subject + ") " +
                                        "AND (" + row["name_source_view"] + ".id_tax = " + id_tax + ") " +
                                        "AND (" + row["name_source_view"] + ".id_budget = " + id_budget + ") " + whereYears +
                            "ORDER BY year";

                        dt = cr.ImportData.ReturnSourceTable(query, "Correlation");
                        string c_s = "ti";
                        string c_d = row["name_field_view"].ToString().Trim();
                        dt = returnDinamicsDt(dt, c_s, c_d);
                        decimal R2 = calculateCorrelation("P", dt, c_s, c_d);
                        decimal R2_significance = (decimal)calculateCorrelationSignificance("P", dt.Rows.Count, (double)R2);
                        decimal R2_Spirmen = calculateCorrelation("S", dt, c_s, c_d);
                        decimal R2_Spirmen_significance = (decimal)calculateCorrelationSignificance("S", dt.Rows.Count, (double)R2);
                        if ((R2 > (decimal)0.7 || R2 < (decimal)-0.7) &&
                               (R2_significance <= (decimal)0.05) ||
                            ((R2_Spirmen > (decimal)0.7 || R2_Spirmen < (decimal)-0.7) && (R2_Spirmen_significance <= (decimal)0.05)))
                        {
                            if (CheckCorrelationTaxBudgetIndexes(id_subject, id_tax, id_index, id_budget, "Data_correlation_subject_tax_budget_indexes") == 0)
                            {
                                correlationSubjectTaxBudgetIndexesRow = correlationSubjectTaxBudgetIndexesDataTable.NewData_correlation_subject_tax_budget_indexesRow();
                                correlationSubjectTaxBudgetIndexesRow.id_subject = id_subject;
                                correlationSubjectTaxBudgetIndexesRow.id_tax = id_tax;
                                correlationSubjectTaxBudgetIndexesRow.id_index = id_index;
                                correlationSubjectTaxBudgetIndexesRow.id_budget = id_budget;
                                correlationSubjectTaxBudgetIndexesRow.R2 = R2;
                                correlationSubjectTaxBudgetIndexesRow.R2_significance = R2_significance;
                                correlationSubjectTaxBudgetIndexesRow.R2_Spirmen = R2_Spirmen;
                                correlationSubjectTaxBudgetIndexesRow.R2_Spirmen_significance = R2_Spirmen_significance;
                                if (whereYears.Length > 0)
                                {
                                    correlationSubjectTaxBudgetIndexesRow.time_period = cr.ImportData.Var.YearAfter + "-" + cr.ImportData.Var.YearBefore;
                                }
                                correlationSubjectTaxBudgetIndexesDataTable.AddData_correlation_subject_tax_budget_indexesRow(correlationSubjectTaxBudgetIndexesRow);
                            }
                        }
                    }
                }
                //
            }
            cr.Data.Base.CorrelationSubjectTaxBudgetIndexesTableAdapter.Update(correlationSubjectTaxBudgetIndexesDataTable);
        }
        public void TakeCorrelationEeaBudgetIndexes(bool isCleaning = false)
        {
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            //
            //years
            string whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }

            //indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + "[dbo].Scheme_values" + " WHERE (type_value LIKE 'coeff')", "[dbo].Scheme_values");

            if (cr.ImportData.Var.IdSubject > 0)
            {
                createCorrelationEeaBudgetIndexes(cr.ImportData.Var.IdSubject, whereYears, isCleaning);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);
                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                    if (!y) continue;

                    createCorrelationEeaBudgetIndexes(id_subject, whereYears, isCleaning);
                }
            }
        }
        private void createCorrelationEeaBudgetIndexes(int id_subject = 0, string whereYears = "", bool isCleaning = false)
        {
            if (id_subject == 0) return;

            createTablesAndAdaptersEeaBudgetIndexes(id_subject);
            if (isCleaning)
            {
                cr.Data.Base.CorrelationSubjectEeaBudgetIndexesTableAdapter.DeleteQuery(id_subject);
            }
            //indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            
            //
            foreach (DataRow rowTax in eeaDataTable.Rows)
            {
                //Выбираем налог
                int id_eea = cr.ImportData.returnNullInt(rowTax["id_eea"]);
                foreach (DataRow rowBudget in budgetDataTable.Rows)
                {
                    int id_budget = cr.ImportData.returnNullInt(rowBudget["id_budget"]);
                    foreach (DataRow row in indexesDataTable.Rows)
                    {
                        int id_index = cr.ImportData.returnNullInt(row["id"]);
                        string query =
                            "SELECT " + row["name_source_view"] + "." + row["name_field_view"] + ", dbo.Data_warehouse_subject_eea_budget.ti " +
                            "FROM " + row["name_source_view"] + " INNER JOIN " +
                                "dbo.Data_warehouse_subject_eea_budget ON " + row["name_source_view"] + ".id_subject = dbo.Data_warehouse_subject_eea_budget.id_subject INNER JOIN " +
                                "dbo.Time ON " + row["name_source_view"] + ".id_time = dbo.Time.id AND dbo.Data_warehouse_subject_eea_budget.id_time = dbo.Time.id " +
                            "WHERE     (dbo.Data_warehouse_subject_eea_budget.id_subject = " + id_subject + ") " +
                                        "AND (dbo.Data_warehouse_subject_eea_budget.id_eea = " + id_eea + ") " +
                                        "AND (dbo.Data_warehouse_subject_eea_budget.id_budget = " + id_budget + ") " +
                            "ORDER BY year";
                        dt = cr.ImportData.ReturnSourceTable(query, "Correlation");
                        string c_s = "ti";
                        string c_d = row["name_field_view"].ToString().Trim();
                        dt = returnDinamicsDt(dt, c_s, c_d);
                        decimal R2 = calculateCorrelation("P", dt, c_s, c_d);
                        decimal R2_significance = (decimal)calculateCorrelationSignificance("P", dt.Rows.Count, (double)R2);
                        decimal R2_Spirmen = calculateCorrelation("S", dt, c_s, c_d);
                        decimal R2_Spirmen_significance = (decimal)calculateCorrelationSignificance("S", dt.Rows.Count, (double)R2);
                        if ((R2 > (decimal)0.7 || R2 < (decimal)-0.7) &&
                            (R2_significance <= (decimal)0.05) ||
                     ((R2_Spirmen > (decimal)0.7 || R2_Spirmen < (decimal)-0.7) && (R2_Spirmen_significance <= (decimal)0.05)))
                        {
                            correlationSubjectEeaBudgetIndexesRow = correlationSubjectEeaBudgetIndexesDataTable.NewData_correlation_subject_eea_budget_indexesRow();
                            correlationSubjectEeaBudgetIndexesRow.id_subject = id_subject;
                            correlationSubjectEeaBudgetIndexesRow.id_eea = id_eea;
                            correlationSubjectEeaBudgetIndexesRow.id_index = id_index;
                            correlationSubjectEeaBudgetIndexesRow.id_budget = id_budget;
                            correlationSubjectEeaBudgetIndexesRow.R2 = R2;
                            correlationSubjectEeaBudgetIndexesRow.R2_significance = R2_significance;
                            correlationSubjectEeaBudgetIndexesRow.R2_Spirmen = R2_Spirmen;
                            correlationSubjectEeaBudgetIndexesRow.R2_Spirmen_significance = R2_Spirmen_significance;
                            correlationSubjectEeaBudgetIndexesDataTable.AddData_correlation_subject_eea_budget_indexesRow(correlationSubjectEeaBudgetIndexesRow);
                        }
                    }
                }
                //
            }
            cr.Data.Base.CorrelationSubjectEeaBudgetIndexesTableAdapter.Update(correlationSubjectEeaBudgetIndexesDataTable);
        }
        public void TakeCorrelationTaxBudgetIndexes(bool isCleaning = false)
        {
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            //
            //years
            string whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }

            indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);

            if (cr.ImportData.Var.IdSubject > 0)
            {
                createCorrelationTaxBudgetIndexes(cr.ImportData.Var.IdSubject, whereYears, isCleaning);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);
                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                    if (!y) continue;

                    createCorrelationTaxBudgetIndexes(id_subject, whereYears, isCleaning);
                }
            }
        }
        private void createCorrelationTaxBudgetIndexes(int id_subject = 0, string whereYears = "", bool isCleaning = false)
        {
            if (id_subject == 0) return;

            createTablesAndAdaptersTaxBudgetIndexes(id_subject);
            if (isCleaning)
            {
                cr.Data.Base.CorrelationSubjectTaxBudgetIndexesTableAdapter.DeleteQuery(id_subject);
            }
            //
            foreach (DataRow rowTax in taxDataTable.Rows)
            {
                //Выбираем налог
                int id_tax = cr.ImportData.returnNullInt(rowTax["id_tax"]);
                foreach (DataRow rowBudget in budgetDataTable.Rows)
                {
                    int id_budget = cr.ImportData.returnNullInt(rowBudget["id_budget"]);
                    foreach (DataRow row in indexesDataTable.Rows)
                    {
                        int id_index = cr.ImportData.returnNullInt(row["id"]);
                        string query =
                            "SELECT " + row["name_source_view"] + "." + row["name_field_view"] + ", dbo.Data_warehouse_subject_tax_budget.ti " +
                            "FROM " + row["name_source_view"] + " INNER JOIN " +
                                "dbo.Data_warehouse_subject_tax_budget ON " + row["name_source_view"] + ".id_subject = dbo.Data_warehouse_subject_tax_budget.id_subject INNER JOIN " +
                                "dbo.Time ON " + row["name_source_view"] + ".id_time = dbo.Time.id AND dbo.Data_warehouse_subject_tax_budget.id_time = dbo.Time.id " +
                            "WHERE     (dbo.Data_warehouse_subject_tax_budget.id_subject = " + id_subject + ") " +
                                        "AND (dbo.Data_warehouse_subject_tax_budget.id_tax = " + id_tax + ") " +
                                        "AND (dbo.Data_warehouse_subject_tax_budget.id_budget = " + id_budget + ") " + whereYears +
                            "ORDER BY year";

                        dt = cr.ImportData.ReturnSourceTable(query, "Correlation");
                        string c_s = "ti";
                        string c_d = row["name_field_view"].ToString().Trim();
                        dt = returnDinamicsDt(dt, c_s, c_d);
                        decimal R2 = calculateCorrelation("P", dt, c_s, c_d);
                        decimal R2_significance = (decimal)calculateCorrelationSignificance("P", dt.Rows.Count, (double)R2);
                        decimal R2_Spirmen = calculateCorrelation("S", dt, c_s, c_d);
                        decimal R2_Spirmen_significance = (decimal)calculateCorrelationSignificance("S", dt.Rows.Count, (double)R2);
                        if ((R2 > (decimal)0.7 || R2 < (decimal)-0.7) &&
                               (R2_significance <= (decimal)0.05) ||
                            ((R2_Spirmen > (decimal)0.7 || R2_Spirmen < (decimal)-0.7) && (R2_Spirmen_significance <= (decimal)0.05)))
                        {
                            if (CheckCorrelationTaxBudgetIndexes(id_subject, id_tax, id_index, id_budget, "Data_correlation_subject_tax_budget_indexes") == 0)
                            {
                                correlationSubjectTaxBudgetIndexesRow = correlationSubjectTaxBudgetIndexesDataTable.NewData_correlation_subject_tax_budget_indexesRow();
                                correlationSubjectTaxBudgetIndexesRow.id_subject = id_subject;
                                correlationSubjectTaxBudgetIndexesRow.id_tax = id_tax;
                                correlationSubjectTaxBudgetIndexesRow.id_index = id_index;
                                correlationSubjectTaxBudgetIndexesRow.id_budget = id_budget;
                                correlationSubjectTaxBudgetIndexesRow.R2 = R2;
                                correlationSubjectTaxBudgetIndexesRow.R2_significance = R2_significance;
                                correlationSubjectTaxBudgetIndexesRow.R2_Spirmen = R2_Spirmen;
                                correlationSubjectTaxBudgetIndexesRow.R2_Spirmen_significance = R2_Spirmen_significance;
                                correlationSubjectTaxBudgetIndexesRow.count_spreading = dt.Rows.Count;
                                correlationSubjectTaxBudgetIndexesRow.low_spreading = false;
                                if (dt.Rows.Count < 100) correlationSubjectTaxBudgetIndexesRow.low_spreading = true;
                                if (whereYears.Length > 0)
                                {
                                    correlationSubjectTaxBudgetIndexesRow.time_period = cr.ImportData.Var.YearAfter + "-" + cr.ImportData.Var.YearBefore;
                                }
                                correlationSubjectTaxBudgetIndexesDataTable.AddData_correlation_subject_tax_budget_indexesRow(correlationSubjectTaxBudgetIndexesRow);
                            }
                        }
                    }
                }
                //
            }
            cr.Data.Base.CorrelationSubjectTaxBudgetIndexesTableAdapter.Update(correlationSubjectTaxBudgetIndexesDataTable);
        }
        private int CheckCorrelationTaxBudgetIndexes(int idSubj = 0, int id_tax = 0, int id_index = 0, int id_budget = 0, string sourceTableName = "")
        {
            /*
                 * Поиск в несколько этапов и определение действие с данными в таблице Корреляций
                 * */

            int y = -1;
            cr.ImportData.Var.SourceTableName = sourceTableName;
            string id_subject_filter = id_subject_filter = correlationSubjectTaxBudgetIndexesDataTable.id_subjectColumn.ToString();
            string filter = id_subject_filter + "=" + idSubj +
                " AND " + correlationSubjectTaxBudgetIndexesDataTable.id_taxColumn.ToString() + "=" + id_tax +
                " AND " + correlationSubjectTaxBudgetIndexesDataTable.id_indexColumn.ToString() + "=" + id_index +
                " AND " + correlationSubjectTaxBudgetIndexesDataTable.id_budgetColumn.ToString() + "=" + id_budget;
            string select = "SELECT * FROM " + sourceTableName + " WHERE " + filter;
            cr.ImportData.Var.SourceTable = cr.ImportData.ReturnSourceTable(select, sourceTableName);
            DataRow[] dRowLev1 = cr.ImportData.Var.SourceTable.Select();
            int count = dRowLev1.Length;
            int indexRow = 0;
            if (count <= 0) y = 0;
            else
            {
                foreach (DataRow lev1 in dRowLev1)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    //cr.ImportData.Var.Status = " проверяем";
                    if (idSubj == cr.ImportData.returnNullInt(lev1[id_subject_filter]) &&
                     id_tax == cr.ImportData.returnNullInt(lev1["id_tax"]) &&
                     id_index == cr.ImportData.returnNullInt(lev1["id_index"]) &&
                     id_budget == cr.ImportData.returnNullInt(lev1["id_budget"]))
                    {
                        cr.ImportData.Var.CheckedId = cr.ImportData.returnNullInt(lev1["id"]);
                        y = 1; //изменяем
                        step1 = true;

                    }
                    if (!step1 && indexRow > 1)
                    {
                        cr.ImportData.Var.CheckedId = cr.ImportData.returnNullInt(lev1["id"]);
                        //cr.ImportData.Var.Status = " удаляем ";
                        correlationSubjectTaxBudgetIndexesDataTable.FindByid(cr.ImportData.Var.CheckedId).Delete();
                        step2 = true;
                        y = 2; //удаляем
                    }
                    if (!step1 && !step2)
                    {
                        y = 0; //добавляем
                    }
                    /*if (idSubj == cr.ImportData.returnNullInt(lev1[id_subject_filter]) &&
                     id_tax == cr.ImportData.returnNullInt(lev1["id_tax"]) &&
                     id_index == cr.ImportData.returnNullInt(lev1["id_index"]) &&
                     id_budget == cr.ImportData.returnNullInt(lev1["id_budget"]) &&
                     impData.returnNullInt(var.InternalTable.Rows[index1][index2]) == cr.ImportData.returnNullInt(lev1[strCol]))
                    {
                        var.CheckedId = cr.ImportData.returnNullInt(lev1["id"]);
                        y = 3; //проверено
                        step3 = true;

                    }*/
                    /*bool exist = false;
                    if (cr.Data.Base.Ds.Tables[cr.ImportData.Var.SourceTableName].Rows.Count > 0)
                    {
                        for (int i = 0; i < cr.Data.Base.Ds.Tables[cr.ImportData.Var.SourceTableName].Rows.Count; i++)
                        {
                            DataRow r = cr.Data.Base.Ds.Tables[cr.ImportData.Var.SourceTableName].Rows[i];

                            if (cr.ImportData.returnNullInt(r["id"]) == cr.ImportData.returnNullInt(lev1["id"]))
                            {
                                exist = true;
                            }
                        }
                        if (!exist)
                        {
                            cr.Data.Base.Ds.Tables[cr.ImportData.Var.SourceTableName].ImportRow(lev1);
                        }
                    }
                    else
                    {
                        cr.Data.Base.Ds.Tables[cr.ImportData.Var.SourceTableName].ImportRow(lev1);
                    }*/
                    //
                }
                if (dRowLev1.Length <= 0)
                {
                    y = 0;
                }
                DataRow[] dRowLev2 = cr.Data.Base.Ds.Tables[cr.ImportData.Var.SourceTableName].Select(filter);
                if (dRowLev2.Length > 0) { y = 1; cr.ImportData.Var.CheckedId = cr.ImportData.returnNullInt(dRowLev2[0]["id"]); }
            }
            return y;

        }
        private int CheckCorrelationBudgetIndexes(int idSubj = 0, int id_index = 0, int id_budget = 0, string sourceTableName = "")
        {
            /*
                 * Поиск в несколько этапов и определение действие с данными в таблице Корреляций
                 * */

            int y = -1;
            cr.ImportData.Var.SourceTableName = sourceTableName;
            string id_subject_filter = id_subject_filter = correlationSubjectBudgetIndexesDataTable.id_subjectColumn.ToString();
            string filter = id_subject_filter + "=" + idSubj +
                " AND " + correlationSubjectBudgetIndexesDataTable.id_indexColumn.ToString() + "=" + id_index +
                " AND " + correlationSubjectBudgetIndexesDataTable.id_budgetColumn.ToString() + "=" + id_budget;
            string select = "SELECT * FROM " + sourceTableName + " WHERE " + filter;
            cr.ImportData.Var.SourceTable = cr.ImportData.ReturnSourceTable(select, sourceTableName);
            DataRow[] dRowLev1 = cr.ImportData.Var.SourceTable.Select();
            int count = dRowLev1.Length;
            int indexRow = 0;
            if (count <= 0) y = 0;
            else
            {
                foreach (DataRow lev1 in dRowLev1)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    //cr.ImportData.Var.Status = " проверяем";
                    if (idSubj == cr.ImportData.returnNullInt(lev1[id_subject_filter]) &&
                     id_index == cr.ImportData.returnNullInt(lev1["id_index"]) &&
                     id_budget == cr.ImportData.returnNullInt(lev1["id_budget"]))
                    {
                        cr.ImportData.Var.CheckedId = cr.ImportData.returnNullInt(lev1["id"]);
                        y = 1; //изменяем
                        step1 = true;

                    }
                    if (!step1 && indexRow > 1)
                    {
                        cr.ImportData.Var.CheckedId = cr.ImportData.returnNullInt(lev1["id"]);
                        //cr.ImportData.Var.Status = " удаляем ";
                        correlationSubjectTaxBudgetIndexesDataTable.FindByid(cr.ImportData.Var.CheckedId).Delete();
                        step2 = true;
                        y = 2; //удаляем
                    }
                    if (!step1 && !step2)
                    {
                        y = 0; //добавляем
                    }
                    //
                }
                if (dRowLev1.Length <= 0)
                {
                    y = 0;
                }
                DataRow[] dRowLev2 = cr.Data.Base.Ds.Tables[cr.ImportData.Var.SourceTableName].Select(filter);
                if (dRowLev2.Length > 0) { y = 1; cr.ImportData.Var.CheckedId = cr.ImportData.returnNullInt(dRowLev2[0]["id"]); }
            }
            return y;

        }

        public void TakeSortParametres(int id_subject = 0, string whereYears = "", bool isCleaning = false)
        {
            #region отбираем субъекты
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            #endregion отбираем субъекты
            #region устанавливаем параметр лет
            //
            //years
            whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }
            #endregion устанавливаем параметр лет
            string query = 
                        "SELECT  [tax-177_nalog].View_dw_total_ti_subjects.total_ti_subject, dbo.Data_warehouse_subject.share_unemployed_population_of_subjects, " +
                         "dbo.Data_warehouse_subject.busyed_population_subject, dbo.Data_warehouse_subject.unemployed_population_subject, " +
                         "dbo.Data_warehouse_subject.total_population_population_subject, dbo.Data_warehouse_subject.share_busyed_popupaltion_of_subjects, " +
                         "dbo.Data_warehouse_subject.share_busyed_popupaltion_of_subject_in_district, "+
                         "dbo.Data_warehouse_subject.share_unemployed_population_of_subject_in_distrcit, dbo.Data_warehouse_subject.share_total_population_population_of_subjects, "+
                         "dbo.Data_warehouse_subject.share_total_population_population_of_subject_in_district, dbo.Data_warehouse_subject.rmit_total_ti_tax_subject, "+
                         "dbo.Data_warehouse_subject.kdol_total_ti_tax_subject_in_district, dbo.Data_warehouse_subject.salary_subject, "+
                         "dbo.Data_warehouse_subject.salary_busyed_subject, dbo.Data_warehouse_subject.lawrence_accum_share_ti_in_district,"+ 
                         "dbo.Data_warehouse_subject.lawrence_accum_share_busyed_in_district, dbo.Data_warehouse_subject.lawrence_accum_share_ti_ideal_in_district, "+
                         "dbo.Data_warehouse_subject.lawrence_accum_share_busyed_ideal_in_district, dbo.Data_warehouse_subject.z, "+
                         "dbo.Data_warehouse_subject.kdol_total_ti_tax_of_subjects, dbo.Data_warehouse_subject.economic_active_population_subject, "+
                         "dbo.Data_warehouse_subject.level_of_unemployed_population_subject, dbo.Data_warehouse_subject.share_kdol_in_district, "+
                         "dbo.Data_warehouse_subject.share_kdol_of_subjects, dbo.Data_warehouse_subject.domestic_regional_product_subject, "+
                         "dbo.Data_warehouse_subject.consumer_price_index_subject, dbo.Data_warehouse_subject.cost_of_basic_funds_subject, "+
                         "dbo.Data_warehouse_subject.investment_in_basic_fund_subject, dbo.Data_warehouse_subject.fact_end_consumption_home_economy_on_territory_of_subject, "+
                         "dbo.Data_warehouse_subject.level_of_runout_of_basic_funds_subject, dbo.Data_warehouse_subject.total_ti_tax_region_budget_subject, "+
                         "dbo.Data_warehouse_subject.debt_ti_subject, dbo.Data_warehouse_subject.lawrence_accum_share_ti_in_country, "+
                         "dbo.Data_warehouse_subject.lawrence_accum_share_busyed_in_country, dbo.Data_warehouse_subject.lawrence_accum_share_busyed_ideal_in_country, "+
                         "dbo.Data_warehouse_subject.lawrence_accum_share_ti_ideal_in_country, dbo.Data_warehouse_subject.count_organizations_companies_subject, "+
                         "dbo.Data_warehouse_subject.avg_income_population_subject, dbo.Data_warehouse_subject.count_owns_auto_subject, "+
                         "dbo.Data_warehouse_subject.avg_consumption_population_subject, dbo.Data_warehouse_subject.production_agriculture_economy_subject, "+
                         "dbo.Data_warehouse_subject.volume_paid_services_subject, dbo.Data_warehouse_subject.morbidity_subject"+
                         "FROM            dbo.Data_warehouse_subject INNER JOIN"+
                         "dbo.Subjects ON dbo.Data_warehouse_subject.id_subject = dbo.Subjects.id INNER JOIN"+
                         "dbo.Federal_district ON dbo.Subjects.id_district = dbo.Federal_district.id INNER JOIN"+
                         "dbo.Time ON dbo.Data_warehouse_subject.id_time = dbo.Time.id INNER JOIN"+
                         "[tax-177_nalog].View_dw_total_ti_subjects ON dbo.Subjects.id = [tax-177_nalog].View_dw_total_ti_subjects.id_subject AND "+
                         "dbo.Time.calendar_year = [tax-177_nalog].View_dw_total_ti_subjects.year"+
                         " WHERE (dbo.Subjects.id = " + id_subject + ") " + whereYears +
                         "ORDER BY year";
            if (cr.ImportData.Var.IdSubject > 0)
            {
                dt = cr.ImportData.ReturnSourceTable(query, "Order1");
                dt = returnMultiDinamicsDt(dt, 1, 1);
            }
            if (dt.Rows.Count <= 0) return;
            //
            REngine.SetEnvironmentVariables(); // <-- May be omitted; the next line would call it.
            REngine engine = REngine.GetInstance();
            // A somewhat contrived but customary Hello World:
            CharacterVector charVec = engine.CreateCharacterVector(new[] { "Hello, R world!, .NET speaking" });
            engine.SetSymbol("greetings", charVec);
            engine.Evaluate("str(greetings)"); // print out in the console
            string[] a = engine.Evaluate("'Hi there .NET, from the R engine'").AsCharacter().ToArray();
            Console.WriteLine("R answered: '{0}'", a[0]);
            Console.WriteLine("Press any key to exit the program");
            Console.ReadKey();
            engine.Dispose();
        }
        private double[] returnArrayDoubleFromDt(DataTable Dt0, int index=0)
        {
            double[] arr = new double[Dt0.Rows.Count];
            for (int i = 0; i < Dt0.Rows.Count; i++)
            {
                arr[i] = cr.ImportData.returnNullDouble(Dt0.Rows[i][index]);
            }
            return arr;
        }
        public void cleanCorrelation()
        {
            //Data_correlation_subject_tax_budget_indexes
            string query =
                "truncate table Data_correlation_subject_tax_budget_indexes";
            DataTable dtDeleted = cr.ImportData.ReturnSourceTable(query, "Deleted");
            //
            query =
                "truncate table Data_correlation_subject_values";
            dtDeleted = cr.ImportData.ReturnSourceTable(query, "Deleted");
        }
        public void TakeFilterFactors()
        {
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            //
            //years
            string whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }
            tableModel = "Scheme_values";
            indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            if (cr.ImportData.Var.IdSubject > 0)
            {
                FilterFactors(cr.ImportData.Var.IdSubject, whereYears);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);
                    FilterFactors(id_subject, whereYears);
                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                }
            }
        }
        private void FilterFactors(int id_subject = 0, string whereYears = "", string additional = "")
        {
            if (id_subject == 0) return;

            createTablesAndAdaptersTaxIndexesnSubjectValues(id_subject);
            foreach (DataRow rowBudget in budgetDataTable.Rows)
            {
                //Выбираем бюджет
                int id_budget = cr.ImportData.returnNullInt(rowBudget["id_budget"]);
                string query = "SELECT id_subject, id_index1, id_index2, id_budget, low_spreading" +
                    " FROM dbo.Table_correlations" +
                    " WHERE (type_index1 LIKE 'tax_budget') AND (type_index2 LIKE 'index') AND (id_index2 <> id_index1) AND (id_budget = " + id_budget + ")" +
                    " GROUP BY id_subject, id_index1, id_index2, id_budget, low_spreading" +
                    " HAVING (id_subject = " + id_subject + ")" +
                    " ORDER BY id_index1";
                dt = cr.ImportData.ReturnSourceTable(query, "Order1");
                bool low_spreading = false;
                string strR2 = correlationCollectionDataTable.R2Column.ColumnName;
                string strR2Sign = correlationCollectionDataTable.R2_significanceColumn.ColumnName;
                foreach (DataRow row2 in dt.Rows)
                {
                    //Выбираем коэффициенты
                    int id_index1 = cr.ImportData.returnNullInt(row2["id_index1"]);
                    int id_index2 = cr.ImportData.returnNullInt(row2["id_index2"]);
                    low_spreading = cr.ImportData.returnNullBool(row2["low_spreading"]);
                    if (low_spreading)
                    {
                        strR2 = correlationCollectionDataTable.R2_SpirmenColumn.ColumnName;
                        strR2Sign = correlationCollectionDataTable.R2_Spirmen_significanceColumn.ColumnName;
                    }

                    query =
                        "SELECT id_subject, id_index1, COUNT(ABS(" + strR2 + ")) AS sum_r2 FROM dbo.Table_correlations " +
                        " WHERE     (type_index1 LIKE 'index') AND (type_index2 LIKE 'index') AND (id_index2 <> " + id_index2 + ")" +
                        " GROUP BY id_subject, id_index1" +
                        " HAVING      (id_subject = " + id_subject + ") AND (id_index1 = " + id_index2 + ")" +
                        " ORDER BY COUNT(ABS(" + strR2 + ")), id_index1";
                    DataTable dt2 = cr.ImportData.ReturnSourceTable(query, "Order2");
                    if (dt2.Rows.Count > 0)
                    {
                        bool low_relations = false;
                        decimal sum_r2 = cr.ImportData.returnNullDecimal(dt2.Rows[0]["sum_r2"]);
                        if (sum_r2 <= 1)
                        {
                            low_relations = true;
                            //additional += "";
                        }
                        else if (sum_r2 > 1)
                        {
                            int m_id_index1 = id_index2;
                            //Проверка фактора на дублирование

                            query =
                                "SELECT id_subject, id_index1, id_index2, " + strR2 + " FROM dbo.Table_correlations " +
                                " WHERE     (type_index1 LIKE 'index') AND (type_index2 LIKE 'index') AND (id_index2 <> " + id_index2 + ")" +
                                " GROUP BY id_subject, id_index1" +
                                " HAVING      (id_subject = " + id_subject + ") AND (id_index1 = " + m_id_index1 + ")" +
                                " ORDER BY SUM(ABS(" + strR2 + ")), id_index1";
                            DataTable dt3 = cr.ImportData.ReturnSourceTable(query, "Order3");

                            query = "SELECT id_subject, id_index1, id_index2, id_budget, low_spreading" +
                                " FROM dbo.Table_correlations" +
                                " WHERE (type_index1 LIKE 'tax_budget') AND (type_index2 LIKE 'index') AND (id_index2 <> id_index1) AND (id_budget = " + id_budget + ")" +
                                " GROUP BY id_subject, id_index1, id_index2, id_budget, low_spreading" +
                                " HAVING (id_subject = " + id_subject + ") AND (id_index1 = " + id_index1 + ") AND (low_relations = 1)" +
                                " ORDER BY id_index1";
                            DataTable dt4 = cr.ImportData.ReturnSourceTable(query, "Order4");
                            //int m_id_index2 = 0;
                            int countMatches = 0;

                            foreach (DataRow row3 in dt3.Rows)
                            {
                                int i1 = cr.ImportData.returnNullInt(row3["id_index2"]);
                                foreach (DataRow row4 in dt4.Rows)
                                {
                                    int i2 = cr.ImportData.returnNullInt(row3["id_index2"]);
                                    if (i1 == i2) countMatches++;
                                }
                            }
                            if (countMatches < 1) low_relations = true;
                        }
                        else low_relations = false;
                        //int id = cr.ImportData.returnNullInt(cr.Data.Base.CorrelationCollectionTableAdapter.GetDataBy2(id_subject, id_budget, id_index1, id_index2).Rows[0]["id"]);
                        try
                        {

                            cr.Data.Base.CorrelationCollectionTableAdapter.UpdateQuery(low_relations, id_subject, id_budget, id_index1, id_index2);
                        }
                        catch (System.Exception ex)
                        {
                            string er = ex.ToString();
                        }
                    }
                    //step 1
                    //
                }
            }

            //cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter.Update(correlationSubjectTaxIndexesDataTable);
        }
        public void TakeFunctions(bool isCleaning=false)
        {
            if (idSubjects == null)
            {
                idSubjects = cr.ImportData.ReturnSourceTable("SELECT     id as id_subject  FROM         dbo.Subjects", "idSubjects");
            }
            //
            //years
            string whereYears = "";
            if (cr.ImportData.Var.YearAfter > 0 || cr.ImportData.Var.YearBefore > 0)
            {
                whereYears = "AND";
                if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore <= 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") ";
                }
                else if (cr.ImportData.Var.YearAfter > 0 && cr.ImportData.Var.YearBefore > 0)
                {
                    whereYears += "(dbo.Time.calendar_year>=" + cr.ImportData.Var.YearAfter + ") AND (dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
                else
                {
                    whereYears += "(dbo.Time.calendar_year<=" + cr.ImportData.Var.YearBefore + ") ";
                }
            }

            if (cr.ImportData.Var.IdSubject > 0)
            {
                createFunctions(cr.ImportData.Var.IdSubject, whereYears,"",isCleaning);
            }
            else
            {
                foreach (DataRow rowSubject in idSubjects.Rows)
                {
                    int id_subject = cr.ImportData.returnNullInt(rowSubject["id_subject"]);
                    createFunctions(id_subject, whereYears,"",isCleaning);
                    bool y = true;
                    if (cr.ImportData.Var.IsIdSubject)
                    {
                        y = false;
                        if (cr.ImportData.Var.IdSubject == id_subject) y = true; else y = false;
                    }
                }
            }
        }
        private void createFunctions(int id_subject = 0, string whereYears = "", string additional = "", bool isCleaning = false)
        {
            if (id_subject == 0) return;
            //
            createTablesAndAdaptersCreateFunctions(id_subject);
            //
            if (isCleaning)
            {
                cr.Data.Base.DataModelSubjectBudgetTaxIndexesTableAdapter.DeleteQuery(id_subject);
            }
            //
            foreach (DataRow rowBudget in budgetDataTable.Rows)
            {
                //Выбираем бюджет
                int id_budget = cr.ImportData.returnNullInt(rowBudget["id_budget"]);
                foreach (DataRow rowTax in taxDataTable.Rows)
                {
                    #region налоги
                    //Выбираем налог
                    int id_tax = cr.ImportData.returnNullInt(rowTax["id_tax"]);
                    //
                    string query =
                        "SELECT id_subject, id_index1, id_index2, id_budget, R2" +
                        " FROM dbo.Table_correlations" +
                        " WHERE" +
                            " (type_index1 LIKE 'tax_budget')" +
                            " AND (type_index2 LIKE 'index')" +
                            " AND (id_index2 <> id_index1)" +
                            " AND (id_budget = " + id_budget + ")" +
                            " AND (low_relations = 1)" +
                        " GROUP BY id_subject, id_index1, id_index2, id_budget, R2" +
                        " HAVING" +
                            " (id_subject = " + id_subject + ")" +
                            " AND (id_index1 = " + id_tax + ")" +
                        " ORDER BY id_index1";
                    dt = cr.ImportData.ReturnSourceTable(query, "Order1");
                    if (dt.Rows.Count < 1) continue;
                    //
                    #endregion налоги
                    DataTable dtY = new DataTable();
                    DataTable dtX = new DataTable();
                    DataTable dtSecond = new DataTable();
                    DataTable dtAddX = new DataTable();
                    
                    #region показатели
                    sourceColumn = "ti";
                    query =
                        "SELECT dbo.Data_warehouse_subject_tax_budget.ti" +
                        " FROM dbo.Data_warehouse_subject_tax_budget INNER JOIN" +
                            " dbo.Time ON dbo.Data_warehouse_subject_tax_budget.id_time = dbo.Time.id" +
                        " WHERE" +
                        " (dbo.Data_warehouse_subject_tax_budget.id_subject = " + id_subject + ")" +
                        " AND (dbo.Data_warehouse_subject_tax_budget.id_tax = " + id_tax + ")" +
                        " AND (dbo.Data_warehouse_subject_tax_budget.id_budget = " + id_budget + ")" +
                        " " + whereYears +
                        "ORDER BY dbo.Time.calendar_year";
                    dtY = cr.ImportData.ReturnSourceTable(query, "Order2");
                    
                    //
                    int needCount = dtY.Rows.Count - 3;
                    if (dt.Rows.Count > needCount)
                    {
                        deleteFactors(out dt, out dtSecond, dt, needCount);
                    }
                    //
                    if (dtY.Rows.Count < 1) continue;
                    if (dt == null || dt.Rows.Count <=0) continue;
                    dtX.Columns.Add("index_one", typeof(double));
                    foreach (DataRow row1 in dtY.Rows)
                    {
                        DataRow row2 = dtX.NewRow();
                        row2["index_one"] = 1;
                        dtX.Rows.Add(row2);
                    }
                    //
                    #region первый набор показателей
                    #endregion показатели
                    foreach (DataRow row1 in dt.Rows)
                    {
                        #region Отбор показателей по налогу
                        //Отбор показателей по налогу
                        int id_index = cr.ImportData.returnNullInt(row1["id_index2"]);
                        if (cr.ImportData.Var.IdTax > 0 && id_tax != cr.ImportData.Var.IdTax) continue;
                        #region показателя нет
                        //
                        DataTable dt2 = cr.Data.Base.SchemeValuesTableAdapters.GetDataBy(id_index);
                        DataRow row2 = null;
                        if (dt2.Rows.Count > 0)
                        {
                            row2 = dt2.Rows[0];
                        }
                        else continue;
                        #endregion показателя нет
                        #region запрашиваем данные по показателю
                        query =
                                    "SELECT " + row2["name_source_view"] + "." + row2["name_field_view"] + " AS index_" + id_index +
                                    " FROM " + row2["name_source_view"] + " INNER JOIN " +
                                        "dbo.Time ON " + row2["name_source_view"] + ".id_time = dbo.Time.id" +
                                    " WHERE" +
                                    " (" + row2["name_source_view"] + ".id_subject = " + id_subject + ")" +
                                    " " + whereYears +
                                    " ORDER BY dbo.Time.calendar_year";
                        DataTable dt4 = cr.ImportData.ReturnSourceTable(query, "Order3");
                        #endregion запрашиваем данные по показателю
                        if (dt4.Rows.Count < 1) continue;
                        #region матричная таблица
                        //добравляем в матричную таблицу значения показателей
                        string columnName = dt4.Columns[0].ColumnName;
                        dtX.Columns.Add(columnName, typeof(double));
                        for (int i = 0; i < dtX.Rows.Count; i++)
                        {
                            try
                            {
                                dtX.Rows[i][columnName] = cr.ImportData.returnNullDouble(dt4.Rows[i][columnName]);
                            }
                            catch (System.Exception ex)
                            {
                                string er = ex.ToString();
                            }
                        }
                        #endregion матричная таблица
                        #endregion Отбор показателей по налогу
                    }
                    
                    #endregion первый набор показателей
                    #region второй набор показателей
                    foreach (DataRow row1 in dtSecond.Rows)
                    {
                        #region Отбор показателей по налогу
                        //Отбор показателей по налогу
                        int id_index = cr.ImportData.returnNullInt(row1["id_index2"]);
                        if (cr.ImportData.Var.IdTax > 0 && id_tax != cr.ImportData.Var.IdTax) continue;
                        #region показателя нет
                        //
                        DataTable dt2 = cr.Data.Base.SchemeValuesTableAdapters.GetDataBy(id_index);
                        DataRow row2 = null;
                        if (dt2.Rows.Count > 0)
                        {
                            row2 = dt2.Rows[0];
                        }
                        else continue;
                        #endregion показателя нет
                        #region запрашиваем данные по показателю
                        query =
                                    "SELECT " + row2["name_source_view"] + "." + row2["name_field_view"] + " AS index_" + id_index +
                                    " FROM " + row2["name_source_view"] + " INNER JOIN " +
                                        "dbo.Time ON " + row2["name_source_view"] + ".id_time = dbo.Time.id" +
                                    " WHERE" +
                                    " (" + row2["name_source_view"] + ".id_subject = " + id_subject + ")" +
                                    " " + whereYears +
                                    " ORDER BY dbo.Time.calendar_year";
                        DataTable dt4 = cr.ImportData.ReturnSourceTable(query, "Order3");
                        #endregion запрашиваем данные по показателю
                        if (dt4.Rows.Count < 1) continue;
                        #region матричная таблица
                        //добравляем в матричную таблицу значения показателей
                        string columnName = dt4.Columns[0].ColumnName;
                        dtAddX.Columns.Add(columnName, typeof(double));
                        for (int i = 0; i < dtAddX.Rows.Count; i++)
                        {
                            try
                            {
                                dtAddX.Rows[i][columnName] = cr.ImportData.returnNullDouble(dt4.Rows[i][columnName]);
                            }
                            catch (System.Exception ex)
                            {
                                string er = ex.ToString();
                            }
                        }
                        #endregion матричная таблица
                        #endregion Отбор показателей по налогу
                    }
                    #endregion второй набор показателей
                    dtX = returnMultiDinamicsDt(dtX);
                    dtY = returnDinamicsDt(dtY, sourceColumn, "", true);
                    dtAddX = returnMultiDinamicsDt(dtAddX);
                    #region формирование вектора (МНК)
                    //Анализируем таблицы и приводим к типу double[,]
                    int countRowsY = dtY.Rows.Count;
                    int countColumnsY = dtY.Columns.Count;
                    int countRowsX = dtX.Rows.Count;
                    int countColumnsX = dtX.Columns.Count;
                    double[,] matrixY = new double[countRowsY, countColumnsY];
                    double[,] matrixX = new double[countRowsX, countColumnsX];
                    if (countRowsX < 1 || countRowsY < 1) continue;
                    //Y
                    for (int i = 0; i < countRowsY; i++)
                    {
                        for (int j = 0; j < countColumnsY; j++)
                        {
                            matrixY[i, j] = cr.ImportData.returnNullDouble(dtY.Rows[i][j]);
                        }
                    }
                    //X
                    for (int i = 0; i < countRowsX; i++)
                    {
                        for (int j = 0; j < countColumnsX; j++)
                        {
                            matrixX[i, j] = cr.ImportData.returnNullDouble(dtX.Rows[i][j]);
                        }
                    }
                    if (matrixX.Length < 1) continue;
                    #region матрицы
                    //Матрицы
                    //Транспонирование
                    double[,] matrixX_T = TranspMatrix(matrixX); //траспонируем
                    if (matrixX_T == null) continue;
                    double[,] matrixX_TX = SMul(matrixX_T, matrixX); //пермножаем
                    if (matrixX_TX == null) continue;
                    double[,] matrixX_TY = SMul(matrixX_T, matrixY); //пермножаем
                    double[,] matrixX_TX_1 = Inverse(matrixX_TX); //обртная матрица
                    double[,] vector = SMul(matrixX_TX_1, matrixX_TY);
                    
                    #endregion матрицы
                    #endregion формирование вектора (МНК)
                    #region Дабвляем частный случай модели
                    //
                    tableModel = "Data_model_subject_budget_tax_indexes";
                    DataTable dtM = returnDt_SubjectBudgetTaxIndexes(
                        id_subject, 
                        id_budget, 
                        id_tax, 
                        0, 
                        vector, 
                        dt,
                        dtY,
                        dtX,
                        dtAddX,
                        matrixX,
                        matrixY, 
                        matrixX_TX_1,
                        matrixX_T);
                    if (dtM != null)
                    {
                        //
                        dataModelSubjectBudgetTaxIndexesRow = dataModelSubjectBudgetTaxIndexesDataTable.NewData_model_subject_budget_tax_indexesRow();
                        dataModelSubjectBudgetTaxIndexesRow.id_subject = id_subject;
                        dataModelSubjectBudgetTaxIndexesRow.id_tax = id_tax;
                        dataModelSubjectBudgetTaxIndexesRow.id_budget = id_budget;
                        dataModelSubjectBudgetTaxIndexesRow.id_model = id_model;
                        dataModelSubjectBudgetTaxIndexesRow.date_create = model_date_create;
                        dataModelSubjectBudgetTaxIndexesDataTable.Rows.Add(dataModelSubjectBudgetTaxIndexesRow);
                        cr.Data.Base.DataModelSubjectBudgetTaxIndexesTableAdapter.Update(dataModelSubjectBudgetTaxIndexesDataTable);
                    }
                    #endregion Дабвляем частный случай модели
                }
            }
        }
        private void deleteFactors(out DataTable dtNeed, out DataTable dtOut, DataTable dtIn, int needCount = 0)
        {
            //deleteAndSetOutFactors(dtNeed, dtOut, dtIn, needCount);
            dtNeed = deleteFactorsF(dtIn, needCount);
            dtOut = setOutFactors(dtIn, needCount);
        }
        private DataTable deleteFactorsF(DataTable dtIn, int needCount = 0)
        {
            //Функция удаления лишних факторов
            if (needCount <= 0) return null;
            if (dtIn.Rows.Count > 0)
            {
                dtIn.Rows[0].Delete();
            }
            dtIn.AcceptChanges();
            if (dtIn.Rows.Count > needCount) deleteFactorsF(dtIn, needCount);
            return dtIn;
        }
        private DataTable setOutFactors(DataTable dtIn, int needCount = 0, DataTable dtOut = null)
        {
            //Функция сохранения лишних факторов
            dtOut = new DataTable();
            dtOut = dtIn.Clone();
            DataTable dtInSave = null;
            dtInSave = dtIn.Clone();
            if (needCount <= 0) return null;
            if (dtInSave.Rows.Count > 0)
            {
                DataRow row = dtInSave.Rows[0];
                dtOut.ImportRow(row);
                dtInSave.Rows[0].Delete();
            }
            dtOut.AcceptChanges();
            dtInSave.AcceptChanges();
            if (dtIn.Rows.Count > needCount) setOutFactors(dtInSave, needCount, dtOut);
            return dtOut;
        }
        private DataTable returnDt(int i, int j = 0)
        {
            #region проверка условий
            DataTable dt = new DataTable();
            dt = cr.ImportData.ReturnSourceTable(returnSqlSelect(i, j), tableModel);
            if (dt.Rows.Count > 0) cr.ImportData.Var.IdSubject = cr.ImportData.returnNullInt(dt.Rows[0]["id_subject"]);
            int check1 = checkExistingModels(dt, 1, 0);
            int check2 = checkExistingModels(dt, 1, 1);
            if (check1 == 1 && check2 == 2)
            {
                deleteModel();
            }
            if (check1 == 1 && check2 == 1)
            {
                dt = null;
            }
            //
            #endregion проверка условий
            if (dt != null)
            {
                #region формализация переменных и таблиц
                //
                //
                //
                //Data_warehouse_subject_tax
                if (tableModel == "Data_warehouse_subject_tax")
                {
                    dt.TableName = taxDataTable.Rows[i]["id_tax"].ToString();
                }
                if (tableModel == "Compare_tax_eea")
                {
                    dt.TableName = taxDataTable.Rows[i]["id_tax"].ToString() + "_" + eeaDataTable.Rows[j]["id_eea"].ToString();
                }
                decimal avg = returnAvg(dt, sourceColumn); //среднее
                DataColumn dc = new DataColumn("t", System.Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("amplitude", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("avg_offset", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("avg_center_offset", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("season", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("T2", System.Type.GetType("System.Int32"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Y2", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("TY", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("YYcp2", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Si", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("YSi", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("T", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("TSi", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("E", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("YTSi2", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Ta0", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Ta1", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("R2", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("F", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("F001", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                dc = new DataColumn("F005", System.Type.GetType("System.Decimal"));
                dt.Columns.Add(dc);
                //Формируем таблицу для показателей
                DataTable dt_index = new DataTable(dt.TableName + "_index");
                for (int c = 0; c < cr.ImportData.Var.CountIntervals; c++)
                {
                    dt_index.Columns.Add("Column" + (c + 1).ToString(), System.Type.GetType("System.Decimal"));
                }
                double d = dt.Rows.Count / (double)cr.ImportData.Var.CountIntervals;
                int p = (int)d;
                for (int r = 0; r < p; r++)
                {
                    dt_index.Rows.Add();
                }
                #endregion формализация переменных и таблиц
                #region расчет статистиски
                //Расчет статистики
                /* 
                 * Амплитуда, скользящая средняя, центрированная скользящяя средняя, сезонный фактор 
                 * */
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    dt.Rows[r]["t"] = r + 1;
                    //
                    dt.Rows[r]["amplitude"] = returnAmplitude(dt, r, sourceColumn, avg); //амплитуда
                    dt.Rows[r]["avg_offset"] = returnAvgOffset(dt, r, sourceColumn); //средняя смещенная
                    dt.Rows[r]["avg_center_offset"] = returnAvgCenterOffset(dt, r, sourceColumn); //центрированная смещенаая средняя
                    dt.Rows[r]["season"] = returnSeason(dt, r, sourceColumn); //сезонный
                    //Расчет показателей
                    /*
                     * t^2, y^2, t*y, y(t), (Y-Ycp)^2
                     * */
                    dt.Rows[r]["T2"] = returnT2(dt, r, "t");
                    dt.Rows[r]["Y2"] = returnY2(dt, r, sourceColumn);
                    dt.Rows[r]["TY"] = returnTY(dt, r, "t", sourceColumn);
                    dt.Rows[r]["YYcp2"] = returnYYcp(dt, r, sourceColumn, avg);
                    //

                    //(y-y(t))^2

                }
                #endregion расчет статистиски
                #region Матрица
                //Рассчитываем показатели
                int countCol = 0;
                for (int r = 0; r < dt_index.Rows.Count; r++)
                {
                    for (int c = 0; c < dt_index.Columns.Count; c++)
                    {
                        dt_index.Rows[r][c] = cr.ImportData.returnNullDecimal(dt.Rows[countCol]["season"]);
                        countCol++;
                    }
                }
                decimal[] avgIndexS = new decimal[cr.ImportData.Var.CountIntervals];
                decimal[] avgIndexCorretedS = new decimal[cr.ImportData.Var.CountIntervals];
                decimal sumAvgIndexS = 0;
                for (int c = 0; c < dt_index.Columns.Count; c++)
                {
                    avgIndexS[c] = returnAvg(dt_index, dt_index.Columns[c].ColumnName);
                    sumAvgIndexS += avgIndexS[c];
                }
                //Коэффициент
                decimal k = 0;
                if (sumAvgIndexS != 0) k = cr.ImportData.Var.CountIntervals / sumAvgIndexS;
                for (int c = 0; c < avgIndexCorretedS.Length; c++)
                {
                    avgIndexCorretedS[c] = avgIndexS[c] * k;
                }
                #endregion Матрица
                //
                #region вычисление параметров
                switch (cr.ImportData.Var.NameTypeModel)
                {
                    case "Полиномная":
                        {
                            x = new double[dt.Rows.Count];
                            y = new double[dt.Rows.Count];

                            for (int r = 0; r < y.Length; r++)
                            {
                                x[r] = cr.ImportData.returnNullDouble(dt.Rows[r]["t"]);
                                y[r] = cr.ImportData.returnNullDouble(dt.Rows[r][sourceColumn]);
                            }
                            int info = 0;
                            alglib.barycentricinterpolant p1 = new alglib.barycentricinterpolant();
                            alglib.polynomialfitreport pr1 = new alglib.polynomialfitreport();
                            alglib.polynomialfit(x, y, 5, out info, out p1, out pr1);
                            alglib.polynomialbar2pow(p1, out k1);
                            paramValues = new double[k1.Length, 1];
                            for (int ik = 0; ik < k1.Length; ik++)
                            {
                                paramValues[ik, 0] = k1[ik];
                            }
                            break;
                        }
                    case "Линейная":
                        {
                            a1 = (((returnSum(dt, "t") * returnSum(dt, sourceColumn)) / dt.Rows.Count) - returnSum(dt, "TY")) / (returnSum(dt, "t") * returnSum(dt, "t") / dt.Rows.Count - returnSum(dt, "T2"));
                            a0 = (returnSum(dt, sourceColumn) - returnSum(dt, "t") * a1) / dt.Rows.Count;
                            paramValues = new double[1, 2];
                            paramValues[0, 0] = cr.ImportData.returnNullDouble(a0);
                            paramValues[0, 1] = cr.ImportData.returnNullDouble(a1);
                            break;
                        }
                }
                #endregion вычисление параметров
                #region проверка модели
                int count = 0;
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    if (count >= avgIndexCorretedS.Length) count = 0;
                    dt.Rows[r]["Si"] = avgIndexCorretedS[count];
                    if (cr.ImportData.returnNullDecimal(dt.Rows[r]["Si"]) != 0) dt.Rows[r]["YSi"] = cr.ImportData.returnNullDecimal(dt.Rows[r][sourceColumn]) / cr.ImportData.returnNullDecimal(dt.Rows[r]["Si"]);
                    decimal aT = 0;
                    switch (cr.ImportData.Var.NameTypeModel)
                    {
                        case "Полиномная":
                            {
                                if (k1.Length > 0)
                                {
                                    for (int a = 0; a < k1.Length; a++)
                                    {
                                        if (a <= 0) { aT += cr.ImportData.returnNullDecimal(k1[a]); }
                                        else
                                        {
                                            aT += cr.ImportData.returnNullDecimal(k1[a]) * cr.ImportData.returnNullDecimal(Math.Pow(cr.ImportData.returnNullInt(dt.Rows[r]["t"]), a));
                                        }
                                    }
                                }
                                break;
                            }
                        case "Линейная":
                            {
                                aT = a0 + a1 * cr.ImportData.returnNullInt(dt.Rows[r]["t"]);
                                break;
                            }
                    }
                    dt.Rows[r]["T"] = aT;
                    dt.Rows[r]["TSi"] = cr.ImportData.returnNullDecimal(dt.Rows[r]["Si"]) * cr.ImportData.returnNullDecimal(dt.Rows[r]["T"]);
                    if (cr.ImportData.returnNullDecimal(dt.Rows[r]["TSi"]) != 0) dt.Rows[r]["E"] = cr.ImportData.returnNullDecimal(dt.Rows[r][sourceColumn]) / cr.ImportData.returnNullDecimal(dt.Rows[r]["TSi"]);
                    dt.Rows[r]["YTSi2"] = (cr.ImportData.returnNullDecimal(dt.Rows[r][sourceColumn]) - cr.ImportData.returnNullDecimal(dt.Rows[r]["TSi"])) * (cr.ImportData.returnNullDecimal(dt.Rows[r][sourceColumn]) - cr.ImportData.returnNullDecimal(dt.Rows[r]["TSi"]));
                    count++;
                }
                decimal R2 = 0;
                if (returnSum(dt, "YYcp2") != 0) R2 = 1 - returnSum(dt, "YTSi2") / returnSum(dt, "YYcp2");
                decimal F1 = R2;
                decimal F2 = 1 - R2;
                decimal F3 = dt.Rows.Count - 1 - 1;
                decimal F4 = 1;
                decimal F = (F1 * F3) / (F2 * F4);
                if (F < 0) F = F * -1;
                decimal SumE = returnSum(dt, "E");
                decimal F001 = (decimal)alglib.invfdistribution(1, dt.Rows.Count - 1, 0.01);
                decimal F005 = (decimal)alglib.invfdistribution(1, dt.Rows.Count - 1, 0.05);
                //
                #endregion проверка модели
                //
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    dt.Rows[r]["R2"] = R2;
                    dt.Rows[r]["F"] = F;
                    dt.Rows[r]["F001"] = F001;
                    dt.Rows[r]["F005"] = F005;
                    dt.Rows[r]["Ta0"] = a0;
                    dt.Rows[r]["Ta1"] = a1;
                }
                #region добавляем модель
                ds.Tables.Add(dt_index);
                //
                int maxId = 0;
                //добавляем модель в базу
                if (paramValues != null)
                {
                    cr.Data.Base.DataModelsTableAdapter = new base_nalogDataSetTableAdapters.Data_modelsTableAdapter();
                    modelsDataTable = new base_nalogDataSet.Data_modelsDataTable();
                    modelsRow = modelsDataTable.NewData_modelsRow();
                    modelsRow.type_model = cr.ImportData.Var.IdTypeModel;
                    modelsRow.R2 = R2;
                    modelsRow.F = F;
                    modelsRow.F001 = F001;
                    modelsRow.F005 = F005;
                    modelsRow.table_name = tableModel;
                    modelsRow.field_name = sourceColumn;
                    modelsRow.count_intervals = cr.ImportData.Var.CountIntervals;
                    switch (tableModel)
                    {
                        case "ti_tax_subject":
                            {
                                modelsRow.table_model = "Data_model_subject_tax";
                                break;
                            }
                    }
                    modelsRow.date_create = DateTime.Now;
                    modelsDataTable.Rows.Add(modelsRow);
                }
                cr.Data.Base.DataModelsTableAdapter.Update(modelsDataTable);
                #endregion добавляем модель
                #region добавляем параметры модели
                //
                dt_prm = cr.ImportData.ReturnSourceTable("SELECT     MAX(id) AS id_max FROM         Data_models", "Data_models");
                if (dt_prm.Rows.Count > 0)
                {
                    maxId = cr.ImportData.returnNullInt(dt_prm.Rows[0][0]);
                }
                if (maxId > 0) id_model = maxId;
                //
                modelParamsDataTable = new base_nalogDataSet.Data_model_paramsDataTable();
                switch (cr.ImportData.Var.NameTypeModel)
                {
                    case "Полиномная":
                        {
                            for (int r = 0; r < paramValues.Length; r++)
                            {

                                modelParamsRow = modelParamsDataTable.NewData_model_paramsRow();
                                modelParamsRow.value = cr.ImportData.returnNullDecimal(paramValues[r, 0]);
                                if (r <= 0) { modelParamsRow.pow = 1; }
                                else { modelParamsRow.pow = r; modelParamsRow.argument = "x"; }
                                modelParamsRow.index = r;
                                modelParamsRow.id_model = id_model;
                                modelParamsDataTable.Rows.Add(modelParamsRow);

                            }
                            break;
                        }
                    case "Линейная":
                        {
                            for (int r = 0; r < paramValues.Length; r++)
                            {

                                modelParamsRow = modelParamsDataTable.NewData_model_paramsRow();
                                modelParamsRow.value = cr.ImportData.returnNullDecimal(paramValues[0, r]);
                                modelParamsRow.pow = 1;
                                if (r > 0) modelParamsRow.argument = "x";
                                modelParamsRow.index = r;
                                modelParamsRow.id_model = id_model;
                                modelParamsDataTable.Rows.Add(modelParamsRow);

                            }
                            break;
                        }
                }
                cr.Data.Base.DataModelParamsTableAdapter = new base_nalogDataSetTableAdapters.Data_model_paramsTableAdapter();
                cr.Data.Base.DataModelParamsTableAdapter.Update(modelParamsDataTable);
                #endregion добавляем параметры модели
            }
            return dt;
        }
        private DataTable returnDt_SubjectBudgetTaxIndexes(
            int id_subject = 0,
            int id_budget = 0,
            int id_tax = 0,
            int id_index = 0,
            double[,] vector = null,
            DataTable dtIndexes = null,
            DataTable dtY = null,
            DataTable dtX = null,
            DataTable dtAddX = null,
            double[,] matrixX = null,
            double[,] matrixY = null,
            double[,] matrixXT_X_1 = null,
            double[,] matrxiX_T = null)
        {
            if (vector == null) return null;
            if (vector.Length < 2) return null;
            #region формализация переменных и таблиц
            DataTable dtM = new DataTable();
            DataTable dtP = new DataTable();
            DataTable dtAddP = new DataTable();
            //dtX.Columns.Remove("index_one");
            if (vector != null)
            {
                //
                decimal avg = returnAvg(dtY, "ti"); //среднее
                //dtM
                dtM.Columns.Add("t", typeof(int));
                dtM.Columns.Add("amplitude", typeof(decimal));
                dtM.Columns.Add("avg_offset", typeof(decimal));
                dtM.Columns.Add("avg_center_offset", typeof(decimal));
                dtM.Columns.Add("season", typeof(decimal));
                dtM.Columns.Add("T2", typeof(decimal));
                dtM.Columns.Add("Y2", typeof(decimal));
                dtM.Columns.Add("Y", typeof(decimal));
                dtM.Columns.Add("TY", typeof(decimal));
                dtM.Columns.Add("YYcp2", typeof(decimal));
                dtM.Columns.Add("Si", typeof(decimal));
                dtM.Columns.Add("YSi", typeof(decimal));
                dtM.Columns.Add("TYcp2", typeof(decimal));
                dtM.Columns.Add("E", typeof(decimal)); //ошибка
                dtM.Columns.Add("E2", typeof(decimal));
                dtM.Columns.Add("E_1", typeof(decimal));
                dtM.Columns.Add("E-E_1", typeof(decimal));
                dtM.Columns.Add("E-E_1_2", typeof(decimal));
                dtM.Columns.Add("EE_1", typeof(decimal));
                dtM.Columns.Add("YTSi2", typeof(decimal));
                dtM.Columns.Add("R2", typeof(decimal));
                dtM.Columns.Add("F", typeof(decimal));
                dtM.Columns.Add("F001", typeof(decimal));
                dtM.Columns.Add("F005", typeof(decimal));
                dtM.Columns.Add("A", typeof(decimal));
                //dtP
                dtP.Columns.Add("value", typeof(decimal));
                dtP.Columns.Add("index", typeof(int));
                dtP.Columns.Add("pow", typeof(int));
                dtP.Columns.Add("argument", typeof(string));
                dtP.Columns.Add("id_model", typeof(int));
                dtP.Columns.Add("elasticity", typeof(decimal));
                dtP.Columns.Add("t", typeof(decimal));
                dtP.Columns.Add("t_left", typeof(decimal));
                dtP.Columns.Add("t_right", typeof(decimal));
                dtP.Columns.Add("St_R2_significant", typeof(bool));
                dtP.Columns.Add("E", typeof(decimal)); //ошибка
                dtP.Columns.Add("B", typeof(decimal));
                dtP.Columns.Add("S", typeof(decimal));
                dtP.Columns.Add("Si", typeof(decimal));
                dtP.Columns.Add("Si2", typeof(decimal));
                dtP.Columns.Add("t_significant", typeof(bool));
                dtP.Columns.Add("id_index", typeof(int));
                dtP.Columns.Add("elasticity_significant", typeof(bool));
                dtP.Columns.Add("SKO", typeof(decimal));
                dtP.Columns.Add("Si2_p", typeof(decimal));
                dtP.Columns.Add("Si_p", typeof(decimal));
                dtP.Columns.Add("DispQuery", typeof(decimal));
                dtP.Columns.Add("R2_E", typeof(decimal));
                dtP.Columns.Add("p_JarqBera1", typeof(decimal));
                dtP.Columns.Add("H_norm001", typeof(bool));
                dtP.Columns.Add("H_norm005", typeof(bool));
                dtP.Columns.Add("P_JarqBera1", typeof(decimal));
                dtP.Columns.Add("P_JarqBera2", typeof(decimal));
                dtP.Columns.Add("P_JarqBera3", typeof(decimal));
                dtP.Columns.Add("enabled", typeof(bool));
                //
                //dtAddP
                dtAddP.Columns.Add("value", typeof(decimal));
                dtAddP.Columns.Add("index", typeof(int));
                dtAddP.Columns.Add("pow", typeof(int));
                dtAddP.Columns.Add("argument", typeof(string));
                dtAddP.Columns.Add("id_model", typeof(int));
                dtAddP.Columns.Add("elasticity", typeof(decimal));
                dtAddP.Columns.Add("t", typeof(decimal));
                dtAddP.Columns.Add("t_left", typeof(decimal));
                dtAddP.Columns.Add("t_right", typeof(decimal));
                dtAddP.Columns.Add("St_R2_significant", typeof(bool));
                dtAddP.Columns.Add("E", typeof(decimal)); //ошибка
                dtAddP.Columns.Add("B", typeof(decimal));
                dtAddP.Columns.Add("S", typeof(decimal));
                dtAddP.Columns.Add("Si", typeof(decimal));
                dtAddP.Columns.Add("Si2", typeof(decimal));
                dtAddP.Columns.Add("t_significant", typeof(bool));
                dtAddP.Columns.Add("id_index", typeof(int));
                dtAddP.Columns.Add("elasticity_significant", typeof(bool));
                dtAddP.Columns.Add("SKO", typeof(decimal));
                dtAddP.Columns.Add("Si2_p", typeof(decimal));
                dtAddP.Columns.Add("Si_p", typeof(decimal));
                dtAddP.Columns.Add("DispQuery", typeof(decimal));
                dtAddP.Columns.Add("R2_E", typeof(decimal));
                dtAddP.Columns.Add("p_JarqBera1", typeof(decimal));
                dtAddP.Columns.Add("H_norm001", typeof(bool));
                dtAddP.Columns.Add("H_norm005", typeof(bool));
                dtAddP.Columns.Add("P_JarqBera1", typeof(decimal));
                dtAddP.Columns.Add("P_JarqBera2", typeof(decimal));
                dtAddP.Columns.Add("P_JarqBera3", typeof(decimal));
                dtAddP.Columns.Add("enabled", typeof(bool));
            }
            #endregion формализация переменных и таблиц
            #region расчет параметров
            //Несмещенная ошибка e = Y - X*vector
            double[,] e = MinusMatrix(matrixY, SMul(matrixX, vector)); // несмещенная ошибка
            //vector*e^2
            double[,] e_T = TranspMatrix(e);
            decimal se2 = (decimal)SMul(e_T, e)[0, 0];
            //Несмещенная оценка дисперсии равна
            decimal s2 = 0;
            int YV = matrixY.Length - vector.Length - 1;
            if (YV > 0)
            {
                s2 = ((decimal)1.0 / (YV)) * se2;
            }
            else
            {
                s2 = ((decimal)1.0 / (matrixY.Length - vector.Length)) * se2;
            }
            //Оценка среднеквадратичного отклонения равна 
            decimal d = (decimal)Math.Sqrt((double)s2);
            //Найдем оценку ковариационной матрицы вектора k = σ*(XTX)-1
            int countRows = 0;
            int countColumns = 0;
            returnMatrixParam(matrixXT_X_1, out countRows, out countColumns);
            double[,] k = new double[countRows, countColumns];
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    k[i, j] = (double)d * matrixXT_X_1[i, j];
                }
            }
            //Выборочные дисперсии

            //
            #endregion расчет параметров
            #region проверка модели
            decimal avgY = returnAvg(dtY, "ti");
            //R Теснота совместных факторов
            for (int i = 0; i < dtY.Rows.Count; i++)
            {
                decimal TY = 0;
                DataRow row = dtM.NewRow();
                for (int v = 0; v < vector.Length; v++)
                {
                    if (v < 1)
                    {
                        TY += cr.ImportData.returnNullDecimal(vector[v, 0]);
                    }
                    else
                    {
                        TY += cr.ImportData.returnNullDecimal(vector[v, 0]) * cr.ImportData.returnNullDecimal(dtX.Rows[i][v]);
                    }
                }

                row["Y"] = dtY.Rows[i]["ti"];
                row["TY"] = TY; // теория
                if ((decimal)row["Y"] != 0)
                {
                    row["A"] = Math.Abs((decimal)row["Y"] - (decimal)row["TY"]) / (decimal)row["Y"];
                    row["E"] = (decimal)row["Y"] - (decimal)row["TY"]; //e
                }
                else
                {
                    row["A"] = (decimal)0;
                }
                row["Y2"] = returnY2(dtY, i, "ti");
                row["T2"] = TY * TY;
                
                dtM.Rows.Add(row);
            }
            //Дисперсия Y
            //decimal S_Y = 
            decimal avgT = returnAvg(dtM, "T");
            double[] e0 = new double[dtY.Rows.Count];
            double[] e1 = new double[dtY.Rows.Count];
            double[] y = new double[dtY.Rows.Count];
            double[] ye1 = new double[dtY.Rows.Count];
            double[] ye2 = new double[dtY.Rows.Count];
            
            //
            for (int i = 0; i < dtM.Rows.Count; i++)
            {
                DataRow row = dtM.Rows[i];
                row["E2"] = returnY2(dtM, i, "E"); //e^2
                //
                if (i > 0)
                {
                    row["E_1"] = cr.ImportData.returnNullDecimal(row["E"]);
                    row["E-E_1"] = cr.ImportData.returnNullDecimal(row["E"]) - cr.ImportData.returnNullDecimal(row["E_1"]);
                    row["E-E_1_2"] = returnY2(dtM, i, "EE_1");
                }
                else
                {
                    row["E_1"] = 0;
                }
                //
                e0[i] = cr.ImportData.returnNullDouble(row["E"]);
                e1[i] = e0[i] * e0[i];
                //
                y[i] = cr.ImportData.returnNullDouble(row["Y"]);
                ye1[i] = cr.ImportData.returnNullDouble(row["TY"]);
                ye2[i] = cr.ImportData.returnNullDouble(row["E"]);
                //
            }
            //
            for (int i = 0; i < dtY.Rows.Count; i++)
            {
                DataRow row = dtM.Rows[i];
                row["YYcp2"] = returnYYcp(dtY, i, "ti", avgY);
                row["TYcp2"] = returnTYcp(dtM, dtY, i, "T", "ti");
            }
            //Дисперсия Y
            decimal SiY = returnDISP(dtY, "ti");
            #region Коэффициент детерминации
            string charR2 = "P";
            if (dtY.Rows.Count < 10) charR2 = "S";
            decimal R2 = calculateCorrelation(charR2, dtM, "Y", "TY");
            decimal R2_E = 0;
            //R2_E = calculateCorrelation(charR2, null, "", "", e1, e2);
            decimal R2_YE = calculateCorrelation(charR2, null, "", "", ye1, ye2);
            #endregion Коэффициент детерминации
            #endregion проверка модели
            #region Значимость коэффициента корреляции
            decimal Q = (decimal)calculateCorrelationSignificance(charR2, dtM.Rows.Count, (double)R2);
            #region проверка значений
            //Табличное значение стьюдента
            #region t-статистика
            decimal St = cr.ImportData.returnNullDecimal(Math.Sqrt(Math.Abs((double)R2)) * (Math.Sqrt(dtY.Rows.Count - 2) / Math.Sqrt((double)(1 - R2))));
            decimal St2k = cr.ImportData.returnNullDecimal(alglib.invstudenttdistribution(dtY.Rows.Count - (vector.Length - 1) - 1, 0.05 / 2));
            St2k = cr.ImportData.returnAbsDecimal(St2k);
            decimal St001 = cr.ImportData.returnNullDecimal(alglib.invstudenttdistribution(dtY.Rows.Count - (vector.Length - 1) - 1, 0.01)); //p_alglib = 1.0 - (0.5 * p_Excel)
            St001 = cr.ImportData.returnAbsDecimal(St001);
            decimal St005 = cr.ImportData.returnNullDecimal(alglib.invstudenttdistribution(dtY.Rows.Count - (vector.Length - 1) - 1, 0.05));
            St005 = cr.ImportData.returnAbsDecimal(St005);
            #endregion t-статистика
            #region Апроксимация
            decimal A = returnSum(dtM, "A") / dtY.Rows.Count;
            #endregion Апроксимация
            #region F-статистика
            decimal F1 = R2;
            decimal F2 = 1 - R2;
            decimal F3 = (vector.Length - 1) - dtM.Rows.Count - 1;
            decimal F4 = 1;
            decimal F = 0;
            decimal R2_XE = 0;
            try
            {
                F = (F1 * F3) / (F2 * F4);
            }
            catch (System.Exception ex)
            {
                F = 0;
            }
            if (F < 0) F = F * -1;
            decimal F001 = (decimal)alglib.invfdistribution((vector.Length - 1), dtM.Rows.Count - (vector.Length - 1) - 1, 0.01);
            decimal F005 = (decimal)alglib.invfdistribution((vector.Length - 1), dtM.Rows.Count - (vector.Length - 1) - 1, 0.05);
            #endregion F-статистика
            #endregion проверка значений
            #endregion Значимость коэффициента корреляции
            //ds.Tables.Add(dt_index);
            //
            //Анализ точности определения оценок коэффициентов регрессии
            #region анализ остатков
            //ошибка
            #endregion анализ остатков


            #region Анализ точности
            decimal SumTYcp2 = returnSum(dtM, "TYcp2");
            decimal Sre = (decimal)Math.Sqrt((double)SumTYcp2 / (matrixY.Length - (vector.Length - 1) - 1));
            for (int i = 0; i < dtY.Rows.Count; i++)
            {
                DataRow row = dtM.Rows[i];
                row["YYcp2"] = returnYYcp(dtY, i, "ti", avgY);
                row["TYcp2"] = returnTYcp(dtM, dtY, i, "T", "ti");
                //
            }
            #region частные коэффициенты эластичности
            //частные коэффициенты эластичности
            #region первая выборка
            for (int i = 0; i < vector.Length; i++)
            {
                DataRow row = dtP.NewRow();
                charR2 = "P";
                //
                row["value"] = cr.ImportData.returnNullDecimal(vector[i, 0]);
                row["pow"] = 1;
                row["id_index"] = 0;
                //
                double p_jarq1 = 0;
                double p_jarq2 = 0;
                double p_jarq3 = 0;
                if (i > 0)
                {
                    string colName = dtX.Columns[i].ColumnName;
                    decimal avgX = returnAvg(dtX, colName);
                    //
                    row["argument"] = "x";
                    //эластичность
                    if (avgY == 0)
                    { row["elasticity"] = 0; }
                    else
                    { row["elasticity"] = cr.ImportData.returnNullDecimal(vector[i, 0]) * (avgX / avgY); }
                    //Значимость эластичности
                    if (cr.ImportData.returnNullDecimal(row["elasticity"]) > 1 || cr.ImportData.returnNullDecimal(row["elasticity"]) < -1)
                    { row["elasticity_significant"] = true; }
                    else { row["elasticity_significant"] = false; }
                    row["Si"] = returnDISP(dtX, dtX.Columns[i].ColumnName); //дисперсия
                    row["SKO"] = (decimal)Math.Sqrt(cr.ImportData.returnNullDouble(row["DispQuery"])); //СрКвОткл
                    decimal Si2 = (decimal)Math.Sqrt(cr.ImportData.returnNullDouble(row["Si"])); //Стандартное отклонение / СКО
                    row["S"] = (decimal)Math.Sqrt((dtX.Rows.Count / (dtX.Rows.Count - 1)) * (double)Si2);
                    //Бетта
                    //row["B"] = (decimal)row["value"] * (decimal)row["Si"] / SiY;
                    //Дисперсия
                    row["Si2"] = Si2;
                    string[] sep = dtX.Columns[i].ColumnName.Split('_');
                    row["id_index"] = cr.ImportData.returnNullInt(sep[1]);
                    //
                    double[] p = new double[dtX.Rows.Count];
                    R2_XE = 0;
                    for (int j = 0; j < dtX.Rows.Count; j++)
                    {
                        DataRow rowP = dtX.Rows[j];
                        p[j] = cr.ImportData.returnNullDouble(rowP[dtX.Columns[i].ColumnName]);
                    }
                    alglib.jarqueberatest(p, p.Length, out p_jarq1);
                    row["P_JarqBera1"] = (decimal)p_jarq1;
                    alglib.jarqueberatest(p, p.Length, out p_jarq2);
                    row["P_JarqBera2"] = (decimal)p_jarq2;
                    alglib.jarqueberatest(p, p.Length, out p_jarq3);
                    row["P_JarqBera3"] = (decimal)p_jarq3;
                    row["p_JarqBera1"] = cr.ImportData.returnNullDecimal(p_jarq1);
                    double chi2 = alglib.chisquaredistribution(vector.Length - 1, dtX.Rows.Count);
                    charR2 = "S";
                    row["R2_E"] = calculateCorrelation(charR2, null, "", "", p, e1);
                    
                    //значимость
                    double R2_E1 = cr.ImportData.returnNullDouble(row["R2_E"]);
                    decimal Q_R2_E = (decimal)calculateCorrelationSignificance(charR2, p.Length, R2_E1);
                    //
                    row["H_Norm001"] = false;
                    row["H_Norm005"] = false;
                    if (p_jarq1 <= 0.01) row["H_Norm001"] = true;
                    if (p_jarq1 <= 0.05) row["H_Norm005"] = true;
                    row["enabled"] = true;
                }
                else
                {
                    row["argument"] = "y";
                    //
                    alglib.jarqueberatest(y, y.Length, out p_jarq1);
                    row["P_JarqBera1"] = (decimal)p_jarq1;
                    alglib.jarqueberatest(y, y.Length, out p_jarq2);
                    row["P_JarqBera2"] = (decimal)p_jarq2;
                    alglib.jarqueberatest(y, y.Length, out p_jarq3);
                    row["P_JarqBera3"] = (decimal)p_jarq3;
                    //double chi2 = alglib.chisquaredistribution(vector.Length - 1, dtX.Rows.Count);
                    charR2 = "P";
                    row["R2_E"] = calculateCorrelation(charR2, null, "", "", y, e1);
                    //значимость
                    double R2_E1 = cr.ImportData.returnNullDouble(row["R2_E"]);
                    decimal Q_R2_E = (decimal)calculateCorrelationSignificance(charR2, y.Length, R2_E1);
                    //
                    row["H_Norm001"] = false;
                    row["H_Norm005"] = false;
                    if (p_jarq1 <= 0.01) row["H_Norm001"] = true;
                    if (p_jarq1 <= 0.05) row["H_Norm005"] = true;
                }

                //
                row["Si2_p"] = (decimal)k[i, i]; //дисперсия парамтеров модели
                row["Si_p"] = returnSqrt(row, "Si2_p");   //СКО параметров модели
                row["DispQuery"] = returnDispQuery(dtX, dtX.Columns[i].ColumnName); //Выборочные дисперсии
                //доверительные интервалы
                //decimal StP = 
                
                row["t"] = 0;

                if ((decimal)row["Si_p"] != 0) row["t"] = Math.Abs(cr.ImportData.returnNullDecimal(vector[i, 0]) / cr.ImportData.returnNullDecimal(row["Si_p"])); //t
                row["t_significant"] = false;
                decimal tP = (decimal)row["t"];
                row["t_left"] = (decimal)row["value"] - St * (decimal)row["Si_p"]; //левый интервал
                row["t_right"] = (decimal)row["value"] + St * (decimal)row["Si_p"]; //правый интервал
                if(tP > St2k) row["t_significant"] = true; //значимость с модулем - двухсторонний критерий
                //
                dtP.Rows.Add(row);

            }
            #endregion первая выборка
            #region вторая выборка
            for (int i = 0; i < dtAddX.Columns.Count; i++)
            {
                DataRow row = dtAddP.NewRow();
                //
                //row["value"] = cr.ImportData.returnNullDecimal(vector[i, 0]);
                row["pow"] = 1;
                row["id_index"] = 0;
                //
                double p_jarq1 = 0;
                double p_jarq2 = 0;
                double p_jarq3 = 0;

                string colName = dtAddX.Columns[i].ColumnName;
                decimal avgX = returnAvg(dtAddX, colName);
                //
                row["argument"] = "x";
                //эластичность
                if (avgY == 0)
                { row["elasticity"] = 0; }
                else
                { row["elasticity"] = cr.ImportData.returnNullDecimal(vector[i, 0]) * (avgX / avgY); }
                //Значимость эластичности
                if (cr.ImportData.returnNullDecimal(row["elasticity"]) > 1 || cr.ImportData.returnNullDecimal(row["elasticity"]) < -1)
                { row["elasticity_significant"] = true; }
                else { row["elasticity_significant"] = false; }
                row["Si"] = returnDISP(dtAddX, dtAddX.Columns[i].ColumnName); //дисперсия
                row["SKO"] = (decimal)Math.Sqrt(cr.ImportData.returnNullDouble(row["DispQuery"])); //СрКвОткл
                decimal Si2 = (decimal)Math.Sqrt(cr.ImportData.returnNullDouble(row["Si"])); //Стандартное отклонение / СКО
                row["S"] = (decimal)Math.Sqrt((dtAddX.Rows.Count / (dtAddX.Rows.Count - 1)) * (double)Si2);
                //Бетта
                //row["B"] = (decimal)row["value"] * (decimal)row["Si"] / SiY;
                //Дисперсия
                row["Si2"] = Si2;
                string[] sep = dtAddX.Columns[i].ColumnName.Split('_');
                row["id_index"] = cr.ImportData.returnNullInt(sep[1]);
                //
                double[] p = new double[dtAddX.Rows.Count];
                R2_XE = 0;
                for (int j = 0; j < dtAddX.Rows.Count; j++)
                {
                    DataRow rowP = dtAddX.Rows[j];
                    p[j] = cr.ImportData.returnNullDouble(rowP[dtAddX.Columns[i].ColumnName]);
                }
                alglib.jarqueberatest(p, p.Length, out p_jarq1);
                row["P_JarqBera1"] = (decimal)p_jarq1;
                alglib.jarqueberatest(p, p.Length, out p_jarq2);
                row["P_JarqBera2"] = (decimal)p_jarq2;
                alglib.jarqueberatest(p, p.Length, out p_jarq3);
                row["P_JarqBera3"] = (decimal)p_jarq3;
                row["p_JarqBera1"] = cr.ImportData.returnNullDecimal(p_jarq1);
                //double chi2 = alglib.chisquaredistribution(vector.Length - 1, dtAddX.Rows.Count);
                row["R2_E"] = calculateCorrelation(charR2, null, "", "", p, e1);
                row["H_Norm001"] = false;
                row["H_Norm005"] = false;
                if (p_jarq1 <= 0.01) row["H_Norm001"] = true;
                if (p_jarq1 <= 0.05) row["H_Norm005"] = true;
                row["enabled"] = false;

                //
                //row["Si2_p"] = (decimal)k[i, i]; //дисперсия парамтеров модели
                //row["Si_p"] = returnSqrt(row, "Si2_p");   //СКО параметров модели
                //row["DispQuery"] = returnDispQuery(dtAddX, dtAddX.Columns[i].ColumnName); //Выборочные дисперсии
                //доверительные интервалы
                //row["t_left"] = (decimal)row["value"] - St * (decimal)row["Si_p"]; //левый интервал
                //row["t_right"] = (decimal)row["value"] + St * (decimal)row["Si_p"]; //правый интервал
                //row["t"] = 0;

                //if ((decimal)row["Si_p"] != 0) row["t"] = Math.Abs(cr.ImportData.returnNullDecimal(vector[i, 0]) / cr.ImportData.returnNullDecimal(row["Si_p"])); //t
                //row["t_significant"] = false;
                //if (Math.Abs((decimal)row["t"]) > St2k) row["t_significant"] = true; //значимость с модулем - двухсторонний критерий
                //
                dtAddP.Rows.Add(row);

            }
            #endregion втора выборка
            #endregion частные коэффициенты эластичности
            #endregion Анализ точности
            int maxId = 0;

            //добавляем модель в базу
            #region добавляем модель
            if (F <= 0) return null;
            model_date_create = DateTime.Today;
            if (vector != null)
            {
                //cr.Data.Base.DataModelsTableAdapter = new base_nalogDataSetTableAdapters.Data_modelsTableAdapter();
                modelsDataTable = new base_nalogDataSet.Data_modelsDataTable();
                modelsRow = modelsDataTable.NewData_modelsRow();
                modelsRow.type_model = cr.ImportData.Var.IdTypeModel;
                modelsRow.R2 = R2;
                modelsRow.R2_E = R2_E;
                modelsRow.R2_YE = R2_YE;
                modelsRow.F = F;
                modelsRow.F001 = F001;
                modelsRow.F005 = F005;
                modelsRow.St = St;
                modelsRow.St2k = St2k; //значение t при двух еритериях
                modelsRow.St001 = St001;
                modelsRow.St005 = St005;
                if (St > St001 || St > St005) { modelsRow.St_R2_significant = true; } else { modelsRow.St_R2_significant = false; }
                if (F > F001 || F > F005) { modelsRow.F_R2_significant = true; } else { modelsRow.F_R2_significant = false; }
                modelsRow.A = A;
                modelsRow.fyx_significant = false;
                if (Math.Abs(A) <= (decimal)0.15) modelsRow.fyx_significant = true;
                modelsRow.table_name = tableModel;
                modelsRow.field_name = sourceColumn;
                modelsRow.count_intervals = cr.ImportData.Var.CountIntervals;
                modelsRow.table_model = "Data_model_subject_budget_tax_indexes";
                //
                double p_jarq = 0;
                alglib.jarqueberatest(e0, e0.Length, out p_jarq);
                modelsRow.P_EJarqBera = cr.ImportData.returnNullDecimal(p_jarq);
                modelsRow.H_ENorm001 = false;
                modelsRow.H_ENorm005 = false;
                if (p_jarq <= 0.01) modelsRow.H_ENorm001 = true;
                if (p_jarq <= 0.05) modelsRow.H_ENorm005 = true;
                //
                modelsRow.date_create = model_date_create;
                //
                modelsDataTable.Rows.Add(modelsRow);
            }
            cr.Data.Base.DataModelsTableAdapter.Update(modelsDataTable);
            #endregion добавляем модель
            #region добавляем параметры модели
            dt_prm = cr.ImportData.ReturnSourceTable("SELECT MAX(id) AS id_max FROM Data_models", "Data_models");
            if (dt_prm.Rows.Count > 0)
            {
                maxId = cr.ImportData.returnNullInt(dt_prm.Rows[0][0]);
            }
            if (maxId > 0) id_model = maxId;
            //
            modelParamsDataTable = new base_nalogDataSet.Data_model_paramsDataTable();
            #region первая выборка
            for (int i = 0; i < dtP.Rows.Count; i++)
            {
                modelParamsRow = modelParamsDataTable.NewData_model_paramsRow();
                modelParamsRow.value = cr.ImportData.returnNullDecimal(dtP.Rows[i]["value"]);
                modelParamsRow.pow = 1;
                if (i > 0)
                {
                    modelParamsRow.argument = (string)dtP.Rows[i]["argument"];
                    modelParamsRow.elasticity = cr.ImportData.returnNullDecimal(dtP.Rows[i]["elasticity"]);
                }
                modelParamsRow.index = i;
                modelParamsRow.id_model = id_model;
                modelParamsRow.B = cr.ImportData.returnNullDecimal(dtP.Rows[i]["B"]);
                modelParamsRow.S = cr.ImportData.returnNullDecimal(dtP.Rows[i]["S"]);
                modelParamsRow.Si = cr.ImportData.returnNullDecimal(dtP.Rows[i]["Si"]);
                modelParamsRow.Si2 = cr.ImportData.returnNullDecimal(dtP.Rows[i]["Si2"]);
                modelParamsRow.id_index = cr.ImportData.returnNullInt(dtP.Rows[i]["id_index"]);
                modelParamsRow.elasticity_significant = cr.ImportData.returnNullBool(dtP.Rows[i]["elasticity_significant"]);
                modelParamsRow.t=cr.ImportData.returnNullDecimal(dtP.Rows[i]["t"]);
                modelParamsRow.Si2_p = cr.ImportData.returnNullDecimal(dtP.Rows[i]["Si2_p"]);
                if (modelParamsRow.Si2_p.ToString().Length > 11) modelParamsRow.Si2_p = (decimal)0;
                modelParamsRow.Si_p=cr.ImportData.returnNullDecimal(dtP.Rows[i]["Si_p"]);
                modelParamsRow.t_left=cr.ImportData.returnNullDecimal(dtP.Rows[i]["t_left"]);
                modelParamsRow.t_right=cr.ImportData.returnNullDecimal(dtP.Rows[i]["t_right"]);
                modelParamsRow.t_significant=cr.ImportData.returnNullBool(dtP.Rows[i]["t_significant"]);
                modelParamsRow.R2_E = cr.ImportData.returnNullDecimal(dtP.Rows[i]["R2_E"]);
                modelParamsRow.H_Norm001 = cr.ImportData.returnNullBool(dtP.Rows[i]["H_Norm001"]);
                modelParamsRow.H_Norm005 = cr.ImportData.returnNullBool(dtP.Rows[i]["H_Norm005"]);
                modelParamsRow.P_JarqBera1 = cr.ImportData.returnNullDecimal(dtP.Rows[i]["P_JarqBera1"]);
                //modelParamsRow.P_JarqBera2 = cr.ImportData.returnNullDecimal(dtP.Rows[i]["P_JarqBera2"]);
                //modelParamsRow.P_JarqBera3 = cr.ImportData.returnNullDecimal(dtP.Rows[i]["P_JarqBera3"]);
                //modelParamsRow.enbaled = cr.ImportData.returnNullBool(dtP.Rows[i]["enabled"]);
                modelParamsDataTable.Rows.Add(modelParamsRow);
            }
            #endregion первая выборка
            #region вторая выборка
            for (int i = 0; i < dtAddP.Rows.Count; i++)
            {
                modelParamsRow = modelParamsDataTable.NewData_model_paramsRow();
                modelParamsRow.value = 0;
                modelParamsRow.pow = 0;
                if (i > 0)
                {
                    modelParamsRow.argument = (string)dtAddP.Rows[i]["argument"];
                    //modelParamsRow.elasticity = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["elasticity"]);
                }
                modelParamsRow.index = i;
                modelParamsRow.id_model = id_model;
                //modelParamsRow.B = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["B"]);
                modelParamsRow.S = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["S"]);
                modelParamsRow.Si = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["Si"]);
                modelParamsRow.Si2 = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["Si2"]);
                modelParamsRow.id_index = cr.ImportData.returnNullInt(dtAddP.Rows[i]["id_index"]);
                //modelParamsRow.elasticity_significant = cr.ImportData.returnNullBool(dtAddP.Rows[i]["elasticity_significant"]);
                //modelParamsRow.t = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["t"]);
                //modelParamsRow.Si2_p = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["Si2_p"]);
                //if (modelParamsRow.Si2_p.ToString().Length > 11) modelParamsRow.Si2_p = (decimal)0;
                //modelParamsRow.Si_p = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["Si_p"]);
                //modelParamsRow.t_left = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["t_left"]);
                //modelParamsRow.t_right = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["t_right"]);
                //modelParamsRow.t_significant = cr.ImportData.returnNullBool(dtAddP.Rows[i]["t_significant"]);
                modelParamsRow.R2_E = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["R2_E"]);
                modelParamsRow.H_Norm001 = cr.ImportData.returnNullBool(dtAddP.Rows[i]["H_Norm001"]);
                modelParamsRow.H_Norm005 = cr.ImportData.returnNullBool(dtAddP.Rows[i]["H_Norm005"]);
                modelParamsRow.P_JarqBera1 = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["P_JarqBera1"]);
                //modelParamsRow.P_JarqBera2 = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["P_JarqBera2"]);
                //modelParamsRow.P_JarqBera3 = cr.ImportData.returnNullDecimal(dtAddP.Rows[i]["P_JarqBera3"]);
                modelParamsRow.enbaled = cr.ImportData.returnNullBool(dtAddP.Rows[i]["enabled"]);
                modelParamsDataTable.Rows.Add(modelParamsRow);
            }
            #endregion вторая выборка
            //cr.Data.Base.DataModelParamsTableAdapter = new base_nalogDataSetTableAdapters.Data_model_paramsTableAdapter();
            cr.Data.Base.DataModelParamsTableAdapter.Update(modelParamsDataTable);
            #endregion добавляем параметры модели
            return dtM;
        }
        unsafe static public bool _SolveSqSysEq(double* result, int rcol, double* mtx, int n)
        {
            double* mtx_u_ii, mtx_ii_j;
            double val;
            double* mtx_end = mtx + n * n, result_i, mtx_u_ii_j = null;
            int d = 0;
            for (double* mtx_ii = mtx, mtx_ii_end = mtx + n, result_i_end = result + rcol; mtx_ii < mtx_end; result = result_i_end, result_i_end += rcol, mtx_ii += n + 1, mtx_ii_end += n, d++)
            {
                {
                    val = System.Math.Abs(*(mtx_ii_j = mtx_ii));
                    for (mtx_u_ii = mtx_ii + n, result_i = result + rcol; mtx_u_ii < mtx_end; mtx_u_ii += n, result_i += rcol)
                    {
                        if (val < System.Math.Abs(*mtx_u_ii))
                        {
                            val = System.Math.Abs(*(mtx_ii_j = mtx_u_ii));
                            mtx_u_ii_j = result_i;
                        }
                    }
                    if (val == 0) return false;
                    else if (mtx_ii_j != mtx_ii)
                    {
                        for (result_i = result; result_i < result_i_end; val = *mtx_u_ii_j, *mtx_u_ii_j = *result_i, *result_i = val, mtx_u_ii_j++, result_i++) ;
                        for (mtx_u_ii = mtx_ii; mtx_u_ii < mtx_ii_end; val = *mtx_u_ii, *mtx_u_ii = *mtx_ii_j, *mtx_ii_j = val, mtx_ii_j++, mtx_u_ii++) ;
                    }
                }
                for (mtx_u_ii = mtx_ii - n, result_i = result - rcol; mtx_u_ii > mtx; mtx_u_ii -= n, result_i -= rcol)
                {
                    val = *(mtx_u_ii) / *mtx_ii;
                    for (mtx_ii_j = mtx_ii + 1, mtx_u_ii_j = mtx_u_ii + 1; mtx_ii_j < mtx_ii_end; mtx_u_ii_j++, mtx_ii_j++) *mtx_u_ii_j -= *mtx_ii_j * val;
                    for (mtx_ii_j = result, mtx_u_ii_j = result_i; mtx_ii_j < result_i_end; mtx_u_ii_j++, mtx_ii_j++) *mtx_u_ii_j -= *mtx_ii_j * val;
                }
                for (mtx_u_ii = mtx_ii + n, result_i = result + rcol; mtx_u_ii < mtx_end; mtx_u_ii += d)
                {
                    val = *(mtx_u_ii++) / *mtx_ii;
                    for (mtx_ii_j = mtx_ii + 1; mtx_ii_j < mtx_ii_end; mtx_u_ii++, mtx_ii_j++) *mtx_u_ii -= *mtx_ii_j * val;
                    for (mtx_ii_j = result; mtx_ii_j < result_i_end; result_i++, mtx_ii_j++) *result_i -= *mtx_ii_j * val;
                }
            }
            for (mtx_end--, result--, n++; mtx_end >= mtx; mtx_end -= n)
            {
                val = *mtx_end;
                for (result_i = result - rcol; result > result_i; result--)
                    *result /= val;
            }
            return true;
        }
        unsafe static public double[,] Inverse(double[,] A)
        {
            int n = A.GetLength(0);
            if (n == A.GetLength(1))
            {
                double[,] Result = new double[n, n];
                if (n > 0)
                {
                    fixed (double* pR = &Result[0, 0])
                    {
                        for (double* pr = pR, pr_end = pr + A.Length; pr < pr_end; pr += n + 1) *pr = 1;
                        fixed (double* pA = &(A.Clone() as double[,])[0, 0])
                            if (_SolveSqSysEq(pR, n, pA, n)) return Result;
                            else return null;
                    }
                }
                return Result;
            }
            else throw new IndexOutOfRangeException();
        }
        unsafe static public void _SMul(double* rmDestination, double* rmX, int xn, int xm, double* rmY, int ym)
        {
            //умножение матриц
            for (double* _dest_end = rmDestination + xn * ym; rmDestination < _dest_end; rmDestination += ym)
                for (double* _x_i_end = rmX + xm, _dest_i_end = rmDestination + ym, _y_tmp = rmY; rmX < _x_i_end; rmX++)
                {
                    //сохраняем текущее значение для многократного использования
                    double cache_val = *rmX;
                    for (double* _dest_ij = rmDestination; _dest_ij < _dest_i_end; _dest_ij++, _y_tmp++)
                        *_dest_ij += cache_val * *_y_tmp;
                }
        }
        unsafe static public double[,] SMul(double[,] X, double[,] Y)
        {
            //умножение матрицы
            if (X == null || Y == null) return null;
            int xm = X.GetLength(1);
            if (xm == Y.GetLength(0))
            {
                int xn = X.GetLength(0);
                int ym = Y.GetLength(1);
                double[,] result = new double[xn, ym];
                if (result.Length > 0)
                    fixed (double* p_result = &result[0, 0])
                    fixed (double* p_x = &X[0, 0])
                    fixed (double* p_y = &Y[0, 0])
                        _SMul(p_result, p_x, xn, xm, p_y, ym);
                return result;
            }
            else throw new ArgumentException();
        }
        static public double[,] TranspMatrix(double[,] X)
        {
            if (X.Length < 1) return null;
            int countRows = 0;
            int countColumns = 0;

            returnMatrixParam(X, out countRows, out countColumns);

            double[,] T = new double[countColumns, countRows];
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    double d = X[i, j];
                    //X[i, j] = X[j, i];
                    T[j, i] = d;
                }
            }
            return T;
        }
        static public double[,] MinusMatrix(double[,] m1, double[,] m2)
        {
            if (m1.Length < 1 || m2.Length < 1) return null;
            #region m1
            int countRowsM1 = 0;
            int countColumnsM1 = 0;
            returnMatrixParam(m1, out countRowsM1, out countColumnsM1);
            #endregion m1
            #region m2
            int countRowsM2 = 0;
            int countColumnsM2 = 0;
            returnMatrixParam(m2, out countRowsM2, out countColumnsM2);
            #endregion m2
            if (countRowsM1 != countRowsM2 ||
                countColumnsM1 != countColumnsM2) return null;
            double[,] T = new double[countRowsM1, countColumnsM1];
            for (int i = 0; i < countRowsM1; i++)
            {
                for (int j = 0; j < countColumnsM1; j++)
                {
                    //X[i, j] = X[j, i];
                    T[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return T;
        }
        static void returnMatrixParam(double[,] matrix, out int n, out int m)
        {
            if (matrix.Length < 1) { n = 0; m = 0; }
            else
            {
                int countRows = 0;
                int countColumns = 0;

                for (int i = 0; i < countRows + 1; i++)
                {
                    countRows++;
                    try
                    {
                        double d = matrix[i, 0];
                    }
                    catch (System.Exception ex)
                    {
                        string er = ex.ToString();
                        countRows--;
                    }
                }

                for (int i = 0; i < countColumns + 1; i++)
                {
                    countColumns++;
                    try
                    {
                        double d = matrix[0, i];

                    }
                    catch (System.Exception ex)
                    {
                        string er = ex.ToString();
                        countColumns--;
                    }
                }
                n = countRows;
                m = countColumns;
            }
        }
        public void cleanModels()
        {
            string query =
                "SELECT id, type_model, model_name, short_name, distription, comments, date_create, date_update, R2, F, F001, F005, table_name, field_name, count_intervals," +
                         " model_table, St, St001, St005, St_R2_significant, F_R2_significant" +
                " FROM Data_models" +
                " WHERE table_name = Data_model_subject_budget_tax_indexes";
            DataTable dtClean = cr.ImportData.ReturnSourceTable(query, "Clean");
            foreach (DataRow row in dtClean.Rows)
            {
                query = "SELECT id, id_subject, id_tax, id_time, S, E, id_model, id_best_model, id_budget" +
                        " FROM Data_model_subject_budget_tax_indexes" +
                        " WHERE (id_model=" + row["id"] + ")";
                DataTable dtSearch = cr.ImportData.ReturnSourceTable(query, "Exist");
                if (dtSearch.Rows.Count < 1)
                {
                    query = "DELETE FROM Data_models" +
                        " WHERE id=" + row["id"];
                    cr.ImportData.DeleteFromSourceTable(query);
                    //
                    query = "SELECT id, value, [index], pow, argument, id_model, elasticity, private_elasticity" +
                            " FROM Data_model_params" +
                            " WHERE (id_model =" + row["id"] + ")";
                    cr.ImportData.DeleteFromSourceTable(query);

                }
            }
        }
        public void deleteModelsSubjectsBudgetsTaxesIndexes()
        {
            string query =
                "truncate table Data_model_subject_budget_tax_indexes";
            DataTable dtDeleted = cr.ImportData.ReturnSourceTable(query, "Deleted");
            string hh = "";
            hh = "fsdf";
        }
        private void createTablesAndAdapters(int id_subject = 0)
        {
            //Налоги - ВЭД
            if (id_subject <= 0) return;

            tableModel = "Data_warehouse_subject_tax";
            taxDataTable = new DataTable();
            taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM  " + tableModel + " GROUP BY id_tax, id_subject HAVING (id_subject = " + id_subject + ")", tableModel);
            taxDataTable.TableName = "tax";

            tableModel = "Data_warehouse_subject_eea";
            eeaDataTable = new DataTable();
            eeaDataTable = cr.ImportData.ReturnSourceTable("SELECT id_eea FROM  " + tableModel + " GROUP BY id_eea, id_subject HAVING (id_subject = " + id_subject + ")", tableModel);
            eeaDataTable.TableName = "eea";
            //
            if (cr.Data.Base.CorrelationSubjectTaxEeaTotalTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectTaxEeaTotalTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_tax_eea_totalTableAdapter();
            }
            if (correlationSubjectTaxEeaTotalDataTable == null)
            {
                correlationSubjectTaxEeaTotalDataTable = new base_nalogDataSet.Data_correlation_subject_tax_eea_totalDataTable();
            }
        }
        private void createTablesAndAdaptersTaxIndexes(int id_subject = 0)
        {
            //Налоги - ВЭД
            if (id_subject <= 0) return;

            tableModel = "Data_warehouse_subject_tax";
            taxDataTable = new DataTable();
            taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM  " + tableModel + " GROUP BY id_tax, id_subject HAVING (id_subject = " + id_subject + ")", tableModel);
            taxDataTable.TableName = "tax";
            //
            tableModel = "Scheme_values";
            indexDataTable = new DataTable();
            indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            indexDataTable.TableName = "index";
            //

            if (cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_tax_indexesTableAdapter();
            }
            if (correlationSubjectTaxIndexesDataTable == null)
            {
                correlationSubjectTaxIndexesDataTable = new base_nalogDataSet.Data_correlation_subject_tax_indexesDataTable();
            }

        }
        private void createTablesAndAdaptersTaxIndexesnSubjectValues(int id_subject = 0, bool isIndexes = true)
        {
            //Налоги - ВЭД
            if (id_subject <= 0) return;

            /*tableModel = "Data_warehouse_subject_tax";
            taxDataTable = new DataTable();
            taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM  " + tableModel + " GROUP BY id_tax, id_subject HAVING (id_subject = " + id_subject + ")", tableModel);
            taxDataTable.TableName = "tax";
            //
            tableModel = "Scheme_values";
            indexDataTable = new DataTable();
            indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            indexDataTable.TableName = "index";*/
            //
            if (isIndexes)
            {
                tableModel = "Scheme_values";
                indexDataTable = new DataTable();
                indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
                indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
                indexDataTable.TableName = "index";
            }
            //
            tableModel = "Data_warehouse_subject_tax_budget";
            budgetDataTable = new DataTable();
            budgetDataTable = cr.ImportData.ReturnSourceTable("SELECT id_budget FROM  " + tableModel + " WHERE(id_subject = " + id_subject + ") GROUP BY id_budget", tableModel);
            budgetDataTable.TableName = "budget";

            if (cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_tax_indexesTableAdapter();
            }
            if (cr.Data.Base.CorrelationSubjectValuesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectValuesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_valuesTableAdapter();
            }
            if (cr.Data.Base.CorrelationCollectionTableAdapter == null)
            {
                cr.Data.Base.CorrelationCollectionTableAdapter = new base_nalogDataSetTableAdapters.Table_correlationsTableAdapter();
            }
            if (correlationCollectionDataTable == null)
            {
                correlationCollectionDataTable = new base_nalogDataSet.Table_correlationsDataTable();
            }

        }
        private void createTablesAndAdaptersCreateFunctions(int id_subject = 0, bool isIndexes = true)
        {
            //Налоги - ВЭД
            if (id_subject <= 0) return;

            tableModel = "Data_warehouse_subject_tax";
            taxDataTable = new DataTable();
            taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM  " + tableModel + " GROUP BY id_tax, id_subject HAVING (id_subject = " + id_subject + ")", tableModel);
            taxDataTable.TableName = "tax";
            //
            /*
            tableModel = "Scheme_values";
            indexDataTable = new DataTable();
            indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            indexDataTable.TableName = "index";*/
            //
            if (isIndexes)
            {
                /*tableModel = "Scheme_values";
                indexDataTable = new DataTable();
                indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
                indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
                indexDataTable.TableName = "index";*/
                tableModel = "Scheme_values";
                indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            }
            //
            tableModel = "Data_warehouse_subject_tax_budget";
            budgetDataTable = new DataTable();
            budgetDataTable = cr.ImportData.ReturnSourceTable("SELECT id_budget FROM  " + tableModel + " WHERE(id_subject = " + id_subject + ") GROUP BY id_budget", tableModel);
            budgetDataTable.TableName = "budget";

            if (cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectTaxIndexesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_tax_indexesTableAdapter();
            }
            if (cr.Data.Base.CorrelationSubjectValuesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectValuesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_valuesTableAdapter();
            }
            if (cr.Data.Base.CorrelationCollectionTableAdapter == null)
            {
                cr.Data.Base.CorrelationCollectionTableAdapter = new base_nalogDataSetTableAdapters.Table_correlationsTableAdapter();
            }
            if (correlationCollectionDataTable == null)
            {
                correlationCollectionDataTable = new base_nalogDataSet.Table_correlationsDataTable();
            }
            if (cr.Data.Base.SchemeValuesTableAdapters == null)
            {
                cr.Data.Base.SchemeValuesTableAdapters = new base_nalogDataSetTableAdapters.Scheme_valuesTableAdapter();
            }
            if (cr.Data.Base.DataModelSubjectBudgetTaxIndexesTableAdapter == null)
            {
                cr.Data.Base.DataModelSubjectBudgetTaxIndexesTableAdapter = new base_nalogDataSetTableAdapters.Data_model_subject_budget_tax_indexesTableAdapter();
            }
            if (cr.Data.Base.DataModelParamsTableAdapter == null)
            {
                cr.Data.Base.DataModelParamsTableAdapter = new base_nalogDataSetTableAdapters.Data_model_paramsTableAdapter();
            }
            if (cr.Data.Base.DataModelsTableAdapter == null)
            {
                cr.Data.Base.DataModelsTableAdapter = new base_nalogDataSetTableAdapters.Data_modelsTableAdapter();
            }
            if (dataModelSubjectBudgetTaxIndexesDataTable == null)
            {
                dataModelSubjectBudgetTaxIndexesDataTable = new base_nalogDataSet.Data_model_subject_budget_tax_indexesDataTable();
            }
        }
        private void createTablesAndAdaptersSubjectValues(int id_subject = 0)
        {
            //Налоги - ВЭД
            if (id_subject <= 0) return;

            tableModel = "Scheme_values";
            indexDataTable = new DataTable();
            indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            indexDataTable.TableName = "index";
            //
            //tableModel = "Scheme_values2";
            //indexDataTable = new DataTable();
            //indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            //indexDataTable.TableName = "index2";
            //

            if (cr.Data.Base.CorrelationSubjectValuesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectValuesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_valuesTableAdapter();
            }
            if (correlationSubjectValuesDataTable == null)
            {
                correlationSubjectValuesDataTable = new base_nalogDataSet.Data_correlation_subject_valuesDataTable();
            }
        }
        private void createTablesAndAdaptersTaxBudgetIndexes(int id_subject = 0, bool isIndexes = true)
        {
            //Налоги - ВЭД
            if (id_subject <= 0) return;

            tableModel = "Data_warehouse_subject_tax";
            taxDataTable = new DataTable();
            taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM  " + tableModel + " GROUP BY id_tax, id_subject HAVING (id_subject = " + id_subject + ")", tableModel);
            taxDataTable.TableName = "tax";

            if (isIndexes)
            {
                tableModel = "Scheme_values";
                indexDataTable = new DataTable();
                indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
                indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
                indexDataTable.TableName = "index";
            }
            //
            tableModel = "Data_warehouse_subject_tax_budget";
            budgetDataTable = new DataTable();
            budgetDataTable = cr.ImportData.ReturnSourceTable("SELECT id_budget FROM  " + tableModel + " WHERE(id_subject = " + id_subject + ") GROUP BY id_budget", tableModel);
            budgetDataTable.TableName = "budget";
            //
            if (cr.Data.Base.CorrelationSubjectTaxBudgetIndexesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectTaxBudgetIndexesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_tax_budget_indexesTableAdapter();
            }
            if (correlationSubjectTaxIndexesDataTable == null)
            {
                correlationSubjectTaxIndexesDataTable = new base_nalogDataSet.Data_correlation_subject_tax_indexesDataTable();
            }
            if (correlationSubjectTaxBudgetIndexesDataTable == null)
            {
                correlationSubjectTaxBudgetIndexesDataTable = new base_nalogDataSet.Data_correlation_subject_tax_budget_indexesDataTable();
            }
        }
        private void createTablesAndAdaptersBudgetIndexes(int id_subject = 0, bool isIndexes = true)
        {
            //Налоги - ВЭД
            if (id_subject <= 0) return;

            /*tableModel = "Data_warehouse_subject_tax";
            taxDataTable = new DataTable();
            taxDataTable = cr.ImportData.ReturnSourceTable("SELECT id_tax FROM  " + tableModel + " GROUP BY id_tax, id_subject HAVING (id_subject = " + id_subject + ")", tableModel);
            taxDataTable.TableName = "tax";*/

            if (isIndexes)
            {
                tableModel = "Scheme_values";
                indexDataTable = new DataTable();
                indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
                indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
                indexDataTable.TableName = "index";
            }
            //
            tableModel = "Data_warehouse_subject_tax_budget";
            budgetDataTable = new DataTable();
            budgetDataTable = cr.ImportData.ReturnSourceTable("SELECT id_budget FROM  " + tableModel + " WHERE(id_subject = " + id_subject + ") GROUP BY id_budget", tableModel);
            budgetDataTable.TableName = "budget";
            //
            if (cr.Data.Base.CorrelationSubjectBudgetIndexesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectBudgetIndexesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_budget_indexesTableAdapter();
            }
            if (correlationSubjectBudgetIndexesDataTable == null)
            {
                try
                {
                    correlationSubjectBudgetIndexesDataTable = new base_nalogDataSet.Data_correlation_subject_budget_indexesDataTable();
                }
                catch (System.Exception ex)
                {
                    string g = ex.ToString();
                }
            }
        }
        private void createTablesAndAdaptersEeaBudgetIndexes(int id_subject = 0)
        {
            //Налоги - ВЭД
            if (id_subject <= 0) return;

            tableModel = "Data_warehouse_subject_eea";
            eeaDataTable = new DataTable();
            eeaDataTable = cr.ImportData.ReturnSourceTable("SELECT id_eea FROM  " + tableModel + " GROUP BY id_eea, id_subject HAVING (id_subject = " + id_subject + ")", tableModel);
            eeaDataTable.TableName = "eea";

            tableModel = "Scheme_values";
            indexDataTable = new DataTable();
            indexesDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            indexDataTable = cr.ImportData.ReturnSourceTable("SELECT  id, name, latin_name, name_source_table, name_field_table, name_source_view, name_field_view, type_value FROM  " + tableModel + " WHERE (type_value LIKE 'index')", tableModel);
            indexDataTable.TableName = "index";
            //
            tableModel = "Data_warehouse_subject_eea_budget";
            budgetDataTable = new DataTable();
            budgetDataTable = cr.ImportData.ReturnSourceTable("SELECT id_budget FROM  " + tableModel + " WHERE(id_subject = " + id_subject + ") GROUP BY id_budget", tableModel);
            budgetDataTable.TableName = "budget";
            //
            if (cr.Data.Base.CorrelationSubjectEeaBudgetIndexesTableAdapter == null)
            {
                cr.Data.Base.CorrelationSubjectEeaBudgetIndexesTableAdapter = new base_nalogDataSetTableAdapters.Data_correlation_subject_eea_budget_indexesTableAdapter();
            }
            if (correlationSubjectTaxIndexesDataTable == null)
            {
                correlationSubjectTaxIndexesDataTable = new base_nalogDataSet.Data_correlation_subject_tax_indexesDataTable();
            }
            if (correlationSubjectEeaBudgetIndexesDataTable == null)
            {
                correlationSubjectEeaBudgetIndexesDataTable = new base_nalogDataSet.Data_correlation_subject_eea_budget_indexesDataTable();
            }
        }
        private decimal calculateCorrelation(string method = "", DataTable dtC = null, string field1 = "", string field2 = "", double[] d1=null, double [] d2=null)
        {

            decimal R2 = 0;
            double[] c1, c2;
            if (d1 != null && d2 != null) { c1 = d1; c2 = d2; }
            else
            {
                c1 = new double[dtC.Rows.Count]; 
                c2 = new double[dtC.Rows.Count];
                for (int i = 0; i < dtC.Rows.Count; i++)
                {
                    c1[i] = cr.ImportData.returnNullDouble(dtC.Rows[i][field1]);
                    c2[i] = cr.ImportData.returnNullDouble(dtC.Rows[i][field2]);
                }
            }
            int count = 0;
            int m=0;
            if (dtC != null)
            {
                count = dtC.Rows.Count;
            }
            else
            {
                count = d1.Length;
            }
            switch (method)
            {
                case "P":
                    {
                        R2 = cr.ImportData.returnNullDecimal(alglib.pearsoncorrelation(c1, c2, count));
                        break;
                    }
                case "S":
                    {
                        R2 = cr.ImportData.returnNullDecimal(alglib.spearmanrankcorrelation(c1, c2, count));
                        break;
                    }
            }

            return R2;
        }
        private double calculateCorrelationSignificance(string method = "", int N = 0, double R2 = 0)
        {

            double S = 0;
            double S_right = 0;
            double S_left = 0;
            switch (method)
            {
                case "P":
                    {
                        alglib.pearsoncorrelationsignificance(R2, N, out S, out S_left, out S_right);
                        break;
                    }
                case "S":
                    {
                        alglib.spearmanrankcorrelationsignificance(R2, N, out S, out S_left, out S_right);
                        break;
                    }
            }
            return S;
        }
        private void deleteModel()
        {
            if (cr.Data.Base.DataBestModelsSubjectTaxTableAdapter == null) cr.Data.Base.DataBestModelsSubjectTaxTableAdapter = new base_nalogDataSetTableAdapters.Data_best_models_subject_taxTableAdapter();
            if (cr.Data.Base.DataModelParamsTableAdapter == null) cr.Data.Base.DataModelParamsTableAdapter = new base_nalogDataSetTableAdapters.Data_model_paramsTableAdapter();
            if (cr.Data.Base.DataModelsTableAdapter == null) cr.Data.Base.DataModelsTableAdapter = new base_nalogDataSetTableAdapters.Data_modelsTableAdapter();
            if (modelParamsDataTable == null) modelParamsDataTable = new base_nalogDataSet.Data_model_paramsDataTable();
            if (modelsDataTable == null) modelsDataTable = new base_nalogDataSet.Data_modelsDataTable();
            if (modelSubjectTaxDataTable == null) modelSubjectTaxDataTable = new base_nalogDataSet.Data_model_subject_taxDataTable();
            //
            cr.Data.Base.DataModelParamsTableAdapter.FillBy(modelParamsDataTable, id_model);
            cr.Data.Base.DataModelParamsTableAdapter.Update((base_nalogDataSet.Data_model_paramsDataTable)returnDeletedTableData(modelParamsDataTable));
            //
            cr.Data.Base.DataModelSubjectTaxTableAdapter.FillBy(modelSubjectTaxDataTable, id_model);
            cr.Data.Base.DataModelSubjectTaxTableAdapter.Update((base_nalogDataSet.Data_model_subject_taxDataTable)returnDeletedTableData(modelSubjectTaxDataTable));
            //
            cr.Data.Base.DataModelsTableAdapter.FillBy(modelsDataTable, id_model);
            cr.Data.Base.DataModelsTableAdapter.Update((base_nalogDataSet.Data_modelsDataTable)returnDeletedTableData(modelsDataTable));
        }
        private DataTable returnDeletedTableData(DataTable dt_d)
        {
            foreach (DataRow row in dt_d.Rows)
            {
                row.Delete();
            }
            return dt_d;
        }
        public void takeForeCast()
        {
            if (cr.ImportData.Var.ForecastPeriod <= 0) return;
            if (cr.Data.Base.Ds == null) cr.Data.Base.Ds = new base_nalogDataSet();
            string model_function = "";
            //
            DataTable dt_subjects = cr.ImportData.ReturnSourceTable("SELECT id_subject FROM dbo.Data_best_models_subject_tax GROUP BY id_subject", "dt_subjects");
            foreach (DataRow rSubject in dt_subjects.Rows)
            {
                int id_subject = cr.ImportData.returnNullInt(rSubject["id_subject"]);
                DataTable dt_taxes_subject = cr.ImportData.ReturnSourceTable("SELECT     id_tax FROM         dbo.Data_best_models_subject_tax GROUP BY id_tax, id_subject HAVING      (id_subject = " + id_subject + ")", "dt_taxes_subject");
                foreach (DataRow rTax in dt_taxes_subject.Rows)
                {
                    int id_tax = cr.ImportData.returnNullInt(rTax["id_tax"]);
                    //DataTable dt_model = cr.ImportData.ReturnSourceTable("SELECT id_model, id_subject, id_tax, id_model_subject_tax FROM dbo.Data_best_models_subject_tax GROUP BY id_model, id_subject, id_tax, id_model_subject_tax HAVING (id_subject = " + id_subject + ") AND (id_tax = " + id_tax + "))", "dt_model");
                    //foreach (DataRow rModel in dt_model.Rows)
                    //{
                    //id_model = cr.ImportData.returnNullInt(rModel["id_model"]);
                    DataTable dt_year = cr.ImportData.ReturnSourceTable("SELECT id_subject, id_tax, year FROM View_models_subjects_taxes GROUP BY id_subject, id_tax, year HAVING (id_tax=" + id_tax + ") AND (id_subject=" + id_subject + ") ORDER BY year", "dt_year");
                    DataTable dt_calculate = cr.ImportData.ReturnSourceTable("SELECT * FROM View_models_subjects_taxes WHERE (id_subject=" + id_subject + ") AND (id_tax=" + id_tax + ") ORDER BY year", "dt_calculate");
                    if (dt_year.Rows.Count > 0)
                    {
                        int maxYear = cr.ImportData.returnNullInt(dt_year.Compute("Max(year)", ""));
                        decimal sum = 0;
                        int index = 0;
                        int countInt = cr.ImportData.returnNullInt(dt_calculate.Rows[0]["count_intervals"]);
                        decimal rS = 0;
                        model_function = "";
                        if (cr.ImportData.Var.ForecastPeriod <= maxYear)
                        {
                            DataTable dt_calculate_S = cr.ImportData.ReturnSourceTable("SELECT * FROM View_models_subjects_taxes WHERE (id_subject=" + id_subject + ") AND (id_tax=" + id_tax + ") AND (year=" + cr.ImportData.Var.ForecastPeriod + ") ORDER BY [index]", "dt_calculate_S");
                            model_function += "(";
                            foreach (DataRow rBestModel in dt_calculate_S.Rows)
                            {
                                if (cr.ImportData.returnNullInt(rBestModel["index"]) <= 0)
                                {
                                    sum += cr.ImportData.returnNullDecimal(rBestModel["value"]);
                                    model_function += cr.ImportData.returnNullDouble(rBestModel["value"], 2);
                                }
                                else
                                {
                                    sum += cr.ImportData.returnNullDecimal(rBestModel["value"]) * (decimal)Math.Pow((double)index, cr.ImportData.returnNullDouble(rBestModel["pow"])); model_function += rBestModel["value"].ToString();
                                    if (rBestModel["argument"].ToString().Length > 0)
                                    {
                                        model_function += "+" + cr.ImportData.returnNullDouble(rBestModel["value"], 2).ToString() + "*" + rBestModel["argument"] + "^" + rBestModel["pow"].ToString();
                                    }
                                    else
                                    {
                                        model_function += "+" + cr.ImportData.returnNullDouble(rBestModel["value"], 2).ToString();
                                    }
                                }
                            }
                            model_function += ")";
                            sum = sum * cr.ImportData.returnNullDecimal(dt_calculate_S.Rows[0]["S"]);
                            model_function += "*" + cr.ImportData.returnNullDouble(dt_calculate_S.Rows[0]["S"], 2).ToString();
                        }
                        else
                        {
                            int indexYear = 0;
                            int countYear = 0;
                            foreach (DataRow row in dt_year.Rows)
                            {
                                countYear += countInt - 1;
                                if (countYear <= dt_year.Rows.Count) indexYear = countYear;
                            }
                            int fYear = cr.ImportData.returnNullInt(dt_calculate.Rows[indexYear]["year"]);
                            DataTable dt_calculate_F = cr.ImportData.ReturnSourceTable("SELECT * FROM View_models_subjects_taxes WHERE (id_subject=" + id_subject + ") AND (id_tax=" + id_tax + ") AND (year=" + fYear + ") ORDER BY [index]", "dt_calculate_F");
                            model_function += "(";
                            foreach (DataRow rBestModel in dt_calculate_F.Rows)
                            {
                                if (cr.ImportData.returnNullInt(rBestModel["index"]) <= 0)
                                {
                                    sum += cr.ImportData.returnNullDecimal(rBestModel["value"]);
                                    model_function += cr.ImportData.returnNullDouble(rBestModel["value"], 2);
                                }
                                else
                                {
                                    sum += cr.ImportData.returnNullDecimal(rBestModel["value"]) * (decimal)Math.Pow((double)index, cr.ImportData.returnNullDouble(rBestModel["pow"]));
                                    model_function += cr.ImportData.returnNullDouble(rBestModel["value"], 2).ToString() + "*" + index + "^" + rBestModel["pow"].ToString();
                                    if (rBestModel["argument"].ToString().Length > 0)
                                    {
                                        model_function += "+" + cr.ImportData.returnNullDouble(rBestModel["value"], 2).ToString() + "*" + rBestModel["argument"] + "^" + rBestModel["pow"].ToString();
                                    }
                                    else
                                    {
                                        model_function += "+" + cr.ImportData.returnNullDouble(rBestModel["value"], 2).ToString();
                                    }
                                }
                            }
                            model_function += ")";
                            sum = sum * cr.ImportData.returnNullDecimal(dt_calculate_F.Rows[0]["S"]);
                            model_function += "*" + cr.ImportData.returnNullDouble(dt_calculate_F.Rows[0]["S"], 2).ToString();
                        }
                        //
                        int id_time = returnIdTime(cr.ImportData.Var.ForecastPeriod);
                        int exist = checkDtForecast(id_subject, id_tax, id_time, sum);
                        if (exist == 0)
                        {
                            if (cr.Data.Base.DataWarehouseForecastSubjectTaxTableAdapter == null) cr.Data.Base.DataWarehouseForecastSubjectTaxTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_forecast_subject_taxTableAdapter();
                            base_nalogDataSet.Data_warehouse_forecast_subject_taxRow row = cr.Data.Base.Ds.Data_warehouse_forecast_subject_tax.NewData_warehouse_forecast_subject_taxRow();
                            row.id_subject = id_subject;
                            row.id_tax = id_tax;
                            row.id_time = id_time;
                            row.ti_tax_subject = sum;
                            row.model_function = model_function;
                            cr.Data.Base.Ds.Data_warehouse_forecast_subject_tax.AddData_warehouse_forecast_subject_taxRow(row);
                            cr.Data.Base.DataWarehouseForecastSubjectTaxTableAdapter.Update(cr.Data.Base.Ds.Data_warehouse_forecast_subject_tax);
                        }
                    }
                    //}
                }
            }
        }
        private int checkDtForecast(int id_subject = 0, int id_tax = 0, int id_time = 0, decimal sum = 0)
        {
            int y = 0;
            if (id_subject <= 0 || id_tax <= 0 || id_time <= 0 || sum <= 0) y = 3;
            DataTable dt_db = cr.ImportData.ReturnSourceTable("SELEC id, id_subject, id_tax, id_time, ti_tax_subject FROM dbo.Data_warehouse_forecast_subject_tax WHERE (id_subject=" + id_subject + ") AND (id_tax=" + id_tax + ") AND (id_time=" + id_time + ")", "Data_warehouse_forecast_subject_tax");
            foreach (DataRow row in dt_db.Rows)
            {
                if (cr.ImportData.returnNullDecimal(row["ti_tax_subject"]) == sum)
                {
                }
            }
            return 0;
        }
        private int returnIdTime(int year)
        {
            int id = 0;
            DataTable dt_time = cr.ImportData.ReturnSourceTable("SELECT id, calendar_year FROM dbo.Time WHERE (calendar_year = " + year + ")", "time");
            if (dt_time.Rows.Count > 0) id = cr.ImportData.returnNullInt(dt_time.Rows[0]["id"]);
            else
            {
                if (cr.Data.Base.TimeTableAdapter == null) cr.Data.Base.TimeTableAdapter = new base_nalogDataSetTableAdapters.TimeTableAdapter();
                cr.Data.Base.TimeTableAdapter.Fill(cr.Data.Base.Ds.Time);
                base_nalogDataSet.TimeRow row = cr.Data.Base.Ds.Time.NewTimeRow();
                row.calendar_year = year;
                cr.Data.Base.Ds.Time.AddTimeRow(row);
                cr.Data.Base.TimeTableAdapter.Update(cr.Data.Base.Ds.Time);
                //
                DataTable dt_time2 = cr.ImportData.ReturnSourceTable("SELECT id, calendar_year FROM dbo.Time WHERE (calendar_year = " + year + ")", "time");
                if (dt_time2.Rows.Count > 0) id = cr.ImportData.returnNullInt(dt_time2.Rows[0]["id"]);
            }
            return id;
        }
    }
}


