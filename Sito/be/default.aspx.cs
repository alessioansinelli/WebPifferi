using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class be_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			if ((txtNomeUtente.Text != string.Empty) && (txtPassword.Text != string.Empty)) {
				Oggetti.OggettoLogin oLogin = new Oggetti.OggettoLogin();
				oLogin.NomeUtente = txtNomeUtente.Text.Trim();
				oLogin.PwdUtente = txtPassword.Text.Trim();

				Login oggettoLogin = new Login();

				oLogin = oggettoLogin.AutenticaUtente(oLogin);
				
				if (oLogin != null)
				{
					try { Response.Redirect("admin.aspx"); }
					catch (System.Threading.ThreadAbortException ex) {
                        
                    }
				}

			}
		}
}
