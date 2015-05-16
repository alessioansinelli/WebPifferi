using System;
using Business;

/// <summary>
/// Summary description for CheckLoginPage
/// </summary>
public class CheckLoginPage : NoViewState.EliminaViewState.SessionPersisterBasePage
{

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (ConstWrapper.UtenteLoggato == null)
        {

            Response.Redirect(ResolveUrl("~/be/default.aspx?from=" + Request.Path));
        }
    }

}
