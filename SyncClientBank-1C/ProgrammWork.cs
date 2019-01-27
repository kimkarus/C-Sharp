using System;
using System.Net;
using System.Data;
using System.Xml;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Web;
using System.Threading;
using System.IO.Compression;
using System.IO;
//using System.Windows.Forms;
//using BytesRoad.Diag;
//using BytesRoad.Net.Ftp;
//using BytesRoad.Net.Sockets;

namespace SyncClientBank_1C
{
    public delegate void ProcessWindow2();

    public class ProgrammWork
    {
        #region common
        private DataSet dsXml;
        private XmlDocument xmlDoc;
        private string pathDirectoryApp = "";
        private string pathFileXml = "keys_configuration.xml";
        private FormConsole fc;
        private HtmlDocument htmlDoc;
        private WebBrowser wb;
        private CliverSoft.WindowInterceptor d1;
        private CliverSoft.WindowInterceptor d2;
        private CliverSoft.WindowInterceptor d3;
        private int hookedId1 = 0;
        private int hookedId2 = 0;
        private int hookedId3 = 0;
        private System.Windows.Forms.HtmlDocument pageLogin;
        private bool timerStarted = false;
        private int timerStep = 0;
        private bool timerStepFinished = false;
        private int step = 0;
        private int countHandles = 0;
        private int countD = 0;
        private string stringFromDate = "";
        private string stringToDate = "";
        private string[] date1;
        private string[] date2;
        private int countTokens = 0;
        private int finishedTokens = 0;
        private int tries = 0;
        //
        //HTTP
        private List<Fiddler.Session> oAllSessions = new List<Fiddler.Session>();
        private bool isFiddlerShutdown = false;
        private bool fiddlerShutdowned = false;
        private string fileUri = "";
        private string strKeys = "";
        private string[] keys;
        private WebClient wc;
        private System.Windows.Forms.WebBrowser wb_s;
        private System.Windows.Forms.HtmlDocument doc_s;
        //
        private Log l;
        private Bank b;
        private ArrayList banks;
        private Response r;
        //
        private string xmlTableNameClientBank = "ClientBank";
        //События
        public ProcessWindow2EventArgs evt;
        //public
        public DataSet DsXml { get { return dsXml; } set { dsXml = value; } }
        public XmlDocument XmlDoc { get { return xmlDoc; } set { xmlDoc = value; } }
        public string PathDirectoryApp { get { return pathDirectoryApp; } set { pathDirectoryApp = value; } }
        public string XmlTableNameClientBank { get { return xmlTableNameClientBank; } set { xmlTableNameClientBank = value; } }
        public bool TimerStarted { get { return timerStarted; } set { timerStarted = value; } }
        public int TimerStep { get { return timerStep; } set { timerStep = value; } }
        public int Step { get { return step; } set { step = value; } }
        public int CountD { get { return countD; } }
        public FormConsole Fc { get { return fc; } }
        public Bank B { get { return b; } set { b = value; } }

        //
        public string StringFromDate { get { return stringFromDate; } }
        public string StringToDate { get { return stringToDate; } }
        //
        public CliverSoft.WindowInterceptor D1 { get { return d1; } }
        public CliverSoft.WindowInterceptor D2 { get { return d2; } }
        public CliverSoft.WindowInterceptor D3 { get { return d3; } set { d3 = value; } }
        #endregion common

        public ProgrammWork()
        {
            l = new Log();
            r = new Response();
            banks = new ArrayList();
            //
            evt = new ProcessWindow2EventArgs();
            //

        }

