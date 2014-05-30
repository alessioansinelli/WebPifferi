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
    /// <summary>
    /// Summary description for OggettoLogin
    /// </summary>
    public class OggettoLogin
    {

        private int _IdUtente = 0;
        private string _NomeUtente = string.Empty;
        private string _PwdUtente = string.Empty;
        DateTime _DataOraAccesso = DateTime.MinValue;

        
        // COSTRUTTORE DELLA CLASSE OggettoLogin
        public OggettoLogin()
        {
            
        }

        public string NomeUtente{
            get { return _NomeUtente; }
            set { _NomeUtente = value; }
        }

        public string PwdUtente
        {
            get { return _PwdUtente; }
            set { _PwdUtente = value; }
        }

        public int IdUtente {
            get { return _IdUtente; }
            set { _IdUtente = value; }
        }

        public DateTime DataOraAccesso 
        {
            get { return _DataOraAccesso; }
            set { _DataOraAccesso = value; }
        }
    }


    public class ObjFoto 
    {
        private int _Id_Foto = 0;
        private string _Titolo_Foto = "";
        private string _Commento_Foto = "";
        private string _Percorso_Foto = "";
        private string _Percorso_Thumb_Foto = "";
        private DateTime _Data_Foto = DateTime.MinValue;
        private int _Id_Utente = 0;
        private int _NumOrder = 0;
        private TipologiaFoto _Tipologia = TipologiaFoto.Entity;
        private int _Predefinita = 0;
        


        public int Id_Foto {
            get { return _Id_Foto; }
            set { _Id_Foto = value; }
        }

        public string Titolo_Foto {
            get { return _Titolo_Foto; }
            set { _Titolo_Foto = value; }
        }

        public string Commento_Foto
        {
            get { return _Commento_Foto; }
            set { _Commento_Foto = value; }
        }

        public string Percorso_Foto
        {
            get { return _Percorso_Foto; }
            set { _Percorso_Foto = value; }
        }

        public string Percorso_Thumb_Foto
        {
            get { return _Percorso_Thumb_Foto; }
            set { _Percorso_Thumb_Foto = value; }
        }

        public DateTime Data_Foto {
            get { return _Data_Foto; }
            set { _Data_Foto = value; }
        }

        public int Id_Utente {
            get { return _Id_Utente; }
            set { _Id_Utente = value; }
        }

        public int NumOrder {
            get { return _NumOrder; }
            set { _NumOrder = value; }
        }

        public TipologiaFoto Tipologia
        {
            get { return _Tipologia; }
            set { _Tipologia = value; }
        }

        public int Predefinita
        {
            get { return _Predefinita; }
            set { _Predefinita = value; }
        }

    }

    public class OggettoGalleria 
    {
        private int _IdGalleria = 0;
        private string _TitoloGalleria = string.Empty;
        private string _DescrizioneGalleria = string.Empty;
        private int _TotaleFoto = 0;
        private Oggetti.OggettoFoto[] _ImmaginiGalleria = null;

        public int IdGalleria 
        {
            get { return _IdGalleria; }
            set { _IdGalleria = value; }
        }
        
        public string TitoloGalleria
        {
            get { return _TitoloGalleria; }
            set { _TitoloGalleria = value; }
        }

        public string DescrizioneGalleria 
        {
            get { return _DescrizioneGalleria; }
            set { _DescrizioneGalleria = value; }
        }

        public int TotaleFoto 
        {
            get { return _TotaleFoto; }
            set { _TotaleFoto = value; }
        }

        public Oggetti.OggettoFoto[] ImmaginiGalleria 
        {
            get { return _ImmaginiGalleria; }
            set { _ImmaginiGalleria = value; }
        }

    }
    
    public enum AzioneForm {
        EDIT = 0, INSERT = 1
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
