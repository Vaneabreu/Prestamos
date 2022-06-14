using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loans.Entity
{
   public class NcfNumbersEntity
    {
        private string ncfNumber;
        private DateTime registrationDate;
        private DateTime usedDate;
        private string ncfType;
        private bool enabled;
        private int customerID;
        private string ncfCode;
        private long currentSequence;
        private long finalSequence;
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public long FinalSequence
        {
            get { return finalSequence; }
            set { finalSequence = value; }
        }

        public long CurrentSequence
        {
            get { return currentSequence; }
            set { currentSequence = value; }
        }

        public string NcfCode
        {
            get { return ncfCode; }
            set { ncfCode = value; }
        }

       
        List<NcfNumbersEntity> ncfNumbersEntityList;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public List<NcfNumbersEntity> NcfNumbersEntityList
        {
            get { return ncfNumbersEntityList; }
            set { ncfNumbersEntityList = value; }
        }

        public string NcfNumber
        {
            get { return ncfNumber; }
            set { ncfNumber = value; }
        }
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }
        public DateTime UsedDate
        {
            get { return usedDate; }
            set { usedDate = value; }
        }
        public string NcfType
        {
            get { return ncfType; }
            set { ncfType = value; }
        }
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
    }
}
