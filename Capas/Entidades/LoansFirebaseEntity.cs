using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
  public class LoansFirebaseEntity
    {
      public string iD { get; set; }
      public string capital { get; set; }
      public string date { get; set; }
      public string customerID { get; set; }
      public string frequency { get; set; }
      public string percentInterest { get; set; }
      public string interestAmount { get; set; }
      public string fixedInterest { get; set; }
      public string totalAmount { get; set; }
      public string forQuota { get; set; }
      public string dueAmount { get; set; }
      public string dueTime { get; set; }
      public string status { get; set; }
      public string customerName { get; set; }
      public string guarantorID { get; set; }
      public string identificationNumber { get; set; }
      public string dueDays { get; set; }
    }
}
