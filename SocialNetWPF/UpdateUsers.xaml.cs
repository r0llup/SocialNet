using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for UpdateUsers.xaml
    /// </summary>
    public partial class UpdateUsers : Window
    {
        public SocialNetServiceClient WcfClient { get; private set; }

        public UpdateUsers(SocialNetServiceClient wcfClient)
        {
            this.InitializeComponent();
            this.WcfClient = wcfClient;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WcfClient.UpdateUsers(this.ancienPseudoTextBox.Text,
                this.pseudoTextBox.Text, this.nomTextBox.Text, this.prenomTextBox.Text,
                this.passwordTextBox.Text, this.avatarTextBox.Text))
                MessageBox.Show("Modification effectuée avec succès :)");
            else
                MessageBox.Show("Modification non effectuée :(");
            this.Close();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            User u = this.WcfClient.GetUsers(this.ancienPseudoTextBox.Text);
            if (u != null)
            {
                this.pseudoTextBox.Text = u.Pseudo;
                this.nomTextBox.Text = u.Nom;
                this.prenomTextBox.Text = u.Prenom;
                this.passwordTextBox.Text = u.Password;
                this.avatarTextBox.Text = u.Avatar;
            }
            else
            {
                MessageBox.Show(this.ancienPseudoTextBox.Text +
                    "ne correspond à aucun utilisateurs :(");
            }
        }
    }
}