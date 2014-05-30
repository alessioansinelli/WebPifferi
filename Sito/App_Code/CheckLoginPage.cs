using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Business;

/// <summary>
/// Summary description for CheckLoginPage
/// </summary>
public class CheckLoginPage : NoViewState.EliminaViewState.SessionPersisterBasePage
{
	public CheckLoginPage()
	{
        //if (ConstWrapper.UtenteLoggato == null)
        //{
        //    Response.Redirect("../SessioneScaduta.aspx");
        //}
	}


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (ConstWrapper.UtenteLoggato == null)
        {
           Response.Redirect(ResolveUrl("~/be/default.aspx"));
        }
    }

}
