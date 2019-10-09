using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NalogAdministrator.Classes
{
    public class SwitchControls
    {
        private ControlReferences cntrReference;
        //
        public ControlReferences ControlReference { get { return cntrReference; } set { cntrReference = value; } }
        public class ControlReferences
        {
            private Controls.Reference.FederalDistrict cntrFederalDistrict;
            private Controls.Reference.Subjects cntrSubjects;
            private Controls.Reference.Cities cntrCities;
            private Controls.Reference.Taxes cntrTaxes;
            private Controls.Reference.TaxesView cntrTaxesView;
            private Controls.Reference.Reports cntrReports;
            private Controls.Reference.TaxAuthority cntrTaxAuthority;
            private Controls.Reference.SourceData1NM cntrSourceData1NM;
            private Controls.Reference.TaxesKea cntrTaxesKea;
            //
            //
            public ControlReferences()
            {

            }
            public System.Windows.Forms.UserControl ReturnSwitchedControl(string tag)
            {
                System.Windows.Forms.UserControl control = new System.Windows.Forms.UserControl();
                
                switch (tag)
                {
                    case "Taxes":
                        {
                            cntrTaxes = new Controls.Reference.Taxes();
                            control = cntrTaxes;
                            break;
                        }
                    case "TaxesView":
                        {
                            cntrTaxesView = new Controls.Reference.TaxesView();
                            control = cntrTaxesView;
                            break;
                        }
                    case "FederalDistrict":
                        {
                            cntrFederalDistrict = new Controls.Reference.FederalDistrict();
                            control = cntrFederalDistrict;
                            break;
                        }
                    case "Subjects":
                        {
                            cntrSubjects = new Controls.Reference.Subjects();
                            control = cntrSubjects;
                            break;
                        }
                    case "Cities":
                        {
                            cntrCities = new Controls.Reference.Cities();
                            control = cntrCities;
                            break;
                        }
                        
                    case "Reports":
                        {
                            cntrReports = new Controls.Reference.Reports();
                            control = cntrReports;
                            break;
                        }
                    case "TaxAuthority":
                        {
                            cntrTaxAuthority = new Controls.Reference.TaxAuthority();
                            control = cntrTaxAuthority;
                            break;
                        }
                    case "SourceData1NM":
                        {
                            cntrSourceData1NM = new Controls.Reference.SourceData1NM();
                            control = cntrSourceData1NM;
                            break;
                        }
                    case "TaxesKea":
                        {
                            cntrTaxesKea = new Controls.Reference.TaxesKea();
                            control = cntrTaxesKea;
                            break;
                        }
                }
                return control;
            }
        }
    }
}
