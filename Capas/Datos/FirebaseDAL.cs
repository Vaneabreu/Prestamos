
using BankingDAL;
//using FireSharp.Config;
//using FireSharp.Interfaces;
//using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Helpers;
using System.Web.Script.Serialization;

public class FirebaseDAL
{
    //EventStreamResponse response;
    bool canContinue = true;
    public bool isInsertCust = false;
    string dbName = ConfigurationManager.AppSettings["DbName"].ToString();
    public bool running = false;
    public bool runningCancel = false;
    public string letter = "";

    public decimal amountB = 0;
    public decimal commissionB = 0;
    public decimal gainAmountB = 0;
    public decimal totalB = 0;
    public decimal freeB = 0;
    public bool existUser = false;
    public bool enabledUser = false;

    public string user = "";
    public string userID = "";
    public DateTime lastPaymentDate;
    public DateTime lastCommissionDate;

    //public TicketEntityFirebase ticket;
    public string userTicket;
    public DateTime dateTicket;

    //public TicketDetailEntityFirebase ticketDetail;
    public string userTicketDetail;
    public DateTime dateTicketDetail;



    //IFirebaseConfig config = new FirebaseConfig
    //{
    //    AuthSecret = "iaThkV7ZNtzSt4Leb0w0IpmaUX31g5dZMRnOBfMU",
    //    BasePath = "https://gsoftbanking.firebaseio.com/"
    //};

    //IFirebaseClient client;

    public FirebaseDAL()
    {
        openConection();

    }


    public void updateBalance(string user, string userID, DateTime lastpaymentDate, DateTime lastCommissionDate)
    {
        try
        {
            DateTime dateCurr = DateTime.Now;
            string currentDate = dateCurr.ToString("yyyyMMdd");
            decimal commission = 0;
            decimal amount = 0;
            decimal gainAmount = 0;
            decimal total = 0;
            decimal free = 0;

            decimal dailycommission = 0;
            decimal dailyamount = 0;
            decimal dailygainAmount = 0;
            decimal dailytotal = 0;
            decimal dailyfree = 0;

            decimal redamount = 0;
            decimal loanamount = 0;

            decimal totalAll = 0;
            decimal gainAll = 0;
            decimal commissionAll = 0;
            decimal freeAll = 0;

            TransactionsDAL transactionsDAL = new TransactionsDAL();
            List<TransactionsDAL> list = new List<TransactionsDAL>();
            transactionsDAL.UserName = user;
            transactionsDAL.StartTime = lastpaymentDate;
            transactionsDAL.EndTime = DateTime.Now;
            transactionsDAL.CustomerID = -1;
            BalanceFirebaseEntity objBalance;

            list = transactionsDAL.Search(true);

            foreach (TransactionsDAL item in list)
            {
                if (item.TransactionStatusName != "Ticket Cancelado")
                {
                    //commission = commission + item.Commission;
                    amount = amount + item.Amount;
                    gainAmount = gainAmount + item.TotalGainAmount;
                    free = free + item.Discount;

                    if (item.Date.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        dailycommission = dailycommission + item.Commission;
                        dailyamount = dailyamount + item.Amount;
                        dailygainAmount = dailygainAmount + item.TotalGainAmount;
                        dailyfree = dailyfree + item.Discount;
                    }
                }
            }

            //buscando la commission acumulada
            transactionsDAL.UserName = user;
            transactionsDAL.StartTime = lastCommissionDate;
            transactionsDAL.EndTime = DateTime.Now;
            transactionsDAL.CustomerID = -1;
            list = transactionsDAL.Search(true);

            foreach (TransactionsDAL item in list)
            {
                if (item.TransactionStatusName != "Ticket Cancelado")
                {
                    commission = commission + item.Commission;
                }

            }

            //buscando balance rojo
            transactionsDAL.UserName = user;
            transactionsDAL.StartTime = DateTime.Now.AddYears(-50);
            transactionsDAL.EndTime = DateTime.Now;
            transactionsDAL.CustomerID = -1;
            list = transactionsDAL.Search(true);

            foreach (TransactionsDAL item in list)
            {
                if (item.TransactionStatusName != "Ticket Cancelado")
                {
                    totalAll = totalAll + item.Amount;
                    commissionAll = commissionAll + item.Commission;
                    gainAll = gainAll + item.TotalGainAmount;
                    freeAll = freeAll + item.Discount;
                }
            }



            total = (amount) - gainAmount - commission - free;
            dailytotal = (dailyamount) - dailygainAmount - dailycommission - dailyfree;
            redamount = totalAll - (commissionAll + gainAll + freeAll);
            loanamount = getLoanAmountByUser(userID);

            objBalance = new BalanceFirebaseEntity();
            objBalance.commission = commission.ToString("N2").Replace(",", "");
            objBalance.amount = amount.ToString("N2").Replace(",", "");
            objBalance.gainAmount = gainAmount.ToString("N2").Replace(",", "");
            objBalance.free = free.ToString("N2").Replace(",", "");
            objBalance.total = total.ToString("N2").Replace(",", "");


            objBalance.dailycommission = dailycommission.ToString("N2").Replace(",", "");
            objBalance.dailyamount = dailyamount.ToString("N2").Replace(",", "");
            objBalance.dailygainAmount = dailygainAmount.ToString("N2").Replace(",", "");
            objBalance.dailyfree = dailyfree.ToString("N2").Replace(",", "");
            objBalance.dailytotal = dailytotal.ToString("N2").Replace(",", "");

            objBalance.redamount = redamount.ToString("N2").Replace(",", "");
            objBalance.loanamount = loanamount.ToString("N2").Replace(",", "");

            SetResponse setB = client.Set(dbName + "/balance/" + user + "/" + currentDate + "/" + userID, objBalance);
            BalanceFirebaseEntity setBalance = setB.ResultAs<BalanceFirebaseEntity>();
        }
        catch (Exception)
        {


        }


    }
    public void clearBalance(string user, string userID, DateTime lastPaymentDate)
    {

        UsersDAL usersDAL = new UsersDAL();
        usersDAL.LastPaymentDate = lastPaymentDate;
        usersDAL.UserID = Convert.ToInt32(userID);

        BalanceFirebaseEntity objBalance;
        objBalance = new BalanceFirebaseEntity();
        objBalance.commission = "0.00";
        objBalance.amount = "0.00";
        objBalance.gainAmount = "0.00";
        objBalance.free = "0.00";
        objBalance.total = "0.00";

        objBalance.dailycommission = "0.00";
        objBalance.dailyamount = "0.00";
        objBalance.dailygainAmount = "0.00";
        objBalance.dailytotal = "0.00";
        objBalance.dailyfree = "0.00";
        objBalance.loanamount = "0.00";
        objBalance.redamount = "0.00";
        SetResponse setB = client.Set(dbName + "/balance/" + user + "/" + userID, objBalance);
        BalanceFirebaseEntity setBalance = setB.ResultAs<BalanceFirebaseEntity>();

        usersDAL.UpdateLastPaymentDate();


    }

    private bool openConection()
    {
        bool result = false;
        client = new FireSharp.FirebaseClient(config);

        if (client != null)
        {
            result = true;
            //listenEvent();
        }

        return result;
    }

    public async void insertLimitPlayType(string playType, string limitAmount)
    {
        try
        {
            string playT = playType;
            string loteryName = string.Empty;

            if (playType.Contains("Quiniela"))
                playT = "Qn";
            else if (playType.Contains("Pale"))
                playT = "Pl";
            else if (playType.Contains("Tripleta"))
                playT = "Tp";

            if (playType.Contains("Nacional") && !playType.Contains("Super Pale"))
                loteryName = "Nacional";
            else if (playType.Contains("Leidsa") && !playType.Contains("Super Pale"))
                loteryName = "Leidsa";
            else if (playType.Contains("Gana mas") && !playType.Contains("Super Pale"))
                loteryName = "Ganamas";
            else if (playType.Contains("Real") && !playType.Contains("Super Pale"))
                loteryName = "Real";
            else if (playType.Contains("Loteka"))
                loteryName = "Loteka";
            else if (playType.Contains("NewYork Tarde"))
                loteryName = "New York Tarde";
            else if (playType.Contains("NewYork Noche"))
                loteryName = "New York Noche";
            else if (playType.Contains("Super Pale Nacional-Leidsa"))
                loteryName = "SP Nacional-Leidsa";
            else if (playType.Contains("Super Pale Real-Gana mas"))
                loteryName = "SP Real-Ganamas";
            else if (playType.Contains("Florida Dia"))
                loteryName = "Florida Dia";
            else if (playType.Contains("Florida Noche"))
                loteryName = "Florida Noche";
            else if (playType.Contains("La Primera"))
                loteryName = "La Primera";
            else if (playType.Contains("La Suerte"))
                loteryName = "La Suerte";

            //LimitPlayTypeFirebaseEntity limitPlayTypeFirebaseEntity = new BankingDAL.LimitPlayTypeFirebaseEntity();
            limitPlayTypeFirebaseEntity.playType = playT;
            limitPlayTypeFirebaseEntity.limitAmount = limitAmount;
            limitPlayTypeFirebaseEntity.lotery = loteryName;

            FirebaseResponse playTypeR = await client.SetAsync(dbName + "/limitPlayType/" + loteryName.ToString() + "/" + playT, limitPlayTypeFirebaseEntity);
            LimitPlayTypeFirebaseEntity objPlayType = playTypeR.ResultAs<LimitPlayTypeFirebaseEntity>();


        }
        catch (Exception ex)
        {


        }

    }

