using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class FirebaseCustomerEntity
    {
        public string id{ get; set; }
        public string identificationType{ get; set; }
        public string identificationNumber { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public string registrationDate { get; set; }
        public string registrationStatus { get; set; }
        public string customerIdDb { get; set; }
    }
}
