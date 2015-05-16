using System;

namespace be
{
    public partial class BeVideoEdit : CheckLoginPage
    {

        private int IdNews {
            get
            {
                var iret = 0;
                if (Request["IdNews"] != null) {
                    int.TryParse(Request["IdNews"], out iret);
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
