using System;
using System.Data;

namespace Business.Oggetti
{

    /// <summary>
    /// Summary description for OggettoBase
    /// </summary>
    public class OggettoBase
    {
        /* Specifiche per documenti e photo */

        public OggettoBase()
        {
            Testo = "";
            SottoTitolo = "";
            Titolo = "";
            IsHomeNews = false;
            NomeFileOggetto = "";
            PathFileOggetto = "";
            Id = 0;
        }

        /// <summary>
        /// ID presente sul Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titolo
        /// </summary>
        public string Titolo { get; set; }

        public string Slug { get; set; }

        /// <summary>
        /// SottoTitolo
        /// </summary>
        public string SottoTitolo { get; set; }

        /// <summary>
        /// Testo
        /// </summary>
        public string Testo { get; set; }

        /// <summary>
        /// Data inserimento
        /// </summary>
        public DateTime DataInserimento { get; set; }

        /// <summary>
        /// Data Modifica
        /// </summary>
        public DateTime DataModifica { get; set; }

        /// <summary>
        /// IdUtente
        /// </summary>
        public int IdUtente { get; set; }

        public TipoOggetto TipoOggetto { get; set; }

        public string PathFileOggetto { get; set; }

        public string NomeFileOggetto { get; set; }

        public int NumOrder { get; set; }

        public virtual void FromDataReader(IDataReader oDr)
        {
            Id = int.Parse(oDr["tObjectID"].ToString());
            Titolo = oDr["tObjectTitolo"].ToString();
            Testo = oDr["tObjectTesto"].ToString();
            SottoTitolo = oDr["tObjectSottoTitolo"].ToString();
            DataInserimento = DateTime.Parse(oDr["tObjectDataInserimento"].ToString());
            DataModifica = DateTime.Parse(oDr["tObjectDataModifica"].ToString());
            IdUtente = int.Parse(oDr["tObjectIDUtente"].ToString());
            TipoOggetto = (TipoOggetto)int.Parse(oDr["tObjectTypeID"].ToString());
            NumOrder = int.Parse(oDr["tObjectNumOrder"].ToString());
            Slug = oDr["slug"].ToString();
            bool isHomeNews;
            bool.TryParse(oDr["isHomeNews"].ToString(), out isHomeNews);
            IsHomeNews = isHomeNews;
        }

        public bool IsHomeNews { get; set; }
    }

    public enum TipoOggetto
    {
        Homepage = 0,
        News = 1,
        Photogallery = 2,
        Eventi = 3,
        Video = 4
    }

}
