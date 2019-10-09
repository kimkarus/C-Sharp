using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator
{
    public partial class FormApp : Form
    {
        #region Переменные
        private Classes.Core cr;
        private Forms.Reference.FormReference frmReference;
        #endregion Переменные
        public FormApp()
        {
            InitializeComponent();
            cr = new Classes.Core(this);
            cr.Data = new Classes.Data();
            cr.Data.Base = new Classes.Base();
            cr.SwitchCotrlos = new Classes.SwitchControls();
        }

        private void налоговаяОтчетность1НМToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormImportData(this.налоговаяОтчетностьToolStripMenuItem.Tag.ToString());
        }
        private void openFormImportData(string tag)
        {
            cr.ImportData = new Classes.ImpData.ImportData(cr, tag);
        }
        private void населениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormImportData(this.населениеToolStripMenuItem.Tag.ToString());
        }

        private void субъектыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SwitchControl(субъектыToolStripMenuItem1.Tag.ToString(), субъектыToolStripMenuItem1.Text);
        }

        private void видыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchControl(видыToolStripMenuItem.Tag.ToString(), видыToolStripMenuItem.Text);
        }
        private void налогиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SwitchControl(налогиToolStripMenuItem1.Tag.ToString(), налогиToolStripMenuItem1.Text);
        }

        private void округаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchControl(округаToolStripMenuItem.Tag.ToString(), округаToolStripMenuItem.Text);
        }
        private void SwitchControl(string tag, string text)
        {
            frmReference = new Forms.Reference.FormReference();
            cr.SwitchCotrlos.ControlReference = new Classes.SwitchControls.ControlReferences();
            UserControl control = cr.SwitchCotrlos.ControlReference.ReturnSwitchedControl(tag);
            frmReference.Controls.Add(control);
            frmReference.Text += text;
            frmReference.MdiParent = this;
            //
            frmReference.Width = control.Width + 20;
            frmReference.Height = control.Height;
            //
            /*-----Controls lable header | Текст шапки в контролле------*/
            //
            Label lblHeader = new Label();
            lblHeader.Text = text;
            lblHeader.Location = new System.Drawing.Point(20, 25);
            lblHeader.Parent = control.Controls["panel1"];
            lblHeader.Visible = true;
            lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lblHeader.Size = new System.Drawing.Size(control.Width, 45);
            //
            /*-----Controls button to exit | Кнопка для закрытия формы*/
            //
            Button btExit = new Button();
            btExit.Size = new System.Drawing.Size(75, 23);
            btExit.Parent = control.Controls["panel2"];
            btExit.Location = new System.Drawing.Point(control.Width - btExit.Size.Width - 10, 30);
            btExit.Name = "btExit";
            btExit.Text = "Закрыть";
            btExit.Visible = true;
            btExit.Click += new System.EventHandler(btExit_Click);
            //
            frmReference.Show();
            cr.SwitchCotrlos.ControlReference = null;
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            frmReference.Close();
        }
        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormSettings frmSettings = new Forms.FormSettings();
            frmSettings.Show();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchControl(отчетыToolStripMenuItem.Tag.ToString(), отчетыToolStripMenuItem.Text);
        }

        private void клацToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormStatisticImportData frmStat = new Forms.FormStatisticImportData(cr);
            frmStat.Show();
        }

        private void налоговыйОрганToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchControl(налоговыйОрганToolStripMenuItem.Tag.ToString(), налоговыйОрганToolStripMenuItem.Text);
        }

        private void форма1НМToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchControl(форма1НМToolStripMenuItem.Tag.ToString(), форма1НМToolStripMenuItem.Text);
        }

        private void поВидамЭкоДеятToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchControl(поВидамЭкоДеятToolStripMenuItem.Tag.ToString(), поВидамЭкоДеятToolStripMenuItem.Text);
        }

        private void городаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchControl(городаToolStripMenuItem.Tag.ToString(), городаToolStripMenuItem.Text);
        }

        private void агрегацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormDataAggregation frmDataAgregation = new Forms.FormDataAggregation(cr);
            frmDataAgregation.MdiParent = this;
            frmDataAgregation.Show();
        }

        private void показателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormImportData(this.показателиToolStripMenuItem.Tag.ToString());
        }
    }
}
