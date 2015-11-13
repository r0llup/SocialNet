using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using Cokkiy.Display;
using SocialNetSilverlight.SocialNetServiceReference;

namespace SocialNetSilverlight
{
    public partial class MainPage : UserControl
    {
        public SocialNetServiceClient WcfProxy { get; private set; }
        public HashSet<Event> Events { get; private set; }
        public HashSet<Event> AddedEvents { get; private set; }

        public MainPage(IDictionary<String, String> argd)
        {
            this.InitializeComponent();
            if ((argd.ContainsKey("login")) && (argd["login"].Equals("True")))
            {
                this.eventTypeComboBox.Items.Add("All");
                this.eventTypeComboBox.Items.Add("Private");
            }
            this.eventTypeComboBox.Items.Add("Public");
            this.eventTypeComboBox.SelectedIndex = 0;
            this.eventCategoryComboBox.Items.Add("All");
            this.eventCategoryComboBox.SelectedIndex = 0;
            this.WcfProxy = new SocialNetServiceClient();
            this.Events = new HashSet<Event>();
            this.AddedEvents = new HashSet<Event>();
            this.WcfProxy.ListPublicEventsCompleted += new EventHandler<ListPublicEventsCompletedEventArgs>(WcfProxy_ListPublicEventsCompleted);
            this.WcfProxy.ListPublicEventsAsync();
            this.WcfProxy.ListPrivateEventsCompleted += new EventHandler<ListPrivateEventsCompletedEventArgs>(WcfProxy_ListPrivateEventsCompleted);
            this.WcfProxy.ListPrivateEventsAsync();
            this.WcfProxy.ListCategoriesCompleted += new EventHandler<ListCategoriesCompletedEventArgs>(WcfProxy_ListCategoriesCompleted);
            this.WcfProxy.ListCategoriesAsync();
        }

        protected void WcfProxy_ListPublicEventsCompleted(object sender, ListPublicEventsCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                foreach (Event ev in e.Result)
                    this.Events.Add(ev);
                this.insertLatestIntoCarousel();
            }
        }

        protected void WcfProxy_ListPrivateEventsCompleted(object sender, ListPrivateEventsCompletedEventArgs e)
        {
 	        if (e.Result != null)
            {
                foreach (Event ev in e.Result)
                    this.Events.Add(ev);
            }
        }

        protected void WcfProxy_ListCategoriesCompleted(object sender, ListCategoriesCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                foreach (Category c in e.Result)
                    this.eventCategoryComboBox.Items.Add(c.Nom);
            }
        }

        protected void insertAllIntoCarousel()
        {
            if (this.AddedEvents != null)
            {
                foreach (Event e in this.AddedEvents)
                    this.carousel.ItemSources.Add(new ItemSource(new Uri(e.Photo), e.Nom));
            }
        }

        protected void insertLatestIntoCarousel()
        {
            if (this.Events != null)
            {
                foreach (Event e in this.Events)
                {
                    if (this.carousel.ItemSources.Count < 10)
                    {
                        if (e.Statut.Equals("Public"))
                        {
                            // month's event
                            if ((DateTime.Now - e.DateDebut).Days < 30)
                                this.carousel.ItemSources.Add(new ItemSource(new Uri(e.Photo), e.Nom));
                        }
                    }
                    else
                        break;
                }
            }
        }

        protected void removeAllFromCarousel()
        {
            for (int i = 0; i < this.carousel.ItemSources.Count; i++)
                this.carousel.ItemSources.RemoveAt(i);
        }

        protected void insertAllEvents()
        {
            this.insertPublicEvents();
            this.insertPrivateEvents();
        }

        protected void insertPublicEvents()
        {
            if (this.Events != null)
            {
                foreach (Event e in this.Events)
                {
                    if (e.Statut.Equals("Public"))
                    {
                        if (!this.AddedEvents.Contains(e))
                            this.AddedEvents.Add(e);
                    }
                    else
                    {
                        if (this.AddedEvents.Contains(e))
                            this.AddedEvents.Remove(e);
                    }
                }
            }
        }

        protected void insertPrivateEvents()
        {
            if (this.Events != null)
            {
                foreach (Event e in this.Events)
                {
                    if (e.Statut.Equals("Privé"))
                    {
                        if (!this.AddedEvents.Contains(e))
                            this.AddedEvents.Add(e);
                    }
                    else
                    {
                        if (this.AddedEvents.Contains(e))
                            this.AddedEvents.Remove(e);
                    }
                }
            }
        }

        protected void insertDateEvents(DateTime givenDate)
        {
            if (this.Events != null)
            {
                foreach (Event e in this.Events)
                {
                    if (e.DateDebut.Equals(givenDate))
                    {
                        if (!this.AddedEvents.Contains(e))
                            this.AddedEvents.Add(e);
                    }
                    else
                    {
                        if (this.AddedEvents.Contains(e))
                            this.AddedEvents.Remove(e);
                    }
                }
            }
        }

        protected void insertCategoryEvents(string givenCategory)
        {
            if (this.Events != null)
            {
                foreach (Event e in this.Events)
                {
                    if (e.Categorie.Equals(givenCategory))
                    {
                        if (!this.AddedEvents.Contains(e))
                            this.AddedEvents.Add(e);
                    }
                    else
                    {
                        if (this.AddedEvents.Contains(e))
                            this.AddedEvents.Remove(e);
                    }
                }
            }
        }

        protected void insertNameEvents(string givenName)
        {
            if (this.Events != null)
            {
                foreach (Event e in this.Events)
                {
                    if (e.Nom.Equals(givenName))
                    {
                        if (!this.AddedEvents.Contains(e))
                            this.AddedEvents.Add(e);
                    }
                    else
                    {
                        if (this.AddedEvents.Contains(e))
                            this.AddedEvents.Remove(e);
                    }
                }
            }
        }

        private void eventDateCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((bool)this.eventTypeCheckBox.IsChecked)
            {
                this.insertDateEvents(Convert.ToDateTime(e.AddedItems[0].ToString()));
                this.removeAllFromCarousel();
                this.insertAllIntoCarousel();
            }
        }

        private void eventTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((bool)this.eventTypeCheckBox.IsChecked)
            {
                String type = this.eventTypeComboBox.SelectedItem as String;
                if (type.Equals("All"))
                    this.insertAllEvents();
                if (type.Equals("Public"))
                    this.insertPublicEvents();
                else if (type.Equals("Private"))
                    this.insertPrivateEvents();
                this.removeAllFromCarousel();
                this.insertAllIntoCarousel();
            }
        }

        private void eventCategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((bool)this.eventCategoryCheckBox.IsChecked)
            {
                String category = this.eventCategoryComboBox.SelectedItem as String;
                if (category.Equals("All"))
                    this.insertAllEvents();
                else
                    this.insertCategoryEvents(category);
                this.removeAllFromCarousel();
                this.insertAllIntoCarousel();
            }
        }

        private void eventNameTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((bool)this.eventNameCheckBox.IsChecked)
            {
                if (e.Key == Key.Enter)
                {
                    this.insertNameEvents(this.eventNameTextBox.Text);
                    this.removeAllFromCarousel();
                    this.insertAllIntoCarousel();
                }
            }
        }

        private void carousel_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                this.carousel.TurnDirection = TurnDirection.Counterclockwise;
            else if (e.Delta < 0)
                this.carousel.TurnDirection = TurnDirection.Clockwise;
        }

        private void carousel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonHelper.IsDoubleClick(sender, e))
            {
                if (this.carousel.AutoTurn)
                    this.carousel.AutoTurn = false;
                else
                    this.carousel.AutoTurn = true;
            }
        }
    }
}