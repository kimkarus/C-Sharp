using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Data;
using System.Xml;
using System.IO;
using System.Security;
using System.Collections;
/*
 * Created by kimkarus
 * website: www.kimkarus.ru
 * */
namespace UpdateHttp
{

    public class Program
    {
        public Program()
        {
            ProgramWork pw = new ProgramWork();
            //
            Main(pw.ArrMain);
        }
        public static void Main(string[] arr)
        {
            ProgramWork pw = new ProgramWork();
            /*foreach (string str in pw.ArrMain)
            {
                Console.WriteLine(str);
            }*/
            Environment.Exit(0);
        }
    }
    public class Router
    {
        public Router()
        {
            name = new _name();
            link = new _link();
            port = new _port();
            typeHttp = new _typeHttp();
            encoding = new _encoding();
            contentType = new _contentType();
            typeQuery = new _typeQuery();
        }

        private _name name;
        private _port port;
        private _link link;
        private _typeHttp typeHttp;
        private _encoding encoding;
        private _contentType contentType;
        private _typeQuery typeQuery;

        private List<string> listOptionNotFill = new List<string>();

        public _name Name { get { return name; } set { name = value; } }
        public _link Link { get 
        {
            link.value = returnNewLink(link.value);
            return link; 
        } set { link = value; } }
        public _port Port { get { return port; } set { port = value; } }
        public _typeHttp TypeHttp { get { return typeHttp; } set { typeHttp = value; } }
        public _encoding Encoding { get { return encoding; } set { encoding = value; } }
        public _contentType ContentType { get { return contentType; } set { contentType = value; } }
        public _typeQuery TypeQuery { get { return typeQuery; } set { typeQuery = value; } }
        public bool OptionsRouterIsFill { get { return checkOptionsRouter(); } }


        private bool checkOptionsRouter()
        {
            bool fill = true;

            if (name.value == "") { listOptionNotFill.Add(name.strName); }
            if (link.value == "") { listOptionNotFill.Add(link.strName); }
            if (port.value == "") { listOptionNotFill.Add(port.strName); }
            if (typeHttp.value == "") { listOptionNotFill.Add(typeHttp.value); }
            if (typeQuery.value == "") { listOptionNotFill.Add(typeQuery.strName); }
            if (encoding.value == "") { listOptionNotFill.Add(encoding.strName); }
            if (contentType.value == "") { listOptionNotFill.Add(contentType.strName); }

            if (listOptionNotFill.Count > 1) { fill = false; }

            return fill;
        }
        private string returnNewLink(string strIn)
        {
            bool findSymbl = false;
            string str = "";
            for (int j = 0; j < strIn.Length; j++)
            {
                if (strIn[j] == '+')
                {
                    findSymbl = true;
                    break;
                }
            }
            if (findSymbl)
            {
                str = strIn.Replace("+", "&");
            }
            else
            {
                str = strIn;
            }
            return str;
        }
        public class _name
        {
            public string strName = "Name";
            public string value = "";
        }
        public class _link
        {
            public string strName = "Link";
            public string value = "";
        }
        public class _port
        {
            public string strName = "IP";
            public string value = "";
        }
        public class _typeHttp
        {
            public string strName = "Type HTTP";
            public string value = "";
        }
        public class _encoding
        {
            public string strName = "Encoding";
            public string value = "";
        }
        public class _contentType
        {
            public string strName = "Content-Type";
            public string value = "";
        }
        public class _typeQuery
        {
            public string strName = "TypeQuery";
            public string value = "";
        }  
    }
    public class Response
    {
        private string name;
        private string link;
        private string port;
        private string typeHttp;
        private string status;
        private string dataTime;
        private string error;

