using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
    public class ExpensesEntity
    {
        private long iD;
        private string description;
        private string ncf;
        private DateTime date;
        private decimal amount;
        private DateTime startDate;
        private DateTime endDate;
        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

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

        public long ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Ncf
        {
            get { return ncf; }
            set { ncf = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
