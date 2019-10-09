using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace NalogAdministrator.Classes.ImpData.Methods
{
    public class ImportDataSubjectIndex
    {
        /*
         * Этот класс предназначен для работы с файлами по работе с населением:
         * общая численность, занятное население и безработное.
         * */
        private Data data;
        private Core cr;
        private base_nalogDataSet ds;
        private Classes.ImpData.ImportData impData;
        private Classes.ImpData.ImportDataVariables var;
        //private string connString = "";
        private Controls.ImportData.UserControlImportDataSubjectIndex ucSubjectIndex;
        private base_nalogDataSet.Source_data_Subject_indexRow subjectIndexRow;
        private DataRow[] subjectIndexRows;
        private string strSubject = "";
        private int indexRowToStart = -1;
        private List<string> edits = new List<string>();
        private List<DataRow> childsSubjects = new List<DataRow>();
        //Работа с файлами и базой
        private Classes.Data Data = new Data();
        #region Конструктор
        public ImportDataSubjectIndex(Core Cr, Classes.ImpData.ImportData ImpData,
                Classes.ImpData.ImportDataVariables Var, string str, Controls.ImportData.UserControlImportDataSubjectIndex Control)
        {
            //передача необходимых параметров
            this.cr = Cr;
            this.impData = ImpData;
            this.var = Var;
            cr.Data.Files = new Files();
            this.ucSubjectIndex = Control;
            cr.Data.Base.SubjectsTableAdapter.Fill(cr.Data.Base.Ds.Subjects);
            cr.Data.Base.SourceDataSubjectIndexTableAdapter = new base_nalogDataSetTableAdapters.Source_data_Subject_indexTableAdapter();
        }
        #endregion Конструктор
        public void AddRecords(string sheet, string tag)
        {
            if (!CheackExcelSheet(sheet)) return;
            cr.Data.Base.SourceDataSubjectIndexTableAdapter.Fill(cr.Data.Base.Ds.Source_data_Subject_index);
            var.TakeIntervalOleDb(var.PathFile, sheet);
            var.InternalTable.TableName = defineSourceTable(impData.ClearStrExcelTable(sheet));
            var.Status = " добавляем"; //устанавливаем статус
            bool flag = true; //флаг на остановку цикла
            #region Поиск начальной строки входа
            for (int i = 0; i < var.InternalTable.Columns.Count; i++)
            {
                if (var.InternalTable.Columns[i].ColumnName.ToString() == "Субъект")
                {
                    indexRowToStart = 0;
                    flag = false;
                    break;
                }
            }
            for (int i = 0; i < var.InternalTable.Rows.Count && flag; i++)
            {
                for (int j = 0; j < var.InternalTable.Columns.Count; j++)
                {
                    if (var.InternalTable.Rows[i][0].ToString() == "Субъект")
                    {
                        indexRowToStart = i;
                        flag = false;
                        break;
                    }
                }
                if(!flag) break;
            }
            #endregion Поиск начальной строки входа
            if (indexRowToStart != -1)
            {
                #region Помечаем столбцы с годами
                //читаем и индексируем поле с годами
                var.Years.Clear();
                for (int j = 0; j < var.InternalTable.Columns.Count; j++)
                {
                    try
                    {
                        int year = Convert.ToInt32(var.InternalTable.Rows[indexRowToStart][j]);
                        var.Years.Add(new List<int> { j, year });
                    }
                    catch (System.Exception err)
                    {
                    }
                }
                #endregion Помечаем столбцы с годами
            }
            AddIntervalTableData(0);
            var.Status = " готово";
        }
        private void AddIntervalTableData(int module)
        {
            bool add = false;
            var.CountRecords = var.InternalTable.Rows.Count;
            int status = -1;
            switch (module)
            {
                case 0:

                    //Переключатель для добавление населения по простой схеме
                    {
                        #region Общее
                        for (var.IndexRecord = indexRowToStart + 1; var.IndexRecord < var.InternalTable.Rows.Count; var.IndexRecord++)
                        {
                            #region проверка значения
                            try
                            {
                                strSubject = var.InternalTable.Rows[var.IndexRecord][0].ToString();

                            }
                            catch (System.Exception err)
                            {
                            }
                            var.IdSubjNow = impData.defineParamSubjId(strSubject, cr.Data.Base.Ds.Subjects.subject_nameColumn.ToString(), "short_name", "subject_name_reports", "");

                            #endregion проверка значения
                            for (int j = 0; j < var.Years.Count; j++)
                            {
                                var.YearNow = var.Years[j][1];
                                ///ucPopulation.dataGridViewPopulation.CurrentCell.Value = j;
                                if (var.InternalTable.Rows[var.IndexRecord][var.Years[j][0]] != System.DBNull.Value &&
                                    var.IdSubjNow > 0)
                                {
                                    //
                                    decimal value=0;
                                    if (var.IsDevideValue)
                                    {
                                        value = impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][var.Years[j][0]], 2) / var.DevideMultiplyValue;
                                    }
                                    else if (var.IsMultiplyValue)
                                    {
                                        value = impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][var.Years[j][0]], 2) * var.DevideMultiplyValue;
                                    }
                                    else
                                    {
                                        value = impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][var.Years[j][0]], 2);
                                    }
                                    status = checkImportedData(var.IdSubjNow, var.YearNow, value, 0, 0, var.InternalTable.TableName);
                                    if (status == 0)
                                    {
                                        add = true;
                                        var.Status = " добавляем ";
                                        subjectIndexRow = cr.Data.Base.Ds.Source_data_Subject_index.NewSource_data_Subject_indexRow();
                                        subjectIndexRow.id_subject = var.IdSubjNow;
                                        subjectIndexRow.year_data = Convert.ToInt16(var.Years[j][1]);
                                        subjectIndexRow[var.InternalTable.TableName] = value;
                                        int pid = checkSubjectPId(var.IdSubjNow);
                                        if (pid > 0)
                                        {
                                            subjectIndexRow.pid = pid;
                                        }
                                        cr.Data.Base.Ds.Source_data_Subject_index.AddSource_data_Subject_indexRow(subjectIndexRow);
                                    }
                                    if (status == 1)
                                    {
                                        var.Status = " изменяем ";
                                        subjectIndexRow = cr.Data.Base.Ds.Source_data_Subject_index.FindByid(var.CheckedId);
                                        subjectIndexRow.year_data = Convert.ToInt16(var.YearNow);
                                        subjectIndexRow[var.InternalTable.TableName] = value;
                                        int pid = checkSubjectPId(var.IdSubjNow);
                                        if (pid > 0)
                                        {
                                            subjectIndexRow.pid = pid;
                                        }
                                    }
                                    if (status == 2)
                                    {
                                        var.Status = " удаляем ";
                                        cr.Data.Base.Ds.Source_data_Subject_index.FindByid(var.CheckedId).Delete();
                                    }
                                    if (status == 3)
                                    {
                                        var.Status = " проверено ";
                                    }
                                }
                            }
                        }
                        var.StatusApp = " Добавляем в БД ";
                        setCommandsForTableAdapter(module);
                        cr.Data.Base.Ds.AcceptChanges();
                        cr.Data.Base.SourceDataSubjectIndexTableAdapter.Fill(cr.Data.Base.Ds.Source_data_Subject_index);
                        status = -1;
                        var.StatusApp = " Готово ";
                        break;
                        #endregion Общее
                    }
            }

        }
        private int checkImportedData(int idSubj, int year, decimal val, int tax, int module, string nameCol="", int pid=0)
        {
            int yes = 0;
            //var.Status = " проверяем"; //устанавливаем статус
            DataRow[] dRowLev1; //вводим переменную для коллекции строк
            switch (module)
            {
                case 0:
                    {
                        #region Общее
                        //создаем фильтр
                        string filter = cr.Data.Base.Ds.Source_data_Subject_index.id_subjectColumn.ToString() + "=" + idSubj +
                            " AND " + cr.Data.Base.Ds.Source_data_Subject_index.year_dataColumn.ToString() + "=" + year;
                        dRowLev1 = cr.Data.Base.Ds.Source_data_Subject_index.Select(filter);
                        #region Проверям строки
                        if (dRowLev1.Length > 0 && idSubj > 0 && year > 0)
                        {
                            int indexRow = 0;
                            yes = 0;
                            foreach (DataRow row in dRowLev1)
                            {
                                bool step1 = false;
                                bool step2 = false;
                                bool step3 = false;
                                indexRow++;

                                //проходимся по найденныи позициям и находим совпадения
                                if (idSubj == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Subject_index.id_subjectColumn]) &&
                                    year == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Subject_index.year_dataColumn]) &&
                                    (impData.returnNullInt(row[cr.Data.Base.Ds.Source_data_Subject_index.Columns[var.InternalTable.TableName]]) != 0 &&
                                    impData.returnNullDecimal(val, 2) == impData.returnNullDecimal(row[cr.Data.Base.Ds.Source_data_Subject_index.Columns[var.InternalTable.TableName]], 2)))
                                {
                                    yes = 3;
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Subject_index.idColumn]);
                                    step1 = true;
                                }
                                else if (idSubj == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Subject_index.id_subjectColumn]) &&
                                    year == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Subject_index.year_dataColumn]) &&
                                    (val != impData.returnNullDecimal(row[cr.Data.Base.Ds.Source_data_Subject_index.Columns[var.InternalTable.TableName]], 2) ||
                                    impData.returnNullInt(row[cr.Data.Base.Ds.Source_data_Subject_index.Columns[var.InternalTable.TableName]]) == 0) &&
                                    indexRow <= 1)
                                {
                                    yes = 1;
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Subject_index.idColumn]);
                                    step2 = true;
                                }
                                else { }
                                if (!step1 && !step2 && indexRow > 1)
                                {
                                    yes = 2;
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Subject_index.idColumn]);
                                    step3 = true;
                                }
                                //шаг 4
                                if (!step1 && !step2 && !step3)
                                {
                                    yes = 0;
                                }
 
                            }
                        }
                        else if (dRowLev1.Length <= 0)
                        {
                            yes = 0;
                        }
                        else
                        {
                            yes = 3;
                        }
                        #endregion Проверям строки
                        break;
                        #endregion Общее
                    }
            }

            return yes;
        }
        private int checkSubjectPId(int idSubj)
        {
            int pid = 0;
            string colPId = "pid";
            var.Status = " проверяем"; //устанавливаем статус
            DataRow row = cr.Data.Base.Ds.Subjects.FindByid(idSubj);
            #region Проверям строки
            if (idSubj > 0)
            {
                if (row[cr.Data.Base.Ds.Subjects.parentColumn] != null)
                {
                    try
                    {
                        pid = Convert.ToInt32(row[cr.Data.Base.Ds.Subjects.parentColumn]);
                    }
                    catch (System.Exception err)
                    {
                        pid = 0;
                    }
                }
            }
            #endregion Проверям строки
            return pid;
        }
        private bool CheackExcelSheet(string sheet)
        {
            bool ret = false;
            sheet = sheet.Replace("$", "");
            foreach (string line in NalogAdministrator.Properties.Settings.Default.TablesIndex)
            {
                if (line == sheet) ret = true;
            }
            return ret;
        }
        public void UpdateTable()
        {
            cr.Data.Base.SourceDataPopulationTableAdapter.Update(cr.Data.Base.Ds.Source_data_Population);
            cr.Data.Base.SourceDataPopulationTableAdapter.Fill(cr.Data.Base.Ds.Source_data_Population);
        }
        private void setCommandsForTableAdapter(int module)
        {
            switch (module)
            {
                case 0:
                    {
                        //Согласно рекомендациям мс сделал, как написано ниже
                        base_nalogDataSet.Source_data_Subject_indexDataTable deleteRows = (base_nalogDataSet.Source_data_Subject_indexDataTable)cr.Data.Base.Ds.Source_data_Subject_index.GetChanges(DataRowState.Deleted);
                        base_nalogDataSet.Source_data_Subject_indexDataTable newRows = (base_nalogDataSet.Source_data_Subject_indexDataTable)cr.Data.Base.Ds.Source_data_Subject_index.GetChanges(DataRowState.Added);
                        base_nalogDataSet.Source_data_Subject_indexDataTable modifiedRows = (base_nalogDataSet.Source_data_Subject_indexDataTable)cr.Data.Base.Ds.Source_data_Subject_index.GetChanges(DataRowState.Modified);
                        try
                        {
                            if (deleteRows != null)
                            {
                                cr.Data.Base.SourceDataSubjectIndexTableAdapter.Update(deleteRows);
                            }
                            if (newRows != null)
                            {
                                cr.Data.Base.SourceDataSubjectIndexTableAdapter.Update(newRows);
                            }
                            if (modifiedRows != null)
                            {
                                cr.Data.Base.SourceDataSubjectIndexTableAdapter.Update(modifiedRows);
                            }
                        }

                        catch (Exception ex)
                        {
                            string err = ex.ToString();
                        }
                        finally
                        {
                            if (deleteRows != null)
                            {
                                deleteRows.Dispose();
                            }
                            if (newRows != null)
                            {
                                newRows.Dispose();
                            }
                            if (modifiedRows != null)
                            {
                                modifiedRows.Dispose();
                            }
                        }
                        break;
                    }
            }
        }
        private int returnInt(object obj)
        {
            int val = 0;
            
            try
            {
                val = Convert.ToInt32(obj);
            }
            catch (System.Exception ex)
            {
                val = 0;
            }
            return val;
        }
        private bool defineChildInField(string str, int child)
        {
            bool y = false;
            string[] strarray = str.Split(';');
            for (int i = 0; i < strarray.Length; i++)
            {
                int num = 0;
                try
                {
                    num = Convert.ToInt32(strarray[i]);
                }
                catch (System.Exception ex)
                {
                }
                if (num == child) { y = true; }
            }
            return y;
        }
        private string defineSourceTable(string sheet)
        {
            string col = "";
            string[] list = NalogAdministrator.Properties.Settings.Default.ShemeListsIndexesAndSQL.ToString().Split(';');
            bool isFind = false;
            foreach (string str in list)
            {
                string[] item = str.Split(',');
                if (item.Length > 1)
                {
                    if (sheet == item[1])
                    {
                        col = item[0].Trim();
                        isFind = true;
                    }
                }
            }
            if (!isFind) col = sheet;
            return col;

        }
    }
}