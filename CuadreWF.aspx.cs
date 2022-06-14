using SoftLoans.Capas.Model;
using SoftLoans.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Controls;

namespace SoftLoans
{

    public partial class CuadreWF : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
        static string userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                userName = loginDAL.UserName;
            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }

            if (!loginDAL.IsAdministrator)
            {
                menuAdmin.Style.Add("display", "none");
                cardCaida.Style.Add("display", "none");
            }
            else
            {
                menuUser.Style.Add("display", "none");
            }

            if (!IsPostBack)
            {
                Session["ListaDetalle"] = null;
                InputFechaInicio.Value = DateTime.Now.ToString("yyyy-MM-dd");
                InputFechaFin.Value = DateTime.Now.ToString("yyyy-MM-dd");

                Cargar();

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

        protected void BtnLoteriasAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoteriasWF.aspx");

        }
        protected void BtnAdminTipoJugada_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminTipoJugadaWF.aspx");

        }
        protected void BtnAdminLimiteTipoJugada_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLimiteTipoJugadaWF.aspx");
        }
        protected void BtnAdminLimiteNumero_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLimiteNumeroWF.aspx");
        }
        protected void BtnAdminCombinacionesPermitidas_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCombinacionesPermitidasWF.aspx");
        }
        protected void BtnAdminNumerosJugados_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminNumerosJugadosWF.aspx");
        }
        protected void BtnAdminUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUsuariosWF.aspx");
        }

        /**FIn Botones Menu Usuario Administrador**********************/


        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
        protected void BtnImprimir_Click(object sender, EventArgs e)
        {

            //CuadreImprimir.Style.Add("display", "block");
            //CuadreImprimir.InnerHtml = "<h1 class='aling-T-C negrita-T'>Cuadre</h1><br/>";
            //CuadreImprimir.InnerHtml = "<h3 class='aling-T-L negrita-T'>Balance Acumulado</h3><br/>";
            //CuadreImprimir.InnerHtml += "<div class='aling-T-L'><a>Ventas:</a><a>" + textVentas.InnerText + "</a></div>";
            //CuadreImprimir.InnerHtml += "<div class='aling-T-L'><a>Comisión:</a><a>" + textComision.InnerText + "</a></div>";
            //CuadreImprimir.InnerHtml += "<div class='aling-T-L'><a>Premios:</a><a>" + textPremios.InnerText + "</a></div><br/>";

            //CuadreImprimir.InnerHtml = "<h3 class='aling-T-L negrita-T'>Balance Acumulado</h3><br/>";
            //CuadreImprimir.InnerHtml += "<div class='aling-T-L'><a>Ventas:</a><a>" + textDateVentas.InnerText + "</a></div>";
            //CuadreImprimir.InnerHtml += "<div class='aling-T-L'><a>Comisión:</a><a>" + textDateComision.InnerText + "</a></div>";
            //CuadreImprimir.InnerHtml += "<div class='aling-T-L'><a>Premios:</a><a>" + textDatePremios.InnerText + "</a></div><br/>";



            EmployeeDAL employeeDAL = new EmployeeDAL();
           
           // employeeDAL.EmployeeID = loginDAL.EmployeeID;
            employeeDAL.GetByKey(loginDAL);



            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ImprimirCuadre('" + employeeDAL.Name+ "','" + InputFechaInicio.Value + "','" + InputFechaFin.Value + "')", true);


        }

   


        protected void GvTickets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GvTickets_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {



        }
        protected void GvTickets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


        }

        public void Cargar()
        {

            TransactionsDAL transactionsDAL = new TransactionsDAL();
            

            List<TransactionsDAL> list = new List<TransactionsDAL>();
            decimal amount = 0;
            decimal commission = 0;
            decimal gainAmount = 0;
            decimal total = 0;
            decimal free = 0;

            decimal dailyamount = 0;
            decimal dailycommission = 0;
            decimal dailygainAmount = 0;
            decimal dailytotal = 0;
            decimal dailyfree = 0;

            decimal totalAll = 0;
            decimal gainAll = 0;
            decimal commissionAll = 0;
            decimal freeAll = 0;
            decimal redamount = 0;

            try
            {
                UsersDAL usersDAL = new UsersDAL();
                usersDAL.dbm.DataSource = loginDAL.DataSource;
                usersDAL.dbm.User = loginDAL.UserName;
                usersDAL.dbm.Password = loginDAL.UserPassword;
                usersDAL.dbm.DataBase = loginDAL.DataBaseName;

                List<UsersDAL> usersDALList = new List<UsersDAL>();
                if (!loginDAL.IsAdministrator)
                {
                    usersDAL.Name = userName;
                }
                
                usersDALList = usersDAL.Search(loginDAL);

                //if (usersDALList.Count > 0)
                foreach (var item in usersDALList) 
                {
                    //balance acumulado
                    transactionsDAL.StartTime = item.LastPaymentDate;
                    transactionsDAL.EndTime = DateTime.Now;
                    transactionsDAL.UserName = item.Name;
                    transactionsDAL.CustomerID = -1;

                    list = transactionsDAL.SearchPayWin(loginDAL, true);

                  
                    foreach (TransactionsDAL itemT in list)
                    {

                        commission = commission + itemT.Commission;
                        amount = amount + itemT.Amount;
                        gainAmount = gainAmount + itemT.TotalGainAmount;
                        free = free + itemT.Discount;

                    }

                    //balance por fecha
                    transactionsDAL = new TransactionsDAL();
                    

                    transactionsDAL.StartTime = Convert.ToDateTime(InputFechaInicio.Value);
                    transactionsDAL.EndTime = Convert.ToDateTime(InputFechaFin.Value + " 23:58");
                    transactionsDAL.UserName = item.Name;
                    
                    transactionsDAL.CustomerID = -1;

                    list = transactionsDAL.SearchPayWin(loginDAL);

                    foreach (TransactionsDAL itemTr in list)
                    {

                        dailycommission = dailycommission + itemTr.Commission;
                        dailyamount = dailyamount + itemTr.Amount;
                        dailygainAmount = dailygainAmount + itemTr.TotalGainAmount;
                        dailyfree = dailyfree + itemTr.Discount;
                    }

                }

                //buscando balance caida
                transactionsDAL = new TransactionsDAL();
             

                transactionsDAL.StartTime = DateTime.Now.AddYears(-50);
                transactionsDAL.EndTime = DateTime.Now;
                transactionsDAL.CustomerID = -1;
                list = transactionsDAL.SearchPayWin(loginDAL);

                foreach (TransactionsDAL item in list)
                {
                    
                        totalAll = totalAll + item.Amount;
                        commissionAll = commissionAll + item.Commission;
                        gainAll = gainAll + item.TotalGainAmount;
                        freeAll = freeAll + item.Discount;
                    
                }

                redamount = totalAll - (commissionAll + gainAll + freeAll);
                total = amount - commission - gainAmount - free;
                dailytotal = dailyamount - dailycommission - dailygainAmount- dailyfree;

                textVentas.InnerText = "$" + amount.ToString("N2");
                textComision.InnerText = "$" + commission.ToString("N2");
                textPremios.InnerText = "$" + gainAmount.ToString("N2");
                textFree.InnerText = "$" + free.ToString("N2");
                textTotal.InnerText = "$" + total.ToString("N2");

                textDateVentas.InnerText = "$" + dailyamount.ToString("N2");
                textDateComision.InnerText = "$" + dailycommission.ToString("N2");
                textDatePremios.InnerText = "$" + dailygainAmount.ToString("N2");
                textDateFree.InnerText = "$" + dailyfree.ToString("N2");
                textDateTotal.InnerText = "$" + dailytotal.ToString("N2");

                textCaida.InnerText = "$" + redamount.ToString("N2");

                if (total < 0)
                {
                    textTotal.Attributes.Add("style", "color:Red;");
                }
                else
                {
                    textTotal.Attributes.Add("style", "color:Green;");
                }

                if (dailytotal < 0)
                {
                    textDateTotal.Attributes.Add("style", "color:Red;");
                }
                else
                {
                    textDateTotal.Attributes.Add("style", "color:Green;");
                }

                if (redamount < 0)
                {
                    textCaida.Attributes.Add("style", "color:Red;");
                }
                else
                {
                    textCaida.Attributes.Add("style", "color:Green;");
                }







            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }



        }


        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }
    }

}
