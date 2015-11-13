using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for AddEvents.xaml
    /// </summary>
    public partial class AddEvents : Window
    {
        public SocialNetServiceClient WcfProxy { get; private set; }

        public AddEvents(SocialNetServiceClient wcfProxy)
        {
            this.InitializeComponent();
            this.WcfProxy = wcfProxy;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.dateDebutDatePicker.SelectedDate != null) &&
                (this.dateFinDatePicker.SelectedDate != null))
            {
                if (this.WcfProxy.AddEvents(this.nomTextBox.Text, this.categorieTextBox.Text,
                    this.dateDebutDatePicker.SelectedDate.Value, this.dateFinDatePicker.SelectedDate.Value,
                    this.descriptionTextBox.Text, this.photoTextBox.Text, this.statutTextBox.Text,
                    this.userTextBox.Text))
                    MessageBox.Show("Ajout effectué avec succès :)");
                else
                    MessageBox.Show("Ajout non effectué :(");
                this.Close();
            }
            else
                MessageBox.Show("Merci de préçiser une date de début et de fin.");
        }
    }
}