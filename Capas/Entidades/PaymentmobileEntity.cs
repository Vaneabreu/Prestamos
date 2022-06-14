using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class PaymentmobileEntity
    {

        private long iD;
        private long loanDetailID;
        private string userMobile;
        private string paymentUser;
        private string status;
        private decimal paymentAmount;
        private string paymentDate;
        private string registrationStatus;

        public int LoandID {get; set;}
        public DateTime Date{get; set;}
        public decimal Capital { get; set; }
        public decimal Interest { get; set; }
        public decimal DelayAmount { get; set; }
        public decimal CapitalBalance { get; set; }
        public decimal InterestBalance { get; set; }
        public decimal DelayBalance { get; set; }
        public int QuotaNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal LateAmount { get; set; }
        public string AmountType { get; set; }
        public DateTime LastDateDelayAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerID { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string TotalQuota { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string RegistrationStatus
        {
            get { return registrationStatus; }
            set { registrationStatus = value; }
        }

        public long ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public long LoanDetailID
        {
            get { return loanDetailID; }
            set { loanDetailID = value; }
        }
        public string UserMobile
        {
            get { return userMobile; }
            set { userMobile = value; }
        }
        public string PaymentUser
        {
            get { return paymentUser; }
            set { paymentUser = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public decimal PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }
        public string PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }
    }
}