    public async void insertLimitNumber(string number, string limitAmount, string lotery)
    {
        try
        {

            string loteryName = string.Empty;

            if (lotery.Contains("Nacional") && !lotery.Contains("Super Pale"))
                loteryName = "Nacional";
            else if (lotery.Contains("Leidsa") && !lotery.Contains("Super Pale"))
                loteryName = "Leidsa";
            else if (lotery.Contains("Gana mas") && !lotery.Contains("Super Pale"))
                loteryName = "Ganamas";
            else if (lotery.Contains("Real") && !lotery.Contains("Super Pale"))
                loteryName = "Real";
            else if (lotery.Contains("Loteka"))
                loteryName = "Loteka";
            else if (lotery.Contains("NewYork Tarde"))
                loteryName = "New York Tarde";
            else if (lotery.Contains("NewYork Noche"))
                loteryName = "New York Noche";
            else if (lotery.Contains("Super Pale Nacional-Leidsa"))
                loteryName = "SP Nacional-Leidsa";
            else if (lotery.Contains("Super Pale Real-Gana mas"))
                loteryName = "SP Real-Ganamas";
            else if (lotery.Contains("Florida Dia"))
                loteryName = "Florida Dia";
            else if (lotery.Contains("Florida Noche"))
                loteryName = "Florida Noche";
            else if (lotery.Contains("La Primera"))
                loteryName = "La Primera";
            else if (lotery.Contains("La Suerte"))
                loteryName = "La Suerte";

            LimitNumberFirebaseEntity limitNumberFirebaseEntity = new BankingDAL.LimitNumberFirebaseEntity();
            limitNumberFirebaseEntity.number = number;
            limitNumberFirebaseEntity.limitAmount = limitAmount;
            limitNumberFirebaseEntity.lotery = loteryName;

            FirebaseResponse numberR = await client.SetAsync(dbName + "/limitNumber/" + loteryName.ToString() + "/" + number, limitNumberFirebaseEntity);
            LimitNumberFirebaseEntity objNumber = numberR.ResultAs<LimitNumberFirebaseEntity>();


        }
        catch (Exception ex)
        {


        }

    }

    public async void deleteLimitPlayType(string playType)
    {
        try
        {
            string playT = playType;
            string loteryName = string.Empty;

            if (playType.Contains("Quiniela"))
                playT = "Qn";
            else if (playType.Contains("Pale"))
                playT = "Pl";
            else if (playType.Contains("Tripleta"))
                playT = "Tp";

            if (playType.Contains("Nacional") && !playType.Contains("Super Pale"))
                loteryName = "Nacional";
            else if (playType.Contains("Leidsa") && !playType.Contains("Super Pale"))
                loteryName = "Leidsa";
            else if (playType.Contains("Gana mas") && !playType.Contains("Super Pale"))
                loteryName = "Ganamas";
            else if (playType.Contains("Real") && !playType.Contains("Super Pale"))
                loteryName = "Real";
            else if (playType.Contains("Loteka"))
                loteryName = "Loteka";
            else if (playType.Contains("NewYork Tarde"))
                loteryName = "New York Tarde";
            else if (playType.Contains("NewYork Noche"))
                loteryName = "New York Noche";
            else if (playType.Contains("Super Pale Nacional-Leidsa"))
                loteryName = "SP Nacional-Leidsa";
            else if (playType.Contains("Super Pale Real-Gana mas"))
                loteryName = "SP Real-Ganamas";
            else if (playType.Contains("Florida Dia"))
                loteryName = "Florida Dia";
            else if (playType.Contains("Florida Noche"))
                loteryName = "Florida Noche";
            else if (playType.Contains("La Primera"))
                loteryName = "La Primera";
            else if (playType.Contains("La Suerte"))
                loteryName = "La Suerte";

            FirebaseResponse response = await client.DeleteAsync(dbName + "/limitPlayType/" + loteryName.ToString() + "/" + playT);

        }
        catch (Exception ex)
        {


        }

    }

    public async void deleteLimitNumber(string lotery, string number)
    {
        try
        {
            string loteryName = string.Empty;

            if (lotery.Contains("Nacional") && !lotery.Contains("Super Pale"))
                loteryName = "Nacional";
            else if (lotery.Contains("Leidsa") && !lotery.Contains("Super Pale"))
                loteryName = "Leidsa";
            else if (lotery.Contains("Gana mas") && !lotery.Contains("Super Pale"))
                loteryName = "Ganamas";
            else if (lotery.Contains("Real") && !lotery.Contains("Super Pale"))
                loteryName = "Real";
            else if (lotery.Contains("Loteka"))
                loteryName = "Loteka";
            else if (lotery.Contains("NewYork Tarde"))
                loteryName = "New York Tarde";
            else if (lotery.Contains("NewYork Noche"))
                loteryName = "New York Noche";
            else if (lotery.Contains("Super Pale Nacional-Leidsa"))
                loteryName = "SP Nacional-Leidsa";
            else if (lotery.Contains("Super Pale Real-Gana mas"))
                loteryName = "SP Real-Ganamas";
            else if (lotery.Contains("Florida Dia"))
                loteryName = "Florida Dia";
            else if (lotery.Contains("Florida Noche"))
                loteryName = "Florida Noche";
            else if (lotery.Contains("La Primera"))
                loteryName = "La Primera";
            else if (lotery.Contains("La Suerte"))
                loteryName = "La Suerte";


            FirebaseResponse response = await client.DeleteAsync(dbName + "/limitNumber/" + loteryName.ToString() + "/" + number);

        }
        catch (Exception ex)
        {


        }

    }

    public async void deleteAllLimitPlayType()
    {
        try
        {
            FirebaseResponse response = await client.DeleteAsync(dbName + "/limitPlayType");

        }
        catch (Exception ex)
        {


        }

    }

    public async void deleteAllLimitNumber()
    {
        try
        {

            FirebaseResponse response = await client.DeleteAsync(dbName + "/limitNumber");

        }
        catch (Exception ex)
        {


        }

    }

    public async void deleteFirebase(string url)
    {
        try
        {

            FirebaseResponse response = await client.DeleteAsync(dbName + url);

        }
        catch (Exception ex)
        {


        }

    }

    public async void updateWinNumber(TicketDetailEntityFirebase ticketDetailEntityFirebase, string user, string userID, DateTime lastPaymentDate, DateTime date, decimal totalGainAmount, DateTime lastCommissionDate)
    {
        try
        {
            DateTime dateCurr = DateTime.Now;
            string currentDate = dateCurr.ToString("yyyyMMdd");

            SetResponse response = client.Set(dbName + "/banking/" + user + "/details/" + currentDate + "/" + ticketDetailEntityFirebase.ID, ticketDetailEntityFirebase);
            TicketDetailEntityFirebase data = response.ResultAs<TicketDetailEntityFirebase>();

            //Win List Detail
            SetResponse responseWin = client.Set(dbName + "/banking/" + user + "/win/details/" + date.ToString("yyyyMMdd") + "/" + ticketDetailEntityFirebase.ID, ticketDetailEntityFirebase);
            TicketDetailEntityFirebase dataWin = responseWin.ResultAs<TicketDetailEntityFirebase>();


            FirebaseResponse ticket = client.Get(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + ticketDetailEntityFirebase.billID);
            TicketEntityFirebase objTicket = ticket.ResultAs<TicketEntityFirebase>();

            objTicket.registrationStatus = "Ganador";
            SetResponse responseT = await client.SetAsync(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + ticketDetailEntityFirebase.billID, objTicket);
            TicketEntityFirebase dataT = responseT.ResultAs<TicketEntityFirebase>();

            //Win List
            objTicket.commission = "0.00";
            objTicket.winAmount = totalGainAmount.ToString("N2").Replace(",", "");
            SetResponse responseTWin = await client.SetAsync(dbName + "/banking/" + user + "/win/tickets/" + date.ToString("yyyyMMdd") + "/" + ticketDetailEntityFirebase.billID, objTicket);
            TicketEntityFirebase dataTWin = responseTWin.ResultAs<TicketEntityFirebase>();


            updateBalance(user, userID, lastPaymentDate, lastCommissionDate);
            updateBalanceTotal();
        }
        catch (Exception ex)
        {


        }

    }

