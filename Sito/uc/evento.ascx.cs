using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_evento : System.Web.UI.UserControl
{

    public string TitoloNotizia = "";
    public string SottoTitolo = "";
    public string TestoNotizia = "";
    public string DataInserimento = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Oggetti.Oggetto oNotizia = Notizia;
        TitoloNotizia = oNotizia.Titolo;
        SottoTitolo = oNotizia.SottoTitolo;
        TestoNotizia = oNotizia.Testo;
        DataInserimento = oNotizia.DataInserimento.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("it-IT"));
    }

    public Oggetti.Oggetto Notizia {
        get {
            if (HttpContext.Current.Cache["evento" + Request["id"].ToString()] != null)
            {
                return (Oggetti.Oggetto)HttpContext.Current.Cache["evento" + Request["id"].ToString()];
            }
            else
            {
                Oggetti.Oggetto oNews = new Notizie(TipoOggetto.Eventi).Get(int.Parse(Request["id"].ToString()), false, 0);
                HttpContext.Current.Cache["evento" + Request["id"].ToString()] = oNews;
                return oNews;
            }
        }
    }
}
