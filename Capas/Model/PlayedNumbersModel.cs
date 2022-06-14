using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankingDAL;

namespace BankingModel
{
   public class PlayedNumbersModel
    {
         PlayedNumbersDAL playedNumbersDAL = null;
       public List<PlayedNumbersDAL> playedNumbersListDAL = null;

		private int playedNumberID;
	private DateTime date;
	private string lotteryName;
	private decimal totalAmount;
	private int ticketID;
	private decimal commision;
	private bool enabled;
    private int errorCode = 0;
    private string errorDescription = "successful";
    private string ticketImage;
    public decimal identityID;

    public string TicketImage
    {
        get { return ticketImage; }
        set { ticketImage = value; }
    }

    public int ErrorCode
    {
        get { return errorCode; }
        set { errorCode = value; }
    }
    public string ErrorDescription
    {
        get { return errorDescription; }
        set { errorDescription = value; }
    }

	public int PlayedNumberID
	{
		get { return playedNumberID; }
		set { playedNumberID = value; }
	}
	public DateTime Date
	{
		get { return date; }
		set { date = value; }
	}
	public string LotteryName
	{
		get { return lotteryName; }
		set { lotteryName = value; }
	}
	public decimal TotalAmount
	{
		get { return totalAmount; }
		set { totalAmount = value; }
	}
	public int TicketID
	{
		get { return ticketID; }
		set { ticketID = value; }
	}
	public decimal Commision
	{
		get { return commision; }
		set { commision = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public PlayedNumbersModel(){ }

	public Boolean Insert()
	{
        bool result = false;


        playedNumbersDAL = new PlayedNumbersDAL();
        //playedNumbersDAL.Date = date;
        playedNumbersDAL.LotteryName = lotteryName;
        playedNumbersDAL.TotalAmount = totalAmount;
        playedNumbersDAL.TicketID = ticketID;
        playedNumbersDAL.Commision = commision;
        playedNumbersDAL.TicketImage = ticketImage;
        playedNumbersDAL.Enabled = enabled;

        result = playedNumbersDAL.Insert();

        identityID = playedNumbersDAL.identityID;
        errorCode = playedNumbersDAL.ErrorCode;
        errorDescription = playedNumbersDAL.ErrorDescription;

        playedNumbersDAL = null;

        return result;
	}


	public Boolean Edit()
	{
        bool result = false;


        playedNumbersDAL = new PlayedNumbersDAL();
        playedNumbersDAL.PlayedNumberID = playedNumberID;
        playedNumbersDAL.Date = date;
        playedNumbersDAL.LotteryName = lotteryName;
        playedNumbersDAL.TotalAmount = totalAmount;
        playedNumbersDAL.TicketID = ticketID;
        playedNumbersDAL.Commision = commision;
        playedNumbersDAL.TicketImage = ticketImage;
        playedNumbersDAL.Enabled = enabled;

        result = playedNumbersDAL.Edit();

        errorCode = playedNumbersDAL.ErrorCode;
        errorDescription = playedNumbersDAL.ErrorDescription;

        playedNumbersDAL = null;

        return result;
		
	}


	public Boolean Delete()
	{
        bool result = false;


        playedNumbersDAL = new PlayedNumbersDAL();
        playedNumbersDAL.PlayedNumberID = playedNumberID;

        result = playedNumbersDAL.Delete();

        errorCode = playedNumbersDAL.ErrorCode;
        errorDescription = playedNumbersDAL.ErrorDescription;

        playedNumbersDAL = null;

        return result;
	}


	    public List<PlayedNumbersDAL> Search()
	    {
            playedNumbersDAL = new PlayedNumbersDAL(); ;

            if (playedNumberID > 0)
                playedNumbersDAL.PlayedNumberID = playedNumberID;


            playedNumbersListDAL = new List<PlayedNumbersDAL>();

            playedNumbersListDAL = playedNumbersDAL.Search();

           
            errorCode = playedNumbersDAL.ErrorCode;
            errorDescription = playedNumbersDAL.ErrorDescription;

            playedNumbersDAL = null;

            return playedNumbersListDAL;
		
	    }
    }
}
