using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace NalogUser
{
    public partial class FormLogin : Form
    {
        int countTrial = 0;
        DataTable dt;
        Login lg;
        Classes.Core cr;
        public FormLogin(Classes.Core Cr)
        {
            this.cr = Cr;
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string login = "";
            string password = "";
            bool step = false;
            int countStep = 0;
            #region Проверки входных значений
            try
            {
                login = this.textBoxLogin.Text;
                password = this.textBoxPassword.Text;
            }
            catch (System.Exception err)
            {
                return;
            }
            if (password.Length < 1)
            {
                password = NalogUser.App.Default.MasterKey.ToString();
            }
            #endregion Проверки входных значений
            if (countTrial > 3) Application.Exit();
            if (login.Length > 3 &&
                password.Length > 6)
            {
                #region Необратимая функция
                Classes.Encryption encr = new Classes.Encryption();
                if (NalogUser.App.Default.MasterKey.Length > 1)
                {
                    password = NalogUser.App.Default.MasterKey.ToString();
                }
                else
                {
                    password = encr.EncryptorSha(password);
                }
                #endregion Необратимая функция
                #region Получаем данные пользователя из БД
                if (cr.B.IsSql)
                {
                    //SQL
                    cr.B.BaseSql.DbConn = new SqlConnection(NalogUser.App.Default.ConnectionString.ToString());
                    cr.B.BaseSql.DbConn.Open();
                    cr.B.BaseSql.DbCom = cr.B.BaseSql.DbConn.CreateCommand();
                    cr.B.BaseSql.DbCom.CommandText = "SELECT id, login, password, name, surname, lastname, activated, online From Users Where (login='" + login + "')";
                    cr.B.BaseSql.DbDataAdp = new SqlDataAdapter(cr.B.BaseSql.DbCom);
                 }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    cr.B.BaseOleDb.DbConn = new OleDbConnection(NalogUser.App.Default.ConnectionString.ToString());
                    cr.B.BaseOleDb.DbConn.Open();
                    cr.B.BaseOleDb.DbCom = cr.B.BaseOleDb.DbConn.CreateCommand();
                    cr.B.BaseOleDb.DbCom.CommandText = "SELECT id, login, password, name, surname, lastname, activated, online From Users Where (login='" + login + "')";
                    cr.B.BaseOleDb.DbDataAdp = new OleDbDataAdapter(cr.B.BaseOleDb.DbCom);
                }
                dt = new System.Data.DataTable();
                if (cr.B.IsSql)
                {
                    //SQL
                    cr.B.BaseSql.DbDataAdp.Fill(dt);
                    cr.B.BaseSql.DbConn.Close();
                }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    cr.B.BaseOleDb.DbDataAdp.Fill(dt);
                    cr.B.BaseOleDb.DbConn.Close();
                }
                #endregion Получаем данные пользователя из БД
                step = true;
                if (dt.Rows.Count > 0)
                {
                    lg = fillUser();
                    #region Проверка пароля
                    string returnPass = dt.Rows[0]["password"].ToString();
                    int lenPass = returnPass.Length;
                    if (lenPass == password.Length)
                    {
                        for (int i = 0; i < lenPass; i++)
                        {
                            if (returnPass[i] == password[i])
                            {
                                countStep++;
                            }
                        }
                    }
                    else { countTrial++; step = false; }
                    if (countStep < lenPass) { step = false; countTrial++; }
                    #endregion Проверка пароля
                }
                else { step = false; countTrial++; }
            }
            else { countTrial++; }
            if (step)
            {
                countTrial = 0;
                FormApp app = new FormApp(lg, this, cr);
                app.Show();
                this.Hide();
                lg.UserActivated = true;

                if (cr.B.IsSql)
                {
                    //SQL
                    cr.B.BaseSql.DbConn = new SqlConnection(NalogUser.App.Default.ConnectionString.ToString());
                    cr.B.BaseSql.DbConn.Open();
                    cr.B.BaseSql.DbCom = cr.B.BaseSql.DbConn.CreateCommand();
                    cr.B.BaseSql.DbCom.CommandText = "UPDATE users SET activated='" + lg.UserActivated + "' Where (id='" + lg.UserId + "')";
                    cr.B.BaseSql.DbCom.ExecuteScalar();
                    cr.B.BaseSql.DbConn.Close();
                }
                if (cr.B.IsOledb)
                {
                    //OLEDB
                    cr.B.BaseOleDb.DbConn = new System.Data.OleDb.OleDbConnection(NalogUser.App.Default.ConnectionString.ToString());
                    cr.B.BaseOleDb.DbConn.Open();
                    cr.B.BaseOleDb.DbCom = cr.B.BaseOleDb.DbConn.CreateCommand();
                    cr.B.BaseOleDb.DbCom.CommandText = "UPDATE users SET activated=" + lg.UserActivated + " Where (id=" + lg.UserId + ")";
                    cr.B.BaseOleDb.DbCom.ExecuteScalar();
                    cr.B.BaseOleDb.DbConn.Close();
                }
            }
            else
            {
                MessageBox.Show("Доступ закрыт.\nОбратитесь к администратору.");
            }
        }
        private Login fillUser()
        {
            Login lg = new Login();
            if (dt.Rows[0]["name"] != System.DBNull.Value) { lg.UserName = dt.Rows[0]["name"].ToString(); }
            if (dt.Rows[0]["id"] != System.DBNull.Value) { lg.UserId = (int)dt.Rows[0]["id"]; }
            if (dt.Rows[0]["login"] != System.DBNull.Value) { lg.UserLogin = (string)dt.Rows[0]["login"]; }
            if (dt.Rows[0]["surname"] != System.DBNull.Value) { lg.UserSurname = (string)dt.Rows[0]["surname"]; }
            if (dt.Rows[0]["lastname"] != System.DBNull.Value) { lg.UserLastname = (string)dt.Rows[0]["lastname"]; }
            if (dt.Rows[0]["online"] != System.DBNull.Value) { lg.UserOnline = (bool)dt.Rows[0]["online"]; }
            //
            return lg;
        }
    }
}
