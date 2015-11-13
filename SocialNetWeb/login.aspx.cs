using System;
using System.ServiceModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialNetServiceReference;

namespace SocialNetWeb
{
    public partial class LoginPage : Page
    {
        public SocialNetServiceClient WcfProxy { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // already connected
            if (Session["login"] != null)
            {
                Session.Remove("login");
                Response.Redirect("~/index.aspx");
            }
            else
                this.WcfProxy = new SocialNetServiceClient();
        }

        protected void LoginControl_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                User u = this.WcfProxy.GetUsers(this.loginControl.UserName);
                if (u.Password.Equals(this.loginControl.Password))
                    e.Authenticated = true;
                else
                    e.Authenticated = false;
            }
            catch (FaultException) /*FIXME*/
            {
                e.Authenticated = false;
            }
        }

        protected void LoginControl_LoggedIn(object sender, EventArgs e)
        {
            Session.Add("login", this.loginControl.UserName);
            if (Session["currentPage"] != null)
                Response.Redirect(Session["currentPage"] as String);
            else
                Response.Redirect("~/index.aspx");
        }
    }
}