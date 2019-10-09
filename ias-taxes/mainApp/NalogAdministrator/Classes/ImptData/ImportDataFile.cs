using System;
using System.Collections.Generic;
using System.Text;

namespace NalogAdministrator.Classes.ImpData
{
    public class ImportDataFile
    {
        private int index = 0;
        private string fileName = "";
        private string folder = "";
        private string folderFullPath = "";
        private string fileFullPath = "";
        private string type = "";
        private int forcastInterval = 0;
        private string extension = "";
        private int dataYear = 0;
        private int idSubject = 0;
        private int parentIdSubject = 0;
        private string subjectShortName = "";
        private int idDistrict = 0;
        private string districtShortName = "";
        private bool isForcast = false;
        //
        public int Index { get { return index; } set { index = value; } }
        public string FileName { get { return fileName; } set { fileName = value; } }
        public string Folder { get { return folder; } set { folder = value; } }
        public string FolderFullPath { get { return folderFullPath; } set { folderFullPath = value; } }
        public string FileFullPath { get { return fileFullPath; } set { fileFullPath = value; } }
        public string Type { get { return type; } set { type = value; } }
        public bool IsForcast { get { return isForcast; } set { isForcast = value; } }
        public int ForcastInterval { get { return forcastInterval; } set { forcastInterval = value; } }
        public string Extension { get { return extension; } set { extension = value; } }
        public int DataYear { get { return dataYear; } set { dataYear = value; } }
        public int IdSubject { get { return idSubject; } set { idSubject = value; } }
        public int ParentIdSubject { get { return parentIdSubject; } set { parentIdSubject = value; } }
        public string SubjectShortName { get { return subjectShortName; } set { subjectShortName = value; } }
        public int IdDistrict { get { return idDistrict; } set { idDistrict = value; } }
        public string DistrictShortName { get { return districtShortName; } set { districtShortName = value; } }
    }
}
