using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_EditorialRepeater : System.Web.UI.UserControl
{
    #region Property
    public TipoOggetto TipoOggetto { get; set; }
    public int Count { get; set; }
    public string Titolo { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        repEventi.DataSource = Eventi;
        repEventi.DataBind();
    }

    public List<Oggetti.Oggetto> Eventi
    {
        get
        {
            if (HttpContext.Current.Cache["EditorialRepeater" + this.ID] != null)
            {
                return (List<Oggetti.Oggetto>)HttpContext.Current.Cache["EditorialRepeater" + this.ID];
            }
            else
            {
                Notizie oNotizie = new Notizie(TipoOggetto);
                List<Oggetti.Oggetto> oOggetti = new List<Oggetti.Oggetto>();
                oOggetti = oNotizie.GetAll(Count, true, 1);
                Eventi = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["EditorialRepeater" + this.ID] = value; }
    }


}
