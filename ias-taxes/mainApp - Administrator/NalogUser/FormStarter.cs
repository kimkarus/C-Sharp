using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogUser
{
    public partial class FormStarter : Form
    {
        #region Переменные
        private Classes.Core cr;
        private Forms.FormReport frmReport;
        private FormLogin frmLogin;
        private Login lg;
        #endregion Переменные
        public FormStarter(Classes.Core Cr)
        {
            InitializeComponent();
            this.cr = Cr; 
        }
        private void ChoiceTypeOfAnalysisForm(int type)
        {
            switch (type)
            {
                case 1:
                    {
                        if (cr.FrmAnalysisDataAbsolute == null)
                        {
                            cr.FrmAnalysisDataAbsolute = new Forms.FormAnalysisData(cr, 1);
                            cr.FrmAnalysisDataAbsolute.Text = cr.SetTitleFrmConfig(btAbsolute.Text); //задаем заголовок формы
                            cr.FrmAnalysisDataAbsolute.Tag = btAbsolute.Text;
                            cr.FrmAnalysisDataAbsolute.MdiParent = cr.FrmApp; //устанавливаем родительский объект
                            cr.FrmAnalysisDataAbsolute.Show(); //показываем форму
                            cr.FrmAnalysisDataAbsolute.Activate();
                        }
                        else
                        {
                            cr.FrmAnalysisDataAbsolute.Show(); //показываем форму
                            cr.FrmAnalysisDataAbsolute.Activate();
                        }
                        break;
                    }
                case 2:
                    {
                        if (cr.FrmAnalysisDataRelative == null)
                        {
                            cr.FrmAnalysisDataRelative = new Forms.FormAnalysisData(cr, 2);
                            cr.FrmAnalysisDataRelative.Text = cr.SetTitleFrmConfig(btRelative.Text); //задаем заголовок формы
                            cr.FrmAnalysisDataRelative.Tag = btRelative.Text;
                            cr.FrmAnalysisDataRelative.MdiParent = cr.FrmApp; //устанавливаем родительский объект
                            cr.FrmAnalysisDataRelative.Show(); //показываем форму
                        }
                        else
                        {
                            cr.FrmAnalysisDataRelative.Show(); //показываем форму
                            cr.FrmAnalysisDataRelative.Activate();
                        }
                        break;
                    }
                case 3:
                    {
                        if (cr.FrmAnalysisDataOnMap == null)
                        {
                            cr.FrmAnalysisDataOnMap = new Forms.FormAnalysisDataOnMap(cr);
                            cr.FrmAnalysisDataOnMap.MdiParent = cr.FrmApp;
                            cr.FrmAnalysisDataOnMap.Show();
                        }
                        else
                        {
                            cr.FrmAnalysisDataOnMap.Show();
                            cr.FrmAnalysisDataOnMap.Activate();
                        }
                        break;
                    }
            }

        }

        private void btAbsolute_Click(object sender, EventArgs e)
        {
            ChoiceTypeOfAnalysisForm(1);
        }

        private void btRelative_Click(object sender, EventArgs e)
        {
            ChoiceTypeOfAnalysisForm(2);
        }

        private void btMap_Click(object sender, EventArgs e)
        {
            ChoiceTypeOfAnalysisForm(3);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btModels_Click(object sender, EventArgs e)
        {

        }
    }
}
