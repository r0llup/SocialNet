using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using SocialNetWPF.SocialNetServiceReference;

namespace SocialNetWPF
{
    /// <summary>
    /// Interaction logic for SocialNet.xaml
    /// </summary>
    public partial class SocialNet : Window
    {
        public SocialNetServiceClient WcfProxy { get; private set; }
        public ObservableCollection<Category> OcCategory { get; private set; }
        public ObservableCollection<User> OcUser { get; private set; }
        public ObservableCollection<Event> OcEvent { get; private set; }

        public SocialNet()
        {
            this.InitializeComponent();
            this.WcfProxy = new SocialNetServiceClient();
            this.OcCategory = null;
            this.OcUser = null;
            this.OcEvent = null;
            this.MenuItem_Click_11(null, null);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            new AddCategories(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            new UpdateCategories(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            new DeleteCategories(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            new AddEvents(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            new UpdateEvents(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            new DeleteEvents(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            new AddUsers(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            new UpdateUsers(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            new DeleteUsers(this.WcfProxy).ShowDialog();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            this.statusBarItem.Content = "Sauvegarde effectuée avec succès.";
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            this.OcCategory = new ObservableCollection<Category>(this.WcfProxy.ListCategories());
            this.OcUser = new ObservableCollection<User>(this.WcfProxy.ListUsers());
            this.OcEvent = new ObservableCollection<Event>(this.WcfProxy.ListEvents());
            this.OcCategory.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OcCategory_CollectionChanged);
            this.OcUser.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OcUser_CollectionChanged);
            this.OcEvent.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OcEvent_CollectionChanged);
            this.categoriesDataGrid.DataContext = this.OcCategory;
            this.usersDataGrid.DataContext = this.OcUser;
            this.eventsDataGrid.DataContext = this.OcEvent;
            this.statusBarItem.Content = "Actualisation effectuée avec succès.";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MenuItem_Click_11(sender, e);
            this.statusBarItem.Content = "Chargement effectué avec succès.";
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            this.MenuItem_Click_10(sender, null);
        }

        void OcCategory_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Category c in e.NewItems)
                        this.WcfProxy.AddCategories(c.Nom, c.Description);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Category c in e.OldItems)
                        this.WcfProxy.DeleteCategories(c.Nom);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        void OcUser_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (User u in e.NewItems)
                        this.WcfProxy.AddUsers(u.Pseudo, u.Nom,
                            u.Prenom, u.Password, u.Avatar);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (User u in e.OldItems)
                        this.WcfProxy.DeleteUsers(u.Pseudo);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        void OcEvent_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Event v in e.NewItems)
                        this.WcfProxy.AddEvents(v.Nom, v.Categorie,
                            v.DateDebut, v.DateFin, v.Description,
                            v.Photo, v.Statut, v.User);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Event v in e.OldItems)
                        this.WcfProxy.DeleteEvents(v.Nom);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
    }
}