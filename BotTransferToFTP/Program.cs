using System;
using System.Net;
using System.Data;
using System.Xml;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BytesRoad.Diag;
using BytesRoad.Net.Ftp;
using BytesRoad.Net.Sockets;

namespace SynchronizationData1cAndSite
{
    
    class Program
    {
        public Program()
        {

        }
        static void Main(string[] args)
        {
            ProgrammWork pw = new ProgrammWork();
            pw.writeDebugLog("Main");
            pw.start();

            foreach (Response rsp in pw.Log)
            {
                Console.WriteLine(rsp.Address + " " + rsp.DataTime + "    " + rsp.Name + "\n    " + rsp.Address + "  " + rsp.Status + "  " + rsp.Error);
            }
            Console.WriteLine("Новые объекты:\n");
            foreach (FoldersFiles ffl in pw.LogAddFilesAndFolders)
            {
                string type = "";
                if (ffl.IsFolder)
                {
                    type = "Директория";
                }
                else
                {
                    type = "Файл";
                }
                Console.WriteLine(type + ": " + ffl.FtpFolderAndFile);
            }
            //System.Diagnostics.Process.Start("pause");
           // Console.ReadLine();
            //Environment.Exit(0);
        }
    }
    public class ProgrammWork
    {
        #region params
        #region XML
        /*
        * XML Parser options
        * */
        private DataSet dsXml;
        private XmlDocument xmlDoc;
        private string pathDirectoryApp = "";
        private string pathFileXml = "Parametres.xml";
        private string pathFileLog = "Log.txt";
        private string pathFileLogErrors = "LogErrors.txt";
        private string pathFileLogDebug = "LogDebug.txt";
        //
        private string xmlTableName = "TransferFolder";
        private string xmlTableNameLocalSettings = "LocalSettings";
        private string xmlTableNameTransferDataSettings = "TransferDataSettings";
        private string xmlTableNameSiteSettings = "SiteSettings";
        private string xmlTableNameProgramSettings = "ProgramSettings";
        //public
        public DataSet DsXml { get { return dsXml; } set { dsXml = value; } }
        public XmlDocument XmlDoc { get { return xmlDoc; } set { xmlDoc = value; } }
        public string PathDirectoryApp { get { return pathDirectoryApp; } set { pathDirectoryApp = value; } }
        public string XmlTableName { get { return xmlTableName; } set { xmlTableName = value; } }
        /*
         * ------------END--------------------
         * */
        #endregion XML
        /*
         * Logs
         * */
        private ArrayList log;
        private ArrayList logAddFilesAndFolders = new ArrayList();
        private ArrayList logDeleteFilesAndFolders = new ArrayList();
        private ArrayList logErrors = new ArrayList();
        private string error;
        //public
        public ArrayList Log { get { return log; } set { log = value; } }
        public ArrayList LogAddFilesAndFolders { get { return logAddFilesAndFolders; } set { logAddFilesAndFolders = value; } }
        public ArrayList LogDeleteFilesAndFolders { get { return logDeleteFilesAndFolders; } set { logDeleteFilesAndFolders = value; } }
        public ArrayList LogErrors { get { return logErrors; } set { logErrors = value; } }
        /*
         * ------------END--------------------
         * */
        /*
         * Arr for Main
         * */
        private string[] arrMain;
        //public
        public string[] ArrMain { get { return arrMain; } set { arrMain = value; } }
        /*
         * ------------END--------------------
         * */
        private string newPage;
        /*
         * Folder and Files Librarry
         * */
        private FoldersFiles fFiles;
        private ArrayList arrFiles = new ArrayList();
        private ArrayList arrFolders = new ArrayList();
        private ArrayList arrLocalFiles = new ArrayList();
        //public
        public ArrayList ArrFiles { get { return arrFiles; } }
        public ArrayList ArrFolders { get { return arrFolders; } }
        public ArrayList ArrLocalFiles { get { return arrLocalFiles; } }
        /*
         * ------------END--------------------
         * */
        /*
         * Read / Write streams
         * */
        private Stream queryStream;
        private Stream sStream;
        private StreamReader reader;
        private StreamWriter writer;
        //public
        public Stream QueryStream { get { return queryStream; } set { queryStream = value; } }
        public Stream SStream { get { return sStream; } set { sStream = value; } }
        public StreamReader Reader { get { return reader; } set { reader = value; } }
        public StreamWriter Writer { get { return writer; } set { writer = value; } }
        /*
         * ------------END--------------------
         * */
        /*
         * Work with FTP and Local
         * */
        private TransferFolder trFolder;
        private UploadFTP upFTP;
        private UploadLocal upLocal;
        //
        public TransferFolder TrFolder { get { return trFolder; } set { trFolder = value; } }
        public UploadFTP UpFtp { get { return upFTP; } set { upFTP = value; } }
        public UploadLocal UpLocal { get { return upLocal; } set { upLocal = value; } }
        /*
         * ------------END--------------------
         * */
        /*
         * Program Settings
         * */
        private ProgramSettings prSettings;
        //
        public ProgramSettings PrSettings { get { return prSettings; } set { prSettings = value; } }
        /*
         * ------------END--------------------
         * */
        /*
         * HTTP options
         * */
        private HttpWebRequest httpWebRequest;
        private CookieContainer cooks;
        private HttpWebResponse httpWebResponse;
        private string statusResponse;
        //public
        public HttpWebRequest HttpWebRequest { get { return httpWebRequest; } set { httpWebRequest = value; } }
        public CookieContainer Cooks { get { return cooks; } set { cooks = value; } }
        public HttpWebResponse HttpWebResponse { get { return httpWebResponse; } set { httpWebResponse = value; } }

