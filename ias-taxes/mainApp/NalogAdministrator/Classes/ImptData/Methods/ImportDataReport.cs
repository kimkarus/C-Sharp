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
            private int count1 = 0;
            private int count2 = 0;
            private int count3 = 0;
            private int count4 = 0;
            private int count5 = 0;
            private int checkedImprotedData = 0;
            private string[,] arrCodeTax;
            private bool allInOne_OnlyList = false;
              //
            private DataRow row;
            private base_nalogDataSet.Source_data_1NMRow NMRow;
            private base_nalogDataSet.Source_data_1NOMRow NOMRow;
            private base_nalogDataSet.Compare_tax_eeaRow CpRow;
            private List<int[]> listOfSubjects;
            private List<int[]> listOfTaxes;
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
                cr.Data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter();
                //
                if (!var.FilledTableTaxes && ds.Taxes != null)
                {
                    data.Base.TaxesTableAdapter.Fill(ds.Taxes); //заполняем таблицу налогов
                    var.FilledTableTaxes = true;
                }
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
                #region Цикл чтения файлов
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
                    var.ForcastInterval = cr.ImportData.ImpDataFile.ForcastInterval;
                    //Если файлы 1-НМ не во всех папках
                    if (var.Ch1NM && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM && !var.ChAllInOne)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }
                    //Если файлы 1-НОМ не во всех папках
                    if (var.Ch1NOM && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM && !var.ChAllInOne)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }
                    //Если есть файлы с прогнозными значениями но не во всех папках
                    if (var.ChForcast && (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast ||
                        cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast11) && !var.ChAllInOne)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }
                    //Если файлы 1-НОМ, но во всех папках
                    if (var.ChAllInOne && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }
                    if (var.ChAllInOne && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }

                }
                #endregion #region Цикл чтения файлов
                var.IndexFile = var.LibraryFolderFiles.Count;
                OnReady();
            }
            private void evenetOnChoiceReport()
            {
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM) var.TableAdapterMethod = "1NM";
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM) var.TableAdapterMethod = "1NOM";
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
                    AcceptMethodImport(j, var.IsImportOneList);
                }

            }
            private void AcceptMethodImport(int j, bool importOneList=false)
            {
                /*
                 * Метод, с помощью программа выбирает путь доваление данных (разные отчетности)
                 *
                 * */
                bool isListOk = true;
                if (CheckAllowableExcelSheet(impData.ClearStrExcelTable(sheet)) && var.Ch1NM ||
                    CheckAllowableExcelSheet(impData.ClearStrExcelTable(sheet)) && var.Ch1NOM ||
                    var.ChAllInOne)
                {
                    sheet = impData.ClearStrExcelTable(sheet);
                    string[] listTaxes = sheet.Split('-');
                    bool isListTaxes = false;
                    int t1=0;
                    int t2=0;
                    if (listTaxes.Length > 1 && listTaxes.Length <= 2)
                    {
                        isListTaxes = true; 
                        t1 = impData.returnNullInt(listTaxes[0]); 
                        t2 = impData.returnNullInt(listTaxes[1]);
                    }
                    if (isListTaxes)
                    {
                        if (t1 <= 0) isListTaxes = false;
                        if (t2 <= 0) isListTaxes = false;
                        isListOk = isListTaxes;
                    }
                    if (!isListTaxes && t1 == 0 && t2 == 0)
                    {
                        int code = impData.returnNullInt(sheet);
                        if (existNeedTax1NM(code)) { var.IsSheetTaxCode = true; }
                        var.CodeTax = code;
                        if (var.IsSheetTaxCode && code <= 0)
                        {
                            isListOk = false;
                        }
                    }
                    if (isListOk)
                    {
                        switch (var.MethExcel)
                        {
                            #region OPENFILE
                            case true:
                                {
                                    var.OpenXlApp();
                                    var.TakeIntervalFromExcel(cr.ImportData.ImpDataFile.FileFullPath);
                                    var.IndexCol = 3;
                                    var.NameSheetNow = sheet;
                                    var.OpenExcelSheet(sheet, j);

                                    if (var.InternalTable != null) { choiceAddInternalMethode(); }

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

                                    if (var.InternalTable != null) { choiceAddInternalMethode(); }
                                    break;
                                }
                        }
                            #endregion OLEDB
                    }
                }
            }
            private void choiceAddInternalMethode()
            {
                 if (ucReportImport.chAllInOne.Checked && ucReportImport.chListSubjects.Checked)
                {
                    listOfSubjects = var.ListOfIdsSubjects;
                }
                 if (ucReportImport.chAllInOne.Checked && ucReportImport.checkBoxListOfTaxes.Checked)
                 {
                     listOfTaxes = var.ListOfIdsTaxes;
                 }
                //
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
                    var.Ch1NM && !var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_1NM";

                    //
                    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                    //
                    doTableAdapter(var.TableAdapterMethod);
                }
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
    var.Ch1NM && var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_1NM";
                    //
                    AddIntervalTableData1NM_AllInOne(cr.ImportData.ImpDataFile.DataYear);
                    //
                    //if (!var.IsImportOneList)
                    //{
                        doTableAdapter(var.TableAdapterMethod);
                    //}
                }

                if ((cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast ||
                    cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast11) &&
                 var.ChForcast && var.Ch1NM && !var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_1NM";
                    //
                    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                    //
                    doTableAdapter(var.TableAdapterMethod);
                }

                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM &&
                    var.Ch1NOM && !var.ChAllInOne)
                {
                    AddIntervalTableData1NOM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                    //
                    doTableAdapter(var.TableAdapterMethod);
                }
                if (var.ChAllInOne && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM)
                {
                    var.IndexCol = 1;
                    if (sheet.Length < 5)
                    {
                        if (ucReportImport.chAllInOne.Checked && ucReportImport.chListSubjects.Checked)
                        {
                            allInOne_OnlyList = true;
                        }
                        AddIntervalTableData1NOM_AllInOne(cr.ImportData.ImpDataFile.DataYear);
                        doTableAdapter(var.TableAdapterMethod);

                    }
                }

            }
            private void doTableAdapter(string method)
            {
                switch (method)
                {
                    #region 1NOM
                    case "1NOM":
                        {
                            base_nalogDataSet.Source_data_1NOMDataTable deleteRows = (base_nalogDataSet.Source_data_1NOMDataTable)cr.Data.Base.Ds.Source_data_1NOM.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Source_data_1NOMDataTable newRows = (base_nalogDataSet.Source_data_1NOMDataTable)cr.Data.Base.Ds.Source_data_1NOM.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Source_data_1NOMDataTable modifiedRows = (base_nalogDataSet.Source_data_1NOMDataTable)cr.Data.Base.Ds.Source_data_1NOM.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.SourceData1NOMTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.SourceData1NOMTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.SourceData1NOMTableAdapter.Update(modifiedRows);
                                }
                            }
                            catch (Exception ex)
                            {
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
                            data.Base.SourceData1NOMTableAdapter.Fill(ds.Source_data_1NOM);
                            break;
                        }
                    #endregion 1NOM
                    #region 1NM
                    case "1NM":
                        {
                            
                            base_nalogDataSet.Source_data_1NMDataTable deleteRows = (base_nalogDataSet.Source_data_1NMDataTable)cr.Data.Base.Ds.Source_data_1NM.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Source_data_1NMDataTable newRows = (base_nalogDataSet.Source_data_1NMDataTable)cr.Data.Base.Ds.Source_data_1NM.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Source_data_1NMDataTable modifiedRows = (base_nalogDataSet.Source_data_1NMDataTable)cr.Data.Base.Ds.Source_data_1NM.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.SourceData1NMTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.SourceData1NMTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.SourceData1NMTableAdapter.Update(modifiedRows);
                                }
                            }
                            catch (Exception ex)
                            {
                                string rr = ex.Message.ToString();
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
                            ds.AcceptChanges();
                            cr.Data.Base.Ds.Source_data_1NM.Clear();
                            //data.Base.SourceData1NMTableAdapter.Fill(ds.Source_data_1NM);
                            break;
                        }
                    #endregion 1NM
                    #region Cp
                    case "Cp":
                        {

                            base_nalogDataSet.Compare_tax_eeaDataTable deleteRows = (base_nalogDataSet.Compare_tax_eeaDataTable)cr.Data.Base.Ds.Compare_tax_eea.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Compare_tax_eeaDataTable newRows = (base_nalogDataSet.Compare_tax_eeaDataTable)cr.Data.Base.Ds.Compare_tax_eea.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Compare_tax_eeaDataTable modifiedRows = (base_nalogDataSet.Compare_tax_eeaDataTable)cr.Data.Base.Ds.Compare_tax_eea.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.CompareTaxEeaTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.CompareTaxEeaTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.CompareTaxEeaTableAdapter.Update(modifiedRows);
                                }
                            }
                            catch (Exception ex)
                            {
                                string rr = ex.Message.ToString();
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
                            ds.AcceptChanges();
                            cr.Data.Base.Ds.Compare_tax_eea.Clear();
                            break;
                        }
                    #endregion Cp
                }
            }
            public void AddIntervalTableData1NM(int year, int subj)
            {
                cr.SWatch.Stop();
                cr.ProcessingEventsReadFile = cr.SWatch.ElapsedMilliseconds;
                cr.SWatch.Reset();
                cr.SWatch.Start();
                //
                //data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter(); //создаем адаптер для формы 1-НМ
                data.Base.TaxesTableAdapter.Fill(ds.Taxes); //заполняем таблицу налогов
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                //data.Base.SourceData1NMTableAdapter.Fill(data.Base.Ds.Source_data_1NM);
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
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j],2));
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
                                    int checkedImportedData1NM = 0;
                                    if (cr.ImportData.ImpDataFile.ForcastInterval < 12)
                                    {
                                        checkedImportedData1NM = checkImportedData1NM(subj, codeTax, year, i, j + 2,"", cr.ImportData.ImpDataFile.ParentIdSubject);
                                    }
                                    else
                                    {
                                        checkedImportedData1NM = checkImportedData1NM(subj, codeTax, year, i, 1 + 2, "", cr.ImportData.ImpDataFile.ParentIdSubject);
                                    }
                                    if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                        codeTax.ToString().Length == 4)
                                    {
                                        if (checkedImportedData1NM == 0)
                                        {
                                            var.Status = " добавляем ";
                                            NMRow = ds.Source_data_1NM.NewSource_data_1NMRow();
                                        }
                                        else if (checkedImportedData1NM == 1)
                                        {
                                            var.Status = " изменяем ";
                                            NMRow = ds.Source_data_1NM.FindByid(var.CheckedId);
                                        }
                                        else if (checkedImportedData1NM == 2)
                                        {
                                            var.Status = " удаляем ";
                                            ds.Source_data_1NM.FindByid(var.CheckedId).Delete();
                                        }
                                        else
                                        {
                                            var.Status = " проверено ";
                                        }
                                        if (checkedImportedData1NM == 1 || checkedImportedData1NM == 0)
                                        {
                                            numColTax = j;
                                            NMRow.id_tax = codeTax;
                                            if(cr.ImportData.ImpDataFile.ParentIdSubject!=0)
                                            {
                                                NMRow.id_subject = cr.ImportData.ImpDataFile.ParentIdSubject;
                                                NMRow.cid = subj;
                                            }
                                            else{
                                                NMRow.id_subject = subj;
                                                NMRow.pid = cr.ImportData.ImpDataFile.ParentIdSubject;
                                            }

                                            NMRow.year_data = year;
                                            
                                            OnReadInternalFile();
                                            /*
                                             * */
                                            //cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast
                                            int intervalDelta = var.ForcastInterval;
                                            int val = 0;
                                            switch (cr.ImportData.ImpDataFile.Type.ToString())
                                            {
                                                #region forcast

                                                case "1NM-FORCAST":
                                                    {
                                                        switch (sectionTax(codeTax))
                                                        {
                                                            #region 1
                                                            case 1:
                                                                {
                                                                    if (cr.ImportData.ImpDataFile.ForcastInterval < 12)
                                                                    {
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                                                        NMRow._1 = defineFullDelta(val, intervalDelta);
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][j + 2]);
                                                                        NMRow._2 = defineFullDelta(val, intervalDelta);
                                                                        //NMRow.temp = NMRow._1 + NMRow._2;
                                                                        //
                                                                        try
                                                                        {
                                                                            val = impData.returnNullInt(var.InternalTable.Rows[i][j + 3]);
                                                                            NMRow._3 = defineFullDelta(val, intervalDelta);
                                                                        }
                                                                        catch (System.Exception err)
                                                                        {
                                                                            val = impData.returnNullInt(0);
                                                                            NMRow._3 = val;
                                                                        }
                                                                        //
                                                                        try
                                                                        {
                                                                            val = impData.returnNullInt(var.InternalTable.Rows[i][j + 4]);
                                                                            NMRow._4 = defineFullDelta(val, intervalDelta);
                                                                        }
                                                                        catch (System.Exception err)
                                                                        {
                                                                            val = impData.returnNullInt(0);
                                                                            NMRow._4 = val;
                                                                        }
                                                                        val = Convert.ToInt32(NMRow._2) + Convert.ToInt32(NMRow._3);
                                                                        NMRow.TI = val;
                                                                    }
                                                                    else
                                                                    {
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][3]);
                                                                        NMRow.TI = val;
                                                                    }
                                                                    break;
                                                                }
                                                            #endregion 1
                                                            #region 2
                                                            case 2:
                                                                {
                                                                    if (cr.ImportData.ImpDataFile.ForcastInterval < 12)
                                                                    {
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                                                        NMRow._1 = defineFullDelta(val, intervalDelta);
                                                                        try
                                                                        {
                                                                            val = impData.returnNullInt(var.InternalTable.Rows[i][j + 2]);
                                                                            NMRow._2 = defineFullDelta(val, intervalDelta);
                                                                        }
                                                                        catch (System.Exception err)
                                                                        {
                                                                            val = impData.returnNullInt(0);
                                                                            NMRow._2 = val;
                                                                        }
                                                                        val = Convert.ToInt32(NMRow._2);
                                                                        NMRow.TI = val;
                                                                    }
                                                                    else
                                                                    {
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][3]);
                                                                        NMRow.TI = val;
                                                                    }
                                                                    break;

                                                                }
                                                            #endregion 2
                                                            #region 3
                                                            case 3:
                                                                {
                                                                    if (cr.ImportData.ImpDataFile.ForcastInterval < 12)
                                                                    {
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                                                        NMRow._1 = defineFullDelta(val, intervalDelta);
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][j + 2]);
                                                                        NMRow._2 = defineFullDelta(val, intervalDelta);
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][j + 3]);
                                                                        NMRow._3 = defineFullDelta(val, intervalDelta);
                                                                        try
                                                                        {
                                                                            val = impData.returnNullInt(var.InternalTable.Rows[i][j + 4]);
                                                                            NMRow._4 = defineFullDelta(val, intervalDelta);
                                                                        }
                                                                        catch (System.Exception err)
                                                                        {
                                                                            val = impData.returnNullInt(0);
                                                                            NMRow._4 = val;
                                                                        }
                                                                        val = Convert.ToInt32(NMRow._3);
                                                                        NMRow.TI = val;
                                                                    }
                                                                    else
                                                                    {
                                                                        val = impData.returnNullInt(var.InternalTable.Rows[i][3]);
                                                                        NMRow.TI = val;
                                                                    }
                                                                    break;
                                                                }
                                                            #endregion 3
                                                        }
                                                        NMRow.forcast = true;
                                                        break;
                                                    }
                                                #endregion forcast
                                                #region 1nm
                                                case "1NM":
                                                    {
                                                        switch (sectionTax(codeTax))
                                                        {
                                                            #region 1
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
                                                            #endregion 1
                                                            #region 2
                                                            case 2:
                                                                {
                                                                    NMRow._1 = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                                                    try
                                                                    {
                                                                        NMRow._2 = impData.returnNullInt(var.InternalTable.Rows[i][j + 2]);
                                                                    }
                                                                    catch (System.Exception err)
                                                                    {
                                                                        NMRow._2 = impData.returnNullInt(0);
                                                                    }
                                                                    NMRow.TI = Convert.ToInt32(NMRow._2);
                                                                    break;
                                                                }
                                                            #endregion 2
                                                            #region 3
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
                                                            #endregion 3
                                                        }
                                                        break;
                                                    }
                                                #endregion 1nm
                                            }
                                            if (ucReportImport.txtTarget.Text.Length > 0 && cr.ImportData.ImpDataFile.IsForcast && cr.ImportData.ImpDataFile.ForcastInterval < 12)
                                            {
                                                NMRow.comments = ucReportImport.txtTarget.Text + " за " + intervalDelta;
                                            }
                                            else if (cr.ImportData.ImpDataFile.IsForcast && cr.ImportData.ImpDataFile.ForcastInterval < 12)
                                            {
                                                NMRow.comments = "Прогнозное значение за " + intervalDelta;
                                            }
                                            else if (cr.ImportData.ImpDataFile.IsForcast && cr.ImportData.ImpDataFile.ForcastInterval == 12)
                                            {
                                                NMRow.comments = "Прогнозное значение за " + "год";
                                            }
                                        }
                                        if (checkedImportedData1NM == 0)
                                        {
                                            ds.Source_data_1NM.AddSource_data_1NMRow(NMRow);
                                        }
                                    }
                                }

                            lastnum = num;
                        }
                    }
                }
                var.IndexRecord = var.CountRecords;
                OnAddData();

                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
            }
            private int defineFullDelta(int source, int interval)
            {
                int val = 0;
                int countDelta = 12 - interval;
                int intervalDelta = countDelta;
                if (source > 0)
                {
                    float delta = source / interval * countDelta;
                    val = Convert.ToInt32(delta);
                }
                else { val = 0; }

                return val + source;
            }
            private float defineDelta(int source, int interval)
            {
                float delta = 0;

                delta = source / interval;

                return delta;
            }
        /*
            public void AddIntervalTableData1NMForcast(int year, int subj)
            {
                data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter(); //создаем адаптер для формы 1-НМ
                data.Base.TaxesTableAdapter.Fill(ds.Taxes); //заполняем таблицу налогов
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                data.Base.SourceData1NMTableAdapter.Fill(data.Base.Ds.Source_data_1NM);
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                OnReadFile();
                if (var.CountSection < 1)
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
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j],2));
                                codeTax = Convert.ToInt32(impData.returnNullInt(var.InternalTable.Rows[i][j]));//проверка на нулевое значение
                            }
                            catch (System.Exception err)
                            {
                                num = 0;
                                codeTax = 0;
                            }
                            if (codeTax != 0 && existNeedTax1NM(codeTax) &&
                                subj > 0 &&
                                year > 0 &&
                                codeTax > 0)
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

                                    NMRow.TI = impData.returnNullInt(var.InternalTable.Rows[i][j + 1]);
                                    NMRow.forcast = true;
                                    //
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
         * */
            public void AddIntervalTableData1NOM(int year, int subj)
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
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j],2));
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
                                int checkedIportedData1NOM = checkImportedData1NOM(subj, codeTax, year, i, j, cr.ImportData.ImpDataFile.ParentIdSubject);
                                if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                    codeTax.ToString().Length == 4 &&
                                    checkedIportedData1NOM == 0)
                                {
                                    count3++;
                                    numColTax = j;
                                    NOMRow = ds.Source_data_1NOM.NewSource_data_1NOMRow();
                                    NOMRow.id_tax = codeTax;
                                    if (cr.ImportData.ImpDataFile.ParentIdSubject != 0)
                                    {
                                        NOMRow.id_subject = cr.ImportData.ImpDataFile.ParentIdSubject;
                                        NOMRow.cid = subj;
                                    }
                                    else
                                    {
                                        NOMRow.id_subject = subj;
                                        NOMRow.pid = cr.ImportData.ImpDataFile.ParentIdSubject;
                                    }
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
                                    if (ucReportImport.chAllInOne.Checked)
                                    {
                                        NOMRow.comments = "Источник: сводная таблица ФНС";
                                    }

                                    ds.Source_data_1NOM.AddSource_data_1NOMRow(NOMRow);
                                }
                                break;
                            }
                            //data.Base.SourceData1NOMTableAdapter.Update(ds.Source_data_1NOM);
                            //data.Base.SourceData1NOMTableAdapter.Fill(ds.Source_data_1NOM);
                            lastnum = num;
                        }


                    }
                }
                var.IndexRecord = var.CountRecords;
                OnAddData();

                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
                cr.SWatch.Reset();
            }
            public void AddIntervalTableData1NOM_AllInOne(int year)
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
                if (!var.FilledTableTaxesVed && ds.Taxes_ved!=null)
                {
                    data.Base.TaxesVedTableAdapter.Fill(ds.Taxes_ved); //заполняем таблицу налогов
                    var.FilledTableTaxesVed = true;
                }
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                if (!var.FilledTable1NOM && data.Base.Ds.Source_data_1NOM!=null)
                {
                    data.Base.SourceData1NOMTableAdapter.Fill(data.Base.Ds.Source_data_1NOM);
                    var.FilledTable1NOM = true;
                }
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                int subj = 0;
                string strSubject = "";
                OnReadFile();

                if (var.CountSection < 75)
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
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j], 2));
                                /* Убираем из строки ненужные символы для считывания
                                 * */
                                string sheet_code_tax = sheet;
                                bool strClear = false;
                                do
                                {
                                    List<int> indexes = new List<int>();

                                    for (int a = 0; a < sheet.Length; a++)
                                    {
                                        indexes.Add(sheet_code_tax.LastIndexOf("$"));
                                        indexes.Add(sheet_code_tax.LastIndexOf("'"));
                                    }
                                    for (int a = 0; a < indexes.Count; a++)
                                    {
                                        if (indexes[a] < 0) { strClear = true; }
                                        else
                                        {
                                            if (sheet_code_tax.LastIndexOf("$") >= 0)
                                            {
                                                sheet_code_tax = sheet.Remove(sheet_code_tax.LastIndexOf("$"), 1);
                                            }
                                            if (sheet_code_tax.LastIndexOf("'") >= 0)
                                            {
                                                sheet_code_tax = sheet_code_tax.Remove(sheet_code_tax.LastIndexOf("'"), 1);
                                            }
                                        }
                                    }

                                }
                                while (!strClear);
                                codeTax = Convert.ToInt32(sheet_code_tax);//проверка на нулевое значение
                                strSubject = var.InternalTable.Rows[i][0].ToString();
                                subj = impData.defineParamSubjId(strSubject, cr.Data.Base.Ds.Subjects.subject_nameColumn.ToString(), "subject_name_reports", "", "");
                                var.IdSubjNow = subj;

                                count1++;
                            }
                            catch (System.Exception err)
                            {
                                num = 0;
                                codeTax = 0;
                            }
                            bool isListOfSubject = false;
                            if (allInOne_OnlyList)
                            {
                                foreach (int[] paramSubject in listOfSubjects)
                                {
                                    if (paramSubject[1] > 0)
                                    {
                                        if (subj == paramSubject[0] && year == paramSubject[1] && paramSubject[0] > 0)
                                        {
                                            isListOfSubject = true;
                                        }
                                    }
                                    if (subj == paramSubject[0])
                                    {
                                        isListOfSubject = true;
                                    }
                                }
                            }
                            if (codeTax != 0 && existNeedTax1NOM(codeTax) &&
                                subj > 0 &&
                                year > 0 &&
                                codeTax > 0 &&
                                (allInOne_OnlyList && isListOfSubject))
                            {
                                count2++;
                                int checkedImprotedData1NOM = checkImportedData1NOM(subj, codeTax, year, i, j);
                                if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                    codeTax.ToString().Length == 4)
                                {
                                    if (checkedImprotedData1NOM == 0)
                                    {
                                        var.Status = " добавляем ";
                                        NOMRow = ds.Source_data_1NOM.NewSource_data_1NOMRow();
                                    }
                                    if (checkedImprotedData1NOM == 1)
                                    {
                                        var.Status = " изменяем ";
                                        NOMRow = ds.Source_data_1NOM.FindByid(var.CheckedId);
                                    }
                                    if (checkedImprotedData1NOM == 2)
                                    {
                                        var.Status = " удаляем ";
                                        ds.Source_data_1NOM.FindByid(var.CheckedId).Delete();
                                    }
                                    if (checkedImprotedData1NOM == 3)
                                    {
                                        var.Status = " проверено ";
                                    }
                                    if (checkedImprotedData1NOM == 0 || checkedImprotedData1NOM == 1)
                                    {
                                        count3++;
                                        numColTax = j;
                                        NOMRow.id_tax = codeTax;
                                        NOMRow.pid = impData.defineParentIdSubject(subj);
                                        if (NOMRow.pid > 0)
                                        {
                                            NOMRow.id_subject = NOMRow.pid;
                                            NOMRow.cid = subj;
                                        }
                                        else
                                        {
                                            NOMRow.id_subject = subj;
                                        }
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
                                        if (ucReportImport.chAllInOne.Checked)
                                        {
                                            NOMRow.comments = "Источник: сводная таблица ФНС";
                                        }
                                    }
                                    if (checkedImprotedData1NOM == 0)
                                    {
                                        ds.Source_data_1NOM.AddSource_data_1NOMRow(NOMRow);
                                    }

                                }
                            }
                            lastnum = num;
                        }


                    }
                }
                var.IndexRecord = var.CountRecords;
                OnAddData();

                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
                cr.SWatch.Reset();
            }
            public void AddIntervalTableData1NM_AllInOne(int year)
            {
                #region переменные
                cr.SWatch.Stop();
                cr.ProcessingEventsReadFile = cr.SWatch.ElapsedMilliseconds;
                cr.SWatch.Reset();
                cr.SWatch.Start();
                count1 = 0;
                count2 = 0;
                count3 = 0;
                count4 = 0;
                count5 = 0;
                //data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter();
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                int numColTax = 0;
                int codeTax = 0;
                int subj = 0;
                string strSubject = "";
                OnReadFile();

                bool chechAllRows = false;
                int rowIndexCodeTax = 0;
                do
                {
                    rowIndexCodeTax = -1;
                    for (int r = 0; r < 15; r++)
                    {
                        string strIndex = var.InternalTable.Rows[r][0].ToString();
                        if (strIndex == "A" || strIndex == "А") rowIndexCodeTax = r;
                    }
                    chechAllRows = true;

                }
                while (!chechAllRows);
                if (rowIndexCodeTax <= 0) return;
                var.ListTaxesColsIds.Clear();
                #endregion переменные
                #region заполняем виды налогов из столбцов
                bool need = false;
                for (int c = 1; c < var.InternalTable.Columns.Count; c++)
                {
                    /*if (var.IsSheetTaxCode) { c = var.InternalTable.Columns.Count - 1; }*/
                    string[] arrCodeTax = var.InternalTable.Rows[rowIndexCodeTax][c].ToString().Split('.');
                     
                    need = existNeedTax1NM(impData.returnNullInt(arrCodeTax[0]));
                    if (var.IsListOfTaxes)
                    {
                        need = existNeedTax1NM(impData.returnNullInt(arrCodeTax[0]));
                    }
                    if (var.IsSheetTaxCode) { need = var.IsSheetTaxCode; arrCodeTax[0] = var.CodeTax.ToString(); }
                    if (listOfTaxes != null)
                    {
                        foreach (int[] str in listOfTaxes)
                        {
                            need = false;
                            if (arrCodeTax[0] == str[0].ToString()) need = true; break;
                        }
                    }
                    if (need)
                    {
                        string[,] arr = new string[1, 6];

                        arr[0, 0] = arrCodeTax[0]; //код налога
                        if (!var.IsSheetTaxCode)
                        {
                            arr[0, 4] = sectionTax(impData.returnNullInt(arrCodeTax[0])).ToString(); //раздел бюджета
                        }
                        if (arrCodeTax.Length > 1)
                        {
                            arr[0, 1] = arrCodeTax[1]; //столбец отчетности
                        }
                        else
                        {
                            if (arr[0, 4] == "2")
                            {
                                arr[0, 1] = "2"; //столбец отчетности
                            }
                            else
                            {
                                arr[0, 1] = "1"; //столбец отчетности
                            }
                        }
                        arr[0, 2] = c.ToString(); //индекс стоблца в таблице
                        if (var.IsSheetTaxCode)
                        {
                            arr[0, 0] = var.CodeTax.ToString();
                            arr[0, 1] = c.ToString();
                            arr[0, 2] = c.ToString();
                        }
                        arr[0, 3] = need.ToString();//необходим ли

                        var.ListTaxesColsIds.Add(arr);
                    }
                }
                #endregion заполняем виды налогов из столбцов
                #region сканируем все строки
                bool isAllowIdSubject = true;
                if (var.ListTaxesColsIds.Count > 0)
                {
                    for (int i = rowIndexCodeTax + 1; i < var.CountRecords; i++)
                    {

                        subj = 0;
                        var.IdSubjNow = 0;
                        //codeTax = 0;
                        var.IndexRecord = i + 1;

                        strSubject = var.InternalTable.Rows[i][0].ToString();
                        subj = impData.defineParamSubjId(strSubject, cr.Data.Base.Ds.Subjects.subject_nameColumn.ToString(), "subject_name_reports", "", "");
                        var.IdSubjNow = subj;
                        count1++;
                        if (ucReportImport.chAllInOne.Checked && ucReportImport.chListSubjects.Checked)
                        {
                            foreach (int[] allow in listOfSubjects)
                            {
                                if (allow[1] > 0)
                                {
                                    if (var.IdSubjNow == allow[0] && var.YearNow == allow[1])
                                    { isAllowIdSubject = true; var.IdSubjNow = allow[0]; break; }
                                }
                                if (var.IdSubjNow == allow[0])
                                { isAllowIdSubject = true; var.IdSubjNow = allow[0]; break; }
                                else { isAllowIdSubject = false; }
                            }
                        }

                        if (isAllowIdSubject && subj > 0)
                        {
                            for (int j = 0; j < var.ListTaxesColsIds.Count; j++)
                            {
                                int oldCodeTax = 0;
                                bool needNewRow = false;
                                arrCodeTax = var.ListTaxesColsIds[j];
                                codeTax = impData.returnNullInt(arrCodeTax[0, 0]);
                                //
                                int pid = impData.defineParentIdSubject(subj);
                                checkedImprotedData = 3;
                                if (isColumnSourceTable(arrCodeTax[0, 1]))
                                {
                                    checkedImprotedData = checkImportedData1NM(subj, codeTax, year, i, impData.returnNullInt(arrCodeTax[0, 2]), arrCodeTax[0, 1].ToString(), pid);
                                }
                                if (subj > 0 && year > 0 && impData.returnNullBool(arrCodeTax[0, 3]))
                                {
                                    #region проходим все субъекты по столбцу вида налога
                                    count2++;
                                    if (var.InternalTable.Rows[i][arrCodeTax[0, 2]] != System.DBNull.Value && checkedImprotedData != 3)
                                    {
                                        #region столбец есть в таблице назнаычения
                                        if (isColumnSourceTable(arrCodeTax[0, 1]))
                                        {
                                            if (checkedImprotedData == 0)
                                            {
                                                var.Status = " добавляем ";
                                                row = ds.Tables[var.SourceTableName].NewRow();
                                            }
                                            if (checkedImprotedData == 1)
                                            {
                                                var.Status = " изменяем ";
                                                row = ds.Tables[var.SourceTableName].Rows.Find(var.CheckedId);
                                            }
                                            if (checkedImprotedData == 2)
                                            {
                                                var.Status = " удаляем ";
                                                row = ds.Tables[var.SourceTableName].Rows.Find(var.CheckedId);
                                                row.Delete();
                                            }
                                            if (checkedImprotedData == 3)
                                            {
                                                var.Status = " проверено ";
                                            }
                                            if (checkedImprotedData == 0 || checkedImprotedData == 1)
                                            {
                                                count3++;
                                                numColTax = j;
                                                row["id_tax"] = codeTax;
                                                row["pid"] = pid;
                                                if (pid > 0)
                                                {
                                                    row["id_subject"] = row["pid"];
                                                    row["cid"] = subj;
                                                }
                                                else
                                                {
                                                    row["id_subject"] = subj;
                                                }
                                                row["year_data"] = year;
                                                OnReadInternalFile();

                                                row[arrCodeTax[0, 1]] = impData.returnNullInt(var.InternalTable.Rows[i][impData.returnNullInt(arrCodeTax[0, 2])]);

                                                //
                                                if (ucReportImport.txtTarget.Text.Length > 0)
                                                {
                                                    row["comments"] = ucReportImport.txtTarget.Text;
                                                }
                                                if (ucReportImport.chAllInOne.Checked)
                                                {
                                                    row["comments"] = "Источник: сводная таблица ФНС";
                                                }

                                            }
                                            if (checkedImprotedData == 0)
                                            {
                                                ds.Tables[var.SourceTableName].Rows.Add(row);
                                            }
                                        }
                                        #endregion столбец есть в таблице назнаычения
                                    }
                                    #endregion проходим все субъекты по столбцу вида налога
                                }
                                oldCodeTax = codeTax;
                            }

                        }
                    }
                }
                #region рассчитываем налоговый доход
                foreach (DataRow row in ds.Tables[var.SourceTableName].Rows)
                {
                    if (row != null && (row.RowState != DataRowState.Detached || row.RowState != DataRowState.Deleted) &&
                        (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified))
                    {
                        switch (sectionTax(impData.returnNullInt(row["id_tax"])))
                        {
                            case 1:
                                {
                                    row["TI"] = impData.returnNullInt(row["2"]) + impData.returnNullInt(row["3"]);
                                    break;
                                }
                            case 2:
                                {
                                    row["TI"] = impData.returnNullInt(row["2"]);
                                    break;
                                }
                            case 3:
                                {
                                    row["TI"] = impData.returnNullInt(row["3"]);
                                    break;
                                }
                        }
                    }
                }
                doTableAdapter(var.TableAdapterMethod);
                ds.AcceptChanges();
                #endregion рассчитываем налоговый доход
                #endregion сканируем все строки

                
                var.IndexRecord = var.CountRecords;
                OnAddData();

                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
                cr.SWatch.Reset();
            }
            private bool isColumnSourceTable(string name)
            {
                bool exist = false;
                foreach (DataColumn dc in ds.Tables[var.SourceTableName].Columns)
                {
                    if (name == dc.ColumnName.ToString()) exist = true;
                }
                return exist;
            }
            public void CompareReportsTaxEea()
            {
                cr.Data.Base.CompareTaxEeaTableAdapter = new base_nalogDataSetTableAdapters.Compare_tax_eeaTableAdapter();
                cr.Data.Base.SourceData1NOMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter();
                data.Base.SubjectsTableAdapter.Fill(ds.Subjects);
                var.TableAdapterMethod = "Cp";
                for (int s = 0; s < ds.Subjects.Count; s++)
                {
                    int id_subject = impData.returnNullInt(ds.Subjects[s]["id"]);
                    data.Base.SourceData1NOMTableAdapter.FillBy(ds.Source_data_1NOM, id_subject);
                    var.CountRecords = ds.Source_data_1NOM.Rows.Count;
                    for (int i = 0; i < ds.Source_data_1NOM.Rows.Count; i++)
                    {
                        var.Status = " калькуляция ";
                        for (int j = 0; j < ds.Source_data_1NOM.Columns.Count; j++)
                        {
                            if (chNumberColTaxEea(ds.Source_data_1NOM.Columns[j].ToString()))
                            {
                                int id_tax = var.CodeTax;
                                int id_eea = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_taxColumn]);
                                id_subject = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_subjectColumn]);
                                int year = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.year_dataColumn]);

                                if (id_tax != 0 && id_subject > 0 && year > 0 && id_eea > 0)
                                {
                                    var.SourceTableName = ds.Compare_tax_eea.TableName;
                                    int checkedImportedData = chRecordCompareTaxEea(id_tax, id_eea, id_subject, ds.Source_data_1NOM[i][j], year);
                                    if (id_tax.ToString().Length == 4)
                                    {
                                        if (checkedImportedData == 0)
                                        {
                                            var.Status = " добавляем ";
                                            CpRow = ds.Compare_tax_eea.NewCompare_tax_eeaRow();
                                        }
                                        else if (checkedImportedData == 1)
                                        {
                                            var.Status = " изменяем ";
                                            CpRow = ds.Compare_tax_eea.FindByid(var.CheckedId);
                                        }
                                        else if (checkedImportedData == 2)
                                        {
                                            var.Status = " удаляем ";
                                            ds.Compare_tax_eea.FindByid(var.CheckedId).Delete();
                                        }
                                        else
                                        {
                                            var.Status = " проверено ";
                                        }
                                        if (checkedImportedData == 1 || checkedImportedData == 0)
                                        {
                                            CpRow.id_subject = id_subject;
                                            CpRow.id_tax = id_tax;
                                            CpRow.id_eea = id_eea;
                                            CpRow.year_data = year;
                                            CpRow.TI = impData.returnNullInt(ds.Source_data_1NOM[i][j]);
                                        }
                                        if (checkedImportedData == 0)
                                        {
                                            ds.Compare_tax_eea.AddCompare_tax_eeaRow(CpRow);
                                        }
                                    }
                                    doTableAdapter(var.TableAdapterMethod);
                                }
                            }

                        }
                    }
                }
                OnAddData();
                var.Status = " готово ";
            }
            private bool chNumberColTaxEea(string col)
            {
                /*
                 * Ищим совпадения в схеме
                 * */
                bool y = false;
                if (ds.Source_data_1NOM_scheme.Rows.Count <= 0)
                {
                    cr.Data.Base.SourceData1NOMSchemeTableAdapter.Fill(ds.Source_data_1NOM_scheme);
                }
                for (int i = 0; i < ds.Source_data_1NOM_scheme.Rows.Count; i++)
                {
                    if (col == ds.Source_data_1NOM_scheme.Rows[i][ds.Source_data_1NOM_scheme.number_columnColumn].ToString().Replace(" ", ""))
                    {
                        y = true;
                        var.CodeTax = impData.returnNullInt(ds.Source_data_1NOM_scheme.Rows[i][ds.Source_data_1NOM_scheme.id_taxColumn]);
                    }
                }
                return y;
            }
            private int chRecordCompareTaxEea(object id_tax_ved, object id_tax, object id_subject, object TI, object year, int pid=0)
            {
                /*
                 * Проходимся по всем записям и находим совпадения
                 * */
                int y = -1;
                var.Status = " проверяем ";
                string id_subject_filter = "id_subject";
                string filter = ds.Compare_tax_eea.id_eeaColumn.ToString() + "=" + id_tax_ved.ToString() +
                    " AND " + ds.Compare_tax_eea.id_taxColumn.ToString() + "=" + id_tax.ToString() +
                    " AND " + ds.Compare_tax_eea.id_subjectColumn.ToString() + "=" + id_subject.ToString() +
                    " AND " + ds.Compare_tax_eea.year_dataColumn.ToString() + "=" + year.ToString();
                string select = "SELECT * FROM " + var.SourceTableName + " WHERE " + filter;
                var.SourceTable = cr.ImportData.ReturnSourceTable(select, var.SourceTableName);
                DataRow[] dRowLev1 = var.SourceTable.Select();
                int count = dRowLev1.Length;
                int indexRow = 0;
                foreach (DataRow lev1 in dRowLev1)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";
                    if ((int)id_subject == impData.returnNullInt(lev1[id_subject_filter]) &&
                     (int)id_tax == impData.returnNullInt(lev1["id_tax"]) &&
                     (int)year == impData.returnNullInt(lev1["year_data"]))
                    {
                        var.CheckedId = impData.returnNullInt(lev1["id"]);
                        y = 1; //изменяем
                        step1 = true;

                    }
                    if (!step1 && indexRow > 1)
                    {
                        var.CheckedId = impData.returnNullInt(lev1["id"]);
                        var.Status = " удаляем ";
                        ds.Compare_tax_eea.FindByid(var.CheckedId).Delete();
                        step2 = true;
                        y = 2; //удаляем
                    }
                    if (!step1 && !step2)
                    {
                        y = 0; //добавляем
                    }
                    if ((int)id_subject == impData.returnNullInt(lev1[id_subject_filter]) &&
                     (int)id_tax == impData.returnNullInt(lev1["id_tax"]) &&
                     (int)year == impData.returnNullInt(lev1["year_data"]) &&
                     (int)TI == impData.returnNullInt(lev1["TI"]))
                    {
                        var.CheckedId = impData.returnNullInt(lev1["id"]);
                        y = 3; //проверено
                        step3 = true;

                    }
                    bool exist = false;
                    if (ds.Tables[var.SourceTableName].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[var.SourceTableName].Rows.Count; i++)
                        {
                            DataRow r = ds.Tables[var.SourceTableName].Rows[i];

                            if (impData.returnNullInt(r["id"]) == impData.returnNullInt(lev1["id"]))
                            {
                                exist = true;
                            }
                        }
                        if (!exist)
                        {
                            ds.Tables[var.SourceTableName].ImportRow(lev1);
                        }
                    }
                    else
                    {
                        ds.Tables[var.SourceTableName].ImportRow(lev1);
                    }
                    //
                }
                if (dRowLev1.Length <= 0)
                {
                    y = 0;
                }
                return y;
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
                    if (impData.ClearSpacesStrExcelTable(sheet.ToUpper()) == impData.ClearSpacesStrExcelTable(line.ToUpper())) ret = true;
                }
                foreach (string line in NalogAdministrator.Properties.Settings.Default.AllowExcelOleDbSheets)
                {
                    if (sheet.ToUpper().Trim() == line.ToUpper().Trim()) var.MethExcel = false;
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
                if (data.Base.InternalDataTableRows.Length > 0)
                {
                    sect = Convert.ToInt32(data.Base.InternalDataTableRows[0][ds.Taxes.sectionColumn]);
                }
                var.IndexSection = sect;
                return sect;
            }
            private int checkImportedData1NM(int idSubj, int codeTax, int year, int index1, int index2, string strCol = "", int pid = 0)
            {
                /*
                 * Поиск в несколько этапов и определение действие с данными в таблице 1-НМ
                 * */

                int y = -1;
                string id_subject_filter = "";
                if (pid != 0)
                {
                    id_subject_filter = ds.Source_data_1NM.cidColumn.ToString();
                }
                else
                {
                    id_subject_filter = ds.Source_data_1NM.id_subjectColumn.ToString();
                }
                string filter = id_subject_filter + "=" + idSubj +
                    " AND " + ds.Source_data_1NM.id_taxColumn.ToString() + "=" + codeTax +
                    " AND " + ds.Source_data_1NM.year_dataColumn.ToString() + "=" + year;
                string select = "SELECT * FROM " + var.SourceTableName + " WHERE " + filter;
                var.SourceTable = cr.ImportData.ReturnSourceTable(select, var.SourceTableName);
                DataRow[] dRowLev1 = var.SourceTable.Select();
                int count = dRowLev1.Length;
                int indexRow = 0;
                if (strCol.Length <= 0) strCol = ds.Source_data_1NM.TIColumn.ColumnName;
                foreach (DataRow lev1 in dRowLev1)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";
                    if (idSubj == impData.returnNullInt(lev1[id_subject_filter]) &&
                     codeTax == impData.returnNullInt(lev1["id_tax"]) &&
                     year == impData.returnNullInt(lev1["year_data"]))
                    {
                        var.CheckedId = impData.returnNullInt(lev1["id"]);
                        y = 1; //изменяем
                        step1 = true;

                    }
                    if (!step1 && indexRow > 1)
                    {
                        var.CheckedId = impData.returnNullInt(lev1["id"]);
                        var.Status = " удаляем ";
                        ds.Source_data_1NM.FindByid(var.CheckedId).Delete();
                        step2 = true;
                        y = 2; //удаляем
                    }
                    if (!step1 && !step2)
                    {
                        y = 0; //добавляем
                    }
                    if (idSubj == impData.returnNullInt(lev1[id_subject_filter]) &&
                     codeTax == impData.returnNullInt(lev1["id_tax"]) &&
                     year == impData.returnNullInt(lev1["year_data"]) &&
                     impData.returnNullInt(var.InternalTable.Rows[index1][index2]) == impData.returnNullInt(lev1[strCol]))
                    {
                        var.CheckedId = impData.returnNullInt(lev1["id"]);
                        y = 3; //проверено
                        step3 = true;

                    }
                    bool exist = false;
                    if (ds.Tables[var.SourceTableName].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[var.SourceTableName].Rows.Count; i++)
                        {
                            DataRow r = ds.Tables[var.SourceTableName].Rows[i];
                            
                            if (impData.returnNullInt(r["id"]) == impData.returnNullInt(lev1["id"]))
                            {
                                exist = true;
                            }
                        }
                        if (!exist)
                        {
                            ds.Tables[var.SourceTableName].ImportRow(lev1);
                        }
                    }
                    else
                    {
                        ds.Tables[var.SourceTableName].ImportRow(lev1);
                    }
                    //
                }
                if (dRowLev1.Length <= 0)
                {
                    y = 0;
                }
                DataRow[] dRowLev2=ds.Tables[var.SourceTableName].Select(filter);
                if (dRowLev2.Length > 0) { y = 1; var.CheckedId = impData.returnNullInt(dRowLev2[0][ds.Source_data_1NM.idColumn]); }
                return y;
            }
            private int checkImportedData1NOM(int idSubj, int codeTax, int year, int index1, int index2, int childId = 0)
            {
                /*
                 * Поиск в несколько этапов и определение действие с данными в таблице 1-НОМ
                 * */
                int y = 0;
                DataRow[] dRowLev1;
                string id_filter = "";
                if (childId != 0)
                {
                    idSubj = childId;
                    id_filter = ds.Source_data_1NOM.cidColumn.ToString();
                }
                else
                {
                    id_filter = ds.Source_data_1NOM.id_subjectColumn.ToString();
                }
                string filter = id_filter + "=" + idSubj +
                    " AND " + ds.Source_data_1NOM.id_taxColumn.ToString() + "=" + codeTax +
                    " AND " + ds.Source_data_1NOM.year_dataColumn.ToString() + "=" + year;
                dRowLev1 = ds.Source_data_1NOM.Select(filter);
                int count = dRowLev1.Length;
                //if (!(count < 1))
                //{
                    int indexRow=0;
                    foreach (DataRow lev1 in dRowLev1)
                    {
                        bool step1 = false;
                        bool step2 = false;
                        bool step3 = false;
                        indexRow++;

                        var.Status = " проверяем";

                        if (idSubj == Convert.ToInt32(lev1[ds.Source_data_1NOM.id_subjectColumn]) &&
                            codeTax == Convert.ToInt32(lev1[ds.Source_data_1NOM.id_taxColumn]) &&
                            year == Convert.ToInt32(lev1[ds.Source_data_1NOM.year_dataColumn]))
                        {
                            var.CheckedId = Convert.ToInt32(lev1[ds.Source_data_1NOM.idColumn]);
                            y = 3;
                            step1 = true;
                        }
                        if (idSubj == Convert.ToInt32(lev1[ds.Source_data_1NOM.id_subjectColumn]) &&
                            codeTax == Convert.ToInt32(lev1[ds.Source_data_1NOM.id_taxColumn]) &&
                            year == Convert.ToInt32(lev1[ds.Source_data_1NOM.year_dataColumn]) &&
                            impData.returnNullInt(var.InternalTable.Rows[index1][index2 + 2]) != Convert.ToInt32(lev1[ds.Source_data_1NOM._2Column]))
                        {
                            y = 1;
                            var.CheckedId = Convert.ToInt32(lev1[ds.Source_data_1NOM.idColumn]);
                            step2 = true;
                        }
                        if (!step1 && !step2 && indexRow > 1)
                        {
                            var.CheckedId = Convert.ToInt32(lev1[ds.Source_data_1NOM.idColumn]);
                            step3 = true;
                            y = 2;
                        }
                        if (!step1 && !step2 && !step3)
                        {
                            y = 0;
                        }

                        var.Status = " проверяем";
                    }
                //}
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
