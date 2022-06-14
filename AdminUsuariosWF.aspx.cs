using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class AdminUsuarios : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
            }

            if (!IsPostBack)
            {
                ContendorE.Style.Add("display", "none");
                ContendorC.Style.Add("display", "block");
                ContendorD.Style.Add("display", "block");
                Session["ListaDetalle"] = null;
                if (GvUsuarios.Controls.Count == 0)
                {
                    CargarDropDown();
                    GvUsuarios.DataSource = null;
                    GvUsuarios.DataBind();
                    Cargar();

                }
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
        protected void BtnReiniciarBalance_Click(object sender, EventArgs e)
        {
          

            try
            {
                DateTime dateCurr = DateTime.Now;
                string currentDate = dateCurr.ToString("yyyyMMdd");
                string hourMinute = TbHora.Text + ":" + TbMinuto.Text;
                DateTime lastPaymentD = Convert.ToDateTime(InputFechaPago.Value + " " + hourMinute);

                UsersDAL usersDAL = new UsersDAL();
                usersDAL.LastPaymentDate = lastPaymentD;
                usersDAL.UserID = Convert.ToInt32(TbIDE.Text);



                if (usersDAL.UpdateLastPaymentDate(loginDAL)) 
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), null, "Confirmacion('Balance Reiniciado con Exito!','AdminUsuariosWF.aspx')", true);
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }
           

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            ContendorE.Style.Add("display", "none");
            ContendorC.Style.Add("display", "block");
            ContendorD.Style.Add("display", "block");
            Limpiar();
            Cargar();
            CargarDropDown();

        }

        protected void GvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GvUsuarios.SelectedRow.RowIndex >= 0)
            {
                ContendorC.Style.Add("display", "none");
                ContendorD.Style.Add("display", "none");
                ContendorE.Style.Add("display", "block");

                TbIDE.Text = GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[0].Text;
                TbNombreE.Text = GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[1].Text;
                TbEmpleadoE.Text = GvUsuarios.Rows[GvUsuarios.SelectedRow.RowIndex].Cells[2].Text;
                InputFechaPago.Value = DateTime.Now.ToString("yyyy-MM-dd");

            }


        }
       
        protected void Limpiar() 
        {
            TbID.Text = "";
            TbIDE.Text = "";
            TbNombre.Text = "";
            TbNombreE.Text = "";
            TbEmpleadoE.Text = "";
        }
        public void Cargar()
        {

            UsersDAL usersDAL = new UsersDAL();

            try
            {

                if (!String.IsNullOrEmpty(TbID.Text))
                    usersDAL.EmployeeID = int.Parse(TbID.Text);

                if (!String.IsNullOrEmpty(TbNombre.Text))
                    usersDAL.Name = TbNombre.Text;

                if (!String.IsNullOrEmpty(TbNombre.Text))
                    usersDAL.Name = TbNombre.Text;

                if (DropDownListEmpleado.SelectedItem.Value.ToString() != "-- Seleccione --")
                {
                    usersDAL.EmployeeID = Convert.ToInt32(DropDownListEmpleado.SelectedItem.Value);
                }              


                GvUsuarios.Controls.Clear();
                GvUsuarios.DataSource = usersDAL.Search(loginDAL);
                GvUsuarios.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }



        }
        protected void CargarDropDown()
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            try
            {

                DropDownListEmpleado.DataSource = employeeDAL.LoadCombo(loginDAL);
                DropDownListEmpleado.DataValueField = "employeeID";
                DropDownListEmpleado.DataTextField = "name";
                DropDownListEmpleado.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            employeeDAL = null;

        }

    }
}