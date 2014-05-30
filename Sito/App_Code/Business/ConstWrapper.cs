using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

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
                        connString = ConfigurationManager.AppSettings["connString"].ToString();
                        break;
                    case "OleDb":
                        connString = ConfigurationManager.AppSettings["provider"].ToString() +
                    "Data Source=" + @HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["pathdbaccess"].ToString());
                        break;
                    default:
                        break;
                }

                return connString;
            }
        }

        
        public static string ConnectionType
        {
            get
            {
                return ConfigurationManager.AppSettings["connType"].ToString();
            }
        }

      
        public static string SmtpURL
        {
            get { return ConfigurationManager.AppSettings["smtpaddress"].ToString(); }
        }

        public static string MailTo
        {
            get { return ConfigurationManager.AppSettings["mailrecipient"].ToString(); }
        }


        public static Oggetti.OggettoLogin UtenteLoggato
        {
            get { return (Oggetti.OggettoLogin)HttpContext.Current.Session["UtenteLoggato"]; }
            set { HttpContext.Current.Session["UtenteLoggato"] = value; }
        }

        public static string CartellaFoto
        {
            get { return ConfigurationManager.AppSettings["pathsalvataggiofoto"].ToString(); }
        }

        public static string LarghezzaThumb
        {
            get { return ConfigurationManager.AppSettings["thumbwidth"].ToString(); }
        }

        public static string AltezzaThumb
        {
            get { return ConfigurationManager.AppSettings["thumbheight"].ToString(); }
        }

        public static string LarghezzaImg
        {
            get { return ConfigurationManager.AppSettings["imgwidth"].ToString(); }
        }

        public static string AltezzaImg
        {
            get { return ConfigurationManager.AppSettings["imgheight"].ToString(); }
        }

    }

}

