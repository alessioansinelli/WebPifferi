using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oggetti;
using System.Data;
//using AleDBManager;
using Mercenari.Data;

/// <summary>
/// Summary description for Notizie
/// </summary>
public class Notizie
{

    private TipoOggetto[] _TipoOggetto;
    private bool HomePage = false;
    //private OleDbConnection _Connessione;
    //private OleDbCommand _Command;

    private DataLayer DAL = new DataLayer();

    string sSQL = "";
    public Notizie(TipoOggetto[] TipoObj)
    {
        //_Connessione = Business.ConstWrapper.Connessione;
        _TipoOggetto = TipoObj;
        if (_TipoOggetto.Length == 1 && _TipoOggetto[0] == TipoOggetto.Homepage)
        {
            HomePage = true;
            _TipoOggetto[0] = TipoOggetto.News;
        }
    }

    public Notizie(TipoOggetto _oTipOggetto)
    {
        TipoOggetto[] artpo = new TipoOggetto[1];
        artpo[0] = _oTipOggetto;
        _TipoOggetto = artpo;
        //_Connessione = Business.ConstWrapper.Connessione;
    }

    public Oggetto Get(int iNotizia)
    {

        Oggetto ret = new Oggetto();
        //OleDbManager oDbManager = Business.ConstWrapper.DbManager;

        string sTipoOggetto = "";
        for (int iT = 0; iT < _TipoOggetto.Length; iT++)
        {
            sTipoOggetto += ((int)_TipoOggetto[iT]).ToString();
            if (iT < _TipoOggetto.Length)
            {
                sTipoOggetto += ", ";
            }
        }

        sSQL = sqlGetSingleObject;
        
        IDbCommand dbC = DAL.CreateCommand();
        dbC.CommandText = sSQL;
				dbC.CommandType = CommandType.StoredProcedure;

        dbC.Parameters.Add(DAL.CreatePar("@objectID", iNotizia));


        IDataReader oDr = DAL.GetDataReader(dbC);
        if (oDr.Read())
        {
            ret.FromDataReader(oDr);
            oDr.Close();
        }
        else { ret = null; }

        return ret;

    }

    public Oggetto Get(int iNotizia, bool GetFoto, int CountImage)
    {

        Oggetto ret = Get(iNotizia);

        ret.Foto = new Immagini().GetAll(iNotizia, CountImage).ToArray();

        return ret;

    }

    public List<Oggetto> GetAll(int Count)
    {

        List<Oggetto> oList = new List<Oggetto>();

        string sTipoOggetto = "";
        string sOrderBy = "";
        for (int iT = 0; iT < _TipoOggetto.Length; iT++)
        {
            sTipoOggetto += ((int)_TipoOggetto[iT]).ToString();
            if (iT < _TipoOggetto.Length - 1)
            {
                sTipoOggetto += ", ";
            }

        }

        if (_TipoOggetto.Length > 1)
        {
            sOrderBy += " order by tObjectDataInserimento desc, tObjectNumOrder ";
        }
        else
        {
            sOrderBy += " order by tObjectNumOrder";
        }

        IDbCommand dbC = DAL.CreateCommand();

        if (Count > 0 && HomePage == false)
        {
            dbC.CommandText = (sqlGetCountObject.Replace("{count}", Count.ToString()).Replace("{@TipoOggetto}", sTipoOggetto).Replace("{sOrderBy}", sOrderBy));
        }
        else if (HomePage == false)
        {
            dbC.CommandText = (sqlGetAllObject.Replace("{@TipoOggetto}", sTipoOggetto).Replace("{sOrderBy}", sOrderBy));
        }
        else
        {
            dbC.CommandText = (sqlGetHomePageObject.Replace("{@TipoOggetto}", sTipoOggetto).Replace("{sOrderBy}", sOrderBy));
        }


        dbC.Parameters.Add(DAL.CreatePar("@TipoOggetto", sTipoOggetto));
        dbC.Parameters.Add(DAL.CreatePar("@isHomePage", HomePage));


        using (IDataReader oDr = DAL.GetDataReader(dbC))
        {

            while (oDr.Read())
            {
                Oggetto oNotizia = new Oggetto();
                oNotizia.FromDataReader(oDr);
                oList.Add(oNotizia);
            }
            oDr.Close();
        }


        return oList;
    }

