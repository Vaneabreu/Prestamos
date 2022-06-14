using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Entity
{
    public class RoutesEntity
    {
        private int routeID;
        private string name;
        private string description;
        private bool status;

        public int RouteID
        {
            get { return routeID; }
            set { routeID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
