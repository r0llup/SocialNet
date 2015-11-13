using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using SocialNetPhone.SocialNetServiceReference;

namespace SocialNetPhone
{
    public partial class EventsPage : PhoneApplicationPage
    {
        public SocialNetServiceClient WcfProxy { get; private set; }
        public String Username { get; private set; }

        public EventsPage()
        {
            this.InitializeComponent();
            this.WcfProxy = new SocialNetServiceClient();
            this.Username = null;
            this.WcfProxy.ListEventsNameCompleted += new EventHandler<ListEventsNameCompletedEventArgs>(this.WcfProxy_ListEventsNameCompleted);
            this.WcfProxy.ListEventsNameAsync();
        }

        void WcfProxy_ListEventsNameCompleted(object sender, ListEventsNameCompletedEventArgs e)
        {
            if (e.Result != null)
                this.eventsListBox.ItemsSource = e.Result;
        }

        void  WcfProxy_AddCommentsCompleted(object sender, AddCommentsCompletedEventArgs e)
        {
 	        // we're done here!
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            String username = "";
            if (NavigationContext.QueryString.TryGetValue("username", out username))
                this.Username = username;
        }

        private void okButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.eventsListBox.SelectedItem != null)
            {
                this.WcfProxy.AddCommentsCompleted += new EventHandler<AddCommentsCompletedEventArgs>(this.WcfProxy_AddCommentsCompleted);
                if (this.Username != null)
                {
                    this.WcfProxy.AddCommentsAsync(this.eventsListBox.SelectedItem as String, this.Username, "", this.commentTextBox.Text);
                    MessageBox.Show("Comment sent successfully!");
                }
            }
        }
    }
}