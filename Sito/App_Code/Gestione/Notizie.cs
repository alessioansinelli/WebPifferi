using System;
using System.Collections.Generic;
using Business.Oggetti;
using System.Data;
using Data;


namespace Gestione
{
    /// <summary>
    /// Summary description for Notizie
    /// </summary>
    public class Notizie
    {

        private TipoOggetto[] _TipoOggetto;
        private readonly bool _homePage;
        //private OleDbConnection _Connessione;
        //private OleDbCommand _Command;

        private DataLayer DAL = new DataLayer();

        string _sSql = "";
        public Notizie(TipoOggetto[] tipoObj)
        {
            //_Connessione = Business.ConstWrapper.Connessione;
            _TipoOggetto = tipoObj;
            if (_TipoOggetto.Length == 1 && _TipoOggetto[0] == TipoOggetto.Homepage)
            {
                _homePage = true;
                _TipoOggetto[0] = TipoOggetto.News;
            }
        }

        public Notizie(TipoOggetto oTipOggetto)
        {
            TipoOggetto[] artpo = new TipoOggetto[1];
            artpo[0] = oTipOggetto;
            _TipoOggetto = artpo;
            //_Connessione = Business.ConstWrapper.Connessione;
        }

        public Oggetto Get(int iNotizia)
        {

            var ret = new Oggetto();


            _sSql = SqlGetSingleObject;

            var dbC = DAL.CreateCommand();
            dbC.CommandText = _sSql;
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

        public Oggetto Get(string slug)
        {

            Oggetto ret = new Oggetto();
            //OleDbManager oDbManager = Business.ConstWrapper.DbManager;

            _sSql = SqlGetSingleObject;

            IDbCommand dbC = DAL.CreateCommand();
            dbC.CommandText = _sSql;
            dbC.CommandType = CommandType.StoredProcedure;

            dbC.Parameters.Add(DAL.CreatePar("@slug", slug));


            IDataReader oDr = DAL.GetDataReader(dbC);
            if (oDr.Read())
            {
                ret.FromDataReader(oDr);
                oDr.Close();
            }
            else { ret = null; }

            return ret;

        }

        public Oggetto Get(int iNotizia, bool getFoto, int countImage)
        {

            Oggetto ret = Get(iNotizia);

            ret.Foto = new Immagini().GetAll(iNotizia, countImage).ToArray();

            return ret;

        }

        public Oggetto Get(string slug, bool getFoto, int countImage)
        {

            Oggetto ret = Get(slug);

            ret.Foto = new Immagini().GetAll(ret.Id, countImage).ToArray();

            return ret;

        }

        public List<Oggetto> GetAll(int count)
        {

            var oList = new List<Oggetto>();

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

            if (count > 0 && _homePage == false)
            {
                dbC.CommandText = (SqlGetCountObject.Replace("{count}", count.ToString()).Replace("{@TipoOggetto}", sTipoOggetto).Replace("{sOrderBy}", sOrderBy));
            }
            else if (_homePage == false)
            {
                dbC.CommandText = (SqlGetAllObject.Replace("{@TipoOggetto}", sTipoOggetto).Replace("{sOrderBy}", sOrderBy));
            }
            else
            {
                dbC.CommandText = (SqlGetHomePageObject.Replace("{@TipoOggetto}", sTipoOggetto).Replace("{sOrderBy}", sOrderBy));
            }


            dbC.Parameters.Add(DAL.CreatePar("@TipoOggetto", sTipoOggetto));
            dbC.Parameters.Add(DAL.CreatePar("@isHomePage", _homePage));


            using (var oDr = DAL.GetDataReader(dbC))
            {

                while (oDr.Read())
                {
                    var oNotizia = new Oggetto();
                    oNotizia.FromDataReader(oDr);
                    oList.Add(oNotizia);
                }
                oDr.Close();
            }


            return oList;
        }

        public List<Oggetto> GetHomePage(int count, bool isHomePage)
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

            if (count > 0)
            {
                dbC.CommandText = (SqlGetHomePageObject.Replace("{count}", count.ToString()).Replace("{@TipoOggetto}", sTipoOggetto).Replace("{sOrderBy}", sOrderBy));
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
                oObj.Foto = new Immagini().GetAll(oObj.Id, 0).ToArray();
            }

            return oList;
        }

