﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NalogAdministrator.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=193.169.44.63,1433;Initial Catalog=tax-177_nalog;Persist Security Inf" +
            "o=True;User ID=ias;Password=oMXM0wOJ;Packet Size=8000")]
        public string base_nalogConnectionString {
            get {
                return ((string)(this["base_nalogConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>1</string>
  <string>2</string>
  <string>3</string>
  <string>4</string>
  <string>5</string>
  <string>Лист1</string>
  <string>Лист2</string>
  <string>Лист3</string>
  <string>raz1</string>
  <string>raz2</string>
  <string>raz3</string>
  <string>1раздел</string>
  <string>2раздел</string>
  <string>3раздел</string>
  <string>Раздел 1</string>
  <string>Раздел 2</string>
  <string>Раздел 3</string>
  <string>1разд</string>
  <string>2разд</string>
  <string>3разд</string>
  <string>1nm</string>
  <string>Лист</string>
  <string>свод</string>
  <string>раздел 1</string>
  <string>раздел 2</string>
  <string>раздел 3</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection AllowExcelSheet {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["AllowExcelSheet"]));
            }
            set {
                this["AllowExcelSheet"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>total_population</string>
  <string>busyed</string>
  <string>unemployed</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection TablesPopulation {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["TablesPopulation"]));
            }
            set {
                this["TablesPopulation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>1NM</string>
  <string>1NOM</string>
  <string>4NOM</string>
  <string>1NM-FORCAST</string>
  <string>1NOM-FORCAST</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection TypeReports {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["TypeReports"]));
            }
            set {
                this["TypeReports"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>raz1</string>\r\n  <string>raz2</string>\r\n  <string>raz3</string>\r\n</ArrayOf" +
            "String>")]
        public global::System.Collections.Specialized.StringCollection AllowExcelOleDbSheets {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["AllowExcelOleDbSheets"]));
            }
            set {
                this["AllowExcelOleDbSheets"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1NM")]
        public string Report1NM {
            get {
                return ((string)(this["Report1NM"]));
            }
            set {
                this["Report1NM"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1NOM")]
        public string Report1NOM {
            get {
                return ((string)(this["Report1NOM"]));
            }
            set {
                this["Report1NOM"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>2</string>
  <string>4</string>
  <string>6</string>
  <string>7</string>
  <string>9</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection NumberCol1NOM {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["NumberCol1NOM"]));
            }
            set {
                this["NumberCol1NOM"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>1020</string>
  <string>1040</string>
  <string>1210</string>
  <string>1220</string>
  <string>1730</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection CodeTax1NOM {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["CodeTax1NOM"]));
            }
            set {
                this["CodeTax1NOM"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1NM-FORCAST")]
        public string Report1NMForcast {
            get {
                return ((string)(this["Report1NMForcast"]));
            }
            set {
                this["Report1NMForcast"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1NOM-FORCAST")]
        public string Report1NOMForcast {
            get {
                return ((string)(this["Report1NOMForcast"]));
            }
            set {
                this["Report1NOMForcast"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1NM-FORCAST-11-")]
        public string Report1NMForcast11 {
            get {
                return ((string)(this["Report1NMForcast11"]));
            }
            set {
                this["Report1NMForcast11"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ListOfIdsSubjectsYears {
            get {
                return ((string)(this["ListOfIdsSubjectsYears"]));
            }
            set {
                this["ListOfIdsSubjectsYears"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>domestic_regional_product</string>
  <string>consumer_price_index</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection TablesIndex {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["TablesIndex"]));
            }
            set {
                this["TablesIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1130;1210;")]
        public string ListOfTaxes {
            get {
                return ((string)(this["ListOfTaxes"]));
            }
            set {
                this["ListOfTaxes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25;")]
        public string ListOfIdsSubjects {
            get {
                return ((string)(this["ListOfIdsSubjects"]));
            }
            set {
                this["ListOfIdsSubjects"] = value;
            }
        }
    }
}