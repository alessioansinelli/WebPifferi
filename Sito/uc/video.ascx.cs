using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_video : System.Web.UI.UserControl
{

    public string TitoloNotizia = "";
    public string SottoTitolo = "";
    public string TestoNotizia = "";
    public string Anno = "";
    public string Mese = "";
    public string Giorno = "";
    public string ID = "";
    public string slug = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        slug = Page.RouteData.Values["slug"] as string;

        Oggetti.Oggetto oNotizia = Notizia;
        TitoloNotizia = oNotizia.Titolo;
        SottoTitolo = oNotizia.SottoTitolo;
        TestoNotizia = oNotizia.Testo;
        Anno = oNotizia.DataInserimento.ToString("yyyy", new System.Globalization.CultureInfo("it-IT"));
        Mese = oNotizia.DataInserimento.ToString("MMM", new System.Globalization.CultureInfo("it-IT")).ToUpper();
        Giorno = oNotizia.DataInserimento.ToString("dd", new System.Globalization.CultureInfo("it-IT"));


    }

    public Oggetti.Oggetto Notizia {
        get {
            if (HttpContext.Current.Cache["video-" + slug] != null)
            {
                return (Oggetti.Oggetto)HttpContext.Current.Cache["video-" + slug];
            }
            else
            {
                Oggetti.Oggetto oNews = new Notizie(TipoOggetto.Video).Get(slug, false, 0);
                HttpContext.Current.Cache["video-" + slug] = oNews;
                return oNews;
            }
        }
    }
}
