using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        public SocialNetServiceClient WcfProxy { get; private set; }

        public AddUsers(SocialNetServiceClient wcfProxy)
        {
            this.InitializeComponent();
            this.WcfProxy = wcfProxy;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WcfProxy.AddUsers(this.pseudoTextBox.Text, this.nomTextBox.Text,
                this.prenomTextBox.Text, this.passwordTextBox.Text, this.avatarTextBox.Text))
                MessageBox.Show("Ajout effectué avec succès :)");
            else
                MessageBox.Show("Ajout non effectué :/");
            this.Close();
        }
    }
}