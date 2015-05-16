using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Business.Oggetti;
using Gestione;

public partial class Photogallery : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TitleTag.Text = Photogallery1.TitoloGallery;

    }   

    public List<Oggetto> ElencoPhotogallery
    {
        get
        {
            if (HttpContext.Current.Cache["ElencoPhotogallery"] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["ElencoPhotogallery"];
            }
            var oNotizie = new Notizie(TipoOggetto.Photogallery);
            var oOggetti = oNotizie.GetAll(0, true, 1);
            ElencoPhotogallery = oOggetti;
            return oOggetti;
        }
        set { HttpContext.Current.Cache["ElencoPhotogallery"] = value; }
    }
	
}
