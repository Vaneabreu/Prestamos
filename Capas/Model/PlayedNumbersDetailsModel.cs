using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankingModel
{
   public class PlayedNumbersDetailsModel
    {
        PlayedNumbersDetailsDAL playedNumbersDetailsDAL = null;
        public List<PlayedNumbersDetailsDAL> playedNumbersDetailsListDAL = null;

	private long playedNumberDetailID;
	private int playedNumberID;
	private string playTypeName;
	private string numbers;
	private decimal amount;
     private int errorCode = 0;
    private string errorDescription = "successful";

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

	public long PlayedNumberDetailID
	{
		get { return playedNumberDetailID; }
		set { playedNumberDetailID = value; }
	}
	public int PlayedNumberID
	{
		get { return playedNumberID; }
		set { playedNumberID = value; }
	}
	public string PlayTypeName
	{
		get { return playTypeName; }
		set { playTypeName = value; }
	}
	public string Numbers
	{
		get { return numbers; }
		set { numbers = value; }
	}
	public decimal Amount
	{
		get { return amount; }
		set { amount = value; }
	}

	public PlayedNumbersDetailsModel(){ }

	public Boolean Insert()
	{
        bool result = false;

        playedNumbersDetailsDAL = new PlayedNumbersDetailsDAL();
        playedNumbersDetailsDAL.PlayedNumberID = playedNumberID;
        playedNumbersDetailsDAL.PlayTypeName = playTypeName;
        playedNumbersDetailsDAL.Numbers = numbers;
        playedNumbersDetailsDAL.Amount = amount;

        result = playedNumbersDetailsDAL.Insert();

        errorCode = playedNumbersDetailsDAL.ErrorCode;
        errorDescription = playedNumbersDetailsDAL.ErrorDescription;

        playedNumbersDetailsDAL = null;

        return result;
	}


	public Boolean Edit()
	{
        bool result = false;

        playedNumbersDetailsDAL = new PlayedNumbersDetailsDAL();
        playedNumbersDetailsDAL.PlayedNumberDetailID = playedNumberDetailID;
        playedNumbersDetailsDAL.PlayedNumberID = playedNumberID;
        playedNumbersDetailsDAL.PlayTypeName = playTypeName;
        playedNumbersDetailsDAL.Numbers = numbers;
        playedNumbersDetailsDAL.Amount = amount;

        result = playedNumbersDetailsDAL.Edit();

        errorCode = playedNumbersDetailsDAL.ErrorCode;
        errorDescription = playedNumbersDetailsDAL.ErrorDescription;

        playedNumbersDetailsDAL = null;

        return result;
		
	}


	public Boolean Delete()
	{
        bool result = false;

        playedNumbersDetailsDAL = new PlayedNumbersDetailsDAL();
        playedNumbersDetailsDAL.PlayedNumberDetailID = playedNumberDetailID;

        result = playedNumbersDetailsDAL.Delete();

        errorCode = playedNumbersDetailsDAL.ErrorCode;
        errorDescription = playedNumbersDetailsDAL.ErrorDescription;

        playedNumbersDetailsDAL = null;

        return result;
	}


	    public List<PlayedNumbersDetailsDAL> Search()
	    {
            playedNumbersDetailsDAL = new PlayedNumbersDetailsDAL(); ;

            if (playedNumberDetailID > 0)
                playedNumbersDetailsDAL.PlayedNumberDetailID = playedNumberDetailID;
            if (playedNumberID > 0)
                playedNumbersDetailsDAL.PlayedNumberID = playedNumberID;

            playedNumbersDetailsListDAL = new List<PlayedNumbersDetailsDAL>();

            playedNumbersDetailsListDAL = playedNumbersDetailsDAL.Search();

            errorCode = playedNumbersDetailsDAL.ErrorCode;
            errorDescription = playedNumbersDetailsDAL.ErrorDescription;

            playedNumbersDetailsDAL = null;

            return playedNumbersDetailsListDAL;
		
	    }
    }

}
