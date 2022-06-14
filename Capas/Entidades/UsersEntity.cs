using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class UsersEntity
    {
        private int iD;
        private string name;
        private string password;
        private bool isAdministrator;
        private DateTime registrationDate;
        private bool status;
        private bool isUser;

        public bool IsUser
        {
            get { return isUser; }
            set { isUser = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public bool IsAdministrator
        {
            get { return isAdministrator; }
            set { isAdministrator = value; }
        }
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