    public void updateWinNumberByTransactionID(string user, string ticketDetailID, string gainAmount, DateTime date, decimal totalGainAmount)
    {
        try
        {
            DateTime dateCurr = DateTime.Now;
            string currentDate = dateCurr.ToString("yyyyMMdd");

            FirebaseResponse ticketDetail = client.Get(dbName + "/banking/" + user + "/details/" + currentDate + "/" + ticketDetailID);
            TicketDetailEntityFirebase objTicketDetail = ticketDetail.ResultAs<TicketDetailEntityFirebase>();

            if (objTicketDetail != null)
            {
                objTicketDetail.winAmount = gainAmount.Replace(",", "");

                SetResponse response = client.Set(dbName + "/banking/" + user + "/details/" + currentDate + "/" + ticketDetailID, objTicketDetail);
                TicketDetailEntityFirebase data = response.ResultAs<TicketDetailEntityFirebase>();

                FirebaseResponse ticket = client.Get(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + objTicketDetail.billID);
                TicketEntityFirebase objTicket = ticket.ResultAs<TicketEntityFirebase>();

                objTicket.winAmount = totalGainAmount.ToString("N2").Replace(",", "");
                objTicket.commission = "0.00";
                //Win List
                SetResponse responseTWin = client.Set(dbName + "/banking/" + user + "/win/tickets/" + date.ToString("yyyyMMdd") + "/" + objTicket.billID, objTicket);
                TicketEntityFirebase dataTWin = responseTWin.ResultAs<TicketEntityFirebase>();

                //Win List Detail
                SetResponse responseWin = client.Set(dbName + "/banking/" + user + "/win/details/" + date.ToString("yyyyMMdd") + "/" + ticketDetailID, objTicketDetail);
                TicketDetailEntityFirebase dataWin = responseWin.ResultAs<TicketDetailEntityFirebase>();
                Thread.Sleep(1000);
            }


        }
        catch (Exception ex)
        {


        }

    }

    public async void updateLotery(LotteryFirebaseEntity lotteryFirebaseEntity)
    {
        try
        {
            string lotery = string.Empty;



            if (lotteryFirebaseEntity.name.Contains("Nacional") && !lotteryFirebaseEntity.name.Contains("Super Pale"))
            {
                lotery = "Nacional";
            }
            else if (lotteryFirebaseEntity.name.Contains("Leidsa") && !lotteryFirebaseEntity.name.Contains("Super Pale"))
            {
                lotery = "Leidsa";
            }
            else if (lotteryFirebaseEntity.name.Contains("Loteka"))
            {
                lotery = "Loteka";
            }
            else if (lotteryFirebaseEntity.name.Contains("Gana mas") && !lotteryFirebaseEntity.name.Contains("Super Pale"))
            {
                lotery = "Ganamas";
            }
            else if (lotteryFirebaseEntity.name.Contains("Real") && !lotteryFirebaseEntity.name.Contains("Super Pale"))
            {
                lotery = "Real";
            }
            else if (lotteryFirebaseEntity.name.Contains("NewYork Tarde"))
            {
                lotery = "New York Tarde";
            }
            else if (lotteryFirebaseEntity.name.Contains("NewYork Noche"))
            {
                lotery = "New York Noche";
            }
            else if (lotteryFirebaseEntity.name.Contains("Super Pale Nacional-Leidsa"))
            {
                lotery = "SP Nacional-Leidsa";
            }
            else if (lotteryFirebaseEntity.name.Contains("Super Pale Real-Gana mas"))
            {
                lotery = "SP Real-Ganamas";
            }
            else if (lotteryFirebaseEntity.name.Contains("Florida Dia"))
            {
                lotery = "Florida Dia";
            }
            else if (lotteryFirebaseEntity.name.Contains("Florida Noche"))
            {
                lotery = "Florida Noche";
            }
            else if (lotteryFirebaseEntity.name.Contains("La Primera"))
            {
                lotery = "La Primera";
            }
            else if (lotteryFirebaseEntity.name.Contains("La Suerte"))
            {
                lotery = "La Suerte";
            }

            lotteryFirebaseEntity.name = lotery;

            SetResponse response = await client.SetAsync(dbName + "/loteries/" + lotteryFirebaseEntity.id, lotteryFirebaseEntity);
            LotteryFirebaseEntity data = response.ResultAs<LotteryFirebaseEntity>();




        }
        catch (Exception ex)
        {


        }

    }



    public async void insertDetailAll(TicketDetailEntityFirebase objDetail, string user)
    {
        try
        {
            string playT = objDetail.playType;
            string loteryName = objDetail.lotery;

            if (objDetail.playType.Contains("Quiniela"))
                playT = "Qn";
            else if (objDetail.playType.Contains("Pale"))
                playT = "Pl";
            else if (objDetail.playType.Contains("Tripleta"))
                playT = "Tp";

            if (loteryName.Contains("Nacional") && !loteryName.Contains("Super Pale"))
                loteryName = "Nacional";
            else if (loteryName.Contains("Leidsa") && !loteryName.Contains("Super Pale"))
                loteryName = "Leidsa";
            else if (loteryName.Contains("Gana mas") && !loteryName.Contains("Super Pale"))
                loteryName = "Ganamas";
            else if (loteryName.Contains("Real") && !loteryName.Contains("Super Pale"))
                loteryName = "Real";
            else if (loteryName.Contains("Loteka"))
                loteryName = "Loteka";
            else if (loteryName.Contains("NewYork Tarde"))
                loteryName = "New York Tarde";
            else if (loteryName.Contains("NewYork Noche"))
                loteryName = "New York Noche";
            else if (loteryName.Contains("Super Pale Nacional-Leidsa"))
                loteryName = "SP Nacional-Leidsa";
            else if (loteryName.Contains("Super Pale Real-Gana mas"))
                loteryName = "SP Real-Ganamas";
            else if (loteryName.Contains("Florida Dia"))
                loteryName = "Florida Dia";
            else if (loteryName.Contains("Florida Noche"))
                loteryName = "Florida Noche";
            else if (loteryName.Contains("La Primera"))
                loteryName = "La Primera";
            else if (loteryName.Contains("La Suerte"))
                loteryName = "La Suerte";

            objDetail.lotery = loteryName;
            objDetail.playType = playT;

            SetResponse setTicketDetail = await client.SetAsync(dbName + "/banking/details/" + user + objDetail.ID, objDetail);
            TicketDetailEntityFirebase setBillDetail = setTicketDetail.ResultAs<TicketDetailEntityFirebase>();
            Thread.Sleep(500);


        }
        catch (Exception ex)
        {


        }

    }
    public async void insertWinNumber(string firstNumber, string secondNumber, string thirdNumber, string date, string lotery)
    {
        try
        {
            FirebaseResponse winNumber = client.Get(dbName + "/winNumbers/" + date);
            WinNumberEntityFirebase objWinNumber = winNumber.ResultAs<WinNumberEntityFirebase>();
            if (objWinNumber == null)
            {
                objWinNumber = new WinNumberEntityFirebase();
                objWinNumber.nacional = "0";
                objWinNumber.leidsa = "0";
                objWinNumber.loteka = "0";
                objWinNumber.ganamas = "0";
                objWinNumber.real = "0";
                objWinNumber.newyorktarde = "0";
                objWinNumber.newyorknoche = "0";
                objWinNumber.floridadia = "0";
                objWinNumber.floridanoche = "0";
                objWinNumber.laprimera = "0";
                objWinNumber.lasuerte = "0";
            }
            objWinNumber.date = date;

            if (lotery == "Nacional - Noche")
            {
                objWinNumber.nacional = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "Leidsa - Noche")
            {
                objWinNumber.leidsa = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "Loteka - Noche")
            {
                objWinNumber.loteka = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "Gana mas - Tarde")
            {
                objWinNumber.ganamas = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "Real - Tarde")
            {
                objWinNumber.real = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "NewYork Tarde - Tarde")
            {
                objWinNumber.newyorktarde = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "NewYork Noche - Noche")
            {
                objWinNumber.newyorknoche = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "Florida Dia - Tarde")
            {
                objWinNumber.floridadia = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "Florida Noche - Noche")
            {
                objWinNumber.floridanoche = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "La Primera - Tarde")
            {
                objWinNumber.laprimera = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }
            else if (lotery == "La Suerte - Tarde")
            {
                objWinNumber.lasuerte = firstNumber + "-" + secondNumber + "-" + thirdNumber;
            }


            SetResponse response = await client.SetAsync(dbName + "/winNumbers/" + date, objWinNumber);
            WinNumberEntityFirebase data = response.ResultAs<WinNumberEntityFirebase>();


        }
        catch (Exception ex)
        {


        }

    }


