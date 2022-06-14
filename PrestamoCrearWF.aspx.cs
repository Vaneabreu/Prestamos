using Loans.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLoans
{
    public partial class PrestamoCrearWF : System.Web.UI.Page
    {
        public string codigo;
        LoginDAL loginDAL = new LoginDAL();
        LoansEntity loansEntity;

        DateTime detailDate = DateTime.Now;
        ReportAmortization reportAmortization;
        List<ReportAmortization> reportAmortizationList;
        double quota = 0;
        double totalInterest = 0;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                if (!IsPostBack)
                {
                    InputFecha.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    CargarDropDown();
                }
            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }
            if (loginDAL.IsAdministrator == false)
            {
                ocultarOpciones();
            }


        }
        public void ocultarOpciones()
        {
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



        protected void BtnCancelar_Click(object sender, EventArgs e)
        {


            Response.Redirect("ClienteWF.aspx");


        }

        protected void BtnConvertir_Click(object sender, EventArgs e)
        {

            decimal cuotaAmount = 0;
            decimal interest = 0;
            decimal cuotaCapital = 0;
            decimal capitalAmount = 0;
            int time = 0;
            string frecuency = DropDownFrecuencia.SelectedValue.ToString();

            decimal.TryParse(TbMonto.Text, out capitalAmount);
            int.TryParse(DropDownTiempo.SelectedValue.ToString(), out time);

            if (RbInteres.Checked)
            {
            }
            else
            {
                decimal.TryParse(TbCuota.Text, out cuotaAmount);

                cuotaCapital = capitalAmount / time;
                //cuotaAmount = cuotaAmount - cuotaCapital;
                cuotaAmount = cuotaAmount - cuotaCapital;

                cuotaAmount = cuotaAmount * time;


                if (frecuency == "DIARIO")
                {
                    cuotaAmount = cuotaAmount * 30;
                }
                else if (frecuency == "SEMANAL")
                {
                    cuotaAmount = cuotaAmount * 4;
                }
                else if (frecuency == "QUINCENAL")
                {
                    cuotaAmount = cuotaAmount * 2;
                }
                else
                {
                }

                cuotaAmount = cuotaAmount / time;
                cuotaAmount = cuotaAmount / capitalAmount;

                if (cuotaAmount.ToString().Contains(".999"))
                {
                    cuotaAmount = Math.Round(cuotaAmount);
                }

                cuotaAmount = cuotaAmount * 100;

                //cuotaAmount = cuotaAmount / capitalAmount * 100;
                TbInteres.Text = cuotaAmount.ToString("N3");
            }


            if (validate())
            {
                CargarAmortizacion();

            }



        }

        protected bool validate()
        {
            bool result = true;
            loansEntity = new LoansEntity();
            StringBuilder sbError = new StringBuilder();

            if (TbNumeroIdenticacionC.Text == "-")
            {
                result = false;
                sbError.AppendLine("- Debe cargar el cliente antes de continuar!!");
            }
            else
            {
                loansEntity.CustomerID = Convert.ToInt32(TbIdCliente.Text);
            }

            if (TbMonto.Text == "")
            {
                result = false;
                sbError.AppendLine("- Monto invalido!!");
            }
            else
            {
                loansEntity.DueAmount = Convert.ToDecimal(TbMonto.Text);
                loansEntity.Capital = Convert.ToDecimal(TbMonto.Text);
            }

            if (string.IsNullOrEmpty(TbInteres.Text))
            {
                result = false;
                sbError.AppendLine("- % Interes invalido!!");
            }
            else
            {
                loansEntity.PercentInterest = Convert.ToDecimal(TbInteres.Text);
            }

            if (string.IsNullOrEmpty(TbIdGaranteGC.Text))
            {
                loansEntity.GuarantorID = 0;
            }
            else
            {
                loansEntity.GuarantorID = Convert.ToInt32(TbIdGaranteGC.Text);
            }

            //if (Convert.ToDateTime(dateTimeStartDate.Value.ToShortDateString() + " 00:00:01") < Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:01"))
            //{
            //    result = false;
            //    sbError.AppendLine("- La fecha debe ser igual o mayor a la de hoy!");
            //}
            //else
            //{
            loansEntity.Date = Convert.ToDateTime(InputFecha.Value + " 00:00:01");
            //}

            loansEntity.Frequency = DropDownFrecuencia.SelectedItem.ToString();

            if (result)
            {
                decimal safeA = 0;
                decimal lawyer = 0;
                decimal actOfSale = 0;
                decimal opposition = 0;
                decimal transfer = 0;
                decimal.TryParse(TbGastosLegales.Text, out safeA);
                decimal.TryParse(TbAbogado.Text, out lawyer);
                decimal.TryParse(TbActoDeVenta.Text, out actOfSale);
                decimal.TryParse(TbOposicion.Text, out opposition);
                decimal.TryParse(TbTraspaso.Text, out transfer);

                loansEntity.TotalAmount = loansEntity.DueAmount + loansEntity.InterestAmount;
                loansEntity.DueTime = Convert.ToInt32(DropDownTiempo.SelectedItem.Text);
                loansEntity.Frequency = DropDownFrecuencia.SelectedItem.ToString();
                loansEntity.CustomerName = TbNombreClienteC.Text;
                loansEntity.ForQuota = CbPorCuota.Checked;
                loansEntity.FixedInterest = false;
                loansEntity.SafeAmount = safeA;
                loansEntity.Lawyer = lawyer;
                loansEntity.ActOfSale = actOfSale;
                loansEntity.Opposition = opposition;
                loansEntity.Transfer = transfer;
                loansEntity.Status = "PENDIENTE";
            }


            return result;
        }

        protected void CargarAmortizacion()
        {
            TbClienteD.Text = TbNombreClienteC.Text;
            TbCapitalD.Text = loansEntity.Capital.ToString();

            TbTraspasoD.Text = loansEntity.SafeAmount.ToString();
            TbOposicionD.Text = loansEntity.Opposition.ToString();
            TbAbogadoD.Text = loansEntity.Lawyer.ToString();
            TbActoVentaD.Text = loansEntity.ActOfSale.ToString();
            TbGastosLegalesD.Text = loansEntity.SafeAmount.ToString();


            double res1 = 0;
            double intPercent = Convert.ToDouble(loansEntity.PercentInterest / 100);
            double capital = Convert.ToDouble(loansEntity.Capital);
            double time = Convert.ToDouble(loansEntity.DueTime);
            //lbCustomer.Text = loansEntity.CustomerName;
            DateTime detailDate = loansEntity.Date;
            reportAmortizationList = new List<ReportAmortization>();
            res1 = capital;
            double percentInterestAmount = 0;
            double totalInterestAmount = 0;
            double quotaCapital = 0;
            double quaotaInterest = 0;
            DateTime currentDate = new DateTime();
            int days = 0;

            if (loansEntity.ForQuota)
            {
                percentInterestAmount = capital * intPercent;
                quotaCapital = capital / time;
                if (loansEntity.Frequency == "DIARIO")
                {
                    totalInterestAmount = (percentInterestAmount * time) / 30;
                    quaotaInterest = totalInterestAmount / time;
                }
                else if (loansEntity.Frequency == "SEMANAL")
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

                for (int i = 1; i <= loansEntity.DueTime; i++)
                {
                    if (loansEntity.Frequency == "DIARIO")
                    {
                        detailDate = detailDate.AddDays(1);
                    }
                    else if (loansEntity.Frequency == "SEMANAL")
                    {
                        detailDate = detailDate.AddDays(7);
                    }
                    else if (loansEntity.Frequency == "QUINCENAL")
                    {
                        days = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                        if (days == 30)
                        {
                            detailDate = detailDate.AddDays(15);
                        }
                        else if (days == 31)
                        {
                            detailDate = detailDate.AddDays(16);
                        }
                        else if (days == 28)
                        {
                            detailDate = detailDate.AddDays(13);
                        }
                        else if (days == 29)
                        {
                            detailDate = detailDate.AddDays(14);
                        }
                        else
                        {
                            detailDate = detailDate.AddDays(15);
                        }
                    }
                    else
                    {
                        detailDate = detailDate.AddMonths(1);
                    }

                    if (detailDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        detailDate = detailDate.AddDays(1);
                    }

                    res1 = res1 - quotaCapital;
                    if (res1 < 0)
                    {
                        res1 = 0;
                    }

                    //Para imprimir el reporte(factura)
                    reportAmortization = new ReportAmortization();
                    reportAmortization.QuotaNumber = i.ToString();
                    reportAmortization.PayDate = detailDate.ToShortDateString();
                    // reportAmortization.Quota = quota.ToString("0.00", CultureInfo.InvariantCulture);
                    //reportAmortization.Quota = quota.ToString("N2");
                    reportAmortization.Quota = Math.Round(quota).ToString("N2");
                    reportAmortization.Interest = Math.Round(quaotaInterest).ToString("N2");
                    reportAmortization.Amortization = Math.Round(quotaCapital).ToString("N2");
                    reportAmortization.Capital = Math.Round(res1).ToString("N2");
                    reportAmortizationList.Add(reportAmortization);


                    totalInterest = totalInterest + Convert.ToDouble(quaotaInterest);
                }
            }
            else
            {
                if (loansEntity.Frequency == "DIARIO")
                {
                    detailDate = detailDate.AddDays(1);
                }
                else if (loansEntity.Frequency == "SEMANAL")
                {
                    detailDate = detailDate.AddDays(7);
                }
                else if (loansEntity.Frequency == "QUINCENAL")
                {
                    days = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                    if (days == 30)
                    {
                        detailDate = detailDate.AddDays(15);
                    }
                    else if (days == 31)
                    {
                        detailDate = detailDate.AddDays(16);
                    }
                    else if (days == 28)
                    {
                        detailDate = detailDate.AddDays(13);
                    }
                    else if (days == 29)
                    {
                        detailDate = detailDate.AddDays(14);
                    }
                    else
                    {
                        detailDate = detailDate.AddDays(15);
                    }
                }
                else
                {
                    detailDate = detailDate.AddMonths(1);
                }

                if (detailDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    detailDate = detailDate.AddDays(1);
                }

                intPercent = Convert.ToDouble(loansEntity.PercentInterest / 100);
                percentInterestAmount = capital * intPercent;
                quaotaInterest = percentInterestAmount;

                //Para imprimir el reporte(factura)

                res1 = res1 - quotaCapital;
                if (res1 < 0)
                {
                    res1 = 0;
                }
                reportAmortization = new ReportAmortization();
                reportAmortization.QuotaNumber = "1";
                reportAmortization.PayDate = detailDate.ToShortDateString();
                //reportAmortization.Quota = quota.ToString("0,0.00", CultureInfo.InvariantCulture);
                reportAmortization.Quota = Math.Round(quota).ToString("N2");
                reportAmortization.Interest = Math.Round(quaotaInterest).ToString("N2");
                reportAmortization.Amortization = Math.Round(quotaCapital).ToString("N2");
                reportAmortization.Capital = Math.Round(res1).ToString("N2");
                reportAmortizationList.Add(reportAmortization);

                totalInterest = quaotaInterest;
            }

            TbInteresD.Text = totalInterest.ToString();
            TbTotalD.Text = (double.Parse(TbInteresD.Text) + double.Parse(TbMonto.Text)).ToString();
            GridViewAmortizacion.DataSource = null;
            GridViewAmortizacion.DataSource = reportAmortizationList;
            GridViewAmortizacion.DataBind();
            //lbInterest.Text = totalInterest.ToString("0,0.00", CultureInfo.InvariantCulture);
            //lbCapital.Text = loansEntity.Capital.ToString("0,0.00", CultureInfo.InvariantCulture);
            //lbTotalAmount.Text = (Convert.ToDouble(loansEntity.Capital) + totalInterest).ToString("0,0.00", CultureInfo.InvariantCulture);
            //lbSafeAmount.Text = loansEntity.SafeAmount.ToString("0,0.00", CultureInfo.InvariantCulture);
            //lbLawyer.Text = loansEntity.Lawyer.ToString("0,0.00", CultureInfo.InvariantCulture);
            //lbActOfSale.Text = loansEntity.ActOfSale.ToString("0,0.00", CultureInfo.InvariantCulture);
            //lbOpposition.Text = loansEntity.Opposition.ToString("0,0.00", CultureInfo.InvariantCulture);
            //lbTransfer.Text = loansEntity.Transfer.ToString("0,0.00", CultureInfo.InvariantCulture);

            //loansEntity.InterestAmount = Convert.ToDecimal(totalInterest);
            //loansEntity.TotalAmount = Convert.ToDecimal(lbTotalAmount.Text);

            BtnProcesar.Visible = true;


        }




        protected void CargarDropDown()
        {

            try
            {

                for (int i = 0; i <= 365; i++)
                {
                    DropDownTiempo.Items.Add(i.ToString());
                }
                DropDownTiempo.SelectedIndex = 0;


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }


        }
        protected void CargarClientes(object sender, EventArgs e)
        {

            CustomersDAL customersDAL = new CustomersDAL();
            CustomersEntity customersEntity = new CustomersEntity();
            customersDAL.dbm.DataSource = loginDAL.DataSource;
            customersDAL.dbm.User = loginDAL.UserName;
            customersDAL.dbm.Password = loginDAL.UserPassword;
            customersDAL.dbm.DataBase = loginDAL.DataBaseName;

            try
            {

                if (GvClientes.Rows.Count == 0)
                {
                    customersEntity.ID = 0;
                    customersEntity.IdentificationNumber = null;
                    customersEntity.Name = String.IsNullOrEmpty(TbNombreClienteB.Text) ? null : TbNombreClienteB.Text;
                    GvClientes.Controls.Clear();

                    GvClientes.DataSource = customersDAL.Search(customersEntity, loginDAL);
                    GvClientes.DataBind();
                }



            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }
        }

        protected void CargarGarantes(object sender, EventArgs e)
        {

            GuarantorDAL guarantorDAL = new GuarantorDAL();
            GuarantorEntity customersEntity = new GuarantorEntity();
            guarantorDAL.dbm.DataSource = loginDAL.DataSource;
            guarantorDAL.dbm.User = loginDAL.UserName;
            guarantorDAL.dbm.Password = loginDAL.UserPassword;
            guarantorDAL.dbm.DataBase = loginDAL.DataBaseName;

            try
            {

                if (GvGarantes.Rows.Count == 0)
                {
                    customersEntity.ID = 0;
                    customersEntity.IdentificationNumber = null;
                    customersEntity.Name = String.IsNullOrEmpty(TbNombreGarante.Text) ? null : TbNombreGarante.Text;
                    GvGarantes.Controls.Clear();

                    GvGarantes.DataSource = guarantorDAL.Search(customersEntity, loginDAL);
                    GvGarantes.DataBind();
                }



            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }
        }

        protected void CargarDetallePrestamo(object sender, EventArgs e)
        {

            //CustomersDAL customersDAL = new CustomersDAL();
            //CustomersEntity customersEntity = new CustomersEntity();
            //customersDAL.dbm.DataSource = loginDAL.DataSource;
            //customersDAL.dbm.User = loginDAL.UserName;
            //customersDAL.dbm.Password = loginDAL.UserPassword;
            //customersDAL.dbm.DataBase = loginDAL.DataBaseName;

            //try
            //{

            //    if (GvClientes.Rows.Count == 0)
            //    {
            //        customersEntity.ID = 0;
            //        customersEntity.IdentificationNumber = null;
            //        customersEntity.Name = String.IsNullOrEmpty(TbNombreClienteB.Text) ? null : TbNombreClienteB.Text;
            //        GvClientes.Controls.Clear();

            //        GvClientes.DataSource = customersDAL.Search(customersEntity, loginDAL);
            //        GvClientes.DataBind();
            //    }



            //}
            //catch (Exception ex)
            //{

            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            //}
        }

        protected void BtnBuscaC_ServerClick(object sender, EventArgs e)
        {
            CustomersDAL customersDAL = new CustomersDAL();
            CustomersEntity customersEntity = new CustomersEntity();
            customersDAL.dbm.DataSource = loginDAL.DataSource;
            customersDAL.dbm.User = loginDAL.UserName;
            customersDAL.dbm.Password = loginDAL.UserPassword;
            customersDAL.dbm.DataBase = loginDAL.DataBaseName;

            try
            {

                customersEntity.ID = 0;
                customersEntity.IdentificationNumber = null;
                customersEntity.Name = String.IsNullOrEmpty(TbNombreClienteB.Text) ? null : TbNombreClienteB.Text;
                GvClientes.Controls.Clear();

                GvClientes.DataSource = customersDAL.Search(customersEntity, loginDAL);
                GvClientes.DataBind();



            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }

        }

        protected void BtnBuscarG_ServerClick(object sender, EventArgs e)
        {
            GuarantorDAL guarantorDAL = new GuarantorDAL();
            GuarantorEntity customersEntity = new GuarantorEntity();
            guarantorDAL.dbm.DataSource = loginDAL.DataSource;
            guarantorDAL.dbm.User = loginDAL.UserName;
            guarantorDAL.dbm.Password = loginDAL.UserPassword;
            guarantorDAL.dbm.DataBase = loginDAL.DataBaseName;

            try
            {

                customersEntity.ID = 0;
                customersEntity.IdentificationNumber = null;
                customersEntity.Name = String.IsNullOrEmpty(TbNombreGaranteB.Text) ? null : TbNombreGaranteB.Text;
                GvGarantes.Controls.Clear();

                GvGarantes.DataSource = guarantorDAL.Search(customersEntity, loginDAL);
                GvGarantes.DataBind();



            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }

        }

        protected void GvGarantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GvGarantes.SelectedRow.RowIndex >= 0)
            {
                GuarantorDAL guarantorDAL = new GuarantorDAL();
                GuarantorEntity guarantorEntity = new GuarantorEntity();
                List<GuarantorEntity> listGuarantorEntity = new List<GuarantorEntity>();
                guarantorDAL.dbm.DataSource = loginDAL.DataSource;
                guarantorDAL.dbm.User = loginDAL.UserName;
                guarantorDAL.dbm.Password = loginDAL.UserPassword;
                guarantorDAL.dbm.DataBase = loginDAL.DataBaseName;

                try
                {

                    guarantorEntity.ID = int.Parse(GvGarantes.Rows[GvGarantes.SelectedRow.RowIndex].Cells[0].Text);
                    guarantorEntity.IdentificationNumber = null;
                    guarantorEntity.Name = String.IsNullOrEmpty(TbNombreGaranteB.Text) ? null : TbNombreGaranteB.Text;

                    listGuarantorEntity = guarantorDAL.Search(guarantorEntity, loginDAL);
                    TbIdGaranteGC.Text = listGuarantorEntity[0].ID.ToString();
                    TbTipoIdentificacionG.Text = listGuarantorEntity[0].IdentificationType.ToString();
                    TbNumeroIdenticacionG.Text = listGuarantorEntity[0].IdentificationNumber.ToString();
                    TbNombreGarante.Text = listGuarantorEntity[0].Name.ToString();
                    TbTelefonoG.Text = listGuarantorEntity[0].Phone.ToString();
                    TbEstadoG.Text = listGuarantorEntity[0].Status.ToString();



                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
                }

                guarantorDAL = null;
                guarantorEntity = null;
                listGuarantorEntity = null;

            }


        }
        protected void GvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GvClientes.SelectedRow.RowIndex >= 0)
            {
                CustomersDAL customersDAL = new CustomersDAL();
                CustomersEntity customersEntity = new CustomersEntity();
                List<CustomersEntity> listCustomersEntity = new List<CustomersEntity>();
                customersDAL.dbm.DataSource = loginDAL.DataSource;
                customersDAL.dbm.User = loginDAL.UserName;
                customersDAL.dbm.Password = loginDAL.UserPassword;
                customersDAL.dbm.DataBase = loginDAL.DataBaseName;

                try
                {

                    customersEntity.ID = int.Parse(GvClientes.Rows[GvClientes.SelectedRow.RowIndex].Cells[0].Text);
                    customersEntity.IdentificationNumber = null;
                    customersEntity.Name = String.IsNullOrEmpty(TbNombreClienteB.Text) ? null : TbNombreClienteB.Text;

                    listCustomersEntity = customersDAL.Search(customersEntity, loginDAL);
                    TbIdCliente.Text = listCustomersEntity[0].ID.ToString();
                    TbTipoIdentificacionC.Text = listCustomersEntity[0].IdentificationType.ToString();
                    TbNumeroIdenticacionC.Text = listCustomersEntity[0].IdentificationNumber.ToString();
                    TbNombreClienteC.Text = listCustomersEntity[0].Name.ToString();
                    TbTelefonoC.Text = listCustomersEntity[0].Phone.ToString();
                    TbEstadoC.Text = listCustomersEntity[0].Status.ToString();



                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
                }

                customersDAL = null;
                customersEntity = null;
                listCustomersEntity = null;

            }

        }

        protected void BtnGuardar_ServerClick(object sender, EventArgs e)
        {
            LoanDAL loanDAL = new LoanDAL();
            LoansEntity loansEntity = new LoansEntity();

            LoandetailsDAL loandetailsDAL = new LoandetailsDAL();
            LoandetailsEntity loandetailsEntity = new LoandetailsEntity();

            try
            {

                loansEntity.CustomerID = Convert.ToInt32(TbIdCliente.Text);
                loansEntity.GuarantorID = Convert.ToInt32(TbIdGaranteGC.Text);
                loansEntity.DueAmount = Convert.ToDecimal(TbCapitalD.Text);
                loansEntity.Capital = Convert.ToDecimal(TbCapitalD.Text);
                loansEntity.PercentInterest = Convert.ToDecimal(TbInteres.Text);
                loansEntity.InterestAmount = Convert.ToDecimal(TbInteresD.Text);

                loansEntity.Date = DateTime.Now;
                loansEntity.Frequency = DropDownFrecuencia.SelectedValue.ToString();
                loansEntity.DueTime = Convert.ToInt32(DropDownTiempo.SelectedValue.ToString());
                if (CbPorCuota.Checked)
                    loansEntity.ForQuota = true;
                else
                    loansEntity.ForQuota = false;
                loansEntity.TotalAmount = loansEntity.DueAmount + loansEntity.InterestAmount;
                loansEntity.FixedInterest = false;
                loansEntity.SafeAmount = 0;
                loansEntity.Lawyer = 0;
                loansEntity.ActOfSale = 0;
                loansEntity.Opposition = 0;
                loansEntity.Transfer = 0;
                loansEntity.Status = "PENDIENTE";

                loanDAL.Insert(loansEntity, loginDAL);

                foreach (GridViewRow item in GridViewAmortizacion.Rows)
                {

                    loandetailsEntity.QuotaNumber = int.Parse(item.Cells[0].Text);
                    loandetailsEntity.LoandID = loansEntity.ID;
                    //loandetailsEntity.Capital = decimal.Parse(item.Cells[4].Text);
                    loandetailsEntity.Capital = Convert.ToDecimal(item.Cells[4].Text);
                    loandetailsEntity.Interest = loansEntity.PercentInterest;
                    loandetailsEntity.CapitalBalance = decimal.Parse(item.Cells[4].Text);
                    loandetailsEntity.InterestBalance = decimal.Parse(item.Cells[3].Text);
                    loandetailsEntity.Date = DateTime.Parse(item.Cells[1].Text);
                    loandetailsEntity.Status = true;
                    loandetailsDAL.Insert(loandetailsEntity, loginDAL);

                }


                BtnProcesar.Visible = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Prestamo Procesado');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
                BtnProcesar.Visible = false;

            }
        }

        protected void RbInteres_CheckedChanged(object sender, EventArgs e)
        {
            TbInteres.ReadOnly = false;
            TbCuota.ReadOnly = true;

        }

        protected void RbCuota_CheckedChanged(object sender, EventArgs e)
        {
            TbInteres.ReadOnly = true;
            TbCuota.ReadOnly = false;

        }



        protected void BtImprimir_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "script", "ImprimirAmortizacion()", true);
        }
    }
}