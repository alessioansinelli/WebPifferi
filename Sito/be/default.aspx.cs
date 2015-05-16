using System;
using Business.Oggetti;
using Business;

namespace be { 

public partial class BeDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if ((txtNomeUtente.Text != string.Empty) && (txtPassword.Text != string.Empty))
        {
            var oLogin = new OggettoLogin
            {
                NomeUtente = txtNomeUtente.Text.Trim(),
                PwdUtente = txtPassword.Text.Trim()
            };

            var oggettoLogin = new LoginHelper();

            oLogin = oggettoLogin.AutenticaUtente(oLogin);

            if (oLogin == null) return;
            try
            {
                Response.Redirect(!string.IsNullOrEmpty(Request["from"]) ? Request["from"] : "Admin.aspx");
            }
            catch (System.Threading.ThreadAbortException ex)
            {

            }
        }
    }
}

}