    public async void getTicketByUser()
    {

        try
        {
            running = true;
            decimal commisson = 0;
            DateTime dateCurr = DateTime.Now;
            string currentDate = dateCurr.ToString("yyyyMMdd");

            long billID = 0;
            int first = 0;
            int current = 0;
            int detailfirst = 0;
            int detailcurrent = 0;
            string currentBillID = "";
            long currentTransactionID = 0;

            try
            {
                updateServerData();


                FirebaseResponse response;
                TicketEntityFirebase obj = new TicketEntityFirebase();
                BalanceFirebaseEntity objBalance = new BalanceFirebaseEntity();

                TransactionsDAL transactionsDAL = new TransactionsDAL();
                TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();


                FirebaseResponse currentNumber = client.Get(dbName + "/banking/" + user + "/counter/" + "currentNumber");
                CounterTicketEntity objCounter = currentNumber.ResultAs<CounterTicketEntity>();

                LotteriesDAL lotteriesDAL = new LotteriesDAL();
                List<LotteriesDAL> listLotery;

                int firstCount = 0;
                if (objCounter != null)
                {
                    first = Convert.ToInt32(objCounter.first);
                    current = Convert.ToInt32(objCounter.number);

                    for (int i = first; i < current; i++)
                    {
                        response = client.Get(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + i.ToString());
                        obj = response.ResultAs<TicketEntityFirebase>();
                        if (obj != null)
                        {
                            if (firstCount == 0)
                            {
                                objCounter.first = i.ToString();
                                firstCount = i;

                                SetResponse setCount = client.Set(dbName + "/banking/" + user + "/counter/" + "currentNumber", objCounter);
                                CounterTicketEntity setC = setCount.ResultAs<CounterTicketEntity>();
                                Thread.Sleep(1000);
                            }



                            if (obj.registrationStatus == "Pendiente" || obj.registrationStatus == "Cancelado")
                            {
                                currentBillID = i.ToString();
                                lotteriesDAL.LotteryID = Convert.ToInt32(obj.loteryID);
                                listLotery = lotteriesDAL.Search();

                                transactionsDAL.Amount = Convert.ToDecimal(obj.amount);
                                transactionsDAL.Amount = Math.Abs(transactionsDAL.Amount);
                                transactionsDAL.UserName = user;
                                transactionsDAL.LotteryName = listLotery[0].Name;
                                transactionsDAL.ShiftName = listLotery[0].ShiftName;
                                transactionsDAL.CustomerID = 0;
                                transactionsDAL.TicketID = obj.billID;
                                if (obj.registrationStatus == "Cancelado")
                                {
                                    transactionsDAL.TransactionStatusName = "CANCELED";
                                }
                                else
                                {
                                    transactionsDAL.TransactionStatusName = "PLAYED";
                                }


                                if (transactionsDAL.Insert())
                                {

                                    billID = transactionsDAL.TransactionID;
                                    currentTransactionID = transactionsDAL.TransactionID;

                                    if (obj.registrationStatus == "Cancelado")
                                    {
                                        obj.registrationStatus = "Cancelado";
                                    }
                                    else
                                    {
                                        obj.registrationStatus = "Sincronizado";
                                    }


                                    obj.transactionID = billID.ToString();

                                    SetResponse setTicketStatus = client.Set(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + i.ToString(), obj);
                                    TicketEntityFirebase data = setTicketStatus.ResultAs<TicketEntityFirebase>();
                                    Thread.Sleep(1000);

                                    currentNumber = client.Get(dbName + "/banking/" + user + "/counter/" + "currentNumber");
                                    objCounter = currentNumber.ResultAs<CounterTicketEntity>();
                                    objCounter.first = (Convert.ToInt32(obj.billID) + 1).ToString();


                                    SetResponse setCounter = client.Set(dbName + "/banking/" + user + "/counter/" + "currentNumber", objCounter);
                                    CounterTicketEntity setCounterob = setCounter.ResultAs<CounterTicketEntity>();
                                    Thread.Sleep(1000);

                                    updateTicketCommission(currentBillID, user, currentDate, currentTransactionID);
                                    updateBalance(user, userID, lastPaymentDate, lastCommissionDate);
                                    updateBalanceTotal();

                                }

                            }



                        }
                    }

                    getDetailByUser(user);
                }
            }
            catch (Exception)
            {


            }

        }
        catch (Exception ex)
        {



        }
        Thread.Sleep(3000);
        updateDetailTicketsByUser(user);

        running = false;
    }

    public async void getDetailByUser(string user)
    {

        try
        {
            decimal commisson = 0;
            bool setDetail = false;
            DateTime dateCurr = DateTime.Now;
            string currentDate = dateCurr.ToString("yyyyMMdd");

            long billID = 0;
            int detailfirst = 0;
            int detailcurrent = 0;

            try
            {
                FirebaseResponse response;
                TicketEntityFirebase obj = new TicketEntityFirebase();
                TicketDetailEntityFirebase objDetail = new TicketDetailEntityFirebase();
                BalanceFirebaseEntity objBalance = new BalanceFirebaseEntity();

                TransactionsDAL transactionsDAL = new TransactionsDAL();
                TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();

                FirebaseResponse detailCurrentNumber = client.Get(dbName + "/banking/" + user + "/counterDetail/" + "currentNumber");
                CounterDetailTicketEntity detailObjCounter = detailCurrentNumber.ResultAs<CounterDetailTicketEntity>();

                LotteriesDAL lotteriesDAL = new LotteriesDAL();
                List<LotteriesDAL> listLotery;
                if (detailObjCounter != null)
                {
                    detailfirst = Convert.ToInt32(detailObjCounter.first);
                    detailcurrent = Convert.ToInt32(detailObjCounter.number);
                    if (detailfirst < 0)
                        detailfirst = 0;

                    for (int d = detailfirst; d < detailcurrent; d++)
                    {
                        response = client.Get(dbName + "/banking/" + user + "/details/" + currentDate + "/" + d.ToString());
                        objDetail = response.ResultAs<TicketDetailEntityFirebase>();
                        Thread.Sleep(1000);
                        if (objDetail != null)
                        {
                            if (objDetail.registrationStatus == "Pendiente")
                            {

                                response = client.Get(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + objDetail.billID);
                                obj = response.ResultAs<TicketEntityFirebase>();

                                if (obj != null)
                                {
                                    if (obj.registrationStatus == "Sincronizado" || obj.registrationStatus == "Cancelado")
                                    {
                                        lotteriesDAL.LotteryID = Convert.ToInt32(obj.loteryID);
                                        listLotery = lotteriesDAL.Search();

                                        transactionDetailsDAL.TransactionID = Convert.ToInt64(obj.transactionID);
                                        transactionDetailsDAL.LotteryName = listLotery[0].Name;
                                        transactionDetailsDAL.ShiftName = listLotery[0].ShiftName;
                                        transactionDetailsDAL.PlayTypeName = getPlayType(objDetail.playType);
                                        transactionDetailsDAL.Numbers = objDetail.number.Replace("-", "");
                                        transactionDetailsDAL.Amount = Convert.ToDecimal(objDetail.amount);
                                        transactionDetailsDAL.Amount = Math.Abs(transactionDetailsDAL.Amount);
                                        transactionDetailsDAL.TicketDetailID = objDetail.ID;

                                        if (transactionDetailsDAL.Insert())
                                        {

                                            objDetail.registrationStatus = "Sincronizado";

                                            SetResponse setTicketDetail = await client.SetAsync(dbName + "/banking/" + user + "/details/" + currentDate + "/" + d.ToString(), objDetail);
                                            TicketDetailEntityFirebase setBillDetail = setTicketDetail.ResultAs<TicketDetailEntityFirebase>();
                                            Thread.Sleep(1000);

                                            detailCurrentNumber = client.Get(dbName + "/banking/" + user + "/counterDetail/" + "currentNumber");
                                            detailObjCounter = detailCurrentNumber.ResultAs<CounterDetailTicketEntity>();

                                            detailObjCounter.first = (Convert.ToInt32(objDetail.ID) + 1).ToString();

                                            SetResponse setCounter = client.Set(dbName + "/banking/" + user + "/counterDetail/" + "currentNumber", detailObjCounter);
                                            CounterDetailTicketEntity setCounterDetail = setCounter.ResultAs<CounterDetailTicketEntity>();
                                            Thread.Sleep(1000);
                                        }
                                    }


                                }


                            }

                        }


                    }
                    updateBalance(user, userID, lastPaymentDate, lastCommissionDate);
                    updateBalanceTotal();
                }

            }
            catch (Exception)
            {


            }






        }
        catch (Exception ex)
        {



        }

        running = false;
    }

