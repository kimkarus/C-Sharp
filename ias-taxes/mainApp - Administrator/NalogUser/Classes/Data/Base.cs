using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;

namespace NalogUser.Classes.Data
{
    public class Base
    {
        private _BaseSql baseSql;
        private _BaseOleDb baseOleDb;
        //
        private Classes.AnalysisData.AnalysisDataVariables var;
        private Classes.AnalysisData.AnalysisData anData;
        //
        private string connectionType = "";
        private bool isConnectionTypeOLEDB = false;
        private bool isConnectionTypeSQL = false;

        public _BaseSql BaseSql { get { return baseSql; } set { baseSql = value; } }
        public _BaseOleDb BaseOleDb { get { return baseOleDb; } set { baseOleDb = value; } }
        public bool IsSql { get { return isConnectionTypeSQL; } }
        public bool IsOledb { get { return isConnectionTypeOLEDB; } }
        public Classes.AnalysisData.AnalysisData AnData { get { return anData; } set { anData = null; anData = value; } }
        public Classes.AnalysisData.AnalysisDataVariables Var { get { return var; } set { var = null; var = value; } }
        public Base(Classes.AnalysisData.AnalysisDataVariables Var=null,
                Classes.AnalysisData.AnalysisData AnData=null)
        {
            this.var = Var;
            this.anData = AnData;
            defineConnectionType(NalogUser.App.Default.NameConnectionString.ToString());
        }
        private void defineConnectionType(string type = "")
        {
            if (type == "")
            {
                connectionType = "";
                isConnectionTypeOLEDB = false;
                isConnectionTypeSQL = false;
            }
            if (type == "OLEDB_ACC" || type == "OLEDB_MDB") { isConnectionTypeOLEDB = true; isConnectionTypeSQL = false; }
            if (type == "SQL") { isConnectionTypeSQL = true; isConnectionTypeOLEDB = false; }
            if (isConnectionTypeOLEDB) baseOleDb = new _BaseOleDb(this);
            if (isConnectionTypeSQL) baseSql = new _BaseSql(this);
        }

        public class _BaseSql
        {
            private Base b;
            public _BaseSql(Base B=null)
            {
                this.b = B;
            }
            #region Переменные
            private string[] referenceTables = { "City", "Collected_tax_ved", "Data_view", "Federal_district", "Log", "Report_type", 
                                               "Report_view", "Reports", "Source_data_1NM", "Source_data_1NOM", "Source_data_1NOM_scheme", 
                                               "Source_data_Population", "Source_data_Population_eea", "Source_data_view", "Subject_type", "Subjects",
                                           "Tax_authority", "Taxes", "Taxes_ved", "Taxes_view"," Users"};
            private string[,] referenceFields ={
                                               {"idDistrict", "",""},
                                               {"idSubject","",""},
                                               {"idTax","","",},
                                               {"idEea","",""}
                                          };
            //
            private SqlConnection dbConn;
            private SqlCommand dbCom;
            private SqlDataAdapter dbDataAdp;
            private SqlParameter paramIdDistrict;
            private SqlParameter paramIdSubject;
            private SqlParameter paramYearAfter;
            private SqlParameter paramYearBefore;
            private SqlParameter paramIdTax;
            private SqlParameter paramIdEea;
            //

