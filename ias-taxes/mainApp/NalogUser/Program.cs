using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using System.IO;

namespace NalogUser
{
    static class Program
    {
        /// <summary>
        /// Информационно-аналитическая система региональных налоговых поступлений Российской Федерации
        /// ИАС "Налоги РФ"
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Classes.Encryption encr = new Classes.Encryption();
            
            /*string strCon = "";
            string strCon2 = "";
            BinaryReader binR = new BinaryReader(File.OpenRead(Application.StartupPath + "\\settings.bin"));
            foreach (char ch in binR.ReadChars((int)binR.BaseStream.Length))
            {
                strCon += ch.ToString();
            }
            binR.Close();
            strCon = encr.Decryptor(strCon);
            strCon2 =strCon;*/
            Classes.Core cr = new Classes.Core();
            if (NalogUser.App.Default.ConnectionString!="")
            {
                if (cr.B.IsSql)
                {
                    if (!cr.B.BaseSql.TestConnection())
                    {
                        Application.Exit();
                    }
                    else
                    {
                        Application.Run(new FormLogin(cr));
                    }
                }
                if (cr.B.IsOledb)
                {
                    if (!cr.B.BaseOleDb.TestConnection())
                    {
                        Application.Exit();
                    }
                    else
                    {
                        Application.Run(new FormLogin(cr));
                    }
                }
                
            }
            else
            {
                Application.Exit();
            }
            //Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.MicrosoftReportViewerWinForms);
            //Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.MicrosoftReportViewerCommon);
            /*Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.MicrosoftReportViewerProcessingObjectModel);
            Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.MicrosoftReportViewerWebForms);
            Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.PresentationCore);
            Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.PresentationFramework);
            Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.SystemDataDataSetExtensions);
            Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.SystemXmlLinq);
            Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.UIAutomationProvider);
            Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.WindowsBase);
            Assembly.LoadFile(Application.StartupPath + NalogUser.Properties.Settings.Default.WindowsFormsIntegration);*/
        }
    }
}
