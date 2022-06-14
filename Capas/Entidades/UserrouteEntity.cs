using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
   public class UserrouteEntity
    {
        private long userRouteID;
        private int userID;
        private int routeID;
        private string userName;
        private string routeName;

        public string RouteName
        {
            get { return routeName; }
            set { routeName = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public long UserRouteID
        {
            get { return userRouteID; }
            set { userRouteID = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int RouteID
        {
            get { return routeID; }
            set { routeID = value; }
        }
    }
}
