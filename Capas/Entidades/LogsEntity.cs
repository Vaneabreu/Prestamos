using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loans.Entity
{
   public class LogsEntity
    {
        private long logID;
        private string action;
        private string detail;
        private DateTime date;
        private string userName;
        private DateTime startDate;
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public long LogID
        {
            get { return logID; }
            set { logID = value; }
        }
        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
