using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace NalogAdministrator.Classes.ImpData.Methods
{
    public class ImportDataPopulation
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
        private Controls.UserControlImportDataPopulation ucPopulation;
        private base_nalogDataSet.Source_data_PopulationRow populationRow;
        private base_nalogDataSet.Source_data_Population_eeaRow populationEeaRow;
        private DataRow[] populationRows;
        private string strSubject = "";
        private int indexRowToStart = -1;
        private List<string> edits = new List<string>();
        private List<DataRow> childsSubjects = new List<DataRow>();
        //Работа с файлами и базой
        private Classes.Data Data = new Data();
        #region Конструктор
        public ImportDataPopulation(Core Cr, Classes.ImpData.ImportData ImpData,
                Classes.ImpData.ImportDataVariables Var, string str, Controls.UserControlImportDataPopulation Control)
        {
            //передача необходимых параметров
            this.cr = Cr;
            this.impData = ImpData;
            this.var = Var;
            cr.Data.Files = new Files();
            this.ucPopulation = Control;
            cr.Data.Base.SubjectsTableAdapter.Fill(cr.Data.Base.Ds.Subjects);
            cr.Data.Base.SourceDataPopulationTableAdapter = new base_nalogDataSetTableAdapters.Source_data_PopulationTableAdapter();
            cr.Data.Base.SourceDataPopulationEeaTableAdapter = new base_nalogDataSetTableAdapters.Source_data_Population_eeaTableAdapter();
        }
        #endregion Конструктор
        public void AddRecords(string sheet)
        {
            if (!CheackExcelSheet(sheet)) return;
            cr.Data.Base.SourceDataPopulationTableAdapter.Fill(cr.Data.Base.Ds.Source_data_Population);
            var.TakeIntervalOleDb(var.PathFile, sheet);
            var.InternalTable.TableName = sheet;
            var.Status = " добавляем"; //устанавливаем статус
            bool flag = true; //флаг на остановку цикла
            #region Поиск начальной строки входа
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
        public void AddRecordsEea(string sheet)
        {
            /*
             * Метод, который обрабатывает данные по населению занятых в экономике по виду экономической деятельности
             * */
            string error = "";
            int year_data = 0;
            string sheet_year = sheet;
            bool strClear = false;
            do
            {
                List<int> indexes = new List<int>();

                for (int i = 0; i < sheet.Length; i++)
                {
                    indexes.Add(sheet_year.LastIndexOf("$"));
                    indexes.Add(sheet_year.LastIndexOf("'"));
                }
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (indexes[i] < 0) { strClear = true; }
                    else
                    {
                        if (sheet_year.LastIndexOf("$") >= 0)
                        {
                            sheet_year = sheet.Remove(sheet_year.LastIndexOf("$"), 1);
                        }
                        if (sheet_year.LastIndexOf("'") >= 0)
                        {
                            sheet_year = sheet_year.Remove(sheet_year.LastIndexOf("'"), 1);
                        }
                    }
                }

            }
            while (!strClear);
            try { year_data = Convert.ToInt16(sheet_year); }
            catch (System.Exception err) { error = "1"; }
            if (error == "1") { return; }
            var.YearNow = year_data;
            cr.Data.Base.SourceDataPopulationEeaTableAdapter.Fill(cr.Data.Base.Ds.Source_data_Population_eea);
            var.TakeIntervalOleDb(var.PathFile, sheet);
            var.InternalTable.TableName = sheet;
            var.Status = " добавляем"; //устанавливаем статус
            bool flag = true; //флаг на остановку цикла
            #region Поиск начальной строки входа
            for (int i = 0; i < var.InternalTable.Rows.Count && flag; i++)
            {
                for (int j = 0; j < var.InternalTable.Columns.Count; j++)
                {
                    if (var.InternalTable.Rows[i][0].ToString() == "Код_налога")
                    {
                        indexRowToStart = i;
                        flag = false;
                        break;
                    }
                }
            }
            if (indexRowToStart < 0) { return; }
            #endregion Поиск начальной строки входа
            if (indexRowToStart != -1)
            {
                #region Помечаем столбцы с налогами
                //читаем и индексируем поле с налогами
                var.Taxes_eea.Clear();
                for (int j = 0; j < var.InternalTable.Columns.Count; j++)
                {
                    try
                    {
                        int tax_eea = Convert.ToInt32(var.InternalTable.Rows[indexRowToStart][j]);
                        var.Taxes_eea.Add(new List<int> { j, tax_eea });
                    }
                    catch (System.Exception err)
                    {
                    }
                }
                #endregion Помечаем столбцы с налогами
            }
            AddIntervalTableData(1);
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
                            var.IdSubjNow = impData.defineParamSubjId(strSubject, cr.Data.Base.Ds.Subjects.subject_nameColumn.ToString(),"","","");

                            #endregion проверка значения
                            for (int j = 0; j < var.Years.Count; j++)
                            {
                                var.YearNow = var.Years[j][1];
                                ///ucPopulation.dataGridViewPopulation.CurrentCell.Value = j;
                                if (var.InternalTable.Rows[var.IndexRecord][j] != System.DBNull.Value &&
                                    var.IdSubjNow > 0)
                                {
                                    //
                                    status = checkImportedData(var.IdSubjNow, var.YearNow, impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][j], 2), 0, 0, var.InternalTable.TableName);
                                    if (status == 0)
                                    {
                                        add = true;
                                        var.Status = " добавляем ";
                                        populationRow = cr.Data.Base.Ds.Source_data_Population.NewSource_data_PopulationRow();
                                        populationRow.id_subject = var.IdSubjNow;
                                        populationRow.year_data = Convert.ToInt16(var.Years[j][1]);
                                        populationRow[var.InternalTable.TableName] = impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][var.Years[j][0]], 2);
                                        int pid = checkSubjectPId(var.IdSubjNow);
                                        if (pid > 0)
                                        {
                                            populationRow.pid = pid;
                                        }
                                        cr.Data.Base.Ds.Source_data_Population.AddSource_data_PopulationRow(populationRow);
                                    }
                                    if (status == 1)
                                    {
                                        var.Status = " изменяем ";
                                        populationRow = cr.Data.Base.Ds.Source_data_Population.FindByid(var.CheckedId);
                                        populationRow.year_data = Convert.ToInt16(var.YearNow);
                                        populationRow[var.InternalTable.TableName] = impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][var.Years[j][0]], 2);
                                        int pid = checkSubjectPId(var.IdSubjNow);
                                        if (pid > 0)
                                        {
                                            populationRow.pid = pid;
                                        }
                                    }
                                    if (status == 2)
                                    {
                                        var.Status = " удаляем ";
                                        cr.Data.Base.Ds.Source_data_Population.FindByid(var.CheckedId).Delete();
                                    }
                                    if (status == 3)
                                    {
                                        var.Status = " проверено ";
                                    }
                                }
                            }
                        }
                        setCommandsForTableAdapter(module);
                        cr.Data.Base.Ds.AcceptChanges();
                        cr.Data.Base.SourceDataPopulationTableAdapter.Fill(cr.Data.Base.Ds.Source_data_Population);
                        status = -1;
                        break;
                        #endregion Общее
                    }
                case 1:
                    {
                        #region ВЭД
                        //indexRowToStart = 89;

                        for (var.IndexRecord = indexRowToStart + 1; var.IndexRecord < var.InternalTable.Rows.Count; var.IndexRecord++)
                        {
                            #region Идём по строкам исходника
                            #region проверка значения
                            try
                            {
                                strSubject = var.InternalTable.Rows[var.IndexRecord][0].ToString();

                            }
                            catch (System.Exception err)
                            {
                            }
                            var.IdSubjNow = impData.defineParamSubjId(strSubject, cr.Data.Base.Ds.Subjects.subject_nameColumn.ToString(),"","","");

                            int pid = checkSubjectPId(var.IdSubjNow); //Смотрим субъект-родитель
                            bool childsSubject = false;
                            if (pid > 0)
                            {
                                childsSubject = true;
                            }
                            else
                            {
                                childsSubject = false;
                            }

                            int iiii = var.IdSubjNow;
                            #endregion проверка значения
                            for (int j = 0; j < var.Taxes_eea.Count; j++)
                            {
                                #region Идём по столбца исходника
                                if (var.InternalTable.Rows[var.IndexRecord][j] != System.DBNull.Value &&
                                    var.IdSubjNow > 0)
                                {
                                    status = checkImportedData(var.IdSubjNow, var.YearNow, impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][var.Taxes_eea[j][0]], 2), var.Taxes_eea[j][1], 1, "",pid);
                                    if (status == 0)
                                    //Проверяем наличие в базе
                                    {
                                        add = true;
                                        var.Status = " добавляем ";
                                        populationEeaRow = cr.Data.Base.Ds.Source_data_Population_eea.NewSource_data_Population_eeaRow();
                                        if (pid > 0)
                                        {
                                            populationEeaRow.id_subject = pid;
                                            populationEeaRow.cid = var.IdSubjNow;
                                        }
                                        else
                                        {
                                            populationEeaRow.id_subject = var.IdSubjNow;
                                        }
                                        populationEeaRow.year_data = Convert.ToInt16(var.YearNow);
                                        populationEeaRow.id_tax_eea = Convert.ToInt32(var.Taxes_eea[j][1]);
                                        populationEeaRow.population = impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][var.Taxes_eea[j][0]], 2);
                                        if (childsSubject)
                                        {
                                            populationEeaRow.pid = pid;
                                            childsSubjects.Add(populationEeaRow);
                                        }
                                        cr.Data.Base.Ds.Source_data_Population_eea.AddSource_data_Population_eeaRow(populationEeaRow);
                                    }
                                    if (status == 1)
                                    {
                                        var.Status = " изменяем ";
                                        populationEeaRow = cr.Data.Base.Ds.Source_data_Population_eea.FindByid(var.CheckedId);
                                        populationEeaRow.year_data = Convert.ToInt16(var.YearNow);
                                        populationEeaRow.id_tax_eea = Convert.ToInt32(var.Taxes_eea[j][1]);
                                        populationEeaRow.population = impData.returnNullDecimal(var.InternalTable.Rows[var.IndexRecord][var.Taxes_eea[j][0]], 2);
                                        if (childsSubject)
                                        {
                                            populationEeaRow.pid = pid;
                                            childsSubjects.Add(populationEeaRow);
                                        }
                                    }
                                    if (status == 2)
                                    {
                                        var.Status = " удаляем ";
                                        cr.Data.Base.Ds.Source_data_Population_eea.FindByid(var.CheckedId).Delete();
                                    }
                                    if (status == 3)
                                    {
                                        var.Status = " проверено ";
                                    }
                                }
                                #endregion Идём по столбца исходника
                            }

                            #region Даем команды TableAdapter
                            setCommandsForTableAdapter(module);
                            cr.Data.Base.Ds.AcceptChanges();
                            cr.Data.Base.SourceDataPopulationEeaTableAdapter.Fill(cr.Data.Base.Ds.Source_data_Population_eea);
                            #endregion Даем команды TableAdapter
                            status = -1;
                            #endregion Идём по строкам исходника
                        }
                        #region Обрабатываем данные для родителей

                        //----1-----Делаем выборку данных, которые имеют родительские объекты
                        string filter1="pid > 0 AND year_data=" + var.YearNow.ToString();
                        DataRow[] drs1=cr.Data.Base.Ds.Source_data_Population_eea.Select(filter1);
                        //----1-----

                        foreach (DataRow dr1 in drs1)
                        {
                            if (dr1.RowState != DataRowState.Detached)
                            {
                                //----2-----Идем по строкам детей и выбираем правильного родителя
                                string filter2 = "id_subject=" + dr1["pid"] +
                                    " AND id_tax_eea=" + dr1["id_tax_eea"] +
                                    " AND year_data=" + dr1["year_data"] +
                                    " AND cid IS NULL";
                                DataRow[] drs2 = cr.Data.Base.Ds.Source_data_Population_eea.Select(filter2);
                                //----2-----
                                if (drs2.Length > 0)
                                {
                                    foreach (DataRow dr2 in drs2)
                                    {
                                        decimal subChildDr1 = 0;

                                        if (dr1["population"] != DBNull.Value) { subChildDr1 = impData.returnNullDecimal(dr1["population"], 2); }

                                        if (!defineChildInField(dr2["sub_childs"].ToString(), returnInt(dr1["id_subject"])))
                                        {
                                            var.Status = " изменяем ";
                                            populationEeaRow = cr.Data.Base.Ds.Source_data_Population_eea.FindByid(impData.returnNullInt(dr2[cr.Data.Base.Ds.Source_data_Population_eea.idColumn]));
                                            decimal subParent = impData.returnNullDecimal(populationEeaRow.population);
                                            populationEeaRow.population = subParent - subChildDr1;
                                            if (dr2["sub_childs"] == DBNull.Value)
                                            {
                                                //populationEeaRow.sub_childs = dr1["id_subject"] + ";";
                                            }
                                            else
                                            {
                                                //populationEeaRow.sub_childs = populationEeaRow.sub_childs + dr1["id_subject"] + ";";
                                            }

                                        }
                                    }
                                }
                            }
                        }
                        setCommandsForTableAdapter(1);
                        cr.Data.Base.Ds.AcceptChanges();
                        cr.Data.Base.SourceDataPopulationEeaTableAdapter.Fill(cr.Data.Base.Ds.Source_data_Population_eea);
                        //
                        #endregion Обрабатываем данные для родителей
                        #endregion ВЭД
                        break;
                    }
            }

        }
        private int checkImportedData(int idSubj, int year, decimal val, int tax, int module, string nameCol="", int pid=0)
        {
            int yes = 0;
            //var.Status = " проверяем"; //устанавливаем статус
            string id_subject_filter = "";
            if (pid != 0)
            {
                id_subject_filter = cr.Data.Base.Ds.Source_data_Population_eea.cidColumn.ToString();
            }
            else
            {
                id_subject_filter = cr.Data.Base.Ds.Source_data_Population_eea.id_subjectColumn.ToString();
            }
            DataRow[] dRowLev1; //вводим переменную для коллекции строк
            switch (module)
            {
                case 0:
                    {
                        #region Общее
                        //создаем фильтр
                        string filter = cr.Data.Base.Ds.Source_data_Population.id_subjectColumn.ToString() + "=" + idSubj +
                            " AND " + cr.Data.Base.Ds.Source_data_Population.year_dataColumn.ToString() + "=" + year; 
                        dRowLev1 = cr.Data.Base.Ds.Source_data_Population.Select(filter);
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
                                if (idSubj == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population.id_subjectColumn]) &&
                                    year == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population.year_dataColumn]) &&
                                    impData.returnNullInt(row[cr.Data.Base.Ds.Source_data_Population.Columns[var.InternalTable.TableName]]) != 0)
                                {
                                    yes = 3;
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population.idColumn]);
                                    step1 = true;
                                }
                                if (idSubj == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population.id_subjectColumn]) &&
                                    year == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population.year_dataColumn]) &&
                                    (val != impData.returnNullDecimal(row[cr.Data.Base.Ds.Source_data_Population.Columns[var.InternalTable.TableName]], 2) || 
                                    impData.returnNullInt(row[cr.Data.Base.Ds.Source_data_Population.Columns[var.InternalTable.TableName]]) == 0) &&
                                    indexRow <= 1)
                                {
                                    yes = 1;
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population.idColumn]);
                                    step2 = true;
                                }
                                if (!step1 && !step2 && indexRow > 1)
                                {
                                    yes = 2;
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population.idColumn]);
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
                case 1:
                    {
                        #region ВЭД
                        string filter = id_subject_filter + "=" + idSubj +
                            " AND " + cr.Data.Base.Ds.Source_data_Population_eea.year_dataColumn.ToString() + "=" + year +
                            " AND " + cr.Data.Base.Ds.Source_data_Population_eea.id_tax_eeaColumn.ToString() + "=" + tax; //создаем фильтр
                        dRowLev1 = cr.Data.Base.Ds.Source_data_Population_eea.Select(filter);
                        #region Проверям строки
                        if (dRowLev1.Length > 0 && idSubj > 0 && year > 0 && tax > 0)
                        {
                            yes = 0;
                            int indexRow = 0;

                            foreach (DataRow row in dRowLev1)
                            {
                                bool step1 = false;
                                bool step2 = false;
                                bool step3 = false;
                                indexRow++;
                                //проходимся по найденныи позициям и находим совпадения

                                //шаг 1
                                if (idSubj == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.id_subjectColumn]) &&
                                    year == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.year_dataColumn]) &&
                                    tax == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.id_tax_eeaColumn]))
                                {
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.idColumn]);
                                    yes = 3;
                                    step1 = true;
                                }
                                //шаг 2
                                //если как-то значения отличаются, то изменяем старые
                                if (idSubj == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.id_subjectColumn]) &&
                                    year == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.year_dataColumn]) &&
                                    tax == Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.id_tax_eeaColumn]) &&
                                    val != impData.returnNullDecimal(row[cr.Data.Base.Ds.Source_data_Population_eea.Columns[cr.Data.Base.Ds.Source_data_Population_eea.populationColumn.ColumnName]], 2) &&
                                    indexRow <= 1)
                                {
                                    yes = 1;
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.idColumn]);
                                    step2 = true;
                                }
                                //шаг 3
                                if (!step1 && !step2 && indexRow > 1)
                                {
                                    yes = 2;
                                    var.CheckedId = Convert.ToInt32(row[cr.Data.Base.Ds.Source_data_Population_eea.idColumn]);
                                    step3 = true;
                                }
                                //шаг 4
                                if (!step1 && !step2 && !step3)
                                {
                                    yes = 0;
                                }
                            }
                        #endregion Проверям строки
                        }
                        else if (dRowLev1.Length <= 0)
                        {
                            yes = 0;
                        }
                        else
                        {
                            yes = 3;
                        }
                        break;
                        #endregion ВЭД
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
            foreach (string line in NalogAdministrator.Properties.Settings.Default.TablesPopulation)
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
                        base_nalogDataSet.Source_data_PopulationDataTable deleteRows = (base_nalogDataSet.Source_data_PopulationDataTable)cr.Data.Base.Ds.Source_data_Population.GetChanges(DataRowState.Deleted);
                        base_nalogDataSet.Source_data_PopulationDataTable newRows = (base_nalogDataSet.Source_data_PopulationDataTable)cr.Data.Base.Ds.Source_data_Population.GetChanges(DataRowState.Added);
                        base_nalogDataSet.Source_data_PopulationDataTable modifiedRows = (base_nalogDataSet.Source_data_PopulationDataTable)cr.Data.Base.Ds.Source_data_Population.GetChanges(DataRowState.Modified);
                        try
                        {
                            if (deleteRows != null)
                            {
                                cr.Data.Base.SourceDataPopulationTableAdapter.Update(deleteRows);
                            }
                            if (newRows != null)
                            {
                                cr.Data.Base.SourceDataPopulationTableAdapter.Update(newRows);
                            }
                            if (modifiedRows != null)
                            {
                                cr.Data.Base.SourceDataPopulationTableAdapter.Update(modifiedRows);
                            }
                            //cr.Data.Base.Ds.Source_data_Population_eea.AcceptChanges();
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
                            //cr.Data.Base.SourceDataPopulationEeaTableAdapter.Update(cr.Data.Base.Ds.Source_data_Population_eea);
                        }
                        break;
                    }
                case 1:
                    {
                        //Согласно рекомендациям мс сделал, как написано ниже
                        base_nalogDataSet.Source_data_Population_eeaDataTable deleteRows = (base_nalogDataSet.Source_data_Population_eeaDataTable)cr.Data.Base.Ds.Source_data_Population_eea.GetChanges(DataRowState.Deleted);
                        base_nalogDataSet.Source_data_Population_eeaDataTable newRows = (base_nalogDataSet.Source_data_Population_eeaDataTable)cr.Data.Base.Ds.Source_data_Population_eea.GetChanges(DataRowState.Added);
                        base_nalogDataSet.Source_data_Population_eeaDataTable modifiedRows = (base_nalogDataSet.Source_data_Population_eeaDataTable)cr.Data.Base.Ds.Source_data_Population_eea.GetChanges(DataRowState.Modified);
                        try
                        {
                            if (deleteRows != null)
                            {
                                cr.Data.Base.SourceDataPopulationEeaTableAdapter.Update(deleteRows);
                            }
                            if (newRows != null)
                            {
                                cr.Data.Base.SourceDataPopulationEeaTableAdapter.Update(newRows);
                            }
                            if (modifiedRows != null)
                            {
                                cr.Data.Base.SourceDataPopulationEeaTableAdapter.Update(modifiedRows);
                            }
                            //cr.Data.Base.Ds.Source_data_Population_eea.AcceptChanges();
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
                            //cr.Data.Base.SourceDataPopulationEeaTableAdapter.Update(cr.Data.Base.Ds.Source_data_Population_eea);
                        }
                        break;
                    }
            }
        }
        private void changeDataParentSubject(DataRow[] drs2)
        {

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
    }
}