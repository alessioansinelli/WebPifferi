using System;
using System.Web.UI;

namespace uc
{
    public partial class UcMenu : UserControl
    {
        private string _selectedmenu;
        public string SelectedMenu {
            get { return _selectedmenu == "" ? "none" : _selectedmenu; }
            set { _selectedmenu = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
