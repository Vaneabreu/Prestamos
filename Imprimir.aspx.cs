using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Web.SessionState;
using System.Web.Mvc;

using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using System.Web.Razor.Generator;
using System.Drawing.Printing;

namespace SoftLoans
{
    public partial class Imprimir : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Control ctrl = (Control)Session["ctrl"];
            //PrintWebControl(ctrl);

            string ss = "";
            ss += "<div class='container'><div class='row'>"
            + "<div class='col-5' style='text-align-last: left; font-weight: bold;'>"
            + "TPNume."
            + "</div>"
            + "<div class='col' style='text-align-last: left; font-weight: bold;'>"
            + "Loterias"
            + "</div>"
            + "<div class='col' style='text-align-last: right; font-weight: bold;'>"
            + "Valor"
            + "</div>"
            + ""
            + "</div>"
            + "<div class='row'>"
            + "<div class='col' style='text-align-last: center;'>"
            + "-------------------------------------------"
            + "</div>"
            + "</div>"
            + "<divclass='row'>"
            + "<div class='col-5' style='text-align-last: left; font-weight: bold;'>"
            + "QN 87-99-09"
            + "</div>"
            + "<div class='col' style='text-align-last: left; font-weight: bold;'>"
            + "LP"
            + "</div>"
            + "<div class='col' style='text-align-last: right; font-weight: bold;'>"
            + "S100"
            + "</div>"
            + ""
            + "</div>"
            + " <div class='row'>"
            + "<div class='col' style='text-align-last: center;'>"
            + "-------------------------------------------"
            + "</div>"
            + "</div></div>"
            + "<asp:Table runat='server' Width='100%' BackColor='Red'>"
            + "<asp:TableHeaderRow Style='text-align-last:left'>"
            + "<asp:TableHeaderCell Style='text-align-last:left'>TP Numero</asp:TableHeaderCell>"
            + "<asp:TableHeaderCell Style='text-align-last:left'>Loterias</asp:TableHeaderCell>"
            + "<asp:TableHeaderCell Style='text-align-last:right'>Valor</asp:TableHeaderCell>"
            + "</asp:TableHeaderRow>"
            + "</asp:Table>";
            string s = "";
            s += "<div class='container' style='background-color:aqua; width: 300px; text-align-last: center'>"
                  + "<h3>Banca 01</h3><div>Pagamosal instante</div><br/><div style ='text-align-last:left'>"
                  + "<a>Telefono:</a><a>829-248-4353</a></div><div style='text-align-last: left'><a>Vendedor:</a><a>Victor Manuel</a></div>"
                   + "<div style='text-align-last: left'><a> Fecha:</a><a> 21 / 05 / 2021 00:03:06 </a></div><br/><div style='text-align-last: center;'>"
                   + "<a>Num.Ticket:</a><a>210004552</a></div><div style='text-align-last: center'><h3>Jugadas</h3></div><div style='text-align-last: left'>"
                    + "<a>LP:</a><a>La Primera</a></div><br/>"
                     + "<table class='table table-hover'  style='width: 100%'><thead><tr>"
                            + "<th scope='col'>TP Numero.</th>"
                          + "<th scope='col'>Loterias</th>"
                          + "<th scope='col'>Valor</th>"
                       + " </tr>"
                      + "</thead>"
                      + "<tbody><tr>"
                          + "<td>QN</td>"
                          + "<td>87-99-09</td>"
                          + "<td>$100</td>"
                          + "</tr></tbody>"
                          + "</table>"
                    + "<div class='row'><div class='col' style='text-align-last: center;'>"
                    + "-------------------------------------------</div> </div>"
                    + "<table class='table table-hover'  style='width: 100%'><thead><tr>"
                            + "<th scope='col'></th>"
                          + "<th scope='col'></th>"
                          + "<th scope='col'></th>"
                       + " </tr>"
                      + "</thead>"
                      + "<tbody><tr>"
                          + "<th scope='row'>SUB-T</th>"
                          + "<td>Rd$100</td>"
                          + "</tr>" +
                          "<tr>"
                          + "<th scope='row'>Free</th>"
                          + "<td>Rd$0</td>"
                          + "</tr><tr>"
                          + "<th scope='row'>Total</th>"
                          + "<td>Rd$100</td>"
                          + "</tr></tbody>"
                          + "</table>"
                    + "<div class='row'><div class='col' style='text-align-last: center;'>"
                    + "-------------------------------------------"
                    + "-------------------------------------------"
                + "</div></div><div class='row'><div class='col' style='text-align-last: center;'>Buena Suerte</div></div><div class='col' style='text-align-last: center;'>Revisar su ticket"
                + "</div><div class='col' style='text-align-last: center;'>No pagamos sin ticket</div><br/></div>";

