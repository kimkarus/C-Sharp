using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Chart2DLib; //Подключаем библиотеку

namespace NalogUser.Forms
{
    public partial class FormParamsSpreading : Form
    {
        private Classes.Core cr;
        public FormParamsSpreading(Classes.Core Cr)
        {
            InitializeComponent();
            this.cr = Cr;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            setParams();
            this.Close();
        }
        private void setParams()
        {
            cr.AnalysData.Var.CountIntervals = cr.AnalysData.returnNullInt(this.textBoxCountIntervals.Text);
        }
    }
}
