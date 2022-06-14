using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class LoanDetailsFirebaseEntity
    {
       public string iD { get; set; }
       public string loandID { get; set; }
       public string date { get; set; }
       public string capital { get; set; }
       public string interest { get; set; }
       public string delayAmount { get; set; }
       public string capitalBalance { get; set; }
       public string interestBalance { get; set; }
       public string delayBalance { get; set; }
       public string status { get; set; }
       public string quotaNumber { get; set; }
       public string lastDateDelayAmount { get; set; }
       public string paymentAmount { get; set; }
       public string paymentDate { get; set; }
       public string paymentUser { get; set; }
       public string registrationStatus { get; set; }
       public string mora { get; set; }
       public string customerName { get; set; }
       public string totalCuota { get; set; }
    }
}
