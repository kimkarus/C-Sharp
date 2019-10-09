using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogUser.Forms
{
    public partial class FormExtention : Form
    {
        private Classes.Core cr;
        public FormExtention(Classes.Core Cr)
        {
            this.cr = Cr;
            InitializeComponent();
            NalogUser.Controls.AnalysisData.UserControlSubjects uCntrlSubjects = new Controls.AnalysisData.UserControlSubjects();
            this.Controls.Add(uCntrlSubjects);
        }
    }
}
