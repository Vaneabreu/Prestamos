using Loans.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace SoftLoans
{
    public partial class MenuWF : System.Web.UI.Page
    {
        LoginDAL loginDAL = new LoginDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];

                VentasXMes();
                VentasXUsuario();
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
            //shown.bs.toast;
            //toast.show();


            //WaitHandle waitHandle1 = result1.AsyncWaitHandle;
           



        }
        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
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

        private void MostrarMenu()
        {
            APrestamos.Style.Add("display", "block");
            AClientes.Style.Add("display", "block");
            AGarantes.Style.Add("display", "block");
         
            AConsultas.Style.Add("display", "block");
            AConPrestamos.Style.Add("display", "block");
           
            AConfiguracion.Style.Add("display", "block");
            AUsuarios.Style.Add("display", "block");
          

        }
        private void OcultarMenu()
        {
            APrestamos.Style.Add("display", "none");
            AClientes.Style.Add("display", "none");
            AGarantes.Style.Add("display", "none");
            AConsultas.Style.Add("display", "none");
            AConPrestamos.Style.Add("display", "none");
            AConfiguracion.Style.Add("display", "none");
            AUsuarios.Style.Add("display", "none");
          

        }

        protected void VentasXMes()
        {
            CashierDAL cashierDAL = new CashierDAL();
            CashierEntity cashierEntity = new CashierEntity();
            List<CashierEntity> listCashierEntity = new List<CashierEntity>();
            List<CashierEntity> listSalida = new List<CashierEntity>();
            List<CashierEntity> listEntrada = new List<CashierEntity>();

            try
            {
                DateTime mesInicial = DateTime.Now;
                DateTime mesFinal = DateTime.Now;

                mesInicial = mesInicial.AddMonths((mesInicial.Month - 1) * -1);
                mesInicial = mesInicial.AddDays((mesInicial.Day - 1) * -1);
                mesFinal = mesFinal.AddMonths(12 - mesFinal.Month);
                mesFinal = mesFinal.AddDays(31 - mesFinal.Day);
                cashierEntity.StartDate = mesInicial;
                cashierEntity.EndDate = mesFinal;
                listCashierEntity = cashierDAL.Search(cashierEntity, loginDAL);
                listSalida = listCashierEntity.Where(w => w.Type == "Salida").ToList();
                listEntrada = listCashierEntity.Where(w => w.Type == "Entrada").ToList();


                foreach (CashierEntity item in listCashierEntity)
                {

                    item.ID = item.LastUpdate.Month;
                }

                var datoS = listCashierEntity.Where(w => w.Type == "Salida").GroupBy(x => x.ID).
                    Select(g => new { Mes = g.Key, Amount = g.Sum(s => s.Amount) });
                var datoE = listCashierEntity.Where(w => w.Type == "Entrada").GroupBy(x => x.ID).
                    Select(g => new { Mes = g.Key, Amount = g.Sum(s => s.Amount) });

                decimal SEnero = 0,
                        SFebrero = 0,
                        SMarzo = 0,
                        SAbril = 0,
                        SMayo = 0,
                        SJunio = 0,
                        SJulio = 0,
                        SAgosto = 0,
                        SSeptiembre = 0,
                        SOptubre = 0,
                        SNovienbre = 0,
                        SDiciembre = 0;

                decimal EEnero = 0,
                        EFebrero = 0,
                        EMarzo = 0,
                        EAbril = 0,
                        EMayo = 0,
                        EJunio = 0,
                        EJulio = 0,
                        EAgosto = 0,
                        ESeptiembre = 0,
                        EOptubre = 0,
                        ENovienbre = 0,
                        EDiciembre = 0;




                foreach (var item in datoS.ToList())
                {
                    switch (item.Mes.ToString())
                    {
                        case "1": SEnero = item.Amount; break;
                        case "2": SFebrero = item.Amount; break;
                        case "3": SMarzo = item.Amount; break;
                        case "4": SAbril = item.Amount; break;
                        case "5": SMayo = item.Amount; break;
                        case "6": SJunio = item.Amount; break;
                        case "7": SJulio = item.Amount; break;
                        case "8": SAgosto = item.Amount; break;
                        case "9": SSeptiembre = item.Amount; break;
                        case "10": SOptubre = item.Amount; break;
                        case "11": SNovienbre = item.Amount; break;
                        case "12": SDiciembre = item.Amount; break;
                    }

                }

                foreach (var item in datoE.ToList())
                {
                    switch (item.Mes.ToString())
                    {
                        case "1": EEnero = item.Amount; break;
                        case "2": EFebrero = item.Amount; break;
                        case "3": EMarzo = item.Amount; break;
                        case "4": EAbril = item.Amount; break;
                        case "5": EMayo = item.Amount; break;
                        case "6": EJunio = item.Amount; break;
                        case "7": EJulio = item.Amount; break;
                        case "8": EAgosto = item.Amount; break;
                        case "9": ESeptiembre = item.Amount; break;
                        case "10": EOptubre = item.Amount; break;
                        case "11": ENovienbre = item.Amount; break;
                        case "12": EDiciembre = item.Amount; break;
                    }

                }

                string[] x1 = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Optubre", "Novienbre", "Diciembre" };
                decimal[] yS = { SEnero, SFebrero, SMarzo, SAbril, SMayo, SJunio, SJulio, SAgosto, SSeptiembre, SOptubre, SNovienbre, SDiciembre };
                decimal[] yE = { EEnero, EFebrero, EMarzo, EAbril, EMayo, EJunio, EJulio, EAgosto, ESeptiembre, EOptubre, ENovienbre, EDiciembre };

                ChartVxMM.Series["SeriesVxMSM"].Points.DataBindXY(x1, yS);
                ChartVxMM.Series["SeriesVxMSM"].LegendText = "Salidas";

                ChartVxMM.Series["SeriesVxMSM"].IsVisibleInLegend = true;
                ChartVxMM.Series["SeriesVxMSM"].Color = System.Drawing.Color.Red;
                ChartVxMM.Series["SeriesVxMSM"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                ChartVxMM.Series["SeriesVxMEM"].Points.DataBindXY(x1, yE);
                ChartVxMM.Series["SeriesVxMEM"].LegendText = "Entradas";
                ChartVxMM.Series["SeriesVxMEM"].Color = System.Drawing.Color.Green;
                ChartVxMM.Series["SeriesVxMEM"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;


                ChartVxMM.ChartAreas["ChartAreaVxMM"].Area3DStyle.Enable3D = true;
                ChartVxMM.Titles["TitleVxMM"].Text = "Flujo del " + DateTime.Now.Year;

                ChartVxMW.Series["SeriesVxMSW"].Points.DataBindXY(x1, yS);
                ChartVxMW.Series["SeriesVxMSW"].LegendText = "Salidas";

                ChartVxMW.Series["SeriesVxMSW"].IsVisibleInLegend = true;
                ChartVxMW.Series["SeriesVxMSW"].Color = System.Drawing.Color.Red;
                ChartVxMW.Series["SeriesVxMSW"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

                ChartVxMW.Series["SeriesVxMEW"].Points.DataBindXY(x1, yE);
                ChartVxMW.Series["SeriesVxMEW"].LegendText = "Entradas";
                ChartVxMW.Series["SeriesVxMEW"].Color = System.Drawing.Color.Green;
                ChartVxMW.Series["SeriesVxMEW"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;


                ChartVxMW.ChartAreas["ChartAreaVxMW"].Area3DStyle.Enable3D = true;
                ChartVxMW.Titles["TitleVxMW"].Text = "Flujo del " + DateTime.Now.Year;




            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }

            cashierDAL = null;
            cashierEntity = null;
            listCashierEntity = null;
            listSalida = null;
            listEntrada = null;


        }
        protected void VentasXUsuario()
        {
            CashierDAL cashierDAL = new CashierDAL();
            CashierEntity cashierEntity = new CashierEntity();
            List<CashierEntity> listCashierEntity = new List<CashierEntity>();
            List<CashierEntity> listSalida = new List<CashierEntity>();
            List<CashierEntity> listEntrada = new List<CashierEntity>();
            DateTime mesInicial = DateTime.Now;
            DateTime mesFinal = DateTime.Now;
            try
            {

                mesInicial = mesInicial.AddMonths((mesInicial.Month - 1) * -1);
                mesInicial = mesInicial.AddDays((mesInicial.Day - 1) * -1);
                mesFinal = mesFinal.AddMonths(12 - mesFinal.Month);
                mesFinal = mesFinal.AddDays(31 - mesFinal.Day);
                cashierEntity.StartDate = mesInicial;
                cashierEntity.EndDate = mesFinal;
                cashierEntity.StartDate = DateTime.Now;
                cashierEntity.EndDate = DateTime.Now;

                listCashierEntity = cashierDAL.Search(cashierEntity, loginDAL);
                listSalida = listCashierEntity.Where(w => w.Type == "Salida").ToList();
                listEntrada = listCashierEntity.Where(w => w.Type == "Entrada").ToList();

                var salida = listSalida.GroupBy(x => x.Type).
               Select(g => new { EntSal = g.Key, Amount = g.Sum(s => s.Amount) });
                var entrada = listEntrada.GroupBy(x => x.Type).
              Select(g => new { EntSal = g.Key, Amount = g.Sum(s => s.Amount) });
                var item1 = salida.ToList();
                var item2 = entrada.ToList();
                string[] x1 = new string[2];
                decimal[] y1 = new decimal[2];
                string[] x2 = { "Sin Flujo" };
                decimal[] y2 = { 100 };


                if (item1.Count <= 0)
                {
                    x1[0] = "Salida";
                    y1[0] = 0;
                }
                else
                {
                    x1[0] = item1[0].EntSal;
                    y1[0] = item1[0].Amount;

                }

                if (item2.Count <= 0)
                {
                    x1[1] = "Entrada";
                    y1[1] = 0;
                }
                else
                {
                    x1[1] = item2[0].EntSal;
                    y1[1] = item2[0].Amount;

                }


                if (item1.Count <= 0 && item2.Count <= 0)
                {
                    ChartVxUM.Series[0].Points.DataBindXY(x2, y2);
                    ChartVxUM.Series[0].Points[0].Color = System.Drawing.Color.Gray;

                    ChartVxUW.Series[0].Points.DataBindXY(x2, y2);
                    ChartVxUW.Series[0].Points[0].Color = System.Drawing.Color.Gray;
                }
                else
                {

                    ChartVxUM.Series[0].Points.DataBindXY(x1, y1);
                    ChartVxUM.Series[0].Points[0].Color = System.Drawing.Color.Red;
                    ChartVxUM.Series[0].Points[1].Color = System.Drawing.Color.Green;

                    ChartVxUW.Series[0].Points.DataBindXY(x1, y1);
                    ChartVxUW.Series[0].Points[0].Color = System.Drawing.Color.Red;
                    ChartVxUW.Series[0].Points[1].Color = System.Drawing.Color.Green;
                }
                ChartVxUM.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.
                    SeriesChartType.Pie;
                ChartVxUM.ChartAreas["ChartAreaVxUM"].Area3DStyle.Enable3D = true;
                ChartVxUM.Series[0]["PieLabelStyle"] = "Disabled";
                ChartVxUM.Legends[0].Enabled = true;

                ChartVxUW.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.
                   SeriesChartType.Pie;
                ChartVxUW.ChartAreas["ChartAreaVxUW"].Area3DStyle.Enable3D = true;
                ChartVxUW.Series[0]["PieLabelStyle"] = "Disabled";
                ChartVxUW.Legends[0].Enabled = true;


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
            }

            cashierDAL = null;
            cashierEntity = null;
            listCashierEntity = null;
            listSalida = null;
            listEntrada = null;

        }


    }

}