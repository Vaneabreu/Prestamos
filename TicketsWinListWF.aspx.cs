using SoftLoans.Capas.Model;
using SoftLoans.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SoftLoans
{

    public partial class TicketsWinListWF : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
        static string userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ListaDetalle"] = null;
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                userName = loginDAL.UserName;
            }
          

            if (!IsPostBack)
            {
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
            TransactionsDAL transactionsDAL = new TransactionsDAL();

            try
            {

                if (RegularExpressionValidator1.IsValid)
                {

                    Cargar();
                }




            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }

        }
        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            Session["ctrl"] = GvTickets;
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Imprimir.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
        }
        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (RegularExpressionValidator1.IsValid)
            {
                Response.Redirect("ClienteCrearWF.aspx");
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
                    transactionDetailsDAL.LotteryName = row.Cells[2].Text;


                    Session["Parametro"] = transactionDetailsDAL;
                    Response.Redirect("TicketsDetalleWF.aspx");


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
                transactionsDAL.TransactionStatusID = 2;
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

                GvTickets.DataSource = transactionsDAL.Search(loginDAL);
                GvTickets.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }



        }

        //[WebMethod]
        //public static string Cancelar(string codigo)
        //{
        //    TransactionsDAL transactionsDAL = new TransactionsDAL();

        //    string result = "Ticket cancelado exitosamente!";
        //    try
        //    {

        //        transactionsDAL.TransactionID = Int64.Parse(codigo);
        //        transactionsDAL.UserName = userName;

        //        if (transactionsDAL.CancelTicket())
        //        {
        //            result = "Cliente Cancelado exitosamente!";

        //        }
        //        else
        //        {
        //            result = transactionsDAL.ErrorDescription;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        result = "Algo salio mal, mas detalles: " + ex.Message;

        //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
        //    }
        //    transactionsDAL = null;
        //    return result;

        //}



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

    }

}
