using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for DeleteUsers.xaml
    /// </summary>
    public partial class DeleteUsers : Window
    {
        public SocialNetServiceClient WcfClient { get; private set; }

        public DeleteUsers(SocialNetServiceClient wcfClient)
        {
            this.InitializeComponent();
            this.WcfClient = wcfClient;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.WcfClient.DeleteUsers(this.pseudoTextBox.Text))
                MessageBox.Show("Suppression effectuée avec succès :)");
            else
                MessageBox.Show("Suppression non effectuée :(");
            this.Close();
        }
    }
}