using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Business.Oggetti;
using Gestione;

public partial class FotoVideo : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        repFoto.DataSource = GalleriePhoto;
        repFoto.DataBind();

        repVideo.DataSource = Video;
        repVideo.DataBind();
    }

    public List<Oggetto> GalleriePhoto
    {
        get
        {
            if (HttpContext.Current.Cache["GalleriePhoto"] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["GalleriePhoto"];
            }
            else
            {
                var oNotizie = new Notizie(TipoOggetto.Photogallery);
                var oOggetti = oNotizie.GetAll(0, true, 1);
                GalleriePhoto = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["GalleriePhoto"] = value; }
    }

    public List<Oggetto> Video
    {
        get
        {
            if (HttpContext.Current.Cache["Video"] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["Video"];
            }
            else
            {
                var oVideo = new Notizie(TipoOggetto.Video);
                var oOggetti = oVideo.GetAll(0, true, 1);
                Video = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["Video"] = value; }
    }
}
