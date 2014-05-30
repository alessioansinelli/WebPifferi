using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace Oggetti
{

    public class Oggetto : OggettoBase
    {

        private OggettoFoto[] _Foto;
        public OggettoFoto[] Foto
        {
            set { _Foto = value; }
            get { return _Foto; }
        }

        public Oggetto()
        {
            //this.TipoOggetto = TipoOggetto.News;
        }

        public Oggetto(TipoOggetto TipoOggetto)
        {
            //this.TipoOggetto = TipoOggetto;
        }

        public override void FromDataReader(IDataReader oDr)
        {
            base.FromDataReader(oDr);
        }
    }

}