		public List<Oggetto> GetHomePage(int Count, bool isHomePage)
		{

			List<Oggetto> oList = new List<Oggetto>();

			string sTipoOggetto = "";
			string sOrderBy = "";
			for (int iT = 0; iT < _TipoOggetto.Length; iT++)
			{
				sTipoOggetto += ((int)_TipoOggetto[iT]).ToString();
				if (iT < _TipoOggetto.Length - 1)
				{
					sTipoOggetto += ", ";
				}

			}

			if (_TipoOggetto.Length > 1)
			{
				sOrderBy += " order by tObjectDataInserimento desc, tObjectNumOrder ";
			}
			else
			{
				sOrderBy += " order by tObjectNumOrder";
			}

			IDbCommand dbC = DAL.CreateCommand();

			if (Count > 0)
			{
				dbC.CommandText = (sqlGetHomePageObject.Replace("{count}", Count.ToString()).Replace("{@TipoOggetto}", sTipoOggetto).Replace("{sOrderBy}", sOrderBy));				
			}

			dbC.Parameters.Add(DAL.CreatePar("@TipoOggetto", sTipoOggetto));
			dbC.Parameters.Add(DAL.CreatePar("@isHomePage", isHomePage));


			using (IDataReader oDr = DAL.GetDataReader(dbC))
			{

				while (oDr.Read())
				{
					Oggetto oNotizia = new Oggetto();
					oNotizia.FromDataReader(oDr);
					oList.Add(oNotizia);
				}
				oDr.Close();
			}

			foreach (Oggetto oObj in oList)
			{
			  oObj.Foto = new Immagini().GetAll(oObj.ID, 0).ToArray();
			}

			return oList;
		}

    public List<Oggetto> GetAll(int Count, bool GetImage, int CountImage)
    {

        List<Oggetto> oList = new List<Oggetto>();

        oList = GetAll(Count);


        foreach (Oggetto oObj in oList)
        {
            oObj.Foto = new Immagini().GetAll(oObj.ID, CountImage).ToArray();
        }

        return oList;
    }

