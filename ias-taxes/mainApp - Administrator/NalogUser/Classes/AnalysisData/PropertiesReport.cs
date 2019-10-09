using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NalogUser.Classes.AnalysisData
{
    public struct PropertiesReport
    {
        private Classes.AnalysisData.AnalysisDataVariables var;
        private Forms.FormReport frmReport;
        //
        public Classes.AnalysisData.AnalysisDataVariables Var{ get { return this.var; } set { this.var = value; } }
        public Forms.FormReport FrmReport { get { return this.frmReport; } set { this.frmReport = value; } }
        //
    }
}
