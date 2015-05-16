using System;
using Business;
using Business.Oggetti;
using Gestione;

namespace be.uc {

public partial class BeUcUcoggetto : System.Web.UI.UserControl
{

    private int IdNews
    {
        get
        {
            var iret = 0;
            if (Request["IdNews"] != null)
            {
                int.TryParse(Request["IdNews"], out iret);
            }

            return iret;
        }
    }

    public TipoOggetto TipoOggetto { set; get; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IdNews != 0)
        {
            imgNotizia.ObjectId = IdNews;
        }

        if (!Page.IsPostBack)
        {
            if (IdNews != 0)
            {
                Oggetto oNotizia = new Notizie(TipoOggetto).Get(IdNews);
                Popolanotizia(oNotizia);
            }
        }

    }

    private void Popolanotizia(Oggetto oNotizia)
    {
        txtTitolo.Text = oNotizia.Titolo;
        txtSottoTitolo.Text = oNotizia.SottoTitolo;
        txtTesto.Value = oNotizia.Testo;
        txtSlug.Text = oNotizia.Slug;
    }


    protected void btnSalva_Click(object sender, EventArgs e)
    {
        if (txtTitolo.Text != "")
        {

            var oNotizie = new Notizie(TipoOggetto);
            var oNotizia = new Oggetto();

            if (IdNews != 0)
            {
                // MODIFICA
                oNotizia.Titolo = txtTitolo.Text.Trim();
                oNotizia.SottoTitolo = txtSottoTitolo.Text.Trim();
                oNotizia.Testo = txtTesto.Value;
                oNotizia.IdUtente = ConstWrapper.UtenteLoggato.IdUtente;
                oNotizia.DataModifica = DateTime.Now;
                oNotizia.Id = IdNews;
                oNotizia.Slug = txtSlug.Text.Trim();

                oNotizie.Update(oNotizia);

            }
            else
            {
                // NUOVO INSERIMENTO

                oNotizia.Titolo = txtTitolo.Text.Trim();
                oNotizia.SottoTitolo = txtSottoTitolo.Text.Trim();
                oNotizia.IdUtente = ConstWrapper.UtenteLoggato.IdUtente;
                oNotizia.DataInserimento = DateTime.Now;
                oNotizia.DataModifica = DateTime.Now;
                oNotizia.TipoOggetto = TipoOggetto;
                oNotizia.Testo = txtTesto.Value;
                oNotizia.Slug = txtSlug.Text.Trim();


                oNotizie.Add(oNotizia);

                switch (TipoOggetto)
                {
                    case TipoOggetto.News:
                        Response.Redirect("/be/news.aspx");
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
        imgNotizia.TitoloOggettoParent = txtTitolo.Text;
    }
    protected void TitoloChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtTitolo.Text))
        {
            if (string.IsNullOrEmpty(txtSlug.Text))
            {
                txtSlug.Text = Utility.GenerateSlug(txtTitolo.Text);
            }
        }
    }
}
}