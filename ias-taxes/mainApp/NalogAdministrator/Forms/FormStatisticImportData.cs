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
    public partial class FormStatisticImportData : Form
    {
        private Classes.Core cr;
        private TimeSpan tSpan;
        private float sumTime = 0;
        public FormStatisticImportData(Classes.Core Cr)
        {
            this.cr = Cr;
            InitializeComponent();
            sumTime = 0;
            this.label1.Text = (cr.GetParamBefore / 1000).ToString();
            this.label2.Text = (cr.ProcessingEventsReadFile / 1000).ToString();
            for (int i = 0; i < cr.ProcessingEventAddToBase.Count; i++)
            {
                this.listBox1.Items.Add(cr.ProcessingEventAddToBase[i] / 1000);
                sumTime += cr.ProcessingEventAddToBase[i];
            }
            this.label4.Text = (sumTime / cr.ProcessingEventAddToBase.Count / 1000).ToString();
        }
    }
}