        /*
         * ------------END--------------------
         * */
        #endregion params
        public ProgrammWork()
        {
            //
            PathDirectoryApp = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //
            dsXml = new DataSet();
            dsXml.ReadXml(pathDirectoryApp + "\\" + pathFileXml);
            //
            prSettings = new ProgramSettings();
            for (int i = 0; i < dsXml.Tables[xmlTableName].Rows.Count; i++)
            {
                prSettings.OnLog.value = setXmlValue(xmlTableNameProgramSettings, i, prSettings.OnLog.xml);
                prSettings.OnLogDebug.value = setXmlValue(xmlTableNameProgramSettings, i, prSettings.OnLogDebug.xml);
                prSettings.OnLogErrors.value = setXmlValue(xmlTableNameProgramSettings, i, prSettings.OnLogErrors.xml);
            }
            //
        }
        public void start()
        {


            writeDebugLog("start()");
            
            readXmlOptions();
            Log = new ArrayList();
            //
            transferData();
        }
        private void readXmlOptions()
        {
			/*
			*	Чтение файла конфигурации
			*/
            writeDebugLog("readXmlOptions() - Чтение файла конфигурации");

        }
        private void writeLogsFile()
        {
            if (prSettings.OnLog.value != "1") return;
            if (!(File.Exists(pathDirectoryApp + "\\" + pathFileLog))) { Stream crFile = File.Create(pathDirectoryApp + "\\" + pathFileLog); crFile.Close(); }
            /*
             * Write log file
             * */
            DateTime date = DateTime.Now;
            writer = File.AppendText(pathDirectoryApp + "\\" + pathFileLog);
            writer.WriteLine(date.ToString()+"********************************");
            for (int i = 0; i < Log.Count; i++)
            {
                Response response = (Response)Log[i];
                writer.WriteLine(response.Address + "   "  + response.Name + "   " + response.DataTime + "   " + response.Status);
            }
            writer.WriteLine("***********Созданные файлы и папки**************");
            foreach (FoldersFiles ffl in logAddFilesAndFolders)
            {
                if(ffl.FtpStatusFolderAndFile=="new")
                {
                    string type = "";
                    if (ffl.IsFolder)
                    {
                        type = "Директория";
                    }
                    else
                    {
                        type = "Файл";
                    }
                    writer.WriteLine(type + ": " + ffl.FtpFolderAndFile);
                }
            }
            writer.WriteLine("*************************************************");
            if (logDeleteFilesAndFolders.Count > 0)
            {
                writer.WriteLine("***********Удалённые файлы и папки**************");

                foreach (string file in logDeleteFilesAndFolders)
                {
                    writer.WriteLine("Удалёно с сервера ФТП " + ": " + file);
                }
            }

            writer.Close();
            writer = File.AppendText(pathDirectoryApp + "\\" + pathFileLogErrors);
            for (int i = 0; i < LogErrors.Count; i++)
            {
                Response response = (Response)LogErrors[i];
                writer.WriteLine(response.Error);
            }
            writer.WriteLine("**************************************************");
            writer.Close();
            /*
             * ------------END--------------------
             * */
        }
        public void writeErrorLog(string str)
        {
            if (prSettings.OnLogErrors.value != "1") return;
            if (!(File.Exists(pathDirectoryApp + "\\" + pathFileLogErrors))) { Stream crFile = File.Create(pathDirectoryApp + "\\" + pathFileLogErrors); crFile.Close(); }
            writer = File.AppendText(pathDirectoryApp + "\\" + pathFileLogErrors);
            writer.WriteLine(str);
            writer.WriteLine("**************************************************");
            writer.Close();
        }
        public void writeDebugLog(string str)
        {
            if (prSettings.OnLogDebug.value != "1") return;
            if (!(File.Exists(pathDirectoryApp + "\\" + pathFileLogDebug))) { Stream crFile = File.Create(pathDirectoryApp + "\\" + pathFileLogDebug); crFile.Close(); }
            writer = File.AppendText(pathDirectoryApp + "\\" + pathFileLogDebug);
            writer.WriteLine(str);
            writer.WriteLine("**************************************************");
            writer.Close();
        }
        public void writeConsoleMessage(string str)
        {
            Console.WriteLine(str);
        }
        private string setXmlValue(string tableName, int i, string nameCol)
        {
            string value = "";
            int chekColumn=0;
            foreach(DataColumn column in dsXml.Tables[tableName].Columns)
            {
                if (column.ColumnName == nameCol) chekColumn++;
            }
            if (chekColumn < 1)
            {
                value = "";
            }
            else
            {
                value = dsXml.Tables[tableName].Rows[i][nameCol].ToString();
            }
            
            return value;
        }
        private void transferData()
        {
			/*
			*	Главная исполняющая процедура, где отбираются параметры из конфига и выполняется запуск вспомагательных процедур
			*/
            writeDebugLog("transferData() - Главная исполняющая процедура, где отбираются параметры из конфига и выполняется запуск вспомагательных процедур");
            for (int i = 0; i < dsXml.Tables[xmlTableName].Rows.Count; i++)
            {
                writeConsoleMessage("Этап 1 из 5. Читаем конфиг");
                #region Читаем конфиг
                /* Читаем Конфиг
                 * */
                trFolder = new TransferFolder();
                
                trFolder.IsLocalShare.value = setXmlValue(xmlTableNameLocalSettings, i, trFolder.IsLocalShare.xml);
                trFolder.LocalAddressExport.value = setXmlValue(xmlTableNameLocalSettings, i, trFolder.LocalAddressExport.xml);
                trFolder.LocalAddressImport.value = setXmlValue(xmlTableNameLocalSettings, i, trFolder.LocalAddressImport.xml);
                trFolder.LocalLogin.value = setXmlValue(xmlTableNameLocalSettings, i, trFolder.LocalLogin.xml);
                trFolder.LocalPassword.value = setXmlValue(xmlTableNameLocalSettings, i, trFolder.LocalPassword.xml);
                trFolder.FtpEnable.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpEnable.xml);
                trFolder.FtpTransferFiles.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpTransferFiles.xml);
                trFolder.FtpAddress.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpAddress.xml);
                trFolder.FtpLogin.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpLogin.xml);
                trFolder.FtpPassword.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpPassword.xml);
                trFolder.FtpRootFolder.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpRootFolder.xml);
                trFolder.LocalRootFolder.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.LocalRootFolder.xml);
                trFolder.FtpPathExtFiles.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpPathExtFiles.xml);
                trFolder.FtpAllTypeAllow.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpAllTypeAllow.xml);
                try
                {
                    trFolder.FtpPort.value = Convert.ToInt32(setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpPort.xml));
                }
                catch (System.Exception err)
                {
                    writeErrorLog(err.Message.ToString());
                }
                trFolder.CleanDestionation.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.CleanDestionation.xml);
                trFolder.FtpTimeout.value = setXmlValue(xmlTableNameTransferDataSettings, i, trFolder.FtpTimeout.xml);
                //trFolder.FtpTypeDocuments = dsXml.Tables[xmlTableNameTransferDataSettings].Rows[i][trFolder.FtpTypeDocuments.xml].ToString();
                //SiteSettings
                trFolder.SiteImageFormatWidth.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteImageFormatWidth.xml);
                trFolder.SiteImageFormatHeight.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteImageFormatHeight.xml);
                trFolder.SiteEncoding.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteEncoding.xml);
                trFolder.SiteContentype.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteContentype.xml);
                trFolder.SiteTypeQuery.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteTypeQuery.xml);
                trFolder.SiteAuthorization.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteAuthorization.xml);
                trFolder.SiteLogin.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteLogin.xml);
                trFolder.SitePassword.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SitePassword.xml);
                trFolder.SiteName.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteName.xml);
                trFolder.SiteEnable.value = setXmlValue(xmlTableNameSiteSettings, i, trFolder.SiteEnable.xml);
                int siteEnable = Convert.ToInt32(trFolder.SiteEnable.value);
                for (int j = 0; j < dsXml.Tables[trFolder.SitePages.xml].Rows.Count; j++)
                {
                    try
                    {
                        trFolder.SitePage = new TransferFolder._sitePage();
                        trFolder.SitePage.link = setXmlValue(trFolder.SitePages.xml, j, trFolder.SitePage.xml);
                        trFolder.SitePage.typeWebPage = setXmlValue(trFolder.SitePages.xml, j, trFolder.SiteTypeWebPage.xml);
                        trFolder.SiteTimeout.value = setXmlValue(trFolder.SitePages.xml, j, trFolder.SiteTimeout.xml);
                        trFolder.SitePage.writingFile = setXmlValue(trFolder.SitePages.xml, j, trFolder.SiteWritingFile.xml);
                        trFolder.SitePages.Page.Add(trFolder.SitePage);
                    }
                    catch (System.Exception err)
                    {
                        writeErrorLog(err.Message.ToString());
                    }
                    finally
                    {
                        //trFolder.SitePages.Page.Add(trFolder.SitePage);
                    }
                    
                    if (trFolder.SitePage.typeWebPage == "Read" && siteEnable == 1)
                    {
                        startSiteFunction(trFolder, true, trFolder.SitePage);
                    }
                }
                //
                #endregion Читаем конфиг
                //Нужно взять таблицу со страницами из текущей строки данных в корневой таблице.
                //
                writeConsoleMessage("Этап 2 из 5. Читаем файлы на ПК");
                getFoldersAndFilestoTransfer(trFolder.LocalAddressExport.value, true);
                getFoldersAndFilestoTransfer(trFolder.LocalRootFolder.value, false);
                //
                if (trFolder.FtpEnable.value == "1")
                {
                    upFTP = new UploadFTP(this);
                    upFTP.go();
                }
                else
                {                 
                    upLocal = new UploadLocal(this);
                    upLocal.go();
                }
                //
                writeConsoleMessage("Этап 4 из 5. Загружаем информацию о товарах на сайт");
                if (siteEnable == 1)
                {
                    startSiteFunction(trFolder);
                }
            }
            /*
             * Write Log file
             * */
            writeLogsFile();
            /*
            * ------------END--------------------
            * */
            writeConsoleMessage("Этап 5 из 5. Пишим логи");
            writeConsoleMessage("***********Обмен завершен*************");

        }
        private void getFoldersAndFilestoTransfer(string localFolder, bool isImportFiles)
        {
			/*
			*	Выбирает файлы и папки из категории конфига
			*/
            //arrFolders.Clear();
            //arrFiles.Clear();
            //arrLocalFiles.Clear();
            if (localFolder.Length < 1) return;
            GetListFoldersAndFiles(localFolder, isImportFiles);
        }
        private void GetListFoldersAndFiles(string path, bool isImportFiles)
        {
			/*
			*	Выбирает все категории в подкатегориях
			*/
            DirectoryInfo di = new DirectoryInfo(path);
            ScanDirectoriesFiles(di, path, isImportFiles);
        }
        private void ScanDirectoriesFiles(DirectoryInfo di, string path, bool isImportFiles)
        {
			/*
			*	Добавляет категории и файлы в коллекции данных
			*/
            #region scan_folder
            fFiles = new FoldersFiles();
            fFiles.IsFolder = true;
            fFiles.NameFolder = di.Name;
            fFiles.FullPathFolder = di.FullName.Substring(path.Length, di.FullName.Length - path.Length);
            #region scan_files
            foreach (FileInfo fi in di.GetFiles())
            {
                fFiles = new FoldersFiles();
                fFiles.IsFolder = false;
                fFiles.NameFile = fi.Name;
                fFiles.FullPathFile = fi.FullName;
                fFiles.FullPathFolder = di.FullName.Substring(path.Length, di.FullName.Length - path.Length);
                fFiles.NameFolder = di.Name;
                fFiles.FileExtention = fi.Extension.ToString();
                if (isImportFiles)
                {
                    arrFiles.Add(fFiles);
                }
                else
                {
                    arrLocalFiles.Add(fFiles);
                }
            }
            #endregion scan_files
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                ScanDirectoriesFiles(dir, path ,isImportFiles);
            }
            #endregion scan_folder
        }
        private void startSiteFunction(TransferFolder obj, bool read = false, TransferFolder._sitePage CurrentPage = null)
        {
            /*
             * Create request
             * */
            if (read)
            {
                http(obj, CurrentPage);
                if (File.Exists(trFolder.LocalAddressImport + "\\" + CurrentPage.writingFile))
                {
                }
                else
                {
                    writer = new StreamWriter(trFolder.LocalAddressImport.value + "\\" + CurrentPage.writingFile);
                    writer.Write(CurrentPage.writingContent);
                    writer.Close();
                }
            }
            else
            {
                foreach (TransferFolder._sitePage page in obj.SitePages.Page)
                {
                    http(obj, page);
                }
            }
            /*
            * Write arr for Main
            * */
            arrMain = new string[log.Count];
            for (int j = 0; j < log.Count; j++)
            {
                arrMain[j] = log[j].ToString();

            }
            /*
             * ------------END--------------------
             * */
        }
        private void http(TransferFolder obj, TransferFolder._sitePage page)
        {
            if (page.link == "") return;

            bool findSymbl = false;
            for (int j = 0; j < page.link.Length; j++)
            {
                if (page.link[j] == '+')
                {
                    findSymbl = true;
                    break;
                }
            }
            if (findSymbl)
            {
                newPage = page.link.Replace("+", "&");
            }
            else
            {
                newPage = page.link;
            }
            //newPage = page;
            httpWebRequest = (HttpWebRequest)WebRequest.Create(newPage);

            Cooks = new CookieContainer();
            httpWebRequest.AllowAutoRedirect = true;
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.ContentType = obj.SiteContentype.value;
            httpWebRequest.Method = obj.SiteTypeQuery.value;
            //

            if (trFolder.SiteTypeQuery.value == "GET")
            {
                httpWebRequest.KeepAlive = true;
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:13.0) Gecko/20100101 Firefox/13.0.1";
                httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                httpWebRequest.UseDefaultCredentials = false;
                httpWebRequest.PreAuthenticate = true;
                httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                byte[] authBytes = Encoding.UTF8.GetBytes((trFolder.SiteLogin.value + ":" + trFolder.SitePassword.value).ToCharArray());
                httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(authBytes);
                httpWebRequest.Credentials = new NetworkCredential(trFolder.SiteLogin.value, trFolder.SitePassword.value);
                httpWebRequest.Timeout = Convert.ToInt32(trFolder.SiteTimeout.value);

                bool getResponse = false;
                try
                {
                    httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    getResponse = true;
                }
                catch (System.Exception err)
                {
                    error = err.ToString();
                    writeErrorLog(err.Message.ToString());
                }
                if (httpWebResponse != null & getResponse)
                {
                    statusResponse = httpWebResponse.StatusCode.ToString();
                }
                else
                {
                    statusResponse = "UNKNOW";
                }
                if (page.typeWebPage == "Read")
                {
                    Stream receiveStream = httpWebResponse.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    page.writingContent = readStream.ReadToEnd().ToString();
                    readStream.Close();
                }
                httpWebResponse.Close();
                DateTime date = DateTime.Now;
                /*
                 * Write response
                 * */
                Response response = new Response();
                response.Name = trFolder.SiteName.value;
                response.Address = newPage;
                response.Status = statusResponse;
                response.DataTime = date.ToString();
                response.Error = error;
                log.Add(response);
            }
            //
        }
        public bool IsImage(string ext)
        {
            bool ok = false;
            if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png")
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            //pw.writeDebugLog("Файл является картинкой - " + ok);
            return ok;
        }
        public bool IsXml(string ext)
        {
            bool ok = false;
            if (ext == ".xml")
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            //pw.writeDebugLog("Файл является xml - " + ok);
            return ok;
        }
    }
    public class UploadFTP
    {
        #region Params
        private ProgrammWork pw;
        private FtpClient client;
        private int TimeoutFTP = 10000;
        private string FTP_SERVER = "";
        private int FTP_PORT = 21;
        private string FTP_USER = "";
        private string FTP_PASSWORD = "";
        //
        private FtpItem[] itemsFiles;
        #endregion Params
        public UploadFTP(ProgrammWork Pw)
        {
            this.pw = Pw;
            client = new FtpClient();
            //
            client.PassiveMode = true;
            FTP_SERVER = pw.TrFolder.FtpAddress.value;
            FTP_PORT = pw.TrFolder.FtpPort.value;
            FTP_USER = pw.TrFolder.FtpLogin.value;
            FTP_PASSWORD = pw.TrFolder.FtpPassword.value;
            try
            {
                TimeoutFTP = Convert.ToInt32(pw.TrFolder.FtpTimeout.value);
            }
            catch (System.Exception err)
            {
                TimeoutFTP = 3000;
                pw.writeErrorLog(err.Message.ToString());
            }
        }
        public void go()
        {

            client.Connect(TimeoutFTP, FTP_SERVER, FTP_PORT);

            client.Login(TimeoutFTP, FTP_USER, FTP_PASSWORD);

            if (client.IsConnected)
            {
                pw.writeDebugLog("\nВходим на ФТП");
                #region подключены к ФТП
                string folderNow = pw.TrFolder.FtpRootFolder.value;// +folderCut;
                string changeDir = folderNow.Substring(0, folderNow.Length/* - folderCut.Length*/);

                pw.writeDebugLog("Вошли на ФТП, считываем файлы");
                List<FoldersFiles> lstFolderFiles = new List<FoldersFiles>();
                FtpItem[] items = client.GetDirectoryList(TimeoutFTP, folderNow);
                
                pw.writeDebugLog("Считали файлы, проверяем");
                try
                {
                    //pw.writeDebugLog("Проверяем папку files на наличии и считываем её");
                    itemsFiles = client.GetDirectoryList(TimeoutFTP, folderNow + pw.TrFolder.FtpPathExtFiles.value);
                }
                catch (System.Exception err)
                {
                    pw.writeDebugLog(err.Message.ToString());
                }
                int countFiles = 0;
                try
                {
                    countFiles = itemsFiles.Length;
                }
                catch (System.Exception err)
                {
                    countFiles = 0;
                    pw.writeErrorLog(err.Message);
                }
                
                pw.writeDebugLog("Найдено фалов на ФТП - " + items.Length);
                pw.writeDebugLog("Найдено фалов на ПК - " + pw.ArrFiles.Count);
                pw.writeDebugLog("Начинаем проверку файлов");
                int countI = 0;
                int countMessageNewFiles = 0;
                pw.writeConsoleMessage("Этап 3 из 5. Синхронизируем файлы и папки ФТП и ПК, всего файлов для проверки - " + items.Length);
                foreach (FoldersFiles fl in pw.ArrFiles)
                {
                    countI++;
                    //pw.writeDebugLog("Файл №" + countI + " из " + pw.ArrFiles.Count + " - " + fl.NameFile + " Проверяется");
                    int checkFiles = 0;
                    bool isFound = false;
                    #region files
                    if ((!pw.IsImage(fl.FileExtention) || !pw.IsXml(fl.FileExtention)) && countFiles > 0 && pw.TrFolder.FtpTransferFiles.value == "1")
                    {
                        //pw.writeDebugLog("Проверяем документы типа Doc, Pdf и тд. на ФТП");
                        foreach (FtpItem item in itemsFiles)
                        {
                            //pw.writeDebugLog("Об какой файл я спотыкаюсь на ФТП - " + item.Name);
                            if (item.ItemType == FtpItemType.File && item.Name == fl.NameFile)
                            {
                                checkFiles++;
                                isFound = true;
                            }

                        }
                    }
                    #endregion files
                    #region images
                    else if (((pw.IsImage(fl.FileExtention) && pw.TrFolder.FtpTransferFiles.value == "1") || pw.IsXml(fl.FileExtention)) && items.Length > 0)
                    {
                        //pw.writeDebugLog("Проверяем картинки на ФТП");
                        foreach (FtpItem item in items)
                        {
                            if (item.ItemType == FtpItemType.File &&  item.Name == fl.NameFile)
                            {
                                checkFiles++;
                                isFound = true;
                            }

                        }
                    }
                    else
                    {
                        checkFiles++;
                        isFound = false;
                    }
                    #endregion images
                    if (countMessageNewFiles < 1)
                    {
                        pw.writeConsoleMessage("Этап 3.1 из 5. Загружаем новые файлы");
                    }
                    countMessageNewFiles++;
                    #region Добавляем файлы
                    if (!isFound)
                    {
                        try
                        {
                            if ((pw.IsImage(fl.FileExtention) && pw.TrFolder.FtpTransferFiles.value == "1") || pw.IsXml(fl.FileExtention))
                            {
                                client.PutFile(TimeoutFTP, folderNow + "/" + fl.NameFile, fl.FullPathFile);
                                fl.FtpFolderAndFile = folderNow + "/" + fl.NameFile;
                            }
                            else
                            {
                                if (pw.TrFolder.FtpTransferFiles.value == "1")
                                {
                                    client.PutFile(TimeoutFTP, folderNow + pw.TrFolder.FtpPathExtFiles.value + fl.NameFile, fl.FullPathFile);
                                    fl.FtpFolderAndFile = folderNow + pw.TrFolder.FtpPathExtFiles.value + fl.NameFile;
                                }
                            }
                            fl.FtpStatusFolderAndFile = "new";
                            pw.LogAddFilesAndFolders.Add(fl);
                        }
                        catch (System.Exception err)
                        {
                            pw.writeErrorLog(err.Message.ToString());
                            Response rsp = new Response();
                            rsp.Error = err.ToString();
                            pw.LogErrors.Add(rsp);
                        }
                    }
                    #endregion Добавляем файлы
                    //pw.writeDebugLog("Файл №" + countI + " проверен");
                }
                pw.writeDebugLog("Переходим к удалению несуществующих файлов");
                pw.writeConsoleMessage("Этап 3.2 из 5. Удаляем несуществующие файлы");
                bool isConnected = false;
                try
                {
                    items = client.GetDirectoryList(TimeoutFTP, folderNow);
                    isConnected = true;
                }
                catch (System.Exception err)
                {
                    pw.writeErrorLog(err.Message.ToString());
                    isConnected = false;
                }
                try
                {
                    itemsFiles = client.GetDirectoryList(TimeoutFTP, folderNow + "/files");
                }
                catch (System.Exception err)
                {
                    pw.writeErrorLog(err.Message.ToString());
                }
                //
                checkOldFilesOnFtp(items, itemsFiles, folderNow);
                //Проверяем файлы которых нет в папке 1с и которые остались на ФТП

                //}

                if(isConnected) client.Disconnect(TimeoutFTP);
                #endregion Подключены к ФТП
            }

        }
        private string extractFileExtention(string name)
        {
            string ext = "";

            return ext;
        }
        private void checkOldFilesOnFtp(FtpItem[] items, FtpItem[] itemsFiles, string path)
        {
            /*
             * Проверяем картинки
             * */
            pw.writeDebugLog("Удаляем несуществующие файлы с ФТП");
            int checkCount = 0;
            string[] split = new string[2];
            int countD = 0;
            if (items.Length > 0)
            {
                foreach (FtpItem item in items)
                {
                    split = returnExtentionFTPFile(item);
                    split[1] = "." + split[1];
                    int typeFile = -1; //0 - image, 1- file
                    foreach (FoldersFiles fl in pw.ArrFiles)
                    {
                        if (item.ItemType == FtpItemType.File && pw.IsImage(split[1]) &&
                            pw.IsImage(fl.FileExtention) && fl.NameFile == item.Name)
                        {
                            checkCount++;
                            typeFile = 0;
                        }
                        else if (item.ItemType == FtpItemType.File && !pw.IsImage(split[1]) &&
                            !pw.IsImage(fl.FileExtention) && !pw.IsXml(fl.FileExtention) && fl.NameFile == item.Name)
                        {
                            /*
                             * Проверяем файлы
                             * */
                            typeFile = 1;
                            checkCount++;
                        }
                        else
                        {
                            typeFile = -1;
                        }
                    }
                    if (checkCount < 1 && pw.TrFolder.CleanDestionation.value == "1")
                    {
                        if (typeFile == 0)
                        {
                            deleteFileFtp(item.Name, path + "/");
                            deleteFileFtp(split[0] + "_" + pw.TrFolder.SiteImageFormatWidth + "x" + pw.TrFolder.SiteImageFormatHeight + split[1], path + "/resized/");
                        }
                        else if (typeFile == 1)
                        {
                            deleteFileFtp(item.Name, path + pw.TrFolder.FtpPathExtFiles);
                        }
                        else { typeFile = -1; }
                        countD++;
                    }
                }
            }
            pw.writeDebugLog("Удалено файлов с ФТП - " + countD);
        }
        private void deleteFileFtp(string name, string path)
        {
            try
            {
                client.DeleteFile(TimeoutFTP, path + name);
                pw.LogDeleteFilesAndFolders.Add(name);
            }
            catch (System.Exception err)
            {
                pw.writeErrorLog(err.Message.ToString());
            }

        }
        private string[] returnExtentionFTPFile(FtpItem item)
        {
            string[] split = new string[2];
            if (item.ItemType == FtpItemType.File)
            {
                split = item.Name.Split('.');
            }
            return split;
        }
    }
    public class UploadLocal
    {
        private ProgrammWork pw;
        public UploadLocal(ProgrammWork Pw)
        {
            this.pw = Pw;
        }
        public void go()
        {
            pw.writeDebugLog("\nЗаходим на локальный диск");
            #region подключены к локальному диску
            int countI = 0;
            int countMessageNewFiles = 0;
            string folderNow = pw.TrFolder.LocalRootFolder.value;

            string pathDir = folderNow + "\\files\\";
            if (!Directory.Exists(pathDir)) Directory.CreateDirectory(pathDir);

            pathDir = folderNow + "\\resized\\";
            if (!Directory.Exists(pathDir)) Directory.CreateDirectory(pathDir);

            foreach (FoldersFiles fl in pw.ArrFiles)
            {
                countI++;
                int checkFiles = 0;
                #region files
                if ((!pw.IsImage(fl.FileExtention) || !pw.IsXml(fl.FileExtention)) && pw.ArrFiles.Count > 0)
                {
                    //pw.writeDebugLog("Проверяем документы типа Doc, Pdf и тд. на ФТП");
                    foreach (FoldersFiles item in pw.ArrLocalFiles)
                    {
                        //pw.writeDebugLog("Об какой файл я спотыкаюсь на ФТП - " + item.Name);
                        if (item.NameFile == fl.NameFile)
                        {
                            checkFiles++;
                        }

                    }
                }
                #endregion files
                #region images and xml
                else if (pw.IsImage(fl.FileExtention) && pw.ArrFiles.Count > 0)
                {
                    //pw.writeDebugLog("Проверяем картинки на ФТП");
                    foreach (FoldersFiles item in pw.ArrLocalFiles)
                    {
                        if (item.NameFile == fl.NameFile)
                        {
                            checkFiles++;
                        }

                    }
                }
                else if (pw.IsXml(fl.FileExtention))
                {
                    checkFiles = 0;
                }
                else
                {
                    checkFiles = 0;
                    //checkFiles++;
                }
                #endregion images and xml
                if (countMessageNewFiles < 1)
                {
                    pw.writeConsoleMessage("Этап 3.1 из 5. Загружаем новые файлы");
                }
                countMessageNewFiles++;
                #region Добавляем файлы
                if (checkFiles < 1)
                {
                    try
                    {
                        if (pw.IsImage(fl.FileExtention) || pw.IsXml(fl.FileExtention))
                        {
                            File.Copy(fl.FullPathFile, folderNow + "\\" + fl.NameFile);
                        }
                        else
                        {
                            File.Copy(fl.FullPathFile, folderNow + "\\files\\" + fl.NameFile);
                        }
                        fl.FtpFolderAndFile = folderNow + "\\" + fl.NameFile;
                        fl.FtpStatusFolderAndFile = "new";
                        pw.LogAddFilesAndFolders.Add(fl);
                    }
                    catch (System.Exception err)
                    {
                        pw.writeErrorLog(err.Message.ToString());
                        Response rsp = new Response();
                        rsp.Error = err.ToString();
                        pw.LogErrors.Add(rsp);
                    }
                }
                #endregion Добавляем файлы
                //pw.writeDebugLog("Файл №" + countI + " проверен");
            }
            checkOldFilesOnLocal();
            #endregion Подключены к локальному диску
        }
        private void checkOldFilesOnLocal()
        {
            /*
             * Проверяем картинки
             * */
            pw.writeDebugLog("Удаляем несуществующие файлы в корневой папке сайта");
            int checkCount = 0;
            int countD = 0;
            if (pw.ArrLocalFiles.Count > 0)
            {
                foreach (FoldersFiles item in pw.ArrLocalFiles)
                {
                    foreach (FoldersFiles fl in pw.ArrFiles)
                    {
                        if (item.NameFile == fl.NameFile)
                        {
                            checkCount++;
                        }
                    }
                    if (checkCount < 1)
                    {
                        deleteFileLocal(item.FullPathFile);
                        //deleteFileLocal(split[0] + "_" + pw.TrFolder.SiteImageFormatWidth + "x" + pw.TrFolder.SiteImageFormatHeight + split[1], path + "/resized/");
                        countD++;
                    }
                }

            }
            pw.writeDebugLog("Удалено файлов из корневой папки сайта - " + countD);
        }
        private void deleteFileLocal(string FullPathFile)
        {
            try
            {
                if (File.Exists(FullPathFile))
                {
                    File.Delete(FullPathFile);
                    pw.LogDeleteFilesAndFolders.Add(FullPathFile);
                }
            }
            catch (System.Exception err)
            {
                pw.writeErrorLog(err.Message.ToString());
            }

        }
    }
    public class TransferFolder
    {
		/*
		*	Класс описывающий параметры конфига
		*/
        public TransferFolder()
        {
            //local
            isLocalShare = new _isLocalShare();
            localAddressImport = new _localAddressImport();
            localAddressExport = new _localAddressExport();
            localLogin = new _localLogin();
            localPassword = new _localPassword();
            localRootFolder = new _localRootFolder();
            //ftp
            ftpEnable = new _ftpEnable();
            ftpTransferFiles = new _ftpTransferFiles();
            ftpAddress = new _ftpAddress();
            ftpLogin = new _ftpLogin();
            ftpPassword = new _ftpPassword();
            ftpPort = new _ftpPort();
            ftpRootFolder = new _ftpRootFolder();
            ftpFolderAndFile = new _ftpFolderAndFile();
            ftpTimeout = new _ftpTimeout();
            ftpTypeDocuments = new _ftpTypeDocuments();
            ftpAllTypeAllow = new _ftpAllTypeAllow();
            ftpPathExtFiles = new _ftpPathExtFiles();
            cleanDestionation = new _cleanDestionation();
            //site
            siteEnable = new _siteEnable(); 
            siteName = new _siteName();
            siteLogin = new _siteLogin();
            siteImageFormatWidth = new _siteImageFormatWidth();
            siteImageFormatHeight = new _siteImageFormatHeight();
            sitePassword = new _sitePassword();
            siteEncoding = new _siteEncoding();
            siteContentType = new _siteContentType();
            siteTypeQuery = new _siteTypeQuery();
            siteAuthorization = new _siteAuthorization();
            sitePage = new _sitePage();
            sitePages = new _sitePages();
            siteTypeWebPage = new _siteTypeWebPage();
            siteWritingFile = new _siteWritingFile();
            siteTimeout = new _siteTimeout();
        }
        //Local
        private _isLocalShare isLocalShare;
        private _localAddressImport localAddressImport;
        private _localAddressExport localAddressExport;
        private _localLogin localLogin;
        private _localPassword localPassword;
        private _localRootFolder localRootFolder;
        //FTP
        private _ftpEnable ftpEnable;
        private _ftpTransferFiles ftpTransferFiles;
        private _ftpAddress ftpAddress;
        private _ftpLogin ftpLogin;
        private _ftpPassword ftpPassword;
        private _ftpPort ftpPort;
        private _ftpRootFolder ftpRootFolder;
        private _ftpFolderAndFile ftpFolderAndFile;
        private _ftpTimeout ftpTimeout;
        private _ftpTypeDocuments ftpTypeDocuments;
        private _ftpAllTypeAllow ftpAllTypeAllow;
        private _ftpPathExtFiles ftpPathExtFiles;
        private _cleanDestionation cleanDestionation;

        //Site
        private _siteEnable siteEnable;
        private _siteName siteName;
        private _siteLogin siteLogin;
        private _sitePassword sitePassword;
        private _siteImageFormatWidth siteImageFormatWidth;
        private _siteImageFormatHeight siteImageFormatHeight;
        private _siteEncoding siteEncoding;
        private _siteContentType siteContentType;
        private _siteTypeQuery siteTypeQuery;
        private _siteAuthorization siteAuthorization;
        private _sitePages sitePages;
        private _sitePage sitePage;
        private _siteTypeWebPage siteTypeWebPage;
        private _siteWritingFile siteWritingFile;
        private _siteTimeout siteTimeout;

        private List<string> listOptionNotFill = new List<string>();

        //local
        public _isLocalShare IsLocalShare { get { return isLocalShare; } set { isLocalShare = value; } }
        public _localAddressImport LocalAddressImport { get { return localAddressImport; } set { localAddressImport = value; } }
        public _localAddressExport LocalAddressExport { get { return localAddressExport; } set { localAddressExport = value; } }
        public _localLogin LocalLogin { get { return localLogin; } set { localLogin = value; } }
        public _localPassword LocalPassword { get { return localPassword; } set { localPassword = value; } }
        public _localRootFolder LocalRootFolder { get { return localRootFolder; } set { localRootFolder = value; } }
        //ftp
        public _ftpEnable FtpEnable { get { return ftpEnable; } set { ftpEnable = value; } }
        public _ftpTransferFiles FtpTransferFiles { get { return ftpTransferFiles; } set { ftpTransferFiles = value; } }
        public _ftpAddress FtpAddress { get { return ftpAddress; } set { ftpAddress = value; } }
        public _ftpLogin FtpLogin { get { return ftpLogin; } set { ftpLogin = value; } }
        public _ftpPassword FtpPassword { get { return ftpPassword; } set { ftpPassword = value; } }
        public _ftpPort FtpPort { get { return ftpPort; } set { ftpPort = value; } }
        public _ftpRootFolder FtpRootFolder { get { return ftpRootFolder; } set { ftpRootFolder = value; } }
        public _ftpFolderAndFile FtpFolderAndFile { get { return ftpFolderAndFile; } set { ftpFolderAndFile = value; } }
        public _ftpTimeout FtpTimeout { get { return ftpTimeout; } set { ftpTimeout = value; } }
        public _ftpTypeDocuments FtpTypeDocuments { get { return ftpTypeDocuments; } set { ftpTypeDocuments = value; } }
        public _ftpAllTypeAllow FtpAllTypeAllow { get { return ftpAllTypeAllow; } set { ftpAllTypeAllow = value; } }
        public _ftpPathExtFiles FtpPathExtFiles { get { return ftpPathExtFiles; } set { ftpPathExtFiles = value; } }
        public _cleanDestionation CleanDestionation { get { return cleanDestionation; } set { cleanDestionation = value; } }
        //site
        public _siteEnable SiteEnable { get { return siteEnable; } set { siteEnable = value; } }
        public _siteName SiteName { get { return siteName; } set { siteName = value; } }
        public _siteLogin SiteLogin { get { return siteLogin; } set { siteLogin = value; } }
        public _sitePassword SitePassword { get { return sitePassword; } set { sitePassword = value; } }
        public _siteImageFormatWidth SiteImageFormatWidth { get { return siteImageFormatWidth; } set { siteImageFormatWidth = value; } }
        public _siteImageFormatHeight SiteImageFormatHeight { get { return siteImageFormatHeight; } set { siteImageFormatHeight = value; } }
        public _siteEncoding SiteEncoding { get { return siteEncoding; } set { siteEncoding = value; } }
        public _siteContentType SiteContentype { get { return siteContentType; } set { siteContentType = value; } }
        public _siteTypeQuery SiteTypeQuery { get { return siteTypeQuery; } set { siteTypeQuery = value; } }
        public _siteAuthorization SiteAuthorization { get { return siteAuthorization; } set { siteAuthorization = value; } }
        public _sitePages SitePages { get { return sitePages; } set { sitePages = value; } }
        public _sitePage SitePage { get { return sitePage; } set { sitePage = value; } }
        public _siteTypeWebPage SiteTypeWebPage { get { return siteTypeWebPage; } set { siteTypeWebPage = value; } }
        public _siteWritingFile SiteWritingFile { get { return siteWritingFile; } set { siteWritingFile = value; } }
        public _siteTimeout SiteTimeout { get { return siteTimeout; } set { siteTimeout = value; } }

        public bool OptionsIsFill { get { return checkOptions(); } }

        private bool checkOptions()
        {
			/*
			*	Тест обязательныйх параметров
			*/
            bool fill = true;

            if (localAddressExport.value == "") { listOptionNotFill.Add(localAddressExport.strName); }
            if (localLogin.value == "") { listOptionNotFill.Add(localLogin.strName); }
            if (localPassword.value == "") { listOptionNotFill.Add(localPassword.strName); }
            if (ftpAddress.value == "") { listOptionNotFill.Add(ftpAddress.strName); }
            if (ftpLogin.value == "") { listOptionNotFill.Add(ftpLogin.strName); }
            if (ftpPassword.value == "") { listOptionNotFill.Add(ftpPassword.strName); }

            if (listOptionNotFill.Count > 1) { fill = false; }

            return fill;
        }

        #region Local Settings
        public class _isLocalShare
        {
            public string strName = "IsLocalShare";
            public string value = "";
            public string xml = "IsLocalShare";
        }
        public class _localAddressImport
        {
            public string strName = "LocalAddressImport";
            public string value = "";
            public string xml = "LocalAddressImport";
        }
        public class _localAddressExport
        {
            public string strName = "LocalAddressExport";
            public string value = "";
            public string xml = "LocalAddressExport";
        }
        public class _localLogin
        {
            public string strName = "LocalLogin";
            public string value = "";
            public string xml = "LocalLogin";
        }
        public class _localPassword
        {
            public string strName = "LocalPassword";
            public string value = "";
            public string xml = "LocalPassword";
        }
        public class _localRootFolder
        {
            public string strName = "LocalRootFolder";
            public string value = "";
            public string xml = "LocalRootFolder";
        }
        #endregion Local Settings
        #region FTP Settings
        public class _ftpEnable
        {
            public string strName = "FTP Enable?";
            public string value = "";
            public string xml = "FtpEnable";
        }
        public class _ftpTransferFiles
        {
            public string strName = "FtpTransferFiles";
            public string value = "";
            public string xml = "FtpTransferFiles";
        }
        public class _ftpAddress
        {
            public string strName = "FtpAddress";
            public string value = "";
            public string xml = "FtpAddress";
        }
        public class _ftpLogin
        {
            public string strName = "FtpLogin";
            public string value = "";
            public string xml = "FtpLogin";
        }
        public class _ftpPassword
        {
            public string strName = "FtpPassword";
            public string value = "";
            public string xml = "FtpPassword";
        }
        public class _ftpPort
        {
            public string strName = "Port";
            public int value = 21;
            public string xml = "FtpPort";
        }
        public class _ftpRootFolder
        {
            public string strName = "FTP Root Folder";
            public string value = "";
            public string xml = "FtpRootFolder";
        }
        public class _ftpFolderAndFile
        {
            public string strName = "Folders and Files";
            public string value = "";
        }
        public class _ftpPathExtFiles
        {
            public string strName = "Path to extention files";
            public string value = "";
            public string xml = "FtpPathExtFiles";
        }
        public class _ftpTimeout
        {
            public string strName = "Timeout FTP Server";
            public string value;
            public string xml = "FtpTimeout";
        }
        public class _ftpAllTypeAllow
        {
            public string strName = "Is allow all types";
            public string value = "1";
            public string xml = "ftpAllTypeAllow";
        }
        public class _ftpTypeDocuments
        {
            public string strName = "Type of transfer documents";
            public string value = "";
            public string xml = "FtpTypeDocuments";
        }
        public class _cleanDestionation
        {
            public string strName = "Clean destionation";
            public string value = "";
            public string xml = "CleanDestenation";
        }
        #endregion FTP Settings
        #region Site Settings
        public class _siteEnable
        {
            public string strName = "Site Enable";
            public string value = "0";
            public string xml = "SiteEnable";
        }
        public class _siteName
        {
            public string strName = "Site Name";
            public string value = "";
            public string xml = "SiteName";
        }
        public class _siteLogin
        {
            public string strName = "Site Login";
            public string value = "";
            public string xml = "SiteLogin";
        }
        public class _sitePassword
        {
            public string strName = "Site password";
            public string value = "";
            public string xml = "SitePassword";
        }
        public class _siteImageFormatWidth
        {
            public string strName = "Site image format - width";
            public string value = "";
            public string xml = "SiteImageFormatWidth";
        }
        public class _siteImageFormatHeight
        {
            public string strName = "Site image format - height";
            public string value = "";
            public string xml = "SiteImageFormatHeight";
        }
        public class _siteEncoding
        {
            public string strName = "Encoding";
            public string value = "";
            public string xml = "SiteEncoding";
        }
        public class _siteContentType
        {
            public string strName = "ContentType";
            public string value = "";
            public string xml = "SiteContentType";
        }
        public class _siteAuthorization
        {
            public string strName = "Authorization";
            public string value = "";
            public string xml = "SiteAuthorization";
        }
        public class _sitePages
        {
            public string strName = "Pages";
            public ArrayList Page = new ArrayList();
            public string xml = "PageTo";
        }
        public class _sitePage
        {
            public string strName = "Page";
            public string value = "";
            public string xml = "Page";
            //
            public string link = "";
            public string typeWebPage = "";
            public string writingFile = "";
            public string writingContent = "";
        }
        public class _siteTypeQuery
        {
            public string strName = "Type Query";
            public string value = "";
            public string xml = "SiteTypeQuery";
        }
        public class _siteTypeWebPage
        {
            public string strName = "Type Web Page";
            public string value = "";
            public string xml = "TypeWebPage";
        }
        public class _siteTimeout
        {
            public string strName = "Site timeout";
            public string value = "";
            public string xml = "Timeout";
        }
        public class _siteWritingFile
        {
            public string strName = "Writing file";
            public string value = "";
            public string xml = "WritingFile";
        }
        #endregion Site Settings

    }
    public class FoldersFiles
    {
		/*
		*	Класс описывает объекты коллекции файлов и категорий
		*/
        private bool isFolder = false;
        private bool isNewForFtp = false;
        private bool forDeleteFromFTP = false;
        private string nameFile = "";
        private string nameFolder = "";
        private string fileExtention = "";
        private string fullPathFile = "";
        private string fullPathFolder = "";
        private string ftpFolderAndFile = "";
        private string ftpStatusFolderAndFile = "";
        //
        public bool IsFolder { get { return isFolder; } set { isFolder = value; } }
        public bool IsNewForFTP { get { return isNewForFtp; } set { isNewForFtp = value; } }
        public bool ForDeleteFromFTP { get { return forDeleteFromFTP; } set { forDeleteFromFTP = value; } }
        public string NameFile { get { return nameFile; } set { nameFile = value; } }
        public string NameFolder { get { return nameFolder; } set { nameFolder = value; } }
        public string FileExtention { get { return fileExtention; } set { fileExtention = value; } }
        public string FullPathFile { get { return fullPathFile; } set { fullPathFile = value; } }
        public string FullPathFolder { get { return fullPathFolder; } set { fullPathFolder = value; } }
        public string FtpFolderAndFile { get { return ftpFolderAndFile; } set { ftpFolderAndFile = value; } }
        public string FtpStatusFolderAndFile { get { return ftpStatusFolderAndFile; } set { ftpStatusFolderAndFile = value; } }
    }
    public class Response
    {
        private string name;
        private string address;
        private string status;
        private string dataTime;
        private string error;

        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string DataTime { get { return dataTime; } set { dataTime = value; } }
        public string Error { get { return error; } set { error = value; } }
    }
    public class ProgramSettings
    {
        public ProgramSettings()
        {
            onLog = new _onLog();
            onLogDebug = new _onLogDebug();
            onLogErrors = new _onLogErrors();
        }
        private _onLog onLog;
        private _onLogDebug onLogDebug;
        private _onLogErrors onLogErrors;
        //
        public _onLog OnLog { get { return onLog; } set { onLog = value; } }
        public _onLogDebug OnLogDebug { get { return onLogDebug; } set { onLogDebug = value; } }
        public _onLogErrors OnLogErrors { get { return onLogErrors; } set { onLogErrors = value; } }
        //
        public class _onLogErrors
        {
            public string strName = "Is switch on error log";
            public string value = "";
            public string xml = "OnLogErrors";
        }
        public class _onLogDebug
        {
            public string strName = "Is switch on debug log";
            public string value = "";
            public string xml = "OnLogDebug";
        }
        public class _onLog
        {
            public string strName = "Is switch on log";
            public string value = "";
            public string xml = "OnLog";
        }
    }
}
