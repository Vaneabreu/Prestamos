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
using System.Web;
using System.Globalization;

namespace SoftLoans
{

    public partial class DetallePrestamosWF : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
        LoandetailsEntity loandetailsEntity = new LoandetailsEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                if (Session["ParametroDetalle"] != null)
                    loandetailsEntity = (LoandetailsEntity)Session["ParametroDetalle"];
                else
                    Response.Redirect("PrestamosWF.aspx");

            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }

            if (!IsPostBack)
            {
                BtnMonto.Visible = false;
                BtnPagar.Visible = false;
                BtnModificar.Visible = false;

                BtnAbonarCapital.Visible = true;
                TbMontoAbono.Visible = true;
                DropDownTipoNCF.Visible = true;
                LbTipoNCF.Visible = true;
                if (GvDetallePrestamos.Controls.Count == 0)
                {
                    GvDetallePrestamos.DataSource = null;
                    GvDetallePrestamos.DataBind();
                    cargar();
                    loadCombo();
                }
            }
            if (loginDAL.IsAdministrator == false)
            {
                ocultarOpciones();
            }

        }

        public void ocultarOpciones()
        {
            btnPrintContrato.Style.Add("display", "none");
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


        ///Inicio Codigo para borrar luego de ser desacrtado
        protected void GvDetallePrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GvDetallePrestamos.SelectedRow.RowIndex >= 0)
            {
                //CustomersEntity customersEntity = new CustomersEntity();
                //List<CustomersEntity> customersEntityList = new List<CustomersEntity>();
                //CustomersDAL customersDAL = new CustomersDAL();


                //customersEntity.ID = int.Parse(GvDetallePrestamos.SelectedRow.Cells[0].Text);
                //customersEntityList = customersDAL.Search(customersEntity, loginDAL);

                //if (customersEntityList.Count > 0)
                //{
                //    customersEntity = customersEntityList[0];
                //    Session["Parametro"] = customersEntity;
                //    Response.Redirect("ClienteCrearWF.aspx");
                //}

            }




        }
        protected void GvDetallePrestamos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), null, "EliminarCliente('" + GvDetallePrestamos.Rows[e.RowIndex].Cells[0].Text + "');", true);
                GvDetallePrestamos.DataSource = null;
                GvDetallePrestamos.DataBind();
            }

        }
        protected void GvDetallePrestamos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            if (e != null)
            {
                if (e.RowIndex >= 0)
                {
                    GridViewRow row = GvDetallePrestamos.Rows[e.RowIndex];


                    TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.TransactionID = Int64.Parse(row.Cells[0].Text);
                    transactionDetailsDAL.LotteryName = row.Cells[2].Text.Replace("&#241;", "ñ");


                    Session["ParametroDetalle"] = transactionDetailsDAL;
                    Response.Redirect("TicketsDetalleWF.aspx");


                }
            }



        }
        protected void GvDetallePrestamos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (!loginDAL.IsAdministrator)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[9].Visible = false;

                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[9].Visible = false;

                }
            }


        }
        ///Fin Codigo para borrar luego de ser desacrtado

        protected void CbItem_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox checkBox = (System.Web.UI.WebControls.CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
            //int numeroCuota = GvDetallePrestamos.Rows[]

            int cont = 0;
            decimal monto = 0;
            decimal mora = 0;
            string interesActual = "0.0", atrasoActual = "0.00", numeroCuota = "";
            int cuotaCont = 0;

            foreach (GridViewRow item1 in GvDetallePrestamos.Rows)
            {
                System.Web.UI.WebControls.CheckBox checkBoxItem1 = (System.Web.UI.WebControls.CheckBox)item1.FindControl("CbItem");
                if (checkBoxItem1.Checked)
                    cuotaCont = int.Parse(item1.Cells[1].Text);

            }

            foreach (GridViewRow item2 in GvDetallePrestamos.Rows)
            {
                System.Web.UI.WebControls.CheckBox checkBoxItem2 = (System.Web.UI.WebControls.CheckBox)item2.FindControl("CbItem");
                if (cuotaCont > int.Parse(item2.Cells[1].Text))
                    checkBoxItem2.Checked = true;

            }

            foreach (GridViewRow item in GvDetallePrestamos.Rows)
            {
                System.Web.UI.WebControls.CheckBox checkBoxItem = (System.Web.UI.WebControls.CheckBox)item.FindControl("CbItem");
                System.Web.UI.WebControls.CheckBox checkBoxHeader = (System.Web.UI.WebControls.CheckBox)GvDetallePrestamos.HeaderRow.FindControl("CbHeader");

                if (checkBoxItem.Checked)
                {
                    cont++;



                    monto = monto + Decimal.Parse(item.Cells[3].Text);
                    mora = mora+ Decimal.Parse(item.Cells[7].Text);
                    interesActual = item.Cells[6].Text;
                    atrasoActual = item.Cells[7].Text;
                    numeroCuota = item.Cells[1].Text;

                    TbMonto.ReadOnly = true;
                    checkBoxHeader.Checked = true;
                }
                else
                {
                    TbMonto.ReadOnly = false;
                    checkBoxHeader.Checked = false;

                }

            }


            //TbMonto.Text = Math.Ceiling(monto).ToString();
            TbMonto.Text = monto.ToString();
            TbMontoMora.Text = mora.ToString();
            if (cont == 1)
            {
                BtnMonto.Visible = true;
                BtnPagar.Visible = true;
                BtnModificar.Visible = true;

                BtnAbonarCapital.Visible = false;
                TbMontoAbono.Visible = false;
                DropDownTipoNCF.Visible = false;
                LbTipoNCF.Visible = false;
                

                TbInteresActual.Text = interesActual;
                TbAtrasoActual.Text = atrasoActual;
                LbMensajeModificar.Text = "Para continuar con el proceso de modificaion de la cuota numero " + numeroCuota + ", por favor colocar los nuevos importes.";
            }
            else if (cont == 0)
            {
                BtnMonto.Visible = false;
                BtnPagar.Visible = false;
                BtnModificar.Visible = false;
                TbMonto.Text = "";


                BtnAbonarCapital.Visible = true;
                TbMontoAbono.Visible = true;
                DropDownTipoNCF.Visible = true;
                LbTipoNCF.Visible = true;
            }
            else
            {
                BtnMonto.Visible = true;
                BtnPagar.Visible = true;
                BtnModificar.Visible = false;
            }

        }
        protected void CbHeader_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox checkBoxHeader = (System.Web.UI.WebControls.CheckBox)GvDetallePrestamos.HeaderRow.FindControl("CbHeader");
            int cont = 0;
            decimal monto = 0;

            foreach (GridViewRow item in GvDetallePrestamos.Rows)
            {
                System.Web.UI.WebControls.CheckBox checkBoxItem = (System.Web.UI.WebControls.CheckBox)item.FindControl("CbItem");
                if (checkBoxHeader.Checked)
                {
                    TbMonto.ReadOnly = true;
                    checkBoxItem.Checked = true;
                    cont++;
                    monto = monto + Decimal.Parse(item.Cells[3].Text);

                    BtnAbonarCapital.Visible = false;
                    TbMontoAbono.Visible = false;
                    DropDownTipoNCF.Visible = false;
                    LbTipoNCF.Visible = false;
                }
                else
                {
                    TbMonto.ReadOnly = false;
                    checkBoxItem.Checked = false;

                    BtnAbonarCapital.Visible = true;
                    TbMontoAbono.Visible = true;
                    DropDownTipoNCF.Visible = true;
                    LbTipoNCF.Visible = true;

                }

            }

            TbMonto.Text = Math.Ceiling(monto).ToString();
            if (cont == 1)
            {
                BtnMonto.Visible = true;
                BtnPagar.Visible = true;
                BtnModificar.Visible = true;
            }
            else if (cont == 0)
            {
                BtnMonto.Visible = false;
                BtnPagar.Visible = false;
                BtnModificar.Visible = false;
                TbMonto.Text = "";
            }
            else
            {
                BtnMonto.Visible = true;
                BtnPagar.Visible = true;
                BtnModificar.Visible = false;
            }
        }
        private void cargar()
        {
            LoandetailsEntity loandetailsEntitySet = new LoandetailsEntity();
            decimal dias = 0;
            decimal quantityDelay = 0;
            TimeSpan difFechas;
            decimal delayAmount = 0;

            decimal totalDueAmount = 0;
            decimal totalPay = 0;

            if (Session["ParametroDetalle"] != null)
            {
                LoandetailsDAL loandetailsDAL = new LoandetailsDAL();
                LoandetailsEntity loandetailsEntity = new LoandetailsEntity();
                List<LoandetailsEntity> loandetailsEntityList = new List<LoandetailsEntity>();
                List<LoandetailsEntity> loandetailsEntityListAll = new List<LoandetailsEntity>();
                PaysDAL paysDAL = new PaysDAL();
                PaysEntity paysEntity = new PaysEntity();
                List<PaysEntity> paysEntityList = new List<PaysEntity>();

                loandetailsDAL.dbm.DataSource = loginDAL.DataSource;
                loandetailsDAL.dbm.User = loginDAL.UserName;
                loandetailsDAL.dbm.Password = loginDAL.UserPassword;
                loandetailsDAL.dbm.DataBase = loginDAL.DataBaseName;

                try
                {

                    loandetailsEntity = (LoandetailsEntity)Session["ParametroDetalle"];
                    loandetailsEntityList = loandetailsDAL.SearchActive(loandetailsEntity, loginDAL);
                    loandetailsEntityListAll = loandetailsDAL.Search(loandetailsEntity, loginDAL);


                    foreach (var item in loandetailsEntityList)
                    {
                        if (item.Status) 
                        {
                            difFechas = DateTime.Now - item.Date;
                            dias = difFechas.Days;

                            if (dias > 0) 
                            {
                                if (item.Frequency == "MENSUAL")
                                {
                                    quantityDelay = dias / 30;
                                }
                                else if (item.Frequency == "QUINCENAL")
                                {
                                    quantityDelay = dias / 15;
                                }
                                else if (item.Frequency == "SEMANAL")
                                {
                                    quantityDelay = dias / 7;
                                }



                                if (item.LateAmount > 0)
                                {
                                    if (item.AmountType == "Porciento")
                                    {
                                        quantityDelay = Math.Truncate(quantityDelay);
                                        if (quantityDelay > 0) 
                                        {
                                            delayAmount = ((item.CapitalBalance + item.InterestBalance) * (item.LateAmount / 100)) * quantityDelay;
                                        }

                                       

                                    }
                                    else
                                    {
                                        quantityDelay = Math.Truncate(quantityDelay);
                                        if (quantityDelay > 0)
                                        {
                                            delayAmount = item.LateAmount * quantityDelay;
                                        }
                                    }
                                }


                                if (delayAmount > 0)
                                {
                                    loandetailsEntitySet = new LoandetailsEntity();
                                    loandetailsEntitySet.ID = item.ID;
                                    loandetailsEntitySet.DelayBalance = delayAmount;
                                    loandetailsDAL.UpdateDelayAmount(loandetailsEntitySet, loginDAL);
                                }
                            }
                        }

                        totalDueAmount = totalDueAmount + Convert.ToDecimal(item.TotalDueAmount.ToString());

                       // totalPay = totalPay + ((item.Interest + item.Capital + item.DelayAmount) - (item.InterestBalance + item.CapitalBalance + item.DelayBalance + delayAmount));


                    }

                    foreach (var item in loandetailsEntityListAll)
                    {                       
                        paysEntity.TimeStart = item.LastDateDelayAmount;
                        paysEntity.TimeEnd = DateTime.Now;
                        paysEntityList = paysDAL.Search(paysEntity, loginDAL);

                        foreach (var item1 in paysEntityList)
                        {
                            if (item.ID == item1.LoanDetailsID)
                                totalPay = totalPay + item1.Amount;

                        }
                    }

                    TbIDPrestamo.InnerText = loandetailsEntity.LoandID.ToString();
                    TbCustomerName.InnerText = loandetailsEntity.CustomerName.ToString();
                    GvDetallePrestamos.Controls.Clear();

                    

                    GvDetallePrestamos.DataSource = loandetailsEntityList;
                    GvDetallePrestamos.DataBind();
                    //Session["Parametro"] = null;

                    LbBalancePendiente.InnerText = totalDueAmount.ToString("N2");
                    LbBalancePagado.InnerText = totalPay.ToString("N2");


                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
                }
            }


        }


        protected void BtnPagar_ServerClick(object sender, EventArgs e)
        {
            decimal montoTotalPagado = 0;
            decimal montoP = 0;
            decimal montoTotalCuota = 0;
            decimal montoAtraso = 0;
            decimal.TryParse(TbMonto.Text, out montoTotalPagado);
            decimal montoAPagar = 0;
            montoP = montoTotalPagado;
            string cuotasPagadas = "";
            string cuotasAbono = "";
            string totalQuota = "";
            int contAtraso = 0;
            DateTime dateNow = DateTime.Now;
            LoandetailsDAL loandetailsDAL = new LoandetailsDAL();

            if(!String.IsNullOrEmpty(TbMontoMora.Text))
                montoAtraso = Convert.ToDecimal(TbMontoMora.Text);

            try
            {
                if (montoTotalPagado > 0)
                {
                    if (montoTotalPagado < montoAtraso) 
                    {
                        montoAtraso = montoTotalPagado;
                    }


                    foreach (GridViewRow item in GvDetallePrestamos.Rows)
                    {

                        if (Convert.ToDateTime(dateNow.ToShortDateString() + " 00:00:01") > Convert.ToDateTime(item.Cells[2].Text + " 00:00:01"))
                        {
                            contAtraso++;
                        }

                        totalQuota = ObtenerTotalQuotas(TbIDPrestamo.InnerText);
                        if (montoP >= Convert.ToDecimal(item.Cells[3].Text))
                        {
                            montoTotalCuota = montoTotalCuota + Convert.ToDecimal(item.Cells[3].Text);
                            montoAPagar = Convert.ToDecimal(item.Cells[3].Text);
                            //montoP = montoP - montoAPagar;
                        }
                        else if (montoP > 0)
                        {
                            montoTotalCuota = montoTotalCuota + Convert.ToDecimal(item.Cells[3].Text);
                            montoAPagar = montoP;
                            montoP = 0;
                            cuotasAbono = item.Cells[1].Text;
                        }
                        if(montoP > 0)
                            if (loandetailsDAL.LoanDetailPay(Convert.ToInt64(item.Cells[0].Text), montoAPagar, "", "Efectivo", "", loginDAL))
                        {
                            if (string.IsNullOrEmpty(cuotasPagadas))
                                cuotasPagadas = cuotasPagadas + item.Cells[1].Text;
                            else
                                cuotasPagadas = cuotasPagadas + "," + item.Cells[1].Text;

                           
                            
                            string lastQuotaNumber = "0";
                            foreach (GridViewRow row in GvDetallePrestamos.Rows)
                            {
                                lastQuotaNumber = row.Cells[1].Text;

                            }

                            if (lastQuotaNumber == item.Cells[1].Text && montoP == Decimal.Parse(item.Cells[3].Text))
                            {
                                LoanDAL loansDAL = new LoanDAL();
                                LoansEntity loansEntity = new LoansEntity();

                                loansEntity.Status = "PAGADO";
                                loansEntity.ID = Convert.ToInt32(TbIDPrestamo.InnerText);
                                loansDAL.UpdateLoanStatus(loansEntity,loginDAL);

                                //if(String.IsNullOrEmpty(loansDAL.errorDescription))
                                //    Response.Redirect("PrestamosWF.aspx");
                            }
                            montoP = montoP - montoAPagar;
                            //if (montoP <= 0)
                            //{
                            //    break;
                            //}

                        }

                    }



                    CashierDAL cashierDAL = new CashierDAL();
                    CashierEntity cashierEntity = new CashierEntity();

                    cashierEntity.Type = "Entrada";
                    cashierEntity.Amount = montoTotalPagado;
                    cashierEntity.Description = "" + " " + " Cliente:" + TbCustomerName.InnerText + "  # Prestamo:" + TbIDPrestamo.InnerText;
                    cashierEntity.Operation = "Cobro";
                    cashierEntity.UserName = loginDAL.UserName;
                    cashierEntity.LastUpdate = dateNow;

                    cashierDAL.Insert(cashierEntity, loginDAL);

                    //ReciboImprimir.Style.Add("display", "block");
                    //ReciboImprimir.InnerHtml += "<div class='container-fluid'>";
                    //ReciboImprimir.InnerHtml += "<h3 class='aling - T - C negrita - T'>" + loginDAL.Company + "</h3>";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - C negrita - T'>(" + loginDAL.Phone + ")</h5>";
                    //ReciboImprimir.InnerHtml += "<hr class='lineaPuntos-T' />";
                    //ReciboImprimir.InnerHtml += "<br />";
                    //ReciboImprimir.InnerHtml += "<h4 class='aling - T - C negrita - T'>Recibo de Cobro</h4>";
                    //ReciboImprimir.InnerHtml += "<hr class='lineaPuntos-T' />";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'>Fecha:" + dateNow.ToString("dd/MM/yyyy hh:mm") + "</h5>";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'># Prestamo:" + TbIDPrestamo.InnerText + "</h5>";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'>Cliente:" + TbCustomerName.InnerText + "</h5>";
                    //ReciboImprimir.InnerHtml += "<hr class='lineaPuntos-T' />";

                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'>Pago a cuota:" + cuotasPagadas + " de " + totalQuota + "</h5>";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'>Abono a Cuota:" + cuotasAbono.ToString() + "</h5>";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'>Valor Pagado:" + montoTotalPagado.ToString() + "</h5>";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'>Monto Cuota:" + montoTotalCuota.ToString() + "</h5>";

                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'>Cuota Atrasadas:" + contAtraso.ToString() + "</h5>";
                    //ReciboImprimir.InnerHtml += "<br />";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - L negrita - T'>Total Pendiente:" + ObtenerTotalPendiente(TbIDPrestamo.InnerText).ToString() + "</h5>";
                    //ReciboImprimir.InnerHtml += "<br />";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - C negrita - T'>Cobrador:" + loginDAL.UserName + "</h5>";
                    //ReciboImprimir.InnerHtml += "<br />";
                    //ReciboImprimir.InnerHtml += "<h5 class='aling - T - C negrita - T'>Firma Cliente</h5>";
                    //ReciboImprimir.InnerHtml += "</div>";

                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ImprimirRecibo();", true);

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "script", "ImprimirReciboCobro('" + loginDAL.Company + "','" + loginDAL.Phone + "','" + dateNow.ToString("dd/MM/yyyy hh:mm")
                        + "','" + TbCustomerName.InnerText + "','" + TbIDPrestamo.InnerText + "','" + cuotasPagadas + "','"
                        + totalQuota + "','" + montoTotalPagado.ToString() + "','" + montoTotalCuota.ToString()
                        + "','" + cuotasAbono.ToString() + "','" + contAtraso.ToString() + "','" + ObtenerTotalPendiente(TbIDPrestamo.InnerText).ToString() + "','" + loginDAL.UserName + "','" + montoAtraso.ToString() + "')", true);



                }

                BtnPagar.Visible = false;
                BtnModificar.Visible = false;

                BtnAbonarCapital.Visible = true;
                TbMontoAbono.Visible = true;
                DropDownTipoNCF.Visible = true;
                LbTipoNCF.Visible = true;
                //TbMonto.Visible = false;
                cargar();
            }
            catch (Exception ex)
            {


            }



        }

        protected void BtnAbonarCapital_ServerClick(object sender, EventArgs e)
        {
            bool result = true;
            int count = 0;
            int countPaid = 0;
            int countLoan = 0;
            decimal amountCapital = 0;
            decimal amountCapitalPay = 0;
            int lastQuota = 0;
            long lastDetailID = 0;
            //Logs logs = new Logs();

            decimal.TryParse(TbMontoAbono.Text, out amountCapital);
            amountCapitalPay = amountCapital;

            if (amountCapital > 0)
            {

                LoansEntity loansEntity = new LoansEntity();
                LoanDAL loansDAL = new LoanDAL();
                List<LoansEntity> listLoans;

                loansEntity.ID = Convert.ToInt32(TbIDPrestamo.InnerText);
                listLoans = loansDAL.Search(loansEntity, loginDAL);

                double res1 = 0;
                double intPercent = Convert.ToDouble(listLoans[0].PercentInterest / 100);
                double capital = Convert.ToDouble(listLoans[0].DueAmount) - Convert.ToDouble(TbMontoAbono.Text);
                double time = Convert.ToDouble(listLoans[0].DueTime);
                //lbCustomer.Text = loansEntity.CustomerName;
                //detailDate = loansEntity.Date;

                double percentInterestAmount = 0;
                double totalInterestAmount = 0;
                double quotaCapital = 0;
                double quaotaInterest = 0;
                DateTime currentDate = new DateTime();
                int days = 0;

                double quota = 0;


                LoandetailsDAL loandetailsDAL = new LoandetailsDAL();
                loandetailsEntity = new LoandetailsEntity();
                loandetailsEntity.LoandID = Convert.ToInt32(TbIDPrestamo.InnerText);
                List<LoandetailsEntity> LoandetailsEntityList = null;


                LoandetailsEntityList = loandetailsDAL.Search(loandetailsEntity, loginDAL);
                count = LoandetailsEntityList.Count;
                countPaid = LoandetailsEntityList.FindAll(l => l.Status == false).Count;


                if (listLoans[0].ForQuota)
                {
                    time = time - countPaid;
                    percentInterestAmount = capital * intPercent;
                    quotaCapital = capital / time;
                    if (loansEntity.Frequency == "SEMANAL")
                    {
                        totalInterestAmount = (percentInterestAmount * time) / 4;
                        quaotaInterest = totalInterestAmount / time;
                    }
                    else if (loansEntity.Frequency == "QUINCENAL")
                    {
                        totalInterestAmount = (percentInterestAmount * time) / 2;
                        quaotaInterest = totalInterestAmount / time;
                    }
                    else
                    {
                        totalInterestAmount = percentInterestAmount * time;
                        quaotaInterest = totalInterestAmount / time;
                    }


                    quota = (totalInterestAmount + capital) / time;


                    loansEntity = new LoansEntity();
                    loansDAL = new LoanDAL();

                    loansEntity.ID = listLoans[0].ID;
                    loansEntity.Capital = listLoans[0].Capital;
                    loansEntity.Date = listLoans[0].Date;
                    loansEntity.CustomerID = listLoans[0].CustomerID;
                    loansEntity.Frequency = listLoans[0].Frequency;
                    loansEntity.PercentInterest = listLoans[0].PercentInterest;
                    loansEntity.InterestAmount = listLoans[0].InterestAmount;
                    loansEntity.FixedInterest = listLoans[0].FixedInterest;
                    loansEntity.TotalAmount = listLoans[0].TotalAmount;
                    loansEntity.ForQuota = listLoans[0].ForQuota;
                    loansEntity.DueAmount = listLoans[0].DueAmount - Convert.ToDecimal(TbMontoAbono.Text);
                    loansEntity.DueTime = listLoans[0].DueTime;
                    loansEntity.SafeAmount = listLoans[0].SafeAmount;
                    loansEntity.GuarantorID = listLoans[0].GuarantorID;
                    loansEntity.Status = listLoans[0].Status;
                    loansEntity.Lawyer = listLoans[0].Lawyer;
                    loansEntity.ActOfSale = listLoans[0].ActOfSale;
                    loansEntity.Opposition = listLoans[0].Opposition;
                    loansEntity.Transfer = listLoans[0].Transfer;

                    loansDAL.Edit(loansEntity,loginDAL);


                    foreach (var item in LoandetailsEntityList)
                    {
                        countLoan++;
                        if (countLoan > countPaid)
                        {

                            loandetailsEntity = new LoandetailsEntity();
                            loandetailsEntity.ID = item.ID;
                            loandetailsEntity.Capital = Convert.ToDecimal(quotaCapital);
                            loandetailsEntity.CapitalBalance = Convert.ToDecimal(quotaCapital);
                            loandetailsEntity.Interest = Convert.ToDecimal(quaotaInterest);
                            loandetailsEntity.InterestBalance = Convert.ToDecimal(quaotaInterest);
                            loandetailsEntity.DelayAmount = item.DelayAmount;
                            loandetailsEntity.DelayBalance = item.DelayBalance;
                            loandetailsEntity.LastDateDelayAmount = item.LastDateDelayAmount;
                            lastDetailID = item.ID;
                            loandetailsDAL.UpdateAmounts(loandetailsEntity,loginDAL);

                           
                        }
                    }

                    PaysDAL payDAL = new PaysDAL();
                    PaysEntity paysEntity = new PaysEntity();
                    paysEntity.Amount = Convert.ToDecimal(TbMontoAbono.Text);
                    paysEntity.Comment = "Abono al capital, total de cuotas " + count;
                    paysEntity.Type = "Efectivo";
                    paysEntity.LoanDetailsID = lastDetailID;
                    paysEntity.Date = DateTime.Now;
                    paysEntity.NcfNumber = "";
                    payDAL.Insert(paysEntity,loginDAL);

                    payDAL = null;
                    paysEntity = null;


                    //imprimir recibo
                    //ScriptManager.RegisterStartupScript(this, this.GetType(),
                    //"script", "ImprimirReciboCobro('" + loginDAL.Company + "','" + loginDAL.Phone + "','" + dateNow.ToString("dd/MM/yyyy hh:mm")
                    //+ "','" + TbCustomerName.InnerText + "','" + TbIDPrestamo.InnerText + "','" + "N/A" + "','"
                    //+ totalQuota + "','" + montoTotalPagado.ToString() + "','" + montoTotalCuota.ToString()
                    //+ "','" + "N/A" + "','" + contAtraso.ToString() + "','" + ObtenerTotalPendiente(TbIDPrestamo.InnerText).ToString() + "','" + loginDAL.UserName + "','" + montoAtraso.ToString() + "')", true);


                    //bool payTotal = false;
                    //ReportEntity reportEntity = new ReportEntity();
                    //reportEntity.Date = DateTime.Now;
                    //reportEntity.QuotaAmount = Convert.ToDecimal(lbTotalDueAmount.Text);
                    //reportEntity.PayAmount = amountCapitalPay;
                    //reportEntity.DelayBalance = Convert.ToDecimal(lbTotalDueAmount.Text) - amountCapitalPay;

                    //if (reportEntity.DelayBalance == 0)
                    //    payTotal = true;

                    //string ncfNumber = GetNCF(comboNCFTypes.SelectedValue.ToString(),);
                    //ReportPayment reportPayment = new ReportPayment(reportEntity, lbLoanID.Text, lbCustomerName.Text, amountCapitalPay, "Abono al Capital", "Efectivo", payTotal, ncfNumber);

                    //reportPayment.ShowDialog();
                    //reportPayment = null;

                    //logs.saveLogs("Abono al Capital", "Abono al capital para el ID Prestamo: " + lbLoanID.Text);
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Capital Abonado correctamente!');", true);
                }
                else
                {
                    foreach (var item in LoandetailsEntityList)
                    {
                        loandetailsEntity = new LoandetailsEntity();
                        loandetailsEntity.ID = item.ID;
                        loandetailsEntity.Capital = item.Capital;
                        loandetailsEntity.CapitalBalance = item.CapitalBalance - Convert.ToDecimal(TbMontoAbono.Text);
                        loandetailsEntity.Interest = item.Interest;
                        loandetailsEntity.InterestBalance = item.InterestBalance;
                        loandetailsEntity.DelayAmount = item.DelayAmount;
                        loandetailsEntity.DelayBalance = item.DelayBalance;
                        loandetailsEntity.LastDateDelayAmount = item.LastDateDelayAmount;
                        lastDetailID = item.ID;
                        loandetailsDAL.UpdateAmounts(loandetailsEntity,loginDAL);
                    }

                    PaysDAL payDAL = new PaysDAL();
                    PaysEntity paysEntity = new PaysEntity();
                    paysEntity.Amount = Convert.ToDecimal(TbMontoAbono.Text);
                    paysEntity.Comment = "Abono al capital, total de cuotas " + count;
                    paysEntity.Type = "Efectivo";
                    paysEntity.LoanDetailsID = lastDetailID;
                    paysEntity.Date = DateTime.Now;

                    payDAL.Insert(paysEntity,loginDAL);

                    payDAL = null;
                    paysEntity = null;


                    //imprimir recibo
                    

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Capital Abonado correctamente!');", true);

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                      "script", "ImprimirReciboCobro('" + loginDAL.Company + "','" + loginDAL.Phone + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm")
                      + "','" + TbCustomerName.InnerText + "','" + TbIDPrestamo.InnerText + "','" + "N/A" + "','"
                      + "N/A" + "','" + "N/A" + "','" + "N/A"
                      + "','" + amountCapitalPay.ToString() + "','" + "N/A" + "','" + ObtenerTotalPendiente(TbIDPrestamo.InnerText).ToString() + "','" + loginDAL.UserName + "','" + "N/A" + "')", true);


                TbMontoAbono.Text = "";
                cargar();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Monto Invalido!!');", true);
                
            }

        }


        private decimal ObtenerTotalPendiente(string id)
        {

            decimal total = 0;
            int loandid = Convert.ToInt32(id);
            try
            {
                LoandetailsDAL loandetailsDAL = new LoandetailsDAL();
                LoandetailsEntity loandetailsEntity = new LoandetailsEntity();
                List<LoandetailsEntity> loandetailsEntityList = new List<LoandetailsEntity>();
                loandetailsEntity.LoandID = loandid;
                loandetailsEntity.FilterDate = false;
                loandetailsEntityList = loandetailsDAL.Search(loandetailsEntity, loginDAL);

                if (loandetailsEntityList.Count > 0)
                {
                    foreach (LoandetailsEntity item in loandetailsEntityList)
                    {
                        if (item.Status)
                        {
                            total = total + item.CapitalBalance + item.InterestBalance + item.DelayBalance;
                        }
                    }
                }


            }
            catch (Exception ex)
            {


            }

            return total;
        }

        private string ObtenerTotalQuotas(string id)
        {

            int total = 0;
            int loandid = Convert.ToInt32(id);
            try
            {
                LoandetailsDAL loandetailsDAL = new LoandetailsDAL();
                LoandetailsEntity loandetailsEntity = new LoandetailsEntity();
                List<LoandetailsEntity> loandetailsEntityList = new List<LoandetailsEntity>();
                loandetailsEntity.LoandID = loandid;
                loandetailsEntity.FilterDate = false;
                loandetailsEntityList = loandetailsDAL.SearchActive(loandetailsEntity, loginDAL);

                if (loandetailsEntityList.Count > 0)
                {
                    foreach (LoandetailsEntity item in loandetailsEntityList)
                    {
                        if (item.Status)
                        {
                            total = item.TotalQuota;
                            break;
                        }
                    }
                }


            }
            catch (Exception ex)
            {


            }

            return total.ToString();
        }

        protected void BtnModificar_ServerClick(object sender, EventArgs e)
        {
            LoandetailsDAL loandetailsDAL = new LoandetailsDAL();
            LoandetailsEntity loandetailsEntity = new LoandetailsEntity();
            long detailID = 0;
            decimal newDelay = 0;
            decimal newInterest = 0;

            if (string.IsNullOrEmpty(TbAtrasoNuevo.Text))
            {
                TbAtrasoNuevo.Text = TbAtrasoActual.Text;
            }

            if (string.IsNullOrEmpty(TbInteresNuevo.Text))
            {
                TbInteresNuevo.Text = TbInteresActual.Text;
            }

            decimal.TryParse(TbAtrasoNuevo.Text, out newDelay);
            decimal.TryParse(TbInteresNuevo.Text, out newInterest);

            try
            {
                foreach (GridViewRow item in GvDetallePrestamos.Rows)
                {
                    System.Web.UI.WebControls.CheckBox checkBoxItem = (System.Web.UI.WebControls.CheckBox)item.FindControl("CbItem");
                    if (checkBoxItem.Checked)
                    {
                        long.TryParse(item.Cells[0].Text, out detailID);
                    }

                }

                loandetailsEntity.DelayBalance = newDelay;
                loandetailsEntity.InterestBalance = newInterest;
                loandetailsEntity.ID = detailID;

                loandetailsDAL.EditAmountDelay(loandetailsEntity, loginDAL);
            }
            catch (Exception ex)
            {

            }
            BtnModificar.Visible = false;
            BtnPagar.Visible = false;
            //TbMonto.Visible = false;
            cargar();
        }
        protected void BtnImprimir_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(),
                       "script", "ImprimirContrato('" + getInforContrato(loginDAL.Contract) + "','" + loginDAL.ContractTitle.Replace("\r\n", "<br/>") + "')", true);



            //Session["ctrl"] = GvDetallePrestamos;
            //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Imprimir.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
        }

        protected void BtnBuscar_ServerClick(object sender, EventArgs e)
        {
                Response.Redirect("PrestamosWF.aspx");
        }

        private string getInforContrato(string texto)
        {
            CustomersDAL customersDAL = new CustomersDAL();
            CustomersEntity customersEntity = new CustomersEntity();

            GuarantorDAL guarantorDAL = new GuarantorDAL();
            GuarantorEntity guarantorEntity = new GuarantorEntity();

            LoanDAL loanDAL = new LoanDAL();
            LoansEntity loansEntity = new LoansEntity();
            List<LoansEntity> loansEntityList = new List<LoansEntity>();

            DateTime fechaActual = DateTime.Now;

            try
            {
                loansEntity.ID = Convert.ToInt32(TbIDPrestamo.InnerText);
                loansEntityList = loanDAL.Search(loansEntity, loginDAL);

                customersEntity.ID = loansEntityList[0].CustomerID;
                customersEntity = customersDAL.Search(customersEntity, loginDAL)[0];

                guarantorEntity.ID = loansEntityList[0].GuarantorID;
                guarantorEntity = guarantorDAL.Search(guarantorEntity, loginDAL)[0];



                texto = texto.Replace("@deudor", customersEntity.Name.ToUpper() + " " + customersEntity.LastName.ToUpper())
               .Replace("@deudorCedulaLetra", NumeroALetras(Convert.ToDouble(customersEntity.IdentificationNumber.Replace("-", ""))).ToLower())
               .Replace("@deudor2CedulaLetra", NumeroALetras(Convert.ToDouble(guarantorEntity.IdentificationNumber.Replace("-", ""))).ToLower())
               .Replace("@deudor2Cedula", guarantorEntity.IdentificationNumber)
               .Replace("@deudorCedula", customersEntity.IdentificationNumber)
               .Replace("@deudor2Trabajo", guarantorEntity.Position)
               .Replace("@deudorTrabajo", customersEntity.Position)
               .Replace("@deudor2Estado", guarantorEntity.Status)
               .Replace("@deudorEstado", customersEntity.Status)
               .Replace("@deudor2", guarantorEntity.Name.ToUpper() + " " + guarantorEntity.LastName.ToUpper())
               .Replace("@diaLetras", fechaActual.ToString("dddd", CultureInfo.CreateSpecificCulture("es-ES")))
               .Replace("@anioLetras", fechaActual.ToString("yyyy", CultureInfo.CreateSpecificCulture("es-ES")))
               .Replace("@mes", fechaActual.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES")))
               .Replace("@dia", fechaActual.Day.ToString())
               .Replace("@anio", NumeroALetrasCompleto(Convert.ToDouble(fechaActual.Year)).ToLower())
               .Replace("@montoLetra", NumeroALetrasCompleto(Convert.ToDouble(loansEntityList[0].Capital)).ToLower())
               .Replace("@monto", loansEntityList[0].Capital.ToString("N2"))
               .Replace("@interesLetra", NumeroALetrasCompleto(Convert.ToDouble(loansEntityList[0].InterestAmount)).ToLower())
               .Replace("@interes", loansEntityList[0].InterestAmount.ToString("N2"))
               .Replace("@cantidadLetra", NumeroALetras(Convert.ToDouble(loansEntityList[0].DueTime)).ToLower())
               .Replace("@cantidad", Convert.ToInt32(loansEntityList[0].DueTime).ToString())
               .Replace("@moraLetra", NumeroALetrasCompleto(Convert.ToDouble(customersEntity.LateAmount)).ToLower())
               .Replace("@mora", customersEntity.LateAmount.ToString())
               .Replace("@direccion2", guarantorEntity.Address)
               .Replace("@direccion", customersEntity.Address);


                texto = texto.Replace("[", "");
                texto = texto.Replace("]", "");

                texto = texto.Replace("@Acto", NumeroALetras(Convert.ToDouble(TextActo.Text))+"("+ TextActo.Text+")");
                texto = texto.Replace("@Folio", NumeroALetras(Convert.ToDouble(TextFolio.Text))+"("+TextFolio.Text+")");


            }
            catch (Exception ex)
            {

                //throw;
            }





            return texto;
        }
        private static string NumeroALetras(double value)
        {
            string cadena = Convert.ToInt64(value).ToString();
            string num2Text = "";
            string numResult = "";
            for (int i = 0; i < cadena.Length; i++)
            {

                value = Convert.ToDouble(cadena.Substring(i, 1));

                value = Math.Truncate(value);
                if (value == 0) num2Text = "CERO";
                else if (value == 1) num2Text = "UNO";
                else if (value == 2) num2Text = "DOS";
                else if (value == 3) num2Text = "TRES";
                else if (value == 4) num2Text = "CUATRO";
                else if (value == 5) num2Text = "CINCO";
                else if (value == 6) num2Text = "SEIS";
                else if (value == 7) num2Text = "SIETE";
                else if (value == 8) num2Text = "OCHO";
                else if (value == 9) num2Text = "NUEVE";
                else if (value == 10) num2Text = "DIEZ";
                else if (value == 11) num2Text = "ONCE";
                else if (value == 12) num2Text = "DOCE";
                else if (value == 13) num2Text = "TRECE";
                else if (value == 14) num2Text = "CATORCE";
                else if (value == 15) num2Text = "QUINCE";
                else if (value < 20) num2Text = "DIECI" + NumeroALetras(value - 10);
                else if (value == 20) num2Text = "VEINTE";
                else if (value < 30) num2Text = "VEINTI" + NumeroALetras(value - 20);
                else if (value == 30) num2Text = "TREINTA";
                else if (value == 40) num2Text = "CUARENTA";
                else if (value == 50) num2Text = "CINCUENTA";
                else if (value == 60) num2Text = "SESENTA";
                else if (value == 70) num2Text = "SETENTA";
                else if (value == 80) num2Text = "OCHENTA";
                else if (value == 90) num2Text = "NOVENTA";
                else if (value < 100) num2Text = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
                else if (value == 100) num2Text = "CIEN";
                else if (value < 200) num2Text = "CIENTO " + NumeroALetras(value - 100);
                else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";
                else if (value == 500) num2Text = "QUINIENTOS";
                else if (value == 700) num2Text = "SETECIENTOS";
                else if (value == 900) num2Text = "NOVECIENTOS";
                else if (value < 1000) num2Text = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
                else if (value == 1000) num2Text = "MIL";
                else if (value < 2000) num2Text = "MIL " + NumeroALetras(value % 1000);
                else if (value < 1000000)
                {
                    num2Text = NumeroALetras(Math.Truncate(value / 1000)) + " MIL";
                    if ((value % 1000) > 0)
                    {
                        num2Text = num2Text + " " + NumeroALetras(value % 1000);
                    }
                }
                else if (value == 1000000)
                {
                    num2Text = "UN MILLON";
                }
                else if (value < 2000000)
                {
                    num2Text = "UN MILLON " + NumeroALetras(value % 1000000);
                }
                else if (value < 1000000000000)
                {
                    num2Text = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                    if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                    {
                        num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
                    }
                }
                else if (value == 1000000000000) num2Text = "UN BILLON";
                else if (value < 2000000000000) num2Text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                else
                {
                    num2Text = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                    if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                    {
                        num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                    }
                }

                if (string.IsNullOrEmpty(num2Text))
                {
                    numResult = numResult + num2Text;
                }
                else
                {
                    numResult = numResult + " " + num2Text;
                }
            }



            return numResult;
        }

        private static string NumeroALetrasCompleto(double value)
        {
            string num2Text = "";

            value = Math.Truncate(value);
            if (value == 0) num2Text = "CERO";
            else if (value == 1) num2Text = "UNO";
            else if (value == 2) num2Text = "DOS";
            else if (value == 3) num2Text = "TRES";
            else if (value == 4) num2Text = "CUATRO";
            else if (value == 5) num2Text = "CINCO";
            else if (value == 6) num2Text = "SEIS";
            else if (value == 7) num2Text = "SIETE";
            else if (value == 8) num2Text = "OCHO";
            else if (value == 9) num2Text = "NUEVE";
            else if (value == 10) num2Text = "DIEZ";
            else if (value == 11) num2Text = "ONCE";
            else if (value == 12) num2Text = "DOCE";
            else if (value == 13) num2Text = "TRECE";
            else if (value == 14) num2Text = "CATORCE";
            else if (value == 15) num2Text = "QUINCE";
            else if (value < 20) num2Text = "DIECI" + NumeroALetrasCompleto(value - 10);
            else if (value == 20) num2Text = "VEINTE";
            else if (value < 30) num2Text = "VEINTI" + NumeroALetrasCompleto(value - 20);
            else if (value == 30) num2Text = "TREINTA";
            else if (value == 40) num2Text = "CUARENTA";
            else if (value == 50) num2Text = "CINCUENTA";
            else if (value == 60) num2Text = "SESENTA";
            else if (value == 70) num2Text = "SETENTA";
            else if (value == 80) num2Text = "OCHENTA";
            else if (value == 90) num2Text = "NOVENTA";
            else if (value < 100) num2Text = NumeroALetrasCompleto(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetrasCompleto(value % 10);
            else if (value == 100) num2Text = "CIEN";
            else if (value < 200) num2Text = "CIENTO " + NumeroALetrasCompleto(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text = NumeroALetrasCompleto(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) num2Text = "QUINIENTOS";
            else if (value == 700) num2Text = "SETECIENTOS";
            else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = NumeroALetrasCompleto(Math.Truncate(value / 100) * 100) + " " + NumeroALetrasCompleto(value % 100);
            else if (value == 1000) num2Text = "MIL";
            else if (value < 2000) num2Text = "MIL " + NumeroALetrasCompleto(value % 1000);
            else if (value < 1000000)
            {
                num2Text = NumeroALetrasCompleto(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetrasCompleto(value % 1000);
                }
            }
            else if (value == 1000000)
            {
                num2Text = "UN MILLON";
            }
            else if (value < 2000000)
            {
                num2Text = "UN MILLON " + NumeroALetrasCompleto(value % 1000000);
            }
            else if (value < 1000000000000)
            {
                num2Text = NumeroALetrasCompleto(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetrasCompleto(value - Math.Truncate(value / 1000000) * 1000000);
                }
            }
            else if (value == 1000000000000) num2Text = "UN BILLON";
            else if (value < 2000000000000) num2Text = "UN BILLON " + NumeroALetrasCompleto(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                num2Text = NumeroALetrasCompleto(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetrasCompleto(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }
            }


            return num2Text;
        }


        public string GetNCF(string ncfCode)
        {
            string ncf = "";
            string ncfNumber = "";
            long currentSequence = 0;
            long finalSequence = 0;
            string ncfTipo = "";

            NcfNumbersEntity ncfNumbersEntity = new NcfNumbersEntity();
            NcfNumbersDAL ncfNumbersDAL = new NcfNumbersDAL();

            ncfNumbersEntity.NcfCode = ncfCode;
            ncfNumbersEntity.NcfNumbersEntityList = ncfNumbersDAL.GetNCF(ncfNumbersEntity,loginDAL);
            if (ncfNumbersEntity.NcfNumbersEntityList.Count > 0)
            {
                ncf = ncfNumbersEntity.NcfNumbersEntityList[0].NcfNumber;
                currentSequence = ncfNumbersEntity.NcfNumbersEntityList[0].CurrentSequence;
                finalSequence = ncfNumbersEntity.NcfNumbersEntityList[0].FinalSequence;

                if (currentSequence < finalSequence)
                {
                    ncfTipo = ncfNumbersEntity.NcfNumbersEntityList[0].Description;
                    ncfNumber = ncf + (currentSequence + 1).ToString().PadLeft(8, '0');
                }


            }

            ncfNumbersEntity = null;
            ncfNumbersDAL = null;

            return ncfNumber;
        }
        public void loadCombo()
        {
            //NcfNumbers
            NcfNumbersDAL ncfNumbersDAL = new NcfNumbersDAL();
            NcfNumbersEntity NcfNumbersEntity = new NcfNumbersEntity();
            List<NcfNumbersEntity> NcfNumbersEntityList = new List<NcfNumbersEntity>();

            //NcfNumbersEntityList = ncfNumbersDAL.LoadCombo(NcfNumbersEntity, loginDAL);
            DropDownTipoNCF.DataSource = null;

            DropDownTipoNCF.DataSource = ncfNumbersDAL.LoadCombo(NcfNumbersEntity,loginDAL);
            DropDownTipoNCF.DataTextField = "Description";
            DropDownTipoNCF.DataValueField = "NcfCode";
            DropDownTipoNCF.DataBind();

            if (DropDownTipoNCF.Items.Count > 0)
                DropDownTipoNCF.SelectedIndex = 0;

            ncfNumbersDAL = null;
            NcfNumbersEntity = null;

        }


    }

}
