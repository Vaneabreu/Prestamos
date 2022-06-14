using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class SeleccionLoteriaWF : System.Web.UI.Page
    {
        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
               
                LoteriasAbiertas();
            }
            else 
            {
                Response.Redirect("InicioWF.aspx");
            }
        }


        /**Inicio Botones Menu Usuario Vendedor**********************/
        protected void BtnLoterias_Click(object sender, EventArgs e)
        {
            Session["DatosUsuario"] = loginDAL;
            Response.Redirect("SeleccionLoteriaWF.aspx");

        }
        protected void BtnCuadre_Click(object sender, EventArgs e) 
        {
         
            Session["DatosUsuario"] = loginDAL;
            Response.Redirect("CuadreWF.aspx");


        }
        protected void BtnTickets_Click(object sender, EventArgs e)
        {
            Session["DatosUsuario"] = loginDAL;
            Response.Redirect("TicketsListWF.aspx");

        }
        protected void BtnTicketsWin_Click(object sender, EventArgs e)
        {

            Session["DatosUsuario"] = loginDAL;
            Response.Redirect("TicketsWinListWF.aspx");

        }
        protected void BtnNumerosGanadores_Click(object sender, EventArgs e)
        {
            Session["DatosUsuario"] = loginDAL;
            Response.Redirect("NumerosGanadoresWF.aspx");

        }
        protected void BtnCerrarSeccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioWF.aspx");

        }
        /**FIn Botones Menu Usuario Vendedor**********************/


        /**Inicio Botones Menu Usuario Admnistrador**********************/
        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuWF.aspx");

        }
        protected void BtnCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteWF.aspx");

        }
        /**FIn Botones Menu Usuario Administrador**********************/


        protected void BtnFacturacion_Click(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlButton button = (System.Web.UI.HtmlControls.HtmlButton)sender;
            Session["Parametros"] = button.ClientID;
            Session["DatosUsuario"] = loginDAL;
            Response.Redirect("FacturacionWF.aspx");

        }

        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        public void LoteriasAbiertas()
        {
            int horaCierreLoteria = 0;
            int horaActual = int.Parse(DateTime.Now.ToString("HH:mm").Replace(":", ""));
            LotteriesDAL lotteriesDAL = new LotteriesDAL();
            List<LotteriesDAL> listLoterias = new List<LotteriesDAL>();
      
            listLoterias = lotteriesDAL.Search(loginDAL);

            for (int i = 0; i < listLoterias.Count; i++)
            {
                if (listLoterias[i].Enabled)
                {
                    horaCierreLoteria = int.Parse(listLoterias[i].ClosingTime.Replace(":", ""));
                    if (horaCierreLoteria <= horaActual)
                    {
                        switch (listLoterias[i].LotteryID)
                        {
                            case 1:  Div1.Visible = false;  break;
                            case 4:  Div4.Visible = false;  break;
                            case 5:  Div5.Visible = false;  break;
                            case 12: Div12.Visible = false;  break;
                            case 15: Div15.Visible = false;  break;
                            case 32: Div32.Visible = false;  break;
                            case 33: Div33.Visible = false;  break;
                            case 37: Div37.Visible = false;  break;
                            case 38: Div38.Visible = false;  break;
                            case 39: Div39.Visible = false;  break;
                            case 40: Div40.Visible = false;  break;
                            case 41: Div41.Visible = false;  break;
                            case 42: Div42.Visible = false;  break;
                            case 43: Div43.Visible = false;  break;
                            case 44: Div44.Visible = false;  break;
                            case 45: Div45.Visible = false;  break;
                            case 46: Div46.Visible = false;  break;
                            case 47: Div47.Visible = false;  break;
                            case 48: Div48.Visible = false;  break;
                            case 49: Div49.Visible = false; break;
                        }
                    }
                }

            }

        }



    }

}
