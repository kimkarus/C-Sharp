namespace NalogUser
{
    partial class FormStarter
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
            this.labelWelcomOfSystemTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.btRelative = new System.Windows.Forms.Button();
            this.btAbsolute = new System.Windows.Forms.Button();
            this.groupBoxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcomOfSystemTop
            // 
            this.labelWelcomOfSystemTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcomOfSystemTop.Location = new System.Drawing.Point(12, 18);
            this.labelWelcomOfSystemTop.Name = "labelWelcomOfSystemTop";
            this.labelWelcomOfSystemTop.Size = new System.Drawing.Size(382, 104);
            this.labelWelcomOfSystemTop.TabIndex = 0;
            this.labelWelcomOfSystemTop.Text = "Вас приветствует информационно-аналитическая система \"Налоги РФ\"";
            this.labelWelcomOfSystemTop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Воспользуйтессь меню для перехода к необходимому разделу:";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(302, 342);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Закрыть";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.Controls.Add(this.btRelative);
            this.groupBoxMenu.Controls.Add(this.btAbsolute);
            this.groupBoxMenu.Location = new System.Drawing.Point(30, 187);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(347, 149);
            this.groupBoxMenu.TabIndex = 3;
            this.groupBoxMenu.TabStop = false;
            this.groupBoxMenu.Text = "Разделы";
            // 
            // btRelative
            // 
            this.btRelative.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRelative.Location = new System.Drawing.Point(6, 83);
            this.btRelative.Name = "btRelative";
            this.btRelative.Size = new System.Drawing.Size(333, 58);
            this.btRelative.TabIndex = 2;
            this.btRelative.Text = "Относительные показатели";
            this.btRelative.UseVisualStyleBackColor = true;
            this.btRelative.Click += new System.EventHandler(this.btRelative_Click);
            // 
            // btAbsolute
            // 
            this.btAbsolute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAbsolute.Location = new System.Drawing.Point(6, 19);
            this.btAbsolute.Name = "btAbsolute";
            this.btAbsolute.Size = new System.Drawing.Size(333, 58);
            this.btAbsolute.TabIndex = 1;
            this.btAbsolute.Text = "Абсолютные показатели";
            this.btAbsolute.UseVisualStyleBackColor = true;
            this.btAbsolute.Click += new System.EventHandler(this.btAbsolute_Click);
            // 
            // FormStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 373);
            this.Controls.Add(this.groupBoxMenu);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWelcomOfSystemTop);
            this.Name = "FormStarter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добро пожаловать";
            this.groupBoxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWelcomOfSystemTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.Button btAbsolute;
        private System.Windows.Forms.Button btRelative;

    }
}