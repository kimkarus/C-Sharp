﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NalogUser {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    public sealed partial class connection : global::System.Configuration.ApplicationSettingsBase {
        
        private static connection defaultInstance = ((connection)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new connection())));
        
        public static connection Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<SerializableConnectionString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <ConnectionString>Data Source=193.169.44.63,1433;Initial Catalog=tax-177_nalog;Persist Security Info=True;User ID=ias;Password=oMXM0wOJ;Network Library=dbmssocn</ConnectionString>
</SerializableConnectionString>")]
        public string ConnectionStringSQL {
            get {
                return ((string)(this["ConnectionStringSQL"]));
            }
            set {
                this["ConnectionStringSQL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<SerializableConnectionString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <ConnectionString>Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""G:\Образование\Разработки\Программа\ИАС Налог\БД\IAS_Nalog.accdb"";Persist Security Info=True;Encrypt Password=False;Mask Password=False;Jet OLEDB:Database Password=sgYigYvGU7aCkshTajrA</ConnectionString>
</SerializableConnectionString>")]
        public string ConnectionStringOLEDB {
            get {
                return ((string)(this["ConnectionStringOLEDB"]));
            }
            set {
                this["ConnectionStringOLEDB"] = value;
            }
        }
    }
}
