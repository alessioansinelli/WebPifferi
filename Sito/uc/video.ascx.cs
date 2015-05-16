using System;
using System.Web;
using Business.Oggetti;
using Gestione;

namespace uc
{
    public partial class UcVideo : System.Web.UI.UserControl
    {

        public string TitoloNotizia = "";
        public string SottoTitolo = "";
        public string TestoNotizia = "";
        public string Anno = "";
        public string Mese = "";
        public string Giorno = "";
        public string ID = "";
        public string Slug = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Slug = Page.RouteData.Values["slug"] as string;

            var oNotizia = Notizia;
            TitoloNotizia = oNotizia.Titolo;
            SottoTitolo = oNotizia.SottoTitolo;
            TestoNotizia = oNotizia.Testo;
            Anno = oNotizia.DataInserimento.ToString("yyyy", new System.Globalization.CultureInfo("it-IT"));
            Mese = oNotizia.DataInserimento.ToString("MMM", new System.Globalization.CultureInfo("it-IT")).ToUpper();
            Giorno = oNotizia.DataInserimento.ToString("dd", new System.Globalization.CultureInfo("it-IT"));


        }

        public Oggetto Notizia {
            get {
                if (HttpContext.Current.Cache["video-" + Slug] != null)
                {
                    return (Oggetto)HttpContext.Current.Cache["video-" + Slug];
                }
                else
                {
                    Oggetto oNews = new Notizie(TipoOggetto.Video).Get(Slug, false, 0);
                    HttpContext.Current.Cache["video-" + Slug] = oNews;
                    return oNews;
                }
            }
        }
    }
}
