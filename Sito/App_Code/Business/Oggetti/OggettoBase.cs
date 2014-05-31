using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for OggettoBase
/// </summary>
public class OggettoBase
{
    private int _ID = 0;
    private string _Titolo = "";
    private string _SottoTitolo = "";
    private string _Testo = "";
    private DateTime _DataInserimento;
    private DateTime _DataModifica;
    private int _IdUtente;
    private TipoOggetto _TipoOggetto;
    private bool _isHomeNews = false;
    /* Specifiche per documenti e photo */
    private string _PathOggetto = "";
    private string _NomeFileOggetto = "";
    private int _NumOrder;
    private OleDbConnection Connessione;
    /// <summary>
    /// ID presente sul Database
    /// </summary>
    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    /// <summary>
    /// Titolo
    /// </summary>
    public string Titolo
    {
        get { return _Titolo; }
        set { _Titolo = value; }
    }

    /// <summary>
    /// SottoTitolo
    /// </summary>
    public string SottoTitolo
    {
        get { return _SottoTitolo; }
        set { _SottoTitolo = value; }
    }

    /// <summary>
    /// Testo
    /// </summary>
    public string Testo
    {
        get { return _Testo; }
        set { _Testo = value; }
    }

    /// <summary>
    /// Data inserimento
    /// </summary>
    public DateTime DataInserimento
    {
        get { return _DataInserimento; }
        set { _DataInserimento = value; }
    }

    /// <summary>
    /// Data Modifica
    /// </summary>
    public DateTime DataModifica
    {
        get { return _DataModifica; }
        set { _DataModifica = value; }
    }

    /// <summary>
    /// IdUtente
    /// </summary>
    public int IdUtente
    {
        get { return _IdUtente; }
        set { _IdUtente = value; }
    }

    public TipoOggetto TipoOggetto
    {
        get { return _TipoOggetto; }
        set { _TipoOggetto = value; }
    }

    public string PathFileOggetto
    {
        get { return _PathOggetto; }
        set { _PathOggetto = value; }
    }

    public string NomeFileOggetto
    {
        get { return _NomeFileOggetto; }
        set { _NomeFileOggetto = value; }
    }

    public int NumOrder
    {
        get { return _NumOrder; }
        set { _NumOrder = value; }
    }

    public virtual void FromDataReader(IDataReader oDr)
    {
        this.ID = int.Parse(oDr["tObjectID"].ToString());
        this.Titolo = oDr["tObjectTitolo"].ToString();
        this.Testo = oDr["tObjectTesto"].ToString();
        this.SottoTitolo = oDr["tObjectSottoTitolo"].ToString();
        this.DataInserimento = DateTime.Parse(oDr["tObjectDataInserimento"].ToString());
        this.DataModifica = DateTime.Parse(oDr["tObjectDataModifica"].ToString());
        this.IdUtente = int.Parse(oDr["tObjectIDUtente"].ToString());
        this.TipoOggetto = (TipoOggetto)int.Parse(oDr["tObjectTypeID"].ToString());
        this.NumOrder = int.Parse(oDr["tObjectNumOrder"].ToString());
        bool.TryParse(oDr["isHomeNews"].ToString(), out _isHomeNews);
    }

    public bool isHomeNews
    {
        get { return _isHomeNews; }
        set { _isHomeNews = value; }
    }

}

public enum TipoOggetto
{
    Homepage = 0,
    News = 1,
    Photogallery = 2,
    Eventi = 3,
    Video = 4
}
