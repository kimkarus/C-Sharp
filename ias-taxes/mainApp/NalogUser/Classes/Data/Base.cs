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
        private Core cr;
        private _Parametr parametr;
        //
        private Classes.AnalysisData.AnalysisDataVariables var;
        private Classes.AnalysisData.AnalysisData anData;
        //
        private string connectionType = "";
        private bool isConnectionTypeOLEDB = false;
        private bool isConnectionTypeSQL = false;

        public _BaseSql BaseSql { get { return baseSql; } set { baseSql = value; } }
        public _BaseOleDb BaseOleDb { get { return baseOleDb; } set { baseOleDb = value; } }
        public _Parametr Parametr { get { return parametr; } set { parametr = value; } }
        public bool IsSql { get { return isConnectionTypeSQL; } }
        public bool IsOledb { get { return isConnectionTypeOLEDB; } }
        public Classes.AnalysisData.AnalysisData AnData { get { return anData; } set { anData = null; anData = value; } }
        public Classes.AnalysisData.AnalysisDataVariables Var { get { return var; } set { var = null; var = value; } }
        public Base(Classes.AnalysisData.AnalysisDataVariables Var=null,
                Classes.AnalysisData.AnalysisData AnData=null, Core Cr=null)
        {
            this.cr = Cr;
            //
            if (this.cr == null)
            {
                this.anData = null;
            }
            else
            {
                this.anData = cr.AnalysData;
            }
            if (this.anData == null)
            {
                this.var = null;
            }
            else
            {
                this.var = cr.AnalysData.Var;
            }
            parametr = new _Parametr();
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
                                           "Tax_authority", "Taxes", "Taxes_ved", "Taxes_view"," Users", "Taxes_budgets", "Scheme_values"};
            private string[,] referenceFields ={
                                               {"idDistrict", "",""},
                                               {"idSubject","",""},
                                               {"idTax","","",},
                                               {"idEea","",""},
                                               {"idBudget","",""},
                                               {"idIndex","",""}
                                          };
            //
            private SqlConnection dbConn;
            private SqlCommand dbCom;
            private SqlDataAdapter dbDataAdp;
            //
            private List<SqlParameter> arrayParamsIdsSubjects = new List<SqlParameter>();
            private List<SqlParameter> arrayParamsIdsTaxes = new List<SqlParameter>();
            private List<SqlParameter> arrayParamsIdsIndexes = new List<SqlParameter>();
            //
            public SqlConnection DbConn { get { return dbConn; } set { dbConn = value; } }
            public SqlCommand DbCom { get { return dbCom; } set { dbCom = value; } }
            public SqlDataAdapter DbDataAdp { get { return dbDataAdp; } set { dbDataAdp = value; } }
            //
            //
            public List<SqlParameter> ArrayParamsIdsSubjects { get { return arrayParamsIdsSubjects; } set { arrayParamsIdsSubjects = value; } }
            public List<SqlParameter> ArrayParamsIdsTaxes { get { return arrayParamsIdsTaxes; } set { arrayParamsIdsTaxes = value; } }
            public List<SqlParameter> ArrayParamsIdsIndexes { get { return arrayParamsIdsIndexes; } set { arrayParamsIdsIndexes = value; } }
            #endregion Переменные
            public void defineParameters()
            {
                dbCom.Parameters.Clear();
                #region Set parametres
                #region Districts
                if (b.Var.IdDistrict > 0)
                {
                    b.parametr.IdDistrict.sqlP = new System.Data.SqlClient.SqlParameter(b.parametr.IdDistrict.name, SqlDbType.Int);
                    DbCom.Parameters.Add(b.parametr.IdDistrict.sqlP);
                    DbCom.Parameters[b.parametr.IdDistrict.name].Value = b.Var.IdDistrict;
                }
                #endregion Districts
                #region Subjects
                #region ids
                if (b.Var.IdsSubjects != null)
                {
                    //SQL
                    ArrayParamsIdsSubjects.Clear();
                    for (int j = 0; j < b.Var.IdsSubjects.Length; j++)
                    {
                        b.parametr.IdSubject.sqlP = new System.Data.SqlClient.SqlParameter(b.parametr.IdSubject.name + j, SqlDbType.Int);
                        ArrayParamsIdsSubjects.Add(b.parametr.IdSubject.sqlP);
                        DbCom.Parameters.Add(b.parametr.IdSubject.sqlP);
                        DbCom.Parameters[b.parametr.IdSubject.name + j].Value = b.Var.IdsSubjects[j];
                    }
                }
                #endregion ids
                #region id
                else
                {
                    if (b.Var.IdSubject > 0)
                    {
                        //SQL
                        b.parametr.IdSubject.sqlP = new System.Data.SqlClient.SqlParameter(b.parametr.IdSubject.name, SqlDbType.Int);
                        ArrayParamsIdsSubjects.Add(b.parametr.IdSubject.sqlP);
                        DbCom.Parameters.Add(b.parametr.IdSubject.sqlP);
                        DbCom.Parameters[b.parametr.IdSubject.name].Value = b.Var.IdSubject;
                    }
                }
                #endregion id
                #endregion Subjects
                #region Taxes
                #region ids
                if (b.Var.IdsTaxes != null)
                {
                    //SQL
                    ArrayParamsIdsTaxes.Clear();
                    for (int j = 0; j < b.Var.IdsTaxes.Length; j++)
                    {
                        b.parametr.IdTax.sqlP = new System.Data.SqlClient.SqlParameter(b.parametr.IdTax.name + j, SqlDbType.Int);
                        ArrayParamsIdsTaxes.Add(b.parametr.IdTax.sqlP);
                        DbCom.Parameters.Add(b.parametr.IdTax.sqlP);
                        DbCom.Parameters[b.parametr.IdTax.name + j].Value = b.Var.IdsTaxes[j];
                    }
                }
                #endregion ids
                #region id
                else
                {
                    if (b.Var.IdTax > 0)
                    {
                        //SQL
                        b.parametr.IdTax.sqlP = new System.Data.SqlClient.SqlParameter(b.parametr.IdTax.name, SqlDbType.Int);
                        ArrayParamsIdsTaxes.Add(b.parametr.IdTax.sqlP);
                        DbCom.Parameters.Add(b.parametr.IdTax.sqlP);
                        DbCom.Parameters[b.parametr.IdTax.name].Value = b.Var.IdTax;
                    }
                }
                #endregion id
                #endregion Taxes
                #region Indexes
                #region ids
                if (b.Var.IdsIndex != null)
                {
                    //SQL
                    ArrayParamsIdsIndexes.Clear();
                    for (int j = 0; j < b.Var.IdsIndex.Length; j++)
                    {
                        b.parametr.IdIndex.sqlP = new System.Data.SqlClient.SqlParameter(b.parametr.IdIndex.name + j, SqlDbType.Int);
                        ArrayParamsIdsIndexes.Add(b.parametr.IdIndex.sqlP);
                        DbCom.Parameters.Add(b.parametr.IdIndex.sqlP);
                        DbCom.Parameters[b.parametr.IdIndex.name + j].Value = b.Var.IdsIndex[j];
                    }
                }
                #endregion ids
                #region id
                else
                {
                    if (b.Var.IdIndex > 0)
                    {
                        //SQL
                        b.parametr.IdIndex.sqlP = new System.Data.SqlClient.SqlParameter(b.parametr.IdIndex.name, SqlDbType.Int);
                        ArrayParamsIdsIndexes.Add(b.parametr.IdIndex.sqlP);
                        DbCom.Parameters.Add(b.parametr.IdIndex.sqlP);
                        DbCom.Parameters[b.parametr.IdIndex.name].Value = b.Var.IdsIndex;
                    }
                }
                #endregion id
                #endregion Indexes
                if (b.Var.IdEea > 0)
                {
                    b.parametr.IdEea.sqlP = new SqlParameter(b.parametr.IdEea.name, SqlDbType.Int);
                    DbCom.Parameters.Add(b.parametr.IdEea.sqlP);
                    DbCom.Parameters[b.parametr.IdEea.name].Value = b.Var.IdEea;
                }
                else b.parametr.IdEea.sqlP = null;
                if (b.Var.IdBudget > 0)
                {
                    b.parametr.IdBudget.sqlP = new SqlParameter(b.parametr.IdBudget.name, SqlDbType.Int);
                    DbCom.Parameters.Add(b.parametr.IdBudget.sqlP);
                    DbCom.Parameters[b.parametr.IdBudget.name].Value = b.Var.IdBudget;
                }
                else b.parametr.IdBudget.sqlP = null;
                if (b.Var.YearAfter > 0 && b.Var.YearBefore > 0)
                {
                    b.parametr.YearAfter.sqlP = new SqlParameter(b.parametr.YearAfter.name, SqlDbType.SmallInt);
                    DbCom.Parameters.Add(b.parametr.YearAfter.sqlP);
                    DbCom.Parameters[b.parametr.YearAfter.name].Value = b.Var.YearAfter;
                    //
                    b.parametr.YearBefore.sqlP = new SqlParameter(b.parametr.YearBefore.name, SqlDbType.SmallInt);
                    DbCom.Parameters.Add(b.parametr.YearBefore.sqlP);
                    DbCom.Parameters[b.parametr.YearBefore.name].Value = b.Var.YearBefore;
                }
                else { b.parametr.YearAfter = null; b.parametr.YearBefore = null; }

                #endregion Set parametres
                #region Params
                
                /*if (b.Var.IdDistrict > 0)
                {
                    ParamIdDistrict = new SqlParameter("@ParametrIdDistrict", b.Var.IdDistrict);
                }
                else ParamIdDistrict = null;
                if (b.Var.IdSubject > 0)
                {
                    ParamIdSubject = new SqlParameter("@ParametrIdSubject", b.Var.IdSubject);
                }
                else ParamIdSubject = null;

                if (b.Var.IdTax > 0)
                {
                    ParamIdTax = new SqlParameter("@ParametrIdTax", b.Var.IdTax);
                }
                else ParamIdTax = null;
*/
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
                #region Subjects
                /*if (b.Var.IdsSubjects != null)
                {
                    if (arrayParamsIdsSubjects.Count > 0 && arrayParamsIdsSubjects.Count == 1)
                    {
                        ParamIdSubject = arrayParamsIdsSubjects[0];
                    }
                    else if (arrayParamsIdsSubjects.Count > 1)
                    {
                        ParamIdSubject = arrayParamsIdsSubjects[0];
                    }
                    else ParamIdSubject = null;
                }
                else ParamIdSubject = null;
                #endregion Subjects
                #region Taxes
                if (b.Var.IdsTaxes != null)
                {
                    if (arrayParamsIdsTaxes.Count > 0 && arrayParamsIdsTaxes.Count == 1)
                    {
                        ParamIdTax = arrayParamsIdsTaxes[0];
                    }
                    else if (arrayParamsIdsTaxes.Count > 1)
                    {
                        ParamIdTax = arrayParamsIdsTaxes[0];
                    }
                    else ParamIdSubject = null;
                }
                else ParamIdTax = null;*/
                #endregion Taxes
                #endregion Params
                int oo = 2;
                if (b.parametr.IdDistrict.sqlP != null || b.parametr.IdSubject.sqlP != null || b.parametr.IdTax.sqlP != null || b.Var.IsYears || b.parametr.IdBudget.sqlP != null || b.parametr.IdIndex.sqlP !=null)
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
                            b.parametr.IdDistrict.name + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrDistrict;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idDistrict") + "=" +
                            b.parametr.IdDistrict.name + ")";
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
                        if (arrayParamsIdsSubjects.Count > 1)
                        {
                            lineParams += strAnd;
                            SqlParameter param0 = (SqlParameter)arrayParamsIdsSubjects[0];
                            lineParams += "((" + returnField(direct, "idSubject") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsSubjects.Count; i++)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsSubjects[i];
                                lineParams += " OR (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            SqlParameter param = (SqlParameter)arrayParamsIdsSubjects[0];
                            lineParams += strAnd + "(" + returnField(direct, "idSubject") + "=" +
                               param.ParameterName + ")";
                        }
                    }
                    else
                    {
                        if (arrayParamsIdsSubjects.Count > 1)
                        {
                            SqlParameter param0 = (SqlParameter)arrayParamsIdsSubjects[0];
                            lineParams += "((" + returnField(direct, "idSubject") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsSubjects.Count; i++)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsSubjects[i];
                                lineParams += " OR (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            SqlParameter param = (SqlParameter)arrayParamsIdsSubjects[0];
                            lineParams += " (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
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
                        //lineParams += strAnd + "(" + returnField(direct, "idTax") + "=" +
                        //    ParamIdTax.ParameterName + ")";
                        //b.Var.HeadFrmReport += " " + b.Var.StrTax;

                        if (arrayParamsIdsTaxes.Count > 1)
                        {
                            lineParams += strAnd;
                            SqlParameter param0 = (SqlParameter)arrayParamsIdsTaxes[0];
                            lineParams += "((" + returnField(direct, "idTax") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsTaxes.Count; i++)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsTaxes[i];
                                lineParams += " OR (" + returnField(direct, "idTax") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            if (arrayParamsIdsTaxes.Count > 0)
                            {
                                lineParams += strAnd;
                                SqlParameter param = (SqlParameter)arrayParamsIdsTaxes[0];
                                lineParams += " (" + returnField(direct, "idTax") + "=" +
                                     param.ParameterName + ")";
                            }
                            else
                            {
                                lineParams += " (" + returnField(direct, "idTax") + "=" +
                                     b.parametr.IdTax.name + ")";
                                b.Var.HeadFrmReport += b.Var.StrTax;
                            }
                        }
                    }
                    else
                    {


                        if (arrayParamsIdsTaxes.Count > 1)
                        {
                            SqlParameter param0 = (SqlParameter)arrayParamsIdsTaxes[0];
                            lineParams += "((" + returnField(direct, "idTax") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsTaxes.Count; i++)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsTaxes[i];
                                lineParams += " OR (" + returnField(direct, "idTax") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            if (arrayParamsIdsTaxes.Count > 0)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsTaxes[0];
                                lineParams += " (" + returnField(direct, "idTax") + "=" +
                                    param.ParameterName + ")";
                            }
                            else
                            {
                                lineParams += " (" + returnField(direct, "idTax") + "=" +
                                     b.parametr.IdTax.name + ")";
                                b.Var.HeadFrmReport += b.Var.StrTax;
                            }
                        }
                    }
                    countAnd++;
                }
                #endregion IdTax
                #region IdIndex
                if (b.Var.IsIdIndex && b.Var.IdIndex > 0 && b.AnData.CheckParam("id_index", index))
                {
                    if (countAnd >= 0)
                    {
                        //lineParams += strAnd + "(" + returnField(direct, "idTax") + "=" +
                        //    ParamIdTax.ParameterName + ")";
                        //b.Var.HeadFrmReport += " " + b.Var.StrTax;

                        if (arrayParamsIdsIndexes.Count > 1)
                        {
                            lineParams += strAnd;
                            SqlParameter param0 = (SqlParameter)arrayParamsIdsIndexes[0];
                            lineParams += "((" + returnField(direct, "idIndex") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsIndexes.Count; i++)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsIndexes[i];
                                lineParams += " OR (" + returnField(direct, "idIndex") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            lineParams += strAnd;
                            SqlParameter param = (SqlParameter)arrayParamsIdsIndexes[0];
                            lineParams += " (" + returnField(direct, "idIndex") + "=" +
                                 param.ParameterName + ")";
                            b.Var.HeadFrmReport += b.Var.StrIndex;
                        }
                    }
                    else
                    {
                        if (arrayParamsIdsIndexes.Count > 1)
                        {
                            SqlParameter param0 = (SqlParameter)arrayParamsIdsIndexes[0];
                            lineParams += "((" + returnField(direct, "idIndex") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsIndexes.Count; i++)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsIndexes[i];
                                lineParams += " OR (" + returnField(direct, "idIndex") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            if (arrayParamsIdsIndexes.Count > 0)
                            {
                                SqlParameter param = (SqlParameter)arrayParamsIdsIndexes[0];
                                lineParams += " (" + returnField(direct, "idIndex") + "=" +
                                    param.ParameterName + ")";
                            }
                            else
                            {
                                lineParams += " (" + returnField(direct, "idIndex") + "=" +
                                     b.parametr.IdIndex.name + ")";
                                b.Var.HeadFrmReport += b.Var.StrIndex;
                            }
                        }
                    }
                    countAnd++;
                }
                #endregion IdIndex
                #region IdEea
                if (b.Var.IsIdEea && b.Var.IdEea > 0 && b.AnData.CheckParam("id_eea", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idEea") + "=" +
                            b.parametr.IdEea.name + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrEea;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idEea") + "=" +
                            b.parametr.IdEea.name + ")";
                        b.Var.HeadFrmReport += b.Var.StrEea;
                    }
                    countAnd++;
                }
                #endregion IdTEea
                #region IdBudget
                if (b.Var.IsBudget && b.Var.IdBudget > 0 && b.AnData.CheckParam("id_budget", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idBudget") + "=" +
                          b.parametr.IdBudget.name + ") OR " + "(" + returnField(direct, "idBudget") + " IS NULL)";
                        b.Var.HeadFrmReport += " " + b.Var.StrBudget;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idBudget") + "=" +
                            b.parametr.IdBudget.name + ") OR " + "(" + returnField(direct, "idBudget") + " IS NULL)";
                        b.Var.HeadFrmReport += b.Var.StrBudget;
                    }
                    countAnd++;
                }
                #endregion IdBudget
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
                            checkYearOperationSign('=', arrYearsSigns) + b.parametr.YearAfter.name + ")";
                        lineParams += strAnd + "(" + mainTable(table) + strYear2 + checkYearOperationSign('<', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + b.parametr.YearBefore.name + ")";
                        countAnd++;
                        b.Var.HeadFrmReport += " " + b.Var.YearAfter.ToString() + " - " + b.Var.YearBefore.ToString();
                    }
                    else
                    {
                        lineParams += "(" + mainTable(table) + strYear1 + checkYearOperationSign('>', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + b.parametr.YearAfter.name + ")";
                        lineParams += strAnd + "(" + mainTable(table) + strYear2 + checkYearOperationSign('<', arrYearsSigns) +
                            checkYearOperationSign('=', arrYearsSigns) + b.parametr.YearBefore.name + ")";
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
                try
                {
                    dbConn = new SqlConnection();
                    dbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                    dbConn.Open();
                    string serVersion = dbConn.ServerVersion;
                    if (serVersion != "")
                    {
                        test = true;
                    }
                }
                catch (System.Exception err)
                {
                    test = false;
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
                referenceFields[4, 1] = "dbo." + b.AnData.Ds.Taxes_budgets.TableName + "." + b.AnData.Ds.Taxes_budgets.idColumn.ColumnName;
                referenceFields[5, 1] = "dbo." + b.AnData.Ds.Scheme_values.TableName + "." + b.AnData.Ds.Scheme_values.idColumn.ColumnName;

                referenceFields[0, 2] = "id_district";
                referenceFields[1, 2] = "id_subject";
                referenceFields[2, 2] = "id_tax";
                referenceFields[3, 2] = "id_eea";
                referenceFields[4, 2] = "id_budget";
                referenceFields[5, 2] = "id_index";
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
                                           "Tax_authority", "Taxes", "Taxes_ved", "Taxes_view"," Users", "Taxes_budgets"};
            private string[,] referenceFields ={
                                               {"idDistrict", "",""},
                                               {"idSubject","",""},
                                               {"idTax","","",},
                                               {"idEea","",""},
                                               {"idBudget","",""}
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
            private OleDbParameter paramIdBudget;
            //
            private List<OleDbParameter> arrayParamsIdsSubjects = new List<OleDbParameter>();
            private List<OleDbParameter> arrayParamsIdsTaxes = new List<OleDbParameter>();
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
            public OleDbParameter ParamIdBudget { get { return paramIdBudget; } set { paramIdBudget = value; } }
            //
            public List<OleDbParameter> ArrayParamsIdsSubjects { get { return arrayParamsIdsSubjects; } set { arrayParamsIdsSubjects = value; } }
            public List<OleDbParameter> ArrayParamsIdsTaxes { get { return arrayParamsIdsTaxes; } set { arrayParamsIdsTaxes = value; } }
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
                if (b.Var.IdSubject > 0)
                {
                    ParamIdSubject = new OleDbParameter("@ParametrIdSubject", b.Var.IdSubject);
                }
                else ParamIdSubject = null;
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
                if (b.Var.IdBudget > 0)
                {
                    ParamIdBudget = new OleDbParameter("@ParametrIdBudget", b.Var.IdBudget);
                }
                else ParamIdBudget = null;
                if (b.Var.YearAfter > 0 && b.Var.YearBefore > 0)
                {
                    ParamYearAfter = new OleDbParameter("@ParametrYearAfter", b.Var.YearAfter);
                    ParamYearBefore = new OleDbParameter("@ParametrYearBefore", b.Var.YearBefore);
                }
                else { ParamYearAfter = null; ParamYearBefore = null; }
                #endregion Params

                /*#region Set parametres
                #region Districts
                if (var.IdDistrict > 0)
                {
                    //SQL
                    if (cr.B.IsSql)
                    {
                        cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdDistrict); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdDistrict.ParameterName].Value = var.IdDistrict;
                    }
                    if (cr.B.IsOledb)
                    {
                        cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdDistrict); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdDistrict.ParameterName].Value = var.IdDistrict;
                    }
                }
                #endregion Districts
                #region Subjects
                #region ids
                if (var.IdsSubjects != null)
                {
                    if (cr.B.IsSql)
                    {
                        //SQL
                        cr.B.BaseSql.ArrayParamsIdsSubjects.Clear();
                        for (int j = 0; j < var.IdsSubjects.Length; j++)
                        {
                            cr.B.BaseSql.ParamIdSubject = new System.Data.SqlClient.SqlParameter("@ParametrIdSubject" + j, var.IdsSubjects[j]);
                            cr.B.BaseSql.ArrayParamsIdsSubjects.Add(cr.B.BaseSql.ParamIdSubject);
                            cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdSubject);
                        }
                    }
                    if (cr.B.IsOledb)
                    {
                        //OLEDB
                        cr.B.BaseOleDb.ArrayParamsIdsSubjects.Clear();
                        for (int j = 0; j < var.IdsSubjects.Length; j++)
                        {
                            cr.B.BaseOleDb.ParamIdSubject = new System.Data.OleDb.OleDbParameter("@ParametrIdSubject" + j, var.IdsSubjects[j]);
                            cr.B.BaseOleDb.ArrayParamsIdsSubjects.Add(cr.B.BaseOleDb.ParamIdSubject);
                            cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdSubject);
                        }
                    }
                }
                #endregion ids
                #region id
                else
                {
                    if (var.IdSubject > 0)
                    {
                        if (cr.B.IsSql)
                        //SQL
                        {
                            cr.B.BaseSql.ParamIdSubject = new System.Data.SqlClient.SqlParameter("@ParametrIdSubject", var.IdSubject);
                            cr.B.BaseSql.ArrayParamsIdsSubjects.Add(cr.B.BaseSql.ParamIdSubject);
                            cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdSubject);
                        }
                        if (cr.B.IsOledb)
                        //OLEDB
                        {
                            cr.B.BaseOleDb.ParamIdSubject = new System.Data.OleDb.OleDbParameter("@ParametrIdSubject", var.IdSubject);
                            cr.B.BaseOleDb.ArrayParamsIdsSubjects.Add(cr.B.BaseOleDb.ParamIdSubject);
                            cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdSubject);
                        }
                    }
                }
                #endregion id
                #endregion Subjects
                #region Taxes

                #region ids
                if (var.IdsTaxes != null)
                {
                    if (cr.B.IsSql)
                    {
                        //SQL
                        cr.B.BaseSql.ArrayParamsIdsTaxes.Clear();
                        for (int j = 0; j < var.IdsTaxes.Length; j++)
                        {
                            cr.B.BaseSql.ParamIdTax = new System.Data.SqlClient.SqlParameter("@ParametrIdTax" + j, var.IdsTaxes[j]);
                            cr.B.BaseSql.ArrayParamsIdsTaxes.Add(cr.B.BaseSql.ParamIdTax);
                            cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdTax);
                        }
                    }
                    if (cr.B.IsOledb)
                    {
                        //OLEDB
                        cr.B.BaseOleDb.ArrayParamsIdsTaxes.Clear();
                        for (int j = 0; j < var.IdsTaxes.Length; j++)
                        {
                            cr.B.BaseOleDb.ParamIdTax = new System.Data.OleDb.OleDbParameter("@ParametrIdTax" + j, var.IdsTaxes[j]);
                            cr.B.BaseOleDb.ArrayParamsIdsTaxes.Add(cr.B.BaseOleDb.ParamIdTax);
                            cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdTax);
                        }
                    }
                }
                #endregion ids
                #region id
                else
                {
                    if (var.IdTax > 0)
                    {
                        if (cr.B.IsSql)
                        //SQL
                        {
                            cr.B.BaseSql.ParamIdTax = new System.Data.SqlClient.SqlParameter("@ParametrIdTax", var.IdTax);
                            cr.B.BaseSql.ArrayParamsIdsTaxes.Add(cr.B.BaseSql.ParamIdTax);
                            cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdTax);
                        }
                        if (cr.B.IsOledb)
                        //OLEDB
                        {
                            cr.B.BaseOleDb.ParamIdTax = new System.Data.OleDb.OleDbParameter("@ParametrIdTax", var.IdTax);
                            cr.B.BaseOleDb.ArrayParamsIdsTaxes.Add(cr.B.BaseOleDb.ParamIdTax);
                            cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdTax);
                        }
                    }
                }
                #endregion id
                #endregion Taxes
                if (cr.B.IsSql)
                {
                    //SQL
                    //if (var.IdTax > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdTax); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdTax.ParameterName].Value = var.IdTax; }
                    if (var.IdEea > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdEea); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdEea.ParameterName].Value = var.IdEea; }
                    if (var.IdBudget > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdBudget); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdBudget.ParameterName].Value = var.IdBudget; }
                    if (var.YearAfter > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamYearAfter); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamYearAfter.ParameterName].Value = var.YearAfter; }
                    if (var.YearBefore > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamYearBefore); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamYearBefore.ParameterName].Value = var.YearBefore; }

                }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    //if (var.IdTax > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdTax); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdTax.ParameterName].Value = var.IdTax; }
                    if (var.IdEea > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdEea); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdEea.ParameterName].Value = var.IdEea; }
                    if (var.IdBudget > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdBudget); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdBudget.ParameterName].Value = var.IdBudget; }
                    if (var.YearAfter > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamYearAfter); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamYearAfter.ParameterName].Value = var.YearAfter; }
                    if (var.YearBefore > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamYearBefore); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamYearBefore.ParameterName].Value = var.YearBefore; }

                }
                #endregion Set parametres*/
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
                #region Subjects
                if (b.Var.IdsSubjects != null)
                {
                    if (arrayParamsIdsSubjects.Count > 0 && arrayParamsIdsSubjects.Count == 1)
                    {
                        ParamIdSubject = arrayParamsIdsSubjects[0];
                    }
                    else if (arrayParamsIdsSubjects.Count > 1)
                    {
                        ParamIdSubject = arrayParamsIdsSubjects[0];
                    }
                    else ParamIdSubject = null;
                }
                else ParamIdSubject = null;
                #endregion Subjects
                #region Taxes
                if (b.Var.IdsTaxes != null)
                {
                    if (arrayParamsIdsTaxes.Count > 0 && arrayParamsIdsTaxes.Count == 1)
                    {
                        ParamIdTax = arrayParamsIdsTaxes[0];
                    }
                    else if (arrayParamsIdsTaxes.Count > 1)
                    {
                        ParamIdTax = arrayParamsIdsTaxes[0];
                    }
                    else ParamIdSubject = null;
                }
                else ParamIdTax = null;
                #endregion Taxes
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
                        if (arrayParamsIdsSubjects.Count > 1)
                        {
                            lineParams += strAnd;
                            OleDbParameter param0 = (OleDbParameter)arrayParamsIdsSubjects[0];
                            lineParams += "((" + returnField(direct, "idSubject") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsSubjects.Count; i++)
                            {
                                OleDbParameter param = (OleDbParameter)arrayParamsIdsSubjects[i];
                                lineParams += " OR (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            ParamIdSubject = (OleDbParameter)arrayParamsIdsSubjects[0];
                            lineParams += strAnd + "(" + returnField(direct, "idSubject") + "=" +
                                ParamIdSubject.ParameterName + ")";
                        }
                    }
                    else
                    {
                        if (arrayParamsIdsSubjects.Count > 1)
                        {
                            OleDbParameter param0 = (OleDbParameter)arrayParamsIdsSubjects[0];
                            lineParams += "((" + returnField(direct, "idSubject") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsSubjects.Count; i++)
                            {
                                OleDbParameter param = (OleDbParameter)arrayParamsIdsSubjects[i];
                                lineParams += " OR (" + returnField(direct, "idSubject") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            ParamIdSubject = (OleDbParameter)arrayParamsIdsSubjects[0];
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
                        //lineParams += strAnd + "(" + returnField(direct, "idTax") + "=" +
                        //    ParamIdTax.ParameterName + ")";
                        //b.Var.HeadFrmReport += " " + b.Var.StrTax;

                        if (arrayParamsIdsTaxes.Count > 1)
                        {
                            lineParams += strAnd;
                            OleDbParameter param0 = (OleDbParameter)arrayParamsIdsTaxes[0];
                            lineParams += "((" + returnField(direct, "idTax") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsTaxes.Count; i++)
                            {
                                OleDbParameter param = (OleDbParameter)arrayParamsIdsTaxes[i];
                                lineParams += " OR (" + returnField(direct, "idTax") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            ParamIdTax = (OleDbParameter)arrayParamsIdsTaxes[0];
                            lineParams += strAnd + "(" + returnField(direct, "idTax") + "=" +
                                ParamIdTax.ParameterName + ")";
                        }
                    }
                    else
                    {
                        //lineParams += " (" + returnField(direct, "idTax") + "=" +
                        //     ParamIdTax.ParameterName + ")";
                        //b.Var.HeadFrmReport += b.Var.StrTax;

                        if (arrayParamsIdsTaxes.Count > 1)
                        {
                            OleDbParameter param0 = (OleDbParameter)arrayParamsIdsTaxes[0];
                            lineParams += "((" + returnField(direct, "idTax") + "=" +
                                param0.ParameterName + ")";
                            for (int i = 1; i < arrayParamsIdsTaxes.Count; i++)
                            {
                                OleDbParameter param = (OleDbParameter)arrayParamsIdsTaxes[i];
                                lineParams += " OR (" + returnField(direct, "idTax") + "=" +
                                param.ParameterName + ")";
                            }
                            lineParams += ")";
                        }
                        else
                        {
                            ParamIdTax = (OleDbParameter)arrayParamsIdsTaxes[0];
                            lineParams += " (" + returnField(direct, "idTax") + "=" +
                                ParamIdTax.ParameterName + ")";
                        }
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
                #region IdBudget
                if (b.Var.IsBudget && b.Var.IdBudget > 0 && b.AnData.CheckParam("id_budget", index))
                {
                    if (countAnd >= 0)
                    {
                        lineParams += strAnd + "(" + returnField(direct, "idBudget") + "=" +
                             ParamIdBudget.ParameterName + ")";
                        b.Var.HeadFrmReport += " " + b.Var.StrBudget;
                    }
                    else
                    {
                        lineParams += " (" + returnField(direct, "idBudget") + "=" +
                            ParamIdBudget.ParameterName + ")";
                        b.Var.HeadFrmReport += b.Var.StrBudget;
                    }
                    countAnd++;
                }
                #endregion IdBudget
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
                referenceFields[4, 1] = "dbo." + b.AnData.Ds.Taxes_budgets.TableName + "." + b.AnData.Ds.Taxes_budgets.idColumn.ColumnName;

                referenceFields[0, 2] = "id_district";
                referenceFields[1, 2] = "id_subject";
                referenceFields[2, 2] = "id_tax";
                referenceFields[3, 2] = "id_eea";
                referenceFields[4, 2] = "id_budget";
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
        public class _Parametr
        {

            //
            public _Parametr()
            {
                prmIdSubject = new _PrmIdSubject();
                prmIdDistrict = new _PrmIdDistrict();
                prmIdTax = new _PrmIdTax();
                prmIdEea = new _PrmIdEea();
                prmIdBudget = new _PrmIdBudget();
                prmIdIndex = new _PrmIdIndex();
                prmYearAfter = new _PrmYearAfter();
                prmYearBefore = new _PrmYearBefore();
            }
            //
            private _PrmIdSubject prmIdSubject;
            public _PrmIdSubject IdSubject { get { return prmIdSubject; } set { prmIdSubject = value; } }
            private _PrmIdDistrict prmIdDistrict;
            public _PrmIdDistrict IdDistrict { get { return prmIdDistrict; } set { prmIdDistrict = value; } }
            private _PrmIdTax prmIdTax;
            public _PrmIdTax IdTax { get { return prmIdTax; } set { prmIdTax = value; } }
            private _PrmIdEea prmIdEea;
            public _PrmIdEea IdEea { get { return prmIdEea; } set { prmIdEea = value; } }
            private _PrmIdBudget prmIdBudget;
            public _PrmIdBudget IdBudget { get { return prmIdBudget; } set { prmIdBudget = value; } }
            private _PrmIdIndex prmIdIndex;
            public _PrmIdIndex IdIndex { get { return prmIdIndex; } set { prmIdIndex = value; } }
            private _PrmYearAfter prmYearAfter;
            public _PrmYearAfter YearAfter { get { return prmYearAfter; } set { prmYearAfter = value; } }
            private _PrmYearBefore prmYearBefore;
            public _PrmYearBefore YearBefore { get { return prmYearBefore; } set { prmYearBefore = value; } }

            public class _PrmIdSubject
            {
                public string name = "@ParametrIdSubject";
                public SqlParameter sqlP;
                public OleDbParameter oledbP;
            }
            public class _PrmIdDistrict
            {
                public string name = "@ParametrIdDistrict";
                public SqlParameter sqlP;
                public OleDbParameter oledbP;
            }
            public class _PrmIdTax
            {
                public string name = "@ParametrIdTax";
                public SqlParameter sqlP;
                public OleDbParameter oledbP;
            }
            public class _PrmIdEea
            {
                public string name = "@ParametrIdEea";
                public SqlParameter sqlP;
                public OleDbParameter oledbP;
            }
            public class _PrmIdBudget
            {
                public string name = "@ParametrIdBudget";
                public SqlParameter sqlP;
                public OleDbParameter oledbP;
            }
            public class _PrmIdIndex
            {
                public string name = "@ParametrIdIndex";
                public SqlParameter sqlP;
                public OleDbParameter oledbP;
            }
            public class _PrmYearAfter
            {
                public string name = "@ParametrYearAfter";
                public SqlParameter sqlP;
                public OleDbParameter oledbP;
            }
            public class _PrmYearBefore
            {
                public string name = "@ParametrYearBefore";
                public SqlParameter sqlP;
                public OleDbParameter oledbP;
            }
        }
    }
}
