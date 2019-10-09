using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;

namespace NalogAdministrator.Forms
{
    public partial class FormDataAggregation : Form
    {
        private Classes.Core cr;
        private Agregation agr;
        public FormDataAggregation(Classes.Core Cr)
        {
            this.cr = Cr;
            InitializeComponent();
            agr = new Agregation(cr, this);
            this.comboBoxSelectTypeAgregation.Items.Clear();
            for (int i = 0; i < agr.ArrTypeAgregation.Length / 5; i++)
            {
                this.comboBoxSelectTypeAgregation.Items.Add(agr.ArrTypeAgregation[i, 0]);
            }
        }
        private void comboBoxSelectTypeAgregation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chkListBoxAgregationParam.Items.Clear();
            if (agr.IsTypeAgregation(comboBoxSelectTypeAgregation.SelectedItem.ToString()))
            {
                btStartAgregation.Enabled = true;
                chkListBoxAgregationParam.Items.AddRange(agr.FieldsAgregation);
            }
        }
        private void btStartAgregation_Click(object sender, EventArgs e)
        {
            agr.startAgregation();
        }
        private void chSetAll_CheckedChanged(object sender, EventArgs e)
        {
            setChekedListAgregationParam(chSetAll.Checked);
        }
        private void setChekedListAgregationParam(bool chk)
        {
            for (int i = 0; i < chkListBoxAgregationParam.Items.Count; i++)
            {
                chkListBoxAgregationParam.SetItemChecked(i, chk);
            }
        }

