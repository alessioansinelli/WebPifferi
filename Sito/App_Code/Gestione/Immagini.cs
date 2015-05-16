using System;
using System.Collections.Generic;
using System.Web;
using Business;
using Data;
using System.Data;
using System.IO;
using ImageResizer;
using Business.Oggetti;

namespace Gestione
{
    /// <summary>
    /// Summary description for Immagini
    /// </summary>
    public class Immagini
    {

        private readonly DataLayer _dal = new DataLayer();
        private IDbCommand _dbC;


        public int GetNewId()
        {

            // recupero l'ID dell'immagine, per salvare il file.

            _dbC = _dal.CreateCommand();


            _dbC.CommandText = (SqlGetLastId);
            var idImmagine = int.Parse(_dal.ExecuteScalar(_dbC).ToString()) + 1;

            return idImmagine;
        }

        /* Delete photo reference */
        public bool Delete(int idfoto, int parentObjectId)
        {
            var oFoto = Get(idfoto, parentObjectId);

            /* delete from tImage */
            _dbC = _dal.CreateCommand();
            _dbC.CommandText = (SqlDeleteSingleObject);
            _dbC.Parameters.Add(_dal.CreatePar("@tImageID", idfoto));

            var bret = (_dal.Execute(_dbC) > 0);

            /* Delete from tRelatedItem */
            _dbC = _dal.CreateCommand();
            _dbC.CommandText = (SqlDeleteFromRelated);
            _dbC.Parameters.Add(_dal.CreatePar("@tImageID", idfoto));
            _dbC.Parameters.Add(_dal.CreatePar("@tObjectParentId", parentObjectId));

            bret = _dal.Execute(_dbC) > 0;

            // UPDATE NEW ORDER
            _dbC = _dal.CreateCommand();
            _dbC.CommandText = "update tRelatedItem set tRelatedItemOrder=tRelatedItemOrder-1 where tRelatedItemOrder > @NumOrder AND tObjectId=@tImageParentID and tObjectRelatedType = 1";
            //dbC.CommandText = ("UPDATE tImage SET tImageNumOrder = tImageNumOrder-1 " +
            //        " WHERE tImageNumOrder > @NumOrder AND tObjectID=@tImageParentID;");
            _dbC.Parameters.Add(_dal.CreatePar("@NumOrder", oFoto.NumOrder));
            _dbC.Parameters.Add(_dal.CreatePar("@tImageParentID", parentObjectId));

            // check if present related item for other object don't delete it from filesystem	
            // DELETE IMAGE FROM FILE SYSTEM
            DeleteFromFileSystem(oFoto);

            _dal.Execute(_dbC);

            return bret;
        }

        private void DeleteFromFileSystem(OggettoFoto oFoto)
        {
            string pathFolder = HttpContext.Current.Server.MapPath(ConstWrapper.CartellaFoto + oFoto.Percorso);
            if (Directory.Exists(pathFolder))
            {
                if (Directory.GetDirectories(pathFolder).Length > 0)
                {
                    foreach (string sFile in Directory.GetFiles(pathFolder))
                    {
                        File.Delete(sFile);
                    }
                }
                else
                {
                    Directory.Delete(pathFolder, true);
                }
            }
        }

        public bool Add(OggettoFoto oFoto)
        {

            _dbC = _dal.CreateCommand();
            _dbC.CommandText = (SqlInsertImage);
            _dbC.CommandType = CommandType.StoredProcedure;

            //tImageID, tImageTitolo, tImageSottoTitolo, tImagePercorso, tImageEstensione, tImageDataInserimento, tObjectID, tImageNumOrder
            _dbC.Parameters.Add(_dal.CreatePar("@tImageID", oFoto.Id));
            _dbC.Parameters.Add(_dal.CreatePar("@tImageTitolo", oFoto.Titolo));
            _dbC.Parameters.Add(_dal.CreatePar("@tImageSottoTitolo", oFoto.SottoTitolo));
            _dbC.Parameters.Add(_dal.CreatePar("@tImagePercorso", oFoto.Percorso));
            _dbC.Parameters.Add(_dal.CreatePar("@tImageEstensione", oFoto.Estensione));
            _dbC.Parameters.Add(_dal.CreatePar("@tImageDataInserimento", oFoto.DataInserimento));
            _dbC.Parameters.Add(_dal.CreatePar("@tObjectID", oFoto.ParentObjectId));
            _dbC.Parameters.Add(_dal.CreatePar("@tImageNumOrder", oFoto.NumOrder));

            _dal.Execute(_dbC);

            _dbC = _dal.CreateCommand();
            _dbC.CommandText = "update tRelatedItem set tRelatedItemOrder=tRelatedItemOrder+1 where tObjectRelatedId <> " + oFoto.Id + " AND tObjectId=" + oFoto.ParentObjectId + " and tObjectRelatedType = 2";

            // dbC.CommandText = ("update tImage SET tImageNumOrder = tImageNumOrder + 1 " +
            // " WHERE tImageID <> " + oFoto.ID.ToString() + " and tObjectID=" + (int)oFoto.ParentObjectID);

            _dal.Execute(_dbC);


            return true;
        }

