namespace NalogUser
{
    partial class FormApp
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
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.картаРФToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.показателиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.абсолютныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.населениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.налоговыеДоходыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доходПоНалогуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поВидуДеятельностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.относительныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показательКДолToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отклонения1НМИ1НОМToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показательОПИНToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.населениеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.насилениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.налоговыйДоходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 693);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(946, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "Главный статус-бар";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.картаРФToolStripMenuItem1,
            this.показателиToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem1});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(946, 24);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "Главное меню";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // картаРФToolStripMenuItem1
            // 
            this.картаРФToolStripMenuItem1.Name = "картаРФToolStripMenuItem1";
            this.картаРФToolStripMenuItem1.Size = new System.Drawing.Size(69, 20);
            this.картаРФToolStripMenuItem1.Text = "Карта РФ";
            this.картаРФToolStripMenuItem1.Click += new System.EventHandler(this.картаРФToolStripMenuItem1_Click);
            // 
            // показателиToolStripMenuItem
            // 
            this.показателиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.абсолютныеToolStripMenuItem,
            this.относительныToolStripMenuItem});
            this.показателиToolStripMenuItem.Name = "показателиToolStripMenuItem";
            this.показателиToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.показателиToolStripMenuItem.Tag = "rate";
            this.показателиToolStripMenuItem.Text = "Показатели";
            // 
            // абсолютныеToolStripMenuItem
            // 
            this.абсолютныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.населениеToolStripMenuItem,
            this.налоговыеДоходыToolStripMenuItem,
            this.доходПоНалогуToolStripMenuItem,
            this.поВидуДеятельностиToolStripMenuItem});
            this.абсолютныеToolStripMenuItem.Name = "абсолютныеToolStripMenuItem";
            this.абсолютныеToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.абсолютныеToolStripMenuItem.Tag = "absolute";
            this.абсолютныеToolStripMenuItem.Text = "Абсолютные";
            this.абсолютныеToolStripMenuItem.Click += new System.EventHandler(this.абсолютныеToolStripMenuItem_Click);
            // 
            // населениеToolStripMenuItem
            // 
            this.населениеToolStripMenuItem.Name = "населениеToolStripMenuItem";
            this.населениеToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.населениеToolStripMenuItem.Tag = "1";
            this.населениеToolStripMenuItem.Text = "Население";
            this.населениеToolStripMenuItem.Click += new System.EventHandler(this.населениеToolStripMenuItem_Click);
            // 
            // налоговыеДоходыToolStripMenuItem
            // 
            this.налоговыеДоходыToolStripMenuItem.Name = "налоговыеДоходыToolStripMenuItem";
            this.налоговыеДоходыToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.налоговыеДоходыToolStripMenuItem.Tag = "2";
            this.налоговыеДоходыToolStripMenuItem.Text = "Налоговые доходы";
            this.налоговыеДоходыToolStripMenuItem.Click += new System.EventHandler(this.налоговыеДоходыToolStripMenuItem_Click);
            // 
            // доходПоНалогуToolStripMenuItem
            // 
            this.доходПоНалогуToolStripMenuItem.Name = "доходПоНалогуToolStripMenuItem";
            this.доходПоНалогуToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.доходПоНалогуToolStripMenuItem.Tag = "8";
            this.доходПоНалогуToolStripMenuItem.Text = "Доход по налогу";
            this.доходПоНалогуToolStripMenuItem.Click += new System.EventHandler(this.доходПоНалогуToolStripMenuItem_Click);
            // 
            // поВидуДеятельностиToolStripMenuItem
            // 
            this.поВидуДеятельностиToolStripMenuItem.Name = "поВидуДеятельностиToolStripMenuItem";
            this.поВидуДеятельностиToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.поВидуДеятельностиToolStripMenuItem.Tag = "10";
            this.поВидуДеятельностиToolStripMenuItem.Text = "По виду деятельности";
            this.поВидуДеятельностиToolStripMenuItem.Click += new System.EventHandler(this.поВидуДеятельностиToolStripMenuItem_Click);
            // 
            // относительныToolStripMenuItem
            // 
            this.относительныToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показательКДолToolStripMenuItem,
            this.отклонения1НМИ1НОМToolStripMenuItem,
            this.показательОПИНToolStripMenuItem,
            this.населениеToolStripMenuItem1});
            this.относительныToolStripMenuItem.Name = "относительныToolStripMenuItem";
            this.относительныToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.относительныToolStripMenuItem.Tag = "relative";
            this.относительныToolStripMenuItem.Text = "Относительные";
            this.относительныToolStripMenuItem.Click += new System.EventHandler(this.относительныToolStripMenuItem_Click);
            // 
            // показательКДолToolStripMenuItem
            // 
            this.показательКДолToolStripMenuItem.Name = "показательКДолToolStripMenuItem";
            this.показательКДолToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.показательКДолToolStripMenuItem.Tag = "4";
            this.показательКДолToolStripMenuItem.Text = "Показатель КДол";
            this.показательКДолToolStripMenuItem.Click += new System.EventHandler(this.показательКДолToolStripMenuItem_Click);
            // 
            // отклонения1НМИ1НОМToolStripMenuItem
            // 
            this.отклонения1НМИ1НОМToolStripMenuItem.Name = "отклонения1НМИ1НОМToolStripMenuItem";
            this.отклонения1НМИ1НОМToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.отклонения1НМИ1НОМToolStripMenuItem.Tag = "13";
            this.отклонения1НМИ1НОМToolStripMenuItem.Text = "Отклонения 1-НМ и 1-НОМ";
            this.отклонения1НМИ1НОМToolStripMenuItem.Click += new System.EventHandler(this.отклонения1НМИ1НОМToolStripMenuItem_Click);
            // 
            // показательОПИНToolStripMenuItem
            // 
            this.показательОПИНToolStripMenuItem.Name = "показательОПИНToolStripMenuItem";
            this.показательОПИНToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.показательОПИНToolStripMenuItem.Tag = "16";
            this.показательОПИНToolStripMenuItem.Text = "Показатель ОПИН";
            this.показательОПИНToolStripMenuItem.Click += new System.EventHandler(this.показательОПИНToolStripMenuItem_Click);
            // 
            // населениеToolStripMenuItem1
            // 
            this.населениеToolStripMenuItem1.Name = "населениеToolStripMenuItem1";
            this.населениеToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.населениеToolStripMenuItem1.Tag = "17";
            this.населениеToolStripMenuItem1.Text = "Население";
            this.населениеToolStripMenuItem1.Click += new System.EventHandler(this.населениеToolStripMenuItem1_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem});
            this.сервисToolStripMenuItem.Enabled = false;
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // справкаToolStripMenuItem1
            // 
            this.справкаToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem1.Name = "справкаToolStripMenuItem1";
            this.справкаToolStripMenuItem1.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem1.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // насилениеToolStripMenuItem
            // 
            this.насилениеToolStripMenuItem.Name = "насилениеToolStripMenuItem";
            this.насилениеToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // налоговыйДоходToolStripMenuItem
            // 
            this.налоговыйДоходToolStripMenuItem.Name = "налоговыйДоходToolStripMenuItem";
            this.налоговыйДоходToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.налоговыйДоходToolStripMenuItem.Text = "Налоговый доход";
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(946, 715);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ИАС \"Налог\"";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormApp_FormClosed);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem насилениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem налоговыйДоходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показателиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem абсолютныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem относительныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem картаРФToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem населениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem налоговыеДоходыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem доходПоНалогуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поВидуДеятельностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показательКДолToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отклонения1НМИ1НОМToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показательОПИНToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem населениеToolStripMenuItem1;


    }
}

