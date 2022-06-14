using Loans.Entity;
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

    public partial class PrestamosWF : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                if (GvPrestamos.Controls.Count == 0)
                {
                    GvPrestamos.DataSource = null;
                    GvPrestamos.DataBind();
                    cargar();
                }
            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }
            if (!loginDAL.IsAdministrator)
            {
                BtnNuevo.Visible = false;
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


        protected void GvPrestamos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (!loginDAL.IsAdministrator)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[8].Visible = false;
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[8].Visible = false;
                }
            }

           
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("PrestamoCrearWF.aspx");

        }

        private void cargar() 
        {

            LoanDAL loanDAL = new LoanDAL();
            LoansEntity loansEntity = new LoansEntity();
            loanDAL.dbm.DataSource = loginDAL.DataSource;
            loanDAL.dbm.User = loginDAL.UserName;
            loanDAL.dbm.Password = loginDAL.UserPassword;
            loanDAL.dbm.DataBase = loginDAL.DataBaseName;

            try
            {

                if (Session["Parametro"] != null)
                {
                    loansEntity = (LoansEntity)Session["Parametro"];
                    TbCustomerID.Text = loansEntity.CustomerID.ToString();
                }

                loansEntity.CustomerID = String.IsNullOrEmpty(TbCustomerID.Text) ? 0 : int.Parse(TbCustomerID.Text);
                loansEntity.CustomerName = String.IsNullOrEmpty(TbCustumerName.Text) ? null : TbCustumerName.Text;
                loansEntity.ID = String.IsNullOrEmpty(TbID.Text) ? 0 : int.Parse(TbID.Text);
                GvPrestamos.Controls.Clear();

                GvPrestamos.DataSource = loanDAL.Search(loansEntity, loginDAL);
                GvPrestamos.DataBind();
                Session["Parametro"] = null;


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            cargar();

        }

        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            Session["ctrl"] = GvPrestamos;
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Imprimir.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
        }

        protected void GvPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GvPrestamos.SelectedRow.RowIndex >= 0)
            {
                CustomersDAL customersDAL = new CustomersDAL();
                LoandetailsEntity loandetailsEntity = new LoandetailsEntity();


                loandetailsEntity.LoandID = int.Parse(GvPrestamos.SelectedRow.Cells[0].Text);
                loandetailsEntity.CustomerName = GvPrestamos.SelectedRow.Cells[2].Text;
                loandetailsEntity.FilterDate = false;

                Session["ParametroDetalle"] = loandetailsEntity;

                Response.Redirect("DetallePrestamosWF.aspx");

            }




        }
        protected void GvPrestamos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), null, "EliminarCliente('" + GvPrestamos.Rows[e.RowIndex].Cells[0].Text + "');", true);
                GvPrestamos.DataSource = null;
                GvPrestamos.DataBind();
            }

        }

        protected void GvPrestamos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            if (e != null)
            {
                if (e.RowIndex >= 0)
                {
                    GridViewRow row = GvPrestamos.Rows[e.RowIndex];


                    TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.TransactionID = Int64.Parse(row.Cells[0].Text);
                    transactionDetailsDAL.LotteryName = row.Cells[2].Text.Replace("&#241;", "ñ");


                    Session["Parametro"] = transactionDetailsDAL;
                    Response.Redirect("TicketsDetalleWF.aspx");


                }
            }



        }



        [WebMethod]
        public static string Borrar(string codigo)
        {
            CustomersDAL customersDAL = new CustomersDAL();




            string result = "Congratulations!!! your account has been created.";
            try
            {

               //customersDAL.Delete(int.Parse(codigo), loginDAL);

                result = "Cliente Elimindo exitosamente!";

            }
            catch (Exception ex)
            {
                result = "Algo salio mal, mas detalles: " + ex.Message;

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }
            customersDAL = null;
            return result;

        }
    }

}
