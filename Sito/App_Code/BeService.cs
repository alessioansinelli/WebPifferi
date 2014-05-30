using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

/// <summary>
/// Summary description for BeService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BeService : System.Web.Services.WebService {

    public BeService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }


    [WebMethod(EnableSession=true)]
    public List<Oggetti.Oggetto> PhotoGalleryList(string NomeUtente, string Password)
    {

        List<Oggetti.Oggetto> retVal = null;
        
        if (AutOK(NomeUtente, Password)){
            Notizie oNotizie = new Notizie(TipoOggetto.Photogallery);
            retVal = oNotizie.GetAll(0);            
        }
                
        return retVal;
    }


		[WebMethod]
		public bool SaveImage(string FileName, byte[] oImage, int GalleryID, string NomeUtente, string Password)
		{

			if (AutOK(NomeUtente, Password))
			{

				if (oImage != null)
				{

					Immagini oImmagini = new Immagini();
					int newId = 0;
					try { newId = oImmagini.GetNewID(); }
					catch { newId = 1; }

					Oggetti.OggettoFoto oFoto = new Oggetti.OggettoFoto();
					oFoto.Titolo = FileName.Substring(0, FileName.LastIndexOf(".") + 1).Trim();
					oFoto.SottoTitolo = "";
					oFoto.DataInserimento = DateTime.Now;
					oFoto.ID = newId;
					oFoto.ParentObjectID = GalleryID;
					oFoto.NumOrder = 1;
					string outPercorso = "";
					string outEstensione = "";


					oImmagini.SalvaImmaginePost(oImage, FileName, oFoto, newId, out outPercorso, out outEstensione);

					oFoto.Estensione = outEstensione;
					oFoto.Percorso = outPercorso;

					oImmagini.Add(oFoto);

				}

				return true;
			}
			else
			{
				return false;
			}
		}

    private bool AutOK(string NomeUtente, string Password) {

        bool bRet = false;

        Oggetti.OggettoLogin oLogin = new Oggetti.OggettoLogin();
        oLogin.NomeUtente = NomeUtente;
        oLogin.PwdUtente = Password;

        Login loginUtil = new Login();

        if ((loginUtil.AutenticaUtente(oLogin).IdUtente) > 0) {
            bRet = true;
        }

        return bRet;

    }
    
}
