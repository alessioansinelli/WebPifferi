using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _photogallery : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TitleTag.Text = Photogallery1.TitoloGallery;

    }   

    public List<Oggetti.Oggetto> ElencoPhotogallery
    {
        get
        {
            if (HttpContext.Current.Cache["ElencoPhotogallery"] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["ElencoPhotogallery"];
            }
            else
            {
                Notizie oNotizie = new Notizie(TipoOggetto.Photogallery);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oNotizie.GetAll(0, true, 1);
                ElencoPhotogallery = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["ElencoPhotogallery"] = value; }
    }
	
}
