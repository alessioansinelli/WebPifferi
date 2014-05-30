using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_Appuntamenti : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        repEventi.DataSource = Eventi;
        repEventi.DataBind();
    }

    public List<Oggetti.Oggetto> Eventi
    {
        get
        {
            if (HttpContext.Current.Cache["Appuntamenti"] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["Appuntamenti"];
            }
            else
            {
								TipoOggetto[] objTipoOggetto = new TipoOggetto[2];
								objTipoOggetto[0] = TipoOggetto.Eventi;
								objTipoOggetto[1] = TipoOggetto.News;
                Notizie oNotizie = new Notizie(objTipoOggetto);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oNotizie.GetAll(3, true, 1);
                Eventi = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["Appuntamenti"] = value; }
    }
}
