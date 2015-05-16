using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Business;
using Business.Oggetti;
using Gestione;

public partial class News : Page
{
    public string TitoloHomePage = "";
    public string SottoTitoloHomePage = "";
    public string TestoHomePage = "";
    public string ImmagineHomePage = "";
    private string _pageurl = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        int iPagina = 1;
        int iCount = int.Parse(ConfigurationManager.AppSettings["countnews"]);
        if (Request["page"] != null)
        {
            int.TryParse(Request["Page"], out iPagina);
        }

        // Gestione paginazione
        PagedDataSource oDs = new PagedDataSource();
        oDs.AllowPaging = true;
        oDs.CurrentPageIndex = iPagina - 1;
        oDs.PageSize = iCount;

        oDs.DataSource = ElencoNotizie;


        repnews.DataSource = oDs;
        repnews.DataBind();


        //paginazione 
        if (oDs.PageCount > 1)
        {

            HtmlGenericControl oUl = new HtmlGenericControl("ul");

            for (int i = 1; i < oDs.PageCount + 1; i++)
            {
                string cssclass = "elem";
                if (i == iPagina)
                {
                    cssclass += " sel";
                }

                HtmlGenericControl oLi = new HtmlGenericControl("li");
                oLi.Attributes.Add("class", cssclass);
                oLi.InnerHtml = "<a href=\"" + _pageurl + "?page=" + i + "\">" + i + "</a>";

                oUl.Controls.Add(oLi);

            }



            divPaginazione.Controls.Add(oUl);
        }
        else
        {
            divPaginazione.Visible = false;
        }


    }

    public string GetUrlPhoto(OggettoFoto[] oFoto, string dimensione)
    {
        string sret = "";
        if (oFoto.Length > 0)
        {
            sret = "<img src=\"" + ResolveUrl(ConstWrapper.CartellaFoto + oFoto[0].Percorso + dimensione + oFoto[0].Estensione + "\" alt=\"" + oFoto[0].Titolo + "\" />");

        }

        return sret;
    }


    public List<Oggetto> ElencoNotizie
    {
        get
        {
            if (HttpContext.Current.Cache["ElencoNotizie"] != null)
            {
                return (List<Oggetto>)HttpContext.Current.Cache["ElencoNotizie"];
            }
            else
            {
                var oNotizie = new Notizie(TipoOggetto.News);
                var oOggetti = oNotizie.GetAll(0, true, 1);
                ElencoNotizie = oOggetti;
                return oOggetti;
            }
        }
        set { HttpContext.Current.Cache["ElencoNotizie"] = value; }
    }
}
