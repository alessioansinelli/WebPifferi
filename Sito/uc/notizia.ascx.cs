using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_notizia : System.Web.UI.UserControl
{

    public string TitoloNotizia = "";
    public string SottoTitolo = "";
    public string TestoNotizia = "";
    public string Anno = "";
    public string Mese = "";
    public string Giorno = "";
    public string ID = "";


    private string slug = "";

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
        ID = oNotizia.ID.ToString();
    }

    public Oggetti.Oggetto Notizia {
        get {
            if (HttpContext.Current.Cache["notizia-" + slug] != null)
            {
                return (Oggetti.Oggetto)HttpContext.Current.Cache["notizia-" + slug];
            }
            else
            {
                Oggetti.Oggetto oNews = new Notizie(TipoOggetto.News).Get(slug, false, 0);
                HttpContext.Current.Cache["notizia-" + slug] = oNews;
                return oNews;
            }
        }
    }
}
