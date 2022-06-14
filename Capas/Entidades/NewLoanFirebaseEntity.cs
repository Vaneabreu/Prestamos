using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class NewLoanFirebaseEntity
    {
        public string amount { get; set; }
        public string customerId { get; set; }
        public string forQuota { get; set; }
        public string frecuency { get; set; }
        public string interest { get; set; }
        public string time { get; set; }
        public string registrationStatus { get; set; }
    }
}
