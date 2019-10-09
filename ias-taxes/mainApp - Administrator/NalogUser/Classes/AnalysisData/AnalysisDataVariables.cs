using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace NalogUser.Classes.AnalysisData
{
    public class AnalysisDataVariables
    {
        #region Переменные
        private Core cr;
        private AnalysisData analysData;
        private Classes.Data.Base b;
        private Classes.Data.Base._BaseSql bSql;
        private Classes.Data.Base._BaseOleDb bOleDb;
        private int idReport = 0;
        private int indexIdReport = 0;
        private int idReportXML = 0;
        private bool addZeroToReport = false;
        private string nameReport = "";
        private string nameParam = "";
        private string[] arrayParamsXML;
        private int currentIdReportXML = 0;
        private string nameTextReport = "";
        private string strNameTextSelectedTax = "";
        private string strNameTextSelectedEea = "";
        //
        private string strDistrict="";
        private string strSubject = "";
        private string[] strSubjects;
        private string strTax = "";
        private string strEea = "";
        private string strYears = "";
        private string[] nameTypeSpreadings = new string[] { "Равномерный", "Нормальный", "Экспоненциальное", "Хи-квадрат", "Стьюдент", "Фишер", "Эрланг", "Логистическое", "Парето", "Логнормальное" };
        //
        #region XML
        private DataSet dsXml;
        private XmlDocument xmlDoc;
        private string xmlTableName = "Reports";
        private string xmlElementReportNameBase = "ReportNameBase";
        private string xmlElementReportName = "ReportName";
        private string xmlElementReportDataSetName = "ReportDataSetName";
        private string xmlElementReportExtention = "ReportExtention";
        private string xmlElementTableDataNameBase = "TableDataNameBase";
        private string xmlElementSQL = "SQL";
        private string xmlElementOrderBy = "OrderBy";
        private string xmlElementType = "Type";
        private string xmlElementCountField = "CountField";
        private string xmlElementForMap = "ForMap";
        private string xmlElementParametres = "Parameters";
        private string xmlElementValues = "values";
        private string xmlElementMainTable = "TableMain";
        private string xmlElementLineFilter = "LineFilter";
        private string xmlElementYearFilter = "YearFilter";
        private string xmlElementIsDirect = "IsDirect";
        private string xmlElementYearsOperationSigns = "YearsOperationSigns";
        #endregion XML
        //
        //SPREADING
        private int countIntervals = 10;
        //
        private bool isIdDistrict = false;
        private int idDistrict = 0;
        private int[] idsDistricts;
        private bool isIdSubject = false;
        private int idSubject = 0;
        private int[] idsSubjects;
        private bool isIdTax = false;
        private int idTax = 0;
        private int[] idsTaxes;
        private bool isIdEea = false;
        private int idEea = 0;
        private int[] idsEea;
        private bool isYears = false;
        private short yearAfter;
        private short yearBefore;
        private List<short> arrYears = new List<short>();
        private List<string> arrFederalDistricts = new List<string>();
        private float error = 0.01f;
        private string headFrmReport = "";
        private int reportIndex = 0;
        private string activeColSourceTable = "";
        private string activeColSourceTableText = "";
        private DataSet sourceDataSet = new DataSet();
        private DataTable sourceTable = new DataTable();
        private List<string> errorList = new List<string>();

        #region Глобальные
        public int IdReport
        {
            get
            {
                return idReport;
            }
            set
            {

                idReport = value;
                if (cr.AnalysData.Ds.Reports.Rows.Count < 1)
                {
                    cr.AnalysData.ReportsTableAdapter.Fill(analysData.Ds.Reports);
                    DataRow[] row = analysData.Ds.Reports.Select("id=" + idReport);
                    nameReport = row[0][analysData.Ds.Reports.code_nameColumn].ToString();
                    addZeroToReport = analysData.returnNullBool(row[0]["add_zero"]);
                }
                else
                {
                    DataRow[] row = analysData.Ds.Reports.Select("id=" + idReport);
                    nameReport = row[0][analysData.Ds.Reports.code_nameColumn].ToString();
                    addZeroToReport = analysData.returnNullBool(row[0]["add_zero"]);
                }
                idReportXML = 0;
                for(int i=0;i<dsXml.Tables[xmlTableName].Rows.Count;i++) 
                {
                    if (nameReport == dsXml.Tables[xmlTableName].Rows[i][xmlElementReportNameBase].ToString())
                    {
                        idReportXML = i;
                    }
                }
                string strParams = dsXml.Tables[xmlTableName].Rows[idReportXML][xmlElementValues].ToString();
                strParams = strParams.Trim();
                strParams = strParams.Replace("\\","");
                strParams = strParams.Replace("=", "");
                strParams = strParams.Replace('"', ' ');
                strParams = strParams.Replace(" ", "");
                arrayParamsXML = strParams.Split(',');
            }
        }
        public int IndexIdReport { get { return indexIdReport; } set { indexIdReport = value; } }
        public int IdReportXML { get { return idReportXML; } set { idReportXML = value; } }
        public bool AddZeroToReport { get { return addZeroToReport; } set { addZeroToReport = value; } }
        public string NameReport { get { return nameReport; } set { nameReport = value; } }
        public string NameParam { get { return nameParam; } set { nameParam = value; } }
        public string[] ArrayParamsXML { get { return arrayParamsXML; } }
        public int CurrentIdReportXML { get { return currentIdReportXML; } }
        public string NameTextReport { get { return nameTextReport; } set { nameTextReport = value; } }
        //
        public string StrDistrict { get { return strDistrict; } set { strDistrict = value; } }
        public string StrSubject { get { return strSubject; } set { strSubject = value; } }
        public string StrTax { get { return strTax; } set { strTax = value; } }
        public string StrEea { get { return strEea; } set { strEea = value; } }
        public string StrYears { get { return strYears; } set { strYears = value; } }
        public string StrNameTextSelectedTax { get { return strNameTextSelectedTax; } set { strNameTextSelectedTax = value; } }
        public string StrNameTextSelectedEea { get { return strNameTextSelectedEea; } set { strNameTextSelectedEea = value; } }
        //
        //
        //SPREADING
        public int CountIntervals { get { return countIntervals; } set { countIntervals = value; } }
        //
        public DataSet DsXml { get { return dsXml; } set { dsXml = value; } }
        public XmlDocument XmlDoc { get { return xmlDoc; } set { xmlDoc = value; } }
        public string XmlTableName { get { return xmlTableName; } }
        public string XmlElementReportNameBase { get { return xmlElementReportNameBase; } }
        public string XmlElementReportName { get { return xmlElementReportName; } }
        public string XmlElementReportDataSetName { get { return xmlElementReportDataSetName; } }
        public string XmlElementReportExtention { get { return xmlElementReportExtention; } }
        public string XmlElementTableDataNameBase { get { return xmlElementTableDataNameBase; } }
        public string XmlElementSQL { get { return xmlElementSQL; } }
        public string XmlElementOrderBy { get { return xmlElementOrderBy; } }
        public string XmlElementType { get { return xmlElementType; } }
        public string XmlElementCountField { get { return xmlElementCountField; } }
        public string XmlElementForMap { get { return xmlElementForMap; } }
        public string XmlElementParametres { get { return xmlElementParametres; } }
        public string XmlElementMainTable { get { return xmlElementMainTable; } }
        public string XmlElementLineFilter { get { return xmlElementLineFilter; } }
        public string XmlElementYearFilter { get { return xmlElementYearFilter; } }
        public string XmlElementIsDirect { get { return xmlElementIsDirect; } }
        public string XmlElementYearsOperationSigns { get { return xmlElementYearsOperationSigns; } }
        //
        public bool IsIdDistrict { get { return isIdDistrict; } set { isIdDistrict = value; } }
        public int IdDistrict { get { return idDistrict; } set { idDistrict = value; if (idDistrict > 0 && !isIdDistrict) isIdDistrict = true; } }
        public int[] IdsDistricts { get { return idsDistricts; } set { idsDistricts = value; if (idsDistricts != null) { if (idsDistricts.Length > 0) { idDistrict = idsDistricts[0]; } } } }
        public bool IsIdSubject { get { return isIdSubject; } set { isIdSubject = value; } }
        public int IdSubject{get { return idSubject; }set { idSubject = value; if (idSubject > 0 && !isIdSubject) isIdSubject = true; }}
        public int[] IdsSubjects
        {
            get { return idsSubjects; }
            set
            {
                idsSubjects = value;
                if (idsSubjects != null)
                {
                    if (idsSubjects.Length > 0) { idSubject = idsSubjects[0]; }
                }
            }
        }
        public string[] StrSubjects { get { return strSubjects; } set { strSubjects = value; } }
        public bool IsIdTax { get { return isIdTax; } set { isIdTax = value; } }
        public int IdTax { get { return idTax; } set { idTax = value; if (idTax > 0 && !isIdTax)isIdTax = true; } }
        public int[] IdsTaxes { get { return idsTaxes; } set { idsTaxes = value; if (idsTaxes != null) { if (idsTaxes.Length > 0) { idTax = idsTaxes[0]; } } } }
        public bool IsIdEea { get { return isIdEea; } set { isIdEea = value; } }
        public int IdEea { get { return idEea; } set { idEea = value; if (idEea > 0 && !isIdEea)isIdEea = true; } }
        public int[] IdsEea { get { return idsEea; } set { idsEea = value; if (idsEea != null) { if (idsEea.Length > 0) { idEea = idsEea[0]; } } } }
        public bool IsYears { get { return isYears; } set { isYears = value; } }
        public short YearAfter { get { return yearAfter; } set { yearAfter = value; } }
        public short YearBefore { get { return yearBefore; } set { yearBefore = value; } }
        public float Error { get { return error; } set { error = value; } }
        public DataTable SourceTable { get { return sourceTable; } set { sourceTable = value; } }
        public DataSet SourceDataSet { get { return sourceDataSet; } set { sourceDataSet = value; } }
        public string HeadFrmReport { get { return headFrmReport; } set { headFrmReport = value; } }
        public int ReportIndex { get { return reportIndex; } set { reportIndex = value; } }
        public string ActiveColSourceTable { get { return activeColSourceTable; } set { activeColSourceTable = value; } }
        public string ActiveColSourceTableText { get { return activeColSourceTableText; } set { activeColSourceTableText = value; } }
        public List<short> ArrYears { get { return arrYears; } set { arrYears = value; } }
        public List<string> ArrFederalDistricts { get { return arrFederalDistricts; } set { arrFederalDistricts = value; } }
        public List<string> ErrorList { get { return errorList; } set { errorList = value; } }
        public string[] NameTypeSpreadings { get { return nameTypeSpreadings; } }
        #endregion Глобальные
        #endregion Переменные
        #region Конструктор
        public AnalysisDataVariables(Core Cr, AnalysisData AnalysData)
        {
            this.cr = Cr;
            this.analysData = AnalysData;
            b = new Data.Base(this);
            if (b.IsSql)
            {
                bSql = b.BaseSql;
                arrYears = bSql.defineMaxMinYear();
            }
            if (b.IsOledb)
            {
                bOleDb = b.BaseOleDb;
                arrYears = bOleDb.defineMaxMinYear();
            }
            yearAfter = MinYear();
            yearBefore = MaxYear();
        }
        public AnalysisDataVariables()
        {
            b = new Data.Base(this);
            if (b.IsSql)
            {
                bSql = b.BaseSql;
                arrYears = bSql.defineMaxMinYear();
            }
            if (b.IsOledb)
            {
                bOleDb = b.BaseOleDb;
                arrYears = bOleDb.defineMaxMinYear();
            }
            
            //yearAfter = 2008;
            //yearBefore = 2008;
        }
        private short MaxYear()
        {
            short year=0;
            if (arrYears.Count > 0)
            {
                year = arrYears[arrYears.Count - 1];
            }
            else
            {
                year = (short)DateTime.Today.Year;
            }
            for (int i = 0; i < arrYears.Count; i++)
            {
                if (arrYears[i] > year)
                {
                    year = arrYears[i];
                }
            }
            return year;
        }
        private short MinYear()
        {
            short year = 0;
            if (arrYears.Count > 0)
            {
                year = arrYears[0];
            }
            else
            {
                year = (short)DateTime.Today.Year;
            }
            for (int i = 0; i < arrYears.Count; i++)
            {
                if (arrYears[i] < year)
                {
                    year = arrYears[i];
                }
            }
            return year;
        }
        #endregion Конструктор
        private void defineNameReport()
        {
        }
    }
    public class ColumnNames
    {
        public ColumnNames()
        {
            subject_total_ti = new _subject_total_ti();
            district_name = new _district_name();
            district_latin_name = new _district_latin_name();
            district_id = new _district_id();
            subject_id = new _subject_id();
            subject_name = new _subject_name();
            subject_short_name = new _subject_short_name();
            subject_latin_name = new _subject_latin_name();
            kdol = new _kdol();
            kdol_eea = new _kdol_eea();
            rmit_eea = new _rmit_eea();
            ti_tax = new _ti_tax();
            subject_ti_eea = new _subject_ti_eea();
        }
        private _subject_total_ti subject_total_ti;
        private _district_name district_name;
        private _district_latin_name district_latin_name;
        private _district_id district_id;
        private _subject_id subject_id;
        private _subject_name subject_name;
        private _subject_short_name subject_short_name;
        private _subject_latin_name subject_latin_name;
        private _kdol kdol;
        private _kdol_eea kdol_eea;
        private _rmit_eea rmit_eea;
        private _ti_tax ti_tax;
        private _subject_ti_eea subject_ti_eea;
        //
        //private 


        public _subject_total_ti Subject_total_ti { get { return subject_total_ti; } }
        public _district_name District_name { get { return district_name; } }
        public _district_latin_name District_latin_name { get { return district_latin_name; } }
        public _district_id District_id { get { return district_id; } }
        public _subject_id Subject_id { get { return subject_id; } }
        public _subject_name Subject_name { get { return subject_name; } }
        public _subject_short_name Subject_short_name { get { return subject_short_name; } }
        public _subject_latin_name Subject_latin_name { get { return subject_latin_name; } }
        public _kdol Kdol { get { return kdol; } }
        public _kdol_eea Kdol_eea { get { return kdol_eea; } }
        public _rmit_eea Rmit_eea { get { return rmit_eea; } }
        public _ti_tax Ti_tax { get { return ti_tax; } }
        public _subject_ti_eea Subject_ti_eea { get { return subject_ti_eea; } }

        public class _subject_total_ti
        {
            public string nameSQL = "total_ti_subject";
            public string nameCol = "НД";
        }
        public class _district_latin_name
        {
            public string nameSQL = "latin_name";
            public string nameCol = "Округ латиница";
        }
        public class _district_name
        {
            public string nameSQL = "district_name";
            public string nameCol = "ФО";
        }
        public class _district_id
        {
            public string nameSQL = "id_district";
            public string nameCol = "Код ФО";
        }
        public class _subject_id
        {
            public string nameSQL = "id_subject";
            public string nameCol = "Код Суб";
        }
        public class _subject_name
        {
            public string nameSQL = "subject_name";
            public string nameCol = "Субъект";
        }
        public class _subject_short_name
        {
            public string nameSQL = "short_name";
            public string nameCol = "Субъект сокр.";
        }
        public class _subject_latin_name
        {
            public string nameSQL = "latin_name";
            public string nameCol = "Субъект латиница";
        }
        public class _kdol
        {
            public string nameSQL = "kdol";
            public string nameCol = "кДол";
        }
        public class _kdol_eea
        {
            public string nameSQL = "kdol_eea";
            public string nameCol = "кДол";
        }
        public class _rmit_eea
        {
            public string nameSQL = "rmit_eea";
            public string nameCol = "ОПИН";
        }
        public class _ti_tax
        {
            public string nameSQL = "sum_ti_subjects";
            public string nameCol = "НД";
        }
        public class _subject_ti_eea
        {
            public string nameSQL = "ti_eea";
            public string nameCol = "НД ВЭД";
        }

        /*public string typeTable(DataTable dt)
        {
            string type = "";
            foreach (DataColumn dc in dt)
            {

            }
            return type;
        }*/
    }
}
