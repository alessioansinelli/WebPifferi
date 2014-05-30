using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class be_uc_ucoggetto : System.Web.UI.UserControl
{

    private int IdNews
    {
        get
        {
            int iret = 0;
            if (Request["IdNews"] != null)
            {
                int.TryParse(Request["IdNews"].ToString(), out iret);
            }

            return iret;
        }
    }

    private TipoOggetto _TipoOggetto;
    public TipoOggetto TipoOggetto
    {
        set { _TipoOggetto = value; }
        get { return _TipoOggetto; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IdNews != 0)
        {
            imgNotizia.ObjectID = IdNews;
        }

        if (!Page.IsPostBack)
        {
            if (IdNews != 0)
            {                
                Oggetti.Oggetto oNotizia = new Notizie(TipoOggetto).Get(IdNews);
                Popolanotizia(oNotizia);
            }
        }

    }

    private void Popolanotizia(Oggetti.Oggetto oNotizia)
    {
        txtTitolo.Text = oNotizia.Titolo;        
        txtSottoTitolo.Text = oNotizia.SottoTitolo;
        txtTesto.Value = oNotizia.Testo;
    }


    protected void btnSalva_Click(object sender, EventArgs e)
    {
        if (txtTitolo.Text != "")
        {

						Notizie oNotizie = new Notizie(_TipoOggetto);
            Oggetti.Oggetto oNotizia = new Oggetti.Oggetto();

            if (IdNews != 0)
            {
                // MODIFICA
                oNotizia.Titolo = txtTitolo.Text.Trim();
                oNotizia.SottoTitolo = txtSottoTitolo.Text.Trim();
                oNotizia.Testo = txtTesto.Value;
                oNotizia.IdUtente = Business.ConstWrapper.UtenteLoggato.IdUtente;
                oNotizia.DataModifica = DateTime.Now;
                oNotizia.ID = IdNews;

                oNotizie.Update(oNotizia);

            }
            else
            {
                // NUOVO INSERIMENTO

                oNotizia.Titolo = txtTitolo.Text.Trim();
                oNotizia.SottoTitolo = txtSottoTitolo.Text.Trim();
                oNotizia.IdUtente = Business.ConstWrapper.UtenteLoggato.IdUtente;
                oNotizia.DataInserimento = DateTime.Now;
                oNotizia.DataModifica = DateTime.Now;
                oNotizia.TipoOggetto = _TipoOggetto;
                oNotizia.Testo = txtTesto.Value;

                int idnews = oNotizie.Add(oNotizia);

                switch (_TipoOggetto) { 
                    case TipoOggetto.Eventi:
                        Response.Redirect("/be/eventi.aspx");
                        break;
                    case TipoOggetto.News :
                        Response.Redirect("/be/news.aspx");
                        break;
                    case TipoOggetto.Homepage:
                        Response.Redirect("/be/homepage.aspx");
                        break;
                    case TipoOggetto.Photogallery:
                        Response.Redirect("/be/photogallery.aspx");
                        break;
                }

                
            }
        }
    }
    protected void btnAnnulla_Click(object sender, EventArgs e)
    {
        Response.Redirect("/be/news.aspx");
    }
    protected void insImmagine_Click(object sender, EventArgs e)
    {
        dettaglionews.Visible = false;
        gestioneimmagini.Visible = true;
        imgNotizia.TitoloOggettoParent = txtTitolo.Text.ToString();
    }
}
