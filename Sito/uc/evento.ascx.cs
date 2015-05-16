using System;
using System.Web;
using Business.Oggetti;
using Gestione;

namespace uc
{
    public partial class UcEvento : System.Web.UI.UserControl
    {

        public string TitoloNotizia = "";
        public string SottoTitolo = "";
        public string TestoNotizia = "";
        public string DataInserimento = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var oNotizia = Notizia;
            TitoloNotizia = oNotizia.Titolo;
            SottoTitolo = oNotizia.SottoTitolo;
            TestoNotizia = oNotizia.Testo;
            DataInserimento = oNotizia.DataInserimento.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("it-IT"));
        }

        public Oggetto Notizia {
            get {
                if (HttpContext.Current.Cache["evento" + Request["id"]] != null)
                {
                    return (Oggetto)HttpContext.Current.Cache["evento" + Request["id"]];
                }
                else
                {
                    Oggetto oNews = new Notizie(TipoOggetto.Eventi).Get(int.Parse(Request["id"]), false, 0);
                    HttpContext.Current.Cache["evento" + Request["id"]] = oNews;
                    return oNews;
                }
            }
        }
    }
}
