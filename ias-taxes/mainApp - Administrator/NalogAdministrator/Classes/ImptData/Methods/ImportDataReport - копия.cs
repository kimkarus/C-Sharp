using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Text;

namespace NalogAdministrator.Classes.ImpData.Methods
{
    public class ImportDataReport
    {
        #region Переменные
            //Переменные
            private Data data;
            private Core cr;
            private base_nalogDataSet ds;
            private Classes.ImpData.ImportData impData;
            private Classes.ImpData.ImportDataVariables var;
            private string connString = "";
            private string sheet = "";
            private Controls.UserControlImportDataReportDefaultTools ucReportImport;
            private int indexTaxForVed = 0;
            private int count1 = 0;
            private int count2 = 0;
            private int count3 = 0;
            private int count4 = 0;
            private int count5 = 0;
            //
            private base_nalogDataSet.Source_data_1NMRow NMRow;
            private base_nalogDataSet.Source_data_1NOMRow NOMRow;
            private base_nalogDataSet.Collected_tax_vedRow CollectTaxVedRow;
            private base_nalogDataSetTableAdapters.Collected_tax_vedTableAdapter collectionTax;
            private bool doCollectTaxVed = false;
            #region Глобальные
            public string ConnString { get { return connString; } set { connString = value; } }
            #endregion Глобальные
            #endregion Переменные
            //
            #region Конструктор
            public ImportDataReport(Core Cr, Data Data, Classes.ImpData.ImportData ImpData,
                Classes.ImpData.ImportDataVariables Var, string str, Controls.UserControlImportDataReportDefaultTools UcReportImport)
            {
                this.cr = Cr;
                this.data = Data;
                this.ds = Data.Base.Ds;
                this.impData = ImpData;
                this.var = Var;
                cr.Data.Files = new Files();
                this.ucReportImport = UcReportImport;
                //activateEvents();
            }
            #endregion Конструктор
            //
            #region Глобальные
            public void AddRecords(bool folder, bool chYear)
            {
                cr.SWatch.Stop();
                cr.GetParamBefore = cr.SWatch.ElapsedMilliseconds;
                cr.SWatch.Reset();
                cr.SWatch.Start();
                //cr.TimersAdd.Add(cr.CountTime.
                OnOpenFile();
                var.CountFiles = var.LibraryFolderFiles.Count;
                ArrayList arrList = new ArrayList();
                
                switch (folder)
                {
                    case true:
                        {
                            arrList = var.LibraryFolderFiles;
                            break;
                        }
                    case false:
                        {
                            arrList = var.LibraryFiles;
                            break;
                        }
                }
                #region Цикл_чтения файлов
                /*for (int i = 0; i < arrList.Count; i++)
                {
                    if (cr.ImportData.ImpDataFile.Type == var.Ch1NM)
                    {

                    }
                }*/
                for (int i = 0; i < arrList.Count; i++)
                {
                    /*
                     * Цикл проходится по всем файлам в коллекции и приминяет функцию добавления данных
                        */
                    var.IndexFile = i + 1; //меняем индекс в баре
                    var.TypeReportNow = cr.ImportData.ImpDataFile.Type;
                    var.MethExcel = ucReportImport.chExcel.Checked; //проверяем галку
                    cr.ImportData.ImpDataFile = (Classes.ImpData.ImportDataFile)arrList[i]; //перебираем коллекцию с файлами
                    impData.LoadExcelSchema(cr.ImportData.ImpDataFile.FileFullPath);
                    var.CountSection = 0;
                    var.NameDistrictNow = cr.ImportData.ImpDataFile.IdDistrict.ToString();
                    var.NameSubjectNow = cr.ImportData.ImpDataFile.SubjectShortName;
                    var.YearNow = cr.ImportData.ImpDataFile.DataYear;
                    if (var.Ch1NM && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }
                    if (var.Ch1NOM && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }

                }
                #endregion #region Цикл_чтения файлов
                var.IndexFile = var.LibraryFolderFiles.Count;
                OnReady();
            }
            private void evenetOnChoiceReport()
            {

                for (int j = 0; j < cr.Data.Files.DtExcelMeta.Rows.Count; j++)
                {
                    /*for (int k = 0; k < cr.Data.Files.DtExcelMeta.Rows.Count; k++)
                    {
                        foreach (string str in NalogAdministrator.Properties.Settings.Default.AllowExcelOleDbSheets)
                        {
                            if (cr.Data.Files.DtExcelMeta.Rows[j][2].ToString().ToUpper() == str.ToUpper())
                            {
                                sheet = str;
                                var.MethExcel = false;

                            }
                        }
                    }*/
                    sheet = cr.Data.Files.DtExcelMeta.Rows[j][2].ToString();
                    AcceptMethodImport(j);
                }

            }
            private void AcceptMethodImport(int j)
            {
                /*
                 * Метод, с помощью программа выбирает путь доваление данных (разные отчетности)
                 *
                 * */
                if (CheckAllowableExcelSheet(var.ClearStrExcelTable(sheet)) && var.Ch1NM ||
                    CheckAllowableExcelSheet(var.ClearStrExcelTable(sheet)) && var.Ch1NOM)
                {
                    switch (var.MethExcel)
                    {
                        #region OPENFILE
                        case true:
                            {
                                var.OpenXlApp();
                                var.TakeIntervalFromExcel(cr.ImportData.ImpDataFile.FileFullPath);
                                var.IndexCol = 3;
                                sheet = var.ClearStrExcelTable(sheet);
                                var.NameSheetNow = sheet;
                                var.OpenExcelSheet(sheet, j);
                                choiceAddInternalMethode();
                                var.CloseExcelAppl();
                                break;
                            }
                        #endregion
                        #region OLEDB
                        case false:
                            {

                                var.IndexCol = 1;
                                sheet = cr.Data.Files.DtExcelMeta.Rows[j][2].ToString();
                                var.NameSheetNow = sheet;
                                var.TakeIntervalOleDb(cr.ImportData.ImpDataFile.FileFullPath, sheet);
                                choiceAddInternalMethode();
                                break;
                            }
                    }
                        #endregion OLEDB
                }
            }
            private void choiceAddInternalMethode()
            {
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
                    var.Ch1NM) AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM &&
                    var.Ch1NOM) AddIntervalTableData1ONM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
            }
            public void AddIntervalTableData1NM(int year, int subj)
            {
                cr.SWatch.Stop();
                cr.ProcessingEventsReadFile = cr.SWatch.ElapsedMilliseconds;
                cr.SWatch.Reset();
                cr.SWatch.Start();
                //
                data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter(); //создаем адаптер для формы 1-НМ
                data.Base.TaxesTableAdapter.Fill(ds.Taxes); //заполняем таблицу налогов
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                data.Base.SourceData1NMTableAdapter.Fill(data.Base.Ds.Source_data_1NM);
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                OnReadFile();
                if (var.CountSection < 4)
                {
                    for (int i = 0; i < var.CountRecords; i++)
                    {

                        var.IndexRecord = i + 1;
                        for (int j = 0; j < var.IndexCol; j++)
                        {
                            //try
                            //{
                            try
                            {
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j]));
                                codeTax = Convert.ToInt32(impData.returnNullInt(var.InternalTable.Rows[i][j]));//проверка на нулевое значение
                            }
                            catch (System.Exception err)
                            {
                                num = 0;
                                codeTax = 0;
                            }
                                if (codeTax !=0 && existNeedTax1NM(codeTax) && 
                                    subj>0 &&
                                    year>0 &&
                                    codeTax>0)
                                {
                                    if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                        codeTax.ToString().Length == 4 &&
                                        !checkImportedData1NM(subj, codeTax, year))
                                    {
                                        numColTax = j;
                                        NMRow = ds.Source_data_1NM.NewSource_data_1NMRow();
                                        NMRow.id_tax = codeTax;
                                        NMRow.id_subject = subj;
                                        NMRow.year_data = year;
                                        OnReadInternalFile();
                                        switch (sectionTax(codeTax))
                                        {
                                            case 1:
                                                {
                                                    NMRow._1 = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                                    NMRow._2 = impData.returnNullInt(var.InternalTable.Rows[i][j + 2]);
                                                    //NMRow.temp = NMRow._1 + NMRow._2;
                                                    //
                                                    try
                                                    {
                                                        NMRow._3 = impData.returnNullInt(var.InternalTable.Rows[i][j + 3]);
                                                    }
                                                    catch (System.Exception err)
                                                    {
                                                        NMRow._3 = impData.returnNullInt(0);
                                                    }
                                                    //
                                                    try
                                                    {
                                                        NMRow._4 = impData.returnNullInt(var.InternalTable.Rows[i][j + 4]);
                                                    }
                                                    catch (System.Exception err)
                                                    {
                                                        NMRow._4 = impData.returnNullInt(0);
                                                    }
                                                    NMRow.TI = Convert.ToInt32(NMRow._2) + Convert.ToInt32(NMRow._3);
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    NMRow._1 = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                                    try
                                                    {
                                                        NMRow._2 = impData.returnNullInt(var.InternalTable.Rows[i][j + 2]);
                                                    }
                                                    catch(System.Exception err)
                                                    {
                                                        NMRow._2 = impData.returnNullInt(0);
                                                    }
                                                    NMRow.TI = Convert.ToInt32(NMRow._2);
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    NMRow._1 = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                                    NMRow._2 = impData.returnNullInt(var.InternalTable.Rows[i][j + 2]);
                                                    NMRow._3 = impData.returnNullInt(var.InternalTable.Rows[i][j + 3]);
                                                    try
                                                    {
                                                        NMRow._4 = impData.returnNullInt(var.InternalTable.Rows[i][j + 4]);
                                                    }
                                                    catch (System.Exception err)
                                                    {
                                                        NMRow._4 = impData.returnNullInt(0);
                                                    }
                                                    NMRow.TI = Convert.ToInt32(NMRow._3);
                                                    break;
                                                }
                                        }
                                        if (ucReportImport.txtTarget.Text.Length > 0)
                                        {
                                            NMRow.comments = ucReportImport.txtTarget.Text;
                                        }
                                        ds.Source_data_1NM.AddSource_data_1NMRow(NMRow);
                                    }
                                    break;
                                }

                            lastnum = num;
                        }


                    }
                }
                var.IndexRecord = var.CountRecords;
                OnAddData();
                data.Base.SourceData1NMTableAdapter.Update(ds.Source_data_1NM);
                data.Base.SourceData1NMTableAdapter.Fill(ds.Source_data_1NM);
                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
            }
            public void AddIntervalTableData1NMForcast(int year, int subj)
            {
            }
            public void AddIntervalTableData1ONM(int year, int subj)
            {
                cr.SWatch.Stop();
                cr.ProcessingEventsReadFile = cr.SWatch.ElapsedMilliseconds;
                cr.SWatch.Reset();
                cr.SWatch.Start();
                count1 = 0;
                count2 = 0;
                count3 = 0;
                count4 = 0;
                count5 = 0;
                data.Base.SourceData1NOMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter();
                data.Base.TaxesVedTableAdapter.Fill(ds.Taxes_ved); //заполняем таблицу налогов
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                data.Base.SourceData1NOMTableAdapter.Fill(data.Base.Ds.Source_data_1NOM);
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                OnReadFile();
                if (var.CountSection < 4)
                {
                    for (int i = 0; i < var.CountRecords; i++)
                    {

                        var.IndexRecord = i + 1;
                        for (int j = 0; j < var.IndexCol; j++)
                        {
                            //try
                            //{
                            try
                            {
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j]));
                                codeTax = Convert.ToInt32(impData.returnNullInt(var.InternalTable.Rows[i][j]));//проверка на нулевое значение
                                count1++;
                            }
                            catch (System.Exception err)
                            {
                                num = 0;
                                codeTax = 0;
                            }
                            if (codeTax != 0 && existNeedTax1NOM(codeTax) &&
                                subj > 0 &&
                                year > 0 &&
                                codeTax > 0)
                            {
                                count2++;
                                if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                    codeTax.ToString().Length == 4 &&
                                    !checkImportedData1NOM(subj, codeTax, year))
                                {
                                    count3++;
                                    numColTax = j;
                                    NOMRow = ds.Source_data_1NOM.NewSource_data_1NOMRow();
                                    NOMRow.id_tax = codeTax;
                                    NOMRow.id_subject = subj;
                                    NOMRow.year_data = year;
                                    OnReadInternalFile();
                                    //
                                    NOMRow._1 = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                    NOMRow._2 = impData.returnNullInt(var.InternalTable.Rows[i][j + 2]);
                                    NOMRow._3 = impData.returnNullInt(var.InternalTable.Rows[i][j + 3]);
                                    NOMRow._4 = impData.returnNullInt(var.InternalTable.Rows[i][j + 4]);
                                    NOMRow._5 = impData.returnNullInt(var.InternalTable.Rows[i][j + 5]);
                                    NOMRow._6 = impData.returnNullInt(var.InternalTable.Rows[i][j + 6]);
                                    try
                                    {
                                        NOMRow._7 = impData.returnNullInt(var.InternalTable.Rows[i][j + 7]);
                                    }
                                    catch (System.Exception err)
                                    {
                                        NOMRow._7 = impData.returnNullInt(0);
                                    }
                                    try
                                    {
                                        NOMRow._8 = impData.returnNullInt(var.InternalTable.Rows[i][j + 8]);
                                    }
                                    catch (System.Exception err)
                                    {
                                        NOMRow._8 = impData.returnNullInt(0);
                                    }
                                    try
                                    {
                                        NOMRow._9 = impData.returnNullInt(var.InternalTable.Rows[i][j + 9]);
                                    }
                                    catch (System.Exception err)
                                    {
                                        NOMRow._9 = impData.returnNullInt(0);
                                    }
                                    try
                                    {
                                        NOMRow._10 = impData.returnNullInt(var.InternalTable.Rows[i][j + 10]);
                                    }
                                    catch (System.Exception err)
                                    {
                                        NOMRow._10 = impData.returnNullInt(0);
                                    }
                                    try
                                    {
                                        NOMRow._11 = impData.returnNullInt(var.InternalTable.Rows[i][j + 11]);
                                    }
                                    catch (System.Exception err)
                                    {
                                        NOMRow._11 = impData.returnNullInt(0);
                                    }
                                    try
                                    {
                                        NOMRow._12 = impData.returnNullInt(var.InternalTable.Rows[i][j + 12]);
                                    }
                                    catch (System.Exception err)
                                    {
                                        NOMRow._12 = impData.returnNullInt(0);
                                    }
                                    try
                                    {
                                        NOMRow._13 = impData.returnNullInt(var.InternalTable.Rows[i][j + 13]);
                                    }
                                    catch (System.Exception err)
                                    {
                                        NOMRow._13 = impData.returnNullInt(0);
                                    }
                                    if (ucReportImport.txtTarget.Text.Length > 0)
                                    {
                                        NOMRow.comments = ucReportImport.txtTarget.Text;
                                    }

                                    ds.Source_data_1NOM.AddSource_data_1NOMRow(NOMRow);
                                }
                                break;
                            }
                            data.Base.SourceData1NOMTableAdapter.Update(ds.Source_data_1NOM);
                            data.Base.SourceData1NOMTableAdapter.Fill(ds.Source_data_1NOM);
                            lastnum = num;
                        }


                    }
                }
                var.IndexRecord = var.CountRecords;
                OnAddData();
                data.Base.SourceData1NOMTableAdapter.Update(ds.Source_data_1NOM);
                data.Base.SourceData1NOMTableAdapter.Fill(ds.Source_data_1NOM);
                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
                cr.SWatch.Reset();
            }
            public void CollectedReport1NOM()
            {
                collectionTax = new base_nalogDataSetTableAdapters.Collected_tax_vedTableAdapter();
                data.Base.SourceData1NOMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter();
                collectionTax.Fill(ds.Collected_tax_ved);
                data.Base.SourceData1NOMTableAdapter.Fill(ds.Source_data_1NOM);
                var.CountRecords = ds.Source_data_1NOM.Rows.Count;
                for (int i = 0; i < ds.Source_data_1NOM.Rows.Count; i++)
                {
                    var.Status = " калькуляция ";
                    for (int j = 0; j < ds.Source_data_1NOM.Columns.Count; j++)
                    {
                        if(chNumberColTaxVed(ds.Source_data_1NOM.Columns[j].ToString()))
                        {
                            chRecordCollectVed(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_taxColumn],
                            NalogAdministrator.Properties.Settings.Default.CodeTax1NOM[indexTaxForVed].ToString(),
                            ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_subjectColumn],
                            ds.Source_data_1NOM[i][j],
                            ds.Source_data_1NOM[i][ds.Source_data_1NOM.year_dataColumn]);
                            if (doCollectTaxVed==true)
                            {
                                var.Status = " записываем ";
                                CollectTaxVedRow = ds.Collected_tax_ved.NewCollected_tax_vedRow();
                                try
                                {
                                    CollectTaxVedRow.id_tax = Convert.ToInt32(NalogAdministrator.Properties.Settings.Default.CodeTax1NOM[indexTaxForVed].ToString());
                                }
                                catch (System.Exception err)
                                {
                                }
                                CollectTaxVedRow.id_tax_ved = Convert.ToInt32(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_taxColumn]);
                                CollectTaxVedRow.TI = Convert.ToInt32(ds.Source_data_1NOM[i][j]);
                                CollectTaxVedRow.year_data = Convert.ToInt32(ds.Source_data_1NOM[i][ds.Source_data_1NOM.year_dataColumn]);
                                CollectTaxVedRow.id_subject = Convert.ToInt32(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_subjectColumn]);
                                ds.Collected_tax_ved.AddCollected_tax_vedRow(CollectTaxVedRow);

                                var.Status = " обновляем ";

                            }
                        }

                    }
                    var.IndexRecord = i;
                }
                collectionTax.Update(ds.Collected_tax_ved);
                collectionTax.Fill(ds.Collected_tax_ved);
                //collectionTax.Update(ds.Collected_tax_ved);
                var.Status = " готово ";
            }
            private bool chNumberColTaxVed(string col)
            {
                /*
                 * Ищим совпадения в схеме
                 * */
                bool y = false;
                var.Status = " проверяем ";
                for (int i = 0; i < NalogAdministrator.Properties.Settings.Default.CodeTax1NOM.Count; i++)
                {
                    if (col == NalogAdministrator.Properties.Settings.Default.NumberCol1NOM[i].ToString())
                    {
                        y = true;
                        indexTaxForVed = i;
                    }
                }
                return y;
            }
            private void chRecordCollectVed(object id_tax_ved, object id_tax, object id_subject, object TI, object year)
            {
                /*
                 * Проходимся по всем записям и находим совпадения
                 * */
                doCollectTaxVed = false;
                var.Status = " проверяем ";
                //collectionTax.Fill(ds.Collected_tax_ved);
                string filter = ds.Collected_tax_ved.id_tax_vedColumn.ToString() + "=" + id_tax_ved.ToString() +
                    " AND " + ds.Collected_tax_ved.id_taxColumn.ToString() + "=" + id_tax.ToString() +
                    " AND " + ds.Collected_tax_ved.id_subjectColumn.ToString() + "=" + id_subject.ToString() +
                    " AND " + ds.Collected_tax_ved.TIColumn.ToString() + "=" + TI.ToString() +
                    " AND " + ds.Collected_tax_ved.year_dataColumn.ToString() + "=" + year.ToString();
                DataRow[] dtRow = ds.Collected_tax_ved.Select(filter);
                //if (dtRow.Length < 1) doCollectTaxVed = true; else doCollectTaxVed = true;
                if (dtRow.Length == 0) doCollectTaxVed = true; else doCollectTaxVed = false;
                /*foreach (DataRow row in dtRow)
                {
                    if (
                        row[ds.Collected_tax_ved.id_subjectColumn] == id_subject &&
                        row[ds.Collected_tax_ved.id_tax_vedColumn] == id_tax_ved &&
                        row[ds.Collected_tax_ved.id_taxColumn] == id_tax &&
                        row[ds.Collected_tax_ved.year_dataColumn] == year &&
                        row[ds.Collected_tax_ved.TIColumn] == TI)
                    {
                        doCollectTaxVed = false;
                        break;
                        
                    }
                    else
                    {
                        doCollectTaxVed = true;
                        break;
                    }
                }*/
            }
            #endregion Глобальные
            //
            #region Не глобальные
            private bool ruleYears(bool term)
            {
                bool y = false;
                if (!term) y = true;
                if (term && cr.ImportData.ImpDataFile.DataYear >= var.ChYearAfter && cr.ImportData.ImpDataFile.DataYear <= var.ChYearBefore) y = true;
                return y;

            }
            private bool CheckAllowableExcelSheet(string sheet)
            {
                bool ret = false;
                foreach (string line in NalogAdministrator.Properties.Settings.Default.AllowExcelSheet)
                {
                    if (var.ClearSpacesStrExcelTable(sheet.ToUpper()) == line.ToUpper()) ret = true;
                }
                foreach (string line in NalogAdministrator.Properties.Settings.Default.AllowExcelOleDbSheets)
                {
                    if (sheet.ToUpper().Trim() == line.ToUpper()) var.MethExcel = false;
                }
                return ret;
            }
            private void addErr(string err)
            {
                /*InternalDataSet.FileListDataTableRow flListRow;
                flListRow = intDs.FileListDataTable.NewFileListDataTableRow();
                flListRow.Error = err;
                flListRow.File_path = path;
                flListRow.File_folder = dir;
                flListRow.File_name = name;
                intDs.FileListDataTable.AddFileListDataTableRow(flListRow);*/
            }
            private bool existNeedTax1NM(int taxNumber)
            {
                /* функция выполняет поиск подходящего налога из списка исходника и сопоставляет их списку из базы
                 * */
                bool yes = false;
                for (int i = 0; i < ds.Taxes.Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Taxes.Rows[i][ds.Taxes.idColumn]) == taxNumber &&
                        Convert.ToBoolean(ds.Taxes.Rows[i][ds.Taxes.useColumn]) == true)
                    {
                        yes = true;
                    }
                }
                return yes;
            }
            private bool existNeedTax1NOM(int taxNumber)
            {
                /* функция выполняет поиск подходящего налога из списка исходника и сопоставляет их списку из базы
                 * */
                bool yes = false;
                for (int i = 0; i < ds.Taxes_ved.Rows.Count; i++)
                {
                    if ((int)ds.Taxes_ved.Rows[i][ds.Taxes_ved.idColumn] == taxNumber &&
                        (bool)ds.Taxes_ved.Rows[i][ds.Taxes_ved.useColumn])
                    {
                        yes = true;
                        count4++;
                    }
                }
                count5++;
                return yes;
            }
            private int sectionTax(int taxNumber)
            {
                int sect = 0;
                object objSect = ds.Taxes.FindByid(taxNumber);
                string filter = ds.Taxes.idColumn.ToString()+"=" + taxNumber.ToString();
                data.Base.InternalDataTableRows = ds.Taxes.Select(filter);
                sect = Convert.ToInt32(data.Base.InternalDataTableRows[0][ds.Taxes.sectionColumn]);
                var.IndexSection = sect;
                return sect;
            }
            private bool checkImportedData1NM(int idSubj, int codeTax, int year)
            {
                bool y = false; ;
                DataRow[] dRowLev1;
                string filter = ds.Source_data_1NM.id_subjectColumn.ToString() + "=" + idSubj +
                    " AND " + ds.Source_data_1NM.id_taxColumn.ToString() + "=" + codeTax;
                dRowLev1 = ds.Source_data_1NM.Select(filter);
                int count = dRowLev1.Length;
                foreach (DataRow lev1 in dRowLev1)
                {
                    if (idSubj == Convert.ToInt32(lev1[ds.Source_data_1NM.id_subjectColumn]) &&
                        codeTax == Convert.ToInt32(lev1[ds.Source_data_1NM.id_taxColumn]) &&
                        year == Convert.ToInt32(lev1[ds.Source_data_1NM.year_dataColumn]))
                    {
                        y = true;
                        break;
                    }
                   
                    var.Status = " проверяем";
                }
                return y;
            }
            private bool checkImportedData1NOM(int idSubj, int codeTax, int year)
            {
                bool y = false; ;
                DataRow[] dRowLev1;
                string filter = ds.Source_data_1NOM.id_subjectColumn.ToString() + "=" + idSubj +
                    " AND " + ds.Source_data_1NOM.id_taxColumn.ToString() + "=" + codeTax;
                dRowLev1 = ds.Source_data_1NOM.Select(filter);
                int count = dRowLev1.Length;
                foreach (DataRow lev1 in dRowLev1)
                {
                    var.Status = " проверяем";
                    if (idSubj == Convert.ToInt32(lev1[ds.Source_data_1NOM.id_subjectColumn]) &&
                        codeTax == Convert.ToInt32(lev1[ds.Source_data_1NOM.id_taxColumn]) &&
                        year == Convert.ToInt32(lev1[ds.Source_data_1NOM.year_dataColumn]))
                    {
                        y = true;
                    }

                    var.Status = " проверяем";
                }
                return y;
            }
            #region изминение_статуса
            private void OnOpenFile()
            {
                var.Status = " открываем ";
            }
            private void OnReadFile()
            {
                var.Status = " читаем/поиск ";
            }
            private void OnChechData()
            {
                var.Status = " проверяем ";
            }
            private void OnAddData()
            {
                var.Status = " заносим ";
            }
            private void OnReadInternalFile()
            {
                var.Status = " считываем ";
            }
            private void OnReady()
            {
                var.Status = " готово ";
            }
            #endregion изминение_статуса
            #endregion Не глобальные

    }
}
