using System;
using Microsoft.Phone.Controls;
using SocialNetPhone.SocialNetServiceReference;

namespace SocialNetPhone
{
    public partial class Login : PhoneApplicationPage
    {
        public SocialNetServiceClient WcfProxy { get; private set; }
        public User GivenUser { get; private set; }

        public Login()
        {
            this.InitializeComponent();
            this.WcfProxy = new SocialNetServiceClient();
            this.GivenUser = null;
        }

        void WcfProxy_GetUsersCompleted(object sender, GetUsersCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    this.GivenUser = e.Result;
                    if (this.GivenUser.Password.Equals(this.passwordTextBox.Text))
                        this.NavigationService.Navigate(new Uri("/Events.xaml?username=" + this.usernameTextBox.Text, UriKind.Relative));
                }
            }
            catch (Exception)
            {
                /*FIXME*/
            }
        }

        private void okButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WcfProxy.GetUsersCompleted += new System.EventHandler<GetUsersCompletedEventArgs>(WcfProxy_GetUsersCompleted);
            this.WcfProxy.GetUsersAsync(this.usernameTextBox.Text);
        }
    }
}