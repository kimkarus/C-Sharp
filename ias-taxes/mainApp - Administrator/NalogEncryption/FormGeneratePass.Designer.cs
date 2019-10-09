namespace NalogEncryption
{
    partial class FormGeneratePass
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
            this.textBoxEncryptor = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.btGen = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.textBoxDecryptor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelCountExp = new System.Windows.Forms.Label();
            this.txtI = new System.Windows.Forms.TextBox();
            this.txtJ = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton1Return = new System.Windows.Forms.RadioButton();
            this.radioButtonNotReturn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBoxEncryptor
            // 
            this.textBoxEncryptor.Location = new System.Drawing.Point(12, 12);
            this.textBoxEncryptor.Multiline = true;
            this.textBoxEncryptor.Name = "textBoxEncryptor";
            this.textBoxEncryptor.Size = new System.Drawing.Size(122, 79);
            this.textBoxEncryptor.TabIndex = 0;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 240);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(260, 85);
            this.textBoxOutput.TabIndex = 1;
            // 
            // btGen
            // 
            this.btGen.Location = new System.Drawing.Point(13, 151);
            this.btGen.Name = "btGen";
            this.btGen.Size = new System.Drawing.Size(122, 33);
            this.btGen.TabIndex = 2;
            this.btGen.Text = "Шифровать";
            this.btGen.UseVisualStyleBackColor = true;
            this.btGen.Click += new System.EventHandler(this.btGen_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(197, 331);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "Закрыть";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // textBoxDecryptor
            // 
            this.textBoxDecryptor.Location = new System.Drawing.Point(141, 13);
            this.textBoxDecryptor.Multiline = true;
            this.textBoxDecryptor.Name = "textBoxDecryptor";
            this.textBoxDecryptor.Size = new System.Drawing.Size(131, 52);
            this.textBoxDecryptor.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Расшифровать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCountExp
            // 
            this.labelCountExp.AutoSize = true;
            this.labelCountExp.Location = new System.Drawing.Point(141, 78);
            this.labelCountExp.Name = "labelCountExp";
            this.labelCountExp.Size = new System.Drawing.Size(0, 13);
            this.labelCountExp.TabIndex = 6;
            // 
            // txtI
            // 
            this.txtI.Location = new System.Drawing.Point(12, 125);
            this.txtI.Name = "txtI";
            this.txtI.Size = new System.Drawing.Size(52, 20);
            this.txtI.TabIndex = 7;
            // 
            // txtJ
            // 
            this.txtJ.Location = new System.Drawing.Point(82, 125);
            this.txtJ.Name = "txtJ";
            this.txtJ.Size = new System.Drawing.Size(52, 20);
            this.txtJ.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton1Return
            // 
            this.radioButton1Return.AutoSize = true;
            this.radioButton1Return.Location = new System.Drawing.Point(13, 102);
            this.radioButton1Return.Name = "radioButton1Return";
            this.radioButton1Return.Size = new System.Drawing.Size(82, 17);
            this.radioButton1Return.TabIndex = 10;
            this.radioButton1Return.TabStop = true;
            this.radioButton1Return.Text = "Обратимая";
            this.radioButton1Return.UseVisualStyleBackColor = true;
            this.radioButton1Return.CheckedChanged += new System.EventHandler(this.radioButton1Return_CheckedChanged);
            // 
            // radioButtonNotReturn
            // 
            this.radioButtonNotReturn.AutoSize = true;
            this.radioButtonNotReturn.Location = new System.Drawing.Point(104, 102);
            this.radioButtonNotReturn.Name = "radioButtonNotReturn";
            this.radioButtonNotReturn.Size = new System.Drawing.Size(94, 17);
            this.radioButtonNotReturn.TabIndex = 11;
            this.radioButtonNotReturn.TabStop = true;
            this.radioButtonNotReturn.Text = "Необратимая";
            this.radioButtonNotReturn.UseVisualStyleBackColor = true;
            this.radioButtonNotReturn.CheckedChanged += new System.EventHandler(this.radioButtonNotReturn_CheckedChanged);
            // 
            // FormGeneratePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 363);
            this.Controls.Add(this.radioButtonNotReturn);
            this.Controls.Add(this.radioButton1Return);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtJ);
            this.Controls.Add(this.txtI);
            this.Controls.Add(this.labelCountExp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDecryptor);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btGen);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxEncryptor);
            this.Name = "FormGeneratePass";
            this.Text = "FormGeneratePass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEncryptor;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button btGen;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox textBoxDecryptor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCountExp;
        private System.Windows.Forms.TextBox txtI;
        private System.Windows.Forms.TextBox txtJ;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1Return;
        private System.Windows.Forms.RadioButton radioButtonNotReturn;
    }
}