using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Business.Oggetti;
using Gestione;

public partial class Default : Page
{

    public string TitoloHomePage = "";
    public string SottoTitoloHomePage = "";
    public string TestoHomePage = "";
    public string ImmagineHomePage = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        // popolo la notizia centrale dell'home page
        //oOggetti = oNotizie.GetAll(1,true);
        var oOggetti = NotiziaCentraleHomePage;

        if (oOggetti.Count > 0)
        {
            TitoloHomePage = oOggetti[0].Titolo;
            SottoTitoloHomePage = oOggetti[0].SottoTitolo;
            TestoHomePage = oOggetti[0].Testo;
            if (oOggetti[0].Foto != null)
            {
                ImmagineHomePage = ResolveUrl(Business.ConstWrapper.CartellaFoto + oOggetti[0].Foto[0].Percorso + "w8" + oOggetti[0].Foto[0].Estensione);
            }
        }

        if (!NotiziaCentraleHomePage.Any()) return;
        repSliderHome.DataSource = NotiziaCentraleHomePage;
        repSliderHome.DataBind();
    }

    public string GetUrlPhoto(OggettoFoto[] oFoto, string dimensione, string cssClass)
    {
        string sret = "";
        if (oFoto.Length > 0)
        {
            sret = "<img src=\"" + ResolveUrl(Business.ConstWrapper.CartellaFoto + oFoto[0].Percorso + dimensione + oFoto[0].Estensione + "\" alt=\"" + oFoto[0].Titolo + "\" class=\""+ cssClass +"\" />");

        }

        return sret;
    }

    public List<Oggetto> NotiziaCentraleHomePage
    {
        get
        {
            if (HttpContext.Current.Cache["NotiziaCentraleHomePage"] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["NotiziaCentraleHomePage"];
            }
            else
            {
                var oNotizie = new Notizie(TipoOggetto.News);
                var oOggetti = oNotizie.GetHomePage(10, true);
                NotiziaCentraleHomePage = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["NotiziaCentraleHomePage"] = value; }
    }

    public List<Oggetto> NotiziePrimoPiano
    {
        get
        {
            if (HttpContext.Current.Cache["NotiziePrimoPiano"] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["NotiziePrimoPiano"];
            }
            else
            {
                var oNotizie = new Notizie(TipoOggetto.News);
                var oOggetti = oNotizie.GetHomePage(5, false);
                NotiziePrimoPiano = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["NotiziePrimoPiano"] = value; }
    }

    public List<Oggetto> Eventi
    {
        get
        {
            if (HttpContext.Current.Cache["EventiHome"] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["EventiHome"];
            }
            else
            {
                var oNotizie = new Notizie(TipoOggetto.Eventi);
                var oOggetti = oNotizie.GetAll(3, true, 1);
                Eventi = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["EventiHome"] = value; }
    }
}
