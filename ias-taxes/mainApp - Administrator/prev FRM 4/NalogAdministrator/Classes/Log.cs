using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NalogAdministrator.Classes
{
    public class Log
    {
        private LogErrors logErrors;
        private Core cr;
        public Log(Core Cr)
        {
            this.cr = Cr;
            logErrors = new LogErrors(this.cr);
        }
        public Log(Core Cr, string error="")
        {
            this.cr = Cr;
            logErrors = new LogErrors(this.cr, error);
        }
        public Log(Core Cr, string error="", string action="")
        {
            this.cr = Cr;
            logErrors = new LogErrors(this.cr);
        }
        public class LogErrors
        {
            private Core cr;
            private string logFile = "log_errors.txt";
            public LogErrors(Core Cr, string error="")
            {
                this.cr = Cr;
                checkFile();
                writeError(error);
            }
            private void checkFile()
            {
                string file = cr.AppPath + "\\" + logFile;
                if (!File.Exists(file))
                {
                    File.Create(file);
                }
            }
            private void writeError(string extention)
            {
                string[] array = new string[] { extention };
                File.WriteAllLines(cr.AppPath + "\\" + logFile, array);
            }
        }
    }
}
