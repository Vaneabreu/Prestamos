using Loans.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoteria
{
    public partial class UsuariosWF : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
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
                Bloqueo();
                if (GvUsuarios.Controls.Count == 0)
                {
                    GvUsuarios.DataSource = null;
                    GvUsuarios.DataBind();
                    string respuesta = Cargar();
                    if (respuesta != "")
                        Notificaion("Error!", "Algo salio mal, mas detalles: " + respuesta, "error");


                }
            }



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


        protected void GvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GvUsuarios.SelectedRow.RowIndex >= 0)
            {
                ContendorC.Style.Add("display", "none");
                ContendorD.Style.Add("display", "none");
                ContendorE.Style.Add("display", "block");

                TbIDE.Text = GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[0].Text;
                TbNombreE.Text = GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[1].Text;
                TbClaveE.Text = GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[2].Text;
                CbAdmin.Checked = GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[3].Text == "True" ? true : false;

                DateTime fecha = Convert.ToDateTime(GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[4].Text, CultureInfo.InvariantCulture);
                InputFecha.Value = fecha.ToString("yyyy-MM-dd");
                DropDownEstado.SelectedValue = GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[5].Text == "True" ? "Activo" : "Inactivo";

            }

        }

        protected void BtnBuscar_ServerClick(object sender, EventArgs e)
        {

        }
        protected void BtnCancelar_ServerClick(object sender, EventArgs e)
        {
            ContendorC.Style.Add("display", "block");
            ContendorD.Style.Add("display", "block");
            ContendorE.Style.Add("display", "none");

            TbIDE.Text = "";
            TbNombreE.Text = "";
            TbClaveE.Text = "";
        }
        protected void BtnLiberar_ServerClick(object sender, EventArgs e)
        {
            LoginDAL loginDAL2 = new LoginDAL();
            try
            {

                loginDAL2.UserName = TbNombreE.Text;
                loginDAL2.DeviceID = "";

                if (loginDAL2.LiberarDeviceID())
                {
                    Notificaion("Proceso Completado!", "Usuario liberado exitosamente.", "success");
                }
                else
                { Notificaion("Error!", "Algo salio mal, mas detalles: " + loginDAL2.ErrorDescription, "error"); }
            }
            catch (Exception ex)
            {
                Notificaion("Error!", "Algo salio mal, mas detalles: " + ex.Message, "error");
            }
            loginDAL2 = null;

        }
        protected void BtnCerrar_ServerClick(object sender, EventArgs e)
        {
            LoginDAL loginDAL2 = new LoginDAL();
            try
            {

                loginDAL2.UserName = TbNombreE.Text;
                loginDAL2.DeviceID = "*****Punto Cerrado****";

                if (loginDAL2.CerrarDeviceID())
                {
                    Notificaion("Proceso Completado!", "Usuario cerrado exitosamente.", "success");
                }
                else
                { Notificaion("Error!", "Algo salio mal, mas detalles: " + loginDAL2.ErrorDescription, "error"); }

            }
            catch (Exception ex)
            {

                Notificaion("Error!", "Algo salio mal, mas detalles: " + ex.Message, "error");
            }
            loginDAL2 = null;

        }

        public void Bloqueo()
        {
            ContendorC.Style.Add("display", "block");
            ContendorD.Style.Add("display", "block");

            ContendorE.Style.Add("display", "none");
        }
        public void BloqueoNuevo()
        {
            ContendorC.Style.Add("display", "none");
            ContendorD.Style.Add("display", "none");

            ContendorE.Style.Add("display", "block");

        }
        public string Cargar()
        {
            string respuesta = "";

            UsersDAL usersDAL = new UsersDAL();
            UsersEntity usersEntity = new UsersEntity();

            try
            {

                if (!String.IsNullOrEmpty(TbID.Text))
                    usersEntity.ID = int.Parse(TbID.Text);

                if (!String.IsNullOrEmpty(TbNombre.Text))
                    usersEntity.Name = TbNombre.Text;

                GvUsuarios.Controls.Clear();
                GvUsuarios.DataSource = usersDAL.Search(usersEntity, loginDAL);
                GvUsuarios.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }

            return respuesta;

        }


        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

    }
}