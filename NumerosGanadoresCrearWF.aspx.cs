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
    public partial class NumerosGanadoresCrearWF : System.Web.UI.Page
    {
        public string codigo;
        LoginDAL loginDAL = new LoginDAL();
        List<TransactionDetailsDAL> listMail = new List<TransactionDetailsDAL>();
        StringBuilder mail = new StringBuilder();
        CustomersDAL customersDAL = new CustomersDAL();
        List<CustomersDAL> customersDALList = new List<CustomersDAL>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosUsuario"] != null)
            {

                loginDAL = (LoginDAL)Session["DatosUsuario"];

                if (!IsPostBack)
                {
                    InputFecha.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    CargarDropDown();
                    if (loginDAL.UserName.IndexOf("SuperAdmin",0, loginDAL.UserName.Length) >=0)
                    {
                        DivGridView.Style.Add("display", "block");
                        CargarBseDatos();
                    }
                    else 
                    {
                        DivGridView.Style.Add("display", "none");
                    }
                }
                //customersDALList = customersDAL.Search(loginDAL);
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


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (RFVFirstNumber.IsValid && RFVSecondNumber.IsValid && RFVThirdNumber.IsValid)
            {
                if (loginDAL.UserName.IndexOf("SuperAdmin", 0, loginDAL.UserName.Length) >= 0)
                {
                    string baseDatos = "";
                    bool marcadoSI = false;
                    foreach (GridViewRow item in GvBaseDatos.Rows)
                    {
                        System.Web.UI.WebControls.CheckBox checkBoxItem = (System.Web.UI.WebControls.CheckBox)item.FindControl("CbItem");
                        if (checkBoxItem.Checked)
                        {
                            marcadoSI = true;
                            baseDatos = loginDAL.DataBaseName;
                            loginDAL.DataBaseName = item.Cells[0].Text;
                            GuardarSuperAdmin();
                            loginDAL.DataBaseName = baseDatos;
                        }

                    }

                    if (!marcadoSI)
                        Notificacion("Error!", "Debe marcar por lo menos una base de datos.", "error");
                }
                else 
                {
                    Guardar();
                }
          



            }

        }

        public void Notificacion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        protected void CargarInicio()
        {

            RFVFirstNumber.EnableClientScript = false;
            RFVSecondNumber.EnableClientScript = false;
            RFVThirdNumber.EnableClientScript = false;


        }
        protected void Guardar()
        {
            int gainCount = 0;
            List<WinNumbersDAL> winNumbersDALList = new List<WinNumbersDAL>();
            StringBuilder gainNumbers = new StringBuilder();
            gainNumbers.AppendLine("Tickets Premiados");

            WinNumbersDAL winNumbersDAL = new WinNumbersDAL();
            try
            {


                winNumbersDAL.First = String.IsNullOrEmpty(TbFirstNumber.Text) ? "" : TbFirstNumber.Text;
                winNumbersDAL.Second = String.IsNullOrEmpty(TbSecondNumber.Text) ? "" : TbSecondNumber.Text;
                winNumbersDAL.Third = String.IsNullOrEmpty(TbThirdNumber.Text) ? "" : TbThirdNumber.Text;

                winNumbersDAL.Date = Convert.ToDateTime(InputFecha.Value);

                winNumbersDAL.LotteryID = Convert.ToInt32(DropDownListLottery.SelectedItem.Value);

                winNumbersDAL.StartDate = Convert.ToDateTime(InputFecha.Value);
                winNumbersDAL.EndDate = Convert.ToDateTime(InputFecha.Value);
                winNumbersDALList = winNumbersDAL.Search(loginDAL);

                if (winNumbersDALList.Count > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), null, "Confirmacion('Los números para " + DropDownListLottery.SelectedItem.Text + " ya fueron registrados!','NumerosGanadoresWF.aspx')", true);
                    Notificacion("Números ya registrados", "Los números para " + DropDownListLottery.SelectedItem.Text + " ya fueron registrados!", "warning");
                }
                else
                {
                    if (winNumbersDAL.Insert(loginDAL))
                    {

                        UsersDAL usersDAL = new UsersDAL();
                        List<UsersDAL> usersDALList = new List<UsersDAL>();
                        List<TransactionsDAL> TransactionstDALList = new List<TransactionsDAL>();
                        List<TransactionDetailsDAL> transactionDetailsDALList = new List<TransactionDetailsDAL>();
                        TransactionsDAL transactionsDAL;
                        TransactionDetailsDAL transactionDetailsDAL;

                        usersDALList = usersDAL.Search(loginDAL);

                        if (usersDAL.ErrorCode == 0)
                        {
                            foreach (UsersDAL itemUser in usersDALList)
                            {

                                transactionsDAL = new TransactionsDAL();
                                transactionsDAL.UserName = itemUser.Name.ToString();
                                transactionsDAL.StartTime = Convert.ToDateTime(InputFecha.Value);
                                transactionsDAL.EndTime = Convert.ToDateTime(InputFecha.Value);
                                transactionsDAL.LotteryID = Convert.ToInt32(DropDownListLottery.SelectedItem.Value);

                                TransactionstDALList = transactionsDAL.Search(loginDAL);

                                if (transactionsDAL.ErrorCode == 0)
                                {
                                    foreach (TransactionsDAL item in TransactionstDALList)
                                    {

                                        transactionDetailsDAL = new TransactionDetailsDAL();
                                        transactionDetailsDAL.TransactionID = item.TransactionID;
                                        transactionDetailsDALList = transactionDetailsDAL.VerifyTicketPaid(false, loginDAL);

                                        if (transactionDetailsDAL.ErrorCode == 0)
                                        {
                                            if (transactionDetailsDALList.Count > 0)
                                            {

                                                gainNumbers.AppendLine("No. Ticket -->" + transactionDetailsDALList[0].TransactionID);
                                                gainCount++;


                                                listMail.Add(transactionDetailsDALList[0]);
                                            }

                                        }
                                        else
                                        {
                                            //mensaje de error
                                            // MessageBox.Show(transactionDetailsDAL.ErrorCode + ": " + transactionDetailsDAL.ErrorDescription);
                                        }


                                    }

                                }

                            }

                            sendMailGainNumber(listMail, TbFirstNumber.Text, TbSecondNumber.Text, TbThirdNumber.Text, DropDownListLottery.SelectedItem.Text);
                        }
                        if (gainCount == 0)
                            gainNumbers.AppendLine(gainCount.ToString());

                        ScriptManager.RegisterStartupScript(this, this.GetType(), null, "ConfirmacionOneButton('Número agregado con exito! Tickets Ganadores:" + gainCount.ToString() + "','NumerosGanadoresWF.aspx')", true);

                        usersDAL = null;
                        transactionDetailsDAL = null;
                        transactionsDAL = null;


                    }
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            winNumbersDAL = null;


        }
        protected void GuardarSuperAdmin()
        {
            int gainCount = 0;
            List<WinNumbersDAL> winNumbersDALList = new List<WinNumbersDAL>();
            StringBuilder gainNumbers = new StringBuilder();
            gainNumbers.AppendLine("Tickets Premiados");

            WinNumbersDAL winNumbersDAL = new WinNumbersDAL();
            try
            {


                winNumbersDAL.First = String.IsNullOrEmpty(TbFirstNumber.Text) ? "" : TbFirstNumber.Text;
                winNumbersDAL.Second = String.IsNullOrEmpty(TbSecondNumber.Text) ? "" : TbSecondNumber.Text;
                winNumbersDAL.Third = String.IsNullOrEmpty(TbThirdNumber.Text) ? "" : TbThirdNumber.Text;

                winNumbersDAL.Date = Convert.ToDateTime(InputFecha.Value);

                winNumbersDAL.LotteryID = Convert.ToInt32(DropDownListLottery.SelectedItem.Value);

                winNumbersDAL.StartDate = Convert.ToDateTime(InputFecha.Value);
                winNumbersDAL.EndDate = Convert.ToDateTime(InputFecha.Value);
                winNumbersDALList = winNumbersDAL.Search(loginDAL);

                if (winNumbersDALList.Count > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), null, "Confirmacion('Los números para " + DropDownListLottery.SelectedItem.Text + " ya fueron registrados!','NumerosGanadoresWF.aspx')", true);
                    Notificacion("Números ya registrados", "Los números para " + DropDownListLottery.SelectedItem.Text + " ya fueron registrados!", "warning");
                }
                else
                {
                    if (winNumbersDAL.Insert(loginDAL))
                    {

                        UsersDAL usersDAL = new UsersDAL();
                        List<UsersDAL> usersDALList = new List<UsersDAL>();
                        List<TransactionsDAL> TransactionstDALList = new List<TransactionsDAL>();
                        List<TransactionDetailsDAL> transactionDetailsDALList = new List<TransactionDetailsDAL>();
                        TransactionsDAL transactionsDAL;
                        TransactionDetailsDAL transactionDetailsDAL;

                        usersDALList = usersDAL.Search(loginDAL);

                        if (usersDAL.ErrorCode == 0)
                        {
                            foreach (UsersDAL itemUser in usersDALList)
                            {

                                transactionsDAL = new TransactionsDAL();
                                transactionsDAL.UserName = itemUser.Name.ToString();
                                transactionsDAL.StartTime = Convert.ToDateTime(InputFecha.Value);
                                transactionsDAL.EndTime = Convert.ToDateTime(InputFecha.Value);
                                transactionsDAL.LotteryID = Convert.ToInt32(DropDownListLottery.SelectedItem.Value);

                                TransactionstDALList = transactionsDAL.Search(loginDAL);

                                if (transactionsDAL.ErrorCode == 0)
                                {
                                    foreach (TransactionsDAL item in TransactionstDALList)
                                    {

                                        transactionDetailsDAL = new TransactionDetailsDAL();
                                        transactionDetailsDAL.TransactionID = item.TransactionID;
                                        transactionDetailsDALList = transactionDetailsDAL.VerifyTicketPaid(false, loginDAL);

                                        if (transactionDetailsDAL.ErrorCode == 0)
                                        {
                                            if (transactionDetailsDALList.Count > 0)
                                            {

                                                gainNumbers.AppendLine("No. Ticket -->" + transactionDetailsDALList[0].TransactionID);
                                                gainCount++;


                                                listMail.Add(transactionDetailsDALList[0]);
                                            }

                                        }
                                        else
                                        {
                                            //mensaje de error
                                            // MessageBox.Show(transactionDetailsDAL.ErrorCode + ": " + transactionDetailsDAL.ErrorDescription);
                                        }


                                    }

                                }

                            }

                            sendMailGainNumber(listMail, TbFirstNumber.Text, TbSecondNumber.Text, TbThirdNumber.Text, DropDownListLottery.SelectedItem.Text);
                        }
                        if (gainCount == 0)
                            gainNumbers.AppendLine(gainCount.ToString());

                        ScriptManager.RegisterStartupScript(this, this.GetType(), null, "ConfirmacionOneButton('Número agregado con exito! Tickets Ganadores:" + gainCount.ToString() + "','NumerosGanadoresWF.aspx')", true);

                        usersDAL = null;
                        transactionDetailsDAL = null;
                        transactionsDAL = null;


                    }
                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            winNumbersDAL = null;


        }

        private void sendMailGainNumber(List<TransactionDetailsDAL> listMail, string primero, string segundo, string tercero, string loteria)
        {
            Ticket ticket = new Ticket();
            TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
            List<TransactionDetailsDAL> transactionDetailsDALList = new List<TransactionDetailsDAL>();

            if (listMail.Count > 0)
            {
                mail.AppendLine("<html>");

                mail.AppendLine("<table>");
                mail.AppendLine("<tr>");
                mail.AppendLine("<td colspan='3'>");
                mail.AppendLine(listMail[0].LotteryName.ToUpper());
                mail.AppendLine("</td>");
                mail.AppendLine("</tr>");

                mail.AppendLine("<tr>");

                mail.AppendLine("<td>");
                mail.AppendLine(primero);
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine(segundo);
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine(tercero);
                mail.AppendLine("</td>");

                mail.AppendLine("</tr>");

                mail.AppendLine("</table>");


                mail.AppendLine("<table>");
                mail.AppendLine("<tr>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b>PUNTO</b>");
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b># TICKET</b>");
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b>NUMERO</b>");
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b>MONTO</b>");
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b>PREMIO</b>");
                mail.AppendLine("</td>");
                mail.AppendLine("</tr>");

                foreach (TransactionDetailsDAL item in listMail)
                {
                    transactionDetailsDAL.TransactionID = item.TransactionID;
                    transactionDetailsDALList = transactionDetailsDAL.Search(loginDAL);

                    if (transactionDetailsDALList.Count > 0)
                    {
                        transactionDetailsDALList = transactionDetailsDALList.Where(u => u.GainAmount > 0).ToList();

                        if (transactionDetailsDALList.Count > 0)
                        {
                            foreach (TransactionDetailsDAL itemP in transactionDetailsDALList)
                            {
                                mail.AppendLine("<tr>");

                                mail.AppendLine("<td>");
                                mail.AppendLine(itemP.BranchName.ToString());
                                mail.AppendLine("</td>");

                                mail.AppendLine("<td>");
                                mail.AppendLine(itemP.TransactionID.ToString());
                                mail.AppendLine("</td>");

                                mail.AppendLine("<td>");
                                mail.AppendLine(itemP.Numbers);
                                mail.AppendLine("</td>");

                                mail.AppendLine("<td>");
                                mail.AppendLine(itemP.Amount.ToString("N2"));
                                mail.AppendLine("</td>");

                                mail.AppendLine("<td>");
                                mail.AppendLine(itemP.GainAmount.ToString("N2"));
                                mail.AppendLine("</td>");

                                mail.AppendLine("</tr>");
                            }

                        }


                    }



                }
                mail.AppendLine("</table>");




            }
            else
            {
                mail.AppendLine("<html>");

                mail.AppendLine("<table>");
                mail.AppendLine("<tr>");
                mail.AppendLine("<td colspan='3'>");
                mail.AppendLine(loteria);
                mail.AppendLine("</td>");
                mail.AppendLine("</tr>");

                mail.AppendLine("<tr>");

                mail.AppendLine("<td>");
                mail.AppendLine(primero);
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine(segundo);
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine(tercero);
                mail.AppendLine("</td>");

                mail.AppendLine("</tr>");

                mail.AppendLine("</table>");


                mail.AppendLine("<table>");
                mail.AppendLine("<tr>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b># TICKET</b>");
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b>NUMERO</b>");
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b>MONTO</b>");
                mail.AppendLine("</td>");

                mail.AppendLine("<td>");
                mail.AppendLine("<b>PREMIO</b>");
                mail.AppendLine("</td>");
                mail.AppendLine("</tr>");

                mail.AppendLine("<tr>");

                mail.AppendLine("<td colspan='4'>");
                mail.AppendLine("NO HUBO GANADORES");
                mail.AppendLine("</td>");

                mail.AppendLine("</tr>");
                mail.AppendLine("</table>");



            }
            mail.AppendLine("<br/>");
            mail.AppendLine("<br/>");


            mail.AppendLine("</html>");

           // ticket.SendMailReport(mail.ToString(), "Premios " + loteria + " (" + customersDALList[0].Name + ")");
        }


        protected void CargarDropDown()
        {
            LotteriesDAL lotteriesDAL = new LotteriesDAL();
            try
            {

                DropDownListLottery.DataSource = lotteriesDAL.Search(loginDAL);
                DropDownListLottery.DataValueField = "lotteryID";
                DropDownListLottery.DataTextField = "name";
                DropDownListLottery.DataBind();


            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }
            lotteriesDAL = null;

        }

        protected void CargarBseDatos()
        {
            LoginDAL loginDAL = new LoginDAL();
            List<LoginDAL> listLoginDAL = new List<LoginDAL>();


            GvBaseDatos.DataSource = null;

            try
            {
                listLoginDAL= loginDAL.Search();
                var hola = listLoginDAL.GroupBy(x => x.DataBaseName).
                   Select(g => new { DataBaseName = g.Key, Proceso = "" });
                GvBaseDatos.DataSource = hola.ToList();

                if (loginDAL.ErrorCode != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: Error: " + loginDAL.ErrorCode + " :: " + loginDAL.ErrorDescription + "','error');", true);

                }
                else
                {
                    GvBaseDatos.DataBind();
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "sweetalert", "swal('Error','Algo salio mal, mas detalles: " + ex.Message + "','error');", true);
            }

            loginDAL = null;
        }


        protected void CbItem_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox checkBox = (System.Web.UI.WebControls.CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;

        }
        protected void CbHeader_CheckedChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.CheckBox checkBoxHeader = (System.Web.UI.WebControls.CheckBox)GvBaseDatos.HeaderRow.FindControl("CbHeader");
            foreach (GridViewRow item in GvBaseDatos.Rows)
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