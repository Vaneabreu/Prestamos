using SoftLoans.Capas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class NumerosGanadoresWF : System.Web.UI.Page
    {
        LoginDAL loginDAL = new LoginDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
               
                if (!IsPostBack)
                {
                   
                    InputFecha.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    GvNumbers.DataSource = null;
                    GvNumbers.DataBind();

                    if (!loginDAL.IsAdministrator)
                    {
                        BtnNuevo.Style.Add("display", "none");
                        menuAdmin.Style.Add("display", "none");
                        GvNumbers.Columns.RemoveAt(9);
                    }
                    else
                    { 
                        menuUser.Style.Add("display", "none");
                    }


                    Cargar();
                }
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
        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NumerosGanadoresCrearWF.aspx");


        }

        public void Cargar()
        {

            try
            {
                WinNumbersDAL winNumbersDAL = new WinNumbersDAL();
                winNumbersDAL.StartDate = Convert.ToDateTime(InputFecha.Value.ToString());
                winNumbersDAL.EndDate = Convert.ToDateTime(InputFecha.Value);

                GvNumbers.DataSource = null;
                GvNumbers.DataSource = winNumbersDAL.Search(loginDAL);
                GvNumbers.DataBind();

            }
            catch (Exception ex)
            {
                Notificaion("Algo salio mal!", "Detalles del error:" + ex.Message, "warning");

            }

        }
        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        protected void GvNumbersRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Borrar(GvNumbers.Rows[e.RowIndex].Cells[0].Text);

                //string title = "Estas seguro?";
                //string text = "Una vez Borrado, ¡no podrá recuperar este registro!";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), null, "NotificacionYN('" + GvNumbers.Rows[e.RowIndex].Cells[0].Text + "','" + title + "','" + text + "','" + OpcionesNotificaciones.Borrar + "');", true);
                //GvNumbers.DataSource = null;
                //GvNumbers.DataBind();
            }
        }
        protected void GvNumbers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
        protected void GvNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Borrar(string codigo)
        {
            WinNumbersDAL winNumbersDAL = new WinNumbersDAL();
           // string result = "Congratulations!!!";
            try
            {

                winNumbersDAL.WinNumberID = int.Parse(codigo);
                winNumbersDAL.Delete(loginDAL);

                Cargar();
               // result = "Registro Eliminado exitosamente!";

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }
            winNumbersDAL = null;

        }

        //[WebMethod]
        //public static string Borrar(string codigo)
        //{
        //    WinNumbersDAL winNumbersDAL = new WinNumbersDAL();
        //    string result = "Congratulations!!!";
        //    try
        //    {

        //        winNumbersDAL.WinNumberID = int.Parse(codigo);
        //        winNumbersDAL.Delete(loginDAL);

        //        result = "Registro Eliminado exitosamente!";
              
        //    }
        //    catch (Exception ex)
        //    {
        //        result = "Algo salio mal, mas detalles: " + ex.Message;

        //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
        //    }
        //    winNumbersDAL = null;
        //    return result;

        //}
    
    
    }
}