using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocialNetWeb
{
    public partial class SocialNetWeb : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String username = Session["login"] as String;
            if (username != null)
            {
                (this.FindControl("loginLabel") as Label).Text = "Logout";
                this.welcomeLabel.Text = "Welcome Back, " + username + "!";
            }
        }
    }
}