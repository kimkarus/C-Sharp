﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace NalogAdministrator.Classes
{
    public class Data
    {
        private Files _files = new Files();
        private Base _base = new Base();
        //
        public Files Files { get { return _files; } set { _files = value; } }
        public Base Base { get { return _base; } set { _base = value; } }

    }
    public class Files
    {
        public Files()
        {
        }
        /*
         * Этот класс объектов отвечает за присоединение к файлу
         * эксель с помощью адаптера оле дб. Этот необходимо для более быстрого
         * считывания файлов и последующая их запись в базу.
         * */
        //провайдер
        private string strConnectionProv = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        //тип соединения
        private string strConnectionType = ";Extended Properties=Excel 8.0";
        private string ll = "";
        private string ll1 = ";HDR=NO;IMEX=0";
        private string ll2 = ";HDR=Yes;IMEX=1";
        private string ll3 = ";HDR=Yes;IMEX=0";
        private string ll4 = ";IMEX=0";
        private string ll5 = ";HDR=NO";
        private string ll6 = ";HDR=NO;IMEX=1";
        //Переменные для базы и табличных значений
        private OleDbConnection excelOleDbConn; //подключение через оледб
        private OleDbDataAdapter excelAdapter; //адаптер для подключения
        private DataTable dtExcel = new DataTable(); //таблица под эксель лист
        private DataSet dsExcel = new DataSet(); //коллекция таблиц
        private DataTable dtExcelMeta = new DataTable(); //Структура документа Ексель
        private base_nalogDataSet bsDs = new base_nalogDataSet();
        //Глобальные переменные
        public string StrConnectionProv { get { return strConnectionProv; } }
        public string StrConnectionType { get { return strConnectionType; } }
        public OleDbConnection ExcelOleDbConn { get { return excelOleDbConn; } set { excelOleDbConn = value; } }
        public OleDbDataAdapter ExcelAdapter { get { return excelAdapter; } set { excelAdapter = value; } }
        public DataTable DtExcel { get { return dtExcel; } set { dtExcel = value; } }
        public DataSet DsExcel { get { return dsExcel; } set { dsExcel = value; } }
        public DataTable DtExcelMeta { get { return dtExcelMeta; } set { dtExcelMeta = value; } }
        public base_nalogDataSet BsDs { get { return bsDs; } set { bsDs = value; } }
        //
        //
        //
        public string connectionString(string path)
        {
            /*
             * Эта фунция возвращает строку подключения к екселю.
             * */
            string connect = strConnectionProv + path + strConnectionType + ll;
            return connect;
        }
        
    }
    public class Base
    {
        #region Переменные
        private base_nalogDataSet ds;
        private base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter sourceData1NMTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_4NMTableAdapter sourceData4NMTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_5ENVDTableAdapter sourceData5ENVDTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_5USNTableAdapter sourceData5USNTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_1PATENTTableAdapter sourceData1PATENTTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter sourceData1NOMTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_1NOM_schemeTableAdapter sourceData1NOMSchemeTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOM_schemeTableAdapter();
        private base_nalogDataSetTableAdapters.Source_data_1NOM_budget_schemeTableAdapter sourceData1NOMBudgetSchemeTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOM_budget_schemeTableAdapter();
        private base_nalogDataSetTableAdapters.Source_data_1NOM_header_schemeTableAdapter sourceData1NOMHeaderSchemeTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NOM_header_schemeTableAdapter();
        private base_nalogDataSetTableAdapters.Source_data_PopulationTableAdapter sourceDataPopultationTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_Population_eeaTableAdapter sourceDataPopultationEeaTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_Subject_indexTableAdapter sourceDataSubjectIndexTableAdapter;
        private base_nalogDataSetTableAdapters.Compare_tax_eeaTableAdapter compareTaxEeaTableAdapter;
        private base_nalogDataSetTableAdapters.Compare_tax_budgetTableAdapter compareTaxBudgetTableAdapter;
        private base_nalogDataSetTableAdapters.Compare_eea_budgetTableAdapter compareEeaBudgetTableAdapter;
        private base_nalogDataSetTableAdapters.Source_data_1NM_schemeTableAdapter sourceData1NMSchemeTableAdapter = new base_nalogDataSetTableAdapters.Source_data_1NM_schemeTableAdapter();
        
        //
        private base_nalogDataSetTableAdapters.Data_warehouse_subjectTableAdapter dataWarehouseSubjectTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_subject_taxTableAdapter dataWarehouseSubjectTaxTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_taxTableAdapter dataWarehouseTaxTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_subject_eeaTableAdapter dataWarehouseSubjectEeaTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_subject_eea_gksTableAdapter dataWarehouseSubjectEeaGksTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_eeaTableAdapter dataWarehouseEeaTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_eea_gksTableAdapter dataWarehouseEeaGksTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_districtTableAdapter dataWarehouseDistrictTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_district_taxTableAdapter dataWarehouseDistrictTaxTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_district_eea_gksTableAdapter dataWarehouseDistrictEeaGksTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_subject_tax_budgetTableAdapter dataWarehouseSubjectTaxBudgetsTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_subject_eea_budgetTableAdapter dataWarehouseSubjectEeaBudgetsTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_subject_budgetTableAdapter dataWarehouseSubjectBudgetsTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_country_taxTableAdapter dataWarehouseCountryTaxTableAdapter;
        //
        private base_nalogDataSetTableAdapters.TimeTableAdapter timeTableAdapter = new base_nalogDataSetTableAdapters.TimeTableAdapter();
        private base_nalogDataSetTableAdapters.TaxesTableAdapter taxesTableAdapter = new base_nalogDataSetTableAdapters.TaxesTableAdapter();
        private base_nalogDataSetTableAdapters.DebtsTableAdapter debtsTableAdapter = new base_nalogDataSetTableAdapters.DebtsTableAdapter();
        private base_nalogDataSetTableAdapters.Taxes_vedTableAdapter taxesVedTableAdapter = new base_nalogDataSetTableAdapters.Taxes_vedTableAdapter();
        private base_nalogDataSetTableAdapters.UsnTableAdapter usnTableAdapter = new base_nalogDataSetTableAdapters.UsnTableAdapter();
        private base_nalogDataSetTableAdapters.EnvdTableAdapter envdTableAdapter = new base_nalogDataSetTableAdapters.EnvdTableAdapter();
        private base_nalogDataSetTableAdapters.PatentTableAdapter patentTableAdapter = new base_nalogDataSetTableAdapters.PatentTableAdapter();
        private base_nalogDataSetTableAdapters.SubjectsTableAdapter subjectsTableAdapter = new base_nalogDataSetTableAdapters.SubjectsTableAdapter();
        private base_nalogDataSetTableAdapters.Federal_districtTableAdapter federalDistrictsTableAdapter = new base_nalogDataSetTableAdapters.Federal_districtTableAdapter();
        private base_nalogDataSetTableAdapters.Taxes_budgetsTableAdapter taxesBudgetsTableAdapter = new base_nalogDataSetTableAdapters.Taxes_budgetsTableAdapter();
        private base_nalogDataSetTableAdapters.CountriesTableAdapter countriesTableAdapter = new base_nalogDataSetTableAdapters.CountriesTableAdapter();
        //
        private base_nalogDataSetTableAdapters.Data_model_subject_taxTableAdapter dataModelSubjectTaxTableAdapter;
        private base_nalogDataSetTableAdapters.Data_model_subject_tax_eeaTableAdapter dataModelSubjectTaxEeaTableAdapter;
        private base_nalogDataSetTableAdapters.Data_model_paramsTableAdapter dataModelParamsTableAdapter;
        private base_nalogDataSetTableAdapters.Data_modelsTableAdapter dataModelsTableAdapter;
        private base_nalogDataSetTableAdapters.Data_best_models_subject_taxTableAdapter dataBestModelsSubjectTaxTableAdapter;
        private base_nalogDataSetTableAdapters.Data_model_subject_budget_tax_indexesTableAdapter dataModelSubjectBudgetTaxIndexesTableAdapter;
        private base_nalogDataSetTableAdapters.Data_warehouse_forecast_subject_taxTableAdapter dataWarehouseForecastSubjectTaxTableAdapter;
        //
        private base_nalogDataSetTableAdapters.Data_correlation_subject_tax_eea_totalTableAdapter correlationSubjectTaxEeaTotalTableAdapter;
        private base_nalogDataSetTableAdapters.Data_correlation_subject_valuesTableAdapter correlationSubjectValuesTableAdapter;
        private base_nalogDataSetTableAdapters.Data_correlation_subject_tax_indexesTableAdapter correlationSubjectTaxIndexesTableAdapter;
        private base_nalogDataSetTableAdapters.Data_correlation_subject_tax_budget_indexesTableAdapter correlationSubjectTaxBudgetIndexesTableAdapter;
        private base_nalogDataSetTableAdapters.Data_correlation_subject_eea_budget_indexesTableAdapter correlationSubjectEeaBudgetIndexesTableAdapter;
        private base_nalogDataSetTableAdapters.Table_correlationsTableAdapter correlationCollectionTableAdapter;
        private base_nalogDataSetTableAdapters.Data_correlation_subject_budget_indexesTableAdapter correlationSubjectBudgetIndexesTableAdapter;
        //
        private base_nalogDataSetTableAdapters.Scheme_valuesTableAdapter schemeValuesTableAdapters;
        
        //
        private DataRow customRow;
        private DataTable customTable;
        private DataTable customMergeTable;
        private DataTable referenceTable;
        private DataSet customDs;
        //private DataSet referenceDataSet
        //
        private System.Data.DataRow[] internalTableRows;
        private base_nalogDataSet.TaxesDataTable taxes = new base_nalogDataSet.TaxesDataTable();
        private bool isDbConnection = false;
        private OleDbConnection dbConnection;
        #region Глобальные
        public base_nalogDataSet Ds { get { return ds; } set { ds = value; } }
        public base_nalogDataSetTableAdapters.Source_data_1NMTableAdapter SourceData1NMTableAdapter { get { return sourceData1NMTableAdapter; } set { sourceData1NMTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_4NMTableAdapter SourceData4NMTableAdapter { get { return sourceData4NMTableAdapter; } set { sourceData4NMTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_1PATENTTableAdapter SourceData1PATENTTableAdapter { get { return sourceData1PATENTTableAdapter; } set { sourceData1PATENTTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_5ENVDTableAdapter SourceData5ENVDTableAdapter { get { return sourceData5ENVDTableAdapter; } set { sourceData5ENVDTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_5USNTableAdapter SourceData5USNTableAdapter { get { return sourceData5USNTableAdapter; } set { sourceData5USNTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_1NOMTableAdapter SourceData1NOMTableAdapter { get { return sourceData1NOMTableAdapter; } set { sourceData1NOMTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_1NOM_schemeTableAdapter SourceData1NOMSchemeTableAdapter { get { return sourceData1NOMSchemeTableAdapter; } }
        public base_nalogDataSetTableAdapters.Source_data_1NOM_budget_schemeTableAdapter SourceData1NOMBudgetSchemeTableAdapter { get { return sourceData1NOMBudgetSchemeTableAdapter; } }
        public base_nalogDataSetTableAdapters.Source_data_1NOM_header_schemeTableAdapter SourceData1NOMHeaderSchemeTableAdapter { get { return sourceData1NOMHeaderSchemeTableAdapter; } }
        public base_nalogDataSetTableAdapters.Source_data_PopulationTableAdapter SourceDataPopulationTableAdapter { get { return sourceDataPopultationTableAdapter; } set { sourceDataPopultationTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_Population_eeaTableAdapter SourceDataPopulationEeaTableAdapter { get { return sourceDataPopultationEeaTableAdapter; } set { sourceDataPopultationEeaTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_Subject_indexTableAdapter SourceDataSubjectIndexTableAdapter { get { return sourceDataSubjectIndexTableAdapter; } set { sourceDataSubjectIndexTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Compare_tax_eeaTableAdapter CompareTaxEeaTableAdapter { get { return compareTaxEeaTableAdapter; } set { compareTaxEeaTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Compare_tax_budgetTableAdapter CompareTaxBudgetTableAdapter { get { return compareTaxBudgetTableAdapter; } set { compareTaxBudgetTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Source_data_1NM_schemeTableAdapter SourceData1NMSchemeTableAdapter { get { return sourceData1NMSchemeTableAdapter; } set { sourceData1NMSchemeTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Compare_eea_budgetTableAdapter CompareEeaBudgetTableAdapter {get {return compareEeaBudgetTableAdapter;} set{compareEeaBudgetTableAdapter=value;}}
        //
        public base_nalogDataSetTableAdapters.Data_warehouse_subjectTableAdapter DataWarehouseSubjectTableAdapter { get { return dataWarehouseSubjectTableAdapter; } set { dataWarehouseSubjectTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_subject_taxTableAdapter DataWarehouseSubjectTaxTableAdapter { get { return dataWarehouseSubjectTaxTableAdapter; } set { dataWarehouseSubjectTaxTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_taxTableAdapter DataWarehouseTaxTableAdapter { get { return dataWarehouseTaxTableAdapter; } set { dataWarehouseTaxTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_subject_eeaTableAdapter DataWarehouseSubjectEeaTableAdapter { get { return dataWarehouseSubjectEeaTableAdapter; } set { dataWarehouseSubjectEeaTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_subject_eea_gksTableAdapter DataWarehouseSubjectEeaGksTableAdapter { get { return dataWarehouseSubjectEeaGksTableAdapter; } set { dataWarehouseSubjectEeaGksTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_eeaTableAdapter DataWarehouseEeaTableAdapter { get { return dataWarehouseEeaTableAdapter; } set { dataWarehouseEeaTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_eea_gksTableAdapter DataWarehouseEeaGksTableAdapter { get { return dataWarehouseEeaGksTableAdapter; } set { dataWarehouseEeaGksTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_districtTableAdapter DataWarehouseDistrictTableAdapter { get { return dataWarehouseDistrictTableAdapter; } set { dataWarehouseDistrictTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_district_eea_gksTableAdapter DataWarehouseDistrictEeaGksTableAdapter { get { return dataWarehouseDistrictEeaGksTableAdapter; } set { dataWarehouseDistrictEeaGksTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_district_taxTableAdapter DataWarehouseDistrictTaxTableAdapter { get { return dataWarehouseDistrictTaxTableAdapter; } set { dataWarehouseDistrictTaxTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_subject_tax_budgetTableAdapter DataWarehouseSubjectTaxBudgetsTableAdapter { get { return dataWarehouseSubjectTaxBudgetsTableAdapter; } set { dataWarehouseSubjectTaxBudgetsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_subject_eea_budgetTableAdapter DataWarehouseSubjectEeaBudgetsTableAdapter { get { return dataWarehouseSubjectEeaBudgetsTableAdapter; } set { dataWarehouseSubjectEeaBudgetsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_subject_budgetTableAdapter DataWarehouseSubjectBudgetsTableAdapter { get { return dataWarehouseSubjectBudgetsTableAdapter; } set { dataWarehouseSubjectBudgetsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_country_taxTableAdapter DataWarehouseCountryTaxTableAdapter { get { return dataWarehouseCountryTaxTableAdapter; } set { dataWarehouseCountryTaxTableAdapter = value; } }
        //
        public base_nalogDataSetTableAdapters.TimeTableAdapter TimeTableAdapter { get { return timeTableAdapter; } set { timeTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.TaxesTableAdapter TaxesTableAdapter { get { return taxesTableAdapter; } set { taxesTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.UsnTableAdapter UsnTableAdapter { get { return usnTableAdapter; } set { usnTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.EnvdTableAdapter EnvdTableAdapter { get { return envdTableAdapter; } set { envdTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.PatentTableAdapter PatentTableAdapter { get { return patentTableAdapter; } set { patentTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.DebtsTableAdapter DebtsTableAdapter { get { return debtsTableAdapter; } set { debtsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Taxes_vedTableAdapter TaxesVedTableAdapter { get { return taxesVedTableAdapter; } set { taxesVedTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.SubjectsTableAdapter SubjectsTableAdapter { get { return subjectsTableAdapter; } set { subjectsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Federal_districtTableAdapter FederalDistrictsTableAdapter { get { return federalDistrictsTableAdapter; } set { federalDistrictsTableAdapter = value; } }
        public System.Data.DataRow[] InternalDataTableRows { get { return internalTableRows; } set { internalTableRows = value; } }
        public base_nalogDataSetTableAdapters.Taxes_budgetsTableAdapter TaxesBudgetsTableAdapter { get { return taxesBudgetsTableAdapter; } set { taxesBudgetsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.CountriesTableAdapter CountriesTableAdapter { get { return countriesTableAdapter; } set { countriesTableAdapter = value; } }
        //
        public base_nalogDataSetTableAdapters.Data_model_subject_taxTableAdapter DataModelSubjectTaxTableAdapter { get { return dataModelSubjectTaxTableAdapter; } set { dataModelSubjectTaxTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_model_subject_tax_eeaTableAdapter DataModelSubjectTaxEeaTableAdapter { get { return dataModelSubjectTaxEeaTableAdapter; } set { dataModelSubjectTaxEeaTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_model_paramsTableAdapter DataModelParamsTableAdapter { get { return dataModelParamsTableAdapter; } set { dataModelParamsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_modelsTableAdapter DataModelsTableAdapter { get { return dataModelsTableAdapter; } set { dataModelsTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_best_models_subject_taxTableAdapter DataBestModelsSubjectTaxTableAdapter { get { return dataBestModelsSubjectTaxTableAdapter; } set { dataBestModelsSubjectTaxTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_model_subject_budget_tax_indexesTableAdapter DataModelSubjectBudgetTaxIndexesTableAdapter { get { return dataModelSubjectBudgetTaxIndexesTableAdapter; } set { dataModelSubjectBudgetTaxIndexesTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_warehouse_forecast_subject_taxTableAdapter DataWarehouseForecastSubjectTaxTableAdapter { get { return dataWarehouseForecastSubjectTaxTableAdapter; } set { dataWarehouseForecastSubjectTaxTableAdapter = value; } }
        //
        public DataRow CustomRow { get { return customRow; } set { customRow = value; } }
        public DataTable CustomTable { get { return customTable; } set { customTable = value; } }
        public DataTable CustomMergeTable { get { return customMergeTable; } set { customMergeTable = value; } }
        public DataTable ReferenceTable { get { return referenceTable; } set { referenceTable = value; } }
        public DataSet CustomDs { get { return customDs; } set { customDs = value; } }
        //
        public base_nalogDataSetTableAdapters.Data_correlation_subject_tax_eea_totalTableAdapter CorrelationSubjectTaxEeaTotalTableAdapter { get { return correlationSubjectTaxEeaTotalTableAdapter; } set { correlationSubjectTaxEeaTotalTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_correlation_subject_valuesTableAdapter CorrelationSubjectValuesTableAdapter { get { return correlationSubjectValuesTableAdapter; } set { correlationSubjectValuesTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_correlation_subject_tax_indexesTableAdapter CorrelationSubjectTaxIndexesTableAdapter { get { return correlationSubjectTaxIndexesTableAdapter; } set { correlationSubjectTaxIndexesTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_correlation_subject_tax_budget_indexesTableAdapter CorrelationSubjectTaxBudgetIndexesTableAdapter { get { return correlationSubjectTaxBudgetIndexesTableAdapter; } set { correlationSubjectTaxBudgetIndexesTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_correlation_subject_eea_budget_indexesTableAdapter CorrelationSubjectEeaBudgetIndexesTableAdapter { get { return correlationSubjectEeaBudgetIndexesTableAdapter; } set { correlationSubjectEeaBudgetIndexesTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Table_correlationsTableAdapter CorrelationCollectionTableAdapter { get { return correlationCollectionTableAdapter; } set { correlationCollectionTableAdapter = value; } }
        public base_nalogDataSetTableAdapters.Data_correlation_subject_budget_indexesTableAdapter CorrelationSubjectBudgetIndexesTableAdapter { get { return correlationSubjectBudgetIndexesTableAdapter; } set { correlationSubjectBudgetIndexesTableAdapter = value; } }
        //
        public base_nalogDataSetTableAdapters.Scheme_valuesTableAdapter SchemeValuesTableAdapters { get { return schemeValuesTableAdapters; } set { schemeValuesTableAdapters = value; } }
        public bool IsDbConnection { 
            get 
            { 
                return isDbConnection; 
            } 
        }
        public SqlConnection SqlConn { get { return sqlConn; } set { sqlConn = value; } }
        public SqlCommand SqlCom { get { return sqlCom; } set { sqlCom = value; } }
        public SqlDataAdapter SqlDataAdp { get { return sqlDataAdp; } set { sqlDataAdp = value; } }
        #endregion Глобальные
        private SqlConnection sqlConn;
        private SqlCommand sqlCom;
        private SqlDataAdapter sqlDataAdp;
        #endregion Переменные
        public Base()
        {
            ds = new base_nalogDataSet();
            try
            {
                //dbConnection = new OleDbConnection(NalogAdministrator.Properties.Settings.Default.base_nalogConnectionString);
                //dbConnection.Open();
                //isDbConnection = true;
            }
            catch (System.Exception err)
            {
                //isDbConnection = false;
                Console.WriteLine(err.ToString());
            }
            //OleDbCommand command=new OleDbCommand("UPDATE Source_data_Population_eea
            //dbConnection.Close();
        }
    }
}
