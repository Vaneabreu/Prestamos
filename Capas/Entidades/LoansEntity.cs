using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class LoansEntity
    {
        private int iD;
        private decimal capital;
        private DateTime date;
        private int customerID;
        private string frequency;
        private decimal percentInterest;
        private decimal interestAmount;
        private bool fixedInterest;
        private decimal totalAmount;
        private bool forQuota;
        private decimal dueAmount;
        private int dueTime;
        private decimal safeAmount;
        private string status;
        private DateTime timeStart;
        private DateTime timeEnd;
        private string customerName;
        private int guarantorID;
        private decimal lawyer;
        private decimal actOfSale;
        private decimal opposition;
        private decimal transfer;
        private string identificationNumber;
        private int routeID;

        public int RouteID
        {
            get { return routeID; }
            set { routeID = value; }
        }

        public string IdentificationNumber
        {
            get { return identificationNumber; }
            set { identificationNumber = value; }
        }

        public decimal Transfer
        {
            get { return transfer; }
            set { transfer = value; }
        }

        public decimal Opposition
        {
            get { return opposition; }
            set { opposition = value; }
        }

        public decimal ActOfSale
        {
            get { return actOfSale; }
            set { actOfSale = value; }
        }

        public decimal Lawyer
        {
            get { return lawyer; }
            set { lawyer = value; }
        }

        public int GuarantorID
        {
            get { return guarantorID; }
            set { guarantorID = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
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
        public decimal Capital
        {
            get { return capital; }
            set { capital = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }
        public decimal PercentInterest
        {
            get { return percentInterest; }
            set { percentInterest = value; }
        }
        public decimal InterestAmount
        {
            get { return interestAmount; }
            set { interestAmount = value; }
        }
        public bool FixedInterest
        {
            get { return fixedInterest; }
            set { fixedInterest = value; }
        }
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        public bool ForQuota
        {
            get { return forQuota; }
            set { forQuota = value; }
        }
        public decimal DueAmount
        {
            get { return dueAmount; }
            set { dueAmount = value; }
        }
        public int DueTime
        {
            get { return dueTime; }
            set { dueTime = value; }
        }
        public decimal SafeAmount
        {
            get { return safeAmount; }
            set { safeAmount = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
