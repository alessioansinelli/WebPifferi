using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    public Utility()
    {}

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
}
