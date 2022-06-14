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

    public partial class ClienteWF : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                if (GvClientes.Controls.Count == 0)
                {
                    GvClientes.DataSource = null;
                    GvClientes.DataBind();
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

          

            RegularExpressionValidator1.EnableClientScript = false;

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

        protected void GvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (!loginDAL.IsAdministrator)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                }
            }

           
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (RegularExpressionValidator1.IsValid)
            {
                Response.Redirect("ClienteCrearWF.aspx");
            }

        }

        private void cargar() 
        {

            CustomersDAL customersDAL = new CustomersDAL();
            CustomersEntity customersEntity = new CustomersEntity();
            customersDAL.dbm.DataSource = loginDAL.DataSource;
            customersDAL.dbm.User = loginDAL.UserName;
            customersDAL.dbm.Password = loginDAL.UserPassword;
            customersDAL.dbm.DataBase = loginDAL.DataBaseName;

            try
            {

                if (RegularExpressionValidator1.IsValid)
                {

                    customersEntity.ID = String.IsNullOrEmpty(TbCustomerID.Text) ? 0 : int.Parse(TbCustomerID.Text);
                    customersEntity.IdentificationNumber = String.IsNullOrEmpty(TbDocumentNumber.Text) ? null : TbDocumentNumber.Text;
                    customersEntity.Name = String.IsNullOrEmpty(TbName.Text) ? null : TbName.Text;
                    GvClientes.Controls.Clear();

                    GvClientes.DataSource = customersDAL.Search(customersEntity, loginDAL);
                    GvClientes.DataBind();
                }


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
            Session["ctrl"] = GvClientes;
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Imprimir.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
        }

        protected void GvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GvClientes.SelectedRow.RowIndex >= 0)
            {
                CustomersEntity customersEntity = new CustomersEntity();
                List<CustomersEntity> customersEntityList = new List<CustomersEntity>();
                CustomersDAL customersDAL = new CustomersDAL();


                customersEntity.ID = int.Parse(GvClientes.SelectedRow.Cells[0].Text);
                customersEntityList = customersDAL.Search(customersEntity, loginDAL);

                if (customersEntityList.Count > 0)
                {
                    customersEntity = customersEntityList[0];
                    Session["Parametro"] = customersEntity;
                    Response.Redirect("ClienteCrearWF.aspx");
                }

            }




        }
        protected void GvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), null, "EliminarCliente('" + GvClientes.Rows[e.RowIndex].Cells[0].Text + "');", true);
                GvClientes.DataSource = null;
                GvClientes.DataBind();
            }

        }

        protected void GvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            if (e != null)
            {
                if (e.RowIndex >= 0)
                {
                    GridViewRow row = GvClientes.Rows[e.RowIndex];


                    LoansEntity loansEntity = new LoansEntity();
                    loansEntity.CustomerID = Int32.Parse(row.Cells[0].Text);


                    Session["Parametro"] = loansEntity;
                    Response.Redirect("PrestamosWF.aspx");


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
