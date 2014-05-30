using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class be_uc_menu_news : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void ClearApplicationCache()
    {
        List<string> keys = new List<string>();

        // retrieve application Cache enumerator
        IDictionaryEnumerator enumerator = Cache.GetEnumerator();

        // copy all keys that currently exist in Cache
        while (enumerator.MoveNext())
        {
            keys.Add(enumerator.Key.ToString());
        }

        // delete every key from cache
        for (int i = 0; i < keys.Count; i++)
        {
            Cache.Remove(keys[i]);
        }
    }
    protected void lnkPulisciCache_Click(object sender, EventArgs e)
    {
        ClearApplicationCache();
    }
}
