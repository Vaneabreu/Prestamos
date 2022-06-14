using MessagingToolkit.QRCode.Codec;
using SoftLoans.Capas.Model;
using SoftLoans.Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SoftLoans
{

    public partial class TicketsDetalleWF : System.Web.UI.Page
    {

        LoginDAL loginDAL = new LoginDAL();
        static string userName = "";
        CustomersDAL customersDAL = new CustomersDAL();
        List<CustomersDAL> customersDALList = new List<CustomersDAL>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session["ListaDetalle"] = null;
            if (Session["DatosUsuario"] != null)
            {
                loginDAL = (LoginDAL)Session["DatosUsuario"];
                userName = loginDAL.UserName;
               // customersDALList = customersDAL.Search(loginDAL);
                CargarInicio();
            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }

            if (!loginDAL.IsAdministrator)
            {
                menuAdmin.Style.Add("display", "none");
            }
            else
            {
                menuUser.Style.Add("display", "none");
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

        protected void BtnLoterias_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeleccionLoteriaWF.aspx");

        }

        protected void BtnNumerosGanadores_Click(object sender, EventArgs e)
        {
            Response.Redirect("NumerosGanadoresWF.aspx");

        }
        protected void BtnCuadre_Click(object sender, EventArgs e)
        {

            Response.Redirect("CuadreWF.aspx");
        }

        protected void BtnImprimir_Click(object sender, EventArgs e)
        {
            //Session["ctrl"] = GvTicketsDetail;
            //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Imprimir.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
            TicketReImprimirC.Style.Add("display", "block");
            PintarTicket(Convert.ToInt64(TbTicketID.InnerText));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ReImprimir()", true);

        }

        protected void GvTicketsDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GvTicketsDetail.SelectedRow.RowIndex >= 0)
            {               

                
                // Session["Parametro"] = customersDAL;
                // Response.Redirect("ClienteCrearWF.aspx");

            }

        }
        protected void GvTicketsDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (allowCancel(loginDAL.UserName))
            {
                if (e.RowIndex >= 0)
                {

                    string title = "Estas seguro?";
                    string text = "Una vez cancelado, ¡no podrá recuperar este ticket!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), null, "NotificacionYN('" + GvTicketsDetail.Rows[e.RowIndex].Cells[0].Text + "','" + title + "','" + text + "','" + OpcionesNotificaciones.Cancelar + "');", true);
                    GvTicketsDetail.DataSource = null;
                    GvTicketsDetail.DataBind();
                }
            }



        }

        public void PintarTicket(long id)
        {
            TransactionsDAL transactionsDAL = new TransactionsDAL();
            List<TransactionsDAL> listTransactionsDAL = new List<TransactionsDAL>();

            TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
            List<TransactionDetailsDAL> listTransactionDetailsDAL = new List<TransactionDetailsDAL>();


            BranchesDAL branchesDAL = new BranchesDAL();
            EmployeeDAL employeeDAL = new EmployeeDAL();
            UsersDAL usersDAL = new UsersDAL();
            List<UsersDAL> listUsersDAL = new List<UsersDAL>();

            LotteriesDAL lotteriesDAL = new LotteriesDAL();
            List<LotteriesDAL> listLotteriesDAL = new List<LotteriesDAL>();

            transactionsDAL.TransactionID = id;
            transactionsDAL.StartTime = DateTime.Now;
            transactionsDAL.EndTime = DateTime.Now;
            listTransactionsDAL = transactionsDAL.Search(loginDAL);

            transactionDetailsDAL.TransactionID = id;
            listTransactionDetailsDAL = transactionDetailsDAL.Search(loginDAL);

            branchesDAL.BranchID = listTransactionsDAL[0].BranchID;
            branchesDAL.GetByKey(loginDAL);

            usersDAL.UserID = listTransactionsDAL[0].UserID;
            listUsersDAL = usersDAL.Search(loginDAL);

            //string nombreBanca = customersDALList[0].PartnerShip;
            string esloganBanca = "Pagamos al instante!";
            string telefonoBanca = branchesDAL.Phone;
            string VendedorBanca = listUsersDAL[0].EmployeeName;
            string numeroTicket = id.ToString();
            string detalleTicket = "";
            int contadorLoterias = 1;
            string FechaBanca = DateTime.Now.ToShortDateString();
           // TicketReImprimir.InnerHtml = "<h3 class='aling-T-C negrita-T'>" + nombreBanca + "</h3>";
            TicketReImprimir.InnerHtml += "<div class='aling-T-C'>" + esloganBanca + "</div><br/>";
            TicketReImprimir.InnerHtml += "<div class='aling-T-L'><a>Telefono:</a><a>" + telefonoBanca + "</a></div>";
            TicketReImprimir.InnerHtml += "<div class='aling-T-L'><a>Vendedor:</a><a>" + VendedorBanca + "</a></div>";
            TicketReImprimir.InnerHtml += "<div class='aling-T-L'><a>Fecha:</a><a>" + FechaBanca + "</a></div><br/>";

            TicketReImprimir.InnerHtml += "<h5 class='aling-T-C negrita-T'>Num. Ticket: " + numeroTicket + "</h5>";
            TicketReImprimir.InnerHtml += "<h6 class='aling-T-C'>Jugadas</h6>";

            TicketReImprimir.InnerHtml += "<div class='aling-T-L'><a>"+listTransactionsDAL[0].CodeName+" </a><a>" + listTransactionsDAL[0].LotteryName + "</a></div>";

          
            TicketReImprimir.InnerHtml += "<br/><div class='row'>";
            TicketReImprimir.InnerHtml += "<div class='col-7 negrita-T'><div class='row justify-content-start negrita-T fs-5'>TP Numeros</div></div>";
            TicketReImprimir.InnerHtml += "<div class='col-2 negrita-T'><div class='row justify-content-start negrita-T fs-5'>Lot.</div></div>";
            TicketReImprimir.InnerHtml += "<div class='col-3 negrita-T'><div class='row justify-content-end negrita-T fs-5'>Valor</div></div>";
            TicketReImprimir.InnerHtml += "<hr class='lineaPuntos-T'/>";
            TicketReImprimir.InnerHtml += "</div>";

            for (int i = 0; i < listTransactionDetailsDAL.Count; i++)
            {
                TicketReImprimir.InnerHtml += "<div class='row'>";
                switch (listTransactionDetailsDAL[i].Numbers.Length)
                {
                    case 2:
                        TicketReImprimir.InnerHtml += "<div class='col-7'><div class='row justify-content-start negrita-T fs-5'>Qn " + listTransactionDetailsDAL[i].Numbers + "</div></div>";
                        break;
                    case 4:
                        TicketReImprimir.InnerHtml += "<div class='col-7'><div class='row justify-content-start negrita-T fs-5'>Pl " + listTransactionDetailsDAL[i].Numbers + "</div></div>";
                        break;
                    case 6:
                        TicketReImprimir.InnerHtml += "<div class='col-7'><div class='row justify-content-start negrita-T fs-5'>Tp  " + listTransactionDetailsDAL[i].Numbers + "</div></div>";
                        break;
                }

                TicketReImprimir.InnerHtml += "<div class='col-2'><div class='row justify-content-start negrita-T fs-5'>" + listTransactionsDAL[0].CodeName + "</div></div>";
                TicketReImprimir.InnerHtml += "<div class='col-3'><div class='row justify-content-end negrita-T fs-5'>$" + listTransactionDetailsDAL[i].Amount + "</div></div>";
                TicketReImprimir.InnerHtml += "</div>";

            }
            

            TicketReImprimir.InnerHtml += detalleTicket;

            TicketReImprimir.InnerHtml += "<h1></h1>";
            TicketReImprimir.InnerHtml += "<h1></h1>";
            TicketReImprimir.InnerHtml += "<div class='row'><hr class='lineaPuntos-T'/></div>";
            TicketReImprimir.InnerHtml += "<div class='row'>";

            //if (loginDAL.UsedFree)
            //{
            //    TicketReImprimir.InnerHtml += "<div class='col-6 negrita-T fs-5'><div class='row justify-content-start'>SubTotal:</div></div>";
            //    TicketReImprimir.InnerHtml += "<div class='col-6 negrita-T'><div class='row justify-content-end fs-5'>$" + listTransactionsDAL[0].Amount + "</div></div>";

            //    TicketReImprimir.InnerHtml += "<div class='col-6 negrita-T fs-5'><div class='row justify-content-start'>Free:</div></div>";
            //    TicketReImprimir.InnerHtml += "<div class='col-6 negrita-T'><div class='row justify-content-end fs-5'>$" + listTransactionsDAL[0].Discount + "</div></div>";
            //}


            TicketReImprimir.InnerHtml += "<div class='col-6 negrita-T fs-5'><div class='row justify-content-start'>Total:</div></div>";
            TicketReImprimir.InnerHtml += "<div class='col-6 negrita-T'><div class='row justify-content-end fs-5'>$" + (listTransactionsDAL[0].Amount- listTransactionsDAL[0].Discount) + "</div></div>";
            TicketReImprimir.InnerHtml += "<hr class='lineaPuntos-T'/>";
            TicketReImprimir.InnerHtml += "<hr class='lineaPuntos-T'/><br/>";
            TicketReImprimir.InnerHtml += "</div><br/><br/>";
            TicketReImprimir.InnerHtml += "<br/><div class='aling-T-C'><a>Buena Suerte</a></div>";
            TicketReImprimir.InnerHtml += "<div class='aling-T-C'><a>Revisar su ticket</a></div>";
            TicketReImprimir.InnerHtml += "<div class='aling-T-C'><a>No pagamos sin ticket</a></div>";
            //TicketReImprimir.InnerHtml += "<div id='DivQRCode'><img runat='server' src ='' id='imgQRCode'/></div>";


            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            Bitmap bitmap = qRCodeEncoder.Encode(numeroTicket);
            System.Drawing.Image image = (System.Drawing.Image)bitmap;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = memoryStream.ToArray();
                imgQRCode.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
                imgQRCode.Height = 100;
                imgQRCode.Width = 100;

            }

        }



     

        public bool allowCancel(string userName)
        {
            bool allow = true;

            UsersDAL usersDAL = new UsersDAL();
            usersDAL.Name = userName;
            allow = usersDAL.AllowCancel(loginDAL);
            usersDAL = null;

            return allow;
        }

        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        protected void CargarInicio()
        {


            if (Session["Parametro"] != null)
            {
                TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
                transactionDetailsDAL = (TransactionDetailsDAL)Session["Parametro"];
                TbTicketID.InnerText = transactionDetailsDAL.TransactionID.ToString();
                TbLotteryName.InnerText = transactionDetailsDAL.LotteryName.ToString();

                try
                {


                    transactionDetailsDAL.TransactionID = String.IsNullOrEmpty(TbTicketID.InnerText) ? 0 : int.Parse(TbTicketID.InnerText);

                    GvTicketsDetail.Controls.Clear();

                    GvTicketsDetail.DataSource = transactionDetailsDAL.Search(loginDAL);
                    GvTicketsDetail.DataBind();

                    calcularTotal();


                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo salio mal, mas detalles: '" + ex.Message + ");", true);
                }


                transactionDetailsDAL = null;
                Session["Parametro"] = null;
            }
        }

        public void calcularTotal()
        {
            int total = 0;
            foreach (GridViewRow item in GvTicketsDetail.Rows)
            {
                total = total + int.Parse(item.Cells[3].Text);
            }
            TbTotalGain.InnerText = "$" + total.ToString();

        }

    }

}
