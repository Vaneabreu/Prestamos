using Loans.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoteria
{
    public partial class ListadoPrestamosPendienteWF : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
        DateTime dateDetail;
        DateTime currentDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }

            if (!IsPostBack)
            {

                if (GvListPretamos.Controls.Count == 0)
                {
                    Cargar();

                }
            }
            if (loginDAL.IsAdministrator == false)
            {
                ocultarOpciones();
            }

        }
        public void ocultarOpciones()
        {
            APrestamos.Style.Add("display", "none");
            AClientes.Style.Add("display", "none");
            AGarantes.Style.Add("display", "none");
            AConfiguracion.Style.Add("display", "none");
        }

        /**Inicio Botones Menu Usuario **********************/
        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuWF.aspx");

        }
        protected void BtnPrestamos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrestamoCrearWF.aspx");
        }
        protected void BtnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteWF.aspx");
        }
        protected void BtnGarante_Click(object sender, EventArgs e)
        {
            Response.Redirect("GaranteWF.aspx");
        }
        protected void BtnCobros_Click(object sender, EventArgs e)
        {

            Response.Redirect("ListadoCobrosWF.aspx");
        }
        protected void BtnBalanceCentral_Click(object sender, EventArgs e)
        {

            Response.Redirect("CentralMovimientosWF.aspx");
        }

        protected void BtnConPrestamos_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrestamosWF.aspx");
        }
        protected void BtnVencidosProximoVencer_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoPrestamosPendienteWF.aspx");
        }
        protected void BtnListPagos_Click(object sender, EventArgs e)
        {

        }
        protected void BtnGastos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GastosWF.aspx");
        }
        protected void BtnListCuotas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReporteCuotasWF.aspx");
        }

        protected void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuariosWF.aspx");
        }
        protected void BtnNCF_Click(object sender, EventArgs e)
        {
            Response.Redirect("NcfWF.aspx");

        }
        protected void BtnAcciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccionesWF.aspx");
        }
        protected void BtnRutas_Click(object sender, EventArgs e)
        {
            Response.Redirect("RutasWF.aspx");
        }
        protected void BtnRutasCobradores_Click(object sender, EventArgs e)
        {
            Response.Redirect("RutasCobradorWF.aspx");
        }

        protected void BtnCerrarSeccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioWF.aspx");

        }
        /**FIn Botones Menu Usuario **********************/

       
        public void Cargar()
        {

            LoandetailsDAL loandetailsDAL = new LoandetailsDAL();
            LoandetailsEntity loandetailsEntity = new LoandetailsEntity();
            List<LoandetailsEntity> listLoandetailsEntity = new List<LoandetailsEntity>();

            GvListPretamos.DataSource = null;
            GvListPretamos.DataBind();

            try
            {
                listLoandetailsEntity = loandetailsDAL.SearchDueDate(loandetailsEntity, loginDAL);
                foreach (LoandetailsEntity item in listLoandetailsEntity)
                {
                    item.TotalDueAmount = Math.Ceiling(item.InterestBalance +item.CapitalBalance);
                    item.TotalAmount = Math.Ceiling(item.Interest + item.Capital);

                }
                GvListPretamos.DataSource = listLoandetailsEntity;
                GvListPretamos.DataBind();


                if (!string.IsNullOrEmpty(loandetailsDAL.errorDescription))
                    Notificaion("Error!", "Algo salio mal, mas detalles: " + loandetailsDAL.errorDescription, "error");

             
            }
            catch (Exception ex)
            {
                Notificaion("Error!", "Algo salio mal, mas detalles: " + ex.Message, "error");
    
            }

            loandetailsDAL = null;
        }
        public void CargarCuotasVencidas()
        {

            LoandetailsDAL loandetailsDAL = new LoandetailsDAL();
            LoandetailsEntity loandetailsEntity = new LoandetailsEntity();
            List<LoandetailsEntity> listLoandetailsEntity = new List<LoandetailsEntity>();

            GvListPretamos.DataSource = null;
            GvListPretamos.DataBind();

            try
            {
                listLoandetailsEntity = loandetailsDAL.SearchDueDate(loandetailsEntity, loginDAL);
                foreach (LoandetailsEntity item in listLoandetailsEntity)
                {
                    item.TotalDueAmount = Math.Ceiling(item.InterestBalance + item.CapitalBalance);
                    item.TotalAmount = Math.Ceiling(item.Interest + item.Capital);

                }

                for (int i = 0; i < listLoandetailsEntity.Count; i++)
                {
                    if (listLoandetailsEntity[i].Date > Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00"))
                    {
                        listLoandetailsEntity.RemoveAt(i);
                    }

                }

                GvListPretamos.DataSource = listLoandetailsEntity;
                GvListPretamos.DataBind();


                if (!string.IsNullOrEmpty(loandetailsDAL.errorDescription))
                    Notificaion("Error!", "Algo salio mal, mas detalles: " + loandetailsDAL.errorDescription, "error");


            }
            catch (Exception ex)
            {
                Notificaion("Error!", "Algo salio mal, mas detalles: " + ex.Message, "error");

            }

            loandetailsDAL = null;
        }
        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        protected void GvListPretamos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                dateDetail = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Date").ToString());
                currentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00");

                if (dateDetail < currentDate)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
                else 
                {

                    //e.Row.BackColor = System.Drawing.Color.White;
                }




            }
        }

        protected void BtnRecargarDatos_ServerClick(object sender, EventArgs e)
        {
            Cargar();

        }
        protected void BtnImprimir_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "script", "ImprimirListPrestamos()", true);
        }
        protected void BtnCuotaVencida_ServerClick(object sender, EventArgs e)
        {
            CargarCuotasVencidas();
        }
    }
}