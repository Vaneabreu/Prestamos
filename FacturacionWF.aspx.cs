using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SoftLoans
{
    public partial class FacturacionWF : System.Web.UI.Page
    {
        int numeroRandom = 0, montoRandom = 0;
        string numeroTickets = "";
        LoginDAL loginDAL = new LoginDAL();
        BranchesDAL branchesDAL = new BranchesDAL();
        EmployeeDAL employeeDAL = new EmployeeDAL();
        CustomersDAL customersDAL = new CustomersDAL();
        List<CustomersDAL> customersDALList = new List<CustomersDAL>();

        protected void Page_Load(object sender, EventArgs e)
        {
            numeroTickets = "";
            TbNumero.Attributes.Add("OnKeyPress", "return disableEnterKey1(event)");
            TbMonto.Attributes.Add("OnKeyPress", "return disableEnterKey2(event)");
            Page.SetFocus(TbNumero);

            //BtnAgregar.Click += null;
            try
            {
                //TbMonto.Attributes.Add("OnKeyPress", "return disableEnterKey(event)");
                //var hola  = TbMonto.Attributes.Keys.GetEnumerator();

                //var button = sender.ToString();
                //string hh = button.ID;

                //TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
                //transactionDetailsDAL.EscribirError("Test de insert archivo");
            }
            catch (Exception)
            {

                //throw;
            }

            if (Session["DatosUsuario"] != null)
            {
                if (Session["Parametros"] == null)
                    Response.Redirect("SeleccionLoteria.aspx");
                else
                {
                    loginDAL = (LoginDAL)Session["DatosUsuario"];

                   
                    branchesDAL.UserName = loginDAL.UserName;
                    branchesDAL.GetByUserName(loginDAL);

                    
                   // employeeDAL.EmployeeID = loginDAL.EmployeeID;
                    employeeDAL.GetByKey(loginDAL);
                   // customersDALList = customersDAL.Search(loginDAL);

                    //if (!loginDAL.UsedFree)
                    //{
                    //    LbSubTotal.Style.Add("display", "none");
                    //    LbFree.Style.Add("display", "none");
                    //}


                    CargarInicio();

                    if (Session["ListaDetalle"] != null)
                    {
                        cargarGridCopiado();
                        ValidarTicket();
                    }

                }


            }
            else
            {
                Response.Redirect("InicioWF.aspx");
            }

        }

        protected void BtnCerrarSeccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioWF.aspx");

        }
        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuWF.aspx");

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
        protected void BtnCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteWF.aspx");

        }
        protected void BtnSeleccionLoteria_Click(object sender, EventArgs e)
        {

            try
            {
                Button button = (Button)sender;
                Response.Redirect("SeleccionLoteriaWF.aspx");

            }
            catch (Exception)
            {

            }



        }
        protected void BtnNumerosGanadores_Click(object sender, EventArgs e)
        {
            Response.Redirect("NumerosGanadoresWF.aspx");

        }

        protected void BtnCuadre_Click(object sender, EventArgs e)
        {
            Session["DatosUsuario"] = loginDAL;
            Response.Redirect("CuadreWF.aspx");
        }

        protected void BtnCombinar_Click(object sender, EventArgs e)
        {
            RFVNumero.ErrorMessage = "";
            REVNumero.ErrorMessage = "";
            int monto = 0;
            int.TryParse(TbMonto.Text, out monto);
            if (RFVMonto.IsValid && REVMonto.IsValid && validateTexboxData() && monto > 0)
            {

                if (int.Parse(TbMonto.Text) > 0)
                {
                    int cont = 0;
                    int countInsert = 0;
                    String numbers = "";
                    List<String> quinielas = new List<String>();
                    foreach (GridViewRow item in GvTicket.Rows)
                    {
                        if (item.Cells[0].Text == "Qn")
                        {

                            quinielas.Add(item.Cells[1].Text);
                            cont++;
                        }
                    }


                    for (int i = 0; i < quinielas.Count; i++)
                    {
                        for (int o = i + 1; o < quinielas.Count; o++)
                        {
                            if (ValidateIfNumberExist(quinielas[i] + quinielas[o]) == false)
                            {
                                numbers = orderNumbers(quinielas[i] + quinielas[o]);

                                DataTable dataTable = new DataTable();
                                dataTable.Columns.Add("Tipo");
                                dataTable.Columns.Add("Numeros");
                                dataTable.Columns.Add("Monto");
                                foreach (GridViewRow item in GvTicket.Rows)
                                {
                                    dataTable.Rows.Add(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
                                }

                                dataTable.Rows.Add("Pl", numbers.Substring(0, 2) + "-" + numbers.Substring(2, 2), TbMonto.Text);
                                GvTicket.DataSource = dataTable;
                                GvTicket.DataBind();

                                countInsert++;
                            }
                        }
                    }
                    if (countInsert > 0)
                    {
                        calcularTotal();
                    }
                    TbMonto.Text = "";
                    TbNumero.Text = "";

                }
            }
        }
        protected void BtnJugar_Click(object sender, EventArgs e)
        {
            try
            {
                //Button button = (Button)sender;

                if (GvTicket.Rows.Count > 0)
                {
                    string respuesta = ValidarTicket();
                    if (respuesta == "")
                    {
                        List<LotteriesDAL> lotteryDalList = new List<LotteriesDAL>();
                        TransactionsDAL transactionsDAL = new TransactionsDAL();
                       

                       // employeeDAL.EmployeeID = loginDAL.EmployeeID;
                       

                        TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
                        

                        LotteriesDAL lotteriesDAL = new LotteriesDAL();
                       

                        StringBuilder sbError = new StringBuilder();

                        transactionsDAL.Amount = getTotalAmountLottery();

                        //if (loginDAL.UsedFree)
                        //{
                        //    transactionsDAL.Discount = Convert.ToDecimal(Math.Truncate(transactionsDAL.Amount / 11));
                        //}
                        //else
                        //{
                        //    transactionsDAL.Discount = 0;
                        //}
 
                        transactionsDAL.UserName = loginDAL.UserName;
                        transactionsDAL.CustomerID = 0;
                        StringBuilder loterryClosingRespuesta = new StringBuilder();

                        if (Cb44.Checked) { lotteriesDAL.LotteryID = 44; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb44.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb1.Checked) { lotteriesDAL.LotteryID = 1; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb1.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb12.Checked) { lotteriesDAL.LotteryID = 12; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb12.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb15.Checked) { lotteriesDAL.LotteryID = 15; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb15.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb32.Checked) { lotteriesDAL.LotteryID = 32; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb32.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb33.Checked) { lotteriesDAL.LotteryID = 33; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb33.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb37.Checked) { lotteriesDAL.LotteryID = 37; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb37.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb38.Checked) { lotteriesDAL.LotteryID = 38; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb38.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb39.Checked) { lotteriesDAL.LotteryID = 39; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb39.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb4.Checked) { lotteriesDAL.LotteryID = 4; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb4.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb40.Checked) { lotteriesDAL.LotteryID = 40; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb40.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb41.Checked) { lotteriesDAL.LotteryID = 41; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb41.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb42.Checked) { lotteriesDAL.LotteryID = 42; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb42.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb43.Checked) { lotteriesDAL.LotteryID = 43; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb43.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb45.Checked) { lotteriesDAL.LotteryID = 45; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb45.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb46.Checked) { lotteriesDAL.LotteryID = 46; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb46.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb47.Checked) { lotteriesDAL.LotteryID = 47; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb47.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb48.Checked) { lotteriesDAL.LotteryID = 48; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb48.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb49.Checked) { lotteriesDAL.LotteryID = 49; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb49.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }
                        if (Cb5.Checked) { lotteriesDAL.LotteryID = 5; lotteriesDAL.GetByKey(loginDAL); loterryClosingRespuesta.Append(LotteryCLose(Cb5.Text, lotteriesDAL.ClosingTime, lotteriesDAL.SundayClosingTime) + "\\n\\n"); }


                        if (loterryClosingRespuesta.Length <= 20)
                        {
                            lotteriesDAL = null;
                            lotteriesDAL = new LotteriesDAL();
                            if (Cb44.Checked) { lotteriesDAL.LotteryID = 44; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb44.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb1.Checked) { lotteriesDAL.LotteryID = 1; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb1.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb12.Checked) { lotteriesDAL.LotteryID = 12; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb12.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb15.Checked) { lotteriesDAL.LotteryID = 15; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb15.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb32.Checked) { lotteriesDAL.LotteryID = 32; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb32.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb33.Checked) { lotteriesDAL.LotteryID = 33; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb33.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb37.Checked) { lotteriesDAL.LotteryID = 37; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb37.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb38.Checked) { lotteriesDAL.LotteryID = 38; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb38.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb39.Checked) { lotteriesDAL.LotteryID = 39; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb39.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb4.Checked) { lotteriesDAL.LotteryID = 4; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb4.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb40.Checked) { lotteriesDAL.LotteryID = 40; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb40.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb41.Checked) { lotteriesDAL.LotteryID = 41; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb41.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb42.Checked) { lotteriesDAL.LotteryID = 42; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb42.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb43.Checked) { lotteriesDAL.LotteryID = 43; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb43.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb45.Checked) { lotteriesDAL.LotteryID = 45; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb45.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb46.Checked) { lotteriesDAL.LotteryID = 46; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb46.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb47.Checked) { lotteriesDAL.LotteryID = 47; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb47.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb48.Checked) { lotteriesDAL.LotteryID = 48; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb48.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb49.Checked) { lotteriesDAL.LotteryID = 49; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb49.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }
                            if (Cb5.Checked) { lotteriesDAL.LotteryID = 5; lotteryDalList = lotteriesDAL.Search(loginDAL); transactionsDAL.ShiftName = lotteryDalList[0].ShiftName; transactionsDAL.LotteryName = Cb5.Text; sbError.Append(transactionsDAL.Insert(loginDAL) ? InsertDetails(transactionsDAL.TransactionID, transactionsDAL.LotteryName, transactionsDAL.ShiftName) + "\\n\\n" : transactionsDAL.ErrorDescription + "\\n\\n"); }

                            ImprimirTPV();
                            if (sbError.Length > 20)
                            {
                                Notificaion("Ticket procesado con errores!", "Detalles del error:" + sbError.ToString(), "warning");
                            }
                        }
                        else
                        {
                            Notificaion("Ticket no procesado!", "Loteria(s) cerrada(S):" + "\\n\\n" + loterryClosingRespuesta.ToString(), "warning");
                        }

                    }
                    else
                    {
                        Notificaion("Ticket no procesado!", respuesta, "warning");
                    }
                }

                Page.SetFocus(TbNumero);
            }
            catch (Exception ex)
            {
                Notificaion("Ticket no procesado!", "ex: " + ex.Message, "warning");
                LimpiarTodo();
                Page.SetFocus(TbNumero);
            }



        }

        protected void BtnAutoQN_Click(object sender, EventArgs e)
        {
            RFVNumero.ErrorMessage = "";
            if (!Cb32.Checked && !Cb5.Checked)
            {
                int monto = 0;
                int.TryParse(TbMonto.Text, out monto);
                if (RFVMonto.IsValid && REVMonto.IsValid && monto > 0)
                {
                    getNumberRamdon(1);
                }
            }
        }
        protected void BtnAutoPL_Click(object sender, EventArgs e)
        {
            RFVNumero.ErrorMessage = "";
            int monto = 0;
            int.TryParse(TbMonto.Text, out monto);
            if (RFVMonto.IsValid && REVMonto.IsValid && monto > 0)
            {
                getNumberRamdon(2);
            }
        }
        protected void BtnAutoTP_Click(object sender, EventArgs e)
        {
            RFVNumero.ErrorMessage = "";
            if (!Cb32.Checked && !Cb5.Checked)
            {
                int monto = 0;
                int.TryParse(TbMonto.Text, out monto);
                if (RFVMonto.IsValid && REVMonto.IsValid && monto > 0)
                {
                    getNumberRamdon(3);
                }

            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

            TicketImprimir.InnerHtml = "";
            TicketImprimirC.Style.Add("display", "none");

            RFVNumero.ErrorMessage = "Campo obligatorio";
            REVNumero.ErrorMessage = "Solo números";
            string tipo = "";
            int monto = 0;
            int.TryParse(TbMonto.Text, out monto);

            if (RFVMonto.IsValid && RFVNumero.IsValid && REVMonto.IsValid && REVNumero.IsValid && validateTexboxData() && monto > 0)
            {
                if (validateAvailableLimits())
                {
                    if (TbNumero.Text.Length != 4)
                    {
                        if (!Cb32.Checked && !Cb5.Checked)
                        {
                            switch (TbNumero.Text.Length)
                            {
                                case 2:
                                    tipo = "Qn";
                                    break;
                                case 4:
                                    tipo = "Pl";
                                    break;
                                case 6:
                                    tipo = "Tp";
                                    break;
                            }
                            DataTable dataTable = new DataTable();
                            if (GvTicket.Rows.Count > 0)
                            {

                                dataTable.Columns.Add("Tipo");
                                dataTable.Columns.Add("Numeros");
                                dataTable.Columns.Add("Monto");
                                foreach (GridViewRow item in GvTicket.Rows)
                                {
                                    dataTable.Rows.Add(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
                                }

                                dataTable.Rows.Add(tipo, SeparadorNumero(TbNumero.Text), TbMonto.Text);


                            }
                            else
                            {

                                dataTable.Columns.Add("Tipo");
                                dataTable.Columns.Add("Numeros");
                                dataTable.Columns.Add("Monto");
                                dataTable.Rows.Add(tipo, SeparadorNumero(TbNumero.Text), TbMonto.Text);
                            }

                            GvTicket.DataSource = dataTable;
                            GvTicket.DataBind();
                            calcularTotal();
                            TbNumero.Text = "";
                            TbMonto.Text = "";

                        }
                        else
                        {
                            Notificaion("Error!", "No solo se permiten Pale para la loteria Super Pale", "error");
                        }
                    }
                    else
                    {
                        switch (TbNumero.Text.Length)
                        {
                            case 2:
                                tipo = "Qn";
                                break;
                            case 4:
                                tipo = "Pl";
                                break;
                            case 6:
                                tipo = "Tp";
                                break;
                        }
                        DataTable dataTable = new DataTable();
                        if (GvTicket.Rows.Count > 0)
                        {

                            dataTable.Columns.Add("Tipo");
                            dataTable.Columns.Add("Numeros");
                            dataTable.Columns.Add("Monto");
                            foreach (GridViewRow item in GvTicket.Rows)
                            {
                                dataTable.Rows.Add(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
                            }

                            dataTable.Rows.Add(tipo, SeparadorNumero(TbNumero.Text), TbMonto.Text);


                        }
                        else
                        {

                            dataTable.Columns.Add("Tipo");
                            dataTable.Columns.Add("Numeros");
                            dataTable.Columns.Add("Monto");
                            dataTable.Rows.Add(tipo, SeparadorNumero(TbNumero.Text), TbMonto.Text);
                        }

                        GvTicket.DataSource = dataTable;
                        GvTicket.DataBind();
                        calcularTotal();
                        TbNumero.Text = "";
                        TbMonto.Text = "";
                    }

                    Page.SetFocus(TbNumero);


                }

            }


        }
        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            GvTicket.DataSource = null;
            GvTicket.DataBind();
            LbTotal.Text = "Total: $0";

        }


        protected void GvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void LimpiarTodo()
        {
            TbMonto.Text = "";
            TbNumero.Text = "";
            LbTotal.Text = "Total: $0";
            LbFree.Text = "F: $0";
            LbSubTotal.Text = "S: $0";
            GvTicket.DataSource = null;
            GvTicket.DataBind();

            if (Cb44.Enabled) { Cb44.Enabled = false; }
            if (Cb1.Enabled) { Cb1.Checked = false; }
            if (Cb12.Enabled) { Cb12.Checked = false; }
            if (Cb15.Enabled) { Cb15.Checked = false; }
            if (Cb32.Enabled) { Cb32.Checked = false; }
            if (Cb33.Enabled) { Cb33.Checked = false; }
            if (Cb37.Enabled) { Cb37.Checked = false; }
            if (Cb38.Enabled) { Cb38.Checked = false; }
            if (Cb39.Enabled) { Cb39.Checked = false; }
            if (Cb4.Enabled) { Cb4.Checked = false; }
            if (Cb40.Enabled) { Cb40.Checked = false; }
            if (Cb41.Enabled) { Cb41.Checked = false; }
            if (Cb42.Enabled) { Cb42.Checked = false; }
            if (Cb43.Enabled) { Cb43.Checked = false; }
            if (Cb45.Enabled) { Cb45.Checked = false; }
            if (Cb46.Enabled) { Cb46.Checked = false; }
            if (Cb47.Enabled) { Cb47.Checked = false; }
            if (Cb48.Enabled) { Cb48.Checked = false; }
            if (Cb49.Enabled) { Cb49.Checked = false; }
            if (Cb5.Enabled) { Cb5.Checked = false; }

            Color color = ColorTranslator.FromHtml("#0000");
            BtnSLM.BackColor = color;

        }

        protected string InsertDetails(long TransationID, string LotteryName, string ShiftName)
        {
            if (numeroTickets.Length == 0) { numeroTickets = TransationID.ToString(); }
            else { numeroTickets += ", " + TransationID.ToString(); }

            TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
            TransactionsDAL transactionsDAL = new TransactionsDAL();
            string result = "";
            try
            {

                foreach (GridViewRow item in GvTicket.Rows)
                {
                    transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.TransactionID = TransationID;
                    transactionDetailsDAL.LotteryName = LotteryName;
                    transactionDetailsDAL.ShiftName = ShiftName;
                    transactionDetailsDAL.Numbers = item.Cells[1].Text.Replace("-", "");
                    switch (item.Cells[0].Text)
                    {
                        case "Qn":
                            transactionDetailsDAL.PlayTypeName = "Quiniela";
                            break;
                        case "Pl":
                            transactionDetailsDAL.PlayTypeName = "Pale";
                            break;
                        case "Tp":
                            transactionDetailsDAL.PlayTypeName = "Tripleta";
                            break;
                    }
                    transactionDetailsDAL.Amount = int.Parse(item.Cells[2].Text);


                    result = transactionDetailsDAL.Insert(loginDAL) ? "" : transactionDetailsDAL.ErrorDescription;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;

                transactionsDAL.TransactionID = TransationID;
                transactionDetailsDAL.TransactionID = TransationID;
                transactionsDAL.Delete(loginDAL);
                transactionDetailsDAL.Delete(loginDAL);


                if (Cb1.Text == LotteryName) { Cb1.Checked = false; }
                if (Cb4.Text == LotteryName) { Cb4.Checked = false; }
                if (Cb5.Text == LotteryName) { Cb5.Checked = false; }
                if (Cb12.Text == LotteryName) { Cb12.Checked = false; }
                if (Cb15.Text == LotteryName) { Cb15.Checked = false; }
                if (Cb32.Text == LotteryName) { Cb32.Checked = false; }
                if (Cb33.Text == LotteryName) { Cb33.Checked = false; }
                if (Cb37.Text == LotteryName) { Cb37.Checked = false; }
                if (Cb38.Text == LotteryName) { Cb38.Checked = false; }
                if (Cb39.Text == LotteryName) { Cb39.Checked = false; }
                if (Cb40.Text == LotteryName) { Cb40.Checked = false; }
                if (Cb41.Text == LotteryName) { Cb41.Checked = false; }
                if (Cb42.Text == LotteryName) { Cb42.Checked = false; }
                if (Cb43.Text == LotteryName) { Cb43.Checked = false; }
                if (Cb44.Text == LotteryName) { Cb44.Checked = false; }
                if (Cb45.Text == LotteryName) { Cb45.Checked = false; }
                if (Cb46.Text == LotteryName) { Cb46.Checked = false; }
                if (Cb47.Text == LotteryName) { Cb47.Checked = false; }
                if (Cb48.Text == LotteryName) { Cb48.Checked = false; }
                if (Cb49.Text == LotteryName) { Cb49.Checked = false; }

            }

            return result;


        }
        protected void ImprimirTPV()
        {
            TicketImprimirC.Style.Add("display", "block");
            PintarTicket();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "printTest();", true);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "BtPrint(document.getElementById('TicketImprimir').innerText)", true)
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "BtPrint('" + PintarTicket1() + "')", true);

            // TicketImprimirC.Style.Add("display", "none");
            Thread.Sleep(2000);


            LimpiarTodo();


        }
        public string PintarTicket1()
        {
            string nombreBanca = branchesDAL.Name;
            string esloganBanca = "Pagamos al instante!";
            string telefonoBanca = branchesDAL.Phone;
            string VendedorBanca = employeeDAL.Name;
            string numeroTicket = "02505633";
            string FechaBanca = DateTime.Now.ToShortDateString();
            List<string> listLoterias = new List<string>();

            string ticketC = "<pre class=`ticketImpri`>";

            ticketC += "\\n" + "--------------------------------";
            ticketC += "\\n" + branchesDAL.Name.PadLeft(branchesDAL.Name.Length < 32 ? (32 - branchesDAL.Name.Length) / 2 : 0, ' ');
            ticketC += "\\n" + esloganBanca.PadLeft(esloganBanca.Length < 32 ? (32 - esloganBanca.Length) / 2 : 0, ' ');
            ticketC += "\\n" + "--------------------------------";
            ticketC += "\\n ";
            ticketC += "\\n" + ("Telefono: " + numeroTicket).PadRight(numeroTicket.Length < 32 ? (32 - numeroTicket.Length) : 0, ' ');
            ticketC += "\\n" + ("Vendedor: " + employeeDAL.Name).PadRight(employeeDAL.Name.Length < 32 ? (32 - employeeDAL.Name.Length) : 0, ' ');
            ticketC += "\\n" + ("Fecha: " + FechaBanca).PadRight(FechaBanca.Length < 32 ? (32 - FechaBanca.Length) : 0, ' ');
            ticketC += "\\n ";
            ticketC += "\\n" + ("Num. Ticket: " + numeroTicket).PadLeft(("Num. Ticket: " + numeroTicket).Length < 32 ? (32 - ("Num. Ticket: " + numeroTicket).Length) / 2 : 0, ' ');
            ticketC += "\\n" + "            Jugadas";
            ticketC += "\\n ";

            if (Cb44.Checked) { ticketC += "\\n" + "AM  " + Cb44.Text; listLoterias.Add("AM"); }
            if (Cb1.Checked) { ticketC += "\\n" + "NA  " + Cb1.Text; listLoterias.Add("NA"); }
            if (Cb12.Checked) { ticketC += "\\n" + "LO  " + Cb12.Text; listLoterias.Add("LO"); }
            if (Cb15.Checked) { ticketC += "\\n" + "GA  " + Cb15.Text; listLoterias.Add("GA"); }
            if (Cb32.Checked) { ticketC += "\\n" + "SRG " + Cb32.Text; listLoterias.Add("SRG"); }
            if (Cb33.Checked) { ticketC += "\\n" + "RE  " + Cb33.Text; listLoterias.Add("RE"); }
            if (Cb37.Checked) { ticketC += "\\n" + "NYT " + Cb37.Text; listLoterias.Add("NYT"); }
            if (Cb38.Checked) { ticketC += "\\n" + "NYN " + Cb38.Text; listLoterias.Add("NYN"); }
            if (Cb39.Checked) { ticketC += "\\n" + "FD  " + Cb39.Text; listLoterias.Add("FD"); }
            if (Cb4.Checked) { ticketC += "\\n" + "LE  " + Cb4.Text; listLoterias.Add("LE"); }
            if (Cb40.Checked) { ticketC += "\\n" + "FN  " + Cb40.Text; listLoterias.Add("FN"); }
            if (Cb41.Checked) { ticketC += "\\n" + "LP  " + Cb41.Text; listLoterias.Add("LP"); }
            if (Cb42.Checked) { ticketC += "\\n" + "LS  " + Cb42.Text; listLoterias.Add("LS"); }
            if (Cb43.Checked) { ticketC += "\\n" + "LD  " + Cb43.Text; listLoterias.Add("LD"); }
            if (Cb45.Checked) { ticketC += "\\n" + "AMD " + Cb45.Text; listLoterias.Add("AMD"); }
            if (Cb46.Checked) { ticketC += "\\n" + "AT  " + Cb46.Text; listLoterias.Add("AT"); }
            if (Cb47.Checked) { ticketC += "\\n" + "AN  " + Cb47.Text; listLoterias.Add("AN"); }
            if (Cb48.Checked) { ticketC += "\\n" + "KGT " + Cb48.Text; listLoterias.Add("KGT"); }
            if (Cb49.Checked) { ticketC += "\\n" + "KGN " + Cb49.Text; listLoterias.Add("KGN"); }
            if (Cb5.Checked) { ticketC += "\\n" + "SNL " + Cb5.Text; listLoterias.Add("SNL"); }
            ticketC += "\\n ";

            ticketC += "\\n" + "TP Numeros  " + "Loterias  " + "     Valor";
            ticketC += "\\n" + "--------------------------------";
            for (int i = 0; i < listLoterias.Count; i++)
            {
                foreach (GridViewRow item in GvTicket.Rows)
                {
                    ticketC += "\\n\\n" + (item.Cells[0].Text + " " + item.Cells[1].Text).PadRight(12 - (item.Cells[0].Text + " " + item.Cells[1].Text).Length, ' ') + listLoterias[i].PadRight(10 - listLoterias[i].Length, ' ') + item.Cells[1].Text.PadLeft(10 - item.Cells[1].Text.Length, ' ');

                }

            }
            ticketC += "\\n ";
            ticketC += "\\n" + "********************************";

            int total = int.Parse(LbTotal.Text.Substring(8, LbTotal.Text.Length - 8));
            total = total * listLoterias.Count;
            ticketC += "\\n" + "Total:" + (total).ToString().PadLeft(total.ToString().Length < 27 ? 26 - total.ToString().Length : 0, ' ');
            ticketC += "\\n" + "--------------------------------";
            ticketC += "\\n" + "--------------------------------";

            ticketC += "\\n\\n ";

            ticketC += "\\n" + "          Buena Suerte";
            ticketC += "\\n" + "       Revisar su ticket";
            ticketC += "\\n" + "     No pagamos sin ticket";
            ticketC += "\\n </pre>";
            return ticketC;

        }


        public void PintarTicket()
        {

            if (Cb1.Checked || Cb4.Checked || Cb5.Checked || Cb12.Checked || Cb15.Checked || Cb32.Checked || Cb33.Checked ||
                Cb37.Checked || Cb38.Checked || Cb39.Checked || Cb40.Checked || Cb41.Checked || Cb42.Checked || Cb43.Checked ||
                Cb44.Checked || Cb45.Checked || Cb46.Checked || Cb47.Checked || Cb48.Checked || Cb49.Checked)
            { }

            //string nombreBanca = customersDALList[0].PartnerShip;
            string esloganBanca = "Pagamos al instante!";
            string telefonoBanca = branchesDAL.Phone;
            string VendedorBanca = employeeDAL.Name;
            string numeroTicket = numeroTickets;
            string detalleTicket = "";
            int contadorLoterias = 1;
            string FechaBanca = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
          //  TicketImprimir.InnerHtml = "<h1 class='aling-T-C'>" + nombreBanca + "</h1>";
            TicketImprimir.InnerHtml += "<div class='aling-T-C' >" + esloganBanca + "</div><br/>";
            TicketImprimir.InnerHtml += "<div class='aling-T-L'><b><a>Telefono:&nbsp</a></b><a>" + telefonoBanca + "</a></div>";
            TicketImprimir.InnerHtml += "<div class='aling-T-L'><b><a>Vendedor:&nbsp</a></b><a>" + VendedorBanca + "</a></div>";
            TicketImprimir.InnerHtml += "<div class='aling-T-L'><b><a>Fecha:&nbsp</a></b><a>" + FechaBanca + "</a></div><br/>";

            TicketImprimir.InnerHtml += "<h5 class='aling-T-C negrita-T' >Num. Ticket: " + numeroTicket + "</h5>";
            TicketImprimir.InnerHtml += "<h6 class='aling-T-C'>Jugadas</h6>";

            if (Cb44.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>AM  </a><a>" + Cb44.Text + "</a></div>"; }
            if (Cb1.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>NA  </a><a>" + Cb1.Text + "</a></div>"; }
            if (Cb12.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>LO  </a><a>" + Cb12.Text + "</a></div>"; }
            if (Cb15.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>GA  </a><a>" + Cb15.Text + "</a></div>"; }
            if (Cb32.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>SRG </a><a>" + Cb32.Text + "</a></div>"; }
            if (Cb33.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>RE  </a><a>" + Cb33.Text + "</a></div>"; }
            if (Cb37.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>NYT </a><a>" + Cb37.Text + "</a></div>"; }
            if (Cb38.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>NYN </a><a>" + Cb38.Text + "</a></div>"; }
            if (Cb39.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>FD  </a><a>" + Cb39.Text + "</a></div>"; }
            if (Cb4.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>LE  </a><a>" + Cb4.Text + "</a></div>"; }
            if (Cb40.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>FN  </a><a>" + Cb40.Text + "</a></div>"; }
            if (Cb41.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>LP  </a><a>" + Cb41.Text + "</a></div>"; }
            if (Cb42.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>LS  </a><a>" + Cb42.Text + "</a></div>"; }
            if (Cb43.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>LD  </a><a>" + Cb43.Text + "</a></div>"; }
            if (Cb45.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>AMD </a><a>" + Cb45.Text + "</a></div>"; }
            if (Cb46.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>AT  </a><a>" + Cb46.Text + "</a></div>"; }
            if (Cb47.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>AN  </a><a>" + Cb47.Text + "</a></div>"; }
            if (Cb48.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>KGT </a><a>" + Cb48.Text + "</a></div>"; }
            if (Cb49.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>KGN </a><a>" + Cb49.Text + "</a></div>"; }
            if (Cb5.Checked) { TicketImprimir.InnerHtml += "<div class='aling-T-L'><a>SNL </a><a>" + Cb5.Text + "</a></div>"; }


            TicketImprimir.InnerHtml += "<br/><div class='row' >";
            TicketImprimir.InnerHtml += "<div class='col-7'><div class='row justify-content-start negrita-T fs-5' >TP Num.</div></div>";
            TicketImprimir.InnerHtml += "<div class='col-2'><div class='row justify-content-start negrita-T fs-5' >Lot.</div></div>";
            TicketImprimir.InnerHtml += "<div class='col-3' ><div class='row justify-content-end negrita-T fs-5' >Valor</div></div>";
            TicketImprimir.InnerHtml += "<hr class='lineaPuntos-T' />";
            TicketImprimir.InnerHtml += "</div>";


            if (Cb44.Checked) { detalleTicket += PintarTicketDetalle("AM", Cb44.Text); contadorLoterias++; }
            if (Cb1.Checked) { detalleTicket += PintarTicketDetalle("NA", Cb1.Text); contadorLoterias++; }
            if (Cb12.Checked) { detalleTicket += PintarTicketDetalle("LO", Cb12.Text); contadorLoterias++; }
            if (Cb15.Checked) { detalleTicket += PintarTicketDetalle("GA", Cb15.Text); contadorLoterias++; }
            if (Cb32.Checked) { detalleTicket += PintarTicketDetalle("SRG", Cb32.Text); contadorLoterias++; }
            if (Cb33.Checked) { detalleTicket += PintarTicketDetalle("RE", Cb33.Text); contadorLoterias++; }
            if (Cb37.Checked) { detalleTicket += PintarTicketDetalle("NYT", Cb37.Text); contadorLoterias++; }
            if (Cb38.Checked) { detalleTicket += PintarTicketDetalle("NYN", Cb38.Text); contadorLoterias++; }
            if (Cb39.Checked) { detalleTicket += PintarTicketDetalle("FD", Cb39.Text); contadorLoterias++; }
            if (Cb4.Checked) { detalleTicket += PintarTicketDetalle("LE", Cb4.Text); contadorLoterias++; }
            if (Cb40.Checked) { detalleTicket += PintarTicketDetalle("FN", Cb40.Text); contadorLoterias++; }
            if (Cb41.Checked) { detalleTicket += PintarTicketDetalle("LP", Cb41.Text); contadorLoterias++; }
            if (Cb42.Checked) { detalleTicket += PintarTicketDetalle("LS", Cb42.Text); contadorLoterias++; }
            if (Cb43.Checked) { detalleTicket += PintarTicketDetalle("LD", Cb43.Text); contadorLoterias++; }
            if (Cb45.Checked) { detalleTicket += PintarTicketDetalle("AMD", Cb45.Text); contadorLoterias++; }
            if (Cb46.Checked) { detalleTicket += PintarTicketDetalle("AT", Cb46.Text); contadorLoterias++; }
            if (Cb47.Checked) { detalleTicket += PintarTicketDetalle("AN", Cb47.Text); contadorLoterias++; }
            if (Cb48.Checked) { detalleTicket += PintarTicketDetalle("KGT", Cb48.Text); contadorLoterias++; }
            if (Cb49.Checked) { detalleTicket += PintarTicketDetalle("KGN", Cb49.Text); contadorLoterias++; }
            if (Cb5.Checked) { detalleTicket += PintarTicketDetalle("SNL", Cb5.Text); contadorLoterias++; }


            TicketImprimir.InnerHtml += detalleTicket;

            TicketImprimir.InnerHtml += "<h1></h1>";
            TicketImprimir.InnerHtml += "<h1></h1>";
            TicketImprimir.InnerHtml += "<div class='row' ><hr class='lineaPuntos-T' /></div>";
            TicketImprimir.InnerHtml += "<div class='row'>";

            //if (loginDAL.UsedFree)
            //{
            //    TicketImprimir.InnerHtml += "<div class='col-6 negrita-T fs-5' ><div class='row justify-content-start' >SubTotal:</div></div>";
            //    int subtotal = int.Parse(LbSubTotal.Text.Substring(4, LbSubTotal.Text.Length - 4));
            //    TicketImprimir.InnerHtml += "<div class='col-6 negrita-T'><div class='row justify-content-end fs-5' >$" + subtotal * (contadorLoterias - 1) + "</div></div>";

                
            //    TicketImprimir.InnerHtml += "<div class='col-6 negrita-T fs-5' ><div class='row justify-content-start' >Free:</div></div>";
            //    int free = int.Parse(LbFree.Text.Substring(4, LbFree.Text.Length - 4));
            //    TicketImprimir.InnerHtml += "<div class='col-6 negrita-T'><div class='row justify-content-end fs-5' >$" + free * (contadorLoterias - 1) + "</div></div>";
            //}

            TicketImprimir.InnerHtml += "<div class='col-6 negrita-T fs-5' ><div class='row justify-content-start' >Total:</div></div>";
            int total = int.Parse(LbTotal.Text.Substring(8, LbTotal.Text.Length - 8));
            TicketImprimir.InnerHtml += "<div class='col-6 negrita-T'><div class='row justify-content-end fs-5' >$" + total * (contadorLoterias - 1) + "</div></div>";
            TicketImprimir.InnerHtml += "<hr class='lineaPuntos-T' />";
            TicketImprimir.InnerHtml += "<hr class='lineaPuntos-T' /><br/>";
            TicketImprimir.InnerHtml += "</div><br/><br/>";
            TicketImprimir.InnerHtml += "<br/><div class='aling-T-C'><a>Buena Suerte</a></div>";
            TicketImprimir.InnerHtml += "<div class='aling-T-C'><a>Revisar su ticket</a></div>";
            TicketImprimir.InnerHtml += "<div class='aling-T-C'><a>No pagamos sin ticket</a></div>";
            //TicketImprimir.InnerHtml += "<div id='DivQRCode'><img runat='server' src ='' id='imgQRCode'/></div>";


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
        public string PintarTicketDetalle(string loteriaIniciales, string loteria)
        {
            string respues = "";

            string detallesTicket = "";
            foreach (GridViewRow item in GvTicket.Rows)
            {
                if (item.Cells[0].Text == "Qn")
                {
                    
                    detallesTicket += "<div class='row'>";
                    detallesTicket += "<div class='col-7'><div class='row justify-content-start negrita-T fs-5'>" + item.Cells[0].Text + "  " + item.Cells[1].Text + "</div></div>";
                    detallesTicket += "<div class='col-2'><div class='row justify-content-start negrita-T fs-5'>" + loteriaIniciales + "</div></div>";
                    detallesTicket += "<div class='col-3'><div class='row justify-content-end negrita-T fs-5'>$" + item.Cells[2].Text + "</div></div>";
                    detallesTicket += "</div>";
                }

            }
            foreach (GridViewRow item in GvTicket.Rows)
            {
                if (item.Cells[0].Text == "Pl")
                {
                    detallesTicket += "<div class='row'>";
                    detallesTicket += "<div class='col-7'><div class='row justify-content-start negrita-T fs-5' >" + item.Cells[0].Text + "  " + item.Cells[1].Text + "</div></div>";
                    detallesTicket += "<div class='col-2'><div class='row justify-content-start negrita-T fs-5' >" + loteriaIniciales + "</div></div>";
                    detallesTicket += "<div class='col-3'><div class='row justify-content-end negrita-T fs-5'>$" + item.Cells[2].Text + "</div></div>";
                    detallesTicket += "</div>";
                }


            }
            foreach (GridViewRow item in GvTicket.Rows)
            {
                if (item.Cells[0].Text == "Tp")
                {
                    detallesTicket += "<div class='row'>";
                    detallesTicket += "<div class='col-7'><div class='row justify-content-start negrita-T fs-5' >" + item.Cells[0].Text + "  " + item.Cells[1].Text + "</div></div>";
                    detallesTicket += "<div class='col-2'><div class='row justify-content-start negrita-T fs-5' >" + loteriaIniciales + "</div></div>";
                    detallesTicket += "<div class='col-3'><div class='row justify-content-end negrita-T fs-5'>$" + item.Cells[2].Text + "</div></div>";
                    detallesTicket += "</div>";
                }


            }

            respues += detallesTicket;

            return respues;
        }
        public string ValidarTicket()
        {
            string respuesta = "No se puede completar el ticket, las siguientes jugadas ya no estan disponible: ";

            int contador = 1;

            foreach (GridViewRow item in GvTicket.Rows)
            {
                if (Cb1.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {
                        respuesta += "\\n\\n En " + Cb1.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1");

                        contador++;
                    }
                }
                if (Cb4.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "4"))
                    {

                        respuesta += "\\n\\n En " + Cb4.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "4");

                        contador++;
                    }
                }
                if (Cb5.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb5.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "5");
                        contador++;
                    }
                }
                if (Cb12.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb12.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "12");
                        contador++;
                    }
                }
                if (Cb15.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb15.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "15");
                        contador++;
                    }
                }
                if (Cb32.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb32.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "32");
                        contador++;
                    }
                }
                if (Cb33.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb33.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "33");
                        contador++;
                    }
                }
                if (Cb37.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb37.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "37");
                        contador++;
                    }
                }
                if (Cb38.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb38.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "38");
                        contador++;
                    }
                }
                if (Cb39.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb39.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "39");
                        contador++;
                    }
                }
                if (Cb40.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb40.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "40");
                        contador++;
                    }
                }
                if (Cb41.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb41.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "41");
                        contador++;
                    }
                }
                if (Cb42.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb42.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "42");
                        contador++;
                    }
                }
                if (Cb43.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb43.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "43");
                        contador++;
                    }
                }
                if (Cb44.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb44.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "44");
                        contador++;
                    }
                }
                if (Cb45.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb45.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "45");
                        contador++;
                    }
                }
                if (Cb46.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb46.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "46");
                        contador++;
                    }
                }
                if (Cb47.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb47.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "47");
                        contador++;
                    }
                }
                if (Cb48.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb48.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "48");
                        contador++;
                    }
                }
                if (Cb49.Checked)
                {
                    if (!validateAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "1"))
                    {

                        respuesta += "\\n\\n En " + Cb49.Text + ":";
                        respuesta += "\\n\\n Linea Ticket: " + item.Cells[0].Text.ToString() + " " + item.Cells[1].Text.ToString() + " " + item.Cells[2].Text.ToString() + " Disp.:" +
                            GetAvailableLimitsGridView(item.Cells[2].Text.ToString(), item.Cells[1].Text.ToString(), item.Cells[0].Text.ToString(), "49");
                        contador++;
                    }
                }
            }

            if (contador == 1)
            {
                respuesta = "";
            }
            return respuesta;
        }

        public string LotteryCLose(string LotteryName, string ClosingTime, string ClosingTimeSunday)
        {
            string respuesa = LotteryName + " ya esta cerrada.";
            try
            {
                if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (Convert.ToInt32(DateTime.Now.ToString("HHmm")) <= Convert.ToInt32(ClosingTimeSunday.Replace(":", "")))
                    {
                        respuesa = "";
                    }

                }
                else
                {
                    if (Convert.ToInt32(DateTime.Now.ToString("HHmm")) <= Convert.ToInt32(ClosingTime.Replace(":", "")))
                    {
                        respuesa = "";
                    }
                }


            }
            catch (Exception ex)
            {
                respuesa = ex.Message;
            }

            //DateTime.

            return respuesa;

        }




        public void CBCheckedChanged(object sender, EventArgs e)
        {
            int contador = 0;
            contador = Cb1.Checked ? contador + 1 : contador;
            contador = Cb4.Checked ? contador + 1 : contador;
            contador = Cb5.Checked ? contador + 1 : contador;
            contador = Cb12.Checked ? contador + 1 : contador;
            contador = Cb15.Checked ? contador + 1 : contador;
            contador = Cb32.Checked ? contador + 1 : contador;
            contador = Cb33.Checked ? contador + 1 : contador;
            contador = Cb37.Checked ? contador + 1 : contador;
            contador = Cb38.Checked ? contador + 1 : contador;
            contador = Cb39.Checked ? contador + 1 : contador;
            contador = Cb40.Checked ? contador + 1 : contador;
            contador = Cb41.Checked ? contador + 1 : contador;
            contador = Cb42.Checked ? contador + 1 : contador;
            contador = Cb43.Checked ? contador + 1 : contador;
            contador = Cb44.Checked ? contador + 1 : contador;
            contador = Cb45.Checked ? contador + 1 : contador;
            contador = Cb46.Checked ? contador + 1 : contador;
            contador = Cb47.Checked ? contador + 1 : contador;
            contador = Cb48.Checked ? contador + 1 : contador;
            contador = Cb49.Checked ? contador + 1 : contador;

            if (contador > 1)
            {
                Color color = ColorTranslator.FromHtml("#ff4136");
                BtnSLM.BackColor = color;

            }
            else
            {
                Color color = ColorTranslator.FromHtml("#0000");
                BtnSLM.BackColor = color;
            }
        }

        public void CargarInicio()
        {
            RFVMonto.EnableClientScript = false;
            RFVNumero.EnableClientScript = false;
            REVMonto.EnableClientScript = false;
            REVNumero.EnableClientScript = false;



            LotteriesDAL lotteriesDAL = new LotteriesDAL();
            lotteriesDAL.LotteryID = int.Parse(Session["Parametros"].ToString().Substring(3, Session["Parametros"].ToString().Length - 3));
            if (lotteriesDAL.GetByKey(loginDAL))
            {
                LbLoteriaID.Text = lotteriesDAL.LotteryID.ToString() + "-" + (DateTime.Now.DayOfWeek == DayOfWeek.Sunday ? lotteriesDAL.SundayClosingTime.Replace(":", "") : lotteriesDAL.ClosingTime.Replace(":", ""));
                LbLoteriaNombre.Text = lotteriesDAL.Name;
                LbTardeNoche.Text = lotteriesDAL.ShiftID.ToString();
                LbHora.Text = DateTime.Now.ToShortDateString();

                if (GvTicket.Rows.Count == 0)
                {
                    GvTicket.DataSource = null;
                    GvTicket.DataBind();
                }

                switch (lotteriesDAL.LotteryID)
                {
                    case 1: Cb1.Enabled = false; Cb1.Checked = true; break;
                    case 4: Cb4.Enabled = false; Cb4.Checked = true; break;
                    case 5: Cb5.Enabled = false; Cb5.Checked = true; break;
                    case 12: Cb12.Enabled = false; Cb12.Checked = true; break;
                    case 15: Cb15.Enabled = false; Cb15.Checked = true; break;
                    case 32: Cb32.Enabled = false; Cb32.Checked = true; break;
                    case 33: Cb33.Enabled = false; Cb33.Checked = true; break;
                    case 37: Cb37.Enabled = false; Cb37.Checked = true; break;
                    case 38: Cb38.Enabled = false; Cb38.Checked = true; break;
                    case 39: Cb39.Enabled = false; Cb39.Checked = true; break;
                    case 40: Cb40.Enabled = false; Cb40.Checked = true; break;
                    case 41: Cb41.Enabled = false; Cb41.Checked = true; break;
                    case 42: Cb42.Enabled = false; Cb42.Checked = true; break;
                    case 43: Cb43.Enabled = false; Cb43.Checked = true; break;
                    case 44: Cb44.Enabled = false; Cb44.Checked = true; break;
                    case 45: Cb45.Enabled = false; Cb45.Checked = true; break;
                    case 46: Cb46.Enabled = false; Cb46.Checked = true; break;
                    case 47: Cb47.Enabled = false; Cb47.Checked = true; break;
                    case 48: Cb48.Enabled = false; Cb48.Checked = true; break;
                    case 49: Cb49.Enabled = false; Cb49.Checked = true; break;
                }


            }
            else
            {
                Response.Redirect("SeleccionLoteria.aspx");
            }



        }


        public bool validateTexboxData()
        {
            if (TbNumero.Text.Length == 1 || TbNumero.Text.Length == 3 || TbNumero.Text.Length == 5)
            {
                return false;
            }

            return true;

        }
        public void calcularTotal()
        {
            decimal subtotal = 0;
            decimal total = 0;
            int free = 0;
            foreach (GridViewRow item in GvTicket.Rows)
            {
                subtotal = subtotal + decimal.Parse(item.Cells[2].Text);  
            }

            if (subtotal > 0)
            {
                //if (loginDAL.UsedFree)
                //{
                //    free = Convert.ToInt32(Math.Truncate(subtotal / 11));
                //    total = subtotal - free;
                //}
                //else
                //{
                //    total = subtotal;
                //}
                
            }
            LbSubTotal.Text = "S: $" + Convert.ToInt32(subtotal).ToString();
            LbFree.Text = "F: $" + free.ToString();
            LbTotal.Text = "Total: $" + Convert.ToInt32(total).ToString();

        }
        public bool ValidateIfNumberExist(String number)
        {
            bool exits = false;
            foreach (GridViewRow item in GvTicket.Rows)
            {
                if (item.Cells[0].Text == "Pl")
                {
                    if (item.Cells[1].Text.Replace("-", "") == number)
                    {
                        exits = true;
                        break;
                    }
                }
            }
            return exits;

        }
        public String orderNumbers(String numbers)
        {
            String orderedNumbers = numbers;

            if (numbers.Length == 4)
            {
                string text = numbers.Substring(0, 2);
                string text2 = numbers.Substring(2, 2);

                if (int.Parse(numbers.Substring(0, 2)) > int.Parse(numbers.Substring(2, 2)))
                {
                    orderedNumbers = numbers.Substring(2, 2) + numbers.Substring(0, 2);
                }
            }
            else if (numbers.Length == 6)
            {
                if (int.Parse(numbers.Substring(2, 2)) > int.Parse(numbers.Substring(0, 2)) && int.Parse(numbers.Substring(2, 2)) > int.Parse(numbers.Substring(4, 2)))
                {
                    if (int.Parse(numbers.Substring(0, 2)) > int.Parse(numbers.Substring(4, 2)))
                    {
                        orderedNumbers = numbers.Substring(4, 2) + numbers.Substring(0, 2) + numbers.Substring(2, 2);
                    }
                    else
                    {
                        orderedNumbers = numbers.Substring(0, 2) + numbers.Substring(4, 2) + numbers.Substring(2, 2);
                    }

                }
                else if (int.Parse(numbers.Substring(4, 2)) > int.Parse(numbers.Substring(0, 2)) && int.Parse(numbers.Substring(4, 2)) > int.Parse(numbers.Substring(2, 2)))
                {
                    if (int.Parse(numbers.Substring(0, 2)) > int.Parse(numbers.Substring(2, 2)))
                    {
                        orderedNumbers = numbers.Substring(2, 2) + numbers.Substring(0, 2) + numbers.Substring(4, 2);
                    }
                    else
                    {
                        orderedNumbers = numbers.Substring(0, 2) + numbers.Substring(2, 2) + numbers.Substring(4, 2);
                    }

                }
                else if (int.Parse(numbers.Substring(0, 2)) > int.Parse(numbers.Substring(2, 2)) && int.Parse(numbers.Substring(0, 2)) > int.Parse(numbers.Substring(4, 2)))
                {
                    if (int.Parse(numbers.Substring(2, 2)) > int.Parse(numbers.Substring(4, 2)))
                    {
                        orderedNumbers = numbers.Substring(4, 2) + numbers.Substring(2, 2) + numbers.Substring(0, 2);
                    }
                    else
                    {
                        orderedNumbers = numbers.Substring(2, 2) + numbers.Substring(4, 2) + numbers.Substring(0, 2);
                    }

                }
            }


            return orderedNumbers;
        }
        public string getPlayTypeName()
        {
            string name = string.Empty;
            if (TbNumero.Text.Length == 2)
                name = "Qn";
            else if (TbNumero.Text.Length == 4)
                name = "Pl";
            else if (TbNumero.Text.Length == 6)
                name = "Tp";
            return name;
        }
        public string getPlayTypeLongName()
        {
            string name = string.Empty;
            if (TbNumero.Text.Length == 2)
                name = "Quiniela";
            else if (TbNumero.Text.Length == 4)
                name = "Pale";
            else if (TbNumero.Text.Length == 6)
                name = "Tripleta";
            return name;
        }
        public void Notificaion(string titulo, string texto, string icono)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', '" + titulo + "', '" + icono + "');", true);
        }

        public string getNumberRamdon(int type)
        {
            var rng = new Random();
            int countR = 0;
            String number = "";

            int numberInt = rng.Next(99);

            if (type == 1)
            {
                number = numberInt.ToString().PadLeft(2, '0');
                if (number.Length != 2)
                    return ""; ;
            }
            else if (type == 2)
            {

                number = numberInt.ToString().PadLeft(2, '0');
                numberInt = rng.Next(99);
                number = number + numberInt.ToString().PadLeft(2, '0');
                if (number.Length != 4)
                    return ""; ;
            }
            else if (type == 3)
            {
                number = numberInt.ToString().PadLeft(2, '0');
                numberInt = rng.Next(99);
                number = number + numberInt.ToString().PadLeft(2, '0');
                numberInt = rng.Next(99);
                number = number + numberInt.ToString().PadLeft(2, '0');

                if (number.Length != 6)
                    return "";
            }

            if (number.Length == 2 || number.Length == 4 || number.Length == 6)
            {
                TbNumero.Text = number;
                numeroRandom = int.Parse(number);
                montoRandom = int.Parse(TbMonto.Text);
                double textAmount = double.Parse(TbMonto.Text);
            }
            if (!validateAvailableLimits())
            {

                while (!validateAvailableLimits())
                {
                    if (type == 1)
                    {
                        number = numberInt.ToString().PadLeft(2, '0');
                        if (number.Length != 2)
                            return ""; ;
                    }
                    else if (type == 2)
                    {

                        number = numberInt.ToString().PadLeft(2, '0');
                        numberInt = rng.Next(99);
                        number = number + numberInt.ToString().PadLeft(2, '0');
                        if (number.Length != 4)
                            return ""; ;
                    }
                    else if (type == 3)
                    {
                        number = numberInt.ToString().PadLeft(2, '0');
                        numberInt = rng.Next(99);
                        number = number + numberInt.ToString().PadLeft(2, '0');
                        numberInt = rng.Next(99);
                        number = number + numberInt.ToString().PadLeft(2, '0');
                        if (number.Length != 6)
                            return "";
                    }

                    if (number.Length == 2 || number.Length == 4 || number.Length == 6)
                    {
                        TbNumero.Text = number;
                        numeroRandom = int.Parse(number);
                        montoRandom = int.Parse(TbMonto.Text);
                    }

                    if (validateAvailableLimits())
                    {
                        if (number.Length == 2 || number.Length == 4 || number.Length == 6)
                        {
                            AgregarResultadoRandom();
                            break;
                        }
                    }
                    countR++;
                    if (countR == 50)
                    {
                        break;
                    }
                }
            }
            else
            {
                if (number.Length == 2 || number.Length == 4 || number.Length == 6)
                {
                    AgregarResultadoRandom();
                }

            }


            return number;
        }

        public string SeparadorNumero(string numero)
        {
            string nums = numero;
            if (numero.Length == 4)
            {
                nums = numero.Substring(0, 2) + '-' + numero.Substring(2, 2);
            }
            else if (numero.Length == 6)
            {
                nums = numero.Substring(0, 2) + '-' + numero.Substring(2, 2) + '-' + numero.Substring(4, 2);
            }
            return nums;

        }
        protected void AgregarResultadoRandom()
        {
            string tipo = "";
            if (numeroRandom.ToString().Length != 4)
            {
                if (!Cb32.Checked && !Cb5.Checked)
                {
                    switch (numeroRandom.ToString().Length)
                    {
                        case 2:
                            tipo = "Qn";
                            break;
                        case 4:
                            tipo = "Pl";
                            break;
                        case 6:
                            tipo = "Tp";
                            break;
                        default:
                            tipo = "N/A";
                            break;
                    }
                    DataTable dataTable = new DataTable();
                    if (GvTicket.Rows.Count > 0)
                    {

                        dataTable.Columns.Add("Tipo");
                        dataTable.Columns.Add("Numeros");
                        dataTable.Columns.Add("Monto");
                        foreach (GridViewRow item in GvTicket.Rows)
                        {
                            dataTable.Rows.Add(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
                        }

                        dataTable.Rows.Add(tipo, SeparadorNumero(numeroRandom.ToString()), montoRandom);


                    }
                    else
                    {

                        dataTable.Columns.Add("Tipo");
                        dataTable.Columns.Add("Numeros");
                        dataTable.Columns.Add("Monto");
                        dataTable.Rows.Add(tipo, SeparadorNumero(numeroRandom.ToString()), montoRandom);
                    }

                    GvTicket.DataSource = dataTable;
                    GvTicket.DataBind();
                    calcularTotal();

                }
                else
                {
                    Notificaion("Error!", "No solo se permiten Pale para la loteria Super Pale", "error");
                }
            }
            else
            {
                switch (numeroRandom.ToString().Length)
                {
                    case 2:
                        tipo = "Qn";
                        break;
                    case 4:
                        tipo = "Pl";
                        break;
                    case 6:
                        tipo = "Tp";
                        break;
                }
                DataTable dataTable = new DataTable();
                if (GvTicket.Rows.Count > 0)
                {

                    dataTable.Columns.Add("Tipo");
                    dataTable.Columns.Add("Numeros");
                    dataTable.Columns.Add("Monto");
                    foreach (GridViewRow item in GvTicket.Rows)
                    {
                        dataTable.Rows.Add(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
                    }

                    dataTable.Rows.Add(tipo, SeparadorNumero(numeroRandom.ToString()), montoRandom);


                }
                else
                {

                    dataTable.Columns.Add("Tipo");
                    dataTable.Columns.Add("Numeros");
                    dataTable.Columns.Add("Monto");
                    dataTable.Rows.Add(tipo, SeparadorNumero(numeroRandom.ToString()), montoRandom);
                }

                GvTicket.DataSource = dataTable;
                GvTicket.DataBind();
                calcularTotal();
            }

            TbNumero.Text = "";
        }
        public int getPlayTypeTotalAmount()
        {
            int amount = 0;

            if (!string.IsNullOrEmpty(TbMonto.Text))
                amount = Convert.ToInt32(TbMonto.Text);

            foreach (GridViewRow item in GvTicket.Rows)
            {
                if (item.Cells[0].Text.ToString().Equals(getPlayTypeName()) && item.Cells[1].Text.Replace("-", "").ToString().Equals(TbNumero.Text))
                {
                    amount += Convert.ToInt32(item.Cells[2].Text.ToString());
                }

            }

            return amount;
        }
        public int getPlayTypeTotalAmountOnly()
        {
            int amount = 0;
            foreach (GridViewRow item in GvTicket.Rows)
            {
                if (item.Cells[0].Text.ToString().Equals(getPlayTypeName()) && item.Cells[1].Text.Replace("-", "").ToString().Equals(orderNumbers(TbNumero.Text)))
                {
                    amount += Convert.ToInt32(item.Cells[2].Text.ToString());
                }

            }
            return amount;
        }
        public int getPlayTypeTotalAmountOnly(string number)
        {
            int amount = 0;
            foreach (GridViewRow item in GvTicket.Rows)
            {
                if (item.Cells[0].Text.ToString().Equals(getPlayTypeName()) && item.Cells[1].Text.Replace("-", "").ToString().Equals(orderNumbers(number)))
                {
                    amount += Convert.ToInt32(item.Cells[2].Text.ToString());
                }

            }
            return amount;
        }

        public int getTotalAmountLottery()
        {
            int amount = 0;
            foreach (GridViewRow item in GvTicket.Rows)
            {
                amount += Convert.ToInt32(item.Cells[2].Text.ToString());

            }
            return amount;
        }

        public bool validateAvailableLimitsGridView(string amount, string number, string typename, string lotteryId)/******/
        {
            bool result = false;
            TransactionsDAL transactionDAL = new TransactionsDAL();
            LotteriesDAL lotteriesDAL = new LotteriesDAL();

            lotteriesDAL.LotteryID = int.Parse(lotteryId);
            lotteriesDAL.GetByKey(loginDAL);

            transactionDAL.Amount = Convert.ToDecimal(amount);
            transactionDAL.Numbers = orderNumbers(number).Replace("-", "");
            transactionDAL.LotteryName = lotteriesDAL.Name;
            transactionDAL.ShiftName = lotteriesDAL.ShiftID == 2 ? "Tarde" : "Noche";
            switch (typename)
            {
                case "Qn":
                    transactionDAL.PlayTypeName = "Quiniela";
                    break;
                case "Pl":
                    transactionDAL.PlayTypeName = "Pale";
                    break;
                case "Tp":
                    transactionDAL.PlayTypeName = "Tripleta";
                    break;
            }

            if (transactionDAL.ValidateLimitsForCombinations(loginDAL))
            {

                if (transactionDAL.AllowTransaction)
                {
                    if (transactionDAL.ExistCombination)
                    {
                        if (transactionDAL.AvailableAmount >= getPlayTypeTotalAmountOnly(number.Replace("-", "")))
                        {
                            result = true;
                        }

                    }
                    else
                    {
                        result = true;
                    }
                }




            }
            return result;
        }
        public string GetAvailableLimitsGridView(string amount, string number, string typename, string lotteryId)/*************/
        {
            string respuesta = "";
            TransactionsDAL transactionDAL = new TransactionsDAL();
            LotteriesDAL lotteriesDAL = new LotteriesDAL();

            lotteriesDAL.LotteryID = int.Parse(lotteryId);
            lotteriesDAL.GetByKey(loginDAL);

            transactionDAL.Amount = Convert.ToInt32(amount);
            transactionDAL.Numbers = orderNumbers(number);
            transactionDAL.LotteryName = lotteriesDAL.Name;
            transactionDAL.ShiftName = lotteriesDAL.ShiftID == 2 ? "Tarde" : "Noche";
            switch (typename)
            {
                case "Qn":
                    transactionDAL.PlayTypeName = "Quiniela";
                    break;
                case "Pl":
                    transactionDAL.PlayTypeName = "Pale";
                    break;
                case "Tp":
                    transactionDAL.PlayTypeName = "Tripleta";
                    break;
            }

            if (transactionDAL.ValidateLimitsForCombinations(loginDAL))
            {

                if (!transactionDAL.ExistCombination)
                {
                    transactionDAL.Amount = getPlayTypeTotalAmount();
                    transactionDAL.ValidateLimitsForPlayTypes(loginDAL);
                    if (transactionDAL.ExistCombination)
                    {
                        int amount1 = 0;
                        foreach (GridViewRow item in GvTicket.Rows)
                        {
                            if (item.Cells[0].Text.ToString().Equals(getPlayTypeName()) && item.Cells[1].Text.Replace("-", "").ToString().Equals(orderNumbers(number)))
                            {
                                amount1 += Convert.ToInt32(item.Cells[2].Text.ToString());
                            }

                        }
                        respuesta = (transactionDAL.AvailableAmount - amount1).ToString();

                        if (Convert.ToInt32(respuesta) < 0)
                            respuesta = "0";
                    }

                }
                else
                {
                    int amount1 = 0;
                    foreach (GridViewRow item in GvTicket.Rows)
                    {
                        if (item.Cells[0].Text.ToString().Equals(getPlayTypeName()) && item.Cells[1].Text.Replace("-", "").ToString().Equals(orderNumbers(number)))
                        {
                            amount1 += Convert.ToInt32(item.Cells[2].Text.ToString());
                        }

                    }

                    respuesta = (transactionDAL.AvailableAmount - amount1).ToString();
                    if (Convert.ToInt32(respuesta) < 0)
                        respuesta = "0";

                }
            }

            return respuesta;
        }

        public bool validateAvailableLimits()/******/
        {
            bool result = false;
            TransactionsDAL transactionDAL = new TransactionsDAL();


            transactionDAL.Amount = Convert.ToInt32(TbMonto.Text);
            transactionDAL.Numbers = orderNumbers(TbNumero.Text);
            transactionDAL.LotteryName = LbLoteriaNombre.Text;
            transactionDAL.ShiftName = LbTardeNoche.Text == "2" ? "Tarde" : "Noche";
            transactionDAL.PlayTypeName = getPlayTypeLongName();

            if (transactionDAL.ValidateLimitsForCombinations(loginDAL))
            {

                if (!transactionDAL.ExistCombination)
                {
                    transactionDAL.Amount = getPlayTypeTotalAmount();
                    transactionDAL.ValidateLimitsForPlayTypes(loginDAL);
                    result = transactionDAL.AllowTransaction;
                }
                else
                    result = true;
            }
            if (!result)
            {
                string texto = "Monto sobrepasa límite, límite disponible [" + (transactionDAL.AvailableAmount - getPlayTypeTotalAmountOnly()) + "]";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', 'Limite Exedido!', 'warning');", true);
            }
            return result;
        }

        public bool validateAvailableLimitsTotal()/******/
        {
            bool result = false;
            TransactionsDAL transactionDAL = new TransactionsDAL();


            transactionDAL.Amount = Convert.ToInt32(TbMonto.Text);
            transactionDAL.Numbers = orderNumbers(TbNumero.Text);
            transactionDAL.LotteryName = LbLoteriaNombre.Text;
            transactionDAL.ShiftName = LbTardeNoche.Text == "2" ? "Tarde" : "Noche";
            transactionDAL.PlayTypeName = getPlayTypeLongName();

            if (transactionDAL.ValidateLimitsForCombinations(loginDAL))
            {

                if (!transactionDAL.ExistCombination)
                {
                    transactionDAL.Amount = getPlayTypeTotalAmount();
                    transactionDAL.ValidateLimitsForPlayTypes(loginDAL);
                    result = transactionDAL.AllowTransaction;
                }
                else
                    result = true;
            }
            if (!result)
            {
                string texto = "Monto sobrepasa límite, límite disponible [" + (transactionDAL.AvailableAmount - getPlayTypeTotalAmountOnly()) + "]";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Notificacion('" + texto + "', 'Limite Exedido!', 'warning');", true);
            }
            return result;
        }

        public string GetAvailableLimits(string numero)/*************/
        {
            string respuesta = "";
            TransactionsDAL transactionDAL = new TransactionsDAL();
            transactionDAL.Amount = Convert.ToInt32(TbMonto.Text);
            transactionDAL.Numbers = orderNumbers(numero);
            transactionDAL.LotteryName = LbLoteriaNombre.Text;
            transactionDAL.ShiftName = LbTardeNoche.Text == "2" ? "Tarde" : "Noche";
            transactionDAL.PlayTypeName = getPlayTypeLongName();

            if (transactionDAL.ValidateLimitsForCombinations(loginDAL))
            {

                if (!transactionDAL.ExistCombination)
                {
                    transactionDAL.Amount = getPlayTypeTotalAmount();
                    transactionDAL.ValidateLimitsForPlayTypes(loginDAL);
                    if (transactionDAL.ExistCombination)
                    {
                        respuesta = (transactionDAL.AvailableAmount - getPlayTypeTotalAmountOnly()).ToString();

                        if (Convert.ToInt32(respuesta) < 0)
                            respuesta = "0";
                    }

                }
                else
                {
                    respuesta = (transactionDAL.AvailableAmount - getPlayTypeTotalAmountOnly()).ToString();
                    if (Convert.ToInt32(respuesta) < 0)
                        respuesta = "0";

                }
            }

            return respuesta;
        }


        protected void GvTicket_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {



        }
        protected void GvTicket_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {


        }
        protected void GvTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GvTicket.SelectedRow.RowIndex >= 0)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Tipo");
                dataTable.Columns.Add("Numeros");
                dataTable.Columns.Add("Monto");
                foreach (GridViewRow item in GvTicket.Rows)
                {
                    dataTable.Rows.Add(item.Cells[0].Text, item.Cells[1].Text, item.Cells[2].Text);
                }
                dataTable.Rows.RemoveAt(GvTicket.SelectedRow.RowIndex);

                GvTicket.DataSource = dataTable;
                GvTicket.DataBind();
                calcularTotal();
            }

        }

        public void cargarGridCopiado()
        {
            try
            {
                List<TransactionDetailsDAL> listCopy = new List<TransactionDetailsDAL>();
                string tipo = "";
                if (Session["ListaDetalle"] != null)
                {
                    listCopy = (List<TransactionDetailsDAL>)Session["ListaDetalle"];


                    DataTable dataTable = new DataTable();

                    dataTable.Columns.Add("Tipo");
                    dataTable.Columns.Add("Numeros");
                    dataTable.Columns.Add("Monto");
                    foreach (TransactionDetailsDAL item in listCopy)
                    {
                        switch (item.Numbers.Length)
                        {
                            case 2:
                                tipo = "Qn";
                                break;
                            case 4:
                                tipo = "Pl";
                                break;
                            case 6:
                                tipo = "Tp";
                                break;
                        }
                        dataTable.Rows.Add(tipo, SeparadorNumero(item.Numbers), Convert.ToInt32(item.Amount).ToString());
                    }


                    GvTicket.DataSource = dataTable;
                    GvTicket.DataBind();
                    calcularTotal();
                    Session["ListaDetalle"] = null;
                }
            }
            catch (Exception e)
            {


            }
        }


    }


}