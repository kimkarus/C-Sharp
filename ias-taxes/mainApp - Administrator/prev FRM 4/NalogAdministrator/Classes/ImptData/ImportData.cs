 using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace NalogAdministrator.Classes.ImpData
{
    public class ImportData
    {
        #region Переменные
        private Core cr;
        private base_nalogDataSet ds;
        private Classes.ImpData.Methods.ImportDataReport reportImport;
        private Classes.ImpData.Methods.ImportDataPopulation impPopulation;
        private Classes.ImpData.Methods.ImportDataSubjectIndex impSubjectIndex;
        private Classes.ImpData.ImportDataFile impDataFile;
        private Forms.FormImportData frmImpData;
        private TreeNode treeView;
        private Classes.ImpData.ImportDataVariables var;
        private NalogAdministrator.Controls.UserControlImportDataReportDefaultTools ucImpDataReports;
        private NalogAdministrator.Controls.UserControlImportDataPopulation ucImpDataPopulation;
        private NalogAdministrator.Controls.ImportData.UserControlImportDataSubjectIndex ucImpDataSubjectIndex;
        //
        private string error = "";
        private static string formName = "Форма для переноса данных. ";
        private int indexUC = 0;
        private int lastIndexUC = 0;
        private string treeFolderPath = "";
        private int indexerFile = 0;
        //
        private List<string> listPathFiles = new List<string>();
        private List<string> listTablesView;
        //
        private EventChangeIndexRecord eveChIndexRec;
        private EventChangeStatus eveChStatus;
        private EventDefineCountRecords eveDefCountRec;
        private EventChangeCountFiles eveChCountFiles;
        private EventChangeIndexFile eveChIndexFile;
        private EventChangeNameDistrict eveChNameDistrict;
        private EventChangeNameSubject eveChNameSubject;
        private EventChangeNameSheet eveChNameSheet;
        private EventChangeYear eveChYear;
        private EventChangeTypeReport eveChTypeReport;
        #region Глобальные
        //
        public delegate void EventChangeIndexRecord(int index);
        public delegate void EventChangeStatus(string status, bool equal);
        public delegate void EventDefineCountRecords(int count);
        public delegate void EventChangeCountFiles(int count);
        public delegate void EventChangeIndexFile(int index, int count);
        public delegate void EventChangeNameDistrict(string district);
        public delegate void EventChangeNameSubject(string subject);
        public delegate void EventChangeNameSheet(string sheet);
        public delegate void EventChangeYear(string year);
        public delegate void EventChangeTypeReport(string type);
        public Classes.ImpData.Methods.ImportDataReport mReportImport { get { return reportImport; } set { reportImport = value; } }
        public Classes.ImpData.Methods.ImportDataPopulation ImpPopulation { get { return impPopulation; } set { impPopulation = value; } }
        public Classes.ImpData.Methods.ImportDataSubjectIndex ImpSubjectIndex { get { return impSubjectIndex; } set { impSubjectIndex = value; } }
        public TreeNode TreeView { get { return treeView; } }
        public string Error { get { return error; } }
        public Classes.ImpData.ImportDataFile ImpDataFile { get { return impDataFile; } set { impDataFile = value; } }
        public List<string> ListTablesView { get { return listTablesView; } }
        public EventChangeIndexRecord EveChIndexRec { get { return eveChIndexRec; } set { eveChIndexRec = value; } }
        public EventChangeStatus EveChStatus { get { return eveChStatus; } set { eveChStatus = value; } }
        public EventDefineCountRecords EveDefCountRec { get { return eveDefCountRec; } set { eveDefCountRec = value; } }
        public EventChangeCountFiles EveChCountFiles { get { return eveChCountFiles; } set { eveChCountFiles = value; } }
        public EventChangeIndexFile EveChIndexFile { get { return eveChIndexFile; } set { eveChIndexFile = value; } }
        public EventChangeNameDistrict EveChNameDistrict { get { return eveChNameDistrict; } set { eveChNameDistrict = value; } }
        public EventChangeNameSubject EveChNameSubject { get { return eveChNameSubject; } set { eveChNameSubject = value; } }
        public EventChangeNameSheet EveChNameSheet { get { return eveChNameSheet; } set { eveChNameSheet = value; } }
        public EventChangeYear EveChYear { get { return eveChYear; } set { eveChYear = value; } }
        public EventChangeTypeReport EveChTypeReport { get { return eveChTypeReport; } set { eveChTypeReport = value; } }
        public Classes.ImpData.ImportDataVariables Var { get { return var; } set { var = value; } }
        public List<string> ListPathFiles { get { return listPathFiles; } set { listPathFiles = value; } }
        #endregion Глобальные
        #endregion Переменные   
        #region Конструктор
        public ImportData(Core Cr, string Tag)
        {
            this.cr = Cr;
            cr.Data = new Data();
            this.ds = cr.Data.Base.Ds;
            eveChIndexRec = new EventChangeIndexRecord(OnChangeIndexRecord);
            eveChStatus = new EventChangeStatus(OnChangeStatus);
            eveDefCountRec = new EventDefineCountRecords(OnDefineCountRecortds);
            eveChCountFiles = new EventChangeCountFiles(OnChangeCountFiles);
            eveChIndexFile = new EventChangeIndexFile(OnChangeIndexFile);
            eveChNameDistrict = new EventChangeNameDistrict(OnChangeNameDistrict);
            eveChNameSubject = new EventChangeNameSubject(OnChangeNameSubject);
            eveChNameSheet = new EventChangeNameSheet(OnChangeSheet);
            eveChYear = new EventChangeYear(OnChangeYear);
            eveChTypeReport = new EventChangeTypeReport(OnChangeTypeReport);
            var = new Classes.ImpData.ImportDataVariables(cr,this);
            SwitchImportDataMetod(Tag);
        }
        public ImportData(Core Cr)
        {
            this.cr = Cr;
            eveChIndexRec = new EventChangeIndexRecord(OnChangeIndexRecord);
            eveChStatus = new EventChangeStatus(OnChangeStatus);
            eveDefCountRec = new EventDefineCountRecords(OnDefineCountRecortds);
            eveChCountFiles = new EventChangeCountFiles(OnChangeCountFiles);
            eveChIndexFile = new EventChangeIndexFile(OnChangeIndexFile);
            eveChNameDistrict = new EventChangeNameDistrict(OnChangeNameDistrict);
            eveChNameSubject = new EventChangeNameSubject(OnChangeNameSubject);
            eveChNameSheet = new EventChangeNameSheet(OnChangeSheet);
            eveChYear = new EventChangeYear(OnChangeYear);
            eveChTypeReport = new EventChangeTypeReport(OnChangeTypeReport);
            var = new Classes.ImpData.ImportDataVariables(cr, this);
        }
        #endregion
        #region Методы
        private void SwitchImportDataMetod(string tag)
        {
            /*
             * Этот модуль переключает необходимые модули и создает их объекты
             * */
            indexUC = defineIndexControl(tag);
            if (frmImpData == null || frmImpData.IsDisposed == true)
            {

                FormImportDataSetProperties(SwitchControl(indexUC));
            }
            else
            {
                if (lastIndexUC != indexUC)
                {
                    frmImpData.Controls.Clear();
                    SwitchControl(indexUC);
                    frmImpData.Refresh();
                    frmImpData.Focus();
                }
                else
                {
                    frmImpData.Refresh();
                    frmImpData.Focus();
                }
            }
        }
        private void FormImportDataSetProperties(Control control)
        {
            /*
             * Эта процедура нужна для первоначальной настройи формы в котором открывается модуль
             * */
            frmImpData = new Forms.FormImportData();
            frmImpData.MdiParent = cr.FrmApp;
            control.Name = var.UcName;
            frmImpData.Controls.Add(control);
            frmImpData.Height = control.Height + frmImpData.Padding.Bottom + frmImpData.Padding.Top+frmImpData.statusStripImportData.Height+frmImpData.btClose.Height + 40;
            frmImpData.Width = control.Width + frmImpData.Padding.Left + frmImpData.Padding.Right + 20;
            frmImpData.Location = new System.Drawing.Point(frmImpData.Padding.Left, frmImpData.Padding.Top);
            frmImpData.Text = formName + " " + var.UcName;
            frmImpData.btClose.Location = new System.Drawing.Point(control.Width + frmImpData.Padding.Left - frmImpData.btClose.Width,
                control.Height + frmImpData.Padding.Bottom + frmImpData.Padding.Top);
            frmImpData.Show();
            lastIndexUC = indexUC;
        }
        private void GetTreeFolder(string Path)
        {
            /*
             * функция для составления древа папки
             * ограничение вложенности до 3-х уровней
             * */
            if (Path != "")
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(Path);
                    ScanDirectories(di);
                }
                catch (System.Exception err)
                {
                }
            }
        }
        private void ScanDirectories(DirectoryInfo di)
        {
            /*
             * Процедура создает древо папок для 
             * поля с папками
             * */
            foreach (DirectoryInfo dir1 in di.GetDirectories())
            {
                TreeNode tree1 = new TreeNode(dir1.Name);
                DirectoryInfo di2 = new DirectoryInfo(dir1.FullName);
                tree1.Tag = dir1.FullName;
                foreach (DirectoryInfo dir2 in di2.GetDirectories())
                {
                    TreeNode tree2 = new TreeNode(dir2.Name);
                    tree2.Tag = dir2.FullName;
                    DirectoryInfo di3 = new DirectoryInfo(dir2.FullName);
                    foreach (DirectoryInfo dir3 in di3.GetDirectories())
                    {
                        TreeNode tree3 = new TreeNode(dir3.Name);
                        tree3.Tag = di3.FullName;
                        tree2.Nodes.Add(tree3);
                    }
                    tree1.Nodes.Add(tree2);
                }
                treeView.Nodes.Add(tree1);
            }
        }
        private void AddFileInList(string path, string folder)
        {
            /*bool err = false;
            try
            {
                treeFolderPath = path;
                GetListFiles(folder + "\\" + treeFolderPath);
            }
            catch (System.Exception errExc)
            {
                err = true;
            }
            if (!err)
            {
                listFilesView = new List<string>();
                for (int i = 0; i < listPathFiles.Count; i++)
                {
                    FileInfo flInfo = new FileInfo(listPathFiles[i].ToString());
                    listFilesView.Add(treeFolderPath + "\\" + flInfo.Name);
                }
            }*/
        }
        private void ScanDirectoriesFiles(DirectoryInfo di)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                if (checkFileExtentions(fi.Extension) && !checkFileExtentions(fi.Directory.Name))
                {
                    impDataFile = new ImportDataFile();
                    impDataFile.Index = indexerFile++;
                    impDataFile.Folder = fi.Directory.Name;
                    impDataFile.FolderFullPath = fi.DirectoryName;
                    impDataFile.FileFullPath = fi.FullName;
                    impDataFile.FileName = fi.Name;
                    impDataFile.Extension = fi.Extension;
                    impDataFile.Type = defineParamFileType(fi.Name);
                    impDataFile.ForcastInterval = defineForcastInterval(fi.Name);
                    if (impDataFile.ForcastInterval > 0) { impDataFile.IsForcast = true; } else { impDataFile.IsForcast = false; }
                    impDataFile.DataYear = defineParamFileYear(fi.Name);
                    impDataFile.IdSubject = defineParamSubjId(impDataFile.Folder, cr.Data.Base.Ds.Subjects.short_nameColumn.ToString(),"","","");
                    impDataFile.ParentIdSubject = var.ParentIdSubjNow;
                    impDataFile.IdDistrict = defineParamIdDistrict(impDataFile.IdSubject);
                    var.LibraryFiles.Add(impDataFile);
                }
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                ScanDirectoriesFiles(dir);
            }
        }
        private bool checkFileExtentions(string ext="")
        {
            int need = 0;
            string[] exts = new string[] { ".xls", "xlsx" };
            foreach (string str in exts)
            {
                if(str.ToUpper() == ext.ToUpper())
                {
                    need++;
                }
            }
            if (need > 0) { return true; } else { return false; }
        }
        private bool checkExcludeFolders(string fld = "")
        {
            int need = 0;
            string[] flds = new string[] { "Архив" };
            foreach (string str in flds)
            {
                if (str.ToUpper() == fld.ToUpper())
                {
                    need++;
                }
            }
            if (need > 0) { return true; } else { return false; }
        }
        private void OpenData(int selectedIndex)
        {
            listTablesView = new List<string>();
            if (listPathFiles.Count > 0)
            {
                listTablesView.Clear();
                if (selectedIndex > -1)
                {
                    LoadExcelSchema(listPathFiles[selectedIndex].ToString());
                    for (int i = 0; i < var.ExcelSheets.Length; i++)
                    {
                        listTablesView.Add(var.ExcelSheets[i]);
                    }
                }

            }
        }
        #endregion Методы
        #region Функции
        private Control SwitchControl(int index)
        {
            /*
             * Этот модуль переключает необходимые контроллы и создает их объекты
             * */
            Control cntr = new Control();
            switch (index)
            {
                case 1:
                    {
                        ucImpDataReports = new Controls.UserControlImportDataReportDefaultTools(cr);
                        reportImport = new Classes.ImpData.Methods.ImportDataReport(cr, cr.Data, this, var, var.UcTag, ucImpDataReports);
                        cntr = ucImpDataReports;
                        break;
                    }
                case 3:
                    {
                        ucImpDataPopulation = new Controls.UserControlImportDataPopulation(cr);
                        impPopulation = new Classes.ImpData.Methods.ImportDataPopulation(cr, this, var, var.UcTag, ucImpDataPopulation);
                        cntr = ucImpDataPopulation;
                        break;
                    }
                case 4:
                    {
                        ucImpDataSubjectIndex = new Controls.ImportData.UserControlImportDataSubjectIndex(cr);
                        impSubjectIndex = new Classes.ImpData.Methods.ImportDataSubjectIndex(cr, this, var, var.UcTag, ucImpDataSubjectIndex);
                        cntr = ucImpDataSubjectIndex;
                        break;
                    }
            }
            return cntr;
        }
        private int defineIndexControl(string tag)
        {
            int index = 0;
            switch(tag)
            {
                case "taxReport":
                    {
                        index = 1;
                        var.UcName = "Налоговая отчетность";
                        var.UcTag = tag;
                        break;
                    }
                case "population":
                    {
                        index = 3;
                        var.UcName = "Население";
                        var.UcTag = tag;
                        break;
                    }
                case "subjectIndex":
                    {
                        index = 4;
                        var.UcName = "Показатели";
                        var.UcTag = tag;
                        break;
                    }

            }
            
            return index;
        }
        public int defineParamSubjId(string name, string colSubject, string col2="", string col3="", string col4="")
        {
            int find = 0;
            int pid = 0;
            string[] filterParams = new string[] { colSubject, col2, col3, col4 };
            int countFind = 0;
            //создаем фильтр
            for (int i = 0; i < filterParams.Length; i++)
            {
                if (countFind >= 1)
                { break; }
                if (filterParams[i] != "")
                {
                    string filter = string.Format(filterParams[i] + " = '{0}'", name);
                    //фильтуруем строки по значению
                    DataRow[] subjRow = ds.Subjects.Select();
                    foreach (DataRow row in subjRow)
                    {
                        bool match = false;
                        if (col2.Length > 0)
                        {
                            if (row[ds.Subjects.Columns[colSubject]].ToString().Replace(" ", string.Empty) == name.Replace(" ", string.Empty) ||
                                row[ds.Subjects.Columns[col2]].ToString().Replace(" ", string.Empty) == name.Replace(" ", string.Empty))
                            {
                                match = true;
                            }
                        }
                        if (col3.Length > 0)
                        {
                            if (row[ds.Subjects.Columns[col3]].ToString().Replace(" ", string.Empty) == name.Replace(" ", string.Empty))
                            {
                                match = true;
                            }
                        }
                        if (col4.Length > 0)
                        {
                            if (row[ds.Subjects.Columns[col4]].ToString().Replace(" ", string.Empty) == name.Replace(" ", string.Empty))
                            {
                                match = true;
                            }
                        }
                        else if (colSubject.Length > 0)
                        {
                            if (row[ds.Subjects.Columns[colSubject]].ToString().Replace(" ", string.Empty) == name.Replace(" ", string.Empty))
                            {
                                match = true;
                            }
                        }
                        else
                        {
                            match = false;
                        }
                        if (match)
                        {
                            //ловим необходимое значение
                            find = Convert.ToInt32(row[ds.Subjects.idColumn]);
                            if (impDataFile != null)
                            {
                                impDataFile.SubjectShortName = row[ds.Subjects.short_nameColumn].ToString();

                            }
                            pid = defineParentIdSubject(find);
                            countFind++;
                        }
                    }
                }
            }
            var.IdSubjNow = find;
            var.ParentIdSubjNow = pid;
            //присваиваем значение
            return find;
        }
        public int defineParentIdSubject(int idSubject)
        {
            int pid = 0;
            DataRow parentSubject = ds.Subjects.FindByid(idSubject);
            try
            {
                pid = Convert.ToInt32(parentSubject[ds.Subjects.parentColumn]);
            }
            catch (System.Exception err)
            {
                pid = 0;
            }
            return pid;
        }
        private int defineForcastInterval(string name)
        {
            int interval = 0;
            if (impDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast ||
                impDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NOMForcast)
            {

                string[] array = name.Split('-');
                try
                {
                    interval = Convert.ToInt32(array[2]);
                }
                catch (System.Exception err)
                {
                    interval = 12;
                }

            }
            return interval;
        }

        private int defineParamFileYear(string name)
        {
            /*
             * Функция, которая вырезает год из имени файла
             * */
            int year = 0;
            //if(impDataFile.Type
            if (impDataFile.Type.Length < 1)
                return 0;
            string str = "";
            if (impDataFile.Type == NalogAdministrator.Properties.Settings.Default.Report1NMForcast)
            {
                str = name.Substring(impDataFile.Type.Length + impDataFile.ForcastInterval.ToString().Length + 2, name.Length - impDataFile.Type.Length - impDataFile.Extension.Length - impDataFile.ForcastInterval.ToString().Length - 2);
            }
            else
            {
                str = name.Substring(impDataFile.Type.Length, name.Length - impDataFile.Type.Length - impDataFile.Extension.Length);
            }
            try
            {
                year = Convert.ToInt32(str);
            }
            catch (System.Exception err)
            {
            }
            return year;
        }
        private string defineParamFileType(string name)
        {
            /*
             * Функция, которая определяет принадлежность файла к виду налог отчетности
             * */
            string type = "";
            List<bool> likeType = new List<bool>();
            foreach (string str in NalogAdministrator.Properties.Settings.Default.TypeReports)
            {
                type = "";
                if (str.Length > name.Length)
                    break;
                type = name.Substring(0, str.Length);
                bool tr = String.Equals(type.ToUpper(), str.ToUpper());
                likeType.Add(tr);
            }
            for (int i = 0; i < likeType.Count; i++)
            {
                if (likeType[i])
                    type = NalogAdministrator.Properties.Settings.Default.TypeReports[i];
            }
            return type;
        }
        private int defineParamIdDistrict(int index)
        {
            int find = 0;
            if (index > 0)
            {
                string filter = string.Format("id = '{0}'", index);
                DataRow[] row = ds.Subjects.Select(filter);
                find = Convert.ToInt32(row[0][ds.Subjects.id_districtColumn]);
                var.IdDistrictNow = find;
            }
            return find;
        }
        private string CutPathFolderString(string folderPath, string filePath)
        {
            string path = "";
            if (folderPath.Length <= filePath.Length)
            {
                path = filePath.Substring(0, folderPath.Length);
            }
            return path;
        }
        #region Глобальные
        public string ClearStrExcelTable(string inbox)
        {
            string str = inbox;
            int i = 0;
            int len = str.Length;
            for (i = 0; i < len; i++)
            {
                if (str.Substring(i, 1) == "$" ||
                    str.Substring(i, 1) == "'")
                {
                    str = str.Remove(i, 1);
                    str = str.Trim();
                    i = 0;
                    len = str.Length;
                }
            }
            str = str.Trim();
            return str;
        }
        public string ClearSpacesStrExcelTable(string inbox)
        {
            string str = inbox;
            int i = 0;
            int len = str.Length;
            for (i = 0; i < len; i++)
            {
                if (str.Substring(i, 1) == "$" ||
                    str.Substring(i, 1) == "'" ||
                    str.Substring(i, 1) == " ")
                {
                    str = str.Remove(i, 1);
                    str = str.Trim();
                    i = 0;
                    len = str.Length;
                }
            }
            str = str.Trim();
            return str;
        }
        public void GetListFiles(string Path)
        {
            /*
            * функция для составления пути к файлам в папке
            * ограничение вложенности до 3-х уровней
            * */
            var.LibraryFiles = new ArrayList();
            indexerFile = 0;
            DirectoryInfo di = new DirectoryInfo(Path);
            ScanDirectoriesFiles(di);
        }
        public void LoadExcelSchema(string path)
        {
            try
            {
                cr.Data.Files.ExcelOleDbConn = new System.Data.OleDb.OleDbConnection(cr.Data.Files.connectionString(path));
                cr.Data.Files.ExcelOleDbConn.Open();
                cr.Data.Files.DtExcelMeta = cr.Data.Files.ExcelOleDbConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[4] { null, null, null, "TABLE" });
                cr.Data.Files.ExcelOleDbConn.Close();
            }
            catch (System.Exception Err)
            {
                //this.cr.
            }
        }
        public List<string> GetListSheets(int index)
        {
            OpenData(index);
            return listTablesView;
        }
        public ArrayList GetListFolderFiles(string folderName, string folderPath)
        {
            /*
             * */
            var.LibraryFolderFiles.Clear();
            for (int i = 0; i < var.LibraryFiles.Count; i++)
            {
                impDataFile = (ImportDataFile)var.LibraryFiles[i];
                if (folderPath == CutPathFolderString(folderPath, impDataFile.FileFullPath))
                {
                    var.LibraryFolderFiles.Add(impDataFile);
                }
            }
            var.CountFiles = var.LibraryFolderFiles.Count;
            return var.LibraryFolderFiles;
        }
        public TreeNode GetTreeNode(string path)
        {
            treeView = new TreeNode();
            GetTreeFolder(path);
            return treeView;
        }
        public DataTable ReturnSourceTable(string command = "", string tableName = "")
        {
            DataTable dt = new DataTable();
            if (command.Length > 0)
            {
                cr.Data.Base.SqlConn = new System.Data.SqlClient.SqlConnection();
                cr.Data.Base.SqlConn.ConnectionString = NalogAdministrator.Properties.Settings.Default.base_nalogConnectionString;
                cr.Data.Base.SqlConn.Open();
                cr.Data.Base.SqlCom = cr.Data.Base.SqlConn.CreateCommand();

                cr.Data.Base.SqlCom.CommandText = command;
                cr.Data.Base.SqlDataAdp = new System.Data.SqlClient.SqlDataAdapter(cr.Data.Base.SqlCom);

                dt.TableName = tableName;
                try
                {
                    cr.Data.Base.SqlDataAdp.Fill(dt);
                }
                catch (System.Exception err)
                {
                    string er = err.Message.ToString();
                }
                cr.Data.Base.SqlConn.Close();
            }
            return dt;
        }
        public void DeleteFromSourceTable(string command = "")
        {
            //DataTable dt = new DataTable();
            if (command.Length > 0)
            {
                cr.Data.Base.SqlConn = new System.Data.SqlClient.SqlConnection();
                cr.Data.Base.SqlConn.ConnectionString = NalogAdministrator.Properties.Settings.Default.base_nalogConnectionString;
                cr.Data.Base.SqlConn.Open();
                cr.Data.Base.SqlCom = cr.Data.Base.SqlConn.CreateCommand();

                cr.Data.Base.SqlCom.CommandText = command;
                cr.Data.Base.SqlDataAdp = new System.Data.SqlClient.SqlDataAdapter(cr.Data.Base.SqlCom);
                try
                {
                    cr.Data.Base.SqlDataAdp.DeleteCommand = cr.Data.Base.SqlConn.CreateCommand();
                    cr.Data.Base.SqlDataAdp.DeleteCommand.CommandText = command;
                    cr.Data.Base.SqlDataAdp.DeleteCommand.ExecuteNonQuery();
                }
                catch (System.Exception err)
                {
                    string er = err.Message.ToString();
                }
                cr.Data.Base.SqlConn.Close();
            }
            //return dt;
        }
        public float returnNullFloat(object rangeValue, int round)
        {
            float value = 0;
            double valueD = 0;
            try
            {
                value = Convert.ToSingle(rangeValue);
            }
            catch (System.Exception err)
            {
                value = 0;
            }
            if (round > 0)
            {
                valueD = Convert.ToDouble(value);
                valueD = Math.Round(value, round);
            }
            
            return (float)valueD;
        }
        public decimal returnAbsDecimal(decimal value = 0)
        {
            if (value >= 0) return value;
            value = value * -1;

            return value;
        }
        public decimal returnNullDecimal(object rangeValue, int round=2)
        {
            decimal value = 0;
            try
            {
                value = Convert.ToDecimal(rangeValue);
            }
            catch (System.Exception err)
            {
                value = 0;
            }
            if (round > 0)
            {
                value = Math.Round(value, round);
            }

            return value;
        }
        public double returnNullDouble(object rangeValue, int round = 2)
        {
            double value = 0;
            try
            {
                value = Convert.ToDouble(rangeValue);
            }
            catch (System.Exception err)
            {
                value = 0;
            }
            if (round > 0)
            {
                if (round > 15) round = 15;
                value = Math.Round(value, round);
            }
            if (value.ToString().Length - 1 > 28)
            {
                int delta = value.ToString().Length - 1 - 28;
                int newRound = 15 - delta;
                value = Math.Round(value, newRound);
            }
            return value;
        }
        public int returnNullInt(object rangeValue)
        {
            int value = 0;
           
            try
            {
                value = Convert.ToInt32(rangeValue);
            }
            catch (System.Exception err)
            {
                value = 0;
            }
             
            return value;
        }
        public bool returnNullBool(object rangeValue)
        {
            bool value = false;
            try
            {
                value = Convert.ToBoolean(rangeValue);
            }
            catch (System.Exception err)
            {
                value = false;
            }

            return value;
        }
        public string returnReplaceString(string str, string[] chars)
        {
            foreach (string ch in chars)
            {
                str = str.Replace(ch, "");
            }
            return str;
        }
        #endregion Глобальные
        #endregion Функции    
        #region События
        private void OnChangeIndexRecord(int index)
        {
            frmImpData.toolStripProgressBarView.Value = index;
            Application.DoEvents();
        }
        private void OnChangeStatus(string state, bool equal)
        {
            if (!equal)
            {
                frmImpData.toolStripStatusLblStatusIs.Text = state;
            }
        }
        private void OnDefineCountRecortds(int count)
        {
            
            frmImpData.toolStripProgressBarView.Maximum = count;
            frmImpData.Refresh();
        }
        private void OnChangeCountFiles(int count)
        {
            frmImpData.toolStripProgressBarAll.Maximum = count;
            frmImpData.Refresh();
        }
        private void OnChangeIndexFile(int index, int count)
        {
            frmImpData.toolStripProgressBarAll.Value = index;

            Application.DoEvents();
            frmImpData.Refresh();
        }
        private void OnChangeTypeReport(string type)
        {
            frmImpData.toolStripStatusLblType.Width = type.Length * 10;
            frmImpData.toolStripStatusLblType.Text = type;
            Application.DoEvents();
            frmImpData.Refresh();
        }
        private void OnChangeNameDistrict(string district)
        {
            frmImpData.toolStripStatusLblDistrict.Width = district.Length*10;
            frmImpData.toolStripStatusLblDistrict.Text = district;
            Application.DoEvents();
            frmImpData.Refresh();
        }
        private void OnChangeNameSubject(string subject)
        {
            frmImpData.toolStripStatusLblSubject.Width = subject.Length*10;
            frmImpData.toolStripStatusLblSubject.Text = subject;
            Application.DoEvents();
            frmImpData.Refresh();
        }
        private void OnChangeSheet(string sheet)
        {
            frmImpData.toolStripStatusLblSheet.Width = sheet.Length*10;
            frmImpData.toolStripStatusLblSheet.Text = sheet;
            Application.DoEvents();
            frmImpData.Refresh();
        }
        private void OnChangeYear(string year)
        {
            frmImpData.toolStripStatusLblYear.Width = year.Length*10;
            frmImpData.toolStripStatusLblYear.Text = year;
            Application.DoEvents();
            frmImpData.Refresh();
        }
        #region Глобальные

        #endregion Глобальные
        #endregion События
    }
}
