using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class CashierEntity
    {
        private int iD;
        private decimal amount;
        private DateTime lastUpdate;
        private string type;
        private string description;
        private string operation;
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

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }
    }
}
