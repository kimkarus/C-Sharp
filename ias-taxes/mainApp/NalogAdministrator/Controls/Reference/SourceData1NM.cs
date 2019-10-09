using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NalogAdministrator.Controls.Reference
{
    public partial class SourceData1NM : UserControl
    {
        public SourceData1NM()
        {
            InitializeComponent();
            this.federal_districtTableAdapter.Fill(this.base_nalogDataSet.Federal_district);
            this.subjectsTableAdapter.Fill(this.base_nalogDataSet.Subjects);
            this.source_data_1NMTableAdapter.Fill(this.base_nalogDataSet.Source_data_1NM);
        }

        private void fillSourceData1NM(int idSubject, short year)
        {
            if (idSubject != null)
            {
                //this.source_data_1NMBindingSource.Filter[
            }
            if (idSubject != null && year != null)
            {
            }
        }

        private void comboBoxSelectSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSourceData1NM(Convert.ToInt32(this.comboBoxSelectSubject.SelectedValue), 
                Convert.ToInt16(this.comboBoxSelectYear.SelectedValue));
        }
    }
}
