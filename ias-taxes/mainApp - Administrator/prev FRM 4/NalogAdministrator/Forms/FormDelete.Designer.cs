namespace NalogAdministrator.Forms
{
    partial class FormDelete
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
            this.richTextBoxIdSubjects = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClearRelativeTables = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxIdSubjects
            // 
            this.richTextBoxIdSubjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxIdSubjects.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxIdSubjects.Name = "richTextBoxIdSubjects";
            this.richTextBoxIdSubjects.Size = new System.Drawing.Size(222, 122);
            this.richTextBoxIdSubjects.TabIndex = 0;
            this.richTextBoxIdSubjects.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxYear);
            this.groupBox1.Controls.Add(this.buttonClearRelativeTables);
            this.groupBox1.Controls.Add(this.richTextBoxIdSubjects);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 250);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Коды субъектов (\";\")";
            // 
            // buttonClearRelativeTables
            // 
            this.buttonClearRelativeTables.Location = new System.Drawing.Point(22, 170);
            this.buttonClearRelativeTables.Name = "buttonClearRelativeTables";
            this.buttonClearRelativeTables.Size = new System.Drawing.Size(122, 23);
            this.buttonClearRelativeTables.TabIndex = 1;
            this.buttonClearRelativeTables.Text = "Очистить таблицы";
            this.buttonClearRelativeTables.UseVisualStyleBackColor = true;
            this.buttonClearRelativeTables.Click += new System.EventHandler(this.buttonClearRelativeTables_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(44, 144);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(100, 20);
            this.textBoxYear.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Год";
            // 
            // FormDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 499);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormDelete";
            this.Text = "FormDelete";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxIdSubjects;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button buttonClearRelativeTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxYear;
    }
}