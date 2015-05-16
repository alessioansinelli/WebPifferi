using System;

namespace be
{
    public partial class BePhotogalleryedit : CheckLoginPage
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
}
