using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace Oggetti
{


	/// <summary>
	/// Summary description for Foto
	/// </summary>
	public class OggettoFoto
	{

        private int _ID = 0;
        private string _Titolo = "";
        private string _SottoTitolo = "";
        private string _Percorso = "";
        private DateTime _DataInserimento = DateTime.Now;
        private int _ParentObjectID = 0;
        private int _NumOrder = 0;
        private string _Estensione = "";

        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }
        
        public string Titolo{
            get { return _Titolo; }
            set { _Titolo = value; }
        }

        public string SottoTitolo
        {
            get { return _SottoTitolo; }
            set { _SottoTitolo = value; }
        }

        public string Percorso {
            get { return _Percorso; }
            set { _Percorso = value; }
        }

        public DateTime DataInserimento {
            get { return _DataInserimento; }
            set { _DataInserimento = value; }
        }

        public int ParentObjectID {
            get { return _ParentObjectID; }
            set { _ParentObjectID = value; }
        }

        public int NumOrder {
            get { return _NumOrder; }
            set { _NumOrder = value; }
        }

        public string Estensione {
            get { return _Estensione; }
            set { _Estensione = value; }
        }



		public OggettoFoto()
		{

		}

		public void FromDataReader(IDataReader oDr) {

            this._ID = (int.Parse(oDr["tImageID"].ToString()));
            this._Titolo = oDr["tImageTitolo"].ToString();
            this._SottoTitolo = oDr["tImageSottoTitolo"].ToString();
            this._Percorso = oDr["tImagePercorso"].ToString();
            this._ParentObjectID = int.Parse(oDr["tObjectID"].ToString());
            this._NumOrder = int.Parse(oDr["tImageNumOrder"].ToString());
            this._Estensione = oDr["tImageEstensione"].ToString();
            this._DataInserimento = DateTime.Parse(oDr["tImageDataInserimento"].ToString());
		}
	}
}