        public int SalvaImmaginePost(byte[] oImgSpedita, string fileName, OggettoFoto oFoto, int id, out string percorso, out string estensione)
        {


            //Loop through each uploaded file
            //foreach (string fileKey in HttpContext.Current.Request.Files.Keys)
            //{
            //    HttpPostedFile file = HttpContext.Current.Request.Files[fileKey];
            //    if (file.ContentLength <= 0) continue; //Skip unused file controls.

            //    //Get the physical path for the uploads folder and make sure it exists
            //    string uploadFolder = MapPath("~/uploads");
            //    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

            //    //Generate each version
            //    foreach (string suffix in versions.Keys)
            //    {
            //        //Generate a filename (GUIDs are best).                
            //    }

            //}

            try
            {
                int iRetVal = 0;
                estensione = fileName.Substring(fileName.LastIndexOf(".", StringComparison.InvariantCulture), fileName.Length - fileName.LastIndexOf(".", StringComparison.InvariantCulture));

                // path foto
                string pathdef = "";
                string pathfoto = id.ToString();
                if (pathfoto.Length % 2 != 0)
                {
                    pathfoto = "0" + pathfoto;
                }

                for (int i = 0; i < pathfoto.Length / 2; i++)
                {
                    pathdef = pathdef + pathfoto.Substring(i * 2, 2) + "/";
                }

                percorso = pathdef;

                if (oImgSpedita != null)
                {
                    // procedo con il ridimensionamento del file e il salvataggio sul db e sul server.                

                    // controllo la dimensione dell'immagine
                    if (oImgSpedita.Length > 0)
                    {
                        // controllo il contentype
                        // SALVO L'IMMAGINE SUL'DISCO E SUL DATABASE

                        // creo l'immagine
                        System.Drawing.Image oImage = System.Drawing.Image.FromStream(new MemoryStream(oImgSpedita));
                        double imgWidth = oImage.Width;
                        double imgHeight = oImage.Height;

                        // proporzione tra larghezza e altezza
                        double proporzioneImg = imgWidth / imgHeight;

                        // da sostituire con chiave nel web.config
                        string percorsoFile = HttpContext.Current.Server.MapPath(ConstWrapper.CartellaFoto) + pathdef;
                        //NomeFile = IdFile + "_w1" + EstensioneFile;

                        for (var iRow = 1; iRow < 13; iRow++)
                        {
                            double width = 0;
                            double height;

                            if (proporzioneImg > 1)
                            {
                                /* Larghezza maggiore altezza */
                                width = (iRow * 100) - 30;
                                height = Math.Ceiling(width / proporzioneImg);
                            }
                            else
                            {
                                height = (iRow * 100) - 30;
                                width = Math.Ceiling(width / proporzioneImg);
                            }

                            if (!Directory.Exists(percorsoFile))
                            {
                                Directory.CreateDirectory(percorsoFile);
                            }

                            //Let the image builder add the correct extension based on the output file type
                            ImageBuilder.Current.Build(oImage, percorsoFile + "\\" + "w" + iRow, new ResizeSettings(string.Format("width={0}&height={1}&format={2}", width, height, estensione)), false, true);
                        }


                        iRetVal = 1;

                    }
                }

                return iRetVal;
            }
            catch (Exception ex)
            {
                // errore! devo dare il messaggio
                throw new Exception("Errore durante il salvataggio dell\'immagine sul server::" + ex.Message);
            }
        }