        public List<Oggetto> GetAll(int count, bool getImage, int countImage)
        {
            var oList = GetAll(count);


            foreach (var oObj in oList)
            {
                oObj.Foto = new Immagini().GetAll(oObj.Id, countImage).ToArray();
            }

            return oList;
        }

        public int Add(Oggetto oNotizia)
        {
            //OleDbManager oDbManager = Business.ConstWrapper.DbManager;
            var dbC = DAL.CreateCommand();

            dbC.CommandText = (SqlInsertSingleObject);

            dbC.Parameters.Add(DAL.CreatePar("@tObjectTitolo", oNotizia.Titolo));
            dbC.Parameters.Add(DAL.CreatePar("@slug", oNotizia.Slug));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectSottoTitolo", oNotizia.SottoTitolo));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectTesto", oNotizia.Testo));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectDataInserimento", DateTime.Now));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectDataModifica", DateTime.Now));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectIDUtente", oNotizia.IdUtente));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectTypeID", oNotizia.TipoOggetto));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectNumOrder", 1));


            var iRetVal = DAL.ExecuteGetId(dbC);

            // UPDATE NumOrder 

            dbC = DAL.CreateCommand();

            dbC.Parameters.Clear();
            dbC.CommandText = "update tObject SET tObjectNumOrder = tObjectNumOrder+1 " +
                                " WHERE tObjectID <> " + iRetVal + " and tObjectTypeID=" + (int)oNotizia.TipoOggetto;

            iRetVal = DAL.Execute(dbC);

            return iRetVal;
        }

        public int Update(Oggetto oNotizia)
        {
            var dbC = DAL.CreateCommand();

            dbC.CommandText = (SqlUpdateSingleObject);
            dbC.Parameters.Add(DAL.CreatePar("@tObjectTitolo", oNotizia.Titolo));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectSottoTitolo", oNotizia.SottoTitolo));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectTesto", oNotizia.Testo));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectDataModifica", oNotizia.DataModifica));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectIDUtente", oNotizia.IdUtente));
            dbC.Parameters.Add(DAL.CreatePar("@tObjectID", oNotizia.Id));
            dbC.Parameters.Add(DAL.CreatePar("@slug", oNotizia.Slug));

            var iRetVal = DAL.Execute(dbC);

            return iRetVal;
        }

        public bool Delete(int idNotizia)
        {
            bool bRet = false;

            Oggetto oNotizia = Get(idNotizia);

            IDbCommand dbC = DAL.CreateCommand();

            dbC.CommandText = SqlDeleteSingleObject;
            dbC.CommandType = CommandType.StoredProcedure;
            dbC.Parameters.Add(DAL.CreatePar("@tObjectID", idNotizia));


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

        public bool UpdateNumOrder(int id, string direction)
        {
            const bool bRet = false;

            var oNotizia = Get(id);

            var currentNumOrder = oNotizia.NumOrder;

            var maxNewOrder = GetLastNumOrder(_TipoOggetto[0]);

            IDbCommand dbC = DAL.CreateCommand();
            dbC.CommandText = "UPDATE tObject set tObjectNumOrder=@NewNumOrder where tObjectID=@Id";


            if ((direction == "UP") && (currentNumOrder != 1))
            {

                dbC.Parameters.Add(DAL.CreatePar("@NewNumOrder", currentNumOrder - 1));
                dbC.Parameters.Add(DAL.CreatePar("@Id", oNotizia.Id));

                DAL.Execute(dbC);

                dbC = DAL.CreateCommand();

                dbC.CommandText = ("UPDATE tObject set tObjectNumOrder=" + currentNumOrder + " where tObjectID <> " + oNotizia.Id + " and tObjectNumOrder=" + (currentNumOrder - 1) + " and tObjectTypeID=" + Convert.ToInt32(_TipoOggetto[0]));

                DAL.Execute(dbC);
            }
            else if ((direction == "DOWN") && (currentNumOrder != maxNewOrder - 1))
            {

                dbC.Parameters.Add(DAL.CreatePar("@NewNumOrder", currentNumOrder + 1));
                dbC.Parameters.Add(DAL.CreatePar("@Id", oNotizia.Id));

                DAL.Execute(dbC);

                dbC = DAL.CreateCommand();

                dbC.CommandText = ("UPDATE tObject set tObjectNumOrder=" + currentNumOrder + " where tObjectID <> " + oNotizia.Id + " and tObjectNumOrder=" + (currentNumOrder + 1) + " and tObjectTypeID=" + Convert.ToInt32(_TipoOggetto[0]));

                DAL.Execute(dbC);

            }

            return bRet;
        }

        private int GetLastNumOrder(TipoOggetto tipoOggetto)
        {
            int iRet;

            var dbC = DAL.CreateCommand();
            dbC.CommandText = (SqlGetLastNumOrder);
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

        public int SetHomePage(int id, bool homeNews)
        {
            IDbCommand dbC = DAL.CreateCommand();
            dbC.CommandText = "UPDATE tObject set isHomeNews=@isHomeNews where tObjectID=@Id;";
            //dbC.CommandText += "UPDATE tObject set isHomeNews=0 where tObjectID <> @Id;";
            dbC.Parameters.Add(DAL.CreatePar("@isHomeNews", homeNews));
            dbC.Parameters.Add(DAL.CreatePar("@Id", id));

            return DAL.Execute(dbC);

        }


        private const string SqlGetSingleObject = "selectSingleObject";/*"SELECT * " +
        "FROM tObject " +
        "WHERE tObjectID=@IdObject";//and tObject.tObjectTypeID in ({@TipoOggetto});*/

        private const string SqlGetAllObject = "SELECT * " +
            "FROM tObject " +
            "WHERE tObject.tObjectTypeID in ({@TipoOggetto}) {sOrderBy}";

        private const string SqlGetHomePageObject = "SELECT TOP {count} * " +
        "FROM tObject " +
        "WHERE tObject.tObjectTypeID in ({@TipoOggetto}) and [isHomeNews]=@isHomePage {sOrderBy}";

        private const string SqlGetCountObject = "SELECT TOP {count} * " +
            "FROM tObject " +
            "WHERE tObject.tObjectTypeID IN ({@TipoOggetto}) {sOrderBy}";

        private const string SqlUpdateSingleObject = "UPDATE tObject SET tObjectTitolo = @tObjectTitolo, tObjectSottoTitolo = @tObjectSottoTitolo, tObjectTesto = @tObjectTesto, tObjectDataModifica = @tObjectDataModifica, tObjectIDUtente = @tObjectIDUtente, slug=@slug " +
            " WHERE tObjectID=@tObjectID";

        private const string SqlInsertSingleObject = "INSERT INTO tObject ( tObjectTitolo, tObjectSottoTitolo, tObjectTesto, tObjectDataInserimento, tObjectDataModifica, tObjectIDUtente, tObjectTypeID, tObjectNumOrder, slug ) " +
            " VALUES ( @tObjectTitolo, @tObjectSottoTitolo, @tObjectTesto, @tObjectDataInserimento, @tObjectDataModifica, @tObjectIDUtente, @tObjectTypeID, @tObjectNumOrder, @slug )";

        private const string SqlGetLastNumOrder = "SELECT Max(tObject.tObjectNumOrder) AS MaxNumOrder" +
            " FROM tObject" +
            " GROUP BY tObject.tObjectTypeID" +
            " HAVING (tObject.tObjectTypeID = @tObjectTypeID);";

        private const string SqlDeleteSingleObject = "deleteSingleObject"; /* stored procedure */

    }

}
