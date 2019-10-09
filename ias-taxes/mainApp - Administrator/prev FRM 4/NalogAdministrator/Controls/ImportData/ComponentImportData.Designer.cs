namespace NalogAdministrator.Controls.ImportData
{
    partial class ComponentImportData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "selectFileBrowserDialog";
            this.openFileDialog.Filter = "*.xls|*.XLS";

        }

        #endregion

        public System.Windows.Forms.FolderBrowserDialog selectFolderBrowserDialog;
        public System.Windows.Forms.OpenFileDialog openFileDialog;

    }
}
