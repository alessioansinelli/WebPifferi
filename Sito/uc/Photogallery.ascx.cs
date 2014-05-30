using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class uc_Photogallery : System.Web.UI.UserControl
{

    public string _TitoloGallery = "";
    public string _SottoTitoloGallery = "";
    public string _TestoGallery = "";
    public string _classname = "";
    public bool _ShowShare = false;
    private TipoOggetto _TipoOggetto;
    private bool _AllowPagination = false;
    private string _pageurl = "";
    public string _DataPubblicazione = "";
    public string _ShowShareUrl = "";
		public bool _ShowOnlyPhoto = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        int iPagina = 1;
        int iCount = int.Parse(System.Configuration.ConfigurationManager.AppSettings["countphoto"].ToString());
        if (Request["page"] != null)
        {
            int.TryParse(Request["Page"].ToString(), out iPagina);
        }

        PagedDataSource oDs = new PagedDataSource();
        oDs.AllowPaging = _AllowPagination;
        oDs.CurrentPageIndex = iPagina - 1;
        oDs.PageSize = iCount;

        Oggetti.Oggetto oFoto = Galleria;

        oDs.DataSource = oFoto.Foto;

        repFoto.DataSource = oDs;
        repFoto.DataBind();
        _TitoloGallery = oFoto.Titolo;
        _SottoTitoloGallery = oFoto.SottoTitolo;
        _SottoTitoloGallery = oFoto.Testo;
        _DataPubblicazione = oFoto.DataInserimento.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("it-IT"));


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
                oLi.InnerHtml = "<a href=\"" + _pageurl + "?id=" + Request["id"].ToString() + "&page=" + i + "\">" + i + "</a>";

                oUl.Controls.Add(oLi);

            }



            divPaginazione.Controls.Add(oUl);
        }
        else
        {
            divPaginazione.Visible = false;
        }

    }

    public Oggetti.Oggetto Galleria
    {
        get
        {
            if (HttpContext.Current.Cache["photogallery" + Request["id"].ToString()] != null)
            {
                return (Oggetti.Oggetto)HttpContext.Current.Cache["photogallery" + Request["id"].ToString()];
            }
            else
            {
                Oggetti.Oggetto oNews = new Notizie(_TipoOggetto).Get(int.Parse(Request["id"].ToString()), true, 0);
                HttpContext.Current.Cache["photogallery" + Request["id"].ToString()] = oNews;
                return oNews;
            }
        }
    }

    public bool AllowPagination
    {
        set { _AllowPagination = value; }
        get { return _AllowPagination; }
    }

    public string PageUrl
    {
        set { _pageurl = value; }
        get { return _pageurl; }
    }

    public TipoOggetto TipoOggetto
    {
        get { return _TipoOggetto; }
        set { _TipoOggetto = value; }
    }

    public string TitoloGallery
    {
        get { return Galleria.Titolo; }
    }

    public bool ShowShare
    {
        get { return _ShowShare; }
        set { _ShowShare = value; }
    }

    public string ShowShareUrl
    {
        get { return _ShowShareUrl; }
        set { _ShowShareUrl = value; }
    }

		public bool ShowOnlyPhoto
		{
			get { return _ShowOnlyPhoto; }
			set { _ShowOnlyPhoto = value; }
		}

}
