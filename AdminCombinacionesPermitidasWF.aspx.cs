using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class AdminCombinacionesPermitidasWF : System.Web.UI.Page
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
                    CargarCombinacion();
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
            if (REVId.IsValid)
                CargarCombinacion();

        }
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TbMontoLimite.Text))
                ActualizarLimite();
        }


        protected void ActualizarLimite()
        {
            CombinationsDAL combinationsDAL = new CombinationsDAL();

           

            try
            {

                foreach (GridViewRow item in GvCombinacion.Rows)
                {
                    System.Web.UI.WebControls.CheckBox checkBoxItem = (System.Web.UI.WebControls.CheckBox)item.FindControl("CbItem");
                    if (checkBoxItem.Checked)
                    {
                        combinationsDAL = new CombinationsDAL();
                        combinationsDAL.CombinationID = int.Parse(item.Cells[0].Text);
                        combinationsDAL.Combination = int.Parse(item.Cells[1].Text);
                        combinationsDAL.PlayTypeID = int.Parse(item.Cells[6].Text);
                        combinationsDAL.GainAmount = int.Parse(TbMontoLimite.Text);
                        combinationsDAL.Enabled = item.Cells[5].Text == "True" ? true : false;
                        combinationsDAL.Update(loginDAL);
                    }

                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }

            combinationsDAL = null;
            //BtnBuscar.ServerClick += new EventHandler(this.BtnBuscar_Click);

            CargarCombinacion();
        }

        protected void CargarDropDown()
        {

            PlayTypesDAL playTypesDAL = new PlayTypesDAL();

            try
            {

                DropDownTipoJugada.DataSource = null;
                DropDownTipoJugada.DataSource = playTypesDAL.LoadCombo(loginDAL);
                DropDownTipoJugada.DataValueField = "PlayTypeID";
                DropDownTipoJugada.DataTextField = "Name";
                DropDownTipoJugada.DataBind();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            playTypesDAL = null;

        }
        protected void CargarCombinacion()
        {
            CombinationsDAL combinationsDAL = new CombinationsDAL();

           

            GvCombinacion.DataSource = null;

            try
            {
                if (!String.IsNullOrEmpty(TbID.Text))
                    combinationsDAL.CombinationID = int.Parse(TbID.Text);



                if (DropDownTipoJugada.SelectedItem.Value.ToString() != "-- Seleccione --")
                {
                    combinationsDAL.PlayTypeID = Convert.ToInt32(DropDownTipoJugada.SelectedItem.Value);
                }


                GvCombinacion.DataSource = combinationsDAL.Search(loginDAL);

                if (combinationsDAL.ErrorCode != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: Error: " + combinationsDAL.ErrorCode + " :: " + combinationsDAL.ErrorDescription + "','error');", true);

                }
                else
                {
                    GvCombinacion.DataBind();
                    TbMontoLimite.Text = "";
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }

            combinationsDAL = null;
        }
        protected void CbItem_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox checkBox = (System.Web.UI.WebControls.CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;

        }
        protected void CbHeader_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox checkBoxHeader = (System.Web.UI.WebControls.CheckBox)GvCombinacion.HeaderRow.FindControl("CbHeader");
            foreach (GridViewRow item in GvCombinacion.Rows)
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