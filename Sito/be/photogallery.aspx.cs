using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Business.Oggetti;
using Gestione;

namespace be
{
    public partial class BePhotogallery : CheckLoginPage
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
                var dataKey = grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())];
                if (dataKey != null)
                    oNotizie.UpdateNumOrder(int.Parse(dataKey.Value.ToString()), "UP");
            }
            else if (e.CommandName == "down")
            {
                //Immagini oImmagini = new Immagini();
                var dataKey = grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())];
                if (dataKey != null)
                    oNotizie.UpdateNumOrder(int.Parse(dataKey.Value.ToString()), "DOWN");
            }
            else if (e.CommandName == "elimina")
            {
                var dataKey = grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())];
                if (dataKey != null)
                    oNotizie.Delete(int.Parse(dataKey.Value.ToString()));
            }
            else if (e.CommandName == "modifica")
            {
                try
                {
                    var dataKey = grdNews.DataKeys[int.Parse(e.CommandArgument.ToString())];
                    if (dataKey != null)
                        Response.Redirect("/be/photogalleryedit.aspx?IdNews=" + int.Parse(dataKey.Value.ToString()));
                }
                catch(System.Threading.ThreadAbortException){
                    // TODO
                }
            }

            PopolaGridNews();

        }

        private void PopolaGridNews() {
            Notizie oNotizie = new Notizie(TipoOggetto.Photogallery);
            List<Oggetto> oListaNews = oNotizie.GetAll(0);

            if (oListaNews.Count > 0)
            {
                grdNews.DataSource = oListaNews;
                grdNews.DataBind();
            }
        }
    }
}
