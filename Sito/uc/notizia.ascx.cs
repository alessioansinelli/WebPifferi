using System;
using System.Web;
using Business.Oggetti;
using Gestione;

namespace uc
{
    public partial class UcNotizia : System.Web.UI.UserControl
    {

        public string TitoloNotizia = "";
        public string SottoTitolo = "";
        public string TestoNotizia = "";
        public string Anno = "";
        public string Mese = "";
        public string Giorno = "";
        public string Id = "";


        private string _slug = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            _slug = Page.RouteData.Values["slug"] as string;

            Oggetto oNotizia = Notizia;
            TitoloNotizia = oNotizia.Titolo;
            SottoTitolo = oNotizia.SottoTitolo;
            TestoNotizia = oNotizia.Testo;
            Anno = oNotizia.DataInserimento.ToString("yyyy", new System.Globalization.CultureInfo("it-IT"));
            Mese = oNotizia.DataInserimento.ToString("MMM", new System.Globalization.CultureInfo("it-IT")).ToUpper();
            Giorno = oNotizia.DataInserimento.ToString("dd", new System.Globalization.CultureInfo("it-IT"));
            Id = oNotizia.Id.ToString();
        }

        public Oggetto Notizia {
            get {
                if (HttpContext.Current.Cache["notizia-" + _slug] != null)
                {
                    return (Oggetto)HttpContext.Current.Cache["notizia-" + _slug];
                }
                else
                {
                    Oggetto oNews = new Notizie(TipoOggetto.News).Get(_slug, false, 0);
                    HttpContext.Current.Cache["notizia-" + _slug] = oNews;
                    return oNews;
                }
            }
        }
    }
}
