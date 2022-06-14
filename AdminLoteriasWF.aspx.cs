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
    public partial class AdminLoteriasWF : System.Web.UI.Page
    {
        LoginDAL loginDAL = new LoginDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                if (!IsPostBack)
                {
                    GvLottery.DataSource = null;
                    GvLottery.DataBind();

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
     

        public void Cargar()
        {

            try
            {
                LotteriesDAL lotteriesDAL = new LotteriesDAL();
               

                GvLottery.DataSource = null;
                GvLottery.DataSource = lotteriesDAL.Search(loginDAL);
                GvLottery.DataBind();

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

      
        protected void GvLottery_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GvLottery.SelectedRow.RowIndex >= 0)
            {
                LotteriesDAL lotteriesDAL = new LotteriesDAL();
               

                lotteriesDAL.LotteryID = int.Parse(GvLottery.SelectedRow.Cells[0].Text);

                if (!String.IsNullOrEmpty(GvLottery.SelectedRow.Cells[2].Text) && GvLottery.SelectedRow.Cells[2].Text != "&nbsp;")
                    lotteriesDAL.Name = GvLottery.SelectedRow.Cells[2].Text;

                if (!String.IsNullOrEmpty(GvLottery.SelectedRow.Cells[3].Text) && GvLottery.SelectedRow.Cells[3].Text != "&nbsp;")
                    lotteriesDAL.ClosingTime = GvLottery.SelectedRow.Cells[3].Text;

                if (!String.IsNullOrEmpty(GvLottery.SelectedRow.Cells[4].Text) && GvLottery.SelectedRow.Cells[4].Text != "&nbsp;")
                    lotteriesDAL.SundayClosingTime = GvLottery.SelectedRow.Cells[4].Text;


                if (!String.IsNullOrEmpty(GvLottery.SelectedRow.Cells[5].Text) && GvLottery.SelectedRow.Cells[5].Text != "&nbsp;")
                    lotteriesDAL.ShiftName = GvLottery.SelectedRow.Cells[5].Text;

                if (!String.IsNullOrEmpty(GvLottery.SelectedRow.Cells[6].Text) && GvLottery.SelectedRow.Cells[5].Text != "&nbsp;")
                    lotteriesDAL.Description = GvLottery.SelectedRow.Cells[6].Text;

                lotteriesDAL.Enabled = GvLottery.SelectedRow.Cells[7].Text == "True" ? true : false;


                Session["Parametro"] = lotteriesDAL;
                Response.Redirect("AdminLoteriasCrearWF.aspx");
            }
        }

  
    }
}