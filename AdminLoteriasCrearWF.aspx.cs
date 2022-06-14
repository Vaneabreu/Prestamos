using SoftLoans.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class AdminLoteriasCrearWF : System.Web.UI.Page
    {
        public string codigo;
        LoginDAL loginDAL = new LoginDAL();
        List<TransactionDetailsDAL> listMail = new List<TransactionDetailsDAL>();
        StringBuilder mail = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];

                if (!IsPostBack)
                {
                    //CargarDropDown();
                    CargarInicio();
                }
            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }

         

        }
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

        protected void BtnCerrarSeccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioWF.aspx");

        }
  
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {


            Response.Redirect("NumerosGanadoresWF.aspx");


        }
        protected void BtnLoterias_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeleccionLoteriaWF.aspx");

        }
        protected void BtnTickets_Click(object sender, EventArgs e)
        {

            Response.Redirect("TicketsListWF.aspx");

        }
        protected void BtnTicketsWin_Click(object sender, EventArgs e)
        {

            Response.Redirect("TicketsWinListWF.aspx");

        }

        protected void BtnNumerosGanadores_Click(object sender, EventArgs e)
        {
            Response.Redirect("NumerosGanadoresWF.aspx");

        }
        protected void BtnCuadre_Click(object sender, EventArgs e)
        {

            Response.Redirect("CuadreWF.aspx");
        }
    

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (RFVID.IsValid && RFVName.IsValid && RFVClosingTime.IsValid && RFVSundayClosingTime.IsValid)
            {

                Actuaizar();

            }

        }

        public void Notificacion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        protected void CargarInicio()
        {
            RFVID.EnableClientScript = false;
            RFVName.EnableClientScript = false;
            RFVClosingTime.EnableClientScript = false;
            RFVSundayClosingTime.EnableClientScript = false;

            if (Session["Parametro"] != null)
            {
                LotteriesDAL lotteriesDAL = new LotteriesDAL();
                lotteriesDAL = (LotteriesDAL)Session["Parametro"];
                

                TbID.Text = lotteriesDAL.LotteryID.ToString();
                TbName.Text = lotteriesDAL.Name;
                TbClosingTime.Text = lotteriesDAL.ClosingTime;
                TbSundayClosingTime.Text = lotteriesDAL.SundayClosingTime;
                TbDescription.Text = lotteriesDAL.Description;

                //DropDownListTanda.SelectedIndex = lotteriesDAL.ShiftName == "Noche" ? 0 : 1;
                TbTanda.Text = lotteriesDAL.ShiftName;
                DropDownListEnabled.SelectedIndex = lotteriesDAL.Enabled ? 0 : 1;
                lotteriesDAL = null;
                Session["Parametro"] = null;
            }
        }
        protected void Actuaizar()
        {
            LotteriesDAL lotteriesDAL = new LotteriesDAL();
           

            ShiftsDAL shiftsDAL = new ShiftsDAL();
            

            List<ShiftsDAL> shiftsDALList = new List<ShiftsDAL>();
          


            try
            {
                shiftsDALList = shiftsDAL.Search(loginDAL);
                shiftsDALList  = shiftsDALList.Where(x => x.Name == TbTanda.Text).ToList();

                lotteriesDAL.LotteryID = String.IsNullOrEmpty(TbID.Text) ? 0 : int.Parse(TbID.Text);
                lotteriesDAL.Name = String.IsNullOrEmpty(TbName.Text) ? "" : TbName.Text;
                lotteriesDAL.ClosingTime = String.IsNullOrEmpty(TbClosingTime.Text) ? "" : TbClosingTime.Text;
                lotteriesDAL.SundayClosingTime = String.IsNullOrEmpty(TbSundayClosingTime.Text) ? "" : TbSundayClosingTime.Text;
                lotteriesDAL.Description = String.IsNullOrEmpty(TbDescription.Text) ? "" : TbDescription.Text;
                lotteriesDAL.ShiftID = shiftsDALList[0].ShiftID;
                lotteriesDAL.Enabled = DropDownListEnabled.SelectedValue != "SI" ? false : true;

                if (lotteriesDAL.Edit(loginDAL))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), null, "Confirmacion('Loteria actualizada con exito!','AdminLoteriasWF.aspx')", true);
                }
                else 
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + lotteriesDAL.ErrorDescription + "','error');", true);
                }
                
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            lotteriesDAL = null;
            shiftsDAL = null;

        }

        protected void CargarDropDown()
        {
            ShiftsDAL shiftsDAL = new ShiftsDAL();
            
            try
            {

                //DropDownListTanda.DataSource = shiftsDAL.Search();
                //DropDownListTanda.DataValueField = "ShiftID";
                //DropDownListTanda.DataTextField = "name";
                //DropDownListTanda.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            shiftsDAL = null;

        }

    }
}