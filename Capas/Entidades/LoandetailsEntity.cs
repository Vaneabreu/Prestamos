using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class LoandetailsEntity
    {
        private long iD;
        private int loandID;
        private DateTime date;
        private decimal capital;
        private decimal interest;
        private decimal delayAmount;
        private decimal capitalBalance;
        private decimal interestBalance;
        private decimal delayBalance;
        private bool status;
        private int quotaNumber;
        private string customerName;
        private decimal lateAmount;
        private string amountType;
        private DateTime lastDateDelayAmount;

        private decimal actOfSale;
        private decimal lawyer;
        private decimal opposition;
        private decimal transfer;
        private decimal safeAmount;
        private bool forQuota;
        private decimal percentInterest;
        private string frequency;
        private string day;
        private decimal totalAmount;
        private decimal totalExpenses;
        private int routeID;
        private int userID;
        private int statusInt;
        private bool filterDate;

        public bool FilterDate
        {
            get { return filterDate; }
            set { filterDate = value; }
        }

        public int StatusInt
        {
            get { return statusInt; }
            set { statusInt = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int RouteID
        {
            get { return routeID; }
            set { routeID = value; }
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int UserMobileID { get; set; }

        public string UserMobileName { get; set; }
        public string Employee { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public int CustomerID { get; set; }
        public int TotalQuota { get; set; }
        public DateTime PayDate { get; set; }

        public string PayStatus { get; set; }
        public decimal TotalDueAmount { get; set; }

        public decimal TotalExpenses
        {
            get { return totalExpenses; }
            set { totalExpenses = value; }
        }

        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        public string Day
        {
            get { return day; }
            set { day = value; }
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

        public bool ForQuota
        {
            get { return forQuota; }
            set { forQuota = value; }
        }

        public decimal SafeAmount
        {
            get { return safeAmount; }
            set { safeAmount = value; }
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

        public decimal Lawyer
        {
            get { return lawyer; }
            set { lawyer = value; }
        }

        public decimal ActOfSale
        {
            get { return actOfSale; }
            set { actOfSale = value; }
        }

        public DateTime LastDateDelayAmount
        {
            get { return lastDateDelayAmount; }
            set { lastDateDelayAmount = value; }
        }

        public string AmountType
        {
            get { return amountType; }
            set { amountType = value; }
        }

        public decimal LateAmount
        {
            get { return lateAmount; }
            set { lateAmount = value; }
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

        public long ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public int LoandID
        {
            get { return loandID; }
            set { loandID = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public decimal Capital
        {
            get { return capital; }
            set { capital = value; }
        }
        public decimal Interest
        {
            get { return interest; }
            set { interest = value; }
        }
        public decimal DelayAmount
        {
            get { return delayAmount; }
            set { delayAmount = value; }
        }
        public decimal CapitalBalance
        {
            get { return capitalBalance; }
            set { capitalBalance = value; }
        }
        public decimal InterestBalance
        {
            get { return interestBalance; }
            set { interestBalance = value; }
        }
        public decimal DelayBalance
        {
            get { return delayBalance; }
            set { delayBalance = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
