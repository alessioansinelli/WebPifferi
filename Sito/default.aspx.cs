using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page
{

    public string TitoloHomePage = "";
    public string SottoTitoloHomePage = "";
    public string TestoHomePage = "";
    public string ImmagineHomePage = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        // popolo la notizia centrale dell'home page
        List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
        //oOggetti = oNotizie.GetAll(1,true);
        oOggetti = NotiziaCentraleHomePage;

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

        oOggetti = new List<Oggetti.Oggetto>();
        oOggetti = NotiziePrimoPiano;
        
        if (NotiziaCentraleHomePage.Count() > 0)
        {
            repSliderHome.DataSource = NotiziaCentraleHomePage;
            repSliderHome.DataBind();
        }


    }

    public string getUrlPhoto(Oggetti.OggettoFoto[] oFoto, string Dimensione, string cssClass)
    {
        string sret = "";
        if (oFoto.Length > 0)
        {
            sret = "<img src=\"" + ResolveUrl(Business.ConstWrapper.CartellaFoto + oFoto[0].Percorso + Dimensione + oFoto[0].Estensione + "\" alt=\"" + oFoto[0].Titolo + "\" class=\""+ cssClass +"\" />");

        }

        return sret;
    }

    public List<Oggetti.Oggetto> NotiziaCentraleHomePage
    {
        get
        {
            if (HttpContext.Current.Cache["NotiziaCentraleHomePage"] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["NotiziaCentraleHomePage"];
            }
            else
            {
                Notizie oNotizie = new Notizie(TipoOggetto.News);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oNotizie.GetHomePage(10, true);
                NotiziaCentraleHomePage = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["NotiziaCentraleHomePage"] = value; }
    }

    public List<Oggetti.Oggetto> NotiziePrimoPiano
    {
        get
        {
            if (HttpContext.Current.Cache["NotiziePrimoPiano"] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["NotiziePrimoPiano"];
            }
            else
            {
                Notizie oNotizie = new Notizie(TipoOggetto.News);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oNotizie.GetHomePage(5, false);
                NotiziePrimoPiano = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["NotiziePrimoPiano"] = value; }
    }

    public List<Oggetti.Oggetto> Eventi
    {
        get
        {
            if (HttpContext.Current.Cache["EventiHome"] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["EventiHome"];
            }
            else
            {
                Notizie oNotizie = new Notizie(TipoOggetto.Eventi);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oNotizie.GetAll(3, true, 1);
                Eventi = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["EventiHome"] = value; }
    }
}
