namespace NalogUser.Forms
{
    partial class FormReport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewerData = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btHide = new System.Windows.Forms.Button();
            this.btView = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btParams = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewerData
            // 
            this.reportViewerData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerData.Location = new System.Drawing.Point(0, 0);
            this.reportViewerData.Name = "reportViewerData";
            this.reportViewerData.Size = new System.Drawing.Size(963, 370);
            this.reportViewerData.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.btHide);
            this.splitContainer.Panel1.Controls.Add(this.btView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.reportViewerData);
            this.splitContainer.Size = new System.Drawing.Size(963, 583);
            this.splitContainer.SplitterDistance = 209;
            this.splitContainer.TabIndex = 6;
            // 
            // btHide
            // 
            this.btHide.Location = new System.Drawing.Point(84, 193);
            this.btHide.Name = "btHide";
            this.btHide.Size = new System.Drawing.Size(75, 23);
            this.btHide.TabIndex = 1;
            this.btHide.Text = "Скрыть";
            this.btHide.UseVisualStyleBackColor = true;
            this.btHide.Click += new System.EventHandler(this.btHide_Click);
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(3, 193);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(75, 23);
            this.btView.TabIndex = 0;
            this.btView.Text = "Выбрать";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btParams);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 51);
            this.panel1.TabIndex = 7;
            // 
            // btParams
            // 
            this.btParams.Location = new System.Drawing.Point(12, 12);
            this.btParams.Name = "btParams";
            this.btParams.Size = new System.Drawing.Size(75, 23);
            this.btParams.TabIndex = 0;
            this.btParams.Text = "Параметры";
            this.btParams.UseVisualStyleBackColor = true;
            this.btParams.Click += new System.EventHandler(this.btParams_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 583);
            this.panel2.TabIndex = 8;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 634);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormReport_KeyPress);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewerData;
        public Microsoft.Reporting.WinForms.ReportDataSource reportDataSource;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.Button btHide;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btParams;
        private System.Windows.Forms.Panel panel2;

    }
}