            StringWriter stringWrite = new StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            Page pg = new Page();
            pg.EnableEventValidation = false;
            pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", ss);
            HtmlForm frm = new HtmlForm();
            pg.Controls.Add(frm);
            frm.Attributes.Add("runat", "server");
            pg.DesignerInitialize();
            pg.RenderControl(htmlWrite);
            string strHTML = stringWrite.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(strHTML);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.Print();

        }
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {

            string ss = "";
            ss += "<div class='container'><div class='row'>"
            + "<div class='col-5' style='text-align-last: left; font-weight: bold;'>"
            + "TPNume."
            + "</div>"
            + "<div class='col' style='text-align-last: left; font-weight: bold;'>"
            + "Loterias"
            + "</div>"
            + "<div class='col' style='text-align-last: right; font-weight: bold;'>"
            + "Valor"
            + "</div>"
            + ""
            + "</div>"
            + "<div class='row'>"
            + "<div class='col' style='text-align-last: center;'>"
            + "-------------------------------------------"
            + "</div>"
            + "</div>"
            + "<divclass='row'>"
            + "<div class='col-5' style='text-align-last: left; font-weight: bold;'>"
            + "QN 87-99-09"
            + "</div>"
            + "<div class='col' style='text-align-last: left; font-weight: bold;'>"
            + "LP"
            + "</div>"
            + "<div class='col' style='text-align-last: right; font-weight: bold;'>"
            + "S100"
            + "</div>"
            + ""
            + "</div>"
            + " <div class='row'>"
            + "<div class='col' style='text-align-last: center;'>"
            + "-------------------------------------------"
            + "</div>"
            + "</div></div>"
            + "<asp:Table runat='server' Width='100%' BackColor='Red'>"
            + "<asp:TableHeaderRow Style='text-align-last:left'>"
            + "<asp:TableHeaderCell Style='text-align-last:left'>TP Numero</asp:TableHeaderCell>"
            + "<asp:TableHeaderCell Style='text-align-last:left'>Loterias</asp:TableHeaderCell>"
            + "<asp:TableHeaderCell Style='text-align-last:right'>Valor</asp:TableHeaderCell>"
            + "</asp:TableHeaderRow>"
            + "</asp:Table>";
            Page pg = new Page();
            pg.EnableEventValidation = false;
            pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", ss);
            //System.Drawing.Image image = (System.Drawing.Image)image;
            e.Graphics.DrawString(pg.ToString(), new Font("Arial", 10), Brushes.Black, 100, 200);
            e.HasMorePages = false;
        }

        public static void PrintWebControl(Control ctrl)
        {
            string s = "";
            PrintWebControl(ctrl, string.Empty);
        }

        public static void PrintWebControl(Control ctrl, string Script)
        {
            StringWriter stringWrite = new StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            if (ctrl is WebControl)
            {
                Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
            }
            Page pg = new Page();
            pg.EnableEventValidation = false;
            if (Script != string.Empty)
            {
                pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
            }
            HtmlForm frm = new HtmlForm();
            pg.Controls.Add(frm);
            frm.Attributes.Add("runat", "server");
            frm.Controls.Add(ctrl);
            pg.DesignerInitialize();
            pg.RenderControl(htmlWrite);
            string strHTML = stringWrite.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(strHTML);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }

        private void ImprimirTPV(object sender, PrintPageEventArgs e)
        {
            int LineaAncho = 23;
            int LimiteIzquierdo = 5;
            int LimiteDerecho = 311;
            int AlturaInicial = 10;

            Font fontTitulo = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Point);
            Font fontCabecera = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            Font fontCabeceraNegrita = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            Font fontCuerpo = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
            Font fontPie = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Point);
            //configuracion Inicial RectangleF(5, 10, 311, 46)
            //segunda configuracion RectangleF(5, 56, 311, 23)
            string NomEmpresa = "Banca 01";
            string RncEmpresa = "0100000005";
            string NomSucursal = "Sucursal 01";
            string DirecEmpresa = "Bonagua la Palmita";
            string PrefijoNcf = "B01";
            string LbNcf = "B01000000001";
            string LbNumDoc = "203300445";
            string CodSucursalUsuario = "0001";
            string NomCli = "Victor Manuel";
            string RncCli = "010450009";
            string DirecCli = "Las Palmas";
            string LbNombreVend = "Vendedor Generico";
            string LbSumaItbis = "0";
            string LbTotalDocumento = "100";
            int descuentoDocP = 0;
            int cobroCreditoP = 0;
            int cobroEfectivoP = 100;


            if (NomEmpresa.Length > 30)
                LineaAncho = LineaAncho * 2;

            //e.Graphics.DrawString("1000  PP de sistema de gestion empresarial 1000  PP de sistema de gestion empresarial", font, Brushes.Black, new RectangleF(5, 10, 311, LineaAncho));
            e.Graphics.DrawString(NomEmpresa, fontTitulo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho, LineaAncho));
            AlturaInicial = AlturaInicial + LineaAncho;
            if (NomEmpresa.Length > 30)
                LineaAncho = LineaAncho / 2;

            e.Graphics.DrawString("RNC:" + RncEmpresa, fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 150, LineaAncho));
            e.Graphics.DrawString("Fecha:" + DateTime.Now.ToShortDateString(), fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo - 150, AlturaInicial, LimiteDerecho - 150, LineaAncho));
            AlturaInicial = AlturaInicial + LineaAncho;
            e.Graphics.DrawString("Sucursal: " + NomSucursal, fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho, LineaAncho));
            AlturaInicial = AlturaInicial + LineaAncho;
            if (DirecEmpresa.Length > 30)
                LineaAncho = LineaAncho * 2;

            e.Graphics.DrawString(DirecEmpresa, fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho, LineaAncho));
            AlturaInicial = AlturaInicial + LineaAncho;
            if (DirecEmpresa.Length > 30)
                LineaAncho = LineaAncho / 2;

            if (!String.IsNullOrEmpty(PrefijoNcf))
            {
                e.Graphics.DrawString("NCF: " + LbNcf, fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 150, LineaAncho));
                e.Graphics.DrawString("#F: " + CodSucursalUsuario + "T" + LbNumDoc, fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo + 150, AlturaInicial, LimiteDerecho - 150, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
            }
            else
            {
                e.Graphics.DrawString("#F: " + LbNumDoc, fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
            }


            if (PrefijoNcf != "B02")
            {
                e.Graphics.DrawString(NomCli, fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;

                if (!String.IsNullOrEmpty(RncCli))
                {
                    e.Graphics.DrawString("RNC: " + RncCli, fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho, LineaAncho));
                    AlturaInicial = AlturaInicial + LineaAncho;
                }

                if (!String.IsNullOrEmpty(DirecCli))
                {
                    if (DirecCli.Length > 30)
                        LineaAncho = LineaAncho * 2;

                    e.Graphics.DrawString("Dir.: " + DirecCli, fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho, LineaAncho));
                    AlturaInicial = AlturaInicial + LineaAncho;

                    if (DirecCli.Length > 30)
                        LineaAncho = LineaAncho / 2;
                }

            }

            e.Graphics.DrawString("Ven.: " + LbNombreVend, fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho, LineaAncho));
            AlturaInicial = AlturaInicial + LineaAncho;

            if (String.IsNullOrEmpty(PrefijoNcf))
            {
                e.Graphics.DrawString("------------------------------------------------------------------------------------------" +
                    "----", fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 5, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
                e.Graphics.DrawString("Factura" + DirecCli, fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo + 120, AlturaInicial, LimiteDerecho, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
                e.Graphics.DrawString("-------------------------------------------------------------------------------------------" +
                    "---", fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 5, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;

            }
            else if (PrefijoNcf == "B02")
            {
                e.Graphics.DrawString("---------------------------------------------------------------------------------------------" +
                    "-", fontCabecera, Brushes.Gray, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 5, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
                e.Graphics.DrawString("Factura de Consumo", fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo + 10, AlturaInicial, LimiteDerecho, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
                e.Graphics.DrawString("---------------------------------------------------------------------------------------------" +
                    "-", fontCabecera, Brushes.Gray, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 5, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
            }
            else // if (PrefijoNcf == "B01")
            {
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------" +
                    "--", fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 5, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
                e.Graphics.DrawString("Factura de Credito Fiscal", fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo + 10, AlturaInicial, LimiteDerecho, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
                e.Graphics.DrawString("---------------------------------------------------------------------------------------------" +
                    "-", fontCabecera, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 5, LineaAncho));
                AlturaInicial = AlturaInicial + LineaAncho;
            }

            e.Graphics.DrawString("(Cant.) Articulo", fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 5, LineaAncho));
            e.Graphics.DrawString("Itbis", fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo + 200, AlturaInicial, LimiteDerecho - 250, LineaAncho));
            e.Graphics.DrawString("Precio", fontCabeceraNegrita, Brushes.Black, new RectangleF(LimiteIzquierdo + 250, AlturaInicial, LimiteDerecho - 250, LineaAncho));
            AlturaInicial = AlturaInicial + LineaAncho;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------" +
                "-", fontCabecera, Brushes.Gray, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 1, LineaAncho));
            AlturaInicial = AlturaInicial + LineaAncho;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.LineAlignment = StringAlignment.Far;

            StringFormat stringFormat1 = new StringFormat();
            stringFormat1.Alignment = StringAlignment.Near;
            stringFormat1.LineAlignment = StringAlignment.Far;

            //foreach (DataGridViewRow item in DgvTpv.Rows)
            //{
            //    if ((item.Cells["Descripcion"].Value.ToString() + " (" + item.Cells["Cantidad"].Value.ToString() + ")").Length > 30)
            //        LineaAncho = LineaAncho * 2;

            //    e.Graphics.DrawString("(" + item.Cells["Cantidad"].Value.ToString() + ") " + item.Cells["Descripcion"].Value.ToString(), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            //    e.Graphics.DrawString(item.Cells["ItbisImpor"].Tag.ToString(), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 165, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);
            //    e.Graphics.DrawString(item.Cells["ImporMasItbis"].Tag.ToString(), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);
            //    AlturaInicial = AlturaInicial + LineaAncho;
            //    if ((item.Cells["Descripcion"].Value.ToString() + " (" + item.Cells["Cantidad"].Value.ToString() + ")").Length > 30)
            //        LineaAncho = LineaAncho / 2;

            //}
            string Descripcion = "Prueba de loto";
            if (Descripcion.Length > 30)
                LineaAncho = LineaAncho * 2;

            string Cantidad = "1";
            string ItbisImpor    = "0";
            string ImporMasItbis = "100";
            e.Graphics.DrawString("(" + Cantidad + ") " + Descripcion, fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            e.Graphics.DrawString(ItbisImpor, fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 165, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);
            e.Graphics.DrawString(ImporMasItbis, fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);
            AlturaInicial = AlturaInicial + LineaAncho;
            //if ((item.Cells["Descripcion"].Value.ToString() + " (" + item.Cells["Cantidad"].Value.ToString() + ")").Length > 30)
            //    LineaAncho = LineaAncho / 2;

            AlturaInicial = AlturaInicial + LineaAncho;
            e.Graphics.DrawString("TOTAL FACTURA:", fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            e.Graphics.DrawString(LbSumaItbis, fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 165, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);
            e.Graphics.DrawString(LbTotalDocumento, fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            //if (descuentoDocP > 0)
            //{
            //    AlturaInicial = AlturaInicial + LineaAncho;
            //    e.Graphics.DrawString("Descuento:", fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            //    e.Graphics.DrawString(descuentoDocP.ToString("N2"), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            //}

            //if (cobroCreditoP > 0)
            //{
            //    AlturaInicial = AlturaInicial + LineaAncho;
            //    e.Graphics.DrawString("Credito a " + diasP.ToString() + " dias de " + cuotasP.ToString() + " cuota" + (cuotasP > 1 ? "s" : ""), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1); ;
            //    e.Graphics.DrawString(cobroCreditoP.ToString("N2"), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            //}

            AlturaInicial = AlturaInicial + LineaAncho;
            e.Graphics.DrawString("TOTAL A PAGAR:", fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            //e.Graphics.DrawString(LbSumaItbis.Tag.ToString(), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 165, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);
            e.Graphics.DrawString((float.Parse(LbTotalDocumento) - descuentoDocP - cobroCreditoP).ToString("N2"), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            if (cobroEfectivoP > 0)
            {
                AlturaInicial = AlturaInicial + LineaAncho;
                e.Graphics.DrawString("Efectivo:", fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
                e.Graphics.DrawString(cobroEfectivoP.ToString("N2"), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            }

            //if (cobroChequeP > 0)
            //{
            //    AlturaInicial = AlturaInicial + LineaAncho;
            //    e.Graphics.DrawString("Cheque:", fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            //    e.Graphics.DrawString(cobroChequeP.ToString("N2"), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            //}

            //if (cobroTarjetaP > 0)
            //{
            //    AlturaInicial = AlturaInicial + LineaAncho;
            //    e.Graphics.DrawString("Tarjeta:", fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            //    e.Graphics.DrawString(cobroTarjetaP.ToString("N2"), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            //}

            //if (cobroTransferenciaP > 0)
            //{
            //    AlturaInicial = AlturaInicial + LineaAncho;
            //    e.Graphics.DrawString("Transferencia:", fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            //    e.Graphics.DrawString(cobroTransferenciaP.ToString("N2"), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            //}

            //if (devueltaEfectivoP > 0)
            //{
            //    AlturaInicial = AlturaInicial + LineaAncho;
            //    e.Graphics.DrawString("Cambio:", fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo, AlturaInicial, LimiteDerecho - 134, LineaAncho), stringFormat1);
            //    e.Graphics.DrawString(devueltaEfectivoP.ToString("N2"), fontCuerpo, Brushes.Black, new RectangleF(LimiteIzquierdo + 230, AlturaInicial, LimiteDerecho - 245, LineaAncho), stringFormat);

            //}

            AlturaInicial = AlturaInicial + LineaAncho;
            AlturaInicial = AlturaInicial + LineaAncho;
            e.Graphics.DrawString("¡Gracias por su compra, vuelva pronto!", fontCuerpo, Brushes.Gray, new RectangleF(LimiteIzquierdo + 15, AlturaInicial, LimiteDerecho - 1, LineaAncho));




        }

        protected void BtnGenerarQR_Click(object sender, EventArgs e)
        {
            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            Bitmap bitmap = qRCodeEncoder.Encode(TbCode.Value);
            System.Drawing.Image image = (System.Drawing.Image)bitmap;


            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = memoryStream.ToArray();
                imgCtrl.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
                imgCtrl.Height = 100;
                imgCtrl.Width = 100;

            }

        }



        /******Probando con metodos*/
      

    }

}