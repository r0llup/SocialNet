using System;
using System.Web.UI;

namespace SocialNetWeb
{
    public partial class IndexPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String username = Session["login"] as String;
            if (username != null)
                this.initParams.Attributes.Add("value", "login=True");
        }
    }
}