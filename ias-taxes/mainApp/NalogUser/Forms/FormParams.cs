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
    public partial class FormParams : Form
    {
        private Classes.Core cr;
        private BindingSource bs;
        private string displayMember;
        private string valueMember;
        private string type = "";
        public FormParams(Classes.Core Cr, BindingSource Bs, string DisplayMember, string ValueMember, string Type)
        {
            InitializeComponent();
            this.cr = Cr;
            this.bs = Bs;
            this.displayMember = DisplayMember;
            this.valueMember = ValueMember;
            this.type = Type;
        }

        private void FormParams_Load(object sender, EventArgs e)
        {
            this.listBoxValues.DataSource = bs;
            this.listBoxValues.DisplayMember = displayMember;
            this.listBoxValues.ValueMember = valueMember;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int[] ids = new int[this.listBoxValues.SelectedItems.Count];
            string[] strs = new string[this.listBoxValues.SelectedItems.Count];
            int id = 0;
            string str = "";
            for (int i = 0; i < listBoxValues.SelectedItems.Count; i++)
            {
                DataRowView rowView = (DataRowView)listBoxValues.SelectedItems[i];
                ids[i] = cr.AnalysData.returnNullInt(rowView.Row.ItemArray[0]);
                strs[i] = rowView.Row.ItemArray[1].ToString();
            }
            if (listBoxValues.SelectedItems.Count == 1)
            {
                id = ids[0];
                str = strs[0];
            }
            switch (type)
            {
                case "s":
                    {
                        cr.AnalysData.Var.IdsSubjects = ids;
                        cr.AnalysData.Var.StrSubjects = strs;
                        break;
                    }
                case "d":
                    {
                        cr.AnalysData.Var.IdsDistricts = ids;
                        break;
                    }
                case "t":
                    {
                        cr.AnalysData.Var.IdsTaxes = ids;
                        break;
                    }
                case "e":
                    {
                        cr.AnalysData.Var.IdsEea = ids;
                        break;
                    }
                case "i":
                    {
                        cr.AnalysData.Var.IdsIndex = ids;
                        break;
                    }
            }
            this.Close();

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxValues.ClearSelected();
            switch (type)
            {
                case "s":
                    {
                        cr.AnalysData.Var.IdsSubjects = null;
                        cr.AnalysData.Var.StrSubjects = null;
                        break;
                    }
                case "d":
                    {
                        cr.AnalysData.Var.IdsDistricts = null;
                        break;
                    }
                case "t":
                    {
                        cr.AnalysData.Var.IdsTaxes = null;
                        break;
                    }
                case "e":
                    {
                        cr.AnalysData.Var.IdsEea = null;
                        break;
                    }
                case "i":
                    {
                        cr.AnalysData.Var.IdsIndex = null;
                        break;
                    }
            }
        }

    }
}
