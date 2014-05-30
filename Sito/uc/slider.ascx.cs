using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class uc_slider : System.Web.UI.UserControl
{

    public string _TitoloGallery = "";
    public string _SottoTitoloGallery = "";
    public string _TestoGallery = "";
    public string _classname = "";
    public bool _ShowShare = false;
    private TipoOggetto _TipoOggetto;
    private bool _AllowPagination = false;
    private string _pageurl = "";
    public string _DataPubblicazione = "";
    public string _ShowShareUrl = "";
    public bool _ShowOnlyPhoto = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Fotografie.Foto.Length > 0)
        {
            repSlider.DataSource = Fotografie.Foto;
            repSlider.DataBind();
        }
    }

    public Oggetti.Oggetto Fotografie
    {
        get
        {
            if (HttpContext.Current.Cache["notizia" + Request["id"].ToString()] != null)
            {
                return (Oggetti.Oggetto)HttpContext.Current.Cache["notizia" + Request["id"].ToString()];
            }
            else
            {
                Oggetti.Oggetto oNews = new Notizie(TipoOggetto.News).Get(int.Parse(Request["id"].ToString()), false, 0);
                HttpContext.Current.Cache["notizia" + Request["id"].ToString()] = oNews;
                return oNews;
            }
        }
    }

    public TipoOggetto TipoOggetto
    {
        get { return _TipoOggetto; }
        set { _TipoOggetto = value; }
    }

    public string getUrlPhoto(Oggetti.OggettoFoto oFoto, string Dimensione, string cssClass)
    {
        string sret = "";
        if (oFoto != null)
        {
            sret = "<img src=\"" + ResolveUrl(Business.ConstWrapper.CartellaFoto + oFoto.Percorso + Dimensione + oFoto.Estensione + "\" alt=\"" + oFoto.Titolo + "\" class=\"" + cssClass + "\" />");

        }

        return sret;
    }

}
