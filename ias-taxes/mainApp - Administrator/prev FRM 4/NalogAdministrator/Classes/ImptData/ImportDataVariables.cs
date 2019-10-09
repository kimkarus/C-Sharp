using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.Xml;
using System.IO;

namespace NalogAdministrator.Classes.ImpData
{
    public class ImportDataVariables
    {
        #region Переменные
        private string connString = "";
        private DataTable internalTable;
        private DataTable agregationTable;
        private DataTable sourceTable;
        private DataTable time;
        private ImportData impData;
        private Core cr;
        private Excel.Application xlApp; //приложение ексель
        private Excel.Workbook xlWorkBook; //книга
        private Excel.Worksheet xlWorkSheet; //лист
        private Excel.Range xlRange; // ячейка
        private object misValue = System.Reflection.Missing.Value;
        private bool methExcel = false;
        private bool filledTable1NOM = false;
        private bool filledTable1NM = false;
        private bool filledTable4NM = false;
        private bool filledTable5ENVD = false;
        private bool filledTable5USN = false;
        private bool filledTable1PATENT = false;
        private bool filledTaleTaxesVed = false;
        private bool filledTaleTaxes = false;
        private bool filledTaleDebts = false;
        //private Data data;
        private ArrayList libraryFiles;
        private ArrayList libraryFolderFiles = new ArrayList();
        private DataRow row;
        private List<int[]> listOfIdsSubjects;
        private List<int[]> listOfIdsTaxes;
        //
        private bool isIdDistrict = false;
        private int idDistrict = 0;
        private bool isIdSubject = false;
        private int idSubject = 0;
        private bool isIdTax = false;
        private int idTax = 0;
        private bool isIdEea = false;
        private int idEea = 0;
        private int idDebt = 0;
        private bool isIdDebt = false;
        private bool isYears = false;
        private int idTime = 0;
        private int idTypeModel = 0;
        private string nameTypeModel = "";
        private int forecastPeriod = 0;
        private short yearAfter = 2006;
        private short yearBefore = 2012;
        private int countIntervals = 0;
        private int indexHeaderRow = 0;
        private int indexHeaderCol = 0;
        private int devideMultiplyValue = 0;
        private bool isDevideValue = false;
        private bool isMultiplyValue = false;
        //
        #region Мудули
        private int idSubjNow = 0; //индекс субъекта
        private int parentIdSubjNow = 0; //индекс Родителя субъекта
        private int yearNow = 0; //указатель года
        private int codeTax = 0;
        private string status = ""; //статус модуля добавления
        private string statusApp = ""; //статус главного окна
        private string memStatus = "";
        private int indexRecord = 0;
        private int countRecords = 0;
        private int countFiles = 0;
        private int indexFile = 0;
        private int codeIndexFile = 0;
        private int idDistrictNow = 0;
        private string nameDistrictNow = "";
        private string nameSubjectNow = "";
        private string nameSheetNow = "";
        private string typeReportNow = "";
        private string ucName = "";
        private string ucTag = "";
        private string[] nameSheets;
        private string tableAdapterMethod = "";
        private bool isImportOneList = false;
        private bool isSheetTaxCode = false;
        private bool addByListOfSubject = false;
        private string selectFolder = "";
        private List<string> nameDt = new List<string>(); //латинское название таблиц
        private List<List<int>> years = new List<List<int>>(); //список лет
        private List<int> yearList = new List<int>();
        private List<List<int>> taxes_eea = new List<List<int>>();
        private List<string[,]> listTaxesColsIds = new List<string[,]>();
        private int indexSection = 0;
        private int countSection = 0;
        private string pathSourceFolder = "";
        private int indexCol = 0;
        private short chYearAfter = 0;
        private short chYearBefore = 0;
        private bool ch1NM = true;
        private bool ch4NM = true;
        private bool ch5ENVD = true;
        private bool ch5USN = true;
        private bool ch1PATENT = true;
        private bool ch1NOM = true;
        private bool chAllInOne = false;
        private bool chForcast = false;
        private int forcastInterval = 0;
        private string pathFile = "";
        private string[] modules = new string[2] { "poppulation_simple", "population_eea" };
        
