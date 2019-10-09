using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace NalogUser
{
    public partial class FormApp : Form
    {
        #region Переменные
        private Classes.Core cr;
        private Forms.FormReport frmReport;
        private FormLogin frmLogin;
        private Login lg;
        private bool isExit=false;
        //
        private EventApplicationExit eveAppExit;
        //
        public delegate void EventApplicationExit(Classes.Core cr);
        //
        public EventApplicationExit EveAppExit { get { return eveAppExit; } set { eveAppExit = value; } }
        
        #endregion Переменные
        public FormApp(Login Lg, FormLogin FrmLogin, Classes.Core Cr=null)
        {
            InitializeComponent();
            this.cr = Cr;
            if (cr != null)
            {
                cr.FrmApp = this;
            }
            else
            {
                cr = new Classes.Core(this);
            }
            cr.AppPath = Application.StartupPath;
            //cr.AnalysData.Ds = this.base_nalogDataSet;
            cr.AnalysData = new Classes.AnalysisData.AnalysisData(cr);
            this.lg = Lg;
            this.frmLogin = FrmLogin;
            this.Text += " " + lg.UserSurname + " " + lg.UserName + " " + lg.UserLastname + " (" + lg.UserLogin + ")";
            //frmLogin.Close();
            cr.FrmStarter=new FormStarter(this.cr);
            cr.FrmStarter.MdiParent=this;
            cr.FrmStarter.Show();
            cr.FrmStarter.Activate();

        }

        private void абсолютныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoiceTypeOfAnalysisForm(1);
        }

        private void относительныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoiceTypeOfAnalysisForm(2);
        }

        private void картаРФToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChoiceTypeOfAnalysisForm(3);
        }

        private void населениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runView(населениеToolStripMenuItem.Tag.ToString());
        }
        private void setParams()
        {
            cr.AnalysData.Var.IdDistrict = 1;
            cr.AnalysData.Var.IdSubject = 0;
            cr.AnalysData.Var.IdTax = 0;
            cr.AnalysData.Var.YearAfter = 2008;
            cr.AnalysData.Var.YearBefore = 2010;
        }

        private void налоговыеДоходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runView(налоговыеДоходыToolStripMenuItem.Tag.ToString());
        }
        private void runView(string tag)
        {
            try
            {
                cr.AnalysData.Var.IdReport = Convert.ToInt32(tag);
            }
            catch (System.Exception err)
            {
                return;
            }
            setParams();
            frmReport = new Forms.FormReport(cr);
            frmReport = cr.AnalysData.SwitchReport(true,0);
            frmReport.Show();
            frmReport.reportViewerData.RefreshReport();
            frmReport.reportViewerData.Update();
        }

        private void доходПоНалогуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runView(доходПоНалогуToolStripMenuItem.Tag.ToString());
        }

        private void поВидуДеятельностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runView(поВидуДеятельностиToolStripMenuItem.Tag.ToString());
        }

        private void показательКДолToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runView(показательКДолToolStripMenuItem.Tag.ToString());
        }

        private void отклонения1НМИ1НОМToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runView(отклонения1НМИ1НОМToolStripMenuItem.Tag.ToString());
        }

        private void показательОПИНToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runView(показательОПИНToolStripMenuItem.Tag.ToString());
        }

        private void населениеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            runView(населениеToolStripMenuItem1.Tag.ToString());
        }

        private void паролиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin frmLog = new FormLogin(cr);
            frmLog.MdiParent = this;
            frmLog.Show();
        }

        private void FormApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            lg.UserActivated = false;
            if (cr.B.IsSql)
            {
                //SQL
                cr.B.BaseSql.BuildRequest("UPDATE users SET activated='" + lg.UserActivated + "' Where (id='" + lg.UserId + "')");
            }
            if (cr.B.IsOledb)
            {
                //OLEDB
                cr.B.BaseOleDb.BuildRequest("UPDATE users SET activated=" + lg.UserActivated + " Where (id=" + lg.UserId + ")");
            }
            AppExit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppExit();
        }
        private void AppExit()
        {
            if (!isExit)
            {
                isExit = true;
                cr.Cfg.saveConfig();
                Application.Exit();
            }
        }
        private void OnApplicationExit(Classes.Core cr)
        {
            
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frmAbout = new FormAbout();
            frmAbout.MdiParent = this;
            frmAbout.Show();
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
                            cr.FrmAnalysisDataAbsolute.Text = cr.SetTitleFrmConfig(абсолютныеToolStripMenuItem.Text); //задаем заголовок формы
                            cr.FrmAnalysisDataAbsolute.Tag = абсолютныеToolStripMenuItem.Text;
                            cr.FrmAnalysisDataAbsolute.MdiParent = this; //устанавливаем родительский объект
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
                            cr.FrmAnalysisDataRelative.Text = cr.SetTitleFrmConfig(относительныToolStripMenuItem.Text); //задаем заголовок формы
                            cr.FrmAnalysisDataRelative.Tag = относительныToolStripMenuItem.Text;
                            cr.FrmAnalysisDataRelative.MdiParent = this; //устанавливаем родительский объект
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
                            cr.FrmAnalysisDataOnMap.MdiParent = this;
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

    }
}
