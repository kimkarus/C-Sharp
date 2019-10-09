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
        private bool filledTaleTaxesVed = false;
        private bool filledTaleTaxes = false;
        //private Data data;
        private ArrayList libraryFiles;
        private ArrayList libraryFolderFiles = new ArrayList();
        private DataRow row;
        private List<int[]> listOfIdsSubjects;
        private List<int[]> listOfIdsTaxes;
        //
        
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
        private bool ch1NOM = true;
        private bool chAllInOne = false;
        private bool chForcast = false;
        private int forcastInterval = 0;
        private string pathFile = "";
        private string[] modules = new string[2] { "poppulation_simple", "population_eea" };
        
        private bool isListOfTaxes = false;
        private int checkedId = -1;
        private string sourceTableName = "";
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
        public string SelectFolder { get { return selectFolder; } set { selectFolder = value; } }
        public int CodeIndexFile { get { return codeIndexFile; } set { codeIndexFile = value; } }
        public int IndexCol { get { return indexCol; } set { indexCol = value; } }
        public string PathSourceFolder { get { return pathSourceFolder; } set { pathSourceFolder=value; } }
        public short ChYearAfter { get { return chYearAfter; } set { chYearAfter = value; } }
        public short ChYearBefore { get { return chYearBefore; } set { chYearBefore = value; } }
        public bool Ch1NM { get { return ch1NM; } set { ch1NM = value; } }
        public bool Ch1NOM { get { return ch1NOM; } set { ch1NOM = value; } }
        public bool ChAllInOne { get { return chAllInOne; } set { chAllInOne = value; } }
        public bool ChForcast { get { return chForcast; } set { chForcast = value; } }
        public bool IsImportOneList { get { return isImportOneList; } set { isImportOneList = value; } }
        public int ForcastInterval { get { return forcastInterval; } set { forcastInterval = value; } }
        public bool FilledTable1NOM { get { return filledTable1NOM; } set { filledTable1NOM = value; } }
        public bool FilledTable1NM { get { return filledTable1NM; } set { filledTable1NM = value; } }
        public bool FilledTableTaxesVed { get { return filledTaleTaxesVed; } set { filledTaleTaxesVed = value; } }
        public bool FilledTableTaxes { get { return filledTaleTaxes; } set { filledTaleTaxes = value; } }
        public string[] Modules { get { return modules; } set { modules = value; } }
        public int CheckedId { get { return checkedId; } set { checkedId = value; } }
        public string SourceTableName { get { return sourceTableName; } set { sourceTableName = value; } }
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
                xlWorkBook = xlApp.Workbooks.Open(path, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            }
        }
        public void OpenExcelSheet(string sheet, int l)
        {
            //try
            //{
           
            int error = 0;
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