    public async void getTicketFirebaseByUser()
    {

        try
        {
            running = true;
            decimal commisson = 0;
            bool setDetail = false;
            DateTime dateCurr = DateTime.Now;
            string currentDate = dateCurr.ToString("yyyyMMdd");

            long billID = 0;
            int first = 0;
            int current = 0;
            int detailfirst = 0;
            int detailcurrent = 0;
            string currentBillID = "";
            long currentTransactionID = 0;

            try
            {
                FirebaseResponse response;
                TicketEntityFirebase obj = new TicketEntityFirebase();
                TicketDetailEntityFirebase objDetail = new TicketDetailEntityFirebase();
                BalanceFirebaseEntity objBalance = new BalanceFirebaseEntity();

                TransactionsDAL transactionsDAL = new TransactionsDAL();
                TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();


                FirebaseResponse currentNumber = client.Get(dbName + "/banking/" + user + "/counter/" + "currentNumber");
                CounterTicketEntity objCounter = currentNumber.ResultAs<CounterTicketEntity>();

                FirebaseResponse detailCurrentNumber = client.Get(dbName + "/banking/" + user + "/counterDetail/" + "currentNumber");
                CounterDetailTicketEntity detailObjCounter = detailCurrentNumber.ResultAs<CounterDetailTicketEntity>();

                LotteriesDAL lotteriesDAL = new LotteriesDAL();
                List<LotteriesDAL> listLotery;

                int firstCount = 0;
                if (objCounter != null)
                {
                    first = Convert.ToInt32(objCounter.first);
                    current = Convert.ToInt32(objCounter.number);

                    for (int i = first; i < current; i++)
                    {
                        response = client.Get(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + i.ToString());
                        obj = response.ResultAs<TicketEntityFirebase>();
                        if (obj != null)
                        {
                            if (firstCount == 0)
                            {
                                objCounter.first = i.ToString();
                                firstCount = i;

                                SetResponse setCount = client.Set(dbName + "/banking/" + user + "/counter/" + "currentNumber", objCounter);
                                CounterTicketEntity setC = setCount.ResultAs<CounterTicketEntity>();
                                Thread.Sleep(1000);
                            }



                            if (obj.registrationStatus == "Pendiente" || obj.registrationStatus == "Cancelado")
                            {
                                currentBillID = i.ToString();
                                lotteriesDAL.LotteryID = Convert.ToInt32(obj.loteryID);
                                listLotery = lotteriesDAL.Search();

                                transactionsDAL.Amount = Convert.ToDecimal(obj.amount);
                                transactionsDAL.UserName = user;
                                transactionsDAL.LotteryName = listLotery[0].Name;
                                transactionsDAL.ShiftName = listLotery[0].ShiftName;
                                transactionsDAL.CustomerID = 0;
                                transactionsDAL.TicketID = obj.billID;
                                if (obj.registrationStatus == "Cancelado")
                                {
                                    transactionsDAL.TransactionStatusName = "CANCELED";
                                }
                                else
                                {
                                    transactionsDAL.TransactionStatusName = "PLAYED";
                                }


                                if (transactionsDAL.Insert())
                                {

                                    billID = transactionsDAL.TransactionID;
                                    currentTransactionID = transactionsDAL.TransactionID;

                                    if (obj.registrationStatus == "Cancelado")
                                    {
                                        obj.registrationStatus = "Cancelado";
                                    }
                                    else
                                    {
                                        obj.registrationStatus = "Sincronizado";
                                    }


                                    obj.transactionID = billID.ToString();
                                    objCounter.first = (Convert.ToInt32(obj.billID) + 1).ToString();

                                    SetResponse setTicketStatus = client.Set(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + i.ToString(), obj);
                                    TicketEntityFirebase data = setTicketStatus.ResultAs<TicketEntityFirebase>();
                                    Thread.Sleep(1000);

                                    SetResponse setCounter = client.Set(dbName + "/banking/" + user + "/counter/" + "currentNumber", objCounter);
                                    CounterTicketEntity setCounterob = setCounter.ResultAs<CounterTicketEntity>();
                                    Thread.Sleep(1500);


                                    detailfirst = Convert.ToInt32(detailObjCounter.first);
                                    detailcurrent = Convert.ToInt32(detailObjCounter.number);

                                    for (int d = detailfirst; d < detailcurrent; d++)
                                    {
                                        response = client.Get(dbName + "/banking/" + user + "/details/" + currentDate + "/" + d.ToString());
                                        objDetail = response.ResultAs<TicketDetailEntityFirebase>();
                                        Thread.Sleep(1000);
                                        if (objDetail != null)
                                        {
                                            if (objDetail.registrationStatus == "Pendiente")
                                            {
                                                if (Convert.ToInt64(objDetail.billID) == Convert.ToInt64(obj.billID))
                                                {
                                                    transactionDetailsDAL.TransactionID = billID;
                                                    transactionDetailsDAL.LotteryName = listLotery[0].Name;
                                                    transactionDetailsDAL.ShiftName = listLotery[0].ShiftName;
                                                    transactionDetailsDAL.PlayTypeName = getPlayType(objDetail.playType);
                                                    transactionDetailsDAL.Numbers = objDetail.number.Replace("-", "");
                                                    transactionDetailsDAL.Amount = Convert.ToDecimal(objDetail.amount);
                                                    transactionDetailsDAL.TicketDetailID = objDetail.ID;

                                                    if (transactionDetailsDAL.Insert())
                                                    {

                                                        detailObjCounter.first = (Convert.ToInt32(objDetail.ID) + 1).ToString();
                                                        objDetail.registrationStatus = "Sincronizado";

                                                        SetResponse setTicketDetail = client.Set(dbName + "/banking/" + user + "/details/" + currentDate + "/" + d.ToString(), objDetail);
                                                        TicketDetailEntityFirebase setBillDetail = setTicketDetail.ResultAs<TicketDetailEntityFirebase>();
                                                        Thread.Sleep(1000);

                                                        SetResponse setCounterDet = await client.SetAsync(dbName + "/banking/" + user + "/counterDetail/" + "currentNumber", detailObjCounter);
                                                        CounterDetailTicketEntity setDetailCounter = setCounterDet.ResultAs<CounterDetailTicketEntity>();
                                                        Thread.Sleep(1000);
                                                    }


                                                }
                                            }

                                        }


                                    }
                                    updateTicketCommission(currentBillID, user, currentDate, currentTransactionID);
                                    updateBalance(user, userID, lastPaymentDate, lastCommissionDate);
                                    updateBalanceTotal();

                                }

                            }



                        }
                    }
                }
            }
            catch (Exception)
            {


            }

        }
        catch (Exception ex)
        {



        }
        Thread.Sleep(1000);
        updateDetailTicketsByUser(user);

        running = false;
    }