    public int Add(Oggetto oNotizia)
    {
        int iRetVal = 0;

        //OleDbManager oDbManager = Business.ConstWrapper.DbManager;
        IDbCommand dbC = DAL.CreateCommand();

        dbC.CommandText = (sqlInsertSingleObject);

        dbC.Parameters.Add(DAL.CreatePar("@tObjectTitolo", oNotizia.Titolo));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectSottoTitolo", oNotizia.SottoTitolo));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectTesto", oNotizia.Testo));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectDataInserimento", DateTime.Now));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectDataModifica", DateTime.Now));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectIDUtente", oNotizia.IdUtente));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectTypeID", (int)oNotizia.TipoOggetto));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectNumOrder", 1));


        iRetVal = DAL.ExecuteGetId(dbC);

        // UPDATE NumOrder 

        dbC = DAL.CreateCommand();

        dbC.Parameters.Clear();
        dbC.CommandText = "update tObject SET tObjectNumOrder = tObjectNumOrder+1 " +
                            " WHERE tObjectID <> " + iRetVal.ToString() + " and tObjectTypeID=" + (int)oNotizia.TipoOggetto;

        iRetVal = DAL.Execute(dbC);

        return iRetVal;
    }

    public int Update(Oggetto oNotizia)
    {
        int iRetVal = 0;

        IDbCommand dbC = DAL.CreateCommand();

        dbC.CommandText = (sqlUpdateSingleObject);
        dbC.Parameters.Add(DAL.CreatePar("@tObjectTitolo", oNotizia.Titolo));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectSottoTitolo", oNotizia.SottoTitolo));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectTesto", oNotizia.Testo));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectDataModifica", oNotizia.DataModifica));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectIDUtente", oNotizia.IdUtente));
        dbC.Parameters.Add(DAL.CreatePar("@tObjectID", oNotizia.ID));

        iRetVal = DAL.Execute(dbC);

        return iRetVal;
    }

    public bool Delete(int IdNotizia)
    {
        bool bRet = false;

        Oggetti.Oggetto oNotizia = Get(IdNotizia);

        IDbCommand dbC = DAL.CreateCommand();

        dbC.CommandText = sqlDeleteSingleObject;
				dbC.CommandType = CommandType.StoredProcedure;
        dbC.Parameters.Add(DAL.CreatePar("@tObjectID", IdNotizia));


        if (DAL.Execute(dbC) > 0)
        {
            bRet = true;
        }

        dbC = DAL.CreateCommand();

        // UPDATE NEW ORDER
        dbC.CommandText = ("UPDATE tObject SET tObjectNumOrder = tObjectNumOrder-1 " +
                " WHERE tObjectNumOrder > @NumOrder AND tObjectTypeID=@Tipologia;");

        dbC.Parameters.Add(DAL.CreatePar("@NumOrder", oNotizia.NumOrder));
        dbC.Parameters.Add(DAL.CreatePar("@Tipologia", (int)_TipoOggetto[0]));

        DAL.Execute(dbC);

        return bRet;

    }

    public bool UpdateNumOrder(int ID, string Direction)
    {
        bool bRet = false;

        Oggetti.Oggetto oNotizia = this.Get(ID);

        int CurrentNumOrder = oNotizia.NumOrder;

        int MaxNewOrder = GetLastNumOrder(_TipoOggetto[0]);

        IDbCommand dbC = DAL.CreateCommand();
        dbC.CommandText = "UPDATE tObject set tObjectNumOrder=@NewNumOrder where tObjectID=@Id";


        if ((Direction == "UP") && (CurrentNumOrder != 1))
        {

            dbC.Parameters.Add(DAL.CreatePar("@NewNumOrder", CurrentNumOrder - 1));
            dbC.Parameters.Add(DAL.CreatePar("@Id", oNotizia.ID));

            DAL.Execute(dbC);

            dbC = DAL.CreateCommand();

            dbC.CommandText = ("UPDATE tObject set tObjectNumOrder=" + CurrentNumOrder + " where tObjectID <> " + oNotizia.ID + " and tObjectNumOrder=" + (CurrentNumOrder - 1) + " and tObjectTypeID=" + Convert.ToInt32(_TipoOggetto[0]));

            DAL.Execute(dbC);
        }
        else if ((Direction == "DOWN") && (CurrentNumOrder != MaxNewOrder - 1))
        {

            dbC.Parameters.Add(DAL.CreatePar("@NewNumOrder", CurrentNumOrder + 1));
            dbC.Parameters.Add(DAL.CreatePar("@Id", oNotizia.ID));

            DAL.Execute(dbC);

            dbC = DAL.CreateCommand();

            dbC.CommandText = ("UPDATE tObject set tObjectNumOrder=" + CurrentNumOrder + " where tObjectID <> " + oNotizia.ID + " and tObjectNumOrder=" + (CurrentNumOrder + 1) + " and tObjectTypeID=" + Convert.ToInt32(_TipoOggetto[0]));

            DAL.Execute(dbC);

        }

        return bRet;
    }

    private int GetLastNumOrder(TipoOggetto tipoOggetto)
    {
        int iRet = 0;

        IDbCommand dbC = DAL.CreateCommand();
        dbC.CommandText = (sqlGetLastNumOrder);
        dbC.Parameters.Add(DAL.CreatePar("@tObjectTypeID", (int)tipoOggetto));

        try
        {
            iRet = (int)DAL.ExecuteScalar(dbC) + 1;
        }
        catch
        {
            iRet = 1;
        }

        return iRet;
    }

    public int SetHomePage(int ID, bool HomeNews)
    {
        IDbCommand dbC = DAL.CreateCommand();
        dbC.CommandText = "UPDATE tObject set isHomeNews=@isHomeNews where tObjectID=@Id;";
        //dbC.CommandText += "UPDATE tObject set isHomeNews=0 where tObjectID <> @Id;";
        dbC.Parameters.Add(DAL.CreatePar("@isHomeNews", HomeNews));
        dbC.Parameters.Add(DAL.CreatePar("@Id", ID));

        return DAL.Execute(dbC);

    }


		private const string sqlGetSingleObject = "selectSingleObject";/*"SELECT * " +
        "FROM tObject " +
        "WHERE tObjectID=@IdObject";//and tObject.tObjectTypeID in ({@TipoOggetto});*/

    private const string sqlGetAllObject = "SELECT * " +
        "FROM tObject " +
        "WHERE tObject.tObjectTypeID in ({@TipoOggetto}) {sOrderBy}";

    private const string sqlGetHomePageObject = "SELECT TOP {count} * " +
    "FROM tObject " +
    "WHERE tObject.tObjectTypeID in ({@TipoOggetto}) and [isHomeNews]=@isHomePage {sOrderBy}";

    private const string sqlGetCountObject = "SELECT TOP {count} * " +
        "FROM tObject " +
        "WHERE tObject.tObjectTypeID IN ({@TipoOggetto}) {sOrderBy}";

    private const string sqlUpdateSingleObject = "UPDATE tObject SET tObjectTitolo = @tObjectTitolo, tObjectSottoTitolo = @tObjectSottoTitolo, tObjectTesto = @tObjectTesto, tObjectDataModifica = @tObjectDataModifica, tObjectIDUtente = @tObjectIDUtente " +
        " WHERE tObjectID=@tObjectID";

    private const string sqlInsertSingleObject = "INSERT INTO tObject ( tObjectTitolo, tObjectSottoTitolo, tObjectTesto, tObjectDataInserimento, tObjectDataModifica, tObjectIDUtente, tObjectTypeID, tObjectNumOrder ) " +
        " VALUES ( @tObjectTitolo, @tObjectSottoTitolo, @tObjectTesto, @tObjectDataInserimento, @tObjectDataModifica, @tObjectIDUtente, @tObjectTypeID, @tObjectNumOrder )";

    private const string sqlUpdateNumOrder = "";

    private const string sqlGetLastNumOrder = "SELECT Max(tObject.tObjectNumOrder) AS MaxNumOrder" +
        " FROM tObject" +
        " GROUP BY tObject.tObjectTypeID" +
        " HAVING (tObject.tObjectTypeID = @tObjectTypeID);";

		private const string sqlDeleteSingleObject = "deleteSingleObject"; /* stored procedure */

}
