using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDAL
{
   public class TicketEntityFirebase
    {
      public string billID { get; set; }
      public string amount { get; set; }
      public string date { get; set; }
      public string loteryID { get; set; }
      public string loteryName { get; set; }
      public string registrationStatus { get; set; }
      public string transactionID { get; set; }
      public string winAmount { get; set; }
      public string commission { get; set; }
    }
}
