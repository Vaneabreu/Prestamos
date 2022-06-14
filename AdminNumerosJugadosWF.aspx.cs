using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class AdminNumerosJugadosWF : System.Web.UI.Page
    {
        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                if (!IsPostBack)
                {
                    InputFechaInicio.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    InputFechaFin.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    CargarDropDown();
                    CargarNumerosJugados();
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
        public void CargarNumerosJugados()
        {

            TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
           

            List<TransactionDetailsDAL> listTransactionDetailsDAL = new List<TransactionDetailsDAL>();
            LotteriesDAL lotteriesDAL = new LotteriesDAL();
            

            List<LotteriesDAL> listLotteriesDAL = new List<LotteriesDAL>();
            DateTime StartTime = Convert.ToDateTime(InputFechaInicio.Value);
            DateTime EndTime = Convert.ToDateTime(InputFechaFin.Value + " 23:58");
            GvNumerosJugados.Controls.Clear();
            try
            {
                if (DropDownListLottery.SelectedItem.Value.ToString() != "-- Seleccione --")
                {
                    lotteriesDAL.LotteryID = Convert.ToInt32(DropDownListLottery.SelectedItem.Value);
                }
                listLotteriesDAL = lotteriesDAL.Search(loginDAL);
                if (lotteriesDAL.ErrorCode == 0)
                {
                    if (listLotteriesDAL.Count > 0)
                    {
                        foreach (LotteriesDAL itemLott in listLotteriesDAL)
                        {
                            transactionDetailsDAL.LotteryName = itemLott.Name + " " + itemLott.ShiftName;

                            listTransactionDetailsDAL = transactionDetailsDAL.GetDetailsCountNumbers(StartTime, EndTime, loginDAL);
                            if (transactionDetailsDAL.ErrorCode == 0)
                            {
                                if (listTransactionDetailsDAL.Count > 0)
                                {
                                    listTransactionDetailsDAL = listTransactionDetailsDAL.OrderBy(b => b.Numbers).ToList();
                                    listTransactionDetailsDAL = listTransactionDetailsDAL.OrderBy(b => b.Numbers.Length).ToList();
                                    //lbLotteryName.Text = transactionDetailsDAL.LotteryName;


                                    GvNumerosJugados.DataSource = listTransactionDetailsDAL;
                                    GvNumerosJugados.DataBind();
                                    //foreach (TransactionDetailsDAL item in listTransactionDetailsDAL)
                                    //{
                                    //    int rows = dataGridAmountToTake.Rows.Add();

                                    //    dataGridAmountToTake.Rows[rows].Cells["Numbers"].Value = item.Numbers.ToString();
                                    //    dataGridAmountToTake.Rows[rows].Cells["Amount"].Value = item.Amount.ToString();
                                    //    dataGridAmountToTake.Rows[rows].Cells["AmountToTake"].Value = "";


                                    //}

                                }
                            }

                        }
                    }
                }



            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }

            transactionDetailsDAL = null;
            listTransactionDetailsDAL = null;
            lotteriesDAL = null;
            listLotteriesDAL = null;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarNumerosJugados();

        }

        protected void GvNumerosJugados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvNumerosJugados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GvNumerosJugados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}