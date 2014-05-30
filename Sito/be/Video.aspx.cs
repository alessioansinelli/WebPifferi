using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class be_video : CheckLoginPage
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
        TipoOggetto[] OtipoOggetto = new TipoOggetto[1];
        OtipoOggetto[0] = TipoOggetto.Video;
        
        Notizie oNotizie = new Notizie(OtipoOggetto);
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
                Response.Redirect("/be/VideoEdit.aspx?IdNews=" + int.Parse(grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()));
            }catch(System.Threading.ThreadAbortException){
                // TODO
            }
        }

        PopolaGridNews();

    }

    private void PopolaGridNews() {

        TipoOggetto[] OtipoOggetto = new TipoOggetto[1];
        OtipoOggetto[0] = TipoOggetto.Video;

        Notizie oNotizie = new Notizie(OtipoOggetto);
        List<Oggetti.Oggetto> oListaNews = oNotizie.GetAll(0);

        if (oListaNews.Count > 0)
        {
            grdNews.DataSource = oListaNews;
            grdNews.DataBind();
        }
    }
}
