using System;

namespace Business.Oggetti
{
    /// <summary>
    /// Summary description for OggettoLogin
    /// </summary>
    public class OggettoLogin
    {
        // COSTRUTTORE DELLA CLASSE OggettoLogin
        public OggettoLogin()
        {
            DataOraAccesso = DateTime.MinValue;
            IdUtente = 0;
            PwdUtente = string.Empty;
            NomeUtente = string.Empty;
        }

        public string NomeUtente { get; set; }

        public string PwdUtente { get; set; }

        public int IdUtente { get; set; }

        public DateTime DataOraAccesso { get; set; }
    }


    public class ObjFoto 
    {
        public ObjFoto()
        {
            Predefinita = 0;
            Tipologia = TipologiaFoto.Entity;
            NumOrder = 0;
            IdUtente = 0;
            DataFoto = DateTime.MinValue;
            PercorsoThumbFoto = "";
            PercorsoFoto = "";
            CommentoFoto = "";
            TitoloFoto = "";
            IdFoto = 0;
        }


        public int IdFoto { get; set; }

        public string TitoloFoto { get; set; }

        public string CommentoFoto { get; set; }

        public string PercorsoFoto { get; set; }

        public string PercorsoThumbFoto { get; set; }

        public DateTime DataFoto { get; set; }

        public int IdUtente { get; set; }

        public int NumOrder { get; set; }

        public TipologiaFoto Tipologia { get; set; }

        public int Predefinita { get; set; }
    }

    public class OggettoGalleria 
    {
        public OggettoGalleria()
        {
            ImmaginiGalleria = null;
            TotaleFoto = 0;
            DescrizioneGalleria = string.Empty;
            TitoloGalleria = string.Empty;
            IdGalleria = 0;
        }

        public int IdGalleria { get; set; }

        public string TitoloGalleria { get; set; }

        public string DescrizioneGalleria { get; set; }

        public int TotaleFoto { get; set; }

        public OggettoFoto[] ImmaginiGalleria { get; set; }
    }
    
    public enum AzioneForm {
        Edit = 0, Insert = 1
    }

    public enum TipologiaFoto
    {
        Entity = 0,
        News = 1,
        Prodotti = 2,
				Categoria = 3
    }

    public enum TipologiaEntity { 
        Entity = 0,
        News = 1,
        Categorie = 2,
        Prodotti = 3,
        CustomInput = 4
    }

}
