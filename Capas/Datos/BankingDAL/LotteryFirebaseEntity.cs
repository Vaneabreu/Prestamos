using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDAL
{
   public class LotteryFirebaseEntity
    {
       public string id { get; set; }
       public string name { get; set; }
       public string enabled { get; set; }
       public string closingTime { get; set; }
       public string sundayClosingTime { get; set; }
    }
}
