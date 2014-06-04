using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


/// <summary>
/// Summary description for Utility
/// </summary>
public static class Utility
{    
    public static string getUrlPhoto(Oggetti.OggettoFoto[] oFoto, string Dimensione)
    {
        string sret = "";
        if (oFoto.Length > 0)
        {
            sret = "<img src=\"" + VirtualPathUtility.ToAbsolute(Business.ConstWrapper.CartellaFoto + oFoto[0].Percorso + Dimensione + oFoto[0].Estensione + "\" alt=\"" + oFoto[0].Titolo + "\" />");

        }

        return sret;
    }

    public static string getUrlPhoto(Oggetti.OggettoFoto oFoto, string Dimensione)
    {
        string sret = "";
        sret = "<img src=\"" + VirtualPathUtility.ToAbsolute(Business.ConstWrapper.CartellaFoto + oFoto.Percorso + Dimensione + oFoto.Estensione + "\" alt=\"" + oFoto.Titolo + "\" />");

        return sret;
    }
    
    public static string getPathPhoto(Oggetti.OggettoFoto oFoto, string Dimensione)
    {
        string sret = "";
        sret = VirtualPathUtility.ToAbsolute(Business.ConstWrapper.CartellaFoto + oFoto.Percorso + Dimensione + oFoto.Estensione );
        return sret;
    }

    public static string getClassname(int itemIndex, int mod, string classname)
    {
        if (itemIndex % mod == 0)
        {
            return classname;
        }
        else
        {
            return "";
        }
    }

    public static string GetBaseUrlByObjectType(TipoOggetto tipoOggetto){
        string sRet = "";

        switch (tipoOggetto)
        {
            case TipoOggetto.News:
                sRet = "news";
                break;
            case TipoOggetto.Video:
                sRet = "video";
                break;
            case TipoOggetto.Photogallery:
                sRet = "gallery";
                break;

        }

        return sRet;
    }

    public static string GenerateSlug(this string phrase)
    {
        string str = phrase.RemoveAccent().ToLower();
        // invalid chars           
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        // convert multiple spaces into one space   
        str = Regex.Replace(str, @"\s+", " ").Trim();
        // cut and trim 
        str = str.Substring(0, str.Length <= 70 ? str.Length : 70).Trim();
        str = Regex.Replace(str, @"\s", "-"); // hyphens   
        return str;
    }

    public static string RemoveAccent(this string txt)
    {
        byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
        return System.Text.Encoding.ASCII.GetString(bytes);
    }

}
