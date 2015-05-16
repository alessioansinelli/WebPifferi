using System.Configuration;
using System.Web;

namespace Business
{
    /// <summary>
    /// Summary description for ConstWrapper
    /// </summary>
    public static class ConstWrapper
    {

        public static string NomeConnessione
        {
            get
            {

                string connString = "";

                switch (ConnectionType)
                {
                    case "SqlServer":
                        connString = ConfigurationManager.AppSettings["connString"];
                        break;
                    case "OleDb":
                        connString = ConfigurationManager.AppSettings["provider"] +
                    "Data Source=" + @HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["pathdbaccess"]);
                        break;
                }

                return connString;
            }
        }

        
        public static string ConnectionType
        {
            get
            {
                return ConfigurationManager.AppSettings["connType"];
            }
        }

      
        public static string SmtpUrl
        {
            get { return ConfigurationManager.AppSettings["smtpaddress"]; }
        }

        public static string MailTo
        {
            get { return ConfigurationManager.AppSettings["mailrecipient"]; }
        }


        public static Oggetti.OggettoLogin UtenteLoggato
        {
            get { return (Oggetti.OggettoLogin)HttpContext.Current.Session["UtenteLoggato"]; }
            set { HttpContext.Current.Session["UtenteLoggato"] = value; }
        }

        public static string CartellaFoto
        {
            get { return ConfigurationManager.AppSettings["pathsalvataggiofoto"]; }
        }

        public static string LarghezzaThumb
        {
            get { return ConfigurationManager.AppSettings["thumbwidth"]; }
        }

        public static string AltezzaThumb
        {
            get { return ConfigurationManager.AppSettings["thumbheight"]; }
        }

        public static string LarghezzaImg
        {
            get { return ConfigurationManager.AppSettings["imgwidth"]; }
        }

        public static string AltezzaImg
        {
            get { return ConfigurationManager.AppSettings["imgheight"]; }
        }

    }

}

