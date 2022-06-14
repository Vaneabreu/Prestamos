using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class PaysEntity
    {
        private int iD;
        private DateTime date;
        private long loanDetailsID;
        private decimal amount;
        private string comment;
        private string type;
        private DateTime timeStart;
        private DateTime timeEnd;
        private int quotaNumber;
        private string customerName;
        private string ncfNumber;
        private int loandID;
        private decimal delayAmount;
        private decimal delayBalance;
        private decimal capitalBalance;
        private decimal interestBalance;
        private decimal capital;
        private decimal interest;
        private decimal capitalPay;
        private decimal interestPay;
        private decimal delayPay;
        private int routeID;
        private string routeName;
        private DateTime detailDate;
        private int customerID;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public DateTime DetailDate
        {
            get { return detailDate; }
            set { detailDate = value; }
        }

        public string RouteName
        {
            get { return routeName; }
            set { routeName = value; }
        }

        public int RouteID
        {
            get { return routeID; }
            set { routeID = value; }
        }

        public decimal DelayPay
        {
            get { return delayPay; }
            set { delayPay = value; }
        }

        public decimal InterestPay
        {
            get { return interestPay; }
            set { interestPay = value; }
        }

        public decimal CapitalPay
        {
            get { return capitalPay; }
            set { capitalPay = value; }
        }

        public decimal Interest
        {
            get { return interest; }
            set { interest = value; }
        }

        public decimal Capital
        {
            get { return capital; }
            set { capital = value; }
        }

        public decimal InterestBalance
        {
            get { return interestBalance; }
            set { interestBalance = value; }
        }

        public decimal CapitalBalance
        {
            get { return capitalBalance; }
            set { capitalBalance = value; }
        }

        public decimal DelayBalance
        {
            get { return delayBalance; }
            set { delayBalance = value; }
        }

        public decimal DelayAmount
        {
            get { return delayAmount; }
            set { delayAmount = value; }
        }
        public int LoandID
        {
            get { return loandID; }
            set { loandID = value; }
        }
        public string NcfNumber
        {
            get { return ncfNumber; }
            set { ncfNumber = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public int QuotaNumber
        {
            get { return quotaNumber; }
            set { quotaNumber = value; }
        }

        public DateTime TimeEnd
        {
            get { return timeEnd; }
            set { timeEnd = value; }
        }

        public DateTime TimeStart
        {
            get { return timeStart; }
            set { timeStart = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public long LoanDetailsID
        {
            get { return loanDetailsID; }
            set { loanDetailsID = value; }
        }
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

    }
}
