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

        notizia1.PreRender += new EventHandler(notizia1_PreRender);

	}

    void notizia1_PreRender(object sender, EventArgs e)
    {
        TitoloPagina = notizia1.Notizia.Titolo;
    }

}
