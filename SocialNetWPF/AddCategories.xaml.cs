using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for AddCategories.xaml
    /// </summary>
    public partial class AddCategories : Window
    {
        public SocialNetServiceClient WcfProxy { get; private set; }

        public AddCategories(SocialNetServiceClient wcfProxy)
        {
            this.InitializeComponent();
            this.WcfProxy = wcfProxy;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WcfProxy.AddCategories(this.nomTextBox.Text, this.descriptionTextBox.Text))
                MessageBox.Show("Ajout effectué avec succès :)");
            else
                MessageBox.Show("Ajout non effectué :(");
            this.Close();
        }
    }
}