        private bool isListOfTaxes = false;
        private int checkedId = -1;
        private string sourceTableName = "";
        private int codeBudget = 0;
        #endregion Модули
        #endregion Переменные
        public ImportDataVariables(Core Cr, ImportData ImpData)
        {
            this.cr = Cr;
            this.impData = ImpData;
            fillProperties();
        }
        #region Глобальные
        

        public DataTable InternalTable { get { return internalTable; } set { internalTable = value; } }
        public DataTable AgregationTable { get { return agregationTable; } set { agregationTable = value; } }
        public DataTable SourceTable { get { return sourceTable; } set { sourceTable = value; } }
        public DataTable Time { get { return time; } set { time = value; } }
        public string[] ExcelSheets { get { return loadExcelSheets(); } }
        public string ConnString { get { return connString; } set { connString = value; } }
        public ArrayList LibraryFiles { get { return libraryFiles; } set { libraryFiles = value; } }
        public ArrayList LibraryFolderFiles {
            get
            {
                //impData.GetListFolderFiles(selectFolder);
                return libraryFolderFiles;
            }
            set { libraryFolderFiles = value; } }
        public List<int[]> ListOfIdsSubjects { get { getListOfIdsSubjects(); return listOfIdsSubjects; } }
        public bool MethExcel { get { return methExcel; } set { methExcel = value; } }
        public int IndexSection { get { return indexSection; }
            set 
            {
                if (value != indexSection)
                {
                    countSection++;
                }
                indexSection = value;
            } 
        }
        public int CountSection { get { return countSection; } set { countSection = value; } }
        public string PathFile { get { return pathFile; } set { pathFile = value; } }
        #region Модули
        public int IdSubjNow { get { return idSubjNow; } set { idSubjNow = value; } }
        public int ParentIdSubjNow { get { return parentIdSubjNow; } set { parentIdSubjNow = value; } }
        public int IdDistrictNow { get { return idDistrictNow; } set { idDistrictNow = value; } }
        public int CodeTax { get { return codeTax; } set { codeTax = value; } }
        public int YearNow 
        {
            get { return yearNow; }
            set { yearNow = value; cr.ImportData.EveChYear(value.ToString()); } 
        }
        public int IndexRecord
        {
            get { return indexRecord; }
            set
            {
                indexRecord = value;
                cr.ImportData.EveChIndexRec(value);
            }
        }
        public int CountRecords
        {
            get { return countRecords; }
            set
            {
                countRecords = value;
                cr.ImportData.EveDefCountRec(value);
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (memStatus != status)
                {
                    cr.ImportData.EveChStatus(value, false);
                }

            }
        }
        public string StatusApp
        {
            get { return statusApp; }
            set
            {
                statusApp = value;
                if (memStatus != statusApp)
                {
                    cr.EveChStatus(value, false);
                }

            }
        }
        public int IndexFile
        {
            get { return indexFile; }
            set
            {
                indexFile = value;
                if (value < countFiles)
                {
                    cr.ImportData.EveChIndexFile(value, countFiles);
                }
            }
        }
        public int CountFiles
        {
            get { return CountFiles; }
            set
            {
                countFiles = value;
                cr.ImportData.EveChCountFiles(value);
            }
        }
        public string NameDistrictNow
        {
            get { return nameDistrictNow; }
            set { nameDistrictNow = value; cr.ImportData.EveChNameDistrict(value); }
        }
        public string NameSubjectNow
        {
            get { return nameSubjectNow; }
            set { nameSubjectNow = value; cr.ImportData.EveChNameSubject(value); }
        }
        public string NameSheetNow
        {
            get { return nameSheetNow; }
            set { nameSheetNow = value; cr.ImportData.EveChNameSheet(value); }
        }
        public string TypeReportNow
        {
            get { return typeReportNow; }
            set
            {
                typeReportNow = value;
                cr.ImportData.EveChTypeReport(value);
            }
        }
        public string TableAdapterMethod { get { return tableAdapterMethod; } set { tableAdapterMethod = value; } }
        public string UcName { get { return ucName; } set { ucName = value; } }
        public string UcTag { get { return ucTag; } set { ucTag = value; } }
        public List<List<int>> Years { get { return years; } set { years = value; } }
        public List<int> YearsList { get { return yearList; } set { yearList = value; } }
        public List<List<int>> Taxes_eea { get { return taxes_eea; } set { taxes_eea = value; } }
        public List<string[,]> ListTaxesColsIds { get { return listTaxesColsIds; } set { listTaxesColsIds = value; } }
        public string[] NameSheets { get { return nameSheets; } set { nameSheets = value; } }
        public List<int[]> ListOfIdsTaxes { get { getListOfIdsTaxes();  return listOfIdsTaxes; } }
        public bool IsListOfTaxes { get { return isListOfTaxes; } set { isListOfTaxes = value; } }
        public bool IsSheetTaxCode { get { return isSheetTaxCode; } set { isSheetTaxCode = value; } }
        public bool AddByListOfSubject { get { return addByListOfSubject; } set { addByListOfSubject = value; } }
        public string SelectFolder { get { return selectFolder; } set { selectFolder = value; } }
        public int CodeIndexFile { get { return codeIndexFile; } set { codeIndexFile = value; } }
        public int IndexCol { get { return indexCol; } set { indexCol = value; } }
        public string PathSourceFolder { get { return pathSourceFolder; } set { pathSourceFolder=value; } }
        public short ChYearAfter { get { return chYearAfter; } set { chYearAfter = value; } }
        public short ChYearBefore { get { return chYearBefore; } set { chYearBefore = value; } }
        public bool Ch1NM { get { return ch1NM; } set { ch1NM = value; } }
        public bool Ch4NM { get { return ch4NM; } set { ch4NM = value; } }
        public bool Ch5ENVD { get { return ch5ENVD; } set { ch5ENVD = value; } }
        public bool Ch5USN { get { return ch5USN; } set { ch5USN = value; } }
        public bool Ch1PATENT { get { return ch1PATENT; } set { ch1PATENT = value; } }
        public bool Ch1NOM { get { return ch1NOM; } set { ch1NOM = value; } }
        public bool ChAllInOne { get { return chAllInOne; } set { chAllInOne = value; } }
        public bool ChForcast { get { return chForcast; } set { chForcast = value; } }
        public bool IsImportOneList { get { return isImportOneList; } set { isImportOneList = value; } }
        public int ForcastInterval { get { return forcastInterval; } set { forcastInterval = value; } }
        public bool FilledTable1NOM { get { return filledTable1NOM; } set { filledTable1NOM = value; } }
        public bool FilledTable1NM { get { return filledTable1NM; } set { filledTable1NM = value; } }
        public bool FilledTable4NM { get { return filledTable4NM; } set { filledTable4NM = value; } }
        public bool FilledTable1PATENT { get { return filledTable1PATENT; } set { filledTable1PATENT = value; } }
        public bool FilledTableTaxesVed { get { return filledTaleTaxesVed; } set { filledTaleTaxesVed = value; } }
        public bool FilledTableTaxes { get { return filledTaleTaxes; } set { filledTaleTaxes = value; } }
        public bool FilledTableDebts { get { return filledTaleDebts; } set { filledTaleDebts = value; } }
        public string[] Modules { get { return modules; } set { modules = value; } }
        public int CheckedId { get { return checkedId; } set { checkedId = value; } }
        public string SourceTableName { get { return sourceTableName; } set { sourceTableName = value; } }
        public bool IsIdDistrict { get { return isIdDistrict; } set { isIdDistrict = value; } }
        public int IdDistrict { get { return idDistrict; } set { idDistrict = value; if (idDistrict > 0 && !isIdDistrict) isIdDistrict = true; } }
        public bool IsIdSubject { get { return isIdSubject; } set { isIdSubject = value; } }
        public int IdSubject { get { return idSubject; } set { idSubject = value; if (idSubject > 0 && !isIdSubject) isIdSubject = true; } }
        public int IdTime { get { return idTime; } set { idTime = value; } }
        public int IdTypeModel { get { return idTypeModel; } set { idTypeModel = value; } }
        public string NameTypeModel { get { return nameTypeModel; } set { nameTypeModel = value; } }
        public int ForecastPeriod { get { return forecastPeriod; } set { forecastPeriod = value; } }
        public bool IsIdTax { get { return isIdTax; } set { isIdTax = value; } }
        public int IdTax { get { return idTax; } set { idTax = value; if (idTax > 0 && !isIdTax)isIdTax = true; } }
        public bool IsIdEea { get { return isIdEea; } set { isIdEea = value; } }
        public int IdEea { get { return idEea; } set { idEea = value; if (idEea > 0 && !isIdEea)isIdEea = true; } }
        public bool IsYears { get { return isYears; } set { isYears = value; } }
        public short YearAfter { get { return yearAfter; } set { yearAfter = value; } }
        public short YearBefore { get { return yearBefore; } set { yearBefore = value; } }
        public int CountIntervals { get { return countFiles; } set { countFiles = value; } }
        public int IndexHeaderRow { get { return indexHeaderRow; } set { indexHeaderRow = value; } }
        public int IndexHeaderCol { get { return indexHeaderCol; } set { indexHeaderCol = value; } }
        public int CodeBudget { get { return codeBudget; } set { codeBudget = value; } }
        public int DevideMultiplyValue { get { return devideMultiplyValue; } set { devideMultiplyValue = value; } }
        public bool IsDevideValue { get { return isDevideValue; } set { isDevideValue = value; } }
        public bool IsMultiplyValue { get { return isMultiplyValue; } set { isMultiplyValue = value; } }
        #endregion Модули
        #endregion Глобальные
        private string[] loadExcelSheets()
        {
            string[] sheets = new string[cr.Data.Files.DtExcelMeta.Rows.Count];
            for (int i = 0; i < sheets.Length; i++)
            {
                sheets[i] = cr.Data.Files.DtExcelMeta.Rows[i][2].ToString();
            }
            return sheets;
        }
        public void OpenExcelList()
        {
            
        }
        public void TakeIntervalFromExcel(string path)
        {
            string sheet = "";
            if (xlWorkBook == null || path.Length > 0)
            {
                try
                {
                    xlWorkBook = xlApp.Workbooks.Open(path, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                }
                catch (System.Exception ex)
                {
                    cr.Log = new Log(cr, ex.ToString());
                }
            }
        }
        public void OpenExcelSheet(string sheet, int l)
        {
            //try
            //{
           
            int error = 0;
            if (xlWorkBook == null) TakeIntervalFromExcel(cr.ImportData.ImpDataFile.FileFullPath);
            try
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[sheet];
            }
            catch(System.Exception err)
            {
                error = 1;
            }
            if (error <= 0)
            {
                //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[@strExcelTable];
                xlRange = xlWorkSheet.UsedRange;
                if (xlRange != null || xlRange.Rows.Count > 1)
                {
                    internalTable = new DataTable();
                    object[,] valueArray = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
                    for (int j = 0; j < xlRange.Columns.Count; j++)
                    {
                        internalTable.Columns.Add((j + 1).ToString(), typeof(string));
                    }
                    for (int i = 0; i < xlRange.Rows.Count; i++)
                    {
                        row = internalTable.NewRow();
                        for (int j = 0; j < xlRange.Columns.Count; j++)
                        {
                            if (valueArray != null && valueArray.GetValue(i + 1, j + 1) != null)
                            {
                                row[j] = valueArray.GetValue(i + 1, j + 1).ToString();
                            }
                        }
                        internalTable.Rows.Add(row);
                    }
                }
            }
        }
        public void TakeIntervalOleDb(string path, string sheet)
        {
            cr.Data.Files.ExcelOleDbConn = new System.Data.OleDb.OleDbConnection(cr.Data.Files.connectionString(path));
            cr.Data.Files.ExcelOleDbConn.Open();
            cr.Data.Files.ExcelAdapter = new System.Data.OleDb.OleDbDataAdapter("Select * from [" + sheet + "];", cr.Data.Files.ExcelOleDbConn);
            cr.Data.Files.ExcelOleDbConn.Close();
            InternalTable = null;
            InternalTable = new DataTable();
            try
            {
                cr.Data.Files.ExcelAdapter.Fill(InternalTable);
            }
            catch (System.Exception err)
            {
            }
        }
        private void fillProperties()
        {
            /*
             * */

        }
        public void CloseExcelBook()
        {
            try
            {
                xlWorkBook.Close(true, misValue, misValue);
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
            }
            catch (System.Exception err)
            {
            }
        }
        public void CloseExcelAppl()
        {
            /*
             * Метод для завершения работы с файлом и его закрытие
             * */
            try
            {
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (System.Exception err)
            {
            }
        }
        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                string err = "Unable to release the Object " + ex.ToString();
            }
            finally
            {
                GC.Collect();
            }
        }
        public void OpenXlApp()
        {
            xlApp = new Excel.ApplicationClass();
        }
        private void getListOfIdsSubjects()
        {
            string pathDirectoryApp =  Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pathAgregationConfig = pathDirectoryApp + "\\Configs\\ImportReports.config";
            string confTable = "configuration";
            string[] list = { "0" };
            DataSet dsXml = new DataSet();
            dsXml.ReadXml(pathAgregationConfig);
            DataTable dt = dsXml.Tables[confTable];
            if (dt.Rows.Count > 0)
            {
                list = dt.Rows[0]["listOfIdsSubjects"].ToString().Split(';');
            }
            listOfIdsSubjects = new List<int[]>();
            foreach (string str in list)
            {
                string[] listSub = str.Split(',');
                if (listSub.Length > 1)
                {
                    int[] paramSub = new int[2];
                    paramSub[0] = impData.returnNullInt(listSub[0]);
                    paramSub[1] = impData.returnNullInt(listSub[1]);
                    listOfIdsSubjects.Add(paramSub);
                }
                else
                {
                    int[] paramSub = new int[2];
                    paramSub[0] = impData.returnNullInt(str);
                    paramSub[1] = 0;
                    listOfIdsSubjects.Add(paramSub);
                }
            }
        }
        private void getListOfIdsTaxes()
        {
            string pathDirectoryApp = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pathAgregationConfig = pathDirectoryApp + "\\Configs\\ImportReports.config";
            string confTable = "configuration";
            string[] list = { "0" };
            DataSet dsXml = new DataSet();
            dsXml.ReadXml(pathAgregationConfig);
            DataTable dt = dsXml.Tables[confTable];
            if (dt.Rows.Count > 0)
            {
                list = dt.Rows[0]["listOfIdsTaxes"].ToString().Split(';');
            }
            listOfIdsTaxes = new List<int[]>();
            foreach (string str in list)
            {
                string[] listSub = str.Split(',');
                if (listSub.Length > 1)
                {
                    int[] paramSub = new int[2];
                    paramSub[0] = impData.returnNullInt(listSub[0]);
                    paramSub[1] = impData.returnNullInt(listSub[1]);
                    listOfIdsTaxes.Add(paramSub);
                }
                else
                {
                    int[] paramSub = new int[2];
                    paramSub[0] = impData.returnNullInt(str);
                    paramSub[1] = 0;
                    listOfIdsTaxes.Add(paramSub);
                }
            }
        }
    }
}
