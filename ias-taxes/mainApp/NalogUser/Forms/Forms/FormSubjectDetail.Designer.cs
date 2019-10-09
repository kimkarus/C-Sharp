namespace NalogUser.Forms
{
    partial class FormSubjectDetail
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
            this.tabControlSubjectDetail = new System.Windows.Forms.TabControl();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.SubjectMapElementHost = new System.Windows.Forms.Integration.ElementHost();
            this.subjectDetailMapControl = new NalogUser.Controls.SubjectDetailMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControlSubjectDetail.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSubjectDetail
            // 
            this.tabControlSubjectDetail.Controls.Add(this.tabPageSummary);
            this.tabControlSubjectDetail.Controls.Add(this.tabPage2);
            this.tabControlSubjectDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSubjectDetail.Location = new System.Drawing.Point(0, 0);
            this.tabControlSubjectDetail.Name = "tabControlSubjectDetail";
            this.tabControlSubjectDetail.SelectedIndex = 0;
            this.tabControlSubjectDetail.Size = new System.Drawing.Size(917, 653);
            this.tabControlSubjectDetail.TabIndex = 0;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Controls.Add(this.splitContainer1);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(909, 627);
            this.tabPageSummary.TabIndex = 0;
            this.tabPageSummary.Text = "Общие сведения";
            this.tabPageSummary.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerMain);
            this.splitContainer1.Size = new System.Drawing.Size(903, 621);
            this.splitContainer1.SplitterDistance = 549;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainerMain.Size = new System.Drawing.Size(903, 549);
            this.splitContainerMain.SplitterDistance = 319;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.SubjectMapElementHost);
            this.splitContainer2.Size = new System.Drawing.Size(319, 549);
            this.splitContainer2.SplitterDistance = 379;
            this.splitContainer2.TabIndex = 0;
            // 
            // SubjectMapElementHost
            // 
            this.SubjectMapElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubjectMapElementHost.Location = new System.Drawing.Point(0, 0);
            this.SubjectMapElementHost.Name = "SubjectMapElementHost";
            this.SubjectMapElementHost.Size = new System.Drawing.Size(319, 379);
            this.SubjectMapElementHost.TabIndex = 0;
            this.SubjectMapElementHost.Text = "SubjectDetailElementHost";
            this.SubjectMapElementHost.Child = this.subjectDetailMapControl;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(909, 627);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormSubjectDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 653);
            this.Controls.Add(this.tabControlSubjectDetail);
            this.Name = "FormSubjectDetail";
            this.Text = "FormSubjectDetail";
            this.tabControlSubjectDetail.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSubjectDetail;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Integration.ElementHost SubjectMapElementHost;
        private Controls.SubjectDetailMapControl subjectDetailMapControl;
    }
}