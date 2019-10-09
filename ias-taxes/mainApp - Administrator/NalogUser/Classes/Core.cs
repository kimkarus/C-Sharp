using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;
using Chart2DLib;

namespace NalogUser.Classes
{
    public class Core
    {
        //Формы
        //private AnalysisData.AnalysisData analysData;
        private EventTakeScreenShot eveScrShot;
        //
        public delegate void EventTakeScreenShot(int width = 0, int height = 0, int x = 0, int y = 0, string name = "");
        //
        public EventTakeScreenShot EveScrShot { get { return eveScrShot; } set { eveScrShot = value; } }
        private AnalysisData.AnalysisData analysData;
        private Classes.AnalysisData.ColumnNames clNames = new AnalysisData.ColumnNames();
        private string appPath = "";
        private string paramTitaleForm = "Конфигурация отчета:";
        private _Config cfg;
        private Classes.Data.Base b;
        private Classes.Encryption encrypt;
        #region формы
        private FormApp frmApp;
        private Forms.FormReport frmReportView;
        private Forms.FormAnalysisData frmAnalysisDataAbsolute;
        private Forms.FormAnalysisData frmAnalysisDataRelative;
        private Forms.FormAnalysisDataOnMap frmAnalysisDataOnMap;
        private Forms.FormChoiceParamAdvance frmChoiceParamAdvance;
        private Forms.FormExtention frmExtention;
        private FormStarter frmStarter;
        #endregion
        //
        public Core(FormApp FrmAppl=null)
        {
            this.frmApp = FrmAppl;
            encrypt = new Encryption();
            cfg = new _Config(this);
            b = new Data.Base();
            eveScrShot = new EventTakeScreenShot(OnTakeScreenShot);
        }

        //
        #region Глобальные
        public AnalysisData.AnalysisData AnalysData { get { return analysData; } set { analysData = value; } }
        public Classes.AnalysisData.ColumnNames ClNames { get { return clNames; } }
        public _Config Cfg{get{return cfg;}}
        public Classes.Encryption Encrypt { get { return encrypt; } }
        public Classes.Data.Base B { get { return b; } set { b = value; } }
        #region Формы глобальыне
        public FormApp FrmApp { get { return frmApp; } set { frmApp = value; } }
        public Forms.FormAnalysisData FrmAnalysisDataAbsolute { get { return frmAnalysisDataAbsolute; } set { frmAnalysisDataAbsolute = value; } }
        public Forms.FormAnalysisData FrmAnalysisDataRelative { get { return frmAnalysisDataRelative; } set { frmAnalysisDataRelative = value; } }
        public Forms.FormAnalysisDataOnMap FrmAnalysisDataOnMap { get { return frmAnalysisDataOnMap; } set { frmAnalysisDataOnMap = value; } }
        public Forms.FormChoiceParamAdvance FrmChoiceParamAdvance { get { return frmChoiceParamAdvance; } set { frmChoiceParamAdvance = value; } }
        public Forms.FormReport FrmReportView { get { return frmReportView; } set { frmReportView = value; } }
        public Forms.FormExtention FrmExtention { get { return frmExtention; } set { frmExtention = value; } }
        public FormStarter FrmStarter { get { return frmStarter; } set { frmStarter = value; } }
        #endregion Формы глобальыне
        #endregion Глобальные
        public string AppPath { get { return appPath; } set { appPath = value; } }
        public string SetTitleFrmConfig(string menuTag)
        {
            string hh = "";
            hh = paramTitaleForm + " " + menuTag.ToLower() + " показатели";
            return hh;
        }
        public bool CheckActiveForm()
        {
            bool y = true;
            return y;
        }
        public void CloseForm(Form form)
        {
            form.Dispose();
            //form = null;
            form.Close();
            //
            
            //
            if (form == frmAnalysisDataAbsolute)
            {
                frmAnalysisDataAbsolute.Dispose();
                frmAnalysisDataAbsolute = null;
            }
            if (form == frmAnalysisDataRelative)
            {
                frmAnalysisDataRelative.Dispose();
                frmAnalysisDataRelative = null;
            }
        }
        private void OnTakeScreenShot(int width = 0, int height = 0, int x = 0, int y = 0, string name="")
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics grf = Graphics.FromImage(bmp);
            System.Drawing.Size s = new Size();
            s.Width = width;
            s.Height = height;
            grf.CopyFromScreen(x, y, 0, 0, s, CopyPixelOperation.SourceCopy);
            if (name.Length > 0)
            {
                bmp.Save(this.cfg.AppPath + "\\" + name + ".bmp");
            }
            else
            {
                bmp.Save(this.cfg.AppPath + "\\screenshot.bmp");
            }
            /*
            Bitmap bmp = new Bitmap(this.Size.Width, this.Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("bitmap.bmp"); */
        }
        public class _Config
        {
            private Core cr;
            private string connectionString = "";
            private string appPath = "";
            private string configPath = "";
            private string configIniPath = "";
            private string sourceConfig = "";
            private bool encryption = false;
            private bool fileEncrypted = false;
            private string maserLey = "";
            //
            //
            public _Config(Core Cr)
            {
                this.cr = Cr;
                setConfig();
            }
            //
            public string ConnectionString { get { return connectionString; } }
            public string AppPath { get { return appPath; } }
            public bool Encryption { get { return encryption; } }
            public string MasterKey { get { return maserLey; } }
            //
            private void setConfig()
            {
                appPath = Application.StartupPath;
                configPath = appPath+"\\user.config";
                configIniPath = appPath + "\\config.ini";
                //
                loadConfigIniDocument();
                //
                XmlDocument doc = loadConfigDocument();
                XmlNode node = doc.SelectSingleNode("//appSettings");
                if (node == null)
                    throw new InvalidOperationException("appSettings section not found in config file.");
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", "NameConnectionString"));
                NalogUser.App.Default.NameConnectionString = elem.GetAttribute("value");
                //
                elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", "MasterKey"));
                NalogUser.App.Default.MasterKey = elem.GetAttribute("value");
                //
                node = doc.SelectSingleNode("//connectionStrings");
                elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@name='{0}']", NalogUser.App.Default.NameConnectionString));
                NalogUser.Properties.Settings.Default.ConnectionString = elem.GetAttribute("connectionString");
                NalogUser.App.Default.ConnectionString = elem.GetAttribute("connectionString");
                
