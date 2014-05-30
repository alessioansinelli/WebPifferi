using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class be_newsEdit : CheckLoginPage
{

    private int IdNews {
        get
        {
            int iret = 0;
            if (Request["IdNews"] != null) {
                int.TryParse(Request["IdNews"].ToString(), out iret);
            }

            return iret;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {

    }
}