    public async void updateDetailTicketsByUser(string user)
    {

        try
        {
            decimal commisson = 0;
            bool setDetail = false;
            DateTime dateCurr = DateTime.Now;
            string currentDate = dateCurr.ToString("yyyyMMdd");

            long billID = 0;
            int detailfirst = 0;
            int detailcurrent = 0;

            try
            {
                FirebaseResponse response;
                TicketEntityFirebase obj = new TicketEntityFirebase();
                TicketDetailEntityFirebase objDetail = new TicketDetailEntityFirebase();
                BalanceFirebaseEntity objBalance = new BalanceFirebaseEntity();

                TransactionsDAL transactionsDAL = new TransactionsDAL();
                TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();

                FirebaseResponse detailCurrentNumber = client.Get(dbName + "/banking/" + user + "/counterDetail/" + "currentNumber");
                CounterDetailTicketEntity detailObjCounter = detailCurrentNumber.ResultAs<CounterDetailTicketEntity>();

                LotteriesDAL lotteriesDAL = new LotteriesDAL();
                List<LotteriesDAL> listLotery;
                if (detailObjCounter != null)
                {
                    detailfirst = Convert.ToInt32(detailObjCounter.first) - 10;
                    detailcurrent = Convert.ToInt32(detailObjCounter.number);
                    if (detailfirst < 0)
                        detailfirst = 0;

                    for (int d = detailfirst; d < detailcurrent; d++)
                    {
                        response = client.Get(dbName + "/banking/" + user + "/details/" + currentDate + "/" + d.ToString());
                        objDetail = response.ResultAs<TicketDetailEntityFirebase>();
                        Thread.Sleep(1000);
                        if (objDetail != null)
                        {
                            if (objDetail.registrationStatus == "Pendiente")
                            {

                                response = client.Get(dbName + "/banking/" + user + "/tickets/" + currentDate + "/" + objDetail.billID);
                                obj = response.ResultAs<TicketEntityFirebase>();

                                if (obj != null)
                                {
                                    if (obj.registrationStatus == "Sincronizado")
                                    {
                                        lotteriesDAL.LotteryID = Convert.ToInt32(obj.loteryID);
                                        listLotery = lotteriesDAL.Search();

                                        transactionDetailsDAL.TransactionID = Convert.ToInt64(obj.transactionID);
                                        transactionDetailsDAL.LotteryName = listLotery[0].Name;
                                        transactionDetailsDAL.ShiftName = listLotery[0].ShiftName;
                                        transactionDetailsDAL.PlayTypeName = getPlayType(objDetail.playType);
                                        transactionDetailsDAL.Numbers = objDetail.number.Replace("-", "");
                                        transactionDetailsDAL.Amount = Convert.ToDecimal(objDetail.amount);
                                        transactionDetailsDAL.TicketDetailID = objDetail.ID;

                                        if (transactionDetailsDAL.Insert())
                                        {

                                            objDetail.registrationStatus = "Sincronizado";

                                            SetResponse setTicketDetail = await client.SetAsync(dbName + "/banking/" + user + "/details/" + currentDate + "/" + d.ToString(), objDetail);
                                            TicketDetailEntityFirebase setBillDetail = setTicketDetail.ResultAs<TicketDetailEntityFirebase>();
                                            Thread.Sleep(1000);


                                        }
                                    }


                                }


                            }

                        }


                    }
                }

            }
            catch (Exception)
            {


            }






        }
        catch (Exception ex)
        {



        }

        running = false;
    }

    public async void updateTicketCommission(string billID, string user, string date, long transactionID)
    {
        try
        {
            TransactionsDAL tDAL = new TransactionsDAL();
            List<TransactionsDAL> list = new List<TransactionsDAL>();
            tDAL.TransactionID = transactionID;
            list = tDAL.Search();
            if (list.Count > 0)
            {
                FirebaseResponse response;
                TicketEntityFirebase obj = new TicketEntityFirebase();
                response = client.Get(dbName + "/banking/" + user + "/tickets/" + date + "/" + billID);
                obj = response.ResultAs<TicketEntityFirebase>();
                obj.commission = list[0].Commission.ToString("N2").Replace(",", "");

                SetResponse setTicketCommission = await client.SetAsync(dbName + "/banking/" + user + "/tickets/" + date + "/" + billID, obj);
                TicketEntityFirebase data = setTicketCommission.ResultAs<TicketEntityFirebase>();
            }
            tDAL = null;
            list = null;



        }
        catch (Exception ex)
        {


        }

    }

    public void insertTicket(string date)
    {
        //SetResponse setTicket = client.Set(dbName + "/banking/" + userTicket + "/record/tickets/" + dateTicket.ToString("ddMMyyyy") + "/" + ticket.billID, ticket);
        SetResponse setTicket = client.Set(dbName + "/banking/" + userTicket + "/tickets/" + date + "/" + ticket.billID, ticket);
        TicketEntityFirebase data = setTicket.ResultAs<TicketEntityFirebase>();
        Thread.Sleep(1000);
    }

    public async void insertTicketDetail(string date)
    {
        //SetResponse setTicketDetail = await client.SetAsync(dbName + "/banking/" + userTicketDetail + "/record/details/" + dateTicketDetail.ToString("ddMMyyyy") + "/" + ticketDetail.ID, ticketDetail);
        SetResponse setTicketDetail = await client.SetAsync(dbName + "/banking/" + userTicketDetail + "/details/" + date + "/" + ticketDetail.ID, ticketDetail);
        TicketDetailEntityFirebase data = setTicketDetail.ResultAs<TicketDetailEntityFirebase>();
        //Thread.Sleep(1000);
    }

    public void insertWinTicket()
    {
        SetResponse setTicket = client.Set(dbName + "/banking/" + userTicket + "/win/tickets/" + dateTicket.ToString("ddMMyyyy") + "/" + ticket.billID, ticket);
        TicketEntityFirebase data = setTicket.ResultAs<TicketEntityFirebase>();
        Thread.Sleep(1000);
    }

    public async void insertWinTicketDetail()
    {
        SetResponse setTicketDetail = await client.SetAsync(dbName + "/banking/" + userTicketDetail + "/win/details/" + dateTicketDetail.ToString("ddMMyyyy") + "/" + ticketDetail.ID, ticketDetail);
        TicketDetailEntityFirebase data = setTicketDetail.ResultAs<TicketDetailEntityFirebase>();
        //Thread.Sleep(1000);
    }


    public bool cancelTicket(string ticketID, string user)
    {
        bool result = false;
        try
        {

            TransactionsDAL transactionsModel = new TransactionsDAL();
            transactionsModel.TransactionID = Convert.ToInt64(ticketID);
            transactionsModel.UserName = user;
            transactionsModel.IsMobil = true;
            if (transactionsModel.CancelTicket())
            {
                result = true;
            }
            else
                result = false;
        }
        catch (Exception)
        {


        }




        return result;
    }

    public void cancelTicketsFirebase()
    {
        try
        {
            DateTime dateCurr = DateTime.Now;
            string currentDate = dateCurr.ToString("yyyyMMdd");
            UsersDAL usersDAL = new UsersDAL();
            List<UsersDAL> usersList = new List<UsersDAL>();
            usersList = usersDAL.Search();
            decimal commisson = 0;
            bool setDetail = false;
            int first = 0;
            int current = 0;
            runningCancel = true;
            foreach (UsersDAL item in usersList)
            {
                FirebaseResponse response;
                TicketEntityFirebase obj = new TicketEntityFirebase();

                FirebaseResponse currentNumber = client.Get(dbName + "/banking/" + item.Name + "/counter/" + "currentNumber");
                CounterTicketEntity objCounter = currentNumber.ResultAs<CounterTicketEntity>();

                if (objCounter != null)
                {
                    first = Convert.ToInt32(objCounter.first) - 20;
                    current = Convert.ToInt32(objCounter.number);

                    if (first < 0)
                        first = 0;

                    for (int i = first; i < current; i++)
                    {
                        response = client.Get(dbName + "/banking/" + item.Name + "/tickets/" + currentDate + "/" + i.ToString());
                        obj = response.ResultAs<TicketEntityFirebase>();
                        if (obj != null)
                        {
                            if (obj.registrationStatus == "Cancelado")
                            {
                                if (!string.IsNullOrEmpty(obj.transactionID))
                                {
                                    cancelTicket(obj.transactionID, item.Name);
                                }
                            }
                        }
                    }
                }
            }
            runningCancel = false;
        }
        catch (Exception)
        {

            runningCancel = false;
        }
    }



