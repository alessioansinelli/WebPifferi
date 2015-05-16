using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Business.Oggetti;
using Gestione;

public partial class Video : Page
{

	public string TitoloHomePage = "";
	public string SottoTitoloHomePage = "";
	public string TestoHomePage = "";
	public string ImmagineHomePage = "";
    public string TitoloPagina = "";

	protected void Page_Load(object sender, EventArgs e)
	{
        notizia1.PreRender += notizia1_PreRender;
	}

    void notizia1_PreRender(object sender, EventArgs e)
    {
        TitoloPagina = notizia1.Notizia.Titolo;
    }

    
    public List<Oggetto> ElencoNotizie
    {
        get
        {
            if (HttpContext.Current.Cache["ElencoNotizie"] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["ElencoNotizie"];
            }
            else
            {
                var oNotizie = new Notizie(TipoOggetto.News);
                var oOggetti = oNotizie.GetAll(0, true,1);
                ElencoNotizie = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["ElencoNotizie"] = value; }
    }    
}