        public List<OggettoFoto> GetAll(int parentObjectId, int count)
        {
            List<OggettoFoto> retList = new List<OggettoFoto>();

            _dbC = _dal.CreateCommand();

            if (count > 0)
            {
                _dbC.CommandText = (SqlGetCountByParentId.Replace("{count}", count.ToString()));
            }
            else
            {
                _dbC.CommandText = (SqlGetAllByParentId);
            }

            _dbC.Parameters.Add(_dal.CreatePar("@tObjectID", parentObjectId));
            using (IDataReader oDr = _dal.GetDataReader(_dbC))
            {

                if (oDr != null)
                {
                    while (oDr.Read())
                    {
                        OggettoFoto oFoto = new OggettoFoto();
                        oFoto.FromDataReader(oDr);

                        retList.Add(oFoto);

                    }
                    oDr.Close();
                }
            }

            return retList;
        }

        public List<OggettoFoto> GetAll(string parentSlug, int count)
        {
            List<OggettoFoto> retList = new List<OggettoFoto>();

            _dbC = _dal.CreateCommand();

            if (count > 0)
            {
                _dbC.CommandText = (SqlGetCountByParentSlug.Replace("{count}", count.ToString()));
            }
            else
            {
                _dbC.CommandText = (SqlGetAllByParentSlug);
            }

            _dbC.Parameters.Add(_dal.CreatePar("@slug", parentSlug));
            using (IDataReader oDr = _dal.GetDataReader(_dbC))
            {

                if (oDr != null)
                {
                    while (oDr.Read())
                    {
                        OggettoFoto oFoto = new OggettoFoto();
                        oFoto.FromDataReader(oDr);

                        retList.Add(oFoto);

                    }
                    oDr.Close();
                }
            }

            return retList;
        }

        public bool UpdateNumOrder(int id, string direction, int parentId)
        {
            var oFoto = Get(id, parentId);

            var currentNumOrder = oFoto.NumOrder;
            var maxNewOrder = GetLastNumOrder(oFoto.ParentObjectId);

            _dbC = _dal.CreateCommand();

            _dbC.CommandText = ("UPDATE tRelatedItem set tRelatedItemOrder=@NewNumOrder where tObjectRelatedId=@Id and tObjectId=" + oFoto.ParentObjectId);

            if ((direction == "UP") && (currentNumOrder != 1))
            {

                _dbC.Parameters.Add(_dal.CreatePar("@NewNumOrder", currentNumOrder - 1));
                _dbC.Parameters.Add(_dal.CreatePar("@Id", oFoto.Id));

                _dal.Execute(_dbC);

                _dbC = _dal.CreateCommand();
                _dbC.CommandText = "UPDATE tRelatedItem set tRelatedItemOrder=" + currentNumOrder + " where tObjectRelatedId <> " + oFoto.Id + " and tRelatedItemOrder=" + (currentNumOrder - 1) + " and tObjectID=" + Convert.ToInt32(oFoto.ParentObjectId);


                _dal.Execute(_dbC);
            }
            else if ((direction == "DOWN") && (currentNumOrder != maxNewOrder - 1))
            {

                _dbC.Parameters.Add(_dal.CreatePar("@NewNumOrder", currentNumOrder + 1));
                _dbC.Parameters.Add(_dal.CreatePar("@Id", oFoto.Id));

                _dal.Execute(_dbC);

                _dbC = _dal.CreateCommand();
                _dbC.CommandText = ("UPDATE tRelatedItem set tRelatedItemOrder=" + currentNumOrder + " where tObjectRelatedId <> " + oFoto.Id + " and tRelatedItemOrder=" + (currentNumOrder + 1) + " and tObjectID=" + Convert.ToInt32(oFoto.ParentObjectId));

                _dal.Execute(_dbC);

            }

            return false;
        }

        private OggettoFoto Get(int id, int parentId)
        {
            OggettoFoto oFoto = new OggettoFoto();

            _dbC = _dal.CreateCommand();

            _dbC.CommandText = (SqlGetFromId);
            _dbC.Parameters.Add(_dal.CreatePar("@tImageID", id));
            _dbC.Parameters.Add(_dal.CreatePar("@tObjectID", parentId));

            using (IDataReader oDr = _dal.GetDataReader(_dbC))
            {

                if (oDr != null)
                {
                    while (oDr.Read())
                    {
                        oFoto.FromDataReader(oDr);
                    }
                    oDr.Close();
                }
            }

            return oFoto;
        }

