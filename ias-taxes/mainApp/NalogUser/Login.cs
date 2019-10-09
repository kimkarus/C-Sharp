using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NalogUser
{
    public class Login
    {
        private int userId = 0;
        private string userName = "";
        private string userLogin = "";
        private string userSurname = "";
        private string userLastname = "";
        private bool userActivated = false;
        private bool userOnline = false;
        private DateTime expired_date;
        //
        public int UserId { get { return userId; } set { userId = value; } }
        public string UserName { get { return userName; } set { userName = value; } }
        public string UserLogin { get { return userLogin; } set { userLogin = value; } }
        public string UserSurname { get { return userSurname; } set { userSurname = value; } }
        public string UserLastname { get { return userLastname; } set { userLastname = value; } }
        public bool UserActivated { get { return userActivated; } set { userActivated = value; } }
        public bool UserOnline { get { return userOnline; } set { userOnline = value; } }
        public DateTime Expired_date { get { return expired_date; } set { expired_date = value; } }
    }
}
