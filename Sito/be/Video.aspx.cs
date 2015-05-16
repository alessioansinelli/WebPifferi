using System;
using System.Web.UI.WebControls;
using Business.Oggetti;
using Gestione;

namespace be
{
    public partial class BeVideo : CheckLoginPage
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
            TipoOggetto[] otipoOggetto = new TipoOggetto[1];
            otipoOggetto[0] = TipoOggetto.Video;
        
            Notizie oNotizie = new Notizie(otipoOggetto);
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
                        Response.Redirect("/be/VideoEdit.aspx?IdNews=" + int.Parse(dataKey.Value.ToString()));
                }
                catch(System.Threading.ThreadAbortException){
                    // TODO
                }
            }

            PopolaGridNews();

        }

        private void PopolaGridNews() {

            var otipoOggetto = new TipoOggetto[1];
            otipoOggetto[0] = TipoOggetto.Video;

            var oNotizie = new Notizie(otipoOggetto);
            var oListaNews = oNotizie.GetAll(0);

            if (oListaNews.Count <= 0) return;
            grdNews.DataSource = oListaNews;
            grdNews.DataBind();
        }
    }
}
