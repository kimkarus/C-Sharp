using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using Microsoft.Reporting.WinForms;
using System.Collections;
using System.IO;

namespace NalogUser.Classes.AnalysisData
{
    public class AnalysisData
    {
        #region Переменные
        private Core cr;
        private base_nalog_viewsDataSet dsView;
        private base_nalogDataSet ds;
        private AnalysisDataVariables var;
        private Forms.FormAnalysisData frmAnalysisData;
        private Forms.ComponentViews comViews;
        private Classes.AnalysisData.PropertiesReport pReports;
        private ReportParameter ReportParamDistrictName;
        private ReportParameter ReportParamSubjectName;
        private ReportParameter ReportParamTaxName;
        private ReportParameter ReportParamTaxEeaName;
        private ReportParameter ReportParamYearAfter;
        private ReportParameter ReportParamYearBefore;
        private static ArrayList arrReports = new ArrayList();
        #region Adapters
        private base_nalogDataSetTableAdapters.ReportsTableAdapter reportsTableAdapter;
        private base_nalogDataSetTableAdapters.Federal_districtTableAdapter districtTableAdapter = new base_nalogDataSetTableAdapters.Federal_districtTableAdapter();
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter = new base_nalogDataSetTableAdapters.SubjectsTableAdapter();
        private base_nalogDataSetTableAdapters.TaxesTableAdapter taxesTableAdapter;
        private base_nalogDataSetTableAdapters.Taxes_vedTableAdapter taxesVedTableAdapter;
        //
        #endregion Adapters
        #region Глобальные
        public AnalysisDataVariables Var { get { return var; } set { var = value; } }
        public base_nalogDataSet Ds { 
            get 
            {
                if (ds == null)
                {
                    cr.AnalysData.Ds = new base_nalogDataSet();
                }
                return ds; 
            } 
            set { ds = value; } }
        public base_nalogDataSetTableAdapters.ReportsTableAdapter ReportsTableAdapter 
        { 
            get 
            {
                if (reportsTableAdapter == null) reportsTableAdapter = new base_nalogDataSetTableAdapters.ReportsTableAdapter();
                return reportsTableAdapter; 
            } set { reportsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Federal_districtTableAdapter DistrictTableAdapter { get { return districtTableAdapter; } set { districtTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.SubjectsTableAdapter SubjectsTableAdapter { get { return subjectsTableAdapter; } set { subjectsTableAdapter = value; } }
        #endregion Глобальные
        #endregion Переменные
        public AnalysisData(Core Cr, base_nalogDataSet Ds,
            Forms.FormAnalysisData FrmAnalysisData)
        {
            this.cr = Cr;
            this.ds = Ds;
            this.frmAnalysisData = FrmAnalysisData;
            var = new AnalysisDataVariables(cr, this);
            dsView = new base_nalog_viewsDataSet();
            comViews = new Forms.ComponentViews();
            //b = new Data.Base(var, this);
            cr.B.Var = var;
            cr.B.AnData = this;
            if (cr.B.IsSql)
            {
                var.ArrYears = cr.B.BaseSql.defineMaxMinYear();
            }
            if (cr.B.IsOledb)
            {
                   var.ArrYears = cr.B.BaseOleDb.defineMaxMinYear();
            }
            //readXmlParams("reports\\Reports_params.xml");
            //var.DsXml = new DataSet("XML");
            fillStandartDsTables();
        }
        public AnalysisData(Core Cr)
        {
            this.cr = Cr;
            var = new AnalysisDataVariables(cr, this);
            dsView = new base_nalog_viewsDataSet();
            cr.B.Var = var;
            cr.B.AnData = this;
            comViews = new Forms.ComponentViews();
            //readXmlParams("reports\\Reports_params.xml");
            //var.DsXml = new DataSet("XML");
            fillStandartDsTables();
        }
        public Forms.FormReport SwitchReport(bool create, int index)
        {
            if (cr.B.IsSql)
            {
                //SQL
                cr.B.BaseSql.DbConn = null;
            }
            if (cr.B.IsOledb)
            {
                //OleDb
                cr.B.BaseOleDb.DbConn = null;
            }
            bool error = false;
            if (create)
            {
                cr.FrmReportView = new Forms.FormReport(cr);
                cr.FrmReportView.reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
                selectReport(0);
                //
                if (var.SourceTable.Rows.Count < 1) { var.ErrorList.Add("Нет данный для выборки"); error=true; }
                if (!error)
                {

                    /*if (pReports != null) { pReports = null; }*/
                    pReports = new PropertiesReport();
                    //arrReports.Add(pReports);
                    if (arrReports.Count > 0) { cr.FrmReportView.FrmIndex = arrReports.Count; var.ReportIndex = cr.FrmReportView.FrmIndex; }
                    else { cr.FrmReportView.FrmIndex = 0; var.ReportIndex = 0; }
                    pReports.Var = new AnalysisDataVariables();
                    pReports.FrmReport = new Forms.FormReport(cr);
                    pReports.FrmReport = cr.FrmReportView;
                    pReports.Var = var;
                    arrReports.Add(pReports);
                    cr.FrmReportView.MdiParent = cr.FrmApp;
                }
            }
            else
            {
                if (var.SourceTable.Rows.Count < 1) { var.ErrorList.Add("Нет данный для выборки"); error = true; }
                if (!error)
                {
                    pReports = (PropertiesReport)arrReports[index];
                    var = pReports.Var;
                    cr.FrmReportView = pReports.FrmReport;
                    //
                    selectReport(0);
                    //
                }
            }
            
            if (frmAnalysisData != null)
            {
                var.HeadFrmReport = frmAnalysisData.Tag + ": " + var.HeadFrmReport + " " + cr.AnalysData.var.NameTextReport;
                if ((var.YearBefore - var.YearAfter) > 1) { var.StrYears = var.YearAfter + " - " + var.YearBefore; } else { var.StrYears = " " + var.YearAfter; }
                cr.FrmReportView.Text = var.HeadFrmReport + " " + var.StrYears;
            }
            return cr.FrmReportView;
        }
        public void readXmlParams(string param)
        {
            TextReader tr = new StringReader(param);
            var.DsXml = new DataSet("XML");
            var.DsXml.ReadXml(tr);
        }
        public void selectReport(int setting)
        {
            int count = 0;
            if (var.IdReportXML > -1)
            {
                count++;
                int i = var.IdReportXML;
                i = 0;
                if (cr.B.IsSql)
                {
                    //SQL
                    cr.B.BaseSql.DbConn = new System.Data.SqlClient.SqlConnection();
                    cr.B.BaseSql.DbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                    cr.B.BaseSql.DbConn.Open();
                    cr.B.BaseSql.DbCom = cr.B.BaseSql.DbConn.CreateCommand();
                    cr.B.BaseSql.defineParameters();
                }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    cr.B.BaseOleDb.DbConn = new System.Data.OleDb.OleDbConnection();
                    cr.B.BaseOleDb.DbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                    cr.B.BaseOleDb.DbConn.Open();
                    cr.B.BaseOleDb.DbCom = cr.B.BaseOleDb.DbConn.CreateCommand();
                    cr.B.BaseOleDb.defineParameters();
                }
                //Обработка расчетных параметров
                //
                bool isDirect = false;
                try
                {
                    isDirect = Convert.ToBoolean(var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementIsDirect].ToString());
                }
                catch (System.Exception err)
                {
                }

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
                if (cr.B.IsSql)
                {
                    //SQL
                    if (var.IdTax > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdTax); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdTax.ParameterName].Value = var.IdTax; }
                    if (var.IdEea > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdEea); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdEea.ParameterName].Value = var.IdEea; }
                    if (var.YearAfter > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamYearAfter); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamYearAfter.ParameterName].Value = var.YearAfter; }
                    if (var.YearBefore > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamYearBefore); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamYearBefore.ParameterName].Value = var.YearBefore; }
                }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    if (var.IdTax > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdTax); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdTax.ParameterName].Value = var.IdTax; }
                    if (var.IdEea > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdEea); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdEea.ParameterName].Value = var.IdEea; }
                    if (var.YearAfter > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamYearAfter); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamYearAfter.ParameterName].Value = var.YearAfter; }
                    if (var.YearBefore > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamYearBefore); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamYearBefore.ParameterName].Value = var.YearBefore; }
                }
                //
                if (cr.B.IsSql)
                {
                    //SQL
                    cr.B.BaseSql.DbCom.CommandText = var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementSQL].ToString() +
                        cr.B.BaseSql.queryEvent(i, isDirect,
                        var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementMainTable].ToString(),
                        var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementLineFilter].ToString(),
                        var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementYearFilter].ToString(),
                        var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementYearsOperationSigns].ToString()) + orderBy(i);
                }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    cr.B.BaseOleDb.DbCom.CommandText = var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementSQL].ToString() +
                        cr.B.BaseOleDb.queryEvent(i, isDirect,
                        var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementMainTable].ToString(),
                        var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementLineFilter].ToString(),
                        var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementYearFilter].ToString(),
                        var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementYearsOperationSigns].ToString()) + orderBy(i);
                }
                //
                switch (setting)
                {
                    #region Для формы отчета
                    case 0:
                        {
                            if (cr.B.IsSql)
                            {
                                //SQL
                                cr.B.BaseSql.DbDataAdp = new System.Data.SqlClient.SqlDataAdapter(cr.B.BaseSql.DbCom);
                            }
                            if (cr.B.IsOledb)
                            {
                                //OLEDB
                                cr.B.BaseOleDb.DbDataAdp = new System.Data.OleDb.OleDbDataAdapter(cr.B.BaseOleDb.DbCom);
                            }
                            var.SourceTable = new DataTable();
                            var.SourceTable.TableName = var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementTableDataNameBase].ToString() + var.ReportIndex;

                            try
                            {
                                bool done = false;
                                if (cr.B.IsSql)
                                {
                                    //SQL
                                    cr.B.BaseSql.DbDataAdp.Fill(var.SourceTable);
                                    done = true;
                                }
                                if (cr.B.IsOledb)
                                {
                                    //SQL
                                    cr.B.BaseOleDb.DbDataAdp.Fill(var.SourceTable);
                                    done = true;
                                }
                                if (done && var.AddZeroToReport)
                                {
                                    string[] columns = { "lawrence_accum_share_ti_in_district", "lawrence_accum_share_busyed_in_district", "lawrence_accum_share_ti_ideal_in_district","lawrence_accum_share_busyed_ideal_in_district" };
                                    DataRow dr = var.SourceTable.NewRow();
                                    foreach (DataColumn dc in var.SourceTable.Columns)
                                    {
                                        foreach (string cl in columns)
                                        {
                                            if (dc.ColumnName == cl)
                                            {
                                                dr[dc] = 0;
                                            }
                                        }
                                    }
                                    var.SourceTable.Rows.Add(dr);
                                }
                            }
                            catch (System.Exception err)
                            {

                                cr.AnalysData.var.ErrorList.Add(err.ToString());
                            }

                            dsView.Tables.Add(var.SourceTable);
                            if (cr.B.IsSql)
                            {
                                //SQL
                                cr.B.BaseSql.DbConn.Close();
                            }
                            if (cr.B.IsOledb)
                            {
                                //OLEDB
                                cr.B.BaseOleDb.DbConn.Close();
                            }

                            //var.SourceTable = dsView.Tables[dsXml.Tables[xmlTableName].Rows[i][xmlElementTableDataNameBase].ToString()];

                            cr.FrmReportView.reportDataSource.Name = var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementReportDataSetName].ToString();

                            comViews.CustomBindingSource.DataSource = var.SourceTable;

                            cr.FrmReportView.reportDataSource.Value = comViews.CustomBindingSource;

                            cr.FrmReportView.reportViewerData.LocalReport.DataSources.Clear();

                            cr.FrmReportView.reportViewerData.LocalReport.DataSources.Add(cr.FrmReportView.reportDataSource);
                            string idDistrict = "";
                            string yearAfter = "";
                            string yearBefore = "";
                            try
                            {
                                idDistrict = var.IdDistrict.ToString();
                            }
                            catch (System.Exception err)
                            {
                            }
                            try
                            {
                                yearAfter = var.YearAfter.ToString();
                            }
                            catch (System.Exception err)
                            {
                            }
                            try
                            {
                                yearBefore = var.YearBefore.ToString();
                            }
                            catch (System.Exception err)
                            {
                            }
                            ReportParamDistrictName = new ReportParameter("DistrictName", idDistrict);
                            ReportParamYearAfter = new ReportParameter("year_min", yearAfter);
                            ReportParamYearBefore = new ReportParameter("year_max", yearBefore);

                            cr.FrmReportView.reportViewerData.LocalReport.ReportPath = cr.AppPath +
                                NalogUser.Properties.folders.Default.folderReports +
                                var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementReportName].ToString() + "." +
                                var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementReportExtention].ToString();
                            //cr.FrmReportView.reportViewerData.LocalReport.SetParameters(new ReportParameter[] { ReportParamYearAfter, ReportParamYearBefore });
                            cr.FrmReportView.reportViewerData.LocalReport.Refresh();
                            break;
                        }
                    #endregion Для формы отчета
                    #region Для карты
                    case 1:
                        {
                            if (cr.B.IsSql)
                            {
                                //SQL
                                cr.B.BaseSql.DbDataAdp = new System.Data.SqlClient.SqlDataAdapter(cr.B.BaseSql.DbCom);
                            }
                            if (cr.B.IsOledb)
                            {
                                //OLEDB
                                cr.B.BaseOleDb.DbDataAdp = new System.Data.OleDb.OleDbDataAdapter(cr.B.BaseOleDb.DbCom);
                            }
                            //dsView.Tables[dsXml.Tables[xmlTableName].Rows[i][xmlElementTableDataNameBase].ToString()].Clear();
                            var.SourceTable = new DataTable();
                            var.SourceTable.TableName = var.DsXml.Tables[var.XmlTableName].Rows[i][var.XmlElementTableDataNameBase].ToString() + var.ReportIndex;
                            //
                            if (cr.B.IsSql)
                            {
                                //SQL
                                cr.B.BaseSql.ParamIdSubject = new System.Data.SqlClient.SqlParameter("@ParametrIdSubject", var.IdSubject);
                                cr.B.BaseSql.ArrayParamsIdsSubjects.Add(cr.B.BaseSql.ParamIdSubject);
                                cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdSubject);
                            }
                            if (cr.B.IsOledb)
                            {
                                //OLEDB
                                cr.B.BaseOleDb.ParamIdSubject = new System.Data.OleDb.OleDbParameter("@ParametrIdSubject", var.IdSubject);
                                cr.B.BaseOleDb.ArrayParamsIdsSubjects.Add(cr.B.BaseOleDb.ParamIdSubject);
                                cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdSubject);
                            }
                            //
                            /*cr.B.BaseSql.DbDataAdp.Fill(
                                dsView.Tables[dsXml.Tables[xmlTableName].Rows[i][xmlElementTableDataNameBase].ToString()]
                                );*/
                            try
                            {
                                if (cr.B.IsSql)
                                {
                                    //SQL
                                    cr.B.BaseSql.DbDataAdp.Fill(var.SourceTable);
                                }
                                if (cr.B.IsOledb)
                                {
                                    //OLEDB
                                    cr.B.BaseOleDb.DbDataAdp.Fill(var.SourceTable);
                                }
                            }
                            catch (System.Exception err)
                            {
                            }

                            dsView.Tables.Add(var.SourceTable);
                            if (cr.B.IsSql)
                            {
                                //SQL
                                cr.B.BaseSql.DbConn.Close();
                            }
                            if (cr.B.IsOledb)
                            {
                                //OLEDB
                                cr.B.BaseOleDb.DbConn.Close();
                            }

                            break;
                        }
                    #endregion Для карты
                }
            }

        }
        public DataTable requestMapMoreInfoSubject(int id_subject = 0, short year = 0, int id_tax=0)
        {
            /*
             * Функция для вовзрата дополнительных сведений о субъекте для модуля карты
             * */
            DataTable dt = new DataTable();
            if (cr.B.IsSql)
            {
                //SQL
                cr.B.BaseSql.ArrayParamsIdsSubjects.Clear();
            }
            if (cr.B.IsOledb)
            {
                //OLEDB
                cr.B.BaseOleDb.ArrayParamsIdsSubjects.Clear();
            }
            if (id_subject != 0 && year != 0)
            {
                var.IdSubject = id_subject;
                var.YearAfter = year;
                var.YearBefore = year;
                var.IdTax = id_tax;
                //
                if (cr.B.IsSql)
                {
                    //SQL
                    cr.B.BaseSql.DbConn = new System.Data.SqlClient.SqlConnection();
                    cr.B.BaseSql.DbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                    cr.B.BaseSql.DbConn.Open();
                    cr.B.BaseSql.DbCom = cr.B.BaseSql.DbConn.CreateCommand();
                    cr.B.BaseSql.defineParameters();
                    //
                    cr.B.BaseSql.DbCom.CommandText = "SELECT id_district, district_name, id_subject, subject_name, short_name, latin_name, total_population, share_total_population, busyed, share_busyed, unemployed, share_unemployed, sum_total_ti_subject, share_ti_subject, year, sum_total_ti_subject_last, total_population_last, busyed_last, unemployed_last, year_last, total_population_change, busyed_change, unemployed_change, sum_total_ti_subject_change, salary, salary_last, ti_1130, ti_1130_last FROM [tax-177_nalog].View_map_detail_subjects";
                    //

                    if (var.IdDistrict > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdDistrict); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdDistrict.ParameterName].Value = var.IdDistrict; }
                    //
                    cr.B.BaseSql.ParamIdSubject = new System.Data.SqlClient.SqlParameter("@ParametrIdSubject", var.IdSubject);
                    cr.B.BaseSql.ArrayParamsIdsSubjects.Add(cr.B.BaseSql.ParamIdSubject);
                    //cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdSubject);
                    //
                    //cr.B.BaseSql.DbCom.Parameters.Clear();
                    //
                    if (var.IdSubject > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdSubject); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdSubject.ParameterName].Value = var.IdSubject; }
                    if (var.IdTax > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdTax); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdTax.ParameterName].Value = var.IdTax; }
                    if (var.IdEea > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdEea); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdEea.ParameterName].Value = var.IdEea; }
                    if (var.YearAfter > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamYearAfter); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamYearAfter.ParameterName].Value = var.YearAfter; }
                    if (var.YearBefore > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamYearBefore); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamYearBefore.ParameterName].Value = var.YearBefore; }
                    //
                    cr.B.BaseSql.DbCom.CommandText += cr.B.BaseSql.queryEvent(0, true, "") + orderBy(0);
                    //
                    cr.B.BaseSql.DbDataAdp = new System.Data.SqlClient.SqlDataAdapter(cr.B.BaseSql.DbCom);
                }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    //SQL
                    cr.B.BaseOleDb.DbConn = new System.Data.OleDb.OleDbConnection();
                    cr.B.BaseOleDb.DbConn.ConnectionString = NalogUser.App.Default.ConnectionString.ToString();
                    cr.B.BaseOleDb.DbConn.Open();
                    cr.B.BaseOleDb.DbCom = cr.B.BaseOleDb.DbConn.CreateCommand();
                    cr.B.BaseOleDb.defineParameters();
                    //
                    cr.B.BaseOleDb.DbCom.CommandText = "SELECT id_district, district_name, id_subject, subject_name, short_name, latin_name, total_population, share_total_population, busyed, share_busyed, unemployed, share_unemployed, sum_total_ti_subject, share_ti_subject, year, sum_total_ti_subject_last, total_population_last, busyed_last, unemployed_last, year_last, total_population_change, busyed_change, unemployed_change, sum_total_ti_subject_change, salary, salary_last, ti_1130, ti_1130_last FROM View_map_detail_subjects";
                    //

                    if (var.IdDistrict > 0) { cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdDistrict); cr.B.BaseSql.DbCom.Parameters[cr.B.BaseSql.ParamIdDistrict.ParameterName].Value = var.IdDistrict; }
                    //
                    cr.B.BaseOleDb.ParamIdSubject = new System.Data.OleDb.OleDbParameter("@ParametrIdSubject", var.IdSubject);
                    cr.B.BaseOleDb.ArrayParamsIdsSubjects.Add(cr.B.BaseOleDb.ParamIdSubject);
                    //cr.B.BaseSql.DbCom.Parameters.Add(cr.B.BaseSql.ParamIdSubject);
                    //
                    //cr.B.BaseSql.DbCom.Parameters.Clear();
                    //
                    if (var.IdSubject > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdSubject); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdSubject.ParameterName].Value = var.IdSubject; }
                    if (var.IdTax > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdTax); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdTax.ParameterName].Value = var.IdTax; }
                    if (var.IdEea > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamIdEea); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamIdEea.ParameterName].Value = var.IdEea; }
                    if (var.YearAfter > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamYearAfter); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamYearAfter.ParameterName].Value = var.YearAfter; }
                    if (var.YearBefore > 0) { cr.B.BaseOleDb.DbCom.Parameters.Add(cr.B.BaseOleDb.ParamYearBefore); cr.B.BaseOleDb.DbCom.Parameters[cr.B.BaseOleDb.ParamYearBefore.ParameterName].Value = var.YearBefore; }
                    //
                    cr.B.BaseOleDb.DbCom.CommandText += cr.B.BaseOleDb.queryEvent(0, true, "") + orderBy(0);
                    //
                    cr.B.BaseOleDb.DbDataAdp = new System.Data.OleDb.OleDbDataAdapter(cr.B.BaseOleDb.DbCom);
                }
                try
                {
                    if (cr.B.IsSql)
                    {
                        //SQL
                        cr.B.BaseSql.DbDataAdp.Fill(dt);
                    }
                    if (cr.B.IsOledb)
                    {
                        //OLEDB
                        cr.B.BaseOleDb.DbDataAdp.Fill(dt);
                    }
                }
                catch (System.Exception err)
                {
                    cr.AnalysData.var.ErrorList.Add(err.ToString());
                }
                if (cr.B.IsSql)
                {
                    //SQL
                    cr.B.BaseSql.DbConn.Close();
                }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    cr.B.BaseOleDb.DbConn.Close();
                }
            }
            return dt;
        }
        public bool CheckParam(string ParamName, int index)
        {
            bool y = false;
            /*if (dsView.Tables[dsXml.Tables[xmlTableName].Rows[index][xmlElementTableDataNameBase].ToString()]!=null)
            {
                int col = dsView.Tables[dsXml.Tables[xmlTableName].Rows[index][xmlElementTableDataNameBase].ToString()].Columns.Count;
                for (int i = 0; i < col; i++)
                {
                    if (dsView.Tables[dsXml.Tables[xmlTableName].Rows[index][xmlElementTableDataNameBase].ToString()].Columns[i].ColumnName == ParamName)
                    { y = true; break; }
                    else
                    { y = false; }
                }
            }*/
            string SQL = var.DsXml.Tables[var.XmlTableName].Rows[index][var.XmlElementSQL].ToString();
            int countCharSQL = SQL.Length;
            string error = "";
            for (int i = 0; i < countCharSQL; i++)
            {
                string substring = "";
                try
                {
                    substring = SQL.Substring(i, ParamName.Length);
                    if (substring == ParamName)
                    { y = true; break; }
                    else
                    { y = false; }
                }
                catch (System.Exception err)
                {
                }
            }
            return y;
        }
        private string orderBy(int index)
        {
            string str="";
            string order = var.DsXml.Tables[var.XmlTableName].Rows[index][var.XmlElementOrderBy].ToString();
            if (order != "") { str = " ORDER BY " + order; }
            return str;
        }
        private void fillStandartDsTables()
        {
            if (cr.AnalysData != null)
            {
                if (cr.AnalysData.Ds != null)
                {
                    if (cr.AnalysData.Ds.Federal_district.Rows.Count < 1) { districtTableAdapter = new base_nalogDataSetTableAdapters.Federal_districtTableAdapter(); districtTableAdapter.Fill(cr.AnalysData.Ds.Federal_district); }
                    if (cr.AnalysData.Ds.Subjects.Rows.Count < 1) { subjectsTableAdapter = new base_nalogDataSetTableAdapters.SubjectsTableAdapter(); subjectsTableAdapter.Fill(cr.AnalysData.Ds.Subjects); }
                    if (cr.AnalysData.Ds.Taxes.Rows.Count < 1) { taxesTableAdapter = new base_nalogDataSetTableAdapters.TaxesTableAdapter(); taxesTableAdapter.Fill(cr.AnalysData.Ds.Taxes); }
                    if (cr.AnalysData.Ds.Taxes_ved.Rows.Count < 1) { taxesVedTableAdapter = new base_nalogDataSetTableAdapters.Taxes_vedTableAdapter(); taxesVedTableAdapter.Fill(cr.AnalysData.Ds.Taxes_ved); }
                }
            }
        }
        public int GetCountField()
        {
            int countField = 0;
            if (var.DsXml.Tables[var.XmlTableName].Rows[var.IdReportXML][var.XmlElementCountField].ToString() != "")
            {
                countField = Convert.ToInt32(var.DsXml.Tables[var.XmlTableName].Rows[var.IdReportXML][var.XmlElementCountField]);
            }
            if (var.NameParam != "")
            {
                countField = 1;
            }
            return countField;
        }
        public string GetXmlType()
        {
            string type = "";
            if (var.DsXml.Tables[var.XmlTableName].Rows[var.IdReportXML][var.XmlElementCountField].ToString() != "")
            {
                type = var.DsXml.Tables[var.XmlTableName].Rows[var.IdReportXML][var.XmlElementType].ToString();
            }
            return type;
        }
        public bool GetItForMap()
        {
            bool forMap = false;
            /*if (var.DsXml.Tables[var.XmlTableName].Rows[var.IdReportXML][var.XmlElementForMap].ToString() != "")
            {
                forMap = Convert.ToBoolean(var.DsXml.Tables[var.XmlTableName].Rows[var.IdReportXML][var.XmlElementForMap].ToString());
            }*/
            selectColumnFromSourceTable();
            if (cr.AnalysData.Var.ActiveColSourceTable == "") { forMap = false; } else { forMap = true; }
            return forMap;
        }
        public bool checkExistingFile(string path)
        {
            bool ok = false;
            if (File.Exists(path)) { ok = true; } else { ok = false; }
            return ok;
        }
        private void selectColumnFromSourceTable()
        {
            if (var.NameParam != "")
            {
                cr.AnalysData.Var.ActiveColSourceTable = var.NameParam;
                cr.AnalysData.Var.ActiveColSourceTableText = "Значение";
            }
            /*switch (cr.AnalysData.Var.NameReport)
            {
                case "kdol_subjects":
                    {
                        cr.AnalysData.Var.ActiveColSourceTable=cr.ClNames.Kdol.nameSQL;
                        cr.AnalysData.Var.ActiveColSourceTableText= cr.ClNames.Kdol.nameCol;
                        break;
                    }
                case "kdol_eea_subjects":
                    {
                        cr.AnalysData.Var.ActiveColSourceTable = cr.ClNames.Kdol_eea.nameSQL;
                        cr.AnalysData.Var.ActiveColSourceTableText = cr.ClNames.Kdol_eea.nameCol;
                        break;
                    }
                case "rmit_eea_subjects":
                    {
                        cr.AnalysData.Var.ActiveColSourceTable = cr.ClNames.Rmit_eea.nameSQL;
                        cr.AnalysData.Var.ActiveColSourceTableText = cr.ClNames.Rmit_eea.nameCol;
                        break;
                    }
                case "total_ti_subjects":
                    {
                        cr.AnalysData.Var.ActiveColSourceTable = cr.ClNames.Subject_total_ti.nameSQL;
                        cr.AnalysData.Var.ActiveColSourceTableText = cr.ClNames.Subject_total_ti.nameCol;
                        break;
                    }
                case "view_ti_tax":
                    {
                        cr.AnalysData.Var.ActiveColSourceTable = cr.ClNames.Ti_tax.nameSQL;
                        cr.AnalysData.Var.ActiveColSourceTableText = cr.ClNames.Ti_tax.nameCol;
                        break;
                    }
                case "ti_eea_subjects":
                    {
                        cr.AnalysData.Var.ActiveColSourceTable = cr.ClNames.Subject_ti_eea.nameSQL;
                        cr.AnalysData.Var.ActiveColSourceTableText = cr.ClNames.Subject_ti_eea.nameCol;
                        break;
                    }
                    
            }*/
        }
        #region Функции
        public float returnNullFloat(object rangeValue, int round=2)
        {
            float value = 0;
            double valueD = 0;
            try
            {
                value = Convert.ToSingle(rangeValue);
            }
            catch (System.Exception err)
            {
                value = 0;
            }
            if (round > 0)
            {
                valueD = Convert.ToDouble(value);
                valueD = Math.Round(value, round);
            }

            return (float)valueD;
        }
        public decimal returnNullDecimal(object rangeValue, int round = 2)
        {
            decimal value = 0;
            try
            {
                value = Convert.ToDecimal(rangeValue);
            }
            catch (System.Exception err)
            {
                value = 0;
            }
            if (round > 0)
            {
                value = Math.Round(value, round);
            }

            return value;
        }
        public double returnNullDouble(object rangeValue, int round = 2)
        {
            double value = 0;
            try
            {
                value = Convert.ToDouble(rangeValue);
            }
            catch (System.Exception err)
            {
                value = 0;
            }
            if (round > 0)
            {
                if (round > 15) round = 15;
                value = Math.Round(value, round);
            }
            if (value.ToString().Length - 1 > 28)
            {
                int delta = value.ToString().Length - 1 - 28;
                int newRound = 15 - delta;
                value = Math.Round(value, newRound);
            }
            return value;
        }
        public int returnNullInt(object rangeValue)
        {
            int value = 0;

            try
            {
                value = (int)Math.Round(Convert.ToSingle(rangeValue));
            }
            catch (System.Exception err)
            {
                value = 0;
            }

            return value;
        }
        public bool returnNullBool(object rangeValue)
        {
            bool value = false;
            try
            {
                value = Convert.ToBoolean(rangeValue);
            }
            catch (System.Exception err)
            {
                value = false;
            }

            return value;
        }
        #endregion Функции
    }
}