        public string Name { get { return name; } set { name = value; } }
        public string Link { get { return link; } set { link = value; } }
        public string Port { get { return port; } set { port = value; } }
        public string TypeHttp { get { return typeHttp; } set { typeHttp = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string DataTime { get { return dataTime; } set { dataTime = value; } }
        public string Error { get { return error; } set { error = value; } }
    }
    public class ProgramWork
    {
        #region Params
        /*
        * XML Parser options
        * */
        private DataSet dsXml;
        private XmlDocument xmlDoc;
        private string pathDirectoryApp = "OptionsRouter.xml";
        private string xmlTableName = "Router";
        private string xmlName = "Name";
        private string xmlLink = "Link";
        private string xmlPort = "Port";
        private string xmlTypeHttp = "TypeHTTP";
        private string xmlEncoding = "Encoding";
        private string xmlContentType = "ContentType";
        private string xmlTypeQuery = "TypeQuery";
        //public
        public DataSet DsXml { get { return dsXml; } set { dsXml = value; } }
        public XmlDocument XmlDoc { get { return xmlDoc; } set { xmlDoc = value; } }
        public string PathDirectoryApp { get { return pathDirectoryApp; } set { pathDirectoryApp = value; } }
        public string XmlTableName { get { return xmlTableName; } set { xmlTableName = value; } }
        public string XmlName { get { return xmlName; } set { xmlName = value; } }
        public string XmlLink { get { return xmlLink; } set { xmlLink = value; } }
        public string XmlPort { get { return xmlPort; } set { xmlPort = value; } }
        public string XmlTypeHttp { get { return xmlTypeHttp; } set { xmlTypeHttp = value; } }
        public string XmlEncoding { get { return xmlEncoding; } set { xmlEncoding = value; } }
        public string XmlContentType { get { return xmlContentType; } set { xmlContentType = value; } }
        public string XmlTypeQuery { get { return xmlTypeQuery; } set { xmlTypeQuery = value; } }
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
         * Logs
         * */
        private ArrayList log;
        private string error;
        //public
        public ArrayList Log { get { return log; } set { log = value; } }
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
        private string strQuery;
        private byte[] ByteQuery;
        #endregion Params
        public ProgramWork()
        {
            PathDirectoryApp = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            readXmlOptions();
            Log = new ArrayList();
            //
            restartRouters();
        }
        private void restartRouters()
        {
            for (int i = 0; i < dsXml.Tables[xmlTableName].Rows.Count; i++)
            {
                /*
                 * Проверка параметров
                 * */
                Router router = new Router();
                router.Name.value = dsXml.Tables[xmlTableName].Rows[i][xmlName].ToString();
                router.Link.value = dsXml.Tables[xmlTableName].Rows[i][xmlLink].ToString();
                if (dsXml.Tables[xmlTableName].Rows[i][xmlPort].ToString().Length <= 0) { router.Port.value = "80"; }
                else { router.Port.value = dsXml.Tables[xmlTableName].Rows[i][xmlPort].ToString(); }
                if (dsXml.Tables[xmlTableName].Rows[i][xmlTypeHttp].ToString().Length <= 0) { router.TypeHttp.value = "http"; }
                else { router.TypeHttp.value = dsXml.Tables[xmlTableName].Rows[i][xmlTypeHttp].ToString(); }
                router.TypeQuery.value = dsXml.Tables[xmlTableName].Rows[i][xmlTypeQuery].ToString();
                router.Encoding.value = dsXml.Tables[xmlTableName].Rows[i][xmlEncoding].ToString();
                router.ContentType.value = dsXml.Tables[xmlTableName].Rows[i][xmlContentType].ToString();
                /*
                 * ------------END--------------------
                 * */
                if (router.OptionsRouterIsFill)
                {
                    /*
                     * Create request
                     * */
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(router.TypeHttp.value + "://" + router.Link.value);

                    Cooks = new CookieContainer();
                    httpWebRequest.AllowAutoRedirect = true;
                    httpWebRequest.CookieContainer = new CookieContainer();
                    httpWebRequest.ContentType = router.ContentType.value;
                    httpWebRequest.Method = router.TypeQuery.value;
                    //Referer
                    //
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:13.0) Gecko/20100101 Firefox/13.0.1";
                    httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    httpWebRequest.UseDefaultCredentials = false;
                    httpWebRequest.PreAuthenticate = true;
                    httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                    //
                    /*
                     * ------------END--------------------
                     * */
                    bool getResponse = false;
                    try
                    {
                        httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        getResponse = true;
                    }
                    catch (System.Exception ex)
                    {
                        error = ex.ToString();
                    }

                    //
                    if (httpWebResponse != null & getResponse)
                    {
                        statusResponse = httpWebResponse.StatusCode.ToString();
                    }
                    else
                    {
                        statusResponse = error;
                    }
                    DateTime date = DateTime.Now;
                    /*
                     * ------------END--------------------
                     * */
                    /*
                     * Write response
                     * */
                    Response response = new Response();
                    response.Name = router.Name.value;
                    response.Link = router.Link.value;
                    response.Port = router.Port.value;
                    response.Status = statusResponse;
                    response.DataTime = date.ToString();
                    response.Error = error;
                    log.Add(response);
                    Console.WriteLine(response.Link + "   " + response.Port + "   " + response.Name + "   " + response.DataTime + "   " + response.Status);
                    response = null;
                    /*
                     * ------------END--------------------
                     * */
                }
                router = null;
                //
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
            /*
            * Write Log file
            * */
            writeLogsFile();
            /*
            * ------------END--------------------
            * */
        }
        private void readXmlOptions()
        {
            dsXml = new DataSet();
            dsXml.ReadXml(pathDirectoryApp + "\\OptionsRouter.xml");
        }
        private void writeLogsFile()
        {
            /*
             * Write log file
             * */
            writer = File.AppendText(pathDirectoryApp + "\\Log.txt");
            for (int i = 0; i < Log.Count; i++)
            {
                Response response = (Response)Log[i];
                writer.WriteLine(response.Link + "   " + response.Port + "   " + response.Name + "   " + response.DataTime + "   " + response.Status);
            }
            writer.WriteLine("*****************************************");
            writer.Close();
            writer = File.AppendText(pathDirectoryApp + "\\LogErrors.txt");
            for (int i = 0; i < Log.Count; i++)
            {
                Response response = (Response)Log[i];
                writer.WriteLine(response.Error);
            }
            writer.WriteLine("*****************************************");
            writer.Close();
            /*
             * ------------END--------------------
             * */
        }
        private void runPOST()
        {
        }
    }
}
