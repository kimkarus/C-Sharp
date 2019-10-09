using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace NalogAdministrator.Classes
{
    public class Core
    {
        //
        private EventChangeStatus eveChStatus;
        //
        private string appPath = "";
        //
        public delegate void EventChangeStatus(string status, bool equal);
        //
        public EventChangeStatus EveChStatus { get { return eveChStatus; } set { eveChStatus = value; } }
        //
        public string AppPath { get { return appPath; } set { appPath = value; } }
        //
        //
        public Core(FormApp FrmAppl)
        {
            this.frmApp = FrmAppl;
            eveChStatus = new EventChangeStatus(OnChangeStatus);
            appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            log = new Log(this);
        }
        private Data data;
        //private Events events;
        protected Log log;
        private Classes.ImpData.ImportData importData;
        private FormApp frmApp;
        private Stopwatch sWatch = new Stopwatch();
        private float getParamBefore = 0f;
        private float processingEventsReadFile =0f;
        private List<float> processingEventAddToBase = new List<float>();

        //
        private Classes.SwitchControls switchControls;
        //
        //public Events Events { get { return events; } set { events = value; } }
        public float GetParamBefore { get { return getParamBefore; } set { getParamBefore = value; } }
        public float ProcessingEventsReadFile { get { return processingEventsReadFile; } set { processingEventsReadFile = value; } }
        public List<float> ProcessingEventAddToBase { get { return processingEventAddToBase; } set { processingEventAddToBase = value; } }
        public Stopwatch SWatch { get { return sWatch; } set { sWatch = value; } }
        public Data Data { get { return data; } set { data = value; } }
        public Classes.ImpData.ImportData ImportData { get { return importData; } set { importData = value; } }
        public FormApp FrmApp { get { return frmApp; } }
        public Log Log { get { return log; } set { log = value; } }

        //
        public Classes.SwitchControls SwitchCotrlos { get { return switchControls; } set { switchControls = value; } }

        private void OnChangeStatus(string status, bool equal)
        {
            if (!equal)
            {
                FrmApp.toolStripLabelActivityNow.Text = status;

                Application.DoEvents();
                frmApp.Refresh();
            }
        }
    }
}
