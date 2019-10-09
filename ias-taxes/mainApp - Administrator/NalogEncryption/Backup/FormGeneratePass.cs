using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace NalogEncryption
{
    public partial class FormGeneratePass : Form
    {
        private bool stop = false;
        private bool rdReturn=true;
        public FormGeneratePass()
        {
            InitializeComponent();
            checkRdReturn();
        }
        private void checkRdReturn()
        {
            if (rdReturn)
            {
                this.radioButton1Return.Checked = true;
                this.radioButtonNotReturn.Checked = false;
                rdReturn = true;
            }
            else
            {
                this.radioButtonNotReturn.Checked = true;
                this.radioButton1Return.Checked = false;
                rdReturn = false;
            }
        }

        private void btGen_Click(object sender, EventArgs e)
        {
            string input = "";
            string output = "";
            int i = 0;
            int j = 0;
            try
            {
                i = Convert.ToInt32(this.txtI.Text);
                j = Convert.ToInt32(this.txtJ.Text);
            }
            catch (System.Exception err)
            {
                txtI.Text = "10";
                txtJ.Text = "3";
                i = 10;
                j = 3;
            }
            try
            {
                input = this.textBoxEncryptor.Text;
            }
            catch (System.Exception err)
            {
                return;
            }
            checkRdReturn();
            Classes.Encryption encr = new Classes.Encryption();
            switch (rdReturn)
            {
                case true:
                    {
                        output = encr.Encryptor(input);
                        break;
                    }
                case false:
                    {
                        output = encr.EncryptorSha(input);
                        break;
                    }
            }

            //output = encr.Encryptor(input, i, j);
            //output = encr.Decryptor(input);
            this.textBoxOutput.Text = output;
            StreamWriter streamWr = new StreamWriter(Application.StartupPath.ToString()+"\\settings.bin");
            BinaryWriter binWr = new BinaryWriter(streamWr.BaseStream);
            foreach (byte bt in output)
            {
                binWr.Write(bt);
            }
            binWr.Close();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = "";
            string output = "";
            checkRdReturn();
            try
            {
                input = this.textBoxDecryptor.Text;
            }
            catch (System.Exception err)
            {
                return;
            }
            Classes.Encryption encr = new Classes.Encryption();
            switch (rdReturn)
            {
                case true:
                    {
                        output = encr.Decryptor(input);
                        break;
                    }
                case false:
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            for (int j = 0; j < 100; j++)
                            {
                                output = encr.Decryptor(input, i, j);
                                this.labelCountExp.Text = i + " / 100; /n" + j + " / 100";
                                if (output != "error" || stop) break;
                                this.textBoxOutput.Text = output;
                                Application.DoEvents();
                                this.Update();
                                this.Refresh();
                            }
                        }
                        break;
                    }
            }
            //output = encr.Decryptor(input);
            this.textBoxOutput.Text = output;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void radioButton1Return_CheckedChanged(object sender, EventArgs e)
        {
            rdReturn = true;
        }

        private void radioButtonNotReturn_CheckedChanged(object sender, EventArgs e)
        {
            rdReturn = false;
        }
    }
}
