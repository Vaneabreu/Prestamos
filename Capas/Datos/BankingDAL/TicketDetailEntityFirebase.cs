using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDAL
{
   public class TicketDetailEntityFirebase
    {
        public string ID { get; set; }
        public string billID { get; set; }
        public string amount { get; set; }
        public string number { get; set; }
        public string playType { get; set; }
        public string winAmount { get; set; }
        public string registrationStatus { get; set; }
        public string lotery { get; set; }
        public string date { get; set; }
        public string commission { get; set; }
    }
}
