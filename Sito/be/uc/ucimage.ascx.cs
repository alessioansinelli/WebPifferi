using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class be_uc_ucimage : System.Web.UI.UserControl
{
    private int _ObjectID = 0;
    public int ObjectID
    {
        get { return _ObjectID; }
        set { _ObjectID = value; }
    }
    private string _TitoloOggettoParent = "";
    
    public string TitoloOggettoParent {
        get { return _TitoloOggettoParent; }
        set { _TitoloOggettoParent = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (_ObjectID != 0 && !IsPostBack)
        {
            PopolaGrigliaImmagini(_ObjectID);
        }
    }
    protected void RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Immagini oImmagini = new Immagini();
        if (e.CommandName == "up")
        {

            //Immagini oImmagini = new Immagini();
					oImmagini.UpdateNumOrder(int.Parse(grdImmagini.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()), "UP", _ObjectID);

            oImmagini = null;

        }
        else if (e.CommandName == "down")
        {
            //Immagini oImmagini = new Immagini();
					oImmagini.UpdateNumOrder(int.Parse(grdImmagini.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()), "DOWN", _ObjectID);

            oImmagini = null;
        }
        else if (e.CommandName == "elimina")
        {
					oImmagini.Delete(int.Parse(grdImmagini.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()), _ObjectID);
        }


        PopolaGrigliaImmagini(_ObjectID);
    }
    protected void btnSalva_Click(object sender, EventArgs e)
    {
        Immagini oImmagini = new Immagini();
        int newId = 0;
        try { newId = oImmagini.GetNewID(); }
        catch { newId = 1; }

        Oggetti.OggettoFoto oFoto = new Oggetti.OggettoFoto();
        oFoto.Titolo = txtTitoloImmagine.Text.Trim();
        oFoto.SottoTitolo = txtSottoTitoloImmagine.Text.Trim();
        oFoto.DataInserimento = DateTime.Now;
        oFoto.ID = newId;
        oFoto.ParentObjectID = _ObjectID;
        oFoto.NumOrder = 1;
        string outPercorso = "";
        string outEstensione = "";

			byte[] b;
			using (MemoryStream ms = new MemoryStream())
			{
        uplImage.PostedFile.InputStream.CopyTo(ms);
        b = ms.ToArray();
			}

        oImmagini.SalvaImmaginePost(b, uplImage.PostedFile.FileName,oFoto, newId, out outPercorso, out outEstensione);

        oFoto.Estensione = outEstensione;
        oFoto.Percorso = outPercorso;

        oImmagini.Add(oFoto);

        oFoto.Percorso = outPercorso;
        oFoto.Estensione = outEstensione;

        PopolaGrigliaImmagini(_ObjectID);

    }
    protected void btnAnnulla_Click(object sender, EventArgs e)
    {

    }

    private void PopolaGrigliaImmagini(int ParentObjectID)
    {
        if (_ObjectID != 0)
        {
            Immagini oImmagini = new Immagini();
            List<Oggetti.OggettoFoto> oFoto = oImmagini.GetAll(_ObjectID, 0);

            grdImmagini.DataSource = oFoto;
            grdImmagini.DataBind();
        }
    }
}
