using System;
using System.Web;
using Business.Oggetti;
using Data;


namespace Business
{

    /// <summary>
    /// Summary description for Login
    /// </summary>
    public class LoginHelper
    {
        public OggettoLogin AutenticaUtente(OggettoLogin oLogin)
        {
            OggettoLogin retval = null;
            if (oLogin != null)
            {
                if (!string.IsNullOrEmpty(oLogin.NomeUtente))
                {

                    // compongo l'SQL per verificare l'autenticazione
                    //OleDbCommand oCmd = new OleDbCommand();
                    var dal = new DataLayer();
                    var dbC = dal.CreateCommand();

                    dbC.CommandText = "SELECT *" +
                        " FROM ADMIN " +
                        " WHERE NomeUtente = @NomeUtente " +
                        " AND [Password] = @PwdUtente";


                    dbC.Parameters.Add(dal.CreatePar("@NomeUtente", oLogin.NomeUtente));
                    dbC.Parameters.Add(dal.CreatePar("@PwdUtente", oLogin.PwdUtente));

                    var loggedIn = false;

                    using (var dtLogin = dal.GetDataReader(dbC))
                    {
                        while (dtLogin.Read())
                        {
                            oLogin.IdUtente = int.Parse(dtLogin["ID"].ToString());
                            // pulisco il campo password
                            oLogin.PwdUtente = "";
                            oLogin.NomeUtente = dtLogin["Nome"] + " " + dtLogin["Cognome"];
                            oLogin.DataOraAccesso = DateTime.Parse(dtLogin["UltimoAccesso"].ToString());

                            loggedIn = true;
                        }

                        dtLogin.Close();

                    }


                    if (!loggedIn) return null;
                    //memorizzo data e ora dell'ultimo accesso al sistema.
                    dbC.Parameters.Clear();
                    dbC.CommandText = "UPDATE Admin set UltimoAccesso = @UltimoAccesso where ID = @IdUtente";

                    dbC.Parameters.Add(dal.CreatePar("@UltimoAccesso", DateTime.Now));
                    dbC.Parameters.Add(dal.CreatePar("@IdUtente", oLogin.IdUtente));

                    dal.Execute(dbC);

                    retval = oLogin;

                    ConstWrapper.UtenteLoggato = oLogin;

                    // set the cookie for access control
                    HttpContext.Current.Response.SetCookie(new HttpCookie("loggedinbackend", "loggedinbackend"));
                }
            }

            return retval;
        }
    }
}