    private string getPlayType(string playT)
    {
        string playType = playT;

        if (playT == "Qn")
        {
            playType = "Quiniela";
        }
        else if (playT == "Pl")
        {
            playType = "Pale";
        }
        else if (playT == "Tp")
        {
            playType = "Tripleta";
        }

        return playType;
    }

   
    public void updateBalanceTotal()
    {
        try
        {
            decimal commission = 0;
            decimal amount = 0;
            decimal gainAmount = 0;
            decimal total = 0;
            decimal free = 0;

            decimal dailycommission = 0;
            decimal dailyamount = 0;
            decimal dailygainAmount = 0;
            decimal dailytotal = 0;
            decimal dailyfree = 0;

            decimal redamount = 0;
            decimal loanamount = 0;

            decimal totalAll = 0;
            decimal gainAll = 0;
            decimal commissionAll = 0;
            decimal freeAll = 0;

            TransactionsDAL transactionsDAL = new TransactionsDAL();
            List<TransactionsDAL> list = new List<TransactionsDAL>();
            BalanceFirebaseEntity objBalance;


            UsersDAL usersDAL = new UsersDAL();
            List<UsersDAL> usersDALList = new List<UsersDAL>();
            usersDALList = usersDAL.Search();

            foreach (UsersDAL itemUser in usersDALList)
            {
                list = new List<TransactionsDAL>();
                transactionsDAL.StartTime = itemUser.LastPaymentDate;
                transactionsDAL.EndTime = DateTime.Now;
                transactionsDAL.UserName = itemUser.Name;
                transactionsDAL.CustomerID = -1;

                list = transactionsDAL.Search(true);

                foreach (TransactionsDAL item in list)
                {
                    if (item.TransactionStatusName != "Ticket Cancelado")
                    {
                        //commission = commission + item.Commission;
                        amount = amount + item.Amount;
                        gainAmount = gainAmount + item.TotalGainAmount;
                        free = free + item.Discount;

                        if (item.Date.ToShortDateString() == DateTime.Now.ToShortDateString())
                        {
                            dailycommission = dailycommission + item.Commission;
                            dailyamount = dailyamount + item.Amount;
                            dailygainAmount = dailygainAmount + item.TotalGainAmount;
                            dailyfree = dailyfree + item.Discount;
                        }
                    }
                }

                //buscando la commission acumulada
                transactionsDAL = new TransactionsDAL();
                transactionsDAL.UserName = itemUser.Name;
                transactionsDAL.StartTime = itemUser.LastCommissionDate;
                transactionsDAL.EndTime = DateTime.Now;
                transactionsDAL.CustomerID = -1;
                list = transactionsDAL.Search(true);

                foreach (TransactionsDAL item in list)
                {
                    if (item.TransactionStatusName != "Ticket Cancelado")
                    {
                        commission = commission + item.Commission;
                    }
                }
            }



            //buscando balance rojo
            transactionsDAL = new TransactionsDAL();
            transactionsDAL.StartTime = DateTime.Now.AddYears(-50);
            transactionsDAL.EndTime = DateTime.Now;
            transactionsDAL.CustomerID = -1;
            list = transactionsDAL.Search(true);

            foreach (TransactionsDAL item in list)
            {
                if (item.TransactionStatusName != "Ticket Cancelado")
                {
                    totalAll = totalAll + item.Amount;
                    commissionAll = commissionAll + item.Commission;
                    gainAll = gainAll + item.TotalGainAmount;
                    freeAll = freeAll + item.Discount;
                }
            }



            total = (amount) - gainAmount - commission - free;
            dailytotal = (dailyamount) - dailygainAmount - dailycommission - dailyfree;
            redamount = totalAll - (commissionAll + gainAll + freeAll);
            loanamount = getLoanAmountAllUser();

            objBalance = new BalanceFirebaseEntity();
            objBalance.commission = commission.ToString("N2").Replace(",", "");
            objBalance.amount = amount.ToString("N2").Replace(",", "");
            objBalance.gainAmount = gainAmount.ToString("N2").Replace(",", "");
            objBalance.free = free.ToString("N2").Replace(",", "");
            objBalance.total = total.ToString("N2").Replace(",", "");

            objBalance.dailycommission = dailycommission.ToString("N2").Replace(",", "");
            objBalance.dailyamount = dailyamount.ToString("N2").Replace(",", "");
            objBalance.dailygainAmount = dailygainAmount.ToString("N2").Replace(",", "");
            objBalance.dailyfree = dailyfree.ToString("N2").Replace(",", "");
            objBalance.dailytotal = dailytotal.ToString("N2").Replace(",", "");

            objBalance.redamount = redamount.ToString("N2").Replace(",", "");
            objBalance.loanamount = loanamount.ToString("N2").Replace(",", "");

            SetResponse setB = client.Set(dbName + "/balance/" + "total" + "/" + "200", objBalance);
            BalanceFirebaseEntity setBalance = setB.ResultAs<BalanceFirebaseEntity>();
        }
        catch (Exception)
        {


        }


    }

    public decimal getLoanAmountByUser(string userID)
    {
        int employeeID = 0;
        decimal loanAmount = 0;

        UsersDAL usersDAL = new UsersDAL();
        List<UsersDAL> usersListDAL = new List<UsersDAL>();
        usersDAL.UserID = Convert.ToInt32(userID);
        usersListDAL = usersDAL.Search();

        if (usersListDAL.Count > 0)
        {
            employeeID = usersListDAL[0].EmployeeID;

            LoanDAL loanDAL = new LoanDAL();
            List<LoanDAL> loanListDAL = new List<LoanDAL>();
            loanDAL.EmployeeID = employeeID;
            loanListDAL = loanDAL.Search();

            foreach (LoanDAL item in loanListDAL)
            {
                if (item.Status != "Cancelado")
                {
                    loanAmount = loanAmount + item.DueAmount;
                }
            }

        }


        return loanAmount;
    }

    public decimal getLoanAmountAllUser()
    {
        int employeeID = 0;
        decimal loanAmount = 0;

        UsersDAL usersDAL = new UsersDAL();
        List<UsersDAL> usersListDAL = new List<UsersDAL>();
        usersListDAL = usersDAL.Search();

        foreach (UsersDAL itemU in usersListDAL)
        {
            employeeID = itemU.EmployeeID;

            LoanDAL loanDAL = new LoanDAL();
            List<LoanDAL> loanListDAL = new List<LoanDAL>();
            loanDAL.EmployeeID = employeeID;
            loanListDAL = loanDAL.Search();

            foreach (LoanDAL item in loanListDAL)
            {
                if (item.Status != "Cancelado")
                {
                    loanAmount = loanAmount + item.DueAmount;
                }
            }
        }



        return loanAmount;
    }

   
    public void getBalance(string user, string userID)
    {
        amountB = 0;
        commissionB = 0;
        gainAmountB = 0;
        totalB = 0;
        freeB = 0;
        existUser = false;

        BalanceFirebaseEntity objBalance;
        objBalance = new BalanceFirebaseEntity();
        FirebaseResponse response;

        response = client.Get(dbName + "/balance/" + user + "/" + userID);
        objBalance = response.ResultAs<BalanceFirebaseEntity>();

        if (objBalance != null)
        {
            decimal.TryParse(objBalance.amount, out amountB);
            decimal.TryParse(objBalance.commission, out commissionB);
            decimal.TryParse(objBalance.gainAmount, out gainAmountB);
            decimal.TryParse(objBalance.free, out freeB);
            decimal.TryParse(objBalance.total, out totalB);
            existUser = true;
        }

        response = null;
        objBalance = null;


    }

    public string getCountUser(string user)
    {
        string count = "";

        try
        {

            FirebaseResponse currentNumber = client.Get(dbName + "/banking/" + user + "/counter/" + "currentNumber");
            CounterTicketEntity objCounter = currentNumber.ResultAs<CounterTicketEntity>();

            FirebaseResponse detailCurrentNumber = client.Get(dbName + "/banking/" + user + "/counterDetail/" + "currentNumber");
            CounterDetailTicketEntity detailObjCounter = detailCurrentNumber.ResultAs<CounterDetailTicketEntity>();

            count = "Tickets: " + objCounter.first + "/" + objCounter.number + "    Details: " + detailObjCounter.first + "/" + detailObjCounter.number;
        }
        catch (Exception ex)
        {

            count = "Tickets: 0/0    Details: 0/0";
        }



        return count;
    }


