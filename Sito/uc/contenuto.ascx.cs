using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_contenuto : System.Web.UI.UserControl
{

	#region "Property"

	private string _Entity = "";
	
	public string Entity
	{
		get { return _Entity; }
		set { _Entity = value; }
	}

	#endregion "Property"

	protected void Page_Load(object sender, EventArgs e)
	{
		// carico l'XML con il contenuto da visualizzare nella pagina.

		XmlDocument oXml = new XmlDocument();

		oXml.Load(Server.MapPath("/pagine/pagine.xml"));

		if (oXml != null)
		{
			XmlNode oXmlNode = oXml.SelectSingleNode("//pagina[@id = '" + _Entity.ToString() + "']");

			if (oXmlNode != null)
			{
				loc.Text = oXmlNode.InnerXml.ToString();
			}
			else 
			{
				NonTrovato();
			}

		}else{
			NonTrovato();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	private void NonTrovato() {
		loc.Text = "Contenuto " + _Entity + " non trovato";
	}
}
