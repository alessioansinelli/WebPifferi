using System;
using System.Collections.Generic;
using System.Web;
using Business.Oggetti;
using Gestione;

public partial class uc_EditorialRepeater : System.Web.UI.UserControl
{
    #region Property
    public TipoOggetto TipoRepeater { get; set; }
    public int Count { get; set; }
    public string Titolo { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        repEventi.DataSource = Eventi;
        repEventi.DataBind();
    }

    public List<Oggetto> Eventi
    {
        get
        {
            if (HttpContext.Current.Cache["EditorialRepeater" + this.ID] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["EditorialRepeater" + this.ID];
            }
            else
            {
                Notizie oNotizie = new Notizie(TipoOggetto.News);
                List<Oggetto> oOggetti = new List<Oggetto>();
                oOggetti = oNotizie.GetAll(Count, true, 1);
                Eventi = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["EditorialRepeater" + this.ID] = value; }
    }


}
