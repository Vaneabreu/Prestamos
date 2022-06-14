using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDAL
{
   public class BalanceFirebaseEntity
    {
        public string amount { get; set; }
        public string commission { get; set; }
        public string gainAmount { get; set; }
        public string total { get; set; }

        public string dailyamount { get; set; }
        public string dailycommission { get; set; }
        public string dailygainAmount { get; set; }
        public string dailytotal { get; set; }
        public string redamount { get; set; }
        public string loanamount { get; set; }
        public string free { get; set; }
        public string dailyfree { get; set; }

    }
}
