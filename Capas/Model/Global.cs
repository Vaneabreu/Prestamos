using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 public class Global
  {
     private static Global oInstance;

     protected Global()
     {
     }

     public static Global Instance()
     {
     
       if (oInstance == null)
           oInstance = new Global();
      
       return oInstance;
     
     }

    public int UserID { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public string DataBaseName { get; set; }
    public string DataSource { get; set; }
    public DateTime CreationDate { get; set; }
    public int LicenseID { get; set; }

    public int EmployeeID { get; set; }
    public bool IsAdministrator { get; set; }
    public int BranchID { get; set; }
    public bool AllowCancelTransaction { get; set; }
    public DateTime LastLoginDate { get; set; }
    public bool Enabled { get; set; }
    public DateTime LastPaymentDate { get; set; }
    public DateTime LastCommissionDate { get; set; }
    public string DeviceID { get; set; }

    public string ListPaysPrint { get; set; }

}

