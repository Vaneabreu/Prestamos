using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SoftLoans.Capas.Model
{
    public class Utilidades
    {

        public string version = "v1.0.5";


       public void Notificaion(string titulo, string texto, string icono, Page page)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }
    }
}