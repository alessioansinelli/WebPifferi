using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Gestione;
using Business.Oggetti;

namespace be.uc
{

    public partial class BeUcUcimage : UserControl
    {
        public int ObjectId { get; set; }

        public BeUcUcimage()
        {
            TitoloOggettoParent = "";
            ObjectId = 0;
        }

        public string TitoloOggettoParent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ObjectId != 0 && !IsPostBack)
            {
                PopolaGrigliaImmagini(ObjectId);
            }
        }
        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Immagini oImmagini = new Immagini();
            if (e.CommandName == "up")
            {
                //Immagini oImmagini = new Immagini();
                var dataKey = grdImmagini.DataKeys[int.Parse(e.CommandArgument.ToString())];
                if (dataKey != null)
                    oImmagini.UpdateNumOrder(int.Parse(dataKey.Value.ToString()), "UP", ObjectId);
            }
            else if (e.CommandName == "down")
            {
                //Immagini oImmagini = new Immagini();
                var dataKey = grdImmagini.DataKeys[int.Parse(e.CommandArgument.ToString())];
                if (dataKey != null)
                    oImmagini.UpdateNumOrder(int.Parse(dataKey.Value.ToString()), "DOWN", ObjectId);
            }
            else if (e.CommandName == "elimina")
            {
                var dataKey = grdImmagini.DataKeys[int.Parse(e.CommandArgument.ToString())];
                if (dataKey != null)
                    oImmagini.Delete(int.Parse(dataKey.Value.ToString()), ObjectId);
            }


            PopolaGrigliaImmagini(ObjectId);
        }
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            var oImmagini = new Immagini();
            int newId;
            try { newId = oImmagini.GetNewId(); }
            catch { newId = 1; }

            OggettoFoto oFoto = new OggettoFoto();
            oFoto.Titolo = txtTitoloImmagine.Text.Trim();
            oFoto.SottoTitolo = txtSottoTitoloImmagine.Text.Trim();
            oFoto.DataInserimento = DateTime.Now;
            oFoto.Id = newId;
            oFoto.ParentObjectId = ObjectId;
            oFoto.NumOrder = 1;
            string outPercorso;
            string outEstensione;

            byte[] b;
            using (MemoryStream ms = new MemoryStream())
            {
                uplImage.PostedFile.InputStream.CopyTo(ms);
                b = ms.ToArray();
            }

            oImmagini.SalvaImmaginePost(b, uplImage.PostedFile.FileName, oFoto, newId, out outPercorso, out outEstensione);

            oFoto.Estensione = outEstensione;
            oFoto.Percorso = outPercorso;

            oImmagini.Add(oFoto);

            oFoto.Percorso = outPercorso;
            oFoto.Estensione = outEstensione;

            PopolaGrigliaImmagini(ObjectId);

        }
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {

        }

        private void PopolaGrigliaImmagini(int parentObjectId = 0)
        {
            if (parentObjectId == 0) return;
            var oImmagini = new Immagini();
            var oFoto = oImmagini.GetAll(parentObjectId, 0);

            grdImmagini.DataSource = oFoto;
            grdImmagini.DataBind();
        }
    }

}
