using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for DeleteCategories.xaml
    /// </summary>
    public partial class DeleteCategories : Window
    {
        public SocialNetServiceClient WcfClient { get; private set; }

        public DeleteCategories(SocialNetServiceClient wcfClient)
        {
            this.InitializeComponent();
            this.WcfClient = wcfClient;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WcfClient.DeleteCategories(this.nomTextBox.Text))
                MessageBox.Show("Suppression effectuée avec succès :)");
            else
                MessageBox.Show("Suppression non effectuée :(");
            this.Close();
        }
    }
}