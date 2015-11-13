using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for UpdateEvents.xaml
    /// </summary>
    public partial class UpdateEvents : Window
    {
        public SocialNetServiceClient WcfClient { get; private set; }

        public UpdateEvents(SocialNetServiceClient wcfClient)
        {
            this.InitializeComponent();
            this.WcfClient = wcfClient;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WcfClient.UpdateEvents(this.ancienNomTextBox.Text,
                this.nomTextBox.Text, this.categorieTextBox.Text,
                this.dateDebutDatePicker.SelectedDate.Value,
                this.dateFinDatePicker.SelectedDate.Value,
                this.descriptionTextBox.Text, this.photoTextBox.Text,
                this.statutTextBox.Text, this.userTextBox.Text))
                MessageBox.Show("Modification effectuée avec succès :)");
            else
                MessageBox.Show("Modification non effectuée :(");
            this.Close();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            Event v = this.WcfClient.GetEvents(this.ancienNomTextBox.Text);
            if (v != null)
            {
                this.nomTextBox.Text = v.Nom;
                this.categorieTextBox.Text = v.Categorie;
                this.dateDebutDatePicker.SelectedDate = v.DateDebut;
                this.dateFinDatePicker.SelectedDate = v.DateFin;
                this.descriptionTextBox.Text = v.Description;
                this.photoTextBox.Text = v.Photo;
                this.statutTextBox.Text = v.Statut;
                this.userTextBox.Text = v.User;
            }
            else
            {
                MessageBox.Show(this.ancienNomTextBox.Text +
                    "ne correspond à aucun évènements :(");
            }
        }
    }
}