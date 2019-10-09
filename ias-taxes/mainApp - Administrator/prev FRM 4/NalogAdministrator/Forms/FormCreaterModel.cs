using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Forms
{
    public partial class FormCreaterModel : Form
    {
        private Classes.Core cr;
        private Classes.CreaterModel crModel;
        private Controls.UserControlAnalysisDataDefault ucDefaultChoice;
        private string[,] arrTypeModel = { 
                                              {"Моделирование по итоговым показателям субъектов и видам налогов", "subject_tax", "Data_warehouse_subject_tax", "Subjects", "id_subject"},
                                              {"Моделирование по итоговым показателям субъектов, видам налогов и бюджетам", "subject_tax_budget", "Data_warehouse_subject_tax_budget", "Subjects", "id_subject"},
                                              {"Моделирование по итоговым показателям субъектов, видов налогов и ВЭД", "subject_tax_eea", "Compare_tax_eea","Subjects", "id_subject"}};
        public FormCreaterModel(Classes.Core Cr)
        {
            InitializeComponent();
            this.cr = Cr;
            this.cr.ImportData = new Classes.ImpData.ImportData(this.cr);
            ucDefaultChoice = new Controls.UserControlAnalysisDataDefault(cr);
            this.groupBoxAdvParams.Controls.Add(ucDefaultChoice);
            ucDefaultChoice.comboBoxYearAfter.Text = cr.ImportData.Var.YearAfter.ToString();
            ucDefaultChoice.comboBoxYearBefore.Text = cr.ImportData.Var.YearBefore.ToString();
            this.comboBoxSelectTypeModel.Items.Clear();
            for (int i = 0; i < arrTypeModel.Length / 5; i++)
            {
                this.comboBoxSelectTypeModel.Items.Add(arrTypeModel[i, 0]);
            }
            
        }
        private bool setParams()
        {
            bool isGood = true;
            cr.ImportData.Var.YearBefore = 0;
            cr.ImportData.Var.YearAfter = 0;
            cr.ImportData.Var.IdDistrict = 0;
            cr.ImportData.Var.IdSubject = 0;
            cr.ImportData.Var.IdTax = 0;
            cr.ImportData.Var.IdEea = 0;
            cr.ImportData.Var.CountIntervals = 0;
            cr.ImportData.Var.IdTypeModel = 0;
            cr.ImportData.Var.NameTypeModel = "";

            try
            {
                if (ucDefaultChoice.checkBoxDistrict.Checked)
                {
                    cr.ImportData.Var.IdDistrict = Convert.ToInt32(ucDefaultChoice.comboBoxDistrict.SelectedValue);
                }
                else
                {
                    cr.ImportData.Var.IdDistrict = 0;
                }
                if (ucDefaultChoice.checkBoxSubject.Checked)
                {
                    cr.ImportData.Var.IdSubject = cr.ImportData.returnNullInt(ucDefaultChoice.comboBoxSubjetcs.SelectedValue);
                }
                else
                {
                    cr.ImportData.Var.IdSubject = 0;
                }
                if (ucDefaultChoice.checkBoxTax.Checked)
                {
                    cr.ImportData.Var.IdTax = Convert.ToInt32(ucDefaultChoice.comboBoxTaxes.SelectedValue);
                }
                else
                {
                    cr.ImportData.Var.IdTax = 0;
                }
                if (ucDefaultChoice.checkBoxTaxEea.Checked)
                {
                    cr.ImportData.Var.IdEea = Convert.ToInt32(ucDefaultChoice.comboBoxTaxesEea.SelectedValue);
                }
                else
                {
                    cr.ImportData.Var.IdEea = 0;
                }
                if (ucDefaultChoice.checkBoxYears.Checked)
                {
                    if(ucDefaultChoice.comboBoxYearBefore.Text.Length>0)cr.ImportData.Var.YearBefore = Convert.ToInt16(ucDefaultChoice.comboBoxYearBefore.Text);
                    if (ucDefaultChoice.comboBoxYearAfter.Text.Length > 0) cr.ImportData.Var.YearAfter = Convert.ToInt16(ucDefaultChoice.comboBoxYearAfter.Text);
                }
                else
                {
                    cr.ImportData.Var.YearBefore = 0;
                    cr.ImportData.Var.YearAfter = 0;
                }
                /*if (textBoxYearAfter.Text.Length > 0 || textBoxYearBefore.Text.Length > 0)
                {
                    cr.ImportData.Var.YearAfter = (short)cr.ImportData.returnNullInt(textBoxYearAfter.Text.ToString());
                    cr.ImportData.Var.YearBefore = (short)cr.ImportData.returnNullInt(textBoxYearBefore.Text.ToString());
                }*/
                cr.ImportData.Var.CountIntervals = Convert.ToInt32(this.textBoxCountIntervals.Text);
                cr.ImportData.Var.IdTypeModel = cr.ImportData.returnNullInt(this.comboBoxTypeModel.SelectedValue);
                cr.ImportData.Var.NameTypeModel = this.comboBoxTypeModel.Text;
                cr.ImportData.Var.ForecastPeriod = cr.ImportData.returnNullInt(this.textBoxForecastPeriod.Text);
            }
            catch (System.Exception err)
            {
                isGood = false;
            }
            //
            cr.ImportData.Var.IsYears = this.ucDefaultChoice.checkBoxYears.Checked;
            cr.ImportData.Var.IsIdSubject = this.ucDefaultChoice.checkBoxSubject.Checked;
            cr.ImportData.Var.IsIdTax = this.ucDefaultChoice.checkBoxTax.Checked;
            cr.ImportData.Var.IsIdEea = this.ucDefaultChoice.checkBoxTaxEea.Checked;
            cr.ImportData.Var.IsYears = this.ucDefaultChoice.checkBoxYears.Checked;
            //
            return isGood;
        }

        private void btCreateModel_Click(object sender, EventArgs e)
        {
            //
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, arrTypeModel[this.comboBoxSelectTypeModel.SelectedIndex, 2]);
            crModel.createModel();
        }

        private void FormCreaterModel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'base_nalogDataSet.Model_type' table. You can move, or remove it, as needed.
            if (this.model_typeTableAdapter == null) this.model_typeTableAdapter = new base_nalogDataSetTableAdapters.Model_typeTableAdapter();
            //if (this.base_nalogDataSet.Model_type == null) this.base_nalogDataSet.Model_type = new base_nalogDataSet.Model_typeDataTable();
            this.model_typeTableAdapter.Fill(this.base_nalogDataSet.Model_type);

        }

        private void buttonChooseTheBest_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, arrTypeModel[this.comboBoxSelectTypeModel.SelectedIndex, 2]);
            crModel.ChooseBestModels();
        }

        private void buttonCorrelation_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, arrTypeModel[this.comboBoxSelectTypeModel.SelectedIndex, 2]);
            crModel.TakeCorrelationTaxEea();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, arrTypeModel[this.comboBoxSelectTypeModel.SelectedIndex, 2]);
            crModel.takeForeCast();
        }

        private void buttonCorrelationTaxIndexes_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, arrTypeModel[this.comboBoxSelectTypeModel.SelectedIndex, 2]);
            crModel.TakeCorrelationTaxIndexes();
        }

        private void buttonCorrelationTaxBudgetIndexes_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationTaxBudgetIndexes();
        }

        private void buttonCorrelationEeaBudgetIndexes_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, arrTypeModel[this.comboBoxSelectTypeModel.SelectedIndex, 2]);
            crModel.TakeCorrelationEeaBudgetIndexes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, arrTypeModel[this.comboBoxSelectTypeModel.SelectedIndex, 2]);
            crModel.TakeCorrelationSubjectСoefficientsTaxBudget();
        }

        private void buttonCorrelValues_Click(object sender, EventArgs e)
        {
            //Корреляция между разными показателями
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationSubjectValues();
        }

        private void buttonCollect_Click(object sender, EventArgs e)
        {
            //Объединения данных о коэффициентах корреляции
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationCollectionTaxIndexesSubjectValues(checkBoxCleanBeforeFill.Checked);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationBudgetIndexes();
        }

        private void buttonFilterFactors_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeFilterFactors();
        }

        private void buttonFunctions_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            if (this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.Checked) crModel.deleteModelsSubjectsBudgetsTaxesIndexes();
            if (this.checkBoxCleanModels.Checked) crModel.cleanModels();
            crModel.TakeFunctions();
        }

        private void buttonThreeInOne_Click(object sender, EventArgs e)
        {
            //
            //
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            if (this.checkBoxDeleteModelsSubjectsBudgetsTaxesIndexes.Checked) crModel.deleteModelsSubjectsBudgetsTaxesIndexes();
            if (this.checkBoxCleanModels.Checked) crModel.cleanModels();
            //
            if (this.checkBoxTakeCorrelationAgain.Checked)
            {
                crModel.cleanCorrelation();
                //
                if (!setParams()) return;
                crModel = new Classes.CreaterModel(this.cr, "");
                crModel.TakeCorrelationTaxBudgetIndexes();
                //
                if (!setParams()) return;
                crModel.TakeCorrelationSubjectValues();
                //
                if (!setParams()) return;
                crModel = new Classes.CreaterModel(this.cr, "");
                crModel.TakeCorrelationCollectionTaxIndexesSubjectValues(checkBoxCleanBeforeFill.Checked);
            }
            //
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationTaxBudgetIndexes(this.checkBoxCleanCorrelation.Checked);

            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationSubjectValues(this.checkBoxCleanCorrelation.Checked);
            
            if (!setParams()) return;
            if (this.comboBoxSelectTypeModel.SelectedIndex < 0) this.comboBoxSelectTypeModel.SelectedIndex = 1;
            crModel = new Classes.CreaterModel(this.cr, arrTypeModel[this.comboBoxSelectTypeModel.SelectedIndex, 2]);
            crModel.TakeCorrelationSubjectСoefficientsTaxBudget(this.checkBoxCleanCorrelation.Checked);

            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationCollectionTaxIndexesSubjectValues(this.checkBoxCleanCorrelation.Checked);

            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeFilterFactors();

            crModel.TakeFunctions(this.checkBoxCleanCorrelation.Checked);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationTaxBudgetIndexes();

            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationSubjectValues();

            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeCorrelationCollectionTaxIndexesSubjectValues(checkBoxCleanBeforeFill.Checked);

            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeFilterFactors();

            if (!setParams()) return;
            crModel = new Classes.CreaterModel(this.cr, "");
            crModel.TakeFunctions();
        }
    }
}
