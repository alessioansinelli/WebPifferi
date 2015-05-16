using System;
using System.Web.UI;

public partial class Dettaglionews : Page
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

}
