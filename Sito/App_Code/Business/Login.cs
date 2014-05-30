using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Oggetti;
using Business;
using System.Data.OleDb;
using Mercenari.Data;


/// <summary>
/// Summary description for Login
/// </summary>
public class Login
{

    public Login()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public OggettoLogin AutenticaUtente(OggettoLogin oLogin)
    {
        OggettoLogin _retval = null;
        if (oLogin != null)
        {
            if ((oLogin.NomeUtente.CompareTo(string.Empty) != 0) && (oLogin.NomeUtente.CompareTo(string.Empty) != 0))
            {

                // compongo l'SQL per verificare l'autenticazione
                //OleDbCommand oCmd = new OleDbCommand();
                DataLayer Dal = new DataLayer();
                IDbCommand dbC = Dal.CreateCommand();

                dbC.CommandText = "SELECT *" +
                    " FROM ADMIN " +
                    " WHERE NomeUtente = @NomeUtente " +
                    " AND [Password] = @PwdUtente";


                dbC.Parameters.Add(Dal.CreatePar("@NomeUtente", oLogin.NomeUtente));
                dbC.Parameters.Add(Dal.CreatePar("@PwdUtente", oLogin.PwdUtente));

                bool LoggedIn = false;

                using (IDataReader DtLogin = Dal.GetDataReader(dbC))
                {
                    while (DtLogin.Read())
                    {
                        oLogin.IdUtente = int.Parse(DtLogin["ID"].ToString());
                        // pulisco il campo password
                        oLogin.PwdUtente = "";
                        oLogin.NomeUtente = DtLogin["Nome"].ToString() + " " + DtLogin["Cognome"];
                        oLogin.DataOraAccesso = DateTime.Parse(DtLogin["UltimoAccesso"].ToString());

                        LoggedIn = true;
                    }

                    DtLogin.Close();

                }


                if (LoggedIn)
                {
                    ///*oLogin.DataOraAccesso = DateTime.Parse(DtLogin.Rows[0][""]);*/
                    //oLogin.IdUtente = int.Parse(DtLogin["ID"].ToString());
                    //// pulisco il campo password
                    //oLogin.PwdUtente = "";
                    //oLogin.NomeUtente = DtLogin["Nome"].ToString() + " " + DtLogin["Cognome"];
                    //oLogin.DataOraAccesso = DateTime.Parse(DtLogin["UltimoAccesso"].ToString());

                    //memorizzo data e ora dell'ultimo accesso al sistema.
                    dbC.Parameters.Clear();
                    dbC.CommandText = "UPDATE Admin set UltimoAccesso = @UltimoAccesso where ID = @IdUtente";

                    dbC.Parameters.Add(Dal.CreatePar("@UltimoAccesso", DateTime.Now));
                    dbC.Parameters.Add(Dal.CreatePar("@IdUtente", oLogin.IdUtente));

                    Dal.Execute(dbC);

                    _retval = oLogin;

                    ConstWrapper.UtenteLoggato = oLogin;
                }

            }
        }

        return _retval;
    }


}
