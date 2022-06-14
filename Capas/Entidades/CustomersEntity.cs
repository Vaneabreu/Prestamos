using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
  public  class CustomersEntity
    {
        private int iD;
        private string identificationType;
        private string identificationNumber;
        private string name;
        private string lastName;
        private string address;
        private string phone;
        private string status;
        private int age;
        private string position;
        private string workPlace;
        private decimal salary;
        private decimal otherSalary;
        private string dependents;
        private string timeInWork;
        private string fatherName;
        private string motherName;
        private string personalReferences;
        private string workReferences;
        private int guarantorID;
        private DateTime registrationDate;
        private bool loanActive;
        private decimal lateAmount;
        private string amountType;
        private int routeID;
        private DateTime birthDate;
        private int pendingCount;
        private int payCount;

        public int PayCount
        {
            get { return payCount; }
            set { payCount = value; }
        }

        public int PendingCount
        {
            get { return pendingCount; }
            set { pendingCount = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public int RouteID
        {
            get { return routeID; }
            set { routeID = value; }
        }

        public int UserMobileID { get; set; }
        public string UserMobileName { get; set; }
        public string EmployeeName { get; set; }

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

        public bool LoanActive
        {
            get { return loanActive; }
            set { loanActive = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string IdentificationType
        {
            get { return identificationType; }
            set { identificationType = value; }
        }
        public string IdentificationNumber
        {
            get { return identificationNumber; }
            set { identificationNumber = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public string WorkPlace
        {
            get { return workPlace; }
            set { workPlace = value; }
        }
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public decimal OtherSalary
        {
            get { return otherSalary; }
            set { otherSalary = value; }
        }
        public string Dependents
        {
            get { return dependents; }
            set { dependents = value; }
        }
        public string TimeInWork
        {
            get { return timeInWork; }
            set { timeInWork = value; }
        }
        public string FatherName
        {
            get { return fatherName; }
            set { fatherName = value; }
        }
        public string MotherName
        {
            get { return motherName; }
            set { motherName = value; }
        }
        public string PersonalReferences
        {
            get { return personalReferences; }
            set { personalReferences = value; }
        }
        public string WorkReferences
        {
            get { return workReferences; }
            set { workReferences = value; }
        }
        public int GuarantorID
        {
            get { return guarantorID; }
            set { guarantorID = value; }
        }
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }
    }
}
