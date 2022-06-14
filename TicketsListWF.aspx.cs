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

    public partial class TicketsListWF : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                Session["ListaDetalle"] = null;
                InputFechaInicio.Value = DateTime.Now.ToString("yyyy-MM-dd");
                InputFechaFin.Value = DateTime.Now.ToString("yyyy-MM-dd");
                if (GvTickets.Controls.Count == 0)
                {
                    CargarDropDown();
                    GvTickets.DataSource = null;
                    GvTickets.DataBind();
                    Cargar();
                   
                }
            }
            if (!loginDAL.IsAdministrator)
            {
                menuAdmin.Style.Add("display", "none");
                DropDownListBranch.Style.Add("display", "none");
                inputBranch.Style.Add("display", "none");
            }
            else
            {
                menuUser.Style.Add("display", "none");
            }

            RegularExpressionValidator1.EnableClientScript = false;

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
            //Session["ctrl"] = GvTickets;         


            ListadoImprimir.Style.Add("display", "block");
            ListadoImprimir.InnerHtml = "<div class='container-fluid'>";
            ListadoImprimir.InnerHtml += "<div class='row fs-1 fw-bold p-3'><div class='col-12 align-self-center'>Listado de Tickes</div></div>";            
            ListadoImprimir.InnerHtml += "<div class='row fs-3 fw-bold text-dark border border-dark'>";
            ListadoImprimir.InnerHtml += "<div class='col-4 col-sm-1'>Id</div>";
            ListadoImprimir.InnerHtml += "<div class='col-4 col-sm-1'>Cod.</div>";
            ListadoImprimir.InnerHtml += "<div class='col-4 col-sm-4 ocultar-div-md'>Loteria</div>";
            ListadoImprimir.InnerHtml += "<div class='col-4 col-sm-1 align-self-end'>Monto</div>";
            ListadoImprimir.InnerHtml += "</div>";
            ListadoImprimir.InnerHtml += "<div class='row fs-5 align-items-start'>";

            foreach (GridViewRow item in GvTickets.Rows)
            {

                ListadoImprimir.InnerHtml += "<div class='col-4 col-sm-1'>" + item.Cells[0].Text + "</div>";
                ListadoImprimir.InnerHtml += "<div class='col-4 col-sm-1'>" + item.Cells[1].Text + "</div>";
                ListadoImprimir.InnerHtml += "<div class='col-4 col-sm-4 ocultar-div-md'>" + item.Cells[2].Text + "</div>";
                ListadoImprimir.InnerHtml += "<div class='col-4 col-sm-1 align-self-end'>" + item.Cells[3].Text + "</div>";

            }
            ListadoImprimir.InnerHtml += "</div>";
            ListadoImprimir.InnerHtml += "</div>";



            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ImprimirListadoTicket()", true);

         
        }
        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (RegularExpressionValidator1.IsValid)
            {
                Response.Redirect("ClienteCrearWF.aspx");
            }


        }
      

        protected void GvTickets_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GvTickets.SelectedRow.RowIndex >= 0)
            {


                try
                {
                    TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
                    List<TransactionDetailsDAL> transactionDetailsDALList = new List<TransactionDetailsDAL>();
                    transactionDetailsDAL.TransactionID = Int64.Parse(GvTickets.SelectedRow.Cells[0].Text);
                    transactionDetailsDALList = transactionDetailsDAL.Search(loginDAL);

                    if (transactionDetailsDALList.Count > 0)
                    {
                        Session["ListaDetalle"] = transactionDetailsDALList;
                        Response.Redirect("SeleccionLoteriaWF.aspx");
                    }


                }
                catch (Exception)
                {

                    throw;
                }




            }

        }
        protected void GvTickets_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            if (e != null)
            {
                if (e.RowIndex >= 0)
                {
                    GridViewRow row = GvTickets.Rows[e.RowIndex];


                    TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.TransactionID = Int64.Parse(row.Cells[0].Text);
                    transactionDetailsDAL.LotteryName = row.Cells[2].Text.Replace("&#241;", "ñ");


                    Session["Parametro"] = transactionDetailsDAL;
                    Response.Redirect("TicketsDetalleWF.aspx");


                }
            }



        }
        protected void GvTickets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (allowCancel(loginDAL.UserName))
            {
                if (e.RowIndex >= 0)
                {

                    string title = "Estas seguro?";
                    string text = "Una vez cancelado, ¡no podrá recuperar este ticket!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), null, "NotificacionYN('" + GvTickets.Rows[e.RowIndex].Cells[0].Text + "','" + title + "','" + text + "','" + OpcionesNotificaciones.Cancelar + "');", true);
                    GvTickets.DataSource = null;
                    GvTickets.DataBind();
                }
            }



        }

        public void Cargar()
        {

            TransactionsDAL transactionsDAL = new TransactionsDAL();

            try
            {


                transactionsDAL.TransactionID = String.IsNullOrEmpty(TbTicketID.Text) ? 0 : int.Parse(TbTicketID.Text);
                transactionsDAL.StartTime = Convert.ToDateTime(InputFechaInicio.Value);
                transactionsDAL.EndTime = Convert.ToDateTime(InputFechaFin.Value + " 23:58");

                if (loginDAL.IsAdministrator)
                {
                    if (DropDownListBranch.SelectedItem.Value.ToString() != "-- Seleccione --")
                    {
                        transactionsDAL.BranchID = Convert.ToInt32(DropDownListBranch.SelectedItem.Value);
                    }
                }
                else 
                {
                    transactionsDAL.UserName = userName;
                }
               
               

                GvTickets.Controls.Clear();

                GvTickets.DataSource = transactionsDAL.SearchPayWin(loginDAL);
                GvTickets.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }



        }
        protected void CargarDropDown()
        {
            BranchesDAL branchesDAL = new BranchesDAL();
            try
            {

                DropDownListBranch.DataSource = branchesDAL.LoadCombo(loginDAL);
                DropDownListBranch.DataValueField = "branchID";
                DropDownListBranch.DataTextField = "name";
                DropDownListBranch.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            branchesDAL = null;

        }


        public bool allowCancel(string userName)
        {
            bool allow = true;

            UsersDAL usersDAL = new UsersDAL();
            usersDAL.Name = userName;
            allow = usersDAL.AllowCancel(loginDAL);
            usersDAL = null;

            return allow;
        }      
        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        protected void BtnMenu_ServerClick(object sender, EventArgs e)
        {

        }
    }

}