        private void FormDataAggregation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'base_nalogDataSet.Subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.base_nalogDataSet.Subjects);

        }

        private void checkBoxFilterYears_CheckedChanged(object sender, EventArgs e)
        {
            textBoxYearAfter.Enabled = checkBoxFilterYears.Checked;
            textBoxYearBefore.Enabled = checkBoxFilterYears.Checked;
        }

        private void checkBoxFilterSubject_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSubjects.Enabled = checkBoxFilterSubject.Checked;
        }

        private void checkBoxPrefix_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPrefix.Enabled = checkBoxPrefix.Checked;
        }
    }
    public class Agregation
    {
        private Classes.Core cr;
        private Classes.Data data;
        private base_nalogDataSet ds;
        private Classes.ImpData.ImportData impData;
        private Classes.ImpData.ImportDataVariables var;
        private Forms.FormDataAggregation frmAgr;

        public Agregation(Classes.Core Cr, Forms.FormDataAggregation FrmAgr)
        {
            this.cr = Cr;
            this.data = cr.Data;
            this.ds = cr.Data.Base.Ds;
            cr.ImportData = new Classes.ImpData.ImportData(cr);
            impData = cr.ImportData;
            this.var = impData.Var;
            this.frmAgr = FrmAgr;
            //cr.ImportData.Var = new Classes.ImpData.ImportDataVariables(cr, cr.ImportData);
            //
            cr.Data.Base.TimeTableAdapter = new base_nalogDataSetTableAdapters.TimeTableAdapter();
            cr.Data.Base.DataWarehouseSubjectTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subjectTableAdapter();
            cr.Data.Base.DataWarehouseSubjectTaxTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subject_taxTableAdapter();
            cr.Data.Base.DataWarehouseTaxTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_taxTableAdapter();
            cr.Data.Base.DataWarehouseSubjectEeaTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subject_eeaTableAdapter();
            cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_subject_eea_gksTableAdapter();
            cr.Data.Base.DataWarehouseEeaTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_eeaTableAdapter();
            cr.Data.Base.DataWarehouseEeaGksTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_eea_gksTableAdapter();
            cr.Data.Base.DataWarehouseDistrictTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_districtTableAdapter();
            cr.Data.Base.DataWarehouseDistrictTaxTableAdapter = new base_nalogDataSetTableAdapters.Data_warehouse_district_taxTableAdapter();
            //
        }
        //
        private string[,] arrTypeAgregation = { 
                                              {"Агрегация данных по итоговым показателям субъектов","subject", "Data_warehouse_subject", "Subjects", "id_subject"},
                                              {"Агрегация данных по итоговым показателям субъектов и видам налогов", "subject_tax", "Data_warehouse_subject_tax", "Subjects", "id_subject"},
                                              {"Агрегация данных по итоговым показателям видов налогов", "tax", "Data_warehouse_tax", "Taxes", "id_tax"},
                                              {"Агрегация данных по итоговым показателям видов экономической деятельности", "eea", "Data_warehouse_eea", "Taxes_ved", "id_eea"},
                                              {"Агрегация данных по итоговым показателям субъектов и видов экономической деятельности", "subject_eea", "Data_warehouse_subject_eea", "Subjects", "id_subject"},
                                              {"Агрегация данных по итоговым показателям видов экономической деятельности (ГКС)", "eea_gks", "Data_warehouse_eea_gks", "Taxes_ved", "id_eea"},
                                              {"Агрегация данных по итоговым показателям видов субъектов и экономической деятельности (ГКС)", "subject_eea_gks", "Data_warehouse_subject_eea_gks","Subjects", "id_subject"},
                                              {"Агрегация данных по итоговым показателям Федеральные округа", "district", "Data_warehouse_district","Federal_district", "id_district"},
                                              {"Агрегация данных по итоговым показателям Федеральные округа и вадам налогов", "district_tax", "Data_warehouse_district_tax","Federal_district", "id_district"}};
        private int currentTypeAgregationIndex = 0;
        private string currentTypeAgregationName = "";
        private string[] fieldsAgregation;
        private string[,] commandsAgregation;
        private string[] arrRows;
        private ArrayList listParamsAgregation;
        private string tableAgregation = "";
        private bool isManyIndexes = false;
        private bool isMergeTable = false;
        //private int idSelectMethod = 0;
        //
        private bool isSubject = false;
        private bool isDistrict = false;
        private bool isTax = false;
        private bool isEea = false;
        private int yearBefore = 0;
        private int yearAfter = 0;
        //
        private SubjectAgregation sbj;
        private SubjectTaxAgregation sbjTax;
        private TaxAgregation tax;
        private EeaAgregation eea;
        private EeaGksAgregation eeaGks;
        private SubjectEeaAgregation sbjEea;
        private SubjectEeaGksAgregation sbjEeaGks;
        private FederalDistrictAgregation fd;
        private FederalDistrictTaxAgregation fdTax;
        private ParamAgregation prm;
        private ValuesAgregation vl;
        //
        private base_nalogDataSet.TimeRow timeRow;
        private DataRow rowAgr;
        private int currentId = 0;
        private DataTable dtSelect;
        //
        public string[,] ArrTypeAgregation { get { return arrTypeAgregation; } }
        public string[] FieldsAgregation { get { return fieldsAgregation; } }
        public Forms.FormDataAggregation FrmAgr { get { return frmAgr; } }
        //
        public bool IsTypeAgregation(string type)
        {
            bool isType = false;
            if (type.Length > 0)
            {
                for (int i = 0; i < arrTypeAgregation.Length / 5; i++)
                {
                    if (type == arrTypeAgregation[i, 0])
                    {
                        isType = true;
                        currentTypeAgregationIndex = i;
                        currentTypeAgregationName = arrTypeAgregation[i, 1];
                    }
                }
                switch (currentTypeAgregationName)
                {
                    #region currentTypeAgregationName
                    case "subject":
                        {
                            sbj = new SubjectAgregation(this);
                            listParamsAgregation = sbj.ListParamsAgregation;
                            commandsAgregation = sbj.CommandsAgregation;
                            tableAgregation = sbj.TableAgregation;
                            isSubject = sbj.IsSubject;
                            isDistrict = sbj.IsDistrict;
                            isTax = sbj.IsTax;
                            isEea = sbj.IsEea;
                            rowAgr = sbj.Row;
                            //idSelectMethod = checkSelectMethod(sbj.SelectMethod);
                            break;
                        }
                    case "subject_tax":
                        {
                            sbjTax = new SubjectTaxAgregation(this);
                            listParamsAgregation = sbjTax.ListParamsAgregation;
                            commandsAgregation = sbjTax.CommandsAgregation;
                            tableAgregation = sbjTax.TableAgregation;
                            isSubject = sbjTax.IsSubject;
                            isDistrict = sbjTax.IsDistrict;
                            isTax = sbjTax.IsTax;
                            isEea = sbjTax.IsEea;
                            rowAgr = sbjTax.Row;
                            //idSelectMethod = checkSelectMethod(sbjTax.SelectMethod);
                            break;
                        }
                    case "tax":
                        {
                            tax = new TaxAgregation(this);
                            listParamsAgregation = tax.ListParamsAgregation;
                            commandsAgregation = tax.CommandsAgregation;
                            tableAgregation = tax.TableAgregation;
                            isSubject = tax.IsSubject;
                            isDistrict = tax.IsDistrict;
                            isTax = tax.IsTax;
                            isEea = tax.IsEea;
                            rowAgr = tax.Row;
                            //idSelectMethod = checkSelectMethod(tax.SelectMethod);
                            break;
                        }
                    case "eea":
                        {
                            eea = new EeaAgregation(this);
                            listParamsAgregation = eea.ListParamsAgregation;
                            commandsAgregation = eea.CommandsAgregation;
                            tableAgregation = eea.TableAgregation;
                            isSubject = eea.IsSubject;
                            isDistrict = eea.IsDistrict;
                            isTax = eea.IsTax;
                            isEea = eea.IsEea;
                            
                            //idSelectMethod = checkSelectMethod(eea.SelectMethod);
                            break;
                        }
                    case "eea_gks":
                        {
                            eeaGks = new EeaGksAgregation(this);
                            listParamsAgregation = eeaGks.ListParamsAgregation;
                            commandsAgregation = eeaGks.CommandsAgregation;
                            tableAgregation = eeaGks.TableAgregation;
                            isSubject = eeaGks.IsSubject;
                            isDistrict = eeaGks.IsDistrict;
                            isTax = eeaGks.IsTax;
                            isEea = eeaGks.IsEea;
                            //idSelectMethod = checkSelectMethod(eeaGks.SelectMethod);
                            break;
                        }
                    case "subject_eea":
                        {
                            sbjEea = new SubjectEeaAgregation(this);
                            listParamsAgregation = sbjEea.ListParamsAgregation;
                            commandsAgregation = sbjEea.CommandsAgregation;
                            tableAgregation = sbjEea.TableAgregation;
                            isSubject = sbjEea.IsSubject;
                            isDistrict = sbjEea.IsDistrict;
                            isTax = sbjEea.IsTax;
                            isEea = sbjEea.IsEea;
                            rowAgr = sbjEea.Row;
                            //idSelectMethod = checkSelectMethod(sbjEea.SelectMethod);
                            break;
                        }
                    case "subject_eea_gks":
                        {
                            sbjEeaGks = new SubjectEeaGksAgregation(this);
                            listParamsAgregation = sbjEeaGks.ListParamsAgregation;
                            commandsAgregation = sbjEeaGks.CommandsAgregation;
                            tableAgregation = sbjEeaGks.TableAgregation;
                            isSubject = sbjEeaGks.IsSubject;
                            isDistrict = sbjEeaGks.IsDistrict;
                            isTax = sbjEeaGks.IsTax;
                            isEea = sbjEeaGks.IsEea;
                            rowAgr = sbjEeaGks.Row;
                            //idSelectMethod = checkSelectMethod(sbjEeaGks.SelectMethod);
                            break;
                        }
                    case "district":
                        {
                            fdTax = new FederalDistrictTaxAgregation(this);
                            listParamsAgregation = fd.ListParamsAgregation;
                            commandsAgregation = fd.CommandsAgregation;
                            tableAgregation = fd.TableAgregation;
                            isSubject = fd.IsSubject;
                            isDistrict = fd.IsDistrict;
                            isTax = fd.IsTax;
                            isEea = fd.IsEea;
                            rowAgr = fd.Row;
                            //idSelectMethod = checkSelectMethod(sbjEeaGks.SelectMethod);
                            break;
                        }
                    case "district_tax":
                        {
                            fdTax = new FederalDistrictTaxAgregation(this);
                            listParamsAgregation = fdTax.ListParamsAgregation;
                            commandsAgregation = fdTax.CommandsAgregation;
                            tableAgregation = fdTax.TableAgregation;
                            isSubject = fdTax.IsSubject;
                            isDistrict = fdTax.IsDistrict;
                            isTax = fdTax.IsTax;
                            isEea = fdTax.IsEea;
                            rowAgr = fdTax.Row;
                            //idSelectMethod = checkSelectMethod(sbjEeaGks.SelectMethod);
                            break;
                        }
                    #endregion currentTypeAgregationName
                }
                fieldsAgregation = returnFieldsAgregation(commandsAgregation);
            }
            return isType;
        }
        private string [] returnFieldsAgregation(string[,] commands)
        {
            string[] arr;
            List<string> listCommands = new List<string>();
            for (int i = 0; i < commands.Length / 5; i++)
            {
                listCommands.Add(commands[i, 3]);
            }
            arr = new string[listCommands.Count];
            for (int i = 0; i < listCommands.Count; i++)
            {
                arr[i] = listCommands[i];
            }
            return arr;
        }
        public void startAgregation(string type = "")
        {
            #region Агрегация данных по итоговым показателям видов налогов
            //
            cr.Data.Base.TimeTableAdapter.Fill(ds.Time);

            //

            //
            //
            //total_ti_tax_subject - View_total_ti_subjects
            //
            switch (currentTypeAgregationName)
            {
                case "subject":
                    {
                        listParamsAgregation = sbj.ListParamsAgregation;
                        break;
                    }
                case "subject_tax":
                    {
                        listParamsAgregation = sbjTax.ListParamsAgregation;
                        break;
                    }
                case "tax":
                    {
                        listParamsAgregation = tax.ListParamsAgregation;
                        break;
                    }
                case "eea":
                    {
                        listParamsAgregation = eea.ListParamsAgregation;
                        break;
                    }
                case "eea_gks":
                    {
                        listParamsAgregation = eeaGks.ListParamsAgregation;
                        break;
                    }
                case "subject_eea":
                    {
                        listParamsAgregation = sbjEea.ListParamsAgregation;
                        break;
                    }
                case "subject_eea_gks":
                    {
                        listParamsAgregation = sbjEeaGks.ListParamsAgregation;
                        break;
                    }
                case "district":
                    {
                        listParamsAgregation = fd.ListParamsAgregation;
                        break;
                    }
                case "district_tax":
                    {
                        listParamsAgregation = fdTax.ListParamsAgregation;
                        break;
                    }
            }
            string nameSelectWhere = "";
            string idCol = "id";
            cr.Data.Base.ReferenceTable = new DataTable();
            switch (arrTypeAgregation[currentTypeAgregationIndex, 4])
            {
                case "id_subject":
                    {
                        nameSelectWhere = "subject_name";
                        cr.Data.Base.SubjectsTableAdapter.Fill(ds.Subjects);
                        break;
                    }
                case "id_district":
                    {

                        nameSelectWhere = "district_name";
                        cr.Data.Base.FederalDistrictsTableAdapter.Fill(ds.Federal_district);
                        break;
                    }
                case "id_tax":
                    {
                        nameSelectWhere = "id_tax";
                        cr.Data.Base.TaxesTableAdapter.Fill(ds.Taxes);

                        break;
                    }
                case "id_eea":
                    {
                        nameSelectWhere = "id_eea";
                        cr.Data.Base.TaxesVedTableAdapter.Fill(ds.Taxes_ved);
                        break;

                    }
            }

            cr.Data.Base.ReferenceTable = ds.Tables[arrTypeAgregation[currentTypeAgregationIndex, 3]];
            if (listParamsAgregation.Count > 1) isManyIndexes = true;
            if (frmAgr.checkBoxMergeTable.Checked) isMergeTable = true;
            if (frmAgr.checkBoxFilterYears.Checked)
            {
                yearBefore = impData.returnNullInt(frmAgr.textBoxYearBefore.Text);
                yearAfter = impData.returnNullInt(frmAgr.textBoxYearAfter.Text);
                int countYears = Math.Abs(yearAfter - yearBefore);
                var.YearsList.Add(yearAfter);
                if (countYears > 0)
                {
                    for (int i = 0; i < countYears; i++)
                    {
                        var.YearsList.Add(yearAfter + i + 1);
                    }
                }
                else
                {
                    var.YearsList.Add(yearAfter);
                }
            }
            if (frmAgr.checkBoxFilterSubject.Checked)
            {
                var.IdSubjNow = impData.returnNullInt(frmAgr.comboBoxSubjects.SelectedValue);
            }
            #region Выбор ключевого поля
            string strKey = "";
            int idKey = 0;
            if (isSubject) { strKey = "id_subject"; }
            if (isDistrict) { strKey = "id_district"; }
            //if (isTax) { strKey = "id_tax"; }
            //if (isEea) { strKey = "id_eea"; }
            #endregion Выбор ключевого поля
            if (!isMergeTable)
            {
                string selectWhere = "";
                if (frmAgr.checkBoxFilterSubject.Checked)
                {
                    selectWhere = "id_subject=" + var.IdSubjNow;
                }
                string strYears = "";
                if (var.YearsList.Count > 0)
                {
                    strYears = "(year>=" + yearAfter + " AND year<=" + yearBefore + ")";
                }
                if (frmAgr.checkBoxFilterSubject.Checked)
                {
                    selectWhere = "(id_subject=" + var.IdSubjNow + ")";
                }
                if (frmAgr.checkBoxFilterYears.Checked && !frmAgr.checkBoxFilterSubject.Checked)
                {
                    selectWhere = strYears;
                }
                if (frmAgr.checkBoxFilterYears.Checked && frmAgr.checkBoxFilterSubject.Checked)
                {
                    selectWhere = "(id_subject=" + var.IdSubjNow + ") AND " + strYears;
                }
                #region если не объединять таблицы показателей
                for (int j = 0; j < listParamsAgregation.Count; j++)
                {
                    prm = (ParamAgregation)listParamsAgregation[j];
                    cr.ImportData.Var.InternalTable = new DataTable();
                    
                    if (selectWhere.Length > 0)
                    {
                        prm.SqlSelect = prm.SqlSelect + " WHERE " + selectWhere;
                    }
                    string select = prm.SqlSelect;
                    cr.ImportData.Var.InternalTable = cr.ImportData.ReturnSourceTable(select, prm.TableName);
                    processingInternalTable(prm, j);
                    cr.ImportData.Var.InternalTable.Clear();
                }
                #endregion если не объединять таблицы показателей
            }
            else
            {
                #region  если объединять таблицы показателей
                MergeTablesAgregation mTbl = new MergeTablesAgregation(this);
                string tableName = "CustomMergeTable";
                var.StatusApp = "Начало подготовки сводной таблицы";

                for (int i = 0; i < cr.Data.Base.ReferenceTable.Rows.Count; i++)
                {
                    frmAgr.toolStripStatusLabelStep.Text = i + 1 + " / " + cr.Data.Base.ReferenceTable.Rows.Count;
                    frmAgr.Refresh();
                    Application.DoEvents();
                    cr.Data.Base.CustomDs = new DataSet();
                    for (int j = 0; j < listParamsAgregation.Count; j++)
                    {
                        prm = (ParamAgregation)listParamsAgregation[j];
                        prm.IsMergeTable = true;
                        prm.NameMergeTable = tableName;
                        string select = prm.SqlSelect + " WHERE " + arrTypeAgregation[currentTypeAgregationIndex, 4] + " = " + cr.Data.Base.ReferenceTable.Rows[i][idCol].ToString();
                        cr.ImportData.Var.InternalTable = new DataTable();
                        cr.ImportData.Var.InternalTable = cr.ImportData.ReturnSourceTable(select, prm.TableName);
                        cr.ImportData.Var.InternalTable.TableName = cr.ImportData.Var.InternalTable.TableName + j;
                        cr.Data.Base.CustomDs.Tables.Add(cr.ImportData.Var.InternalTable);
                    }
                    if (cr.Data.Base.CustomDs.Tables.Count > 0)
                    {
                        var.StatusApp = "Формирование сводной таблицы";
                        cr.Data.Base.CustomMergeTable = cr.Data.Base.CustomDs.Tables[0];
                        cr.Data.Base.CustomMergeTable.TableName = tableName;
                        for (int k = 1; k < cr.Data.Base.CustomDs.Tables.Count; k++)
                        {
                            cr.Data.Base.CustomMergeTable.Merge(cr.Data.Base.CustomDs.Tables[k], false, MissingSchemaAction.Add);
                        }
                        for (int k = 1; k < cr.Data.Base.CustomDs.Tables.Count; k++)
                        {
                            cr.Data.Base.CustomDs.Tables.Remove(cr.Data.Base.CustomDs.Tables[k]);
                        }
                    }
                    cr.Data.Base.CustomMergeTable = mTbl.MergeRowsDataTable(cr.Data.Base.CustomMergeTable);
                    cr.ImportData.Var.InternalTable = cr.Data.Base.CustomMergeTable;
                    processingInternalTable(prm, 0, i + 1, cr.Data.Base.ReferenceTable.Rows.Count, isMergeTable, "");
                }
                #endregion  если объединять таблицы показателей
            }
            //********************************************
            #endregion Агрегация данных по итоговым показателям видов налогов
            var.StatusApp = " Готово ";

        }
        private bool checkColumn(DataColumn dc)
        {
            bool ok = false;
            for (int i = 0; i < listParamsAgregation.Count; i++)
            {
                ParamAgregation p = (ParamAgregation)listParamsAgregation[i];
                if (p.FieldSourceTable == dc.ColumnName.ToString()) ok = true;
            }
            return ok;
        }
        public string[,] returnCommandsAgregation(string tableName)
        {
            string pathDirectoryApp = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pathAgregationConfig = pathDirectoryApp + "\\Configs\\Agregation.config";
            DataSet dsXml = new DataSet();
            dsXml.ReadXml(pathAgregationConfig);
            DataTable dt = dsXml.Tables[tableName];
            if (dt.Rows.Count > 0)
            {
                arrRows = dt.Rows[0].ItemArray[0].ToString().Split(';');
                int countCol = arrRows[0].Split(',').Length;
                commandsAgregation = new string[arrRows.Length, countCol];
                for (int i = 0; i < arrRows.Length; i++)
                {
                    string[] arrCols = arrRows[i].Split(',');
                    for (int j = 0; j < arrCols.Length; j++)
                    {
                        commandsAgregation[i, j] = arrCols[j];
                    }
                }
            }

            return commandsAgregation;
        }
        private void processingInternalTable(ParamAgregation prm, int stepIndex = 0, int stepSelectIndex = 0, int countStepsSelectIndex = 0, bool isMergeTable = false, string subject_name="")
        {
            int count = 0;
            int checkedAgregationData = 0;
            if (countStepsSelectIndex > 0 && !isMergeTable)
            {
                frmAgr.toolStripStatusLabelStep.Text = stepIndex + " / " + listParamsAgregation.Count +
                    " и " + stepSelectIndex + " / " + countStepsSelectIndex;
                frmAgr.toolStripStatusLabelAction.Text = "Сканируем - " + prm.TableName + ": " + prm.FieldDestinationTable;
            }
            else if (!isMergeTable)
            {
                frmAgr.toolStripStatusLabelStep.Text = stepIndex + " / " + listParamsAgregation.Count;
                frmAgr.toolStripStatusLabelAction.Text = "Сканируем - " + prm.TableName + ": " + prm.FieldDestinationTable;
            }
            else if (isMergeTable)
            {
                //frmAgr.toolStripStatusLabelStep.Text = 0 + " / " + cr.Data.Base.CustomMergeTable.Rows.Count;
                //frmAgr.toolStripStatusLabelAction.Text = "Сканируем объединенную таблицу для " + subject_name;
            }
            else if (isMergeTable && countStepsSelectIndex>0)
            {
                //frmAgr.toolStripStatusLabelStep.Text = 0 + " / " + " / " + cr.Data.Base.CustomMergeTable.Rows.Count +
                //    " и " + stepSelectIndex + " / " + countStepsSelectIndex + " - " + subject_name;
            }
            frmAgr.Refresh();
            Application.DoEvents();
            //
            #region заполнение таблицы агригации уже имеющейся информацией
            switch (currentTypeAgregationName)
            {
                case "subject":
                    {
                        cr.Data.Base.DataWarehouseSubjectTableAdapter.Fill(ds.Data_warehouse_subject);
                        break;
                    }
                case "subject_tax":
                    {
                        cr.Data.Base.DataWarehouseSubjectTaxTableAdapter.Fill(ds.Data_warehouse_subject_tax);
                        break;
                    }
                case "tax":
                    {
                        cr.Data.Base.DataWarehouseTaxTableAdapter.Fill(ds.Data_warehouse_tax);
                        break;
                    }
                case "eea":
                    {
                        cr.Data.Base.DataWarehouseEeaTableAdapter.Fill(ds.Data_warehouse_eea);
                        break;
                    }
                case "eea_gks":
                    {
                        cr.Data.Base.DataWarehouseEeaGksTableAdapter.Fill(ds.Data_warehouse_eea_gks);
                        break;
                    }
                case "subject_eea":
                    {
                        cr.Data.Base.DataWarehouseSubjectEeaTableAdapter.Fill(ds.Data_warehouse_subject_eea);
                        break;
                    }
                case "subject_eea_gks":
                    {
                        cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter.Fill(ds.Data_warehouse_subject_eea_gks);
                        break;
                    }
                case "district":
                    {
                        cr.Data.Base.DataWarehouseDistrictTableAdapter.Fill(ds.Data_warehouse_district);
                        break;
                    }
                case "district_tax":
                    {
                        cr.Data.Base.DataWarehouseDistrictTaxTableAdapter.Fill(ds.Data_warehouse_district_tax);
                        break;
                    }
            }
            #endregion заполнение таблицы агригации уже имеющейся информацией
            //
            cr.ImportData.Var.AgregationTable = new DataTable();
            #region применяем фильтр в соответствии с настройками
            if (frmAgr.checkBoxFilterYears.Checked)
            {
                // years

                /*string strYears = "year=" + var.YearsList[0].ToString();
                if (var.YearsList.Count > 1)
                {
                    for (int i = 1; i < var.YearsList.Count; i++)
                    {
                        strYears += " AND year=" + var.YearsList[i].ToString();
                    }
                }
                string filter = strYears;
                if (frmAgr.checkBoxFilterSubject.Checked && frmAgr.checkBoxFilterYears.Checked)
                {
                    filter += " AND id_subject=" + var.IdSubjNow;
                }
                if (frmAgr.checkBoxFilterSubject.Checked && !frmAgr.checkBoxFilterYears.Checked)
                {
                    filter += "id_subject=" + var.IdSubjNow;
                }
                //
                dtSelect = new DataTable(cr.ImportData.Var.InternalTable.TableName, cr.ImportData.Var.InternalTable.Namespace);
                foreach (DataColumn dc in cr.ImportData.Var.InternalTable.Columns)
                {
                    dtSelect.Columns.Add(dc.ColumnName, dc.DataType);
                }
                if (dtSelect.Columns.Count > 0)
                {
                    DataRow[] rSelect = cr.ImportData.Var.InternalTable.Select(filter);
                    foreach (DataRow r in rSelect)
                    {
                        dtSelect.ImportRow(r);
                    }
                }
                cr.ImportData.Var.InternalTable.Clear();
                cr.ImportData.Var.InternalTable = dtSelect;
                //cr.ImportData.Var.InternalTable
                //cr.ImportData.Var.InternalTable.Clear();
                //cr.ImportData.Var.InternalTable.Rows.Add(InternalRows);*/

            }
            frmAgr.toolStripProgressBarAgregation.Maximum = cr.ImportData.Var.InternalTable.Rows.Count + 1;
            #endregion применяем фильтр в соответствии с настройками
            bool error = false;
            for (int i = 0; i < cr.ImportData.Var.InternalTable.Rows.Count; i++)
            {
                var.StatusApp = " Проверяем ";
                int idKey = 0;
                string strKey = "";
                int year = 0;
                decimal value = 0.0m;
                int id_time = 0;
                string sqlExt1 = "";
                int sqlExt2 = 0;
                #region выбор столбцов
                switch (currentTypeAgregationName)
                {
                    case "subject_tax":
                        {
                            sqlExt1 = "id_tax";
                            break;
                        }
                    case "tax":
                        {
                            sqlExt1 = "id_tax";
                            break;
                        }
                    case "eea":
                        {
                            sqlExt1 = "id_eea";
                            break;
                        }
                    case "eea_gks":
                        {
                            sqlExt1 = "id_eea";
                            break;
                        }
                    case "subject_eea":
                        {
                            sqlExt1 = "id_eea";
                            break;
                        }
                    case "subject_eea_gks":
                        {
                            sqlExt1 = "id_eea";
                            break;
                        }
                    case "district_tax":
                        {
                            sqlExt1 = "id_tax";
                            break;
                        }
                }
                #endregion выбор столбцов
                #region Выбор ключевого поля
                if (isSubject) { strKey = "id_subject";  }
                if (isDistrict) { strKey = "id_district"; }
                //if (isTax) { strKey = "id_tax"; }
                //if (isEea) { strKey = "id_eea"; }
                idKey = cr.ImportData.returnNullInt(cr.ImportData.Var.InternalTable.Rows[i][strKey]);
                #endregion Выбор ключевого поля
                if (isTax || isEea) sqlExt2 = cr.ImportData.returnNullInt(cr.ImportData.Var.InternalTable.Rows[i][sqlExt1]);
                year = cr.ImportData.returnNullInt(cr.ImportData.Var.InternalTable.Rows[i]["year"]);
                if(isMergeTable)
                {
                    vl = new ValuesAgregation();
                    for (int j = 0; j < listParamsAgregation.Count; j++)
                    {
                        prm = (ParamAgregation)listParamsAgregation[j];
                        vl.ColValues.Add(prm.FieldSourceTable);
                        vl.ColDestValues.Add(prm.FieldDestinationTable);
                        vl.Values.Add(cr.ImportData.returnNullDecimal(cr.ImportData.Var.InternalTable.Rows[i][prm.FieldSourceTable]));
                    }
                }
                else
                {
                    value = cr.ImportData.returnNullDecimal(cr.ImportData.Var.InternalTable.Rows[i][prm.FieldSourceTable], prm.Round);
                }
                id_time = 0;
                if (idKey > 0 || year > 0)
                {
                    #region запрос на выборку из таблицы агригации
                    cr.ImportData.Var.AgregationTable.Clear();

                    if (sqlExt1.Length > 0 && (isTax || isEea))
                    {
                        cr.ImportData.Var.AgregationTable = cr.ImportData.ReturnSourceTable("SELECT " + tableAgregation + ".*, Time.* FROM " + tableAgregation + " INNER JOIN Time ON dbo." + tableAgregation + ".id_time = dbo.Time.id WHERE (dbo." + tableAgregation + "."+strKey+" = " + idKey + ") AND (dbo.Time.calendar_year = " + year + ") AND (dbo." + tableAgregation + "." + sqlExt1 + " = " + sqlExt2 + ")", tableAgregation);
                    }
                    else if (isSubject || isDistrict)
                    {
                        cr.ImportData.Var.AgregationTable = cr.ImportData.ReturnSourceTable("SELECT " + tableAgregation + ".*, Time.* FROM " + tableAgregation + " INNER JOIN Time ON dbo." + tableAgregation + ".id_time = dbo.Time.id WHERE (dbo." + tableAgregation + "." + strKey + " = " + idKey + ") AND (dbo.Time.calendar_year = " + year + ")", tableAgregation);
                    }
                    else if ((sqlExt1.Length > 0 && !isSubject && !isDistrict) && (isTax || isEea))
                    {
                        cr.ImportData.Var.AgregationTable = cr.ImportData.ReturnSourceTable("SELECT " + tableAgregation + ".*, Time.* FROM " + tableAgregation + " INNER JOIN Time ON dbo." + tableAgregation + ".id_time = dbo.Time.id WHERE (dbo." + tableAgregation + "." + sqlExt1 + " = " + sqlExt2 + ") AND (dbo.Time.calendar_year = " + year + ")", tableAgregation);
                    }
                    else
                    {
                       
                    }
                    #endregion запрос на выборку из таблицы агригации
                    if (cr.ImportData.Var.AgregationTable.Rows.Count > 0)
                    {
                        #region изменить запись
                        var.StatusApp = " Проверяем существующие ";
                        checkedAgregationData = 1;
                        int id = cr.ImportData.returnNullInt(cr.ImportData.Var.AgregationTable.Rows[0]["id"]);
                        if (isEea || isTax)
                        {
                            rowAgr = ds.Tables[arrTypeAgregation[currentTypeAgregationIndex, 2]].Rows.Find(id);
                            rowAgr[sqlExt1] = sqlExt2;
                            rowAgr[prm.FieldDestinationTable] = value;
                        }
                        else
                        {
                            rowAgr = ds.Tables[arrTypeAgregation[currentTypeAgregationIndex, 2]].Rows.Find(id);
                            rowAgr[prm.FieldDestinationTable] = value;
                        }
                        
                        #endregion изменить запись
                    }
                    else
                    {
                        #region добавить запись
                        var.StatusApp = " Доавляем новые ";
                        checkedAgregationData = 0;
                        //
                        if ((isEea || isTax) && !(!isSubject || !isDistrict))
                        {
                            rowAgr = ds.Tables[arrTypeAgregation[currentTypeAgregationIndex, 2]].NewRow();
                            rowAgr[sqlExt1] = sqlExt2;
                        }
                        else if ((isEea || isTax) && (isSubject || isDistrict))
                        {
                            rowAgr = ds.Tables[arrTypeAgregation[currentTypeAgregationIndex, 2]].NewRow();
                            rowAgr[sqlExt1] = sqlExt2;
                            rowAgr[strKey] = idKey;
                        }
                        else if (isSubject || isDistrict)
                        {
                            rowAgr = ds.Tables[arrTypeAgregation[currentTypeAgregationIndex, 2]].NewRow();
                            rowAgr[strKey] = idKey;
                        }
                        else
                        {
                        }
                        #endregion добавить запись
                        #region поиск и добавление записи в ьтаблицу Time
                        //
                        DataRow[] dRowLev1;
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
                        #endregion поиск и добавление записи в ьтаблицу Time
                        #region добавить информацию в запись
                        if (!isMergeTable)
                        {
                            rowAgr["id_time"] = id_time;
                            rowAgr[prm.FieldDestinationTable] = value;
                            ds.Tables[arrTypeAgregation[currentTypeAgregationIndex, 2]].Rows.Add(rowAgr);
                        }
                        else
                        {
                            rowAgr["id_time"] = id_time;
                            rowAgr[prm.FieldDestinationTable] = value;
                            for (int k = 0; k < vl.ColDestValues.Count; k++)
                            {
                                rowAgr[vl.ColDestValues[k]] = vl.Values[k];
                            }
                            ds.Tables[arrTypeAgregation[currentTypeAgregationIndex, 2]].Rows.Add(rowAgr);
                        }
                        #endregion добавить информацию в запись
                    }
                }
                frmAgr.toolStripProgressBarAgregation.Value = i + 1;
            }
            var.StatusApp = " Добавляем в БД ";
            doTableAdapter(currentTypeAgregationName);
            count++;
        }
        private bool checkAgragateData()
        {
            bool agregate = false;

            return agregate;
        }
        private void doTableAdapter(string method)
        {
            cr.Data.Base.CustomTable = new DataTable();
            DataTable deleteRows = (DataTable)cr.Data.Base.CustomTable.GetChanges(DataRowState.Deleted);
            DataTable newRows = (DataTable)cr.Data.Base.CustomTable.GetChanges(DataRowState.Added);
            DataTable modifiedRows = (DataTable)cr.Data.Base.CustomTable.GetChanges(DataRowState.Modified);
            #region method
            switch (method)
            {
                case "Time":
                    {
                        /*base_nalogDataSet.TimeDataTable */
                        deleteRows = (base_nalogDataSet.TimeDataTable)ds.Time.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.TimeDataTable */
                        newRows = (base_nalogDataSet.TimeDataTable)ds.Time.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.TimeDataTable */
                        modifiedRows = (base_nalogDataSet.TimeDataTable)ds.Time.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "subject":
                    {
                        /*base_nalogDataSet.Data_warehouse_subjectDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subjectDataTable)ds.Data_warehouse_subject.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_subjectDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subjectDataTable)ds.Data_warehouse_subject.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_subjectDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subjectDataTable)ds.Data_warehouse_subject.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "subject_tax":
                    {
                        /*base_nalogDataSet.Data_warehouse_subject_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subject_taxDataTable)ds.Data_warehouse_subject_tax.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_subject_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subject_taxDataTable)ds.Data_warehouse_subject_tax.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_subject_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subject_taxDataTable)ds.Data_warehouse_subject_tax.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "tax":
                    {
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_taxDataTable)ds.Data_warehouse_tax.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_taxDataTable)ds.Data_warehouse_tax.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_taxDataTable)ds.Data_warehouse_tax.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "subject_eea":
                    {
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subject_eeaDataTable)ds.Data_warehouse_subject_eea.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subject_eeaDataTable)ds.Data_warehouse_subject_eea.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subject_eeaDataTable)ds.Data_warehouse_subject_eea.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "subject_eea_gks":
                    {
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)ds.Data_warehouse_subject_eea_gks.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)ds.Data_warehouse_subject_eea_gks.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)ds.Data_warehouse_subject_eea_gks.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "eea":
                    {
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        deleteRows = (base_nalogDataSet.Data_warehouse_eeaDataTable)ds.Data_warehouse_eea.GetChanges(DataRowState.Deleted);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        newRows = (base_nalogDataSet.Data_warehouse_eeaDataTable)ds.Data_warehouse_eea.GetChanges(DataRowState.Added);
                        /*base_nalogDataSet.Data_warehouse_taxDataTable */
                        modifiedRows = (base_nalogDataSet.Data_warehouse_eeaDataTable)ds.Data_warehouse_eea.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "eea_gks":
                    {
                        deleteRows = (base_nalogDataSet.Data_warehouse_eea_gksDataTable)ds.Data_warehouse_eea_gks.GetChanges(DataRowState.Deleted);
                        newRows = (base_nalogDataSet.Data_warehouse_eea_gksDataTable)ds.Data_warehouse_eea_gks.GetChanges(DataRowState.Added);
                        modifiedRows = (base_nalogDataSet.Data_warehouse_eea_gksDataTable)ds.Data_warehouse_eea_gks.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "district":
                    {
                        deleteRows = (base_nalogDataSet.Data_warehouse_districtDataTable)ds.Data_warehouse_district.GetChanges(DataRowState.Deleted);
                        newRows = (base_nalogDataSet.Data_warehouse_districtDataTable)ds.Data_warehouse_district.GetChanges(DataRowState.Added);
                        modifiedRows = (base_nalogDataSet.Data_warehouse_districtDataTable)ds.Data_warehouse_district.GetChanges(DataRowState.Modified);
                        break;
                    }
                case "district_tax":
                    {
                        deleteRows = (base_nalogDataSet.Data_warehouse_district_taxDataTable)ds.Data_warehouse_district_tax.GetChanges(DataRowState.Deleted);
                        newRows = (base_nalogDataSet.Data_warehouse_district_taxDataTable)ds.Data_warehouse_district_tax.GetChanges(DataRowState.Added);
                        modifiedRows = (base_nalogDataSet.Data_warehouse_district_taxDataTable)ds.Data_warehouse_district_tax.GetChanges(DataRowState.Modified);
                        break;
                    }
            }
            #endregion method
            //
            try
            {
                #region deleteRows
                if (deleteRows != null)
                {
                    switch (method)
                    {
                        case "Time":
                            {
                                cr.Data.Base.TimeTableAdapter.Update((base_nalogDataSet.TimeDataTable)deleteRows);
                                break;
                            }
                        case "subject":
                            {
                                cr.Data.Base.DataWarehouseSubjectTableAdapter.Update((base_nalogDataSet.Data_warehouse_subjectDataTable)deleteRows);
                                break;
                            }
                        case "subject_tax":
                            {
                                cr.Data.Base.DataWarehouseSubjectTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_taxDataTable)deleteRows);
                                break;
                            }
                        case "tax":
                            {
                                cr.Data.Base.DataWarehouseTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_taxDataTable)deleteRows);
                                break;
                            }
                        case "subject_eea":
                            {
                                cr.Data.Base.DataWarehouseSubjectEeaTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_eeaDataTable)deleteRows);
                                break;
                            }
                        case "subject_eea_gks":
                            {
                                cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)deleteRows);
                                break;
                            }
                        case "eea":
                            {
                                cr.Data.Base.DataWarehouseEeaTableAdapter.Update((base_nalogDataSet.Data_warehouse_eeaDataTable)deleteRows);
                                break;
                            }
                        case "eea_gks":
                            {
                                cr.Data.Base.DataWarehouseEeaGksTableAdapter.Update((base_nalogDataSet.Data_warehouse_eea_gksDataTable)deleteRows);
                                break;
                            }
                        case "district":
                            {
                                cr.Data.Base.DataWarehouseDistrictTableAdapter.Update((base_nalogDataSet.Data_warehouse_districtDataTable)deleteRows);
                                break;
                            }
                        case "district_tax":
                            {
                                cr.Data.Base.DataWarehouseDistrictTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_district_taxDataTable)deleteRows);
                                break;
                            }

                    }
                }
                #endregion deleteRows
                #region newRows
                if (newRows != null)
                {
                    switch (method)
                    {
                        case "Time":
                            {
                                cr.Data.Base.TimeTableAdapter.Update((base_nalogDataSet.TimeDataTable)newRows);
                                break;
                            }
                        case "subject":
                            {
                                cr.Data.Base.DataWarehouseSubjectTableAdapter.Update((base_nalogDataSet.Data_warehouse_subjectDataTable)newRows);
                                break;
                            }
                        case "subject_tax":
                            {
                                cr.Data.Base.DataWarehouseSubjectTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_taxDataTable)newRows);
                                break;
                            }
                        case "tax":
                            {
                                cr.Data.Base.DataWarehouseTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_taxDataTable)newRows);
                                break;
                            }
                        case "subject_eea":
                            {
                                cr.Data.Base.DataWarehouseSubjectEeaTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_eeaDataTable)newRows);
                                break;
                            }
                        case "subject_eea_gks":
                            {
                                cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)newRows);
                                break;
                            }
                        case "eea":
                            {
                                cr.Data.Base.DataWarehouseEeaTableAdapter.Update((base_nalogDataSet.Data_warehouse_eeaDataTable)newRows);
                                break;
                            }
                        case "eea_gks":
                            {
                                cr.Data.Base.DataWarehouseEeaGksTableAdapter.Update((base_nalogDataSet.Data_warehouse_eea_gksDataTable)newRows);
                                break;
                            }
                        case "district":
                            {
                                cr.Data.Base.DataWarehouseDistrictTableAdapter.Update((base_nalogDataSet.Data_warehouse_districtDataTable)newRows);
                                break;
                            }
                        case "district_tax":
                            {
                                cr.Data.Base.DataWarehouseDistrictTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_district_taxDataTable)newRows);
                                break;
                            }
                    }
                }
                #endregion newRows
                #region modifiedRows
                if (modifiedRows != null)
                {
                    switch (method)
                    {
                        case "Time":
                            {
                                cr.Data.Base.TimeTableAdapter.Update((base_nalogDataSet.TimeDataTable)deleteRows);
                                break;
                            }
                        case "subject":
                            {
                                cr.Data.Base.DataWarehouseSubjectTableAdapter.Update((base_nalogDataSet.Data_warehouse_subjectDataTable)modifiedRows);
                                break;
                            }
                        case "subject_tax":
                            {
                                cr.Data.Base.DataWarehouseSubjectTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_taxDataTable)modifiedRows);
                                break;
                            }
                        case "tax":
                            {
                                cr.Data.Base.DataWarehouseTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_taxDataTable)modifiedRows);
                                break;
                            }
                        case "subject_eea":
                            {
                                cr.Data.Base.DataWarehouseSubjectEeaTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_eeaDataTable)modifiedRows);
                                break;
                            }
                        case "subject_eea_gks":
                            {
                                cr.Data.Base.DataWarehouseSubjectEeaGksTableAdapter.Update((base_nalogDataSet.Data_warehouse_subject_eea_gksDataTable)modifiedRows);
                                break;
                            }
                        case "eea":
                            {
                                cr.Data.Base.DataWarehouseEeaTableAdapter.Update((base_nalogDataSet.Data_warehouse_eeaDataTable)modifiedRows);
                                break;
                            }
                        case "eea_gks":
                            {
                                cr.Data.Base.DataWarehouseEeaGksTableAdapter.Update((base_nalogDataSet.Data_warehouse_eea_gksDataTable)modifiedRows);
                                break;
                            }
                        case "district":
                            {
                                cr.Data.Base.DataWarehouseDistrictTableAdapter.Update((base_nalogDataSet.Data_warehouse_districtDataTable)modifiedRows);
                                break;
                            }
                        case "district_tax":
                            {
                                cr.Data.Base.DataWarehouseDistrictTaxTableAdapter.Update((base_nalogDataSet.Data_warehouse_district_taxDataTable)modifiedRows);
                                break;
                            }
                    }
                }
                #endregion modifiedRows
            }
            
            catch (System.Exception ex)
            {
                #region error
                string er = ex.Message.ToString();
            #endregion error
            }
            
            
            finally
            {
                #region finally
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
                #endregion finally
            }
        }
        public class SubjectAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_subject";
            private string tableSample = "subject";
            private base_nalogDataSet.Data_warehouse_subjectRow row; //subject
            //
            private bool isSubject = true;
            private bool isDistrict = false;
            private bool isTax = false;
            private bool isEea = false;
            private string selectMethod = "all";
            private string[,] commandsAgregation;
            //
            public SubjectAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public SubjectAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea {get{return isEea;}}
            public string SelectMethod { get { return selectMethod; } }
            public base_nalogDataSet.Data_warehouse_subjectRow Row { get { return row; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class SubjectTaxAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_subject_tax";
            private string tableSample = "subject_tax";
            private base_nalogDataSet.Data_warehouse_subject_taxRow row; //subject_tax
            //
            private bool isSubject = true;
            private bool isDistrict = false;
            private bool isTax = true;
            private bool isEea = false;
            private string selectMethod = "one_subject";
            private string[,] commandsAgregation;

            //
            public SubjectTaxAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public SubjectTaxAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            //
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea { get { return isEea; } }
            public string SelectMethod { get { return selectMethod; } }
            public base_nalogDataSet.Data_warehouse_subject_taxRow Row { get { return row; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class TaxAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_tax";
            private string tableSample = "tax";
            private base_nalogDataSet.Data_warehouse_taxRow row; //tax
            //
            private bool isSubject = false;
            private bool isDistrict = false;
            private bool isTax = true;
            private bool isEea = false;
            private string selectMethod = "all";
            private string[,] commandsAgregation;
            public TaxAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public TaxAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            //
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea { get { return isEea; } }
            public string SelectMethod { get { return selectMethod; } }
            public base_nalogDataSet.Data_warehouse_taxRow Row { get { return row; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class EeaAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_eea";
            private string tableSample = "eea";
            //
            private bool isSubject = false;
            private bool isDistrict = false;
            private bool isTax = false;
            private bool isEea = true;
            private string selectMethod = "all";

            private string[,] commandsAgregation;
            public EeaAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public EeaAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            //
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea { get { return isEea; } }
            public string SelectMethod { get { return selectMethod; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class SubjectEeaAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_subject_eea";
            private string tableSample = "subject_eea";
            private base_nalogDataSet.Data_warehouse_subject_eeaRow row; //subject_eea_gks
            //
            private bool isSubject = true;
            private bool isDistrict = false;
            private bool isTax = false;
            private bool isEea = true;
            private string selectMethod = "one_subject";

            //
            private string[,] commandsAgregation;
            //
            public SubjectEeaAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public SubjectEeaAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            //
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea { get { return isEea; } }
            public string SelectMethod { get { return selectMethod; } }
            public base_nalogDataSet.Data_warehouse_subject_eeaRow Row { get { return row; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class EeaGksAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_eea_gks";
            private string tableSample = "eea_gks";
            //
            private bool isSubject = false;
            private bool isDistrict = false;
            private bool isTax = false;
            private bool isEea = true;
            private string selectMethod = "all";
            //private int idSelectMethod = 0;

            //
            private string[,] commandsAgregation;
            //
            public EeaGksAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public EeaGksAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            //
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea { get { return isEea; } }
            public string SelectMethod { get { return selectMethod; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class SubjectEeaGksAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_subject_eea_gks";
            private string tableSample = "subject_eea_gks";
            private base_nalogDataSet.Data_warehouse_subject_eea_gksRow row; //subject_eea_gks
            //
            private bool isSubject = true;
            private bool isDistrict = false;
            private bool isTax = false;
            private bool isEea = true;
            private string[,] commandsAgregation;
            //
            public SubjectEeaGksAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public SubjectEeaGksAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            //
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea { get { return isEea; } }
            public base_nalogDataSet.Data_warehouse_subject_eea_gksRow Row { get { return row; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            //public string SelectMethod { get { return selectMethod; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class FederalDistrictAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_district";
            private string tableSample = "district";
            private base_nalogDataSet.Data_warehouse_districtRow row; //subject
            //
            private bool isSubject = false;
            private bool isDistrict = true;
            private bool isTax = false;
            private bool isEea = false;
            private string selectMethod = "all";
            private string[,] commandsAgregation;
            //
            public  FederalDistrictAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public FederalDistrictAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea { get { return isEea; } }
            public string SelectMethod { get { return selectMethod; } }
            public base_nalogDataSet.Data_warehouse_districtRow Row { get { return row; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class FederalDistrictTaxAgregation
        {
            Agregation agr;
            private ArrayList listParamsAgregation = new ArrayList();
            private string tableAgregation = "Data_warehouse_district_tax";
            private string tableSample = "district_tax";
            private base_nalogDataSet.Data_warehouse_district_taxRow row; //subject
            //
            private bool isSubject = false;
            private bool isDistrict = true;
            private bool isTax = true;
            private bool isEea = false;
            private string selectMethod = "all";
            private string[,] commandsAgregation;
            //
            public FederalDistrictTaxAgregation(Agregation Agr)
            {
                this.agr = Agr;
                commandsAgregation = agr.returnCommandsAgregation(tableSample);
                fillListParamAgregation();
            }
            public FederalDistrictTaxAgregation()
            {

            }
            //
            public ArrayList ListParamsAgregation { get { fillListParamAgregation(); return listParamsAgregation; } }
            public string[,] CommandsAgregation { get { return commandsAgregation; } }
            public string TableAgregation { get { return tableAgregation; } }
            public bool IsSubject { get { return isSubject; } }
            public bool IsDistrict { get { return isDistrict; } }
            public bool IsTax { get { return isTax; } }
            public bool IsEea { get { return isEea; } }
            public string SelectMethod { get { return selectMethod; } }
            public base_nalogDataSet.Data_warehouse_district_taxRow Row { get { return row; } }
            //public int IdSelectMethod { get { return idSelectMethod; } set { idSelectMethod = value; } }
            //
            private void fillListParamAgregation()
            {
                int countCommands = agr.frmAgr.chkListBoxAgregationParam.CheckedIndices.Count;
                listParamsAgregation.Clear();
                if (countCommands > 0)
                {
                    foreach (int i in agr.frmAgr.chkListBoxAgregationParam.CheckedIndices)
                    {
                        ParamAgregation prm = new ParamAgregation();
                        prm.SqlSelect = commandsAgregation[i, 0] + " FROM " + commandsAgregation[i, 1];
                        prm.TableName = commandsAgregation[i, 1];
                        prm.FieldSourceTable = commandsAgregation[i, 2];
                        prm.FieldDestinationTable = commandsAgregation[i, 3];
                        prm.Round = agr.cr.ImportData.returnNullInt(commandsAgregation[i, 4]);
                        listParamsAgregation.Add(prm);
                    }
                }
            }
        }
        public class ParamAgregation
        {
            public ParamAgregation()
            {
            }
            private string sqlSelect = "";
            private string tableName = "";
            private string fieldSourceTable = "";
            private string fieldDestinationTable = "";
            private int round = 2;
            private bool isMergeTable = false;
            private string nameMergeTable = "";
            //
            public string SqlSelect { get { return sqlSelect; } set { sqlSelect = value; } }
            public string TableName { get { return tableName; } set { tableName = value; } }
            public string FieldSourceTable { get { return fieldSourceTable; } set { fieldSourceTable = value; } }
            public string FieldDestinationTable { get { return fieldDestinationTable; } set { fieldDestinationTable = value; } }
            public int Round { get { return round; } set { round = value; } }
            public bool IsMergeTable{get{return isMergeTable;}set{isMergeTable=value;}}
            public string NameMergeTable { get { return nameMergeTable; } set { nameMergeTable = value; } }
        }
        public class ValuesAgregation
        {
            public ValuesAgregation()
            {
                colValues = new List<string>();
                colDestValues = new List<string>();
                values = new List<decimal>();
            }
            private List<string> colValues;
            private List<string> colDestValues;
            private List<decimal> values;
            //
            public List<string> ColValues { get { return colValues; } set { colValues = value; } }
            public List<string> ColDestValues { get { return colDestValues; } set { colDestValues = value; } }
            public List<decimal> Values { get { return values; } set { values = value; } }
        }
        public class MergeTablesAgregation
        {
            private Agregation agr;
            private ParamAgregation prm;
            //
            public MergeTablesAgregation(Agregation Agr)
            {
                this.agr = Agr;
                mainCols = new List<string>();
                mainValues = new List<int>();
                fieldsSelect = new List<string>();
                select = new List<string>();
                from = new List<string>();
                fillColValues();
                //takeSelectString();
            }
            private List<string> mainCols;
            private List<int> mainValues;
            private List<string> fieldsSelect;
            private List<string> select;
            private List<string> from;
            //
            public List<string> MainCols { get { return mainCols; } set { mainCols = value; } }
            public List<int> MainValues { get { return mainValues; } set { mainValues = value; } }
            public List<string> FieldsSelect { get { return fieldsSelect; } set { fieldsSelect = value; } }
            private void fillColValues()
            {
                mainCols.Clear();
                if (agr.isDistrict) mainCols.Add("id_district");
                if (agr.isEea) mainCols.Add("id_eea");
                if (agr.isSubject) mainCols.Add("id_subject");
                if (agr.isTax) mainCols.Add("id_tax");
                mainCols.Add("year");
                //
                for (int i = 0; i < agr.listParamsAgregation.Count; i++)
                {
                    prm = (ParamAgregation)agr.listParamsAgregation[i];
                    fieldsSelect.Add(prm.FieldSourceTable);
                }
            }
            /*private void takeSelectString()
            {
                if (agr.isSubject)
                {

                }
                mainColValues.Add("year");
            }*/
            public DataTable MergeRowsDataTable(DataTable dt)
            {
                DataTable dtNew = new DataTable();
                dtNew = dt.Clone();
                bool isAdd = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    isAdd = false;
                    DataRow row = dt.Rows[i];
                    mainValues.Clear();
                    for (int k = 0; k < mainCols.Count; k++)
                    {
                        mainValues.Add(agr.cr.ImportData.returnNullInt(dt.Rows[i][mainCols[k]]));
                    }
                    string filter = mainCols[0] + " = " + mainValues[0];
                    if (mainCols.Count > 1)
                    {
                        for (int k = 1; k < mainCols.Count; k++)
                        {
                            filter += " AND " + mainCols[k] + " = " + mainValues[k];
                        }
                    }
                    //
                    DataRow[] rowsSelect = dt.Select(filter);
                    DataRow newRow = dtNew.NewRow();
                   
                    foreach(DataRow r in rowsSelect)
                    {
                        foreach(string col in fieldsSelect)
                        {
                            if (agr.cr.ImportData.returnNullDecimal(r[col]) > 0)
                            {
                                newRow[col] = r[col];
                                isAdd = true;
                            }
                        }
                        foreach (string col in mainCols)
                        {
                            if (agr.cr.ImportData.returnNullInt(r[col]) > 0)
                            {
                                newRow[col] = r[col];
                                isAdd = true;
                            }
                        }

                        dt.Rows.Remove(r);
                    }
                    if (isAdd) dtNew.Rows.Add(newRow);
                }
                /*DataRow[] dr = new DataRow();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int k = 0; k < mainCols.Count; k++)
                        {
                            mainValues.Add(agr.cr.ImportData.returnNullInt(dt.Rows[i][mainCols[k]]));
                        }
                        string filter = mainCols[0] + " = " + mainValues[0];
                        if (mainCols.Count > 1)
                        {
                            for (int k = 1; k < mainCols.Count; k++)
                            {
                                filter += " AND" + mainCols[k] + " = " + mainValues[k];
                            }
                        }
                        dr = dt.Select(filter);
                        if (dr.Length > 1)
                        {

                        }
                    }
                }*/
                //agr.cr.Data.Base.CustomDs.Merge(dt);
                //dt = agr.cr.Data.Base.CustomDs.Tables[0];
                dt.Dispose();
                return dtNew;
            }
            /*private DataRow returnOneRow(DataRow[] drList)
            {
                DataRow dr = new DataRow();
                return dr;
            }*/
        }
    }
}