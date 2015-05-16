using System;
using System.Web;
using Business.Oggetti;
using Gestione;

namespace uc
{
    public partial class UcSlider : System.Web.UI.UserControl
    {

        public string TitoloGallery = "";
        public string SottoTitoloGallery = "";
        public string TestoGallery = "";
        public string Classname = "";
        public bool ShowShare = false;
        public string DataPubblicazione = "";
        public string ShowShareUrl = "";
        public bool ShowOnlyPhoto = false;
        private string _slug = "";

        public string Slug { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        
        
            if (!string.IsNullOrEmpty(Slug)) {
                _slug = Slug;
            }
            else
            {
                _slug = Page.RouteData.Values["slug"] as string;
            }
        
        
            if (Fotografie.Foto.Length > 0)
            {
                repSlider.DataSource = Fotografie.Foto;
                repSlider.DataBind();
            }
        }

        public Oggetto Fotografie
        {
            get
            {
                if (HttpContext.Current.Cache["notizia-" + _slug] != null)
                {
                    return (Oggetto)HttpContext.Current.Cache["notizia-" + _slug];
                }
                else
                {
                    Oggetto oNews = new Notizie(TipoOggetto.News).Get(_slug, false, 0);
                    HttpContext.Current.Cache["notizia-" + _slug] = oNews;
                    return oNews;
                }
            }
        }

        public TipoOggetto TipoOggetto { get; set; }

        public string GetUrlPhoto(OggettoFoto oFoto, string dimensione, string cssClass)
        {
            var sret = "";
            if (oFoto != null)
            {
                sret = "<img src=\"" + ResolveUrl(Business.ConstWrapper.CartellaFoto + oFoto.Percorso + dimensione + oFoto.Estensione + "\" alt=\"" + oFoto.Titolo + "\" class=\"" + cssClass + "\" />");

            }

            return sret;
        }

    }
}
