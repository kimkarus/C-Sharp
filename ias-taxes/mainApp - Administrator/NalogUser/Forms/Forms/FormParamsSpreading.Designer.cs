﻿namespace NalogUser.Forms
{
    partial class FormParamsSpreading
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCountIntervals = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество интервалов";
            // 
            // textBoxCountIntervals
            // 
            this.textBoxCountIntervals.Location = new System.Drawing.Point(146, 6);
            this.textBoxCountIntervals.Name = "textBoxCountIntervals";
            this.textBoxCountIntervals.Size = new System.Drawing.Size(100, 20);
            this.textBoxCountIntervals.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(146, 32);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormParamsSpreading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 68);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxCountIntervals);
            this.Controls.Add(this.label1);
            this.Name = "FormParamsSpreading";
            this.Text = "FormParamsSpreading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCountIntervals;
        private System.Windows.Forms.Button buttonOK;


    }
}