using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;

namespace SoftLoans
{

    public partial class AdminTipoJugadaWF : System.Web.UI.Page
    {
        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                if (!IsPostBack)
                {
                    CargarDropDown();
                    CargarTipoJugada();
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
            CargarTipoJugada();

        }
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TbComision.Text))
                ActualizarComision();
        }

        protected void CargarDropDown()
        {
            LotteriesDAL lotteriesModel = new LotteriesDAL();

            try
            {

                DropDownListLottery.DataSource = null;
                DropDownListLottery.DataSource = lotteriesModel.LoadCombo(loginDAL);
                DropDownListLottery.DataValueField = "LotteryID";
                DropDownListLottery.DataTextField = "Name";
                DropDownListLottery.DataBind();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            lotteriesModel = null;

        }
        protected void CargarTipoJugada()
        {
            PlayTypesDAL playTypesDAL = new PlayTypesDAL();


            GvTipoJugada.DataSource = null;

            try
            {
                if (!String.IsNullOrEmpty(TbID.Text))
                    playTypesDAL.PlayTypeID = int.Parse(TbID.Text);

                if (!String.IsNullOrEmpty(TbNombre.Text))
                    playTypesDAL.Name = TbNombre.Text;

                if (DropDownListLottery.SelectedItem.Value.ToString() != "-- Seleccione --")
                {
                    playTypesDAL.LotteryID = Convert.ToInt32(DropDownListLottery.SelectedItem.Value);
                }


                GvTipoJugada.DataSource = playTypesDAL.Search(loginDAL);

                if (playTypesDAL.ErrorCode != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: Error: " + playTypesDAL.ErrorCode + " :: " + playTypesDAL.ErrorDescription + "','error');", true);

                }
                else
                {
                    GvTipoJugada.DataBind();
                    TbComision.Text = "";
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }

            playTypesDAL = null;
        }
        protected void ActualizarComision()
        {
            PlayTypesDAL playTypesDAL = new PlayTypesDAL();


            try
            {

                foreach (GridViewRow item in GvTipoJugada.Rows)
                {
                    System.Web.UI.WebControls.CheckBox checkBoxItem = (System.Web.UI.WebControls.CheckBox)item.FindControl("CbItem");
                    if (checkBoxItem.Checked)
                    {
                        playTypesDAL = new PlayTypesDAL();


                        playTypesDAL.PlayTypeID = int.Parse(item.Cells[0].Text);
                        playTypesDAL.CommissionPercent = decimal.Parse(TbComision.Text);
                        playTypesDAL.PartnerCommissionPercent = decimal.Parse(item.Cells[4].Text);
                        playTypesDAL.Update(loginDAL);
                    }

                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }

            playTypesDAL = null;
            //BtnBuscar.ServerClick += new EventHandler(this.BtnBuscar_Click);

            CargarTipoJugada();
        }


        protected void CbItem_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox checkBox = (System.Web.UI.WebControls.CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;

        }
        protected void CbHeader_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox checkBoxHeader = (System.Web.UI.WebControls.CheckBox)GvTipoJugada.HeaderRow.FindControl("CbHeader");
            foreach (GridViewRow item in GvTipoJugada.Rows)
            {
                System.Web.UI.WebControls.CheckBox checkBoxItem = (System.Web.UI.WebControls.CheckBox)item.FindControl("CbItem");
                if (checkBoxHeader.Checked)
                    checkBoxItem.Checked = true;
                else
                    checkBoxItem.Checked = false;

            }
        }
    }
}