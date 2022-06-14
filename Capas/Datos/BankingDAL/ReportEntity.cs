using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDAL
{
    public class ReportEntity
    {
        public string brancheName {get; set;}
        public decimal amount { get; set; }
        public decimal commission { get; set; }
        public decimal gainAmount { get; set; }
        public decimal total { get; set; }

        
    }
}
