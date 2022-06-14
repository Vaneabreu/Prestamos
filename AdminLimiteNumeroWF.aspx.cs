using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class AdminLimiteNumeroWF : System.Web.UI.Page
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
                    CargarLimiteNumero();
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
            if (REVId.IsValid && REVNumero.IsValid)
            {
                CargarLimiteNumero();
                TbID.Text = "";
                TbNumero.Text = "";
                CargarDropDown();
            }

        }
        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            ContendorCabecera.Visible = false;
            ContenedorGrid.Visible = false;
            ContenedorNuevo.Visible = true;
            BtnBorrar.Visible = false;
            CargarDropDown2();

        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (RFVMontoLimite.IsValid && RFVNumeroNuevo.IsValid && REVMontoLimite.IsValid && REVNumeroNuevo.IsValid)
            {
                if (DropDownTipoJugadaNuevo.SelectedItem.Text.ToString() != "-- Seleccione Tipo de Juagada --")
                {
                    string error = "";
                    string selecion = DropDownTipoJugadaNuevo.SelectedItem.Text;
                    selecion = selecion.Substring(0, selecion.IndexOf("-"));
                    selecion = selecion.Replace(" ", String.Empty);
                    switch (TbNumeroNuevo.Text.Length)
                    {
                        case 2:
                            if (selecion != "Quiniela")
                            {
                                error = "Numero erroneo para el tipo de jugada selecionado";
                            }
                            break;
                        case 4:
                            if (selecion != "Pale")
                            {
                                error = "Numero erroneo para el tipo de jugada selecionado";
                            }
                            break;
                        case 6:
                            if (selecion != "Tripleta")
                            {
                                error = "Numero erroneo para el tipo de jugada selecionado";
                            }
                            break;
                        default:
                            error = "Numero fuera de rango, solo se perminten de dos(00), cuatro(0000) y seis(000000) digitos";
                            break;
                    }
                    if (error == "")
                    {
                        string validar = Validar();
                        if (validar == "N")
                        {
                            if (Guardar())
                            {
                                Limpiar();
                                ContendorCabecera.Visible = true;
                                ContenedorGrid.Visible = true;
                                ContenedorNuevo.Visible = false;
                                CargarLimiteNumero();
                            }
                        }
                        else if (validar == "S")
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','El numero actual ya esta limitado para este tipo de jugada','error');", true);
                        }
                        else 
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','" + validar + "','error');", true);
                        }
                        
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','"+ error + "','error');", true);
                    }
                  



                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Debe selecionar un tipo de jugada!','error');", true);

                }

            }

        }
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            ContendorCabecera.Visible = true;
            ContenedorGrid.Visible = true;
            ContenedorNuevo.Visible = false;

        }
        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            LimitNumbersDAL limitNumbersDAL = new LimitNumbersDAL();
         
            try
            {

                limitNumbersDAL.LimitNumberID = int.Parse(TbLimitNumberID.Text);
                limitNumbersDAL.Delete(loginDAL);

                Limpiar();
                ContendorCabecera.Visible = true;
                ContenedorGrid.Visible = true;
                ContenedorNuevo.Visible = false;
                CargarLimiteNumero();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            limitNumbersDAL = null;
        }

        protected bool Guardar()
        {
            LimitNumbersDAL limitNumbersDAL = new LimitNumbersDAL();
          
            bool respuesta = false;
            try
            {
                if (string.IsNullOrEmpty(TbLimitNumberID.Text))
                {
                    limitNumbersDAL.LimitNumberID = 0;
                }
                else
                {
                    limitNumbersDAL.LimitNumberID = Convert.ToInt32(TbLimitNumberID.Text);
                }


                limitNumbersDAL.Numbers = TbNumeroNuevo.Text;
                limitNumbersDAL.LimitAmount = Convert.ToInt32(TbMontoLimite.Text);
                limitNumbersDAL.Enabled = DropDownListEnabled.SelectedItem.Value.ToUpper() == "SI" ? true : false;
                if (DropDownTipoJugadaNuevo.SelectedItem.Text.ToString() != "-- Seleccione Tipo de Juagada --")
                {
                    limitNumbersDAL.PlayTypeID = Convert.ToInt32(DropDownTipoJugadaNuevo.SelectedItem.Value);
                }

                if (limitNumbersDAL.LimitNumberID == 0)
                {
                    respuesta = limitNumbersDAL.Insert(loginDAL);
                }
                else
                {
                    respuesta = limitNumbersDAL.Update(loginDAL);
                }

                if (!respuesta)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + limitNumbersDAL.ErrorDescription + "','error');", true);


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            limitNumbersDAL = null;
            return respuesta;
        }
        protected void Borrar()
        {
            LimitNumbersDAL limitNumbersDAL = new LimitNumbersDAL();
           


        }
        protected string Validar() 
        {
            string respuesta = "N";
            LimitNumbersDAL limitNumbersDAL = new LimitNumbersDAL();
           
            List<LimitNumbersDAL> listLimitNumbersDAL = new List<LimitNumbersDAL>();
            try
            {
                limitNumbersDAL.PlayTypeID = Convert.ToInt32(DropDownTipoJugadaNuevo.SelectedItem.Value);
                limitNumbersDAL.Numbers = TbNumeroNuevo.Text;

                listLimitNumbersDAL = limitNumbersDAL.Search(loginDAL);
                if (listLimitNumbersDAL.Count > 0)
                {
                    respuesta = "S";
                }

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            return respuesta;
        }
        protected void Limpiar()
        {
            TbLimitNumberID.Text = "";
            TbNumeroNuevo.Text = "";
            TbMontoLimite.Text = "";
            DropDownListEnabled.SelectedItem.Value = "Si";
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
        protected void CargarDropDown2()
        {
            PlayTypesDAL playTypesDAL = new PlayTypesDAL();
          
            try
            {

                DropDownTipoJugadaNuevo.DataSource = null;
                DropDownTipoJugadaNuevo.DataSource = playTypesDAL.LoadCombo(loginDAL);
                DropDownTipoJugadaNuevo.DataValueField = "PlayTypeID";
                DropDownTipoJugadaNuevo.DataTextField = "Name";
                DropDownTipoJugadaNuevo.DataBind();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            playTypesDAL = null;

        }
        protected void CargarLimiteNumero()
        {
            LimitNumbersDAL limitNumbersDAL = new LimitNumbersDAL();
           
            GvLimiteNumero.DataSource = null;

            try
            {
                if (!String.IsNullOrEmpty(TbID.Text))
                    limitNumbersDAL.LimitNumberID = int.Parse(TbID.Text);

                if (!String.IsNullOrEmpty(TbNumero.Text))
                    limitNumbersDAL.Numbers = TbNumero.Text;

                if (DropDownTipoJugada.SelectedItem.Text.ToString() != "-- Seleccione Tipo de Juagada --")
                {
                    limitNumbersDAL.PlayTypeID = Convert.ToInt32(DropDownTipoJugada.SelectedItem.Value);
                }


                GvLimiteNumero.DataSource = limitNumbersDAL.Search(loginDAL);

                if (limitNumbersDAL.ErrorCode != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: Error: " + limitNumbersDAL.ErrorCode + " :: " + limitNumbersDAL.ErrorDescription + "','error');", true);

                }
                else
                {
                    GvLimiteNumero.DataBind();
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }

            limitNumbersDAL = null;
        }

        protected void GvLimiteNumero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GvLimiteNumero.SelectedRow.RowIndex >= 0)
            {

                BtnBorrar.Visible = true;
                ContendorCabecera.Visible = false;
                ContenedorGrid.Visible = false;
                ContenedorNuevo.Visible = true;
                CargarDropDown2();
                TbLimitNumberID.Text = GvLimiteNumero.SelectedRow.Cells[0].Text;
                TbNumeroNuevo.Text = GvLimiteNumero.SelectedRow.Cells[2].Text;
                TbMontoLimite.Text = GvLimiteNumero.SelectedRow.Cells[3].Text;
                //DropDownTipoJugadaNuevo.SelectedItem.Text = GvLimiteNumero.SelectedRow.Cells[1].Text;
                //DropDownListEnabled.SelectedItem.Value = GvLimiteNumero.SelectedRow.Cells[4].Text=="True"?"SI":"NO";

            }


        }
              
    }
}