            //
            private List<SqlParameter> arrayParamsIdsSubject = new List<SqlParameter>();
            //
            public SqlConnection DbConn { get { return dbConn; } set { dbConn = value; } }
            public SqlCommand DbCom { get { return dbCom; } set { dbCom = value; } }
            public SqlDataAdapter DbDataAdp { get { return dbDataAdp; } set { dbDataAdp = value; } }
            //
            public SqlParameter ParamIdDistrict { get { return paramIdDistrict; } set { paramIdDistrict = value; } }
            public SqlParameter ParamIdSubject { get { return paramIdSubject; } set { paramIdSubject = value; } }
            public SqlParameter ParamYearAfter { get { return paramYearAfter; } set { paramYearAfter = value; } }
            public SqlParameter ParamYearBefore { get { return paramYearBefore; } set { paramYearBefore = value; } }
            public SqlParameter ParamIdTax { get { return paramIdTax; } set { paramIdTax = value; } }
            public SqlParameter ParamIdEea { get { return paramIdEea; } set { paramIdEea = value; } }
            //
            public List<SqlParameter> ArrayParamsIdsSubjects { get { return arrayParamsIdsSubject; } set { arrayParamsIdsSubject = value; } }
            #endregion Переменные
            public void defineParameters()
            {
                #region Params
                dbCom.Parameters.Clear();
                if (b.Var.IdDistrict > 0)
                {
                    ParamIdDistrict = new SqlParameter("@ParametrIdDistrict", b.Var.IdDistrict);
                }
                else ParamIdDistrict = null;


                if (b.Var.IdTax > 0)
                {
                    ParamIdTax = new SqlParameter("@ParametrIdTax", b.Var.IdTax);
                }
                else ParamIdTax = null;
                if (b.Var.IdEea > 0)
                {
                    ParamIdEea = new SqlParameter("@ParametrIdEea", b.Var.IdEea);
                }
                else ParamIdEea = null;
                if (b.Var.YearAfter > 0 && b.Var.YearBefore > 0)
                {
                    ParamYearAfter = new SqlParameter("@ParametrYearAfter", b.Var.YearAfter);
                    ParamYearBefore = new SqlParameter("@ParametrYearBefore", b.Var.YearBefore);
                }
                else { ParamYearAfter = null; ParamYearBefore = null; }
                #endregion Params
            }
            public string queryEvent(int index, bool direct = false, string table = "", string lineFilter = "", string yearFilter = "", string yearsSigns = "")
            {
                string lineWhere = "";
                string lineParams = "";
                string line = "";
                b.Var.HeadFrmReport = "";
                int countAnd = -1;
                string strAnd = " AND ";
                setReferenceFields();
                direct = false;
                #region Params
                if (b.Var.IdsSubjects != null)
                {
                    if (arrayParamsIdsSubject.Count > 0 && arrayParamsIdsSubject.Count == 1)
                    {
                        ParamIdSubject = arrayParamsIdsSubject[0];
                    }
                    else if (arrayParamsIdsSubject.Count > 1)
                    {
                        ParamIdSubject = arrayParamsIdsSubject[0];
                    }
                    else ParamIdSubject = null;
                }
                else ParamIdSubject = null;
                #endregion Params
                int oo = 2;
                if (ParamIdDistrict != null || ParamIdSubject != null || ParamIdTax != null || b.Var.IsYears)
                {
                    if (lineFilter.Length < 2)
                    {
                        lineFilter = "WHERE";
                    }
                    lineWhere += " " + lineFilter;
                }
                else
                {
                    //return;
                }
                #region IdDistrict
                if (b.Var.IsIdDistrict && b.Var.IdDistrict > 0 && b.AnData.CheckParam("id_district", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idDistrict") + "=" +
                            ParamIdDistrict.ParameterName + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrDistrict;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idDistrict") + "=" +
                            ParamIdDistrict.ParameterName + ")";
                        b.Var.HeadFrmReport += b.Var.StrDistrict;
                    }
                    countAnd++;
                }
                #endregion IdDistrict
                #region IdSubject
                if (b.Var.IsIdSubject && b.Var.IdSubject > 0 && b.AnData.CheckParam("id_subject", index))
                {
                    if (countAnd >= 0)
                    {
                        if (arrayParamsIdsSubject.Count > 1)
                        {
                            lineParams += strAnd;
                            SqlParameter param0 = (SqlParameter)arrayParamsIdsSubject[0];
                            lineParams += "((" + returnField(direct, "idSubject") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsSubject.Count; i++)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsSubject[i];
                                lineParams += " OR (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            ParamIdSubject = (SqlParameter)arrayParamsIdsSubject[0];
                            lineParams += strAnd + "(" + returnField(direct, "idSubject") + "=" +
                                ParamIdSubject.ParameterName + ")";
                        }
                    }
                    else
                    {
                        if (arrayParamsIdsSubject.Count > 1)
                        {
                            SqlParameter param0 = (SqlParameter)arrayParamsIdsSubject[0];
                            lineParams += "((" + returnField(direct, "idSubject") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsSubject.Count; i++)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsSubject[i];
                                lineParams += " OR (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            ParamIdSubject = (SqlParameter)arrayParamsIdsSubject[0];
                            lineParams += " (" + returnField(direct, "idSubject") + "=" +
                                ParamIdSubject.ParameterName + ")";
                        }
                    }
                    if (b.Var.StrSubjects != null)
                    {
                        b.Var.HeadFrmReport += b.Var.StrSubjects[0];
                        for (int i = 1; i < b.Var.StrSubjects.Length; i++)
                        {
                            b.Var.HeadFrmReport += ", " + b.Var.StrSubjects[i];
                        }
                    }
                    else
                    {
                        b.Var.HeadFrmReport += b.Var.StrSubject;
                    }
                    countAnd++;
                }
                #endregion IdSubject
                #region IdTax
                if (b.Var.IsIdTax && b.Var.IdTax > 0 && b.AnData.CheckParam("id_tax", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idTax") + "=" +
                            ParamIdTax.ParameterName + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrTax;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idTax") + "=" +
                            ParamIdTax.ParameterName + ")";
                        b.Var.HeadFrmReport += b.Var.StrTax;
                    }
                    countAnd++;
                }
                #endregion IdTax
                #region IdEea
                if (b.Var.IsIdEea && b.Var.IdEea > 0 && b.AnData.CheckParam("id_eea", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idEea") + "=" +
                            ParamIdEea.ParameterName + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrEea;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idEea") + "=" +
                            ParamIdEea.ParameterName + ")";
                        b.Var.HeadFrmReport += b.Var.StrEea;
                    }
                    countAnd++;
                }
                #endregion IdTEea
                #region Years
                if (b.Var.YearAfter > 0 && b.Var.YearBefore > 0 && !b.Var.IsYears) b.Var.IsYears = true;
                if (b.Var.IsYears && b.Var.YearAfter > 0 && b.Var.YearBefore > 0)
                {
                    string strYear1 = "year";
                    string strYear2 = "year";
                    if (yearFilter.Length > 1)
                    {
                        string[] arrYearFilter = yearFilter.Split(',');
                        strYear1 = arrYearFilter[0];
                        strYear2 = arrYearFilter[1];
                    }
                    char[] arrYearsSigns = yearsSigns.ToCharArray();
                    if (yearsSigns.Length > 1)
                    {

                    }
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + mainTable(table) + strYear1 + checkYearOperationSign('>', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + ParamYearAfter.ParameterName + ")";
                        lineParams += strAnd + "(" + mainTable(table) + strYear2 + checkYearOperationSign('<', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + ParamYearBefore.ParameterName + ")";
                        countAnd++;
                        b.Var.HeadFrmReport += " " + b.Var.YearAfter.ToString() + " - " + b.Var.YearBefore.ToString();
                    }
                    else
                    {
                        lineParams += "(" + mainTable(table) + strYear1 + checkYearOperationSign('>', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + ParamYearAfter.ParameterName + ")";
                        lineParams += strAnd + "(" + mainTable(table) + strYear2 + checkYearOperationSign('<', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + ParamYearBefore.ParameterName + ")";
                        countAnd++;
                    }

                }
                #endregion Years
                //line += ";";
                if (lineParams.Length > 0)
                {
                    line = lineWhere + lineParams;
                }
                return line;
            }
            public string mainTable(string table)
            {
                string str = "";
                if (table.Length > 0)
                {
                    str = table + ".";
                }
                return str;
            }
            public List<short> defineMaxMinYear()
            {
                short yearMax = 0;
                short yearMin = 0;
                List<short> arr = new List<short>();
                dbConn = new SqlConnection();
                dbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                dbConn.Open();
                dbCom = dbConn.CreateCommand();
                dbCom.CommandText = "SELECT * FROM [tax-177_nalog].View_years";
                dbDataAdp = new SqlDataAdapter(dbCom);
                dbConn.Close();
                DataTable dt = new DataTable();
                dbDataAdp.Fill(dt);
                yearMin = Convert.ToInt16(dt.Rows[0]["year_min"]);
                yearMax = Convert.ToInt16(dt.Rows[0]["year_max"]);
                for (int i = (int)yearMin - 1; i < (int)yearMax; i++)
                {
                    arr.Add((short)(i + 1));
                }
                return arr;
            }
            public bool TestConnection()
            {
                bool test = false;
                dbConn = new SqlConnection();
                dbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                dbConn.Open();
                string serVersion = dbConn.ServerVersion;
                if (serVersion != "")
                {
                    test = true;
                }
                return test;
            }
            public void BuildRequest(string str)
            {
                SqlConnection conn = new SqlConnection(NalogUser.App.Default.ConnectionString.ToString());
                conn.Open();
                SqlCommand com = conn.CreateCommand();
                com.CommandText = str;
                com.ExecuteScalar();
                conn.Close();
            }
            private string returnField(bool direct, string field)
            {
                string sField = "";

                for (int i = 0; i < referenceFields.GetLength(0); i++)
                {
                    if (referenceFields[i, 0] == field)
                    {
                        if (direct)
                        {
                            sField = referenceFields[i, 1].ToString();
                        }
                        else
                        {
                            sField = referenceFields[i, 2].ToString();
                        }
                    }
                }

                return sField;
            }
            private void setReferenceFields()
            {
                referenceFields[0, 1] = "dbo." + b.AnData.Ds.Federal_district.TableName + "." + b.AnData.Ds.Federal_district.idColumn.ColumnName;
                referenceFields[1, 1] = "dbo." + b.AnData.Ds.Subjects.TableName + "." + b.AnData.Ds.Subjects.idColumn.ColumnName;
                referenceFields[2, 1] = "dbo." + b.AnData.Ds.Taxes.TableName + "." + b.AnData.Ds.Taxes.idColumn.ColumnName;
                referenceFields[3, 1] = "dbo." + b.AnData.Ds.Taxes_ved.TableName + "." + b.AnData.Ds.Taxes_ved.idColumn.ColumnName;

                referenceFields[0, 2] = "id_district";
                referenceFields[1, 2] = "id_subject";
                referenceFields[2, 2] = "id_tax";
                referenceFields[3, 2] = "id_eea";
            }
            private string checkYearOperationSign(char sign, char[] signs)
            {
                string str = "";
                char chr = ' ';
                if (signs.Length > 0)
                {
                    if (sign == '>') chr = 'm';
                    if (sign == '<') chr = 'l';
                    if (sign == '=') chr = 'e';
                    //
                    for (int i = 0; i < signs.Length; i++)
                    {
                        if (chr == signs[i]) str = sign.ToString();
                    }
                }
                else
                {
                    str = sign.ToString();
                }
                //
                return str;
            }
        }
        public class _BaseOleDb
        {
            private Base b;
            public _BaseOleDb(Base B)
            {
                this.b = B;
            }
            #region Переменные
            private string[] referenceTables = { "City", "Collected_tax_ved", "Data_view", "Federal_district", "Log", "Report_type", 
                                               "Report_view", "Reports", "Source_data_1NM", "Source_data_1NOM", "Source_data_1NOM_scheme", 
                                               "Source_data_Population", "Source_data_Population_eea", "Source_data_view", "Subject_type", "Subjects",
                                           "Tax_authority", "Taxes", "Taxes_ved", "Taxes_view"," Users"};
            private string[,] referenceFields ={
                                               {"idDistrict", "",""},
                                               {"idSubject","",""},
                                               {"idTax","","",},
                                               {"idEea","",""}
                                          };
            //
            private OleDbConnection dbConn;
            private OleDbCommand dbCom;
            private OleDbDataAdapter dbDataAdp;
            private OleDbParameter paramIdDistrict;
            private OleDbParameter paramIdSubject;
            private OleDbParameter paramYearAfter;
            private OleDbParameter paramYearBefore;
            private OleDbParameter paramIdTax;
            private OleDbParameter paramIdEea;
            //
            private List<OleDbParameter> arrayParamsIdsSubject = new List<OleDbParameter>();
            //
            public OleDbConnection DbConn { get { return dbConn; } set { dbConn = value; } }
            public OleDbCommand DbCom { get { return dbCom; } set { dbCom = value; } }
            public OleDbDataAdapter DbDataAdp { get { return dbDataAdp; } set { dbDataAdp = value; } }
            //
            public OleDbParameter ParamIdDistrict { get { return paramIdDistrict; } set { paramIdDistrict = value; } }
            public OleDbParameter ParamIdSubject { get { return paramIdSubject; } set { paramIdSubject = value; } }
            public OleDbParameter ParamYearAfter { get { return paramYearAfter; } set { paramYearAfter = value; } }
            public OleDbParameter ParamYearBefore { get { return paramYearBefore; } set { paramYearBefore = value; } }
            public OleDbParameter ParamIdTax { get { return paramIdTax; } set { paramIdTax = value; } }
            public OleDbParameter ParamIdEea { get { return paramIdEea; } set { paramIdEea = value; } }
            //
            public List<OleDbParameter> ArrayParamsIdsSubjects { get { return arrayParamsIdsSubject; } set { arrayParamsIdsSubject = value; } }
            #endregion Переменные
            public void defineParameters()
            {
                #region Params
                dbCom.Parameters.Clear();
                if (b.Var.IdDistrict > 0)
                {
                    ParamIdDistrict = new OleDbParameter("@ParametrIdDistrict", b.Var.IdDistrict);
                }
                else ParamIdDistrict = null;


                if (b.Var.IdTax > 0)
                {
                    ParamIdTax = new OleDbParameter("@ParametrIdTax", b.Var.IdTax);
                }
                else ParamIdTax = null;
                if (b.Var.IdEea > 0)
                {
                    ParamIdEea = new OleDbParameter("@ParametrIdEea", b.Var.IdEea);
                }
                else ParamIdEea = null;
                if (b.Var.YearAfter > 0 && b.Var.YearBefore > 0)
                {
                    ParamYearAfter = new OleDbParameter("@ParametrYearAfter", b.Var.YearAfter);
                    ParamYearBefore = new OleDbParameter("@ParametrYearBefore", b.Var.YearBefore);
                }
                else { ParamYearAfter = null; ParamYearBefore = null; }
                #endregion Params
            }
            public string queryEvent(int index, bool direct = false, string table = "", string lineFilter = "", string yearFilter = "", string yearsSigns = "")
            {
                string lineWhere = "";
                string lineParams = "";
                string line = "";
                b.Var.HeadFrmReport = "";
                int countAnd = -1;
                string strAnd = " AND ";
                setReferenceFields();
                direct = false;
                #region Params
                if (b.Var.IdsSubjects != null)
                {
                    if (arrayParamsIdsSubject.Count > 0 && arrayParamsIdsSubject.Count == 1)
                    {
                        ParamIdSubject = arrayParamsIdsSubject[0];
                    }
                    else if (arrayParamsIdsSubject.Count > 1)
                    {
                        ParamIdSubject = arrayParamsIdsSubject[0];
                    }
                    else ParamIdSubject = null;
                }
                else ParamIdSubject = null;
                #endregion Params
                int oo = 2;
                if (ParamIdDistrict != null || ParamIdSubject != null || ParamIdTax != null || b.Var.IsYears)
                {
                    if (lineFilter.Length < 2)
                    {
                        lineFilter = "WHERE";
                    }
                    lineWhere += " " + lineFilter;
                }
                else
                {
                    //return;
                }
                #region IdDistrict
                if (b.Var.IsIdDistrict && b.Var.IdDistrict > 0 && b.AnData.CheckParam("id_district", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idDistrict") + "=" +
                            ParamIdDistrict.ParameterName + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrDistrict;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idDistrict") + "=" +
                            ParamIdDistrict.ParameterName + ")";
                        b.Var.HeadFrmReport += b.Var.StrDistrict;
                    }
                    countAnd++;
                }
                #endregion IdDistrict
                #region IdSubject
                if (b.Var.IsIdSubject && b.Var.IdSubject > 0 && b.AnData.CheckParam("id_subject", index))
                {
                    if (countAnd >= 0)
                    {
                        if (arrayParamsIdsSubject.Count > 1)
                        {
                            lineParams += strAnd;
                            OleDbParameter param0 = (OleDbParameter)arrayParamsIdsSubject[0];
                            lineParams += "((" + returnField(direct, "idSubject") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsSubject.Count; i++)
                            {
                                OleDbParameter param = (OleDbParameter)arrayParamsIdsSubject[i];
                                lineParams += " OR (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            ParamIdSubject = (OleDbParameter)arrayParamsIdsSubject[0];
                            lineParams += strAnd + "(" + returnField(direct, "idSubject") + "=" +
                                ParamIdSubject.ParameterName + ")";
                        }
                    }
                    else
                    {
                        if (arrayParamsIdsSubject.Count > 1)
                        {
                            OleDbParameter param0 = (OleDbParameter)arrayParamsIdsSubject[0];
                            lineParams += "((" + returnField(direct, "idSubject") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsSubject.Count; i++)
                            {
                                OleDbParameter param = (OleDbParameter)arrayParamsIdsSubject[i];
                                lineParams += " OR (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            ParamIdSubject = (OleDbParameter)arrayParamsIdsSubject[0];
                            lineParams += " (" + returnField(direct, "idSubject") + "=" +
                                ParamIdSubject.ParameterName + ")";
                        }
                    }
                    if (b.Var.StrSubjects != null)
                    {
                        b.Var.HeadFrmReport += b.Var.StrSubjects[0];
                        for (int i = 1; i < b.Var.StrSubjects.Length; i++)
                        {
                            b.Var.HeadFrmReport += ", " + b.Var.StrSubjects[i];
                        }
                    }
                    else
                    {
                        b.Var.HeadFrmReport += b.Var.StrSubject;
                    }
                    countAnd++;
                }
                #endregion IdSubject
                #region IdTax
                if (b.Var.IsIdTax && b.Var.IdTax > 0 && b.AnData.CheckParam("id_tax", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idTax") + "=" +
                            ParamIdTax.ParameterName + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrTax;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idTax") + "=" +
                            ParamIdTax.ParameterName + ")";
                        b.Var.HeadFrmReport += b.Var.StrTax;
                    }
                    countAnd++;
                }
                #endregion IdTax
                #region IdEea
                if (b.Var.IsIdEea && b.Var.IdEea > 0 && b.AnData.CheckParam("id_eea", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idEea") + "=" +
                            ParamIdEea.ParameterName + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrEea;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idEea") + "=" +
                            ParamIdEea.ParameterName + ")";
                        b.Var.HeadFrmReport += b.Var.StrEea;
                    }
                    countAnd++;
                }
                #endregion IdTEea
                #region Years
                if (b.Var.YearAfter > 0 && b.Var.YearBefore > 0 && !b.Var.IsYears) b.Var.IsYears = true;
                if (b.Var.IsYears && b.Var.YearAfter > 0 && b.Var.YearBefore > 0)
                {
                    string strYear1 = "year";
                    string strYear2 = "year";
                    if (yearFilter.Length > 1)
                    {
                        string[] arrYearFilter = yearFilter.Split(',');
                        strYear1 = arrYearFilter[0];
                        strYear2 = arrYearFilter[1];
                    }
                    char[] arrYearsSigns = yearsSigns.ToCharArray();
                    if (yearsSigns.Length > 1)
                    {

                    }
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + mainTable(table) + strYear1 + checkYearOperationSign('>', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + ParamYearAfter.ParameterName + ")";
                        lineParams += strAnd + "(" + mainTable(table) + strYear2 + checkYearOperationSign('<', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + ParamYearBefore.ParameterName + ")";
                        countAnd++;
                        b.Var.HeadFrmReport += " " + b.Var.YearAfter.ToString() + " - " + b.Var.YearBefore.ToString();
                    }
                    else
                    {
                        lineParams += "(" + mainTable(table) + strYear1 + checkYearOperationSign('>', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + ParamYearAfter.ParameterName + ")";
                        lineParams += strAnd + "(" + mainTable(table) + strYear2 + checkYearOperationSign('<', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + ParamYearBefore.ParameterName + ")";
                        countAnd++;
                    }

                }
                #endregion Years
                //line += ";";
                if (lineParams.Length > 0)
                {
                    line = lineWhere + lineParams;
                }
                return line;
            }
            public string mainTable(string table)
            {
                string str = "";
                if (table.Length > 0)
                {
                    str = table + ".";
                }
                return str;
            }
            public List<short> defineMaxMinYear()
            {
                short yearMax = 0;
                short yearMin = 0;
                List<short> arr = new List<short>();
                dbConn = new OleDbConnection();
                dbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                dbConn.Open();
                dbCom = dbConn.CreateCommand();
                dbCom.CommandText = "SELECT * FROM View_years";
                dbDataAdp = new OleDbDataAdapter(dbCom);
                dbConn.Close();
                DataTable dt = new DataTable();
                dbDataAdp.Fill(dt);
                yearMin = Convert.ToInt16(dt.Rows[0]["year_min"]);
                yearMax = Convert.ToInt16(dt.Rows[0]["year_max"]);
                for (int i = (int)yearMin - 1; i < (int)yearMax; i++)
                {
                    arr.Add((short)(i + 1));
                }
                return arr;
            }
            public bool TestConnection()
            {
                bool test = false;
                string serVersion = "";
                dbConn = new OleDbConnection();
                dbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                try
                {
                    dbConn.Open();
                    serVersion = dbConn.ServerVersion;
                }
                catch (System.Exception ex)
                {
                }
                finally
                {
                    
                    if (serVersion != "")
                    {
                        test = true;
                    }
                }
                return test;
            }
            public void BuildRequest(string str)
            {
                OleDbConnection conn = new OleDbConnection(NalogUser.App.Default.ConnectionString.ToString());
                conn.Open();
                OleDbCommand com = conn.CreateCommand();
                com.CommandText = str;
                com.ExecuteScalar();
                conn.Close();
            }
            private string returnField(bool direct, string field)
            {
                string sField = "";

                for (int i = 0; i < referenceFields.GetLength(0); i++)
                {
                    if (referenceFields[i, 0] == field)
                    {
                        if (direct)
                        {
                            sField = referenceFields[i, 1].ToString();
                        }
                        else
                        {
                            sField = referenceFields[i, 2].ToString();
                        }
                    }
                }

                return sField;
            }
            private void setReferenceFields()
            {
                referenceFields[0, 1] = "dbo." + b.AnData.Ds.Federal_district.TableName + "." + b.AnData.Ds.Federal_district.idColumn.ColumnName;
                referenceFields[1, 1] = "dbo." + b.AnData.Ds.Subjects.TableName + "." + b.AnData.Ds.Subjects.idColumn.ColumnName;
                referenceFields[2, 1] = "dbo." + b.AnData.Ds.Taxes.TableName + "." + b.AnData.Ds.Taxes.idColumn.ColumnName;
                referenceFields[3, 1] = "dbo." + b.AnData.Ds.Taxes_ved.TableName + "." + b.AnData.Ds.Taxes_ved.idColumn.ColumnName;

                referenceFields[0, 2] = "id_district";
                referenceFields[1, 2] = "id_subject";
                referenceFields[2, 2] = "id_tax";
                referenceFields[3, 2] = "id_eea";
            }
            private string checkYearOperationSign(char sign, char[] signs)
            {
                string str = "";
                char chr = ' ';
                if (signs.Length > 0)
                {
                    if (sign == '>') chr = 'm';
                    if (sign == '<') chr = 'l';
                    if (sign == '=') chr = 'e';
                    //
                    for (int i = 0; i < signs.Length; i++)
                    {
                        if (chr == signs[i]) str = sign.ToString();
                    }
                }
                else
                {
                    str = sign.ToString();
                }
                //
                return str;
            }
        }
    }
}
