using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
  public class ReportEntity
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
        private string noQuota;
        private decimal subTotalQuota;
        private decimal quotaAmount;
        private decimal payAmount;
        private string nfc;

        public string Nfc
        {
            get { return nfc; }
            set { nfc = value; }
        }

        public decimal PayAmount
        {
            get { return payAmount; }
            set { payAmount = value; }
        }

        public decimal QuotaAmount
        {
            get { return quotaAmount; }
            set { quotaAmount = value; }
        }
      

        public decimal SubTotalQuota
        {
            get { return subTotalQuota; }
            set { subTotalQuota = value; }
        }

        public string NoQuota
        {
            get { return noQuota; }
            set { noQuota = value; }
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
