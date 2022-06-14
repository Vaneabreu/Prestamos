using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class GuarantorEntity
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
        private string timeInWork;
        private string fatherName;
        private string motherName;
        private DateTime registrationDate;

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
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

    }
}