        void ProgrammWork_onD3()
        {
            throw new NotImplementedException();
        }
        public ProgrammWork(FormConsole Fc)
        {
            l = new Log();
            r = new Response();
            banks = new ArrayList();
            this.fc = Fc;
            //
        }
        public void start(FormConsole frm)
        {
            PathDirectoryApp = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            readXmlOptions();
            readClientBank();
            date1 = new string[] { DateTime.Today.Day.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString() };
            date2 = new string[] { DateTime.Today.Day.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString() };

            b = returnClientBank();
            action(b, frm);

            //
            //set date1
            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(pathDirectoryApp + "\\date.txt");
            }
            catch (Exception e)
            {
                //closeApp();
            }
            if (lines.Length > 0)
            {
                string[] line = null;
                bool isPeriod = false;
                foreach(char ch in lines[0].ToCharArray())
                {
                    if (ch.ToString() == "-")
                    {
                        isPeriod = true;
                    }
                }
                if (isPeriod)
                {
                    line = lines[0].Split('-');
                }
                else
                {
                    line = new string[lines.Length];
                    line[0] = lines[0];
                }
                switch (line.Length)
                {
                    case 1:
                        {
                            string[] lineDate1 = line[0].Split('.');
                            
                            date1[0] = lineDate1[0];
                            date1[1] = lineDate1[1];
                            date1[2] = lineDate1[2];

                            date2[0] = lineDate1[0];
                            date2[1] = lineDate1[1];
                            date2[2] = lineDate1[2];
                            break;
                        }
                    case 2:
                        {
                            string[] lineDate1 = line[0].Split('.');
                            date1[0] = lineDate1[0];
                            date1[1] = lineDate1[1];
                            date1[2] = lineDate1[2];

                            string[] lineDate2 = line[1].Split('.');
                            date2[0] = lineDate2[0];
                            date2[1] = lineDate2[1];
                            date2[2] = lineDate2[2];
                            break;
                        }
                }
            }
        }
        private void readXmlOptions()
        {
            /*
			*	Чтение файла конфигурации
			*/
            dsXml = new DataSet();
            dsXml.ReadXml(pathDirectoryApp + "\\" + pathFileXml);
        }
        private void readClientBank()
        {
            /*
            *	Главная исполняющая процедура, где отбираются параметры из конфига и выполняется запуск вспомагательных процедур
            */
            //l.writeConsoleMessage("Этап 1 из 5. Читаем конфиг");
            foreach (DataRow row in dsXml.Tables[XmlTableNameClientBank].Rows)
            {
                #region Читаем конфиги банков
                /* Читаем Конфиг
                 * */
                b = new Bank();

                b.Name.value = row[b.Name.xml].ToString();
                b.Organization.value = row[b.Organization.xml].ToString();
                b.Login.value = row[b.Login.xml].ToString();
                b.Password.value = row[b.Password.xml].ToString();
                b.Pin.value = row[b.Pin.xml].ToString();
                b.Token.value = row[b.Token.xml].ToString();
                b.Token.valueHidden = row[b.Token.xmlHidden].ToString();
                b.Token.idHidden = row[b.Token.xmlFiledHidden].ToString();
                b.Cert.value = row[b.Cert.xml].ToString();
                b.CertCode.value = row[b.CertCode.xml].ToString();
                b.CertCodeInner.value = row[b.CertCodeInner.xml].ToString();
                b.CertInner.value = row[b.CertInner.xml].ToString();
                b.OnlyIncome.value = row[b.OnlyIncome.xml].ToString();
                b.ManualSaving.value = row[b.ManualSaving.xml].ToString();
                if (b.ManualSaving.value == "1")
                { b.ManualSaving.isValue = true; }
                else { b.ManualSaving.isValue = false; }
                //
                b.LoginUrl.value = row[b.LoginUrl.xml].ToString();
                b.LogoutUrl.value = row[b.LogoutUrl.xml].ToString();
                //
                b.Login.id = row[b.Login.xmlFiled].ToString();
                b.Password.id = row[b.Password.xmlFiled].ToString();
                b.Token.id = row[b.Token.xmlFiled].ToString();
                b.Cert.id = row[b.Cert.xmlFiled].ToString();
                //
                b.ButtonLogin.id = row[b.ButtonLogin.xml].ToString();
                //
                b.FolderDestination.value = row[b.FolderDestination.xml].ToString();
                b.FileDestination.value = row[b.FileDestination.xml].ToString();
                b.OnArchive.value = row[b.OnArchive.xml].ToString();
                b.ArchiveMethod.value = row[b.ArchiveMethod.xml].ToString();
                //
                banks.Add(b);
                #endregion Читаем конфиги банков
                //
            }
        }
        private void openInternetBroweser(Bank b)
        {
            fc.webBrowser.Navigate(new Uri(b.LoginUrl.value));
            //
        }
        public void switchClientBank()
        {
            b = returnClientBank();
        }
        private Bank returnClientBank(int index = -1)
        {
            if (index > -1) step = index;
            if (step > banks.Count - 1) step = 0;
            Bank item = (Bank)banks[step];
            if (item.Finished)
            {
                step += 1;
                b = returnClientBank();
            }
            if (finishedTokens >= countTokens && finishedTokens != 0)
            {
                //closeApp();
            }
            step += 1;
            return item;
        }
        public void action(Bank bank, FormConsole frm, int InputStep=-1)
        {
            fc = frm;
            bool norm = false;
            try
            {
                wb_s = frm.webBrowser;
                doc_s = frm.webBrowser.Document;
                norm = true;
            }
            catch (System.Exception ex)
            {

            }
            int step = timerStep;
            if (InputStep >= 0) step = InputStep;
            if (norm)
            {
                switch (step)
                {
                    case 0:
                        {
                            frm.timer1.Interval = 20000;
                            frm.timerStart();
                            //timerStep++;
                            openInternetBroweser(bank);
                            break;
                        }
                    case 1:
                        {
                            frm.timer1.Interval = 5000;
                            setInputs(doc_s, wb_s);
                            frm.timerStart();
                            break;
                        }
                    case 2:
                        {
                            frm.timer1.Interval = 25000;
                            pushButton(doc_s, wb_s);
                            d1 = new CliverSoft.WindowInterceptor(frm.Handle, ProcessWindow1, this);
                            frm.timerStart();
                            break;
                        }
                    case 3:
                        {
                            if (!timerStepFinished)
                            {
                                frm.timerStop();
                                frm.timerStart();

                            }
                            else
                            {
                                frm.timer1.Interval = 5000;
                                openExtracts(doc_s, wb_s);
                                frm.timerStart();
                            }
                            break;
                        }
                    case 4:
                        {
                            frm.timer1.Interval = 5000;
                            setExtracts(doc_s, wb_s);
                            frm.timerStart();
                            break;
                        }
                    case 5:
                        {
                            if (b.ManualSaving.isValue) { break; }
                            else
                            {
                                frm.timer1.Interval = 5000;
                                viewExtracts(doc_s, wb_s);
                                frm.timerStart();
                                break;
                            }
                        }
                    case 6:
                        {
                            if (b.ManualSaving.isValue) { break; }
                            else
                            {
                                frm.timer1.Interval = 5000;
                                saveExtracts(doc_s, wb_s);
                                frm.timerStart();
                                break;
                            }
                        }
                    case 7:
                        {
                            if (b.ManualSaving.isValue) { break; }
                            else
                            {
                                frm.timer1.Interval = 5000;
                                moveToPage(b.LogoutUrl.value);
                                frm.timerStart();
                                finishedTokens++;
                                if (finishedTokens <= countTokens)
                                {
                                    timerStep = 0;
                                    countTokens = 0;
                                    b = returnClientBank();
                                    action(b, frm);
                                }
                                else
                                {
                                    closeApp();
                                }
                                break;
                            }
                        }
                    case 8:
                        {
                            frm.timer1.Interval = 5000;
                            b.Finished = true;
                            moveToPage(b.LogoutUrl.value);
                            frm.timerStart();
                            finishedTokens++;
                            
                            if (finishedTokens < countTokens)
                            {
                                timerStep = 0;
                                countTokens = 0;
                                b = returnClientBank();
                                if (!b.Finished)
                                {
                                    action(b, frm);
                                }
                            }
                            else
                            {
                                closeApp();
                            }
                            break;
                        }
                }
            }

        }
        public void openExtracts(System.Windows.Forms.HtmlDocument doc=null, System.Windows.Forms.WebBrowser wb = null)
        {
            try
            {
                clickLink("Документы", doc, wb, "A", "InnerText");
            }
            catch (System.Exception ex)
            {
                if (!b.ManualSaving.isValue)
                {
                    moveToPage(b.LogoutUrl.value);
                    timerStep = 0;
                }
            }
        }
        public void setExtracts(System.Windows.Forms.HtmlDocument doc=null, System.Windows.Forms.WebBrowser wb = null)
        {
            stringFromDate = date1[0] + "/" + date1[1] + "/" + date1[2];
            setElementAttributeByName("fromdate", stringFromDate, doc, "value");
            //
            setElementAttributeByName("fromdatedd", date1[0], doc, "value");
            setElementAttributeByName("fromdatemm", date1[1], doc, "value");
            setElementAttributeByName("fromdateyy", date1[2], doc, "value");
            //
            stringToDate = date2[0] + "/" + date2[1] + "/" + date2[2];
            setElementAttributeByName("todate", stringToDate, doc, "value");
            //
            setElementAttributeByName("todatedd", date2[0], doc, "value");
            setElementAttributeByName("todatemm", date2[1], doc, "value");
            setElementAttributeByName("todateyy", date2[2], doc, "value");
            //
            clickLink("Показать", doc, wb, "input", "value");
            
        }
        public void viewExtracts(System.Windows.Forms.HtmlDocument doc = null, System.Windows.Forms.WebBrowser wb = null)
        {
            clickLink("Экспорт", doc, wb, "input", "value");
        }
        public void saveExtracts(System.Windows.Forms.HtmlDocument doc=null, System.Windows.Forms.WebBrowser wb = null)
        {
            //frm.webBrowser.ShowSaveAsDialog();
            clickLink("expformat", doc, wb, "input", "id");
            setElementAttributeByName("expformat", "docexp1c77.asp", doc, "value");
            clickLink("btnLoad", doc, wb,  "input", "id");
            //
            countHandles = 0;
            //

        }
        public void saveFile(string address="")
        {
            countD = 2;
            if (address != "")
            {
                System.Text.Encoding code = Encoding.GetEncoding("windows-1251");
                var responseStream = new GZipStream(wc.OpenRead(address), CompressionMode.Decompress);
                var reader = new StreamReader(responseStream, code);
                var textResponse = reader.ReadToEnd();

                //byte[] fileBytes = new UTF8Encoding(true).GetBytes(textResponse);
                byte[] fileBytes = new ASCIIEncoding().GetBytes(textResponse);

                if (!Directory.Exists(b.FolderDestination.value))
                {
                    Directory.CreateDirectory(b.FolderDestination.value);
                }
                string strDate = date1[0].ToString() + "." + date1[1].ToString() + "." + date1[2].ToString();
                string dirDate=b.FolderDestination.value+"\\"+strDate;
                try
                {
                    if (!Directory.Exists(dirDate))
                    {
                        Directory.CreateDirectory(dirDate);
                    }
                    if (File.Exists(b.FolderDestination + "\\" + b.FileDestination))
                    {
                        File.Delete(b.FolderDestination + "\\" + b.FileDestination);
                    }
                    if (File.Exists(dirDate + "\\" + b.FileDestination))
                    {
                        File.Delete(dirDate + "\\" + b.FileDestination);
                    }
                    using (FileStream fs = File.Create(b.FolderDestination.value + "\\" + b.FileDestination.value))
                    {
                        
                        StreamWriter sw = new StreamWriter(fs, code);
                        sw.Write(textResponse);
                        //fs.Write(fileBytes, 0, fileBytes.Length);
                        sw.Close();
                    }
                    using (FileStream fs = File.Create(dirDate + "\\" + b.FileDestination.value))
                    {
                        StreamWriter sw = new StreamWriter(fs, code);
                        sw.Write(textResponse);
                        //fs.Write(fileBytes, 0, fileBytes.Length);
                        sw.Close();
                    }
                    b.Finished = true;
                }
                catch (System.Exception ex)
                {
                    //closeApp();
                }
            }
            //
        }
        public void setInputs(System.Windows.Forms.HtmlDocument doc=null, System.Windows.Forms.WebBrowser wb = null)
        {
            //
            //login
            setElementAttributeByName(b.Login.id, b.Login.value, doc,"");
            //password
            setElementAttributeByName(b.Password.id, b.Password.value, doc,"");
            //token
            #region token
            HtmlElementCollection hec = null;
            try
            {
               hec = doc.GetElementById(b.Token.id).GetElementsByTagName("option");
            }
            catch (System.Exception ex)
            {
                closeApp();
                return;
            }
            if (countTokens <= 0)
            {
                foreach (HtmlElement he_hec in hec)
                {
                    if (timerStep == 1)
                    {
                        countTokens++;
                    }
                }
            }
            int foundToken = 0;
            if (hec.Count > 0)
            {
                foreach (HtmlElement he_hec in hec)
                {
                    /*if (timerStep == 1)
                    {
                        countTokens++;
                    }*/
                    he_hec.InvokeMember("click");
                    if (b.Token.value == he_hec.InnerText)
                    {
                        //Set token
                        foundToken++;
                        doc.GetElementById(b.Token.id).Focus();
                        setElementAttributeByElement("true", he_hec, "selected");
                        setElementAttributeByName(b.Token.id, he_hec.GetAttribute("value"), doc,"");
                        setElementAttributeByName(b.Token.idHidden, b.Token.valueHidden, doc,"");
                        he_hec.InvokeMember("click");
                        doc.GetElementById(b.Token.id).InvokeMember("onchange");
                    }
                }
            }
            if (foundToken <= 0)
            {
                if (tries > banks.Count)
                {
                    closeApp();
                }
                b = returnClientBank();
                setInputs(doc, wb);
                tries++;
            }
            if (countTokens <= 0)
            {
                closeApp();
            }
            //countTokens = countTokens;// / 2;
            #endregion token
            //Cert
            #region cert
            hec = doc.GetElementById(b.Cert.id).GetElementsByTagName("option");
            if (hec.Count > 0)
            {
                int count = 0;
                foreach (HtmlElement he_hec in hec)
                {
                    switch (count)
                    {
                        case 0:
                            {
                                setElementAttributeByElement(b.Cert.value, he_hec, "value");
                                setElementInnerByElement(b.CertInner.value, he_hec);
                                break;
                            }
                        case 1:
                            {
                                setElementAttributeByElement(b.CertCode.value, he_hec, "value");
                                setElementInnerByElement(b.CertCodeInner.value, he_hec);
                                break;
                            }
                    }
                    count += 1;
                }
            }
            setElementAttributeByName("tlv", "1", doc,"");
            #endregion cert
        }
        public void pushButton(System.Windows.Forms.HtmlDocument doc=null, System.Windows.Forms.WebBrowser wb = null, string buttonId="")
        {
            countD = 1;
            d1 = new CliverSoft.WindowInterceptor(fc.Handle, ProcessWindow1, this);
            if (buttonId == "") buttonId = b.ButtonLogin.id;
            d1 = new CliverSoft.WindowInterceptor(fc.Handle, ProcessWindow1, this);
            doc.GetElementById(buttonId).InvokeMember("click");
            d1 = new CliverSoft.WindowInterceptor(fc.Handle, ProcessWindow1, this);
            //
        }
        public void clickLink(string searching="", System.Windows.Forms.HtmlDocument doc=null, System.Windows.Forms.WebBrowser wb = null, string tag="", string searchingPlace="",HtmlElement he_in=null, HtmlElementCollection hec=null)
        {
            if(tag=="")tag="A";
            if (he_in == null)
            {
                hec = doc.GetElementsByTagName(tag);
                switch (searchingPlace)
                {
                    case "InnerText":
                        {
                            foreach (HtmlElement he in hec)
                            {
                                if (he.InnerText.Equals(searching))
                                    he.InvokeMember("click");
                            }
                            break;
                        }
                    case "value":
                        {
                            foreach (HtmlElement he in hec)
                            {
                                if (he.GetAttribute(searchingPlace).Equals(searching))
                                    he.InvokeMember("click");
                            }
                            break;
                        }
                    case "id":
                        {
                            foreach (HtmlElement he in hec)
                            {
                                if (he.GetAttribute(searchingPlace).Equals(searching))
                                    he.InvokeMember("click");
                            }
                            break;
                        }
                }
            }
            else
            {
                he_in.InvokeMember("click");
            }
        }
        public void moveToPage(string page = "")
        {
            if (page != "")
            {
                fc.webBrowser.Navigate(page);
            }
        }
        private void setElementAttributeByName(string name = "", string value = "", System.Windows.Forms.HtmlDocument doc = null, string attributeName = "")
        {

            try
            {
                if (attributeName == "") attributeName = "value";
                if (name != "" && value != "")
                {
                    HtmlElement he = doc.GetElementById(name);
                    if (he != null)
                    {
                        he.SetAttribute(attributeName, value);
                    }
                    else
                    {
                        //HtmlElement he = doc.get(name);
                    }
                }
            }
            catch (System.Exception ex)
            {
                b = returnClientBank();
                setInputs(doc, wb);
            }

        }
        private void setElementAttributeByElement(string value = "", System.Windows.Forms.HtmlElement he = null, string attributeName = "")
        {
            if (attributeName == "") attributeName = "value";
            if (he != null)
            {
                he.SetAttribute(attributeName, value);
            }
        }
        private void setElementInnerByElement(string value = "", System.Windows.Forms.HtmlElement he = null)
        {
            if (he != null)
            {
                he.InnerText = value;
            }
        }
        private void DeleteAttributeByElement(string value = "", System.Windows.Forms.HtmlElement he = null)
        {
            if (he != null)
            {
                //he.SetAttribute
            }
        }
        private void followToBankPahe()
        {
        }
        public void enterInSystem(Bank b)
        {
            //pushButton(
        }
        private void enterBankParametres()
        {
        }
        public void readHTTPRequests(WebBrowserNavigatingEventArgs e, FormConsole frm)
        {
            #region listening
            if (e.Url.ToString().Contains("https://clbank.***.ru/"))
            {
                Fiddler.FiddlerApplication.BeforeRequest += delegate(Fiddler.Session oS)
                {
                    Monitor.Enter(oAllSessions);
                    oAllSessions.Add(oS);
                    Monitor.Exit(oAllSessions);
                };

            }
            int countContains = 0;
            foreach (Fiddler.Session oS in oAllSessions)
            {
                if (oS.fullUrl.Contains("clbank.****.ru/docexp"))
                {
                    countContains++;
                    //Fiddler.Session
                    foreach (Fiddler.HTTPHeaderItem head in oS.oRequest.headers)
                    {
                        if (head.Name == "Cookie")
                        {
                            strKeys = head.Value;
                            keys = head.Value.Split(';');
                            isFiddlerShutdown = true;
                            switchOffFiddler();
                            break;
                        }
                    }
                }
                if (isFiddlerShutdown) break;

            }
            if (countContains <= 0)
            {
                oAllSessions.Clear();
                //isFiddlerShutdown = true;
            }
            if (isFiddlerShutdown && !fiddlerShutdowned)
            {
                switchOffFiddler();
            }
            #endregion listening
            //
            
            if (e.Url.ToString().Contains("https://clbank.***.ru/docexp1c77.asp"))
            {
                #region build http request
                fileUri = e.Url.ToString();

                e.Cancel = true;

                //MessageBox.Show("Cancel");

                //string filepath = null;

                string cookies = GetCookies(frm);

                string address = e.Url.ToString();
                //Замена символов
                address = address.Replace(stringFromDate, stringFromDate.Replace("/", "%2F"));
                address = address.Replace(stringToDate, stringToDate.Replace("/", "%2F"));
                //
                wc = new WebClient();
                try
                {
                    wc.Headers.Add(HttpRequestHeader.Accept, "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, */*");
                    wc.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; WebMoney Advisor)");
                    wc.Headers.Add(HttpRequestHeader.AcceptLanguage, "ru-RU");
                    wc.Headers.Add(HttpRequestHeader.Referer, "https://clbank.***.ru/docexport.asp");
                    wc.Headers.Add(HttpRequestHeader.Cookie, strKeys);
                }
                catch (System.Exception ex)
                {
                    string err = ex.Message.ToString();
                }
                #endregion build http request
                //
                saveFile(address);
            }
        }
        private string GetCookies(FormConsole frm)
        {
            return frm.webBrowser.Document.Cookie;
        }
        public void switchOffFiddler()
        {
            Fiddler.FiddlerApplication.Shutdown();
            fiddlerShutdowned = true;
        }
        public void ProcessWindow1(IntPtr hwnd)
        {
            hookedId1 = (int)d1.Hook_id;
            
            //looking for edit box control within intercepted window
            IntPtr h = (IntPtr)Win32.Functions.FindWindowEx(hwnd, IntPtr.Zero, "Edit", null);
            h = (IntPtr)Win32.Functions.FindWindowEx(hwnd, h, "Edit", null);
            if (h != IntPtr.Zero)
            {
                //setting text
                Win32.Functions.SetWindowText((IntPtr)h, b.Pin.value);
                timerStepFinished = true;
                
            }
            //looking for button "OK" within the intercepted window
            h = (IntPtr)Win32.Functions.FindWindowEx(hwnd, IntPtr.Zero, "Button", null);
            if (h != IntPtr.Zero)
            { //clicking the found button
                Win32.Functions.SendMessage
                    ((IntPtr)h, (uint)Win32.Messages.WM_LBUTTONDOWN, 0, 0);
                Win32.Functions.SendMessage
                        ((IntPtr)h, (uint)Win32.Messages.WM_LBUTTONUP, 0, 0);
                d1.Stop();
                //hookedId = 0;
                timerStepFinished = true;
            }
            else
            { //close window if OK was not found
                Win32.Functions.SendMessage(hwnd, (uint)Win32.Messages.WM_CLOSE, 0, 0);
            }
            //Thread.Sleep(1000);
        }
        public void ProcessWindow2(IntPtr hwnd)
        {
            //looking for edit box control within intercepted window
            countHandles++;
            if ((int)d1.Hook_id <= 0 /*&& (int)d1.Hook_id <=0*/)
            {
                IntPtr h1 = (IntPtr)Win32.Functions.FindWindowEx(hwnd, IntPtr.Zero, "Button", null);
                IntPtr h2 = (IntPtr)Win32.Functions.FindWindowEx(hwnd, h1, "Button", null);
                //IntPtr h3 = (IntPtr)Win32.Functions.FindWindowEx(hwnd, h2, "Button", null);
                //h = (IntPtr)Win32.Functions.FindWindowEx(hwnd, h, "Button", null);
                //h = (IntPtr)Win32.Functions.FindWindowEx(hwnd, h, "Button", null);
                if (h2 != IntPtr.Zero)
                {
                    //setting text
                    Win32.Functions.SendMessage
                            ((IntPtr)h2, (uint)Win32.Messages.WM_LBUTTONDOWN, 0, 0);
                    Win32.Functions.SendMessage
                            ((IntPtr)h2, (uint)Win32.Messages.WM_LBUTTONUP, 0, 0);
                    d2.Stop();
                    //hookedId = 0;
                }
                //looking for button "OK" within the intercepted window
                else
                { //close window if OK was not found
                    Win32.Functions.SendMessage(hwnd, (uint)Win32.Messages.WM_CLOSE, 0, 0);
                    //d2.Stop();
                }
            }
            //Thread.Sleep(3000);
            //
            /*if (h2 != IntPtr.Zero && countHandles > 3)
            {
                CliverSoft.WindowInterceptor d2 = new CliverSoft.WindowInterceptor(fc.Handle, ProcessWindow5);
            }*/
        }
        public void ProcessWindow3(IntPtr hwnd)
        {
            //looking for edit box control within intercepted window
            if (countD > 2 && (int)d2.Hook_id <= 0)
            {
                IntPtr dialog = (IntPtr)Win32.Functions.FindWindow("#32770", null);
                if ((int)dialog == 0) dialog = (IntPtr)Win32.Functions.FindWindow("#32770", null);
                hwnd = dialog;
                IntPtr h1 = (IntPtr)Win32.Functions.FindWindowEx(hwnd, IntPtr.Zero, "Button", null);
                IntPtr h2 = (IntPtr)Win32.Functions.FindWindowEx(hwnd, h1, "Button", null);
                //h = (IntPtr)Win32.Functions.FindWindowEx(hwnd, h, "Button", null);
                //h = (IntPtr)Win32.Functions.FindWindowEx(hwnd, h, "Button", null);
                if (h1 != IntPtr.Zero)
                {
                    //setting text
                    Win32.Functions.SendMessage
                            ((IntPtr)h1, (uint)Win32.Messages.WM_LBUTTONDOWN, 0, 0);
                    Win32.Functions.SendMessage
                            ((IntPtr)h1, (uint)Win32.Messages.WM_LBUTTONUP, 0, 0);
                    //countD = 4;
                    d3.Stop();
                    //hookedId = 0;
                }
                //looking for button "OK" within the intercepted window
                else
                { //close window if OK was not found
                    Win32.Functions.SendMessage(hwnd, (uint)Win32.Messages.WM_CLOSE, 0, 0);
                    //d3.Stop();
                }
            }
        }
        private void closeApp()
        {
            fc.Close();
            Application.Exit();
        }
        public class ProcessWindow2EventArgs
        {
            public event ProcessWindow2 UserEvent;
            private ProgrammWork pw;
            public void OnUserEvent()
            {
                UserEvent();
            }
        }
    }
}