    public void getUserStatus(string user, string userID)
    {
        enabledUser = false;

        UserFirebaseEntity objUser;
        objUser = new UserFirebaseEntity();
        FirebaseResponse response;

        response = client.Get(dbName + "/users/" + userID);
        objUser = response.ResultAs<UserFirebaseEntity>();

        if (objUser != null)
        {
            if (objUser.enabled == "True")
                enabledUser = true;
            else
                enabledUser = false;
        }

        response = null;
        objUser = null;


    }

    public void createUserMovil(string user, string userID, string pass, string branche, string employee)
    {
        UserFirebaseEntity objUser;
        objUser = new UserFirebaseEntity();
        objUser.commission = "20";
        objUser.pass = pass;
        objUser.user = user;
        objUser.enabled = "True";
        objUser.id = userID;
        objUser.header = "";
        objUser.onlyBalance = "False";
        objUser.branche = branche;
        objUser.employee = employee;
        objUser.printername = "";
        SetResponse setUser = client.Set(dbName + "/users/" + userID, objUser);
        UserFirebaseEntity setU = setUser.ResultAs<UserFirebaseEntity>();
        Thread.Sleep(1000);

        //BalanceFirebaseEntity objBalance;
        //objBalance = new BalanceFirebaseEntity();
        //objBalance.commission = "0.00";
        //objBalance.amount = "0.00";
        //objBalance.gainAmount = "0.00";
        //objBalance.total = "0.00";

        //objBalance.dailycommission = "0.00";
        //objBalance.dailyamount = "0.00";
        //objBalance.dailygainAmount = "0.00";
        //objBalance.dailytotal = "0.00";

        //objBalance.loanamount = "0.00";
        //objBalance.redamount = "0.00";

        //SetResponse setB = client.Set(dbName + "/balance/" + user + "/" + userID, objBalance);
        //BalanceFirebaseEntity setBalance = setB.ResultAs<BalanceFirebaseEntity>();
        //Thread.Sleep(1000);

        CounterTicketEntity objCounter;
        objCounter = new CounterTicketEntity();
        objCounter.first = "100";
        objCounter.number = "100";
        SetResponse setCounter = client.Set(dbName + "/banking/" + user + "/counter/" + "currentNumber", objCounter);
        CounterTicketEntity setCounterob = setCounter.ResultAs<CounterTicketEntity>();
        Thread.Sleep(1000);

        CounterDetailTicketEntity objCounterDetail;
        objCounterDetail = new CounterDetailTicketEntity();
        objCounterDetail.first = "1";
        objCounterDetail.number = "1";
        SetResponse setCounterD = client.Set(dbName + "/banking/" + user + "/counterDetail/" + "currentNumber", objCounterDetail);
        CounterDetailTicketEntity setCounterobD = setCounterD.ResultAs<CounterDetailTicketEntity>();

    }

    public async void createVersion()
    {
        VersionEntityFirebase objVersion = new VersionEntityFirebase();

        objVersion.company = ConfigurationManager.AppSettings["CompanyName"].ToString();
        objVersion.company2 = "";
        objVersion.fontsize = "28";
        objVersion.fontsizesubtittle = "14";
        objVersion.fontsizetittle = "18";
        objVersion.padr = "4";
        objVersion.padr2 = "14";
        objVersion.urlVersion = "";
        objVersion.versionNumber = "v1.0.0";
        objVersion.fontsizetotal = "14";
        objVersion.timecancel = "5";
        objVersion.phone = "";

        SetResponse setVersion = await client.SetAsync(dbName + "/version/1", objVersion);
        VersionEntityFirebase setV = setVersion.ResultAs<VersionEntityFirebase>();


    }

    public void enabledUserFirebase(string user, string userID, string pass, string enabled)
    {
        UserFirebaseEntity objUser;
        objUser = new UserFirebaseEntity();
        objUser.commission = "20";
        objUser.pass = pass;
        objUser.user = user;
        objUser.enabled = enabled;
        objUser.header = "";
        objUser.onlyBalance = "False";
        SetResponse setUser = client.Set(dbName + "/users/" + userID, objUser);
        UserFirebaseEntity setU = setUser.ResultAs<UserFirebaseEntity>();
        Thread.Sleep(1000);


    }

    public async void updateServerData()
    {

        try
        {
            ServerDataEntityFirebase objServerData = new ServerDataEntityFirebase();
            DateTime currentD = DateTime.Now;


            objServerData.shortdate = currentD.ToString("yyyyMMdd");
            objServerData.longdate = currentD.ToString("dd/MM/yyyy HH:mm:ss");
            objServerData.hhmmss = currentD.ToString("HH:mm");


            SetResponse setServerData = await client.SetAsync(dbName + "/ServerData/1", objServerData);
            ServerDataEntityFirebase setD = setServerData.ResultAs<ServerDataEntityFirebase>();


        }
        catch (Exception ex)
        {

        }

    }


    public async void listenEvent()
    {

        response = await client.OnAsync(dbName + "/loans", (sender, args, context) =>
        {
            if (canContinue)
            {


                canContinue = false;
            }
        });
    }

    public async void deleteDataUsers(string user)
    {
        try
        {

            FirebaseResponse response = await client.DeleteAsync(dbName + "/banking/" + user + "/" + "tickets");
            FirebaseResponse responseD = await client.DeleteAsync(dbName + "/banking/" + user + "/" + "details");

        }
        catch (Exception ex)
        {


        }

    }

    public async void deleteDetailsAll()
    {
        try
        {

            FirebaseResponse response = await client.DeleteAsync(dbName + "/banking/" + "details");

        }
        catch (Exception ex)
        {


        }

    }

    public void GetAllUsers()
    {


        TicketEntityFirebase objUser;
        objUser = new TicketEntityFirebase();
        FirebaseResponse response;
        List<TicketEntityFirebase> list = new List<TicketEntityFirebase>();
        response = client.Get(dbName + "/banking/01/tickets/20210511");


        /**********Inicio del Nuevo codigo*******************/
        float contConte = 0;
        int entrar = 0;
        string columNombre = "";
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("billID");
        dataTable.Columns.Add("amount");
        dataTable.Columns.Add("commission");
        dataTable.Columns.Add("date");
        dataTable.Columns.Add("loteryID");
        dataTable.Columns.Add("loteryName");
        dataTable.Columns.Add("registrationStatus");
        dataTable.Columns.Add("transactionID");
        dataTable.Columns.Add("winAmount");
        DataRow dataRow = dataTable.NewRow();

        JsonTextReader reader = new JsonTextReader(new StringReader(response.Body));
        try
        {
            while (reader.Read())
            {
                if (reader.TokenType.ToString() == "PropertyName")
                {
                    try
                    {
                        contConte = float.Parse(reader.Value.ToString());
                        entrar++;

                    }
                    catch (Exception)
                    {
                        entrar = 1;
                        columNombre = reader.Value.ToString();
                    }
                }

                if (reader.TokenType.ToString() == "String")
                {
                    dataRow[columNombre] = reader.Value.ToString(); ;
                }
                if (reader.TokenType.ToString() == "EndObject" || entrar == 2)
                {
                    dataTable.Rows.Add(dataRow.ItemArray);
                    entrar = 0;
                }
            }


        }
        catch (Exception ex)
        {

            //throw;
        }
        /**********FIn del Nuevo codigo*******************/
        
        var json_serializer = new JavaScriptSerializer();
        var routes_list = (IDictionary<string, object>)json_serializer.DeserializeObject(response.Body);

        foreach (var entry in routes_list)
        {

            System.Console.WriteLine(entry.Key + ":" + entry.Value);

        }


        //char[] list = response.Body;
        //var model = JsonConvert.DeserializeObject<TicketEntityFirebase>(response.Body);


        objUser = response.ResultAs<TicketEntityFirebase>();

        //if (objUser != null)
        //{
        //    if (objUser.enabled == "True")
        //        enabledUser = true;
        //    else
        //        enabledUser = false;
        //}

        //response = null;
        //objUser = null;


    }

    public void disposeFirebaseStreaming()
    {
        if (response != null)
            response.Dispose();
    }

    public string Decrypt(string textoEncriptado)
    {
        byte[] keyArray;
        //convierte el texto en una secuencia de bytes
        byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

        //se llama a las clases que tienen los algoritmos
        //de encriptación se le aplica hashing
        //algoritmo MD5
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("J"));

        hashmd5.Clear();

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateDecryptor();

        byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

        tdes.Clear();
        //se regresa en forma de cadena
        return UTF8Encoding.UTF8.GetString(resultArray);
    }

}

