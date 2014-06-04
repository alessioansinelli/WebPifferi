using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _fotoVideo : CheckLoginPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        repFoto.DataSource = GalleriePhoto;
        repFoto.DataBind();

        repVideo.DataSource = Video;
        repVideo.DataBind();
    }

    public List<Oggetti.Oggetto> GalleriePhoto
    {
        get
        {
            if (HttpContext.Current.Cache["GalleriePhoto"] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["GalleriePhoto"];
            }
            else
            {
                Notizie oNotizie = new Notizie(TipoOggetto.Photogallery);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oNotizie.GetAll(0, true, 1);
                GalleriePhoto = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["GalleriePhoto"] = value; }
    }

    public List<Oggetti.Oggetto> Video
    {
        get
        {
            if (HttpContext.Current.Cache["Video"] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["Video"];
            }
            else
            {
                Notizie oVideo = new Notizie(TipoOggetto.Video);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oVideo.GetAll(0, true, 1);
                Video = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["Video"] = value; }
    }
}