        private int GetLastNumOrder(int tParentObjectId)
        {
            int iRet;

            _dbC = _dal.CreateCommand();
            _dbC.CommandText = (SqlGetLastNumOrder);

            _dbC.Parameters.Add(_dal.CreatePar("@tObjectID", tParentObjectId));

            try
            {
                iRet = (int.Parse(_dal.ExecuteScalar(_dbC).ToString())) + 1;
            }
            catch
            {
                iRet = 1;
            }

            return iRet;
        }

        public const string SqlGetLastId = "SELECT Max(tImageID) AS MaxDitImageID FROM tImage";

        public const string SqlInsertImage = "insertImage";
        /*
         *	
                "INSERT INTO tImage (tImageID, tImageTitolo, tImageSottoTitolo, tImagePercorso, tImageEstensione, tImageDataInserimento, tObjectID, tImageNumOrder)" +
                " VALUES " +
                " ( @tImageID, @tImageTitolo, @tImageSottoTitolo, @tImagePercorso, @tImageEstensione, @tImageDataInserimento, @tObjectID, @tImageNumOrder ) ";
         * 
         */

        private const string SqlGetAllByParentId = "SELECT [tImageID] " +
      ",[tImageTitolo] " +
      ",[tImageSottoTitolo] " +
      ",[tImagePercorso] " +
      ",[tImageEstensione] " +
      ",[tImageDataInserimento] " +
      ",r.tObjectId " +
      ",r.tRelatedItemOrder as tImageNumOrder " +
            "FROM [tImage] i  " +
            "INNER JOIN tRelatedItem r " +
            "ON r.tObjectRelatedId = i.tImageID where r.tObjectId = @tObjectID order by r.tRelatedItemOrder";

        private const string SqlGetAllByParentSlug = "SELECT [tImageID] " +
          ",[tImageTitolo] " +
          ",[tImageSottoTitolo] " +
          ",[tImagePercorso] " +
          ",[tImageEstensione] " +
          ",[tImageDataInserimento] " +
          ",r.tObjectId " +
          ",r.tRelatedItemOrder as tImageNumOrder " +
                "FROM [tImage] i  " +
                "INNER JOIN tRelatedItem r " +
                "ON r.tObjectRelatedId = i.tImageID where r.slug = @slug order by r.tRelatedItemOrder";

        private const string SqlGetCountByParentId = "SELECT TOP {count} [tImageID]" +
            ",[tImageTitolo] " +
            ",[tImageSottoTitolo] " +
            ",[tImagePercorso] " +
            ",[tImageEstensione] " +
            ",[tImageDataInserimento] " +
            ",r.tObjectId " +
            ",r.tRelatedItemOrder as tImageNumOrder " +
            "FROM [tImage] i  " +
            "INNER JOIN tRelatedItem r " +
            "ON r.tObjectRelatedId = i.tImageID where r.tObjectId = @tObjectID order by r.tRelatedItemOrder";

        private const string SqlGetCountByParentSlug = "SELECT TOP {count} [tImageID]" +
        ",[tImageTitolo] " +
        ",[tImageSottoTitolo] " +
        ",[tImagePercorso] " +
        ",[tImageEstensione] " +
        ",[tImageDataInserimento] " +
        ",r.tObjectId " +
        ",r.tRelatedItemOrder as tImageNumOrder " +
        "FROM [tImage] i  " +
        "INNER JOIN tRelatedItem r " +
        "ON r.tObjectRelatedId = i.tImageID where i.slug = @slug order by r.tRelatedItemOrder";

        private const string SqlGetFromId = "SELECT [tImageID] " +
          ",[tImageTitolo] " +
          ",[tImageSottoTitolo] " +
          ",[tImagePercorso] " +
          ",[tImageEstensione] " +
          ",[tImageDataInserimento] " +
          ",r.tObjectId " +
          ",r.tRelatedItemOrder as tImageNumOrder " +
                "FROM [tImage] i  " +
                "INNER JOIN tRelatedItem r " +
                "ON r.tObjectRelatedId = i.tImageID " +
                "WHERE i.tImageID = @tImageID " +
                "AND i.tObjectID = @tObjectID";

        private const string SqlGetLastNumOrder = "select top 1 tRelatedItemOrder from tRelatedItem r where r.tObjectId = @tObjectID and tObjectRelatedType = 2 order by r.tRelatedItemOrder desc";

        private const string SqlDeleteSingleObject = "DELETE FROM tImage where tImageID=@tImageID";

        private const string SqlDeleteFromRelated = "delete from tRelatedItem where tObjectRelatedId=@tImageID and tObjectId=@tObjectParentId";

    }
}