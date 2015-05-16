using System;
using System.Collections.Generic;
using System.Web.Services;
using Business.Oggetti;
using Business;
using Gestione;

/// <summary>
/// Summary description for BeService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BeService : WebService {

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }


    [WebMethod(EnableSession=true)]
    public List<Oggetto> PhotoGalleryList(string nomeUtente, string password)
    {

        List<Oggetto> retVal = null;
        
        if (AutOK(nomeUtente, password)){
            Notizie oNotizie = new Notizie(TipoOggetto.Photogallery);
            retVal = oNotizie.GetAll(0);            
        }
                
        return retVal;
    }


		[WebMethod]
		public bool SaveImage(string fileName, byte[] oImage, int galleryId, string nomeUtente, string password)
		{
		    if (AutOK(nomeUtente, password))
			{
			    if (oImage == null) return true;
			    var oImmagini = new Immagini();
			    int newId;
			    try { newId = oImmagini.GetNewId(); }
			    catch { newId = 1; }

			    var oFoto = new OggettoFoto
			    {
			        Titolo = fileName.Substring(0, fileName.LastIndexOf(".", StringComparison.InvariantCulture) + 1).Trim(),
			        SottoTitolo = "",
			        DataInserimento = DateTime.Now,
			        Id = newId,
			        ParentObjectId = galleryId,
			        NumOrder = 1
			    };
			    string outPercorso;
			    string outEstensione;


			    oImmagini.SalvaImmaginePost(oImage, fileName, oFoto, newId, out outPercorso, out outEstensione);

			    oFoto.Estensione = outEstensione;
			    oFoto.Percorso = outPercorso;

			    oImmagini.Add(oFoto);
			    return true;
			}
		    return false;
		}

    private bool AutOK(string nomeUtente, string password) {

        var bRet = false;

        var oLogin = new OggettoLogin
        {
            NomeUtente = nomeUtente,
            PwdUtente = password
        };

        var loginUtil = new LoginHelper();

        if ((loginUtil.AutenticaUtente(oLogin).IdUtente) > 0) {
            bRet = true;
        }

        return bRet;

    }
    
}
