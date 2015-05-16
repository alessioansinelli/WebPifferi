using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Business.Oggetti;
using Gestione;

namespace uc
{
    public partial class UcPhotogallery : System.Web.UI.UserControl
    {       
        public string TestoGallery = "";
        public string Classname = "";
        public string DataPubblicazione = "";
        public string Anno, Mese, Giorno;
        private string _slug = "";

        public UcPhotogallery()
        {
            PageUrl = "";
            ShowShareUrl = "";
        }

        public string Slug { get; set; }
        public bool HideTitle { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            int iPagina = 1;
            int iCount = int.Parse(System.Configuration.ConfigurationManager.AppSettings["countphoto"]);
            if (Request["page"] != null)
            {
                int.TryParse(Request["Page"], out iPagina);
            }

            PagedDataSource oDs = new PagedDataSource();
            oDs.AllowPaging = AllowPagination;
            oDs.CurrentPageIndex = iPagina - 1;
            oDs.PageSize = iCount;

            Oggetto oFoto = Galleria;
            oDs.DataSource = oFoto.Foto;

            repFoto.DataSource = oDs;
            repFoto.DataBind();
            Anno = oFoto.DataInserimento.ToString("yyyy", new System.Globalization.CultureInfo("it-IT"));
            Mese = oFoto.DataInserimento.ToString("MMM", new System.Globalization.CultureInfo("it-IT")).ToUpper();
            Giorno = oFoto.DataInserimento.ToString("dd", new System.Globalization.CultureInfo("it-IT"));


            //paginazione 
            if (oDs.PageCount > 1)
            {

                var oUl = new HtmlGenericControl("ul");

                for (int i = 1; i < oDs.PageCount + 1; i++)
                {
                    string cssclass = "elem";
                    if (i == iPagina)
                    {
                        cssclass += " sel";
                    }

                    var oLi = new HtmlGenericControl("li");
                    oLi.Attributes.Add("class", cssclass);
                    oLi.InnerHtml = "<a href=\"" + PageUrl + "?id=" + Request["id"] + "&page=" + i + "\">" + i + "</a>";

                    oUl.Controls.Add(oLi);

                }



                divPaginazione.Controls.Add(oUl);
            }
            else
            {
                divPaginazione.Visible = false;
            }

        }

        public Oggetto Galleria
        {
            get
            {
                if (string.IsNullOrEmpty(Slug))
                {
                    _slug = Page.RouteData.Values["slug"] as string;
                }
                else
                {
                    _slug = Slug;
                }
            

                if (HttpContext.Current.Cache["photogallery-" + _slug] != null)
                {
                    return (Oggetto)HttpContext.Current.Cache["photogallery-" + _slug];
                }
                else
                {                
                    var oNews = new Notizie(TipoOggetto).Get(_slug, true, 0);
                    HttpContext.Current.Cache["photogallery-" + _slug] = oNews;
                    return oNews;
                }
            }
        }

        public bool AllowPagination { set; get; }

        public string PageUrl { set; get; }

        public TipoOggetto TipoOggetto { get; set; }

        public string TitoloGallery
        {
            get { return Galleria.Titolo; }
        }

        public bool ShowShare { get; set; }

        public string ShowShareUrl { get; set; }

        public bool ShowOnlyPhoto { get; set; }
    }
}
