using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

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
            private base_nalogDataSet.Source_data_4NMRow NM4Row;
            private base_nalogDataSet.Source_data_5ENVDRow ENVD5Row;
            private base_nalogDataSet.Source_data_5USNRow US5NRow;
            private base_nalogDataSet.Source_data_1PATENTRow PATENT1Row;
            private base_nalogDataSet.Source_data_Subject_indexRow subjectIndexRow;
            private base_nalogDataSet.Source_data_1NOMRow NOMRow;
            private base_nalogDataSet.Compare_tax_eeaRow CpRow;
            private base_nalogDataSet.Compare_tax_budgetRow SpTaxRow;
            private base_nalogDataSet.Compare_eea_budgetRow SpEeaRow;
            private List<int[]> listOfSubjects;
            private List<int[]> listOfTaxes;
        //
            private bool codeChanged = false;
            private int newCode = 0;
        //
            private Stream queryStream;
            private Stream sStream;
            private StreamReader reader;
            private StreamWriter writer;
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
                if ((!var.FilledTableTaxes && ds.Taxes == null) || ds.Taxes.Rows.Count <= 0)
                {
                    data.Base.TaxesTableAdapter.Fill(ds.Taxes); //заполняем таблицу налогов
                    var.FilledTableTaxes = true;
                }
                if ((!var.FilledTableDebts && ds.Debts == null) || ds.Debts.Rows.Count <= 0)
                {
                    data.Base.DebtsTableAdapter.Fill(ds.Debts); //заполняем таблицу налогов
                    var.FilledTableDebts = true;
                }
                if (ds.Source_data_1NOM_scheme == null || ds.Source_data_1NOM_scheme.Rows.Count <= 0)
                {
                    data.Base.SourceData1NOMSchemeTableAdapter.Fill(ds.Source_data_1NOM_scheme);
                }
                if (ds.Source_data_1NOM_header_scheme == null || ds.Source_data_1NOM_header_scheme.Rows.Count <= 0)
                {
                    data.Base.SourceData1NOMHeaderSchemeTableAdapter.Fill(ds.Source_data_1NOM_header_scheme);
                }
                if (ds.Taxes_ved == null || ds.Taxes_ved.Rows.Count <= 0)
                {
                    data.Base.TaxesVedTableAdapter.Fill(ds.Taxes_ved); //заполняем таблицу налогов
                }
                if (ds.Usn == null || ds.Usn.Rows.Count <= 0)
                {
                    data.Base.UsnTableAdapter.Fill(ds.Usn); //заполняем таблицу налогов
                }
                if (ds.Envd == null || ds.Envd.Rows.Count <= 0)
                {
                    data.Base.EnvdTableAdapter.Fill(ds.Envd); //заполняем таблицу налогов
                }
                if (ds.Patent == null || ds.Patent.Rows.Count <= 0)
                {
                    data.Base.PatentTableAdapter.Fill(ds.Patent); //заполняем таблицу налогов
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
                //адаптеры
                //
                if (var.Ch1NM)
                {
                    cr.Data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter();
                }
                if (var.Ch1NOM)
                {
                    cr.Data.Base.SourceData1NOMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter();
                }
                if (var.Ch4NM)
                {
                    cr.Data.Base.SourceData4NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_4NMTableAdapter();
                }
                if (var.Ch5ENVD)
                {
                    cr.Data.Base.SourceData5ENVDTableAdapter = new base_nalogDataSetTableAdapters.Source_data_5ENVDTableAdapter();
                }
                if (var.Ch5USN)
                {
                    cr.Data.Base.SourceData5USNTableAdapter = new base_nalogDataSetTableAdapters.Source_data_5USNTableAdapter();
                }
                if (var.Ch1PATENT)
                {
                    cr.Data.Base.SourceData1PATENTTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1PATENTTableAdapter();
                }

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
                    //Если файлы 4-НМ не во всех папках
                    if (var.Ch4NM && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report4NM && !var.ChAllInOne)
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
                    if (var.ChAllInOne && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report4NM)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }
                    if (var.ChAllInOne && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1PATENT)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }
                    if (var.ChAllInOne && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report5ENVD)
                    {
                        if (ruleYears(chYear))
                        {
                            evenetOnChoiceReport();
                        }
                    }
                    if (var.ChAllInOne && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report5USN)
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
            public void CompareReportsTaxEea()
            {
                if (cr.Data.Base.CompareTaxEeaTableAdapter == null)
                {
                    cr.Data.Base.CompareTaxEeaTableAdapter = new base_nalogDataSetTableAdapters.Compare_tax_eeaTableAdapter();
                }
                if(cr.Data.Base.SourceData1NOMTableAdapter==null)
                {
                    cr.Data.Base.SourceData1NOMTableAdapter=new base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter();
                }
                if (cr.Data.Base.SourceData1NMTableAdapter == null)
                {
                    cr.Data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter();
                }
                if (ds.Subjects == null || ds.Subjects.Rows.Count <= 0)
                {
                    data.Base.SubjectsTableAdapter.Fill(ds.Subjects);
                }
                var.TableAdapterMethod = "Cp";
                if (var.IdSubject <= 0)
                {
                    int s = 0;
                    foreach (DataRow rowSubject in ds.Subjects.Rows)
                    {

                        AddCompareReportsTaxEea(impData.returnNullInt(rowSubject["id"]));
                        s++;
                        var.IndexFile = s;
                    }
                }
                else
                {
                    AddCompareReportsTaxEea(var.IdSubject);
                }
                var.IndexFile = ds.Subjects.Count;
                OnAddData();
                var.Status = " готово ";
            }
            public void SpreadOnBudgetsTax()
            {
                if (cr.Data.Base.SourceData1NMTableAdapter == null)
                {
                    cr.Data.Base.SourceData1NMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter();
                }
                if (ds.Subjects == null || ds.Subjects.Rows.Count <= 0)
                {
                    data.Base.SubjectsTableAdapter.Fill(ds.Subjects);
                }
                if (cr.Data.Base.CompareTaxBudgetTableAdapter == null)
                {
                    cr.Data.Base.CompareTaxBudgetTableAdapter = new base_nalogDataSetTableAdapters.Compare_tax_budgetTableAdapter();
                }
                var.TableAdapterMethod = "SpTax";
                if (var.IdSubject <= 0)
                {
                    int s = 0;
                    foreach (DataRow rowSubject in ds.Subjects.Rows)
                    {
                        AddSpreadOnBudgetsTax(impData.returnNullInt(rowSubject["id"]));
                        s++;
                        var.IndexFile = s;
                    }
                }
                else
                {
                    AddSpreadOnBudgetsTax(var.IdSubject);
                }
                var.IndexFile = ds.Subjects.Count;
                OnAddData();
                var.Status = " готово ";
            }
            public void SpreadOnBudgetsEea()
            {
                if (cr.Data.Base.SourceData1NOMTableAdapter == null)
                {
                    cr.Data.Base.SourceData1NOMTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter();
                }
                if (ds.Subjects == null || ds.Subjects.Rows.Count <= 0)
                {
                    data.Base.SubjectsTableAdapter.Fill(ds.Subjects);
                }
                if (cr.Data.Base.CompareEeaBudgetTableAdapter == null)
                {
                    cr.Data.Base.CompareEeaBudgetTableAdapter = new base_nalogDataSetTableAdapters.Compare_eea_budgetTableAdapter();
                }
                var.TableAdapterMethod = "SpEea";
                if (var.IdSubject <= 0)
                {
                    int s = 0;
                    foreach (DataRow rowSubject in ds.Subjects.Rows)
                    {
                        AddSpreadOnBudgetsEea(impData.returnNullInt(rowSubject["id"]));
                        s++;
                        var.IndexFile = s;
                    }
                }
                else
                {
                    AddSpreadOnBudgetsEea(var.IdSubject);
                }
                var.IndexFile = ds.Subjects.Count;
                OnAddData();
                var.Status = " готово ";
            }
            #endregion Глобальные
            //
            #region Не глобальные
            private void evenetOnChoiceReport()
            {
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM) var.TableAdapterMethod = "1NM";
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report4NM) var.TableAdapterMethod = "4NM";
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM) var.TableAdapterMethod = "1NOM";
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1PATENT) var.TableAdapterMethod = "1PATENT";
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report5ENVD) var.TableAdapterMethod = "5ENVD";
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report5USN) var.TableAdapterMethod = "5USN";
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
            private void AcceptMethodImport(int j, bool importOneList = false)
            {
                /*
                 * Метод, с помощью программа выбирает путь доваление данных (разные отчетности)
                 *
                 * */
                bool isListOk = true;
                if (CheckAllowableExcelSheet(impData.ClearStrExcelTable(sheet)) && var.Ch1NM ||
                    CheckAllowableExcelSheet(impData.ClearStrExcelTable(sheet)) && var.Ch4NM ||
                    CheckAllowableExcelSheet(impData.ClearStrExcelTable(sheet)) && var.Ch1NOM ||
                    CheckAllowableExcelSheet(impData.ClearStrExcelTable(sheet)) && var.Ch1PATENT ||
                    CheckAllowableExcelSheet(impData.ClearStrExcelTable(sheet)) && var.Ch5ENVD ||
                    CheckAllowableExcelSheet(impData.ClearStrExcelTable(sheet)) && var.Ch5USN ||
                    var.ChAllInOne)
                {
                    sheet = impData.ClearStrExcelTable(sheet);
                    string[] listTaxes = sheet.Split('-');
                    bool isListTaxes = false;
                    int t1 = 0;
                    int t2 = 0;
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
                #region settings
                if (var.InternalTable.Rows.Count > 0)
                {
                    var.IndexHeaderRow = defineIndexHeaderRow();
                }
                if (ucReportImport.chAllInOne.Checked && ucReportImport.chListSubjects.Checked)
                {
                    listOfSubjects = var.ListOfIdsSubjects;
                }
                if (ucReportImport.chAllInOne.Checked && ucReportImport.checkBoxListOfTaxes.Checked)
                {
                    listOfTaxes = var.ListOfIdsTaxes;
                }
                #endregion settings
                //
                #region 1NM
                #region 1NM_Simple
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
                    var.Ch1NM && !var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_1NM";
                    var.IndexHeaderRow = defineIndexHeaderRow();
                    //
                    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                    doTableAdapter(var.TableAdapterMethod);
                }
                #endregion 1NM_Simple
                #region 1NM_Forecast
                if ((cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast ||
                    cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast11) &&
                 var.ChForcast && var.Ch1NM && !var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_1NM";
                    var.IndexHeaderRow = defineIndexHeaderRow();
                    //
                    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                    doTableAdapter(var.TableAdapterMethod);
                }
                #endregion 1NM_Forecast
                #region 1NM_AllInOne
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
    var.Ch1NM && var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_1NM";
                    var.IndexHeaderRow = defineIndexHeaderRow();
                    //
                    AddIntervalTableData1NM_AllInOne(cr.ImportData.ImpDataFile.DataYear);
                    //doTableAdapter(var.TableAdapterMethod);
                    base_nalogDataSet.Source_data_1NMDataTable deleteRows = (base_nalogDataSet.Source_data_1NMDataTable)cr.Data.Base.Ds.Source_data_1NM.GetChanges(DataRowState.Deleted);
                    base_nalogDataSet.Source_data_1NMDataTable newRows = (base_nalogDataSet.Source_data_1NMDataTable)cr.Data.Base.Ds.Source_data_1NM.GetChanges(DataRowState.Added);
                    base_nalogDataSet.Source_data_1NMDataTable modifiedRows = (base_nalogDataSet.Source_data_1NMDataTable)cr.Data.Base.Ds.Source_data_1NM.GetChanges(DataRowState.Modified);
                    if (deleteRows != null || newRows != null || modifiedRows != null)
                    {
                        doTableAdapter(var.TableAdapterMethod);
                        ds.AcceptChanges();
                    }
                }
                #endregion 1NM_AllInOne
                #endregion 1NM
                #region 4NM
                #region 4NM_Simple
                //if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
                //    var.Ch1NM && !var.ChAllInOne)
                //{
                //    var.SourceTableName = "Source_data_1NM";
                //    var.IndexHeaderRow = defineIndexHeaderRow();
                //    //
                //    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                //    doTableAdapter(var.TableAdapterMethod);
                //}
                #endregion 4NM_Simple
                #region 4NM_Forecast
                //if ((cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast ||
                //    cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast11) &&
                // var.ChForcast && var.Ch1NM && !var.ChAllInOne)
                //{
                //    var.SourceTableName = "Source_data_1NM";
                //    var.IndexHeaderRow = defineIndexHeaderRow();
                //    //
                //    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                //    doTableAdapter(var.TableAdapterMethod);
                //}
                #endregion 4NM_Forecast
                #region 1NM_AllInOne
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report4NM &&
    var.Ch4NM && var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_4NM";
                    var.IndexHeaderRow = defineIndexHeaderRow();
                    //
                    AddIntervalTableData4NM_AllInOne(cr.ImportData.ImpDataFile.DataYear);
                    doTableAdapter(var.TableAdapterMethod);
                }
                #endregion 4NM_AllInOne
                #endregion 4NM
                //
                #region 1NOM
                #region 1NOM_Simple
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM &&
                    var.Ch1NOM && !var.ChAllInOne)
                {
                    var.IndexHeaderRow = defineIndexHeaderRow();
                    AddIntervalTableData1NOM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                    doTableAdapter(var.TableAdapterMethod);
                }
                #endregion 1NOM_Simple
                #region 1NOM_AllInOne
                if (var.ChAllInOne && cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOM)
                {
                    var.IndexCol = 1;
                    if (sheet.Length < 5)
                    {
                        if (ucReportImport.chAllInOne.Checked && ucReportImport.chListSubjects.Checked)
                        {
                            allInOne_OnlyList = true;
                        }
                        var.IndexHeaderRow = defineIndexHeaderRow1NOM_AllInOne();
                        AddIntervalTableData1NOM_AllInOne(cr.ImportData.ImpDataFile.DataYear);
                        doTableAdapter(var.TableAdapterMethod);
                    }
                }
                #endregion 1NOM_AllInOne
                #endregion 1NOM
                #region 1PATENT
                #region 1PATENT_Simple
                //if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
                //    var.Ch1NM && !var.ChAllInOne)
                //{
                //    var.SourceTableName = "Source_data_1NM";
                //    var.IndexHeaderRow = defineIndexHeaderRow();
                //    //
                //    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                //    doTableAdapter(var.TableAdapterMethod);
                //}
                #endregion 1PATENT_Simple
                #region 1PATENT_Forecast
                //if ((cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast ||
                //    cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast11) &&
                // var.ChForcast && var.Ch1NM && !var.ChAllInOne)
                //{
                //    var.SourceTableName = "Source_data_1NM";
                //    var.IndexHeaderRow = defineIndexHeaderRow();
                //    //
                //    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                //    doTableAdapter(var.TableAdapterMethod);
                //}
                #endregion 1PATENT_Forecast
                #region 1PATENT_AllInOne
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1PATENT &&
    var.Ch1PATENT && var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_1PATENT";
                    var.IndexHeaderRow = defineIndexHeaderRowA();
                    //
                    AddIntervalTableData1PATENT_AllInOne(cr.ImportData.ImpDataFile.DataYear);
                    doTableAdapter(var.TableAdapterMethod);
                }
                #endregion 1PATENT_AllInOne
                #endregion 1PATENT
                #region 5ENVD
                #region 5ENVD_Simple
                //if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
                //    var.Ch1NM && !var.ChAllInOne)
                //{
                //    var.SourceTableName = "Source_data_1NM";
                //    var.IndexHeaderRow = defineIndexHeaderRow();
                //    //
                //    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                //    doTableAdapter(var.TableAdapterMethod);
                //}
                #endregion 5ENVD_Simple
                #region 5ENVD_Forecast
                //if ((cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast ||
                //    cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast11) &&
                // var.ChForcast && var.Ch1NM && !var.ChAllInOne)
                //{
                //    var.SourceTableName = "Source_data_1NM";
                //    var.IndexHeaderRow = defineIndexHeaderRow();
                //    //
                //    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                //    doTableAdapter(var.TableAdapterMethod);
                //}
                #endregion 5ENVD_Forecast
                #region 5ENVD_AllInOne
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report5ENVD &&
    var.Ch5ENVD && var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_5ENVD";
                    var.IndexHeaderRow = defineIndexHeaderRowA();
                    //
                    AddIntervalTableData5ENVD_AllInOne(cr.ImportData.ImpDataFile.DataYear);
                    doTableAdapter(var.TableAdapterMethod);
                }
                #endregion 5ENVD_AllInOne
                #endregion 5ENVD
                #region 5USN
                #region 5USN_Simple
                //if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NM &&
                //    var.Ch1NM && !var.ChAllInOne)
                //{
                //    var.SourceTableName = "Source_data_1NM";
                //    var.IndexHeaderRow = defineIndexHeaderRow();
                //    //
                //    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                //    doTableAdapter(var.TableAdapterMethod);
                //}
                #endregion 5USN_Simple
                #region 5USN_Forecast
                //if ((cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast ||
                //    cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast11) &&
                // var.ChForcast && var.Ch1NM && !var.ChAllInOne)
                //{
                //    var.SourceTableName = "Source_data_1NM";
                //    var.IndexHeaderRow = defineIndexHeaderRow();
                //    //
                //    AddIntervalTableData1NM(cr.ImportData.ImpDataFile.DataYear, cr.ImportData.ImpDataFile.IdSubject);
                //    doTableAdapter(var.TableAdapterMethod);
                //}
                #endregion 5USN_Forecast
                #region 5USN_AllInOne
                if (cr.ImportData.ImpDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report5USN &&
    var.Ch5USN && var.ChAllInOne)
                {
                    var.SourceTableName = "Source_data_5USN";
                    var.IndexHeaderRow = defineIndexHeaderRowA();
                    //
                    AddIntervalTableData5USN_AllInOne(cr.ImportData.ImpDataFile.DataYear);
                    doTableAdapter(var.TableAdapterMethod);
                }
                #endregion 5USN_AllInOne
                #endregion 5USN
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
                    #region 4NM
                    case "4NM":
                        {

                            base_nalogDataSet.Source_data_4NMDataTable deleteRows = (base_nalogDataSet.Source_data_4NMDataTable)cr.Data.Base.Ds.Source_data_4NM.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Source_data_4NMDataTable newRows = (base_nalogDataSet.Source_data_4NMDataTable)cr.Data.Base.Ds.Source_data_4NM.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Source_data_4NMDataTable modifiedRows = (base_nalogDataSet.Source_data_4NMDataTable)cr.Data.Base.Ds.Source_data_4NM.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.SourceData4NMTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.SourceData4NMTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.SourceData4NMTableAdapter.Update(modifiedRows);
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
                            cr.Data.Base.Ds.Source_data_4NM.Clear();
                            //data.Base.SourceData1NMTableAdapter.Fill(ds.Source_data_1NM);
                            break;
                        }
                    #endregion 4NM
                    #region 5ENVD
                    case "5ENVD":
                        {

                            base_nalogDataSet.Source_data_5ENVDDataTable deleteRows = (base_nalogDataSet.Source_data_5ENVDDataTable)cr.Data.Base.Ds.Source_data_5ENVD.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Source_data_5ENVDDataTable newRows = (base_nalogDataSet.Source_data_5ENVDDataTable)cr.Data.Base.Ds.Source_data_5ENVD.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Source_data_5ENVDDataTable modifiedRows = (base_nalogDataSet.Source_data_5ENVDDataTable)cr.Data.Base.Ds.Source_data_5ENVD.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.SourceData5ENVDTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.SourceData5ENVDTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.SourceData5ENVDTableAdapter.Update(modifiedRows);
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
                            cr.Data.Base.Ds.Source_data_5ENVD.Clear();
                            //data.Base.SourceData1NMTableAdapter.Fill(ds.Source_data_1NM);
                            break;
                        }
                    #endregion 5ENVD
                    #region 5USN
                    case "5USN":
                        {

                            base_nalogDataSet.Source_data_5USNDataTable deleteRows = (base_nalogDataSet.Source_data_5USNDataTable)cr.Data.Base.Ds.Source_data_5USN.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Source_data_5USNDataTable newRows = (base_nalogDataSet.Source_data_5USNDataTable)cr.Data.Base.Ds.Source_data_5USN.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Source_data_5USNDataTable modifiedRows = (base_nalogDataSet.Source_data_5USNDataTable)cr.Data.Base.Ds.Source_data_5USN.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.SourceData5USNTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.SourceData5USNTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.SourceData5USNTableAdapter.Update(modifiedRows);
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
                            cr.Data.Base.Ds.Source_data_5USN.Clear();
                            //data.Base.SourceData1NMTableAdapter.Fill(ds.Source_data_1NM);
                            break;
                        }
                    #endregion 5USN
                    #region 1PATENT
                    case "1PATENT":
                        {

                            base_nalogDataSet.Source_data_1PATENTDataTable deleteRows = (base_nalogDataSet.Source_data_1PATENTDataTable)cr.Data.Base.Ds.Source_data_1PATENT.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Source_data_1PATENTDataTable newRows = (base_nalogDataSet.Source_data_1PATENTDataTable)cr.Data.Base.Ds.Source_data_1PATENT.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Source_data_1PATENTDataTable modifiedRows = (base_nalogDataSet.Source_data_1PATENTDataTable)cr.Data.Base.Ds.Source_data_1PATENT.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.SourceData1PATENTTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.SourceData1PATENTTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.SourceData1PATENTTableAdapter.Update(modifiedRows);
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
                            cr.Data.Base.Ds.Source_data_1PATENT.Clear();
                            //data.Base.SourceData1NMTableAdapter.Fill(ds.Source_data_1NM);
                            break;
                        }
                    #endregion 1PATENT
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
                    #region SpTax
                    case "SpTax":
                        {

                            base_nalogDataSet.Compare_tax_budgetDataTable deleteRows = (base_nalogDataSet.Compare_tax_budgetDataTable)cr.Data.Base.Ds.Compare_tax_budget.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Compare_tax_budgetDataTable newRows = (base_nalogDataSet.Compare_tax_budgetDataTable)cr.Data.Base.Ds.Compare_tax_budget.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Compare_tax_budgetDataTable modifiedRows = (base_nalogDataSet.Compare_tax_budgetDataTable)cr.Data.Base.Ds.Compare_tax_budget.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.CompareTaxBudgetTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.CompareTaxBudgetTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.CompareTaxBudgetTableAdapter.Update(modifiedRows);
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
                            cr.Data.Base.Ds.Compare_tax_budget.Clear();
                            break;
                        }
                    #endregion SpTax
                    #region SpEea
                    case "SpEea":
                        {

                            base_nalogDataSet.Compare_eea_budgetDataTable deleteRows = (base_nalogDataSet.Compare_eea_budgetDataTable)cr.Data.Base.Ds.Compare_eea_budget.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.Compare_eea_budgetDataTable newRows = (base_nalogDataSet.Compare_eea_budgetDataTable)cr.Data.Base.Ds.Compare_eea_budget.GetChanges(DataRowState.Added);
                            base_nalogDataSet.Compare_eea_budgetDataTable modifiedRows = (base_nalogDataSet.Compare_eea_budgetDataTable)cr.Data.Base.Ds.Compare_eea_budget.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.CompareEeaBudgetTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.CompareEeaBudgetTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.CompareEeaBudgetTableAdapter.Update(modifiedRows);
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
                            cr.Data.Base.Ds.Compare_eea_budget.Clear();
                            break;
                        }
                    #endregion SpEea
                    #region Time
                    case "Time":
                        {

                            base_nalogDataSet.TimeDataTable deleteRows = (base_nalogDataSet.TimeDataTable)cr.Data.Base.Ds.Time.GetChanges(DataRowState.Deleted);
                            base_nalogDataSet.TimeDataTable newRows = (base_nalogDataSet.TimeDataTable)cr.Data.Base.Ds.Time.GetChanges(DataRowState.Added);
                            base_nalogDataSet.TimeDataTable modifiedRows = (base_nalogDataSet.TimeDataTable)cr.Data.Base.Ds.Time.GetChanges(DataRowState.Modified);
                            //
                            try
                            {
                                if (deleteRows != null)
                                {
                                    cr.Data.Base.TimeTableAdapter.Update(deleteRows);
                                }
                                if (newRows != null)
                                {
                                    cr.Data.Base.TimeTableAdapter.Update(newRows);
                                }
                                if (modifiedRows != null)
                                {
                                    cr.Data.Base.TimeTableAdapter.Update(modifiedRows);
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
                            //cr.Data.Base.Ds.Time.Clear();
                            break;
                        }
                    #endregion Time
                }
            }
            private void AddIntervalTableData1NM(int year, int subj)
            {
                cr.SWatch.Stop();
                cr.ProcessingEventsReadFile = cr.SWatch.ElapsedMilliseconds;
                cr.SWatch.Reset();
                cr.SWatch.Start();
                //
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
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
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j], 2));
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
                                int checkedImportedData1NM = 0;
                                if (cr.ImportData.ImpDataFile.ForcastInterval < 12)
                                {
                                    checkedImportedData1NM = checkImportedData1NM(subj, codeTax, year, i, j + 2, "", cr.ImportData.ImpDataFile.ParentIdSubject);
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
                                        if (cr.ImportData.ImpDataFile.ParentIdSubject != 0)
                                        {
                                            NMRow.id_subject = cr.ImportData.ImpDataFile.ParentIdSubject;
                                            NMRow.cid = subj;
                                        }
                                        else
                                        {
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
                                                                break;
                                                            }
                                                        #endregion 1
                                                        #region 2
                                                        case 2:
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

                                                                break;

                                                            }
                                                        #endregion 2
                                                        #region 3
                                                        case 3:
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
            private void AddIntervalTableData1NOM(int year, int subj)
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
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                data.Base.SourceData1NOMTableAdapter.Fill(data.Base.Ds.Source_data_1NOM);
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                string code = "";
                int indexCol = 0;
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
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j], 2));
                                codeTax = Convert.ToInt32(impData.returnNullInt(var.InternalTable.Rows[i][j]));//проверка на нулевое значение
                                count1++;
                            }
                            catch (System.Exception err)
                            {
                                num = 0;
                                codeTax = 0;
                            }
                            string nameTax = "";

                            if (codeTax != 0 && j - 1 >= 0 && j - 2 >= 0)
                            {
                                code = impData.returnReplaceString(var.InternalTable.Rows[i][j - 1].ToString(), new string[] { "\n", "\r", " " }); nameTax = impData.returnReplaceString(var.InternalTable.Rows[i][j - 2].ToString(), new string[] { "\n", "\r", " " });
                            }

                            if (codeTax != 0 && existNeedTax1NOM(codeTax, code, nameTax) &&
                                subj > 0 &&
                                year > 0 &&
                                codeTax > 0)
                            {
                                if (codeChanged) codeTax = newCode;
                                int iiii = 0;
                                count2++;
                                int findFirstValueCol = 0;
                                int findFirstValueColIndex = 0;
                                for (int c = 0; c < var.InternalTable.Columns.Count; c++)
                                {
                                    int index1 = defineTrueCol1NOM(c);
                                    if (index1 == 2)
                                    {
                                        findFirstValueCol = index1;
                                        findFirstValueColIndex = c;
                                        break;
                                    }
                                }
                                int checkedImprotedData1NOM = checkImportedData1NOM(subj, codeTax, year, i, findFirstValueColIndex, findFirstValueCol, cr.ImportData.ImpDataFile.ParentIdSubject);
                                #region заносим основные данные
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
                                        //
                                        if (ucReportImport.txtTarget.Text.Length > 0)
                                        {
                                            NOMRow.comments = ucReportImport.txtTarget.Text;
                                        }
                                        if (ucReportImport.chAllInOne.Checked)
                                        {
                                            NOMRow.comments = "Источник: сводная таблица ФНС";
                                        }
                                        if (checkedImprotedData1NOM == 0)
                                        {
                                            ds.Source_data_1NOM.AddSource_data_1NOMRow(NOMRow);
                                        }
                                        OnReadInternalFile();
                                    }
                                }
                                #endregion заносим основные данные
                                for (int c = 0; c < var.InternalTable.Columns.Count; c++)
                                {
                                    if (impData.returnNullInt(var.InternalTable.Rows[var.IndexHeaderRow][c]) > 0)
                                    {
                                        indexCol = defineTrueCol1NOM(c);
                                        if (indexCol > 0)
                                        {
                                            if (checkedImprotedData1NOM != 0 && checkedImprotedData1NOM != 3)
                                            {
                                                checkedImprotedData1NOM = checkImportedData1NOM(subj, codeTax, year, i, indexCol, 2, cr.ImportData.ImpDataFile.ParentIdSubject);
                                            }
                                            if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                    codeTax.ToString().Length == 4)
                                            {
                                                if (checkedImprotedData1NOM == 0 || checkedImprotedData1NOM == 1)
                                                {
                                                    OnReadInternalFile();
                                                    //
                                                    NOMRow[indexCol.ToString()] = impData.returnNullInt(var.InternalTable.Rows[i][c]);
                                                }
                                            }
                                        }
                                    }
                                    iiii++;
                                    if (var.InternalTable.Rows[i][j] == System.DBNull.Value &&
                                        codeTax.ToString().Length != 4)
                                    {
                                        break;
                                    }
                                }

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
            private void AddIntervalTableData1NOM_AllInOne(int year)
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
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                if (!var.FilledTable1NOM && data.Base.Ds.Source_data_1NOM != null)
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
                string code = "";
                int indexCol = 0;
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
                            bool isAllowIdSubject = true;
                            if (var.AddByListOfSubject)
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
                            bool allow = true;
                            if (var.AddByListOfSubject) allow = isListOfSubject;
                            if (var.IdSubject > 0)
                            {
                                if (subj != var.IdSubject)
                                {
                                    isAllowIdSubject = false;
                                }
                                else
                                {
                                    isAllowIdSubject = true;
                                }
                            }
                            if (j - 1 >= 0) code = var.InternalTable.Rows[i][j - 1].ToString();

                            if (codeTax != 0 && existNeedTax1NOM(codeTax, code) &&
                                subj > 0 &&
                                year > 0 &&
                                codeTax > 0 &&
                                allow &&
                                isAllowIdSubject)
                            {
                                count2++;
                                int iiii = 0;
                                int findFirstValueCol = 0;
                                int findFirstValueColIndex = 0;
                                for (int c = 0; c < var.InternalTable.Columns.Count; c++)
                                {
                                    int index1 = defineTrueCol1NOM(c);
                                    if (index1 == 1)
                                    {
                                        findFirstValueCol = index1;
                                        findFirstValueColIndex = c;
                                        break;
                                    }
                                }
                                if (codeChanged) codeTax = newCode;
                                int checkedImprotedData1NOM = checkImportedData1NOM(subj, codeTax, year, i, j, 2, cr.ImportData.ImpDataFile.ParentIdSubject);

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
                                    }
                                }
                                for (int c = 0; c < var.InternalTable.Columns.Count; c++)
                                {
                                    if (var.InternalTable.Rows[var.IndexHeaderRow][c].ToString().Length > 0)
                                    {
                                        indexCol = defineTrueCol1NOM(c);
                                        if (indexCol > 0)
                                        {
                                            if (checkedImprotedData1NOM != 0 && checkedImprotedData1NOM != 3)
                                            {
                                                checkedImprotedData1NOM = checkImportedData1NOM(subj, codeTax, year, i, indexCol, 2, cr.ImportData.ImpDataFile.ParentIdSubject);
                                            }
                                            if (var.InternalTable.Rows[i][c] != System.DBNull.Value &&
                                    codeTax.ToString().Length == 4)
                                            {
                                                if (checkedImprotedData1NOM == 0 || checkedImprotedData1NOM == 1)
                                                {
                                                    OnReadInternalFile();
                                                    //
                                                    NOMRow[indexCol.ToString()] = impData.returnNullInt(var.InternalTable.Rows[i][c]);
                                                    //doTableAdapter(
                                                }
                                            }
                                        }
                                    }
                                    iiii++;
                                    /*if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                        codeTax.ToString().Length == 4)
                                    {
                                        break;
                                    }*/
                                }
                                if (checkedImprotedData1NOM == 0)
                                {
                                    ds.Source_data_1NOM.AddSource_data_1NOMRow(NOMRow);
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
            private void AddIntervalTableData1NM_AllInOne(int year)
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
                        string strIndex = "";
                        try
                        {
                            strIndex = var.InternalTable.Rows[r][0].ToString();
                        }
                        catch (System.Exception ex)
                        {
                            strIndex = "";
                        }
                        if (strIndex != "")
                        {
                            if (strIndex == "A" || strIndex == "А") rowIndexCodeTax = r;
                        }
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
                        if (var.IdSubject > 0)
                        {
                            if (subj != var.IdSubject)
                            {
                                isAllowIdSubject = false;
                            }
                            else
                            {
                                isAllowIdSubject = true;
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
                                if (codeTax > 0 && subj > 0 && year > 0)
                                {
                                    if (isColumnSourceTable(arrCodeTax[0, 1]))
                                    {
                                        checkedImprotedData = checkImportedData1NM(subj, codeTax, year, i, impData.returnNullInt(arrCodeTax[0, 2]), arrCodeTax[0, 1].ToString(), pid);
                                    }
                                    if (impData.returnNullBool(arrCodeTax[0, 3]) && existNeedTax1NM(codeTax))
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
                //doTableAdapter(var.TableAdapterMethod);
                //ds.AcceptChanges();
                #endregion рассчитываем налоговый доход
                #endregion сканируем все строки


                var.IndexRecord = var.CountRecords;
                OnAddData();

                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
                cr.SWatch.Reset();
            }
            private void AddIntervalTableData4NM_AllInOne(int year)
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
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                if (!var.FilledTable4NM && data.Base.Ds.Source_data_4NM != null)
                {
                    data.Base.SourceData4NMTableAdapter.Fill(data.Base.Ds.Source_data_4NM);
                    var.FilledTable4NM = true;
                }
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                int subj = 0;
                string strSubject = "";
                string code = "";
                int indexCol = 0;
                int startRowA = 0;
                int startColA_1 = 0;
                OnReadFile();

                if (var.CountSection < 75)
                {
                    #region CountSection
                    for (int i = 0; i < var.CountRecords; i++)
                    {
                        #region CountRecords
                        var.IndexRecord = i + 1;
                        for (int j = 0; j < var.IndexCol; j++)
                        {
                            //#region var.IndexCol
                            //try
                            //{
                            try
                            {
                                #region indexes.Add(sheet_code_tax)
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
                                #endregion indexes.Add(sheet_code_tax)
                            }
                            catch (System.Exception err)
                            {
                                num = 0;
                                codeTax = 0;
                            }
                            //
                            if (var.InternalTable.Rows[i][j].ToString() == "A" ||
                                var.InternalTable.Rows[i][j].ToString() == "А")
                            {
                                startRowA = i;
                                startColA_1 = j + 1;
                            }
                            //
                            bool isListOfSubject = false;
                            bool isAllowIdSubject = true;
                            if (var.AddByListOfSubject)
                            {
                                #region var.AddByListOfSubject
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
                                #endregion var.AddByListOfSubject
                            }
                            bool allow = true;
                            if (var.AddByListOfSubject) allow = isListOfSubject;
                            if (var.IdSubject > 0)
                            {
                                #region var.IdSubject
                                if (subj != var.IdSubject)
                                {
                                    isAllowIdSubject = false;
                                }
                                else
                                {
                                    isAllowIdSubject = true;
                                }
                                #endregion var.IdSubject
                            }
                            if (j - 1 >= 0) code = var.InternalTable.Rows[i][j - 1].ToString();
                            
                            if (codeTax != 0 && existNeedTax4NM(codeTax) &&
                                subj > 0 &&
                                year > 0 &&
                                codeTax > 0 &&
                                allow &&
                                isAllowIdSubject &&
                                startRowA > 0 &&
                                startColA_1 > 0)
                            {
                                //#region codeTax != 0
                                count2++;
                                int iiii = 0;
                                j = var.IndexCol;

                                /*if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                    codeTax.ToString().Length == 4)
                                {
                                    break;
                                }*/
                                //#endregion var.InternalTable.Columns.Count

                                int checkedImprotedData4NM = checkImportedData4NM(subj, codeTax, year, i, j, 2, cr.ImportData.ImpDataFile.ParentIdSubject);

                                if (var.InternalTable.Rows[i][j] != System.DBNull.Value &&
                                    codeTax.ToString().Length == 4)
                                {
                                    #region var.InternalTable.Rows[i][c]
                                    if (checkedImprotedData4NM == 0)
                                    {
                                        var.Status = " добавляем ";
                                        NM4Row = ds.Source_data_4NM.NewSource_data_4NMRow();
                                    }
                                    if (checkedImprotedData4NM == 1)
                                    {
                                        var.Status = " изменяем ";
                                        NM4Row = ds.Source_data_4NM.FindByid(var.CheckedId);
                                    }
                                    if (checkedImprotedData4NM == 2)
                                    {
                                        var.Status = " удаляем ";
                                        ds.Source_data_4NM.FindByid(var.CheckedId).Delete();
                                    }
                                    if (checkedImprotedData4NM == 3)
                                    {
                                        var.Status = " проверено ";
                                    }
                                    if (checkedImprotedData4NM == 0 || checkedImprotedData4NM == 1)
                                    {
                                        count3++;
                                        NM4Row.id_debt = codeTax;
                                        NM4Row.pid = impData.defineParentIdSubject(subj);
                                        if (NM4Row.pid > 0)
                                        {
                                            NM4Row.id_subject = NM4Row.pid;
                                            NM4Row.cid = subj;
                                        }
                                        else
                                        {
                                            NM4Row.id_subject = subj;
                                        }
                                        NM4Row.year_data = year;
                                        OnReadInternalFile();
                                    }
                                    #endregion var.InternalTable.Rows[i][c]
                                }

                                for (int c = startColA_1; c < var.InternalTable.Columns.Count; c++)
                                {
                                    //#region var.InternalTable.Columns.Count
                                    if (var.InternalTable.Rows[i][c].ToString().Length > 0)
                                    {
                                        indexCol = c;
                                        if (startRowA > 0)
                                        {
                                            if (checkedImprotedData4NM != 0 && checkedImprotedData4NM != 3)
                                            {
                                                checkedImprotedData4NM = checkImportedData4NM(subj, codeTax, year, i, indexCol, 2, cr.ImportData.ImpDataFile.ParentIdSubject);
                                            }
                                            if (var.InternalTable.Rows[i][c] != System.DBNull.Value &&
                                    codeTax.ToString().Length == 4)
                                            {
                                                if (checkedImprotedData4NM == 0 || checkedImprotedData4NM == 1)
                                                {
                                                    OnReadInternalFile();
                                                    //
                                                    NM4Row[indexCol.ToString()] = impData.returnNullInt(var.InternalTable.Rows[i][c]);
                                                    //doTableAdapter(
                                                }
                                            }
                                        }

                                    }
                                    iiii++;
                                }

                                if (checkedImprotedData4NM == 0)
                                {
                                    try
                                    {
                                        ds.Source_data_4NM.AddSource_data_4NMRow(NM4Row);
                                    }
                                    catch (System.Exception e)
                                    {
                                    }

                                }
                            }

                            //#endregion codeTax != 0

                            lastnum = num;
                            //#endregion var.IndexCol
                        }
                                #endregion CountRecords
                    }
                            #endregion CountSection
                }
                var.IndexRecord = var.CountRecords;
                OnAddData();

                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
                cr.SWatch.Reset();
            }
            private void AddIntervalTableData5USN_AllInOne(int year)
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
                        string strIndex = "";
                        try
                        {
                            strIndex = var.InternalTable.Rows[r][0].ToString();
                        }
                        catch (System.Exception ex)
                        {
                            strIndex = "";
                        }
                        if (strIndex != "")
                        {
                            if (strIndex == "A" || strIndex == "А") rowIndexCodeTax = r;
                        }
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

                    need = existNeedTax5USN(impData.returnNullInt(arrCodeTax[0]), arrCodeTax[0]);
                    if (var.IsListOfTaxes)
                    {
                        need = existNeedTax5USN(impData.returnNullInt(arrCodeTax[0]), arrCodeTax[0]);
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
                        if (var.IdSubject > 0)
                        {
                            if (subj != var.IdSubject)
                            {
                                isAllowIdSubject = false;
                            }
                            else
                            {
                                isAllowIdSubject = true;
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
                                if (codeChanged) codeTax = newCode;
                                //
                                int pid = impData.defineParentIdSubject(subj);
                                checkedImprotedData = 3;
                                if (codeTax > 0 && subj > 0 && year > 0)
                                {
                                    if (isColumnSourceTable(arrCodeTax[0, 1]))
                                    {
                                        checkedImprotedData = checkImportedData5USN(subj, codeTax, year, i, impData.returnNullInt(arrCodeTax[0, 2]), arrCodeTax[0, 1].ToString(), pid);
                                    }
                                    if (impData.returnNullBool(arrCodeTax[0, 3]) && existNeedTax5USN(codeTax))
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
                                                    row["id_usn"] = codeTax;
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

                        row["TI"] = impData.returnNullInt(row["1"]);

                    }
                }
                //doTableAdapter(var.TableAdapterMethod);
                //ds.AcceptChanges();
                #endregion рассчитываем налоговый доход
                #endregion сканируем все строки


                var.IndexRecord = var.CountRecords;
                OnAddData();

                cr.SWatch.Stop();
                cr.ProcessingEventAddToBase.Add(cr.SWatch.ElapsedMilliseconds);
                cr.SWatch.Reset();
            }
            private void AddIntervalTableData5ENVD_AllInOne(int year)
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
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                int subj = 0;
                string strSubject = "";
                string code = "";
                int indexCol = 0;
                string sheet_code_tax="";
                OnReadFile();

                if (var.CountSection < 75)
                {
                    for (int i = var.IndexHeaderRow+1; i < var.CountRecords; i++)
                    {

                        var.IndexRecord = i + 1;
                        for (int j = 0; j < var.IndexCol; j++)
                        {
                            //try
                            //{
                            try
                            {
                                #region считывание параметров
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j], 2));
                                /* Убираем из строки ненужные символы для считывания
                                 * */
                                sheet_code_tax = sheet;
                                code = "";
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
                                #endregion считывание параметров
                            }
                            catch (System.Exception err)
                            {
                                num = 0;
                                codeTax = 0;
                            }
                            #region проверка листа субъекта
                            bool isListOfSubject = false;
                            bool isAllowIdSubject = true;
                            if (var.AddByListOfSubject)
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
                            bool allow = true;
                            if (var.AddByListOfSubject) allow = isListOfSubject;
                            #endregion проверка листа субъекта
                            #region проверка нулевого субъекта
                            if (var.IdSubject > 0)
                            {
                                if (subj != var.IdSubject)
                                {
                                    isAllowIdSubject = false;
                                }
                                else
                                {
                                    isAllowIdSubject = true;
                                }
                            }
                            #endregion проверка нулевого субъекта
                            if (j - 1 >= 0)
                            {
                                code = var.InternalTable.Columns[j - 1].ToString();
                                //if (code.Length <= 0) code = sheet_code_tax;
                            }

                            if (codeTax != 0 && existNeedTax5ENVD(codeTax) &&
                                subj > 0 &&
                                year > 0 &&
                                codeTax > 0 &&
                                allow &&
                                isAllowIdSubject)
                            {
                                count2++;
                                int iiii = 0;
                                int findFirstValueCol = 0;
                                int findFirstValueColIndex = 0;
                                for (int c = 0; c < var.InternalTable.Columns.Count; c++)
                                {
                                    int index1 = defineTrueCol5ENVD(c);
                                    if (index1 == 1)
                                    {
                                        findFirstValueCol = index1;
                                        findFirstValueColIndex = c;
                                        break;
                                    }
                                }
                                if (codeChanged) codeTax = newCode;
                                int status = checkImportedData5ENVD(subj, codeTax, year, i, findFirstValueColIndex, findFirstValueCol, "", cr.ImportData.ImpDataFile.ParentIdSubject);
                                #region добавляем/изменяем
                                if (!DBNull.Value.Equals(var.InternalTable.Rows[i][j]))
                                {
                                    if (status == 0)
                                    {
                                        var.Status = " добавляем ";
                                        ENVD5Row = ds.Source_data_5ENVD.NewSource_data_5ENVDRow();
                                    }
                                    if (status == 1)
                                    {
                                        var.Status = " изменяем ";
                                        ENVD5Row = ds.Source_data_5ENVD.FindByid(var.CheckedId);
                                    }
                                    if (status == 2)
                                    {
                                        var.Status = " удаляем ";
                                        ds.Source_data_5ENVD.FindByid(var.CheckedId).Delete();
                                    }
                                    if (status == 3)
                                    {
                                        var.Status = " проверено ";
                                    }
                                    if (status == 0 || status == 1)
                                    {
                                        count3++;
                                        numColTax = j;
                                        ENVD5Row.id_envd = codeTax;
                                        ENVD5Row.pid = impData.defineParentIdSubject(subj);
                                        if (ENVD5Row.pid > 0)
                                        {
                                            ENVD5Row.id_subject = ENVD5Row.pid;
                                            ENVD5Row.cid = subj;
                                        }
                                        else
                                        {
                                            ENVD5Row.id_subject = subj;
                                        }
                                        ENVD5Row.year_data = year;
                                        OnReadInternalFile();
                                    }
                                    for (int c = var.IndexHeaderCol; c < var.InternalTable.Columns.Count; c++)
                                    {
                                        if (var.InternalTable.Rows[var.IndexHeaderRow][c].ToString().Length > 0)
                                        {
                                            indexCol = defineTrueCol5ENVD(c);
                                            if (indexCol > 0)
                                            {
                                                if (status != 0 && status != 3)
                                                {
                                                    status = checkImportedData5ENVD(subj, codeTax, year, i, findFirstValueColIndex, findFirstValueCol, "", cr.ImportData.ImpDataFile.ParentIdSubject);
                                                }
                                                if (status == 2)
                                                {
                                                    var.Status = " удаляем ";
                                                    ds.Source_data_5ENVD.FindByid(var.CheckedId).Delete();
                                                }
                                                if (!DBNull.Value.Equals(var.InternalTable.Rows[i][c]))
                                                {
                                                    if (status == 0 || status == 1)
                                                    {
                                                        OnReadInternalFile();
                                                        //
                                                        ENVD5Row[indexCol.ToString()] = impData.returnNullInt(var.InternalTable.Rows[i][c + 1]);
                                                        //doTableAdapter(
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (status == 0)
                                    {
                                        ds.Source_data_5ENVD.AddSource_data_5ENVDRow(ENVD5Row);
                                    }
                                }
                                #endregion добавляем/изменяем

                                iiii++;
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
            private void AddIntervalTableData1PATENT_AllInOne(int year)
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
                var.CountRecords = var.InternalTable.Rows.Count; //считаем кол-во записей
                float num = 0;
                float lastnum = 0;
                int numColTax = 0;
                int codeTax = 0;
                int subj = 0;
                string strSubject = "";
                string code = "";
                int indexCol = 0;
                string sheet_code_tax = "";
                OnReadFile();

                if (var.CountSection < 75)
                {
                    for (int i = var.IndexHeaderRow + 1; i < var.CountRecords; i++)
                    {

                        var.IndexRecord = i + 1;
                        for (int j = 0; j < var.IndexCol; j++)
                        {
                            //try
                            //{
                            try
                            {
                                #region считывание параметров
                                num = Convert.ToSingle(impData.returnNullFloat(var.InternalTable.Rows[i][j], 2));
                                /* Убираем из строки ненужные символы для считывания
                                 * */
                                sheet_code_tax = sheet;
                                code = "";
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
                                #endregion считывание параметров
                            }
                            catch (System.Exception err)
                            {
                                num = 0;
                                codeTax = 0;
                            }
                            #region проверка листа субъекта
                            bool isListOfSubject = false;
                            bool isAllowIdSubject = true;
                            if (var.AddByListOfSubject)
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
                            bool allow = true;
                            if (var.AddByListOfSubject) allow = isListOfSubject;
                            #endregion проверка листа субъекта
                            #region проверка нулевого субъекта
                            if (var.IdSubject > 0)
                            {
                                if (subj != var.IdSubject)
                                {
                                    isAllowIdSubject = false;
                                }
                                else
                                {
                                    isAllowIdSubject = true;
                                }
                            }
                            #endregion проверка нулевого субъекта
                            if (j - 1 >= 0)
                            {
                                code = var.InternalTable.Columns[j - 1].ToString();
                                //if (code.Length <= 0) code = sheet_code_tax;
                            }

                            if (codeTax != 0 && existNeedTax1PATENT(codeTax) &&
                                subj > 0 &&
                                year > 0 &&
                                codeTax > 0 &&
                                allow &&
                                isAllowIdSubject)
                            {
                                count2++;
                                int iiii = 0;
                                int findFirstValueCol = 0;
                                int findFirstValueColIndex = 0;
                                for (int c = 0; c < var.InternalTable.Columns.Count; c++)
                                {
                                    int index1 = defineTrueCol1PATENT(c);
                                    if (index1 == 1)
                                    {
                                        findFirstValueCol = index1;
                                        findFirstValueColIndex = c;
                                        break;
                                    }
                                }
                                if (codeChanged) codeTax = newCode;
                                int status = checkImportedData1PATENT(subj, codeTax, year, i, findFirstValueColIndex, findFirstValueCol, "", cr.ImportData.ImpDataFile.ParentIdSubject);
                                #region добавляем/изменяем
                                if (!DBNull.Value.Equals(var.InternalTable.Rows[i][j]))
                                {
                                    if (status == 0)
                                    {
                                        var.Status = " добавляем ";
                                        PATENT1Row = ds.Source_data_1PATENT.NewSource_data_1PATENTRow();
                                    }
                                    if (status == 1)
                                    {
                                        var.Status = " изменяем ";
                                        PATENT1Row = ds.Source_data_1PATENT.FindByid(var.CheckedId);
                                    }
                                    if (status == 2)
                                    {
                                        var.Status = " удаляем ";
                                        ds.Source_data_1PATENT.FindByid(var.CheckedId).Delete();
                                    }
                                    if (status == 3)
                                    {
                                        var.Status = " проверено ";
                                    }
                                    if (status == 0 || status == 1)
                                    {
                                        count3++;
                                        numColTax = j;
                                        PATENT1Row.id_patent = codeTax;
                                        PATENT1Row.pid = impData.defineParentIdSubject(subj);
                                        if (PATENT1Row.pid > 0)
                                        {
                                            PATENT1Row.id_subject = PATENT1Row.pid;
                                            PATENT1Row.cid = subj;
                                        }
                                        else
                                        {
                                            PATENT1Row.id_subject = subj;
                                        }
                                        PATENT1Row.year_data = year;
                                        OnReadInternalFile();
                                    }
                                    for (int c = var.IndexHeaderCol; c < var.InternalTable.Columns.Count; c++)
                                    {
                                                                                
                                        if (var.InternalTable.Rows[var.IndexHeaderRow][c].ToString().Length > 0)
                                        {
                                            indexCol = defineTrueCol1PATENT(c);
                                            if (indexCol > 0)
                                            {
                                                if (status != 0 && status != 3)
                                                {
                                                    status = checkImportedData1PATENT(subj, codeTax, year, i, findFirstValueColIndex, findFirstValueCol, "", cr.ImportData.ImpDataFile.ParentIdSubject);
                                                }
                                                if (status == 2)
                                                {
                                                    var.Status = " удаляем ";
                                                    ds.Source_data_1PATENT.FindByid(var.CheckedId).Delete();
                                                }
                                                bool isChechedNeedCol = true;
                                                try
                                                {
                                                    int value = impData.returnNullInt(var.InternalTable.Rows[i][c + 1]);

                                                }
                                                catch (System.Exception ex)
                                                {
                                                    isChechedNeedCol = false;
                                                }
                                                if (!isChechedNeedCol) continue;
                                                if (!DBNull.Value.Equals(var.InternalTable.Rows[i][c + 1]))
                                                {
                                                    if (status == 0 || status == 1)
                                                    {
                                                        OnReadInternalFile();
                                                        //
                                                        PATENT1Row[indexCol.ToString()] = impData.returnNullInt(var.InternalTable.Rows[i][c + 1]);
                                                        //doTableAdapter(
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (status == 0)
                                    {
                                        ds.Source_data_1PATENT.AddSource_data_1PATENTRow(PATENT1Row);
                                    }
                                }
                                #endregion добавляем/изменяем

                                iiii++;
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
            private void AddCompareReportsTaxEea(int id_subject)
            {
                if (var.YearAfter>0 && var.YearBefore > 0)
                {
                    cr.Data.Base.SourceData1NOMTableAdapter.FillBy_subject_year(ds.Source_data_1NOM, id_subject, var.YearAfter, var.YearBefore);
                }
                else
                {
                    cr.Data.Base.SourceData1NOMTableAdapter.FillBy(ds.Source_data_1NOM, id_subject);
                }
                
                var.CountRecords = ds.Source_data_1NOM.Rows.Count;
                int countForsChTax = 0;
                int countFors = 0;
                for (int i = 0; i < ds.Source_data_1NOM.Rows.Count; i++)
                {
                    var.IndexRecord = i + 1;
                    var.Status = " калькуляция ";
                    for (int j = 0; j < ds.Source_data_1NOM.Columns.Count; j++)
                    {
                        countFors++;
                        var.NameDistrictNow = countFors.ToString();
                        if (chNumberColTaxEea(ds.Source_data_1NOM.Columns[j].ToString()))
                        {
                            int id_tax = var.CodeTax;
                            int id_eea = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_taxColumn]);
                            id_subject = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_subjectColumn]);
                            int year = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.year_dataColumn]);
                            int pid = impData.defineParentIdSubject(id_subject);
                            countForsChTax++;
                            var.NameSubjectNow = countFors.ToString();
                            if (id_tax != 0 && id_subject > 0 && year > 0 && id_eea > 0)
                            {
                                var.SourceTableName = ds.Compare_tax_eea.TableName;
                                int checkedImportedData = chRecordCompareTaxEea(id_eea, id_tax, id_subject, impData.returnNullDecimal(ds.Source_data_1NOM[i][j]), year, pid);
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
                    var.IndexRecord = ds.Source_data_1NOM.Rows.Count;
                }
            }
            private void AddSpreadOnBudgetsTax(int id_subject)
            {
                if (id_subject > 0 && var.YearAfter <= 0 && var.YearBefore <= 0)
                {
                    cr.Data.Base.SourceData1NMTableAdapter.FillBy(ds.Source_data_1NM, id_subject);
                }
                else if (id_subject > 0 && var.YearAfter > 0 && var.YearBefore > 0)
                {
                    cr.Data.Base.SourceData1NMTableAdapter.FillBy_subject_year(ds.Source_data_1NM, id_subject, var.YearAfter, var.YearBefore);
                }
                else
                {
                    cr.Data.Base.SourceData1NMTableAdapter.Fill(ds.Source_data_1NM);
                }
                var.CountRecords = ds.Source_data_1NM.Rows.Count;
                int countForsChTax = 0;
                int countFors = 0;
                for (int i = 0; i < ds.Source_data_1NM.Rows.Count; i++)
                {
                    var.IndexRecord = i + 1;
                    var.Status = " распределение ";
                    for (int j = 0; j < ds.Source_data_1NM.Columns.Count; j++)
                    {
                        countFors++;
                        var.NameDistrictNow = countFors.ToString();
                        if (chNumberColTaxBudget(ds.Source_data_1NM.Columns[j].ToString()))
                        {
                            int id_tax = impData.returnNullInt(ds.Source_data_1NM[i][ds.Source_data_1NM.id_taxColumn]);
                            int id_budget = var.CodeBudget;
                            id_subject = impData.returnNullInt(ds.Source_data_1NM[i][ds.Source_data_1NM.id_subjectColumn]);
                            int id_time = findIdTimeByYear(impData.returnNullInt(ds.Source_data_1NM[i][ds.Source_data_1NM.year_dataColumn]));
                            int pid = impData.defineParentIdSubject(id_subject);
                            countForsChTax++;
                            var.NameSubjectNow = countFors.ToString();
                            if (id_tax != 0 && id_subject > 0 && id_time > 0 && id_budget > 0)
                            {
                                var.SourceTableName = ds.Compare_tax_budget.TableName;
                                int checkedImportedData = chRecordCompareTaxBudget(id_budget, id_tax, id_subject, impData.returnNullDecimal(ds.Source_data_1NM[i][j]), id_time, pid);
                                if (id_budget > 0)
                                {
                                    if (checkedImportedData == 0)
                                    {
                                        var.Status = " добавляем ";
                                        SpTaxRow = ds.Compare_tax_budget.NewCompare_tax_budgetRow();
                                    }
                                    else if (checkedImportedData == 1)
                                    {
                                        var.Status = " изменяем ";
                                        SpTaxRow = ds.Compare_tax_budget.FindByid(var.CheckedId);
                                    }
                                    else if (checkedImportedData == 2)
                                    {
                                        var.Status = " удаляем ";
                                        ds.Compare_tax_budget.FindByid(var.CheckedId).Delete();
                                    }
                                    else
                                    {
                                        var.Status = " проверено ";
                                    }
                                    if (checkedImportedData == 1 || checkedImportedData == 0)
                                    {
                                        SpTaxRow.id_subject = id_subject;
                                        SpTaxRow.id_tax = id_tax;
                                        SpTaxRow.id_budget = id_budget;
                                        SpTaxRow.id_time = id_time;
                                        SpTaxRow.ti = impData.returnNullInt(ds.Source_data_1NM[i][j]);
                                    }
                                    if (checkedImportedData == 0)
                                    {
                                        ds.Compare_tax_budget.AddCompare_tax_budgetRow(SpTaxRow);
                                    }
                                }
                                doTableAdapter(var.TableAdapterMethod);
                            }
                        }

                    }
                    var.IndexRecord = ds.Source_data_1NM.Rows.Count;
                }
                #region Расчет регионального бюджета
                //Расчет регионального бюджета из ФБ-МБ
                var.CodeBudget = 2; //Код регионального бюджета
                for (int i = 0; i < ds.Source_data_1NM.Rows.Count; i++)
                {
                    var.IndexRecord = i + 1;
                    var.Status = " расчет ";
                    countFors++;
                    var.NameDistrictNow = countFors.ToString();
                    int id_tax = impData.returnNullInt(ds.Source_data_1NM[i][ds.Source_data_1NM.id_taxColumn]);
                    int id_budget = var.CodeBudget;
                    id_subject = impData.returnNullInt(ds.Source_data_1NM[i][ds.Source_data_1NM.id_subjectColumn]);
                    int id_time = findIdTimeByYear(impData.returnNullInt(ds.Source_data_1NM[i][ds.Source_data_1NM.year_dataColumn]));
                    int pid = impData.defineParentIdSubject(id_subject);
                    countForsChTax++;
                    var.NameSubjectNow = countFors.ToString();
                    if (id_tax != 0 && id_subject > 0 && id_time > 0 && id_budget > 0)
                    {
                        var.SourceTableName = ds.Compare_tax_budget.TableName;
                        decimal ti = impData.returnNullDecimal(ds.Source_data_1NM[i][ds.Source_data_1NM._3Column]) - impData.returnNullDecimal(ds.Source_data_1NM[i][ds.Source_data_1NM._4Column]);
                        int checkedImportedData = chRecordCompareTaxBudget(id_budget, id_tax, id_subject, ti, id_time, pid);
                        if (id_budget > 0)
                        {
                            if (checkedImportedData == 0)
                            {
                                var.Status = " добавляем ";
                                SpTaxRow = ds.Compare_tax_budget.NewCompare_tax_budgetRow();
                            }
                            else if (checkedImportedData == 1)
                            {
                                var.Status = " изменяем ";
                                SpTaxRow = ds.Compare_tax_budget.FindByid(var.CheckedId);
                            }
                            else if (checkedImportedData == 2)
                            {
                                var.Status = " удаляем ";
                                ds.Compare_tax_budget.FindByid(var.CheckedId).Delete();
                            }
                            else
                            {
                                var.Status = " проверено ";
                            }
                            if (checkedImportedData == 1 || checkedImportedData == 0)
                            {
                                SpTaxRow.id_subject = id_subject;
                                SpTaxRow.id_tax = id_tax;
                                SpTaxRow.id_budget = id_budget;
                                SpTaxRow.id_time = id_time;
                                SpTaxRow.ti = ti;
                            }
                            if (checkedImportedData == 0)
                            {
                                ds.Compare_tax_budget.AddCompare_tax_budgetRow(SpTaxRow);
                            }
                        }
                        doTableAdapter(var.TableAdapterMethod);
                    }
                    var.IndexRecord = ds.Source_data_1NM.Rows.Count;
                }
                #endregion Расчет регионального бюджета
            }
            private void AddSpreadOnBudgetsEea(int id_subject)
            {
                if (id_subject > 0 && var.YearAfter <= 0 && var.YearBefore <= 0)
                {
                    cr.Data.Base.SourceData1NOMTableAdapter.FillBy(ds.Source_data_1NOM, id_subject);
                }
                else if (id_subject > 0 && var.YearAfter > 0 && var.YearBefore > 0)
                {
                    cr.Data.Base.SourceData1NOMTableAdapter.FillBy_subject_year(ds.Source_data_1NOM, id_subject, var.YearAfter, var.YearBefore);
                }
                else
                {
                    cr.Data.Base.SourceData1NOMTableAdapter.Fill(ds.Source_data_1NOM);
                }
                var.CountRecords = ds.Source_data_1NOM.Rows.Count;
                int countForsChTax = 0;
                int countFors = 0;
                for (int i = 0; i < ds.Source_data_1NOM.Rows.Count; i++)
                {
                    var.IndexRecord = i + 1;
                    var.Status = " распределение ";
                    for (int j = 0; j < ds.Source_data_1NOM.Columns.Count; j++)
                    {
                        countFors++;
                        var.NameDistrictNow = countFors.ToString();
                        if (chNumberColEeaBudget(ds.Source_data_1NOM.Columns[j].ToString()))
                        {
                            int id_tax = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_taxColumn]);
                            int id_budget = var.CodeBudget;
                            id_subject = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_subjectColumn]);
                            int id_time = findIdTimeByYear(impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.year_dataColumn]));
                            int pid = impData.defineParentIdSubject(id_subject);
                            countForsChTax++;
                            var.NameSubjectNow = countFors.ToString();
                            if (id_tax != 0 && id_subject > 0 && id_time > 0 && id_budget > 0)
                            {
                                var.SourceTableName = ds.Compare_eea_budget.TableName;
                                int checkedImportedData = chRecordCompareEeaBudget(id_budget, id_tax, id_subject, impData.returnNullDecimal(ds.Source_data_1NOM[i][j]), id_time, pid);
                                if (id_budget > 0)
                                {
                                    if (checkedImportedData == 0)
                                    {
                                        var.Status = " добавляем ";
                                        SpEeaRow = ds.Compare_eea_budget.NewCompare_eea_budgetRow();
                                    }
                                    else if (checkedImportedData == 1)
                                    {
                                        var.Status = " изменяем ";
                                        SpEeaRow = ds.Compare_eea_budget.FindByid(var.CheckedId);
                                    }
                                    else if (checkedImportedData == 2)
                                    {
                                        var.Status = " удаляем ";
                                        ds.Compare_eea_budget.FindByid(var.CheckedId).Delete();
                                    }
                                    else
                                    {
                                        var.Status = " проверено ";
                                    }
                                    if (checkedImportedData == 1 || checkedImportedData == 0)
                                    {
                                        SpEeaRow.id_subject = id_subject;
                                        SpEeaRow.id_eea = id_tax;
                                        SpEeaRow.id_budget = id_budget;
                                        SpEeaRow.id_time = id_time;
                                        SpEeaRow.ti = impData.returnNullInt(ds.Source_data_1NOM[i][j]);
                                    }
                                    if (checkedImportedData == 0)
                                    {
                                        ds.Compare_eea_budget.AddCompare_eea_budgetRow(SpEeaRow);
                                    }
                                }
                                doTableAdapter(var.TableAdapterMethod);
                            }
                        }

                    }
                    var.IndexRecord = ds.Source_data_1NOM.Rows.Count;
                }
                #region Расчет регионального бюджета
                //Расчет регионального бюджета из ФБ-МБ
                /*var.CodeBudget = 2; //Код регионального бюджета
                for (int i = 0; i < ds.Source_data_1NOM.Rows.Count; i++)
                {
                    var.IndexRecord = i + 1;
                    var.Status = " расчет ";
                    countFors++;
                    var.NameDistrictNow = countFors.ToString();
                    int id_tax = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_taxColumn]);
                    int id_budget = var.CodeBudget;
                    id_subject = impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.id_subjectColumn]);
                    int id_time = findIdTimeByYear(impData.returnNullInt(ds.Source_data_1NOM[i][ds.Source_data_1NOM.year_dataColumn]));
                    int pid = impData.defineParentIdSubject(id_subject);
                    countForsChTax++;
                    var.NameSubjectNow = countFors.ToString();
                    if (id_tax != 0 && id_subject > 0 && id_time > 0 && id_budget > 0)
                    {
                        var.SourceTableName = ds.Compare_eea_budget.TableName;
                        decimal ti = impData.returnNullDecimal(ds.Source_data_1NOM[i][ds.Source_data_1NOM._3Column]) - impData.returnNullDecimal(ds.Source_data_1NOM[i][ds.Source_data_1NOM._4Column]);
                        int checkedImportedData = chRecordCompareEeaBudget(id_budget, id_tax, id_subject, ti, id_time, pid);
                        if (id_budget > 0)
                        {
                            if (checkedImportedData == 0)
                            {
                                var.Status = " добавляем ";
                                SpEeaRow = ds.Compare_eea_budget.NewCompare_eea_budgetRow();
                            }
                            else if (checkedImportedData == 1)
                            {
                                var.Status = " изменяем ";
                                SpEeaRow = ds.Compare_eea_budget.FindByid(var.CheckedId);
                            }
                            else if (checkedImportedData == 2)
                            {
                                var.Status = " удаляем ";
                                ds.Compare_eea_budget.FindByid(var.CheckedId).Delete();
                            }
                            else
                            {
                                var.Status = " проверено ";
                            }
                            if (checkedImportedData == 1 || checkedImportedData == 0)
                            {
                                SpEeaRow.id_subject = id_subject;
                                SpEeaRow.id_eea = id_tax;
                                SpEeaRow.id_budget = id_budget;
                                SpEeaRow.id_time = id_time;
                                SpEeaRow.ti = ti;
                            }
                            if (checkedImportedData == 0)
                            {
                                ds.Compare_eea_budget.AddCompare_eea_budgetRow(SpEeaRow);
                            }
                        }
                        doTableAdapter(var.TableAdapterMethod);
                    }
                    //var.IndexRecord = ds.Source_data_1NOM.Rows.Count;
                }*/
                #endregion Расчет регионального бюджета
            }
            private int findIdTimeByYear(int year)
            {
                int id_time = 0;
                if (ds.Time == null)
                {
                    cr.Data.Base.TimeTableAdapter.Fill(ds.Time);
                }
                if (ds.Time.Rows.Count <= 0) cr.Data.Base.TimeTableAdapter.Fill(ds.Time);
                DataRow[] dRowLev1;
                base_nalogDataSet.TimeRow timeRow;
                string filter = "calendar_year =" + year;
                dRowLev1 = ds.Time.Select(filter);
                if (dRowLev1.Length > 0)
                {
                    id_time = cr.ImportData.returnNullInt(dRowLev1[0]["id"]);
                }
                else
                {
                    //
                    timeRow = ds.Time.NewTimeRow();
                    timeRow.calendar_year = year;
                    ds.Time.AddTimeRow(timeRow);
                    doTableAdapter("Time");
                    id_time = cr.ImportData.returnNullInt(ds.Time.Rows[ds.Time.Rows.Count - 1][ds.Time.idColumn]);
                }
                return id_time;
            }
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
            private bool existNeedTax4NM(int taxNumber)
            {
                /* функция выполняет поиск подходящего налога из списка исходника и сопоставляет их списку из базы
                 * */
                bool yes = false;
                foreach (DataRow row in ds.Debts)
                {
                    if (taxNumber == impData.returnNullInt(row[ds.Debts.id_debtColumn]) &&
                        (bool)row[ds.Debts.useColumn] &&
                        impData.returnReplaceString(row[ds.Debts.id_debtColumn].ToString(), new string[] { " " }).Length <= 1)
                    {
                        yes = true;
                        break;
                    }
                    else if (taxNumber == impData.returnNullInt(row[ds.Debts.id_debtColumn]) &&
                        (bool)row[ds.Debts.useColumn] &&
                        var.Ch4NM && var.ChAllInOne)
                    {
                        yes = true;
                        break;
                    }
                }
                return yes;
            }
            private bool existNeedTax5ENVD(int taxNumber, string code = "", string name = "")
            {
                /* функция выполняет поиск подходящего налога из списка исходника и сопоставляет их списку из базы
                 * */
                bool yes = false;
                codeChanged = false;
                newCode = 0;
                /*for (int i = 0; i < ds.Taxes_ved.Rows.Count; i++)
                {
                    if ((int)ds.Taxes_ved.Rows[i][ds.Taxes_ved.idColumn] == taxNumber &&
                        (bool)ds.Taxes_ved.Rows[i][ds.Taxes_ved.useColumn])
                    {
                        yes = true;
                        count4++;
                    }
                }*/
                if (taxNumber > 0 && code.Length <= 1)
                {
                    foreach (DataRow row in ds.Envd)
                    {
                        if (taxNumber == impData.returnNullInt(row[ds.Envd.codeColumn]) &&
                            (bool)row[ds.Envd.useColumn] &&
                            impData.returnReplaceString(row[ds.Envd.codeColumn].ToString(), new string[] { " " }).Length <= 1)
                        {
                            yes = true;
                            break;
                        }
                        else if (taxNumber == impData.returnNullInt(row[ds.Envd.codeColumn]) &&
                            (bool)row[ds.Envd.useColumn] &&
                            var.Ch5ENVD && var.ChAllInOne)
                        {
                            yes = true;
                            break;
                        }
                    }
                    if (!yes && name.Length > 0)
                    {
                        if (matchStrings(name)) yes = true;
                        else yes = false;
                    }
                }
                if (taxNumber > 0 && code.Length > 1 && !yes)
                {
                    foreach (DataRow row in ds.Envd)
                    {
                        if (impData.returnReplaceString(
                                row[ds.Envd.codeColumn].ToString(), new string[] { " " }).ToUpper() == code.ToUpper() &&
                                (bool)row[ds.Envd.useColumn])
                        {
                            newCode = impData.returnNullInt(row["code"]);
                            yes = true;
                            break;
                        }
                    }
                }

                if (newCode > 0) codeChanged = true;
                count5++;
                return yes;
            }
            private bool existNeedTax5USN(int taxNumber, string code = "", string name = "")
            {
                /* функция выполняет поиск подходящего налога из списка исходника и сопоставляет их списку из базы
                 * */
                bool yes = false;
                codeChanged = false;
                newCode = 0;
                /*for (int i = 0; i < ds.Taxes_ved.Rows.Count; i++)
                {
                    if ((int)ds.Taxes_ved.Rows[i][ds.Taxes_ved.idColumn] == taxNumber &&
                        (bool)ds.Taxes_ved.Rows[i][ds.Taxes_ved.useColumn])
                    {
                        yes = true;
                        count4++;
                    }
                }*/
                if (taxNumber > 0)
                {
                    foreach (DataRow row in ds.Usn)
                    {
                        if ((taxNumber == impData.returnNullInt(row[ds.Usn.codeColumn]) || taxNumber == impData.returnNullInt(row[ds.Usn.code2Column])) &&
                            (bool)row[ds.Usn.useColumn] &&
                            impData.returnReplaceString(row[ds.Usn.codeColumn].ToString(), new string[] { " " }).Length <= 1)
                        {
                            yes = true;
                            if (taxNumber.ToString().Length > 3) newCode = impData.returnNullInt(row[ds.Usn.codeColumn]);
                            break;
                        }
                        else if ((taxNumber == impData.returnNullInt(row[ds.Usn.codeColumn]) || taxNumber == impData.returnNullInt(row[ds.Usn.code2Column])) &&
                            (bool)row[ds.Usn.useColumn] &&
                            var.Ch5USN && var.ChAllInOne)
                        {
                            yes = true;
                            if (taxNumber.ToString().Length > 3) newCode = impData.returnNullInt(row[ds.Usn.codeColumn]);
                            break;
                        }
                    }
                    if (!yes && name.Length > 0)
                    {
                        if (matchStrings(name)) yes = true;
                        else yes = false;
                    }
                }
                if (taxNumber > 0 && code.Length > 1 && !yes)
                {
                    foreach (DataRow row in ds.Usn)
                    {
                        if ((impData.returnReplaceString(row[ds.Usn.codeColumn].ToString(), new string[] { " " }).ToUpper() == code.ToUpper() ||
                            impData.returnReplaceString(row[ds.Usn.code2Column].ToString(), new string[] { " " }).ToUpper() == code.ToUpper())&&
                                (bool)row[ds.Usn.useColumn])
                        {
                            newCode = impData.returnNullInt(row["code"]);
                            if (taxNumber.ToString().Length > 3) newCode = impData.returnNullInt(row[ds.Usn.codeColumn]);
                            yes = true;
                            break;
                        }
                    }
                }

                if (newCode > 0) codeChanged = true;
                count5++;
                return yes;
            }
            private bool existNeedTax1PATENT(int taxNumber, string code = "", string name = "")
            {
                /* функция выполняет поиск подходящего налога из списка исходника и сопоставляет их списку из базы
                 * */
                bool yes = false;
                codeChanged = false;
                newCode = 0;
                /*for (int i = 0; i < ds.Taxes_ved.Rows.Count; i++)
                {
                    if ((int)ds.Taxes_ved.Rows[i][ds.Taxes_ved.idColumn] == taxNumber &&
                        (bool)ds.Taxes_ved.Rows[i][ds.Taxes_ved.useColumn])
                    {
                        yes = true;
                        count4++;
                    }
                }*/
                if (taxNumber > 0 && code.Length <= 1)
                {
                    foreach (DataRow row in ds.Patent)
                    {
                        if (taxNumber == impData.returnNullInt(row[ds.Patent.codeColumn]) &&
                            (bool)row[ds.Patent.useColumn] &&
                            impData.returnReplaceString(row[ds.Patent.codeColumn].ToString(), new string[] { " " }).Length <= 1)
                        {
                            yes = true;
                            break;
                        }
                        else if (taxNumber == impData.returnNullInt(row[ds.Patent.codeColumn]) &&
                            (bool)row[ds.Patent.useColumn] &&
                            var.Ch1PATENT && var.ChAllInOne)
                        {
                            yes = true;
                            break;
                        }
                    }
                    if (!yes && name.Length > 0)
                    {
                        if (matchStrings(name)) yes = true;
                        else yes = false;
                    }
                }
                if (taxNumber > 0 && code.Length > 1 && !yes)
                {
                    foreach (DataRow row in ds.Patent)
                    {
                        if (impData.returnReplaceString(
                                row[ds.Patent.codeColumn].ToString(), new string[] { " " }).ToUpper() == code.ToUpper() &&
                                (bool)row[ds.Patent.useColumn])
                        {
                            newCode = impData.returnNullInt(row["code"]);
                            yes = true;
                            break;
                        }
                    }
                }

                if (newCode > 0) codeChanged = true;
                count5++;
                return yes;
            }
            private bool existNeedTax1NOM(int taxNumber, string code="", string name="")
            {
                /* функция выполняет поиск подходящего налога из списка исходника и сопоставляет их списку из базы
                 * */
                bool yes = false;
                codeChanged = false;
                newCode = 0;
                /*for (int i = 0; i < ds.Taxes_ved.Rows.Count; i++)
                {
                    if ((int)ds.Taxes_ved.Rows[i][ds.Taxes_ved.idColumn] == taxNumber &&
                        (bool)ds.Taxes_ved.Rows[i][ds.Taxes_ved.useColumn])
                    {
                        yes = true;
                        count4++;
                    }
                }*/
                if (taxNumber > 0 && code.Length <=1)
                {
                    foreach (DataRow row in ds.Taxes_ved)
                    {
                        if (taxNumber == impData.returnNullInt(row[ds.Taxes_ved.idColumn]) &&
                            (bool)row[ds.Taxes_ved.useColumn] &&
                            impData.returnReplaceString(row[ds.Taxes_ved.codeColumn].ToString(), new string[] { " " }).Length <= 1)
                        {
                            yes = true;
                            break;
                        }
                        else if (taxNumber == impData.returnNullInt(row[ds.Taxes_ved.idColumn]) &&
                            (bool)row[ds.Taxes_ved.useColumn] &&
                            var.Ch1NOM && var.ChAllInOne)
                        {
                            yes = true;
                            break;
                        }
                    }
                    if (!yes && name.Length>0)
                    {
                        if (matchStrings(name)) yes = true;
                        else yes = false;
                    }
                }
                if (taxNumber > 0 && code.Length > 1 && taxNumber < 2000 && !yes)
                {
                    foreach (DataRow row in ds.Taxes_ved)
                    {
                        if (impData.returnReplaceString(
                                row[ds.Taxes_ved.codeColumn].ToString(), new string[] { " " }).ToUpper() == code.ToUpper() &&
                                (bool)row[ds.Taxes_ved.useColumn])
                        {
                            newCode = impData.returnNullInt(row["id"]);
                            yes = true;
                            break;
                        }
                    }
                }

                if (newCode > 0) codeChanged = true;
                count5++;
                return yes;
            }
            private bool checkTrueCode1NOM(string code)
            {
                return true;
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
                DataRow[] dRowLev2 = ds.Tables[var.SourceTableName].Select(filter);
                if (dRowLev2.Length > 0) { y = 1; var.CheckedId = impData.returnNullInt(dRowLev2[0][ds.Source_data_1NM.idColumn]); }
                return y;
            }
            private int checkImportedData5ENVD(int idSubj, int codeTax, int year, int index1, int index2, int index3 = 2, string strCol = "", int pid = 0)
            {
                /*
                 * Поиск в несколько этапов и определение действие с данными в таблице 1-НМ
                 * */

                int y = -1;
                string id_subject_filter = "";
                if (pid != 0)
                {
                    id_subject_filter = ds.Source_data_5ENVD.cidColumn.ToString();
                }
                else
                {
                    id_subject_filter = ds.Source_data_5ENVD.id_subjectColumn.ToString();
                }
                string filter = id_subject_filter + "=" + idSubj +
                    " AND " + ds.Source_data_5ENVD.id_envdColumn.ToString() + "=" + codeTax +
                    " AND " + ds.Source_data_5ENVD.year_dataColumn.ToString() + "=" + year;
                string select = "SELECT * FROM " + var.SourceTableName + " WHERE " + filter;
                var.SourceTable = cr.ImportData.ReturnSourceTable(select, var.SourceTableName);
                DataRow[] dRowLev1 = var.SourceTable.Select();
                int count = dRowLev1.Length;
                int indexRow = 0;
                string strIdTaxCol = "id_envd";
                if (strCol.Length <= 0) strCol = ds.Source_data_5ENVD._1Column.ColumnName;
                foreach (DataRow lev1 in dRowLev1)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";
                    if (idSubj == impData.returnNullInt(lev1[id_subject_filter]) &&
                     codeTax == impData.returnNullInt(lev1[strIdTaxCol]) &&
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
                        ds.Source_data_5ENVD.FindByid(var.CheckedId).Delete();
                        step2 = true;
                        y = 2; //удаляем
                    }
                    if (!step1 && !step2)
                    {
                        y = 0; //добавляем
                    }
                    if (idSubj == impData.returnNullInt(lev1[id_subject_filter]) &&
                     codeTax == impData.returnNullInt(lev1[strIdTaxCol]) &&
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
                DataRow[] dRowLev2 = ds.Tables[var.SourceTableName].Select(filter);
                if (dRowLev2.Length > 0) { y = 1; var.CheckedId = impData.returnNullInt(dRowLev2[0][ds.Source_data_5ENVD.idColumn]); }
                return y;
            }
            private int checkImportedData5USN(int idSubj, int codeTax, int year, int index1, int index2, string strCol = "", int pid = 0)
            {
                /*
                 * Поиск в несколько этапов и определение действие с данными в таблице 1-НМ
                 * */

                int y = -1;
                string id_subject_filter = "";
                string strIdTaxCol = "id_usn";
                if (pid != 0)
                {
                    id_subject_filter = ds.Source_data_5USN.cidColumn.ToString();
                }
                else
                {
                    id_subject_filter = ds.Source_data_5USN.id_subjectColumn.ToString();
                }
                string filter = id_subject_filter + "=" + idSubj +
                    " AND " + ds.Source_data_5USN.Columns[strIdTaxCol].ColumnName.ToString() + "=" + codeTax +
                    " AND " + ds.Source_data_5USN.year_dataColumn.ToString() + "=" + year;
                string select = "SELECT * FROM " + var.SourceTableName + " WHERE " + filter;
                var.SourceTable = cr.ImportData.ReturnSourceTable(select, var.SourceTableName);
                DataRow[] dRowLev1 = var.SourceTable.Select();
                int count = dRowLev1.Length;
                int indexRow = 0;

                if (strCol.Length <= 0) strCol = ds.Source_data_5USN._1Column.ColumnName;
                foreach (DataRow lev1 in dRowLev1)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";
                    if (idSubj == impData.returnNullInt(lev1[id_subject_filter]) &&
                     codeTax == impData.returnNullInt(lev1[strIdTaxCol]) &&
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
                        ds.Source_data_5USN.FindByid(var.CheckedId).Delete();
                        step2 = true;
                        y = 2; //удаляем
                    }
                    if (!step1 && !step2)
                    {
                        y = 0; //добавляем
                    }
                    if (idSubj == impData.returnNullInt(lev1[id_subject_filter]) &&
                     codeTax == impData.returnNullInt(lev1[strIdTaxCol]) &&
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
                DataRow[] dRowLev2 = ds.Tables[var.SourceTableName].Select(filter);
                if (dRowLev2.Length > 0) { y = 1; var.CheckedId = impData.returnNullInt(dRowLev2[0][ds.Source_data_5USN.idColumn]); }
                return y;
            }
            private int checkImportedData1PATENT(int idSubj, int codeTax, int year, int index1, int index2, int index3 = 2, string strCol = "", int pid = 0)
            {
                /*
                 * Поиск в несколько этапов и определение действие с данными в таблице 1-НМ
                 * */

                int y = -1;
                string id_subject_filter = "";
                string string_id = "id_patent";
                if (pid != 0)
                {
                    id_subject_filter = ds.Source_data_1PATENT.cidColumn.ToString();
                }
                else
                {
                    id_subject_filter = ds.Source_data_1PATENT.id_subjectColumn.ToString();
                }
                string filter = id_subject_filter + "=" + idSubj +
                    " AND " + ds.Source_data_1PATENT.Columns[string_id].ColumnName.ToString() + "=" + codeTax +
                    " AND " + ds.Source_data_1PATENT.year_dataColumn.ToString() + "=" + year;
                string select = "SELECT * FROM " + var.SourceTableName + " WHERE " + filter;
                var.SourceTable = cr.ImportData.ReturnSourceTable(select, var.SourceTableName);
                DataRow[] dRowLev1 = var.SourceTable.Select();
                int count = dRowLev1.Length;
                int indexRow = 0;
                
                if (strCol.Length <= 0) strCol = ds.Source_data_1PATENT._1Column.ColumnName;
                foreach (DataRow lev1 in dRowLev1)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";
                    if (idSubj == impData.returnNullInt(lev1[id_subject_filter]) &&
                     codeTax == impData.returnNullInt(lev1[string_id]) &&
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
                        ds.Source_data_1PATENT.FindByid(var.CheckedId).Delete();
                        step2 = true;
                        y = 2; //удаляем
                    }
                    if (!step1 && !step2)
                    {
                        y = 0; //добавляем
                    }
                    if (idSubj == impData.returnNullInt(lev1[id_subject_filter]) &&
                     codeTax == impData.returnNullInt(lev1[string_id]) &&
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
                DataRow[] dRowLev2 = ds.Tables[var.SourceTableName].Select(filter);
                if (dRowLev2.Length > 0) { y = 1; var.CheckedId = impData.returnNullInt(dRowLev2[0][ds.Source_data_1PATENT.idColumn]); }
                return y;
            }
            private int checkImportedData4NM(int idSubj, int codeTax, int year, int index1, int index2, int index3=2, int childId = 0)
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
                    id_filter = ds.Source_data_4NM.cidColumn.ToString();
                }
                else
                {
                    id_filter = ds.Source_data_4NM.id_subjectColumn.ToString();
                }
                string filter = id_filter + "=" + idSubj +
                    " AND " + ds.Source_data_4NM.id_debtColumn.ToString() + "=" + codeTax +
                    " AND " + ds.Source_data_4NM.year_dataColumn.ToString() + "=" + year;
                dRowLev1 = ds.Source_data_4NM.Select(filter);
                int count = dRowLev1.Length;
                //if (!(count < 1))
                //{
                int indexRow = 0;
                foreach (DataRow lev1 in dRowLev1)
                {
                    #region Проверка
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";

                    if (idSubj == impData.returnNullInt(lev1[ds.Source_data_4NM.id_subjectColumn]) &&
                        codeTax == impData.returnNullInt(lev1[ds.Source_data_4NM.id_debtColumn]) &&
                        year == impData.returnNullInt(lev1[ds.Source_data_4NM.year_dataColumn]) &&
                        lev1[ds.Source_data_4NM._2Column] != DBNull.Value)
                    {
                        //проверено
                        var.CheckedId = Convert.ToInt32(lev1[ds.Source_data_4NM.idColumn]);
                        y = 3;
                        step1 = true;
                    }
                    if (idSubj == impData.returnNullInt(lev1[ds.Source_data_4NM.id_subjectColumn]) &&
                        codeTax == impData.returnNullInt(lev1[ds.Source_data_4NM.id_debtColumn]) &&
                        year == impData.returnNullInt(lev1[ds.Source_data_4NM.year_dataColumn]) &&
                        index2 > 0)
                    {
                        if (impData.returnNullInt(var.InternalTable.Rows[index1][index2]) != impData.returnNullInt(lev1[index3.ToString()]))
                        {
                            //изменяем
                            y = 1;
                            var.CheckedId = Convert.ToInt32(lev1[ds.Source_data_4NM.idColumn]);
                            step2 = true;
                        }
                    }
                    if (!step1 && !step2 && indexRow > 1)
                    {
                        //удаляем
                        var.CheckedId = impData.returnNullInt(lev1[ds.Source_data_4NM.idColumn]);
                        step3 = true;
                        y = 2;
                    }
                    if (!step1 && !step2 && !step3)
                    {
                        //добавляем
                        y = 0;
                    }
                    var.Status = " проверяем";
                    #endregion Проверка
                }
                //}
                return y;
            }
            private int checkImportedData(int idSubj, int year, decimal val, int tax, int module, string nameCol = "", int pid = 0)
            {
                //такая функция же есть в SubjectIndex
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
            private int checkImportedData1NOM(int idSubj, int codeTax, int year, int index1, int index2, int index3=2, int childId = 0)
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
                int indexRow = 0;
                foreach (DataRow lev1 in dRowLev1)
                {
                    #region Проверка
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";

                    if (idSubj == impData.returnNullInt(lev1[ds.Source_data_1NOM.id_subjectColumn]) &&
                        codeTax == impData.returnNullInt(lev1[ds.Source_data_1NOM.id_taxColumn]) &&
                        year == impData.returnNullInt(lev1[ds.Source_data_1NOM.year_dataColumn]) &&
                        lev1[ds.Source_data_1NOM._2Column] != DBNull.Value)
                    {
                        //проверено
                        var.CheckedId = Convert.ToInt32(lev1[ds.Source_data_1NOM.idColumn]);
                        y = 3;
                        step1 = true;
                    }
                    if (idSubj == impData.returnNullInt(lev1[ds.Source_data_1NOM.id_subjectColumn]) &&
                        codeTax == impData.returnNullInt(lev1[ds.Source_data_1NOM.id_taxColumn]) &&
                        year == impData.returnNullInt(lev1[ds.Source_data_1NOM.year_dataColumn]) &&
                        index2 > 0)
                    {
                        if (impData.returnNullInt(var.InternalTable.Rows[index1][index2]) != impData.returnNullInt(lev1[index3.ToString()]))
                        {
                            //изменяем
                            y = 1;
                            var.CheckedId = Convert.ToInt32(lev1[ds.Source_data_1NOM.idColumn]);
                            step2 = true;
                        }
                    }
                    if (!step1 && !step2 && indexRow > 1)
                    {
                        //удаляем
                        var.CheckedId = impData.returnNullInt(lev1[ds.Source_data_1NOM.idColumn]);
                        step3 = true;
                        y = 2;
                    }
                    if (!step1 && !step2 && !step3)
                    {
                        //добавляем
                        y = 0;
                    }
                    var.Status = " проверяем";
                    #endregion Проверка
                }
                //}
                return y;
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
                    if (i - 1 >= 0)
                    {
                        if (col == impData.returnReplaceString(ds.Source_data_1NOM_scheme.Rows[i][ds.Source_data_1NOM_scheme.number_columnColumn].ToString(), new string[] { " " }))
                        {
                            y = true;
                            var.CodeTax = impData.returnNullInt(ds.Source_data_1NOM_scheme.Rows[i][ds.Source_data_1NOM_scheme.id_taxColumn]);
                        }
                    }
                }
                return y;
            }
            private bool chNumberColTaxBudget(string col)
            {
                /*
                 * Ищим совпадения в схеме
                 * */
                bool y = false;
                if (ds.Source_data_1NM_scheme.Rows.Count <= 0)
                {
                    cr.Data.Base.SourceData1NMSchemeTableAdapter.Fill(ds.Source_data_1NM_scheme);
                }
                for (int i = 0; i < ds.Source_data_1NM_scheme.Rows.Count; i++)
                {
                    if (col == impData.returnReplaceString(ds.Source_data_1NM_scheme.Rows[i][ds.Source_data_1NM_scheme.number_columnColumn].ToString(), new string[] { " " }))
                    {
                        y = true;
                        var.CodeBudget = impData.returnNullInt(ds.Source_data_1NM_scheme.Rows[i][ds.Source_data_1NM_scheme.id_budgetColumn]);
                    }
                }
                return y;
            }
            private bool chNumberColEeaBudget(string col)
            {
                /*
                 * Ищим совпадения в схеме
                 * */
                bool y = false;
                if (ds.Source_data_1NOM_budget_scheme.Rows.Count <= 0)
                {
                    cr.Data.Base.SourceData1NOMBudgetSchemeTableAdapter.Fill(ds.Source_data_1NOM_budget_scheme);
                }
                for (int i = 0; i < ds.Source_data_1NOM_budget_scheme.Rows.Count; i++)
                {
                    if (col == impData.returnReplaceString(ds.Source_data_1NOM_budget_scheme.Rows[i][ds.Source_data_1NOM_budget_scheme.number_columnColumn].ToString(), new string[] { " " }))
                    {
                        y = true;
                        var.CodeBudget = impData.returnNullInt(ds.Source_data_1NOM_budget_scheme.Rows[i][ds.Source_data_1NOM_budget_scheme.id_budgetColumn]);
                    }
                }
                return y;
            }
            private int chRecordCompareTaxEea(int id_eea, int id_tax, int id_subject, decimal TI, int year, int pid = 0)
            {
                /*
                 * Проходимся по всем записям и находим совпадения
                 * */
                int y = -1;
                var.Status = " проверяем ";
                string id_subject_filter = "id_subject";
                if (pid != 0)
                {
                    id_subject_filter = ds.Compare_tax_eea.cidColumn.ToString();
                }
                else
                {
                    id_subject_filter = ds.Compare_tax_eea.id_subjectColumn.ToString();
                }
                string filter = ds.Compare_tax_eea.id_eeaColumn.ToString() + "=" + id_eea.ToString() +
                    " AND " + ds.Compare_tax_eea.id_taxColumn.ToString() + "=" + id_tax.ToString() +
                    " AND " + ds.Compare_tax_eea.id_subjectColumn.ToString() + "=" + id_subject.ToString() +
                    " AND " + ds.Compare_tax_eea.year_dataColumn.ToString() + "=" + year.ToString();
                string select = "SELECT * FROM " + var.SourceTableName + " WHERE " + filter;
                var.SourceTable = cr.ImportData.ReturnSourceTable(select, var.SourceTableName);
                int count = var.SourceTable.Rows.Count;
                int indexRow = 0;
                foreach (DataRow lev1 in var.SourceTable.Rows)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";
                    if (id_subject == impData.returnNullInt(lev1[id_subject_filter]) &&
                     id_tax == impData.returnNullInt(lev1["id_tax"]) &&
                     year == impData.returnNullInt(lev1["year_data"]) &&
                        TI != impData.returnNullDecimal(lev1["TI"]))
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
                    if (id_subject == impData.returnNullInt(lev1[id_subject_filter]) &&
                     id_tax == impData.returnNullInt(lev1["id_tax"]) &&
                     year == impData.returnNullInt(lev1["year_data"]) &&
                     TI == impData.returnNullInt(lev1["TI"]))
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
                if (var.SourceTable.Rows.Count <= 0)
                {
                    y = 0;
                }
                return y;
            }
            private int chRecordCompareTaxBudget(int id_budget, int id_tax, int id_subject, decimal TI, int id_time, int pid = 0)
            {
                /*
                 * Проходимся по всем записям и находим совпадения
                 * */
                int y = -1;
                var.Status = " проверяем ";
                string id_subject_filter = "id_subject";
                if (pid != 0)
                {
                    id_subject_filter = ds.Compare_tax_budget.cidColumn.ToString();
                }
                else
                {
                    id_subject_filter = ds.Compare_tax_budget.id_subjectColumn.ToString();
                }
                string filter = ds.Compare_tax_budget.id_budgetColumn.ToString() + "=" + id_budget.ToString() +
                    " AND " + ds.Compare_tax_budget.id_taxColumn.ToString() + "=" + id_tax.ToString() +
                    " AND " + ds.Compare_tax_budget.id_subjectColumn.ToString() + "=" + id_subject.ToString() +
                    " AND " + ds.Compare_tax_budget.id_timeColumn.ToString() + "=" + id_time.ToString();
                string select = "SELECT * FROM " + var.SourceTableName + " WHERE " + filter;
                var.SourceTable = cr.ImportData.ReturnSourceTable(select, var.SourceTableName);
                int count = var.SourceTable.Rows.Count;
                int indexRow = 0;
                foreach (DataRow lev1 in var.SourceTable.Rows)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";
                    if (id_subject == impData.returnNullInt(lev1[id_subject_filter]) &&
                     id_tax == impData.returnNullInt(lev1["id_tax"]) &&
                     id_time == impData.returnNullInt(lev1["id_time"]) &&
                        TI != impData.returnNullDecimal(lev1["TI"]))
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
                    if (id_subject == impData.returnNullInt(lev1[id_subject_filter]) &&
                     id_tax == impData.returnNullInt(lev1["id_tax"]) &&
                     id_time == impData.returnNullInt(lev1["id_time"]) &&
                     TI == impData.returnNullInt(lev1["TI"]))
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
                if (var.SourceTable.Rows.Count <= 0)
                {
                    y = 0;
                }
                return y;
            }
            private int chRecordCompareEeaBudget(int id_budget, int id_tax, int id_subject, decimal TI, int id_time, int pid = 0)
            {
                /*
                 * Проходимся по всем записям и находим совпадения
                 * */
                int y = -1;
                var.Status = " проверяем ";
                string id_subject_filter = "id_subject";
                if (pid != 0)
                {
                    id_subject_filter = ds.Compare_eea_budget.cidColumn.ToString();
                }
                else
                {
                    id_subject_filter = ds.Compare_eea_budget.id_subjectColumn.ToString();
                }
                string filter = ds.Compare_eea_budget.id_budgetColumn.ToString() + "=" + id_budget.ToString() +
                    " AND " + ds.Compare_eea_budget.id_eeaColumn.ToString() + "=" + id_tax.ToString() +
                    " AND " + ds.Compare_eea_budget.id_subjectColumn.ToString() + "=" + id_subject.ToString() +
                    " AND " + ds.Compare_eea_budget.id_timeColumn.ToString() + "=" + id_time.ToString();
                string select = "SELECT * FROM " + var.SourceTableName + " WHERE " + filter;
                var.SourceTable = cr.ImportData.ReturnSourceTable(select, var.SourceTableName);
                int count = var.SourceTable.Rows.Count;
                int indexRow = 0;
                foreach (DataRow lev1 in var.SourceTable.Rows)
                {
                    bool step1 = false;
                    bool step2 = false;
                    bool step3 = false;
                    indexRow++;
                    var.Status = " проверяем";
                    if (id_subject == impData.returnNullInt(lev1[id_subject_filter]) &&
                     id_tax == impData.returnNullInt(lev1["id_eea"]) &&
                     id_time == impData.returnNullInt(lev1["id_time"]) &&
                        TI != impData.returnNullDecimal(lev1["TI"]))
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
                    if (id_subject == impData.returnNullInt(lev1[id_subject_filter]) &&
                     id_tax == impData.returnNullInt(lev1["id_eea"]) &&
                     id_time == impData.returnNullInt(lev1["id_time"]) &&
                     TI == impData.returnNullInt(lev1["TI"]))
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
                if (var.SourceTable.Rows.Count <= 0)
                {
                    y = 0;
                }
                return y;
            }
            private void writeLogsFile(string line)
            {
                /*
                 * Write log file
                 * */
                string PathFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Log.txt";
                FileInfo fi = new FileInfo(PathFile);
                if (!fi.Exists) File.Create(PathFile);
                writer = File.AppendText(PathFile);
                writer.WriteLine(line);
                writer.Close();
                /*
                 * ------------END--------------------
                 * */
            }
            private int defineIndexHeaderRow()
            {
                int[] indexes = new int[3];
                int index1 = 0;
                int index2 = 0;
                for (int i = 0; i < var.InternalTable.Rows.Count; i++)
                {
                    for (int j = 0; j < var.InternalTable.Columns.Count; j++)
                    {
                        if (j + 2 <= var.InternalTable.Columns.Count - 1)
                        {
                            if ((impData.returnReplaceString(var.InternalTable.Rows[i][j].ToString(), new string[] { " " }).ToUpper() == "A" ||
                                impData.returnReplaceString(var.InternalTable.Rows[i][j].ToString(), new string[] { " " }).ToUpper() == "А") &&
                               (impData.returnReplaceString(var.InternalTable.Rows[i][j + 1].ToString(), new string[] { " " }).ToUpper() == "Б" ||
                                impData.returnReplaceString(var.InternalTable.Rows[i][j + 1].ToString(), new string[] { " " }).ToUpper() == "B") &&
                               (impData.returnReplaceString(var.InternalTable.Rows[i][j + 2].ToString(), new string[] { " " }).ToUpper() == "В" ||
                                impData.returnReplaceString(var.InternalTable.Rows[i][j + 2].ToString(), new string[] { " " }).ToUpper() == "C"))
                            {
                                index1 = i;
                                index2 = j + 3;
                                break;
                            }
                        }
                    }
                    if (index1 != 0) break;
                }
                var.IndexHeaderCol = index2;
                return index1;
            }
            private int defineIndexHeaderRowA()
            {
                int[] indexes = new int[3];
                int index1 = 0;
                int index2 = 0;
                for (int i = 0; i < var.InternalTable.Rows.Count; i++)
                {
                    for (int j = 0; j < var.InternalTable.Columns.Count; j++)
                    {
                        if (j + 1 <= var.InternalTable.Columns.Count - 1)
                        {
                            if ((impData.returnReplaceString(var.InternalTable.Rows[i][j].ToString(), new string[] { " " }).ToUpper() == "A" ||
                                impData.returnReplaceString(var.InternalTable.Rows[i][j].ToString(), new string[] { " " }).ToUpper() == "А"))
                            {
                                index1 = i;
                                index2 = j;
                                break;
                            }
                        }
                    }
                    if (index1 != 0) break;
                }
                var.IndexHeaderCol = index2;
                return index1;
            }
            private int defineIndexHeaderRow1NOM_AllInOne()
            {
                int[] indexes = new int[3];
                int index1 = 0;
                int index2 = 0;
                for (int i = 0; i < var.InternalTable.Rows.Count; i++)
                {
                    for (int j = 0; j < var.InternalTable.Columns.Count; j++)
                    {
                        if (j + 2 <= var.InternalTable.Columns.Count - 1)
                        {
                            if ((impData.returnReplaceString(var.InternalTable.Rows[i][j].ToString(), new string[] { " " }).ToUpper() == "A" ||
                                 impData.returnReplaceString(var.InternalTable.Rows[i][j].ToString(), new string[] { " " }).ToUpper() == "А") &&
                                (impData.returnReplaceString(var.InternalTable.Rows[i][j + 1].ToString(), new string[] { " " }).ToUpper() == "1" ||
                                 impData.returnReplaceString(var.InternalTable.Rows[i][j + 1].ToString(), new string[] { " " }).ToUpper() == "1") &&
                                (impData.returnReplaceString(var.InternalTable.Rows[i][j + 2].ToString(), new string[] { " " }).ToUpper() == "2" ||
                                 impData.returnReplaceString(var.InternalTable.Rows[i][j + 2].ToString(), new string[] { " " }).ToUpper() == "2"))
                            {
                                index1 = i;
                                index2 = j + 3;
                                break;
                            }
                        }
                    }
                    if (index1 != 0) break;
                }
                var.IndexHeaderCol = index2;
                return index1;
            }
            private int defineTrueCol1NOM(int j)
            {
                int col = 0;
                string[] cleanSymbols = new string[] { "гр", " ", ".", "=", "+", "-", "(", ")", ",", " " };
                for (int h = var.IndexHeaderRow-1; h >= 0; h--)
                {
                    //возвращаем значение из исходной таблицы
                    string name = var.InternalTable.Rows[h][j].ToString();
                    string str1 = impData.returnReplaceString(name, cleanSymbols);
                    if (str1.Length > 0)
                    {
                        //убираем лишние символы
                        string[] arr1 = returnArrayFromString(str1); //создаем массив символов из исходной строки
                        foreach (DataRow row in ds.Source_data_1NOM_header_scheme)
                        {
                            //проходим по таблицы соответствий
                            bool eq = false;
                            string str2 = impData.returnReplaceString(row["name"].ToString(), cleanSymbols);
                            if (str1 == str2)
                            {
                                //если полное совпадение то прерываем 
                                col = impData.returnNullInt(row["number"]);
                                eq = true;
                                break;
                            }
                            if (!eq)
                            {
                                //нет, идем дальше
                                string[] arr2 = returnArrayFromString(str2);
                                int countEq = 0;
                                int countLen = 0;
                                if (arr1.Length >= arr2.Length)
                                {
                                    countLen = arr1.Length;
                                }
                                else countLen = arr2.Length;
                                for (int i = 0; i < countLen; i++)
                                {
                                    if (i <= arr1.Length - 1 && i <= arr2.Length - 1)
                                    {
                                        if (arr1[i] == arr2[i]) countEq++;
                                    }
                                    else break;
                                }
                                decimal like1 = countEq / arr1.Length;
                                decimal like2 = countEq / arr2.Length;
                                decimal maxLike = Math.Max(like1, like2);
                                if (maxLike >= (decimal)0.7)
                                {
                                    col = impData.returnNullInt(row["number"]);
                                    break;
                                }
                                else
                                {
                                    List<string> listCh = new List<string>();
                                    for (int i = 0; i < arr1.Length; i++)
                                    {
                                        int countCh = 0;
                                        foreach (string ch in listCh)
                                        {
                                            if (ch == arr1[i]) countCh++;
                                        }
                                        if (countCh <= 0) listCh.Add(arr1[i]);
                                    }
                                    for (int i = 0; i < arr2.Length; i++)
                                    {
                                        int countCh = 0;
                                        foreach (string ch in listCh)
                                        {
                                            if (ch == arr2[i]) countCh++;
                                        }
                                        if (countCh <= 0) listCh.Add(arr2[i]);
                                    }
                                    decimal like = 0;
                                    foreach (string ch in listCh)
                                    {
                                        int C1 = new Regex(ch).Matches(str1).Count;
                                        int C2 = new Regex(ch).Matches(str2).Count;
                                        decimal F1 = C1 / (decimal)str1.Length;
                                        decimal F2 = C2 / (decimal)str2.Length;
                                        if (F1 > 0 && F2 > 0)
                                        {
                                            if (F1 > F2) like += F2 / F1 / listCh.Count;
                                            if (F2 > F1) like += F1 / F2 / listCh.Count;
                                            
                                        }
                                    }
                                    if (like >= (decimal)0.6)
                                    {
                                        col = impData.returnNullInt(row["number"]);
                                        break;
                                    }
                                        
                                }
                            }

                        }
                        if (col > 0) break;
                    }
                }
                return col;
            }
            private int defineTrueCol5ENVD(int j)
            {
                int col = 0;
                string[] cleanSymbols = new string[] { "гр", " ", ".", "=", "+", "-", "(", ")", ",", " " };
                
                col = j + 1;
                return col;
            }
            private int defineTrueCol1PATENT(int j)
            {
                int col = 0;
                string[] cleanSymbols = new string[] { "гр", " ", ".", "=", "+", "-", "(", ")", ",", " " };

                col = j + 1;
                return col;
            }
            private int defineTrueCol5USN(int j)
            {
                int col = 0;
                string[] cleanSymbols = new string[] { "гр", " ", ".", "=", "+", "-", "(", ")", ",", " " };

                col = j + 1;
                return col;
            }
            private int defineTrueCol4NM(int j)
            {
                int col = 0;
                string[] cleanSymbols = new string[] { "гр", " ", ".", "=", "+", "-", "(", ")", ",", " " };
                #region test
                //for (int h = var.IndexHeaderRow - 1; h >= 0; h--)
                //{
                //    //возвращаем значение из исходной таблицы
                //    string name = var.InternalTable.Rows[h][j].ToString();
                //    string str1 = impData.returnReplaceString(name, cleanSymbols);
                //    if (str1.Length > 0)
                //    {
                //        //убираем лишние символы
                //        string[] arr1 = returnArrayFromString(str1); //создаем массив символов из исходной строки
                //        foreach (DataRow row in ds.Source_data_1NOM_header_scheme)
                //        {
                //            //проходим по таблицы соответствий
                //            bool eq = false;
                //            string str2 = impData.returnReplaceString(row["name"].ToString(), cleanSymbols);
                //            if (str1 == str2)
                //            {
                //                //если полное совпадение то прерываем 
                //                col = impData.returnNullInt(row["number"]);
                //                eq = true;
                //                break;
                //            }
                //            if (!eq)
                //            {
                //                //нет, идем дальше
                //                string[] arr2 = returnArrayFromString(str2);
                //                int countEq = 0;
                //                int countLen = 0;
                //                if (arr1.Length >= arr2.Length)
                //                {
                //                    countLen = arr1.Length;
                //                }
                //                else countLen = arr2.Length;
                //                for (int i = 0; i < countLen; i++)
                //                {
                //                    if (i <= arr1.Length - 1 && i <= arr2.Length - 1)
                //                    {
                //                        if (arr1[i] == arr2[i]) countEq++;
                //                    }
                //                    else break;
                //                }
                //                decimal like1 = countEq / arr1.Length;
                //                decimal like2 = countEq / arr2.Length;
                //                decimal maxLike = Math.Max(like1, like2);
                //                if (maxLike >= (decimal)0.7)
                //                {
                //                    col = impData.returnNullInt(row["number"]);
                //                    break;
                //                }
                //                else
                //                {
                //                    List<string> listCh = new List<string>();
                //                    for (int i = 0; i < arr1.Length; i++)
                //                    {
                //                        int countCh = 0;
                //                        foreach (string ch in listCh)
                //                        {
                //                            if (ch == arr1[i]) countCh++;
                //                        }
                //                        if (countCh <= 0) listCh.Add(arr1[i]);
                //                    }
                //                    for (int i = 0; i < arr2.Length; i++)
                //                    {
                //                        int countCh = 0;
                //                        foreach (string ch in listCh)
                //                        {
                //                            if (ch == arr2[i]) countCh++;
                //                        }
                //                        if (countCh <= 0) listCh.Add(arr2[i]);
                //                    }
                //                    decimal like = 0;
                //                    foreach (string ch in listCh)
                //                    {
                //                        int C1 = new Regex(ch).Matches(str1).Count;
                //                        int C2 = new Regex(ch).Matches(str2).Count;
                //                        decimal F1 = C1 / (decimal)str1.Length;
                //                        decimal F2 = C2 / (decimal)str2.Length;
                //                        if (F1 > 0 && F2 > 0)
                //                        {
                //                            if (F1 > F2) like += F2 / F1 / listCh.Count;
                //                            if (F2 > F1) like += F1 / F2 / listCh.Count;

                //                        }
                //                    }
                //                    if (like >= (decimal)0.6)
                //                    {
                //                        col = impData.returnNullInt(row["number"]);
                //                        break;
                //                    }

                //                }
                //            }

                //        }
                //        if (col > 0) break;
                //    }
                //}
                #endregion test
                col = j + 1;
                return col;
            }
            private bool matchStrings(string str1 = "", string str2 = "")
            {
                bool isMatch = false;
                decimal match = 0;
                string[] cleanSymbols = new string[] { "гр", " ", ".", "=", "+", "-", "(", ")", ",", " " };
                    //возвращаем значение из исходной таблицы
                    str1 = impData.returnReplaceString(str1, cleanSymbols);
                    if (str1.Length > 0)
                    {
                        //убираем лишние символы
                        string[] arr1 = returnArrayFromString(str1); //создаем массив символов из исходной строки
                        foreach (DataRow row in ds.Taxes_ved.Rows)
                        {
                            //проходим по таблицы соответствий
                            bool eq = false;
                            str2 = impData.returnReplaceString(row[ds.Taxes_ved.nameColumn].ToString(), cleanSymbols);
                            if (str1 == str2)
                            {
                                //если полное совпадение то прерываем 
                                newCode = impData.returnNullInt(row[ds.Taxes_ved.idColumn]);
                                eq = true;
                                break;
                            }
                            if (!eq)
                            {
                                //нет, идем дальше
                                string[] arr2 = returnArrayFromString(str2);
                                int countEq = 0;
                                int countLen = 0;
                                if (arr1.Length >= arr2.Length)
                                {
                                    countLen = arr1.Length;
                                }
                                else countLen = arr2.Length;
                                for (int i = 0; i < countLen; i++)
                                {
                                    if (i <= arr1.Length - 1 && i <= arr2.Length - 1)
                                    {
                                        if (arr1[i] == arr2[i]) countEq++;
                                    }
                                    else break;
                                }
                                decimal like1 = (decimal)countEq / arr1.Length;
                                decimal like2 = (decimal)countEq / arr2.Length;
                                decimal maxLike = Math.Max(like1, like2);
                                if (maxLike >= (decimal)0.7)
                                {
                                    newCode = impData.returnNullInt(row[ds.Taxes_ved.idColumn]);
                                    break;
                                }
                                else
                                {
                                    List<string> listCh = new List<string>();
                                    for (int i = 0; i < arr1.Length; i++)
                                    {
                                        int countCh = 0;
                                        foreach (string ch in listCh)
                                        {
                                            if (ch == arr1[i]) countCh++;
                                        }
                                        if (countCh <= 0) listCh.Add(arr1[i]);
                                    }
                                    for (int i = 0; i < arr2.Length; i++)
                                    {
                                        int countCh = 0;
                                        foreach (string ch in listCh)
                                        {
                                            if (ch == arr2[i]) countCh++;
                                        }
                                        if (countCh <= 0) listCh.Add(arr2[i]);
                                    }
                                    decimal like = 0;
                                    foreach (string ch in listCh)
                                    {
                                        int C1 = new Regex(ch).Matches(str1).Count;
                                        int C2 = new Regex(ch).Matches(str2).Count;
                                        decimal F1 = C1 / (decimal)str1.Length;
                                        decimal F2 = C2 / (decimal)str2.Length;
                                        if (F1 > 0 && F2 > 0)
                                        {
                                            if (F1 > F2) like += F2 / F1 / listCh.Count;
                                            if (F2 > F1) like += F1 / F2 / listCh.Count;

                                        }
                                    }
                                    if (like >= (decimal)0.6)
                                    {
                                        newCode = impData.returnNullInt(row[ds.Taxes_ved.idColumn]);
                                        break;
                                    }

                                }
                            }
                        }
                        if (newCode > 0) { isMatch = true; }
                    }
                return isMatch;
            }
            private string[] returnArrayFromString(string str)
            {
                string[] arr = new string[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    arr[i] = str[i].ToString();
                }
                return arr;
            }
            private void setValueInRow(DataRow row)
            {

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
            private int defineFullDelta(int source, int interval)
            {
                int val = 0;
                int countDelta = 0;
                if (interval <= 12)
                {
                    countDelta = 12 - interval;
                }
                if (interval > 12)
                {
                    countDelta = interval - 12;
                }
                int intervalDelta = countDelta;
                if (source > 0)
                {
                    float delta = source / interval * countDelta;
                    val = Convert.ToInt32(delta);
                }
                else { val = 0; }
                if (interval <= 12)
                {
                    val = val + source;
                }
                if (interval > 12)
                {
                    val = source - val;
                }
                return val;
            }
            private float defineDelta(int source, int interval)
            {
                float delta = 0;

                delta = source / interval;

                return delta;
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
