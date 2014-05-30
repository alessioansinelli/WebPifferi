using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _dettaglionews : System.Web.UI.Page
{

	public string TitoloHomePage = "";
	public string SottoTitoloHomePage = "";
	public string TestoHomePage = "";
	public string ImmagineHomePage = "";
    public string TitoloPagina = "";

	protected void Page_Load(object sender, EventArgs e)
	{

		List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
        oOggetti = ElencoNotizie;

        notizia1.PreRender += new EventHandler(notizia1_PreRender);

	}

    void notizia1_PreRender(object sender, EventArgs e)
    {
        TitoloPagina = notizia1.Notizia.Titolo;
    }

    
    public List<Oggetti.Oggetto> ElencoNotizie
    {
        get
        {
            if (HttpContext.Current.Cache["ElencoNotizie"] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["ElencoNotizie"];
            }
            else
            {
                Notizie oNotizie = new Notizie(TipoOggetto.News);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oNotizie.GetAll(0, true,1);
                ElencoNotizie = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["ElencoNotizie"] = value; }
    }    
}
