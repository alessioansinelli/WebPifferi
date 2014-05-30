using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class be_photogallery : CheckLoginPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            PopolaGridNews();
        }
    }
    protected void RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Notizie oNotizie = new Notizie(TipoOggetto.Photogallery);
        if (e.CommandName == "up")
        {
            
            //Immagini oImmagini = new Immagini();
            oNotizie.UpdateNumOrder(int.Parse(grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()), "UP");

            oNotizie = null;

        }
        else if (e.CommandName == "down")
        {
            //Immagini oImmagini = new Immagini();
            oNotizie.UpdateNumOrder(int.Parse(grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()), "DOWN");

            oNotizie = null;
        }
        else if (e.CommandName == "elimina")
        {
            oNotizie.Delete(int.Parse(grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()));
        }
        else if (e.CommandName == "modifica")
        {
            try
            {
                Response.Redirect("/be/photogalleryedit.aspx?IdNews=" + int.Parse(grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()));
            }catch(System.Threading.ThreadAbortException){
                // TODO
            }
        }

        PopolaGridNews();

    }

    private void PopolaGridNews() {
        Notizie oNotizie = new Notizie(TipoOggetto.Photogallery);
        List<Oggetti.Oggetto> oListaNews = oNotizie.GetAll(0);

        if (oListaNews.Count > 0)
        {
            grdNews.DataSource = oListaNews;
            grdNews.DataBind();
        }
    }
}