                //
            }
            private XmlDocument loadConfigDocument()
            {
                XmlDocument doc = null;
                sourceConfig = "";
                try
                {
                    BinaryReader binR = new BinaryReader(File.OpenRead(configPath));
                    foreach (char ch in binR.ReadChars((int)binR.BaseStream.Length))
                    {
                        sourceConfig += ch.ToString();
                    }
                    binR.Close();
                    if (fileEncrypted)
                    {
                        sourceConfig = cr.encrypt.Decryptor(sourceConfig);
                    }
                    TextReader tR = new StringReader(sourceConfig.Trim());
                    doc = new XmlDocument();
                    doc.Load(tR);
                    return doc;
                }
                catch (System.IO.FileNotFoundException e)
                {
                    throw new Exception("No configuration file found.", e);
                }
            }
            private string[] loadConfigIniDocument()
            {
                string[] ini = File.ReadAllLines(configIniPath);
                for (int i = 0; i < ini.Length; i++)
                {
                    string[] line = ini[i].Split('=');
                    if (line[0].Length > 0)
                    {
                        string iniParam = line[0];
                        string iniParamValue = line[1];
                        switch (iniParam)
                        {
                            case "Encryption":
                                {
                                    try
                                    {
                                        encryption = Convert.ToBoolean(Convert.ToInt16(line[1]));
                                    }
                                    catch (System.Exception ex)
                                    {
                                    }
                                    break;
                                }
                            case "FileEncrypted":
                                {
                                    try
                                    {
                                        fileEncrypted = Convert.ToBoolean(Convert.ToInt16(line[1]));
                                    }
                                    catch (System.Exception ex)
                                    {
                                    }
                                    break;
                                }
                        }
                    }
                }
                return ini;
            }
            public void saveConfig(string config = "")
            {
                string[] ini = loadConfigIniDocument();
                XmlDocument doc = null;
                sourceConfig = "";
                try
                {
                    BinaryReader binR = new BinaryReader(File.OpenRead(configPath));
                    foreach (char ch in binR.ReadChars((int)binR.BaseStream.Length))
                    {
                        sourceConfig += ch.ToString();
                    }
                    binR.Close();
                    if (fileEncrypted)
                    {
                        sourceConfig = cr.Encrypt.Decryptor(sourceConfig);
                        fileEncrypted = false;
                    }
                }
                catch (System.IO.FileNotFoundException e)
                {
                    throw new Exception("No configuration file found.", e);
                }
                StreamWriter sw = null;
                if (encryption && (!fileEncrypted || fileEncrypted))
                {
                    sourceConfig = cr.Encrypt.Encryptor(sourceConfig);
                    fileEncrypted = true;
                }
                sw = File.CreateText(configPath);
                sw.Write(sourceConfig);
                //
                sw.Close();

                for (int i = 0; i < ini.Length; i++)
                {
                    string[] line = ini[i].Split('=');
                    if (line[0].Length > 0)
                    {
                        switch (line[0])
                        {
                            case "Encryption":
                                {
                                    try
                                    {
                                        line[1] = Convert.ToInt16(encryption).ToString();
                                    }
                                    catch (System.Exception ex)
                                    {
                                    }
                                    break;
                                }
                            case "FileEncrypted":
                                {
                                    try
                                    {
                                        line[1] = Convert.ToInt16(fileEncrypted).ToString();
                                    }
                                    catch (System.Exception ex)
                                    {
                                    }
                                    break;
                                }
                        }
                    }
                    ini[i] = line[0] + "=" + line[1];
                }
                sw = File.CreateText(configIniPath);
                foreach (string str in ini)
                {
                    sw.WriteLine(str);
                }
                sw.Close();
            }
            
            public class ConnectionStrings
            {
                private string name = "";
                private string provider = "";
                private string path = "";
                private string ext = "";
                private string password = "";
                //
                public string Nmae { get { return name; } set { name = value; } }
                public string Provider { get { return provider; } set { provider = value; } }
                public string Path { get { return path; } set { path = value; } }
                public string Ext { get { return ext; } set { ext = value; } }
            }
        }
    }

}
