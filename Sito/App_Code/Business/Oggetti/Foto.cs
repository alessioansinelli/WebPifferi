using System;
using System.Data;


namespace Business.Oggetti
{
	/// <summary>
	/// Summary description for Foto
	/// </summary>
	public class OggettoFoto
	{
	    public OggettoFoto()
	    {
	        Estensione = "";
	        NumOrder = 0;
	        ParentObjectId = 0;
	        DataInserimento = DateTime.Now;
	        Percorso = "";
	        SottoTitolo = "";
	        Titolo = "";
	        Id = 0;
	    }

	    public int Id { get; set; }

	    public string Titolo { get; set; }

	    public string SottoTitolo { get; set; }

	    public string Percorso { get; set; }

	    public DateTime DataInserimento { get; set; }

	    public int ParentObjectId { get; set; }

	    public int NumOrder { get; set; }

	    public string Estensione { get; set; }


	    public void FromDataReader(IDataReader oDr) {

            Id = (int.Parse(oDr["tImageID"].ToString()));
            Titolo = oDr["tImageTitolo"].ToString();
            SottoTitolo = oDr["tImageSottoTitolo"].ToString();
            Percorso = oDr["tImagePercorso"].ToString();
            ParentObjectId = int.Parse(oDr["tObjectID"].ToString());
            NumOrder = int.Parse(oDr["tImageNumOrder"].ToString());
            Estensione = oDr["tImageEstensione"].ToString();
            DataInserimento = DateTime.Parse(oDr["tImageDataInserimento"].ToString());
		}
	}
}
