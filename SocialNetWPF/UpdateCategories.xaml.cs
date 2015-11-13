using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for UpdateCategories.xaml
    /// </summary>
    public partial class UpdateCategories : Window
    {
        public SocialNetServiceClient WcfClient { get; private set; }

        public UpdateCategories(SocialNetServiceClient WcfClient)
        {
            this.InitializeComponent();
            this.WcfClient = WcfClient;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WcfClient.UpdateCategories(this.ancienNomTextBox.Text,
                this.nomTextBox.Text, this.descriptionTextBox.Text))
                MessageBox.Show("Modification effectuée avec succès :)");
            else
                MessageBox.Show("Modification non effectuée :(");
            this.Close();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            Category c = this.WcfClient.GetCategories(this.ancienNomTextBox.Text);
            if (c != null)
            {
                this.nomTextBox.Text = c.Nom;
                this.descriptionTextBox.Text = c.Description;
            }
            else
            {
                MessageBox.Show(this.ancienNomTextBox.Text +
                    "ne correspond à aucune catégories :(");
            }
        }
    }
}