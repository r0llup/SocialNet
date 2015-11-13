using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetDAL.Properties;

namespace SocialNetDAL
{
    public class DALib
    {
        public SocialNetDataContext DataContext { get; private set; }

        public DALib()
        {
            this.DataContext = new SocialNetDataContext(Settings.Default.SocialNetConnectionString);
        }

        // Categories

        public List<Category> showCategories()
        {
            return (from Category in this.DataContext.Categories
                    orderby Category.Nom
                    select Category).ToList();
        }

        public Category showCategories(String oldName)
        {
            return (from Category in this.DataContext.Categories
                    where Category.Nom.Equals(oldName)
                    select Category).Single();
        }

        public Boolean insertCategories(Category newCategory)
        {
            try
            {
                this.DataContext.Categories.InsertOnSubmit(newCategory);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean editCategories(String oldName, Category newCategory)
        {
            try
            {
                Category editableCategory = this.DataContext.Categories.Single(c => c.Nom == oldName);
                editableCategory.Nom = newCategory.Nom;
                editableCategory.Description = newCategory.Description;
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean deleteCategories(Category oldCategory)
        {
            try
            {
                this.DataContext.Categories.DeleteOnSubmit(oldCategory);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public List<String> showCategoriesName()
        {
            return (from Category in this.DataContext.Categories
                    orderby Category.Nom
                    select Category.Nom).ToList();
        }

        public List<String> showCategoriesDescription()
        {
            return (from Category in this.DataContext.Categories
                    orderby Category.Description
                    select Category.Description).ToList();
        }

        public List<String> showCategoriesDescription(String oldName)
        {
            return (from Category in this.DataContext.Categories
                    where Category.Nom.Equals(oldName)
                    select Category.Description).ToList();
        }

        // Events

        public List<Event> showEvents()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.Nom
                    select Event).ToList();
        }

        public Event showEvents(String oldName)
        {
            return (from Event in this.DataContext.Events
                    where Event.Nom.Equals(oldName)
                    select Event).Single();
        }

        public List<Event> showRelatedEvents(String oldNick)
        {
            return (from Event in this.DataContext.Events
                    where Event.User.Equals(oldNick)
                    orderby Event.Nom
                    select Event).ToList();
        }

        public Dictionary<String, String> showEventsNamePhoto()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.Nom
                    select new { Event.Nom, Event.Photo }).ToDictionary(d => d.Nom, d => d.Photo);
        }

        public Boolean insertEvents(Event newEvent)
        {
            try
            {
                this.DataContext.Events.InsertOnSubmit(newEvent);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean editEvents(String oldName, Event newEvent)
        {
            try
            {
                Event editableEvent = this.DataContext.Events.Single(e => e.Nom == oldName);
                editableEvent.Nom = newEvent.Nom;
                editableEvent.Categorie = newEvent.Categorie;
                editableEvent.DateDebut = newEvent.DateDebut;
                editableEvent.DateFin = newEvent.DateFin;
                editableEvent.Description = newEvent.Description;
                editableEvent.Photo = newEvent.Photo;
                editableEvent.Statut = newEvent.Statut;
                editableEvent.User = newEvent.User;
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean deleteEvents(Event oldEvent)
        {
            try
            {
                this.DataContext.Events.DeleteOnSubmit(oldEvent);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public List<Event> showPrivateEvents() /*FIXME*/
        {
            return (from Event in this.DataContext.Events
                    where Event.Statut.Equals("Privé")
                    orderby Event.Nom
                    select Event).ToList();
        }

        public List<Event> showPublicEvents() /*FIXME*/
        {
            return (from Event in this.DataContext.Events
                    where Event.Statut.Equals("Public")
                    orderby Event.Nom
                    select Event).ToList();
        }

        public List<String> showEventsName()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.Nom
                    select Event.Nom).ToList();
        }

        public List<String> showEventsCategories()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.Categorie
                    select Event.Categorie).ToList();
        }

        public String showEventsCategories(String oldName)
        {
            return (from Event in this.DataContext.Events
                    where Event.Nom.Equals(oldName)
                    select Event.Categorie).Single();
        }

        public List<DateTime> showEventsStartDate()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.DateDebut
                    select Event.DateDebut).ToList();
        }

        public DateTime showEventsStartDate(String oldName)
        {
            return (from Event in this.DataContext.Events
                    where Event.Nom.Equals(oldName)
                    select Event.DateDebut).Single();
        }

        public List<DateTime> showEventsEndDate()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.DateFin
                    select Event.DateFin).ToList();
        }

        public DateTime showEventsEndDate(String oldName)
        {
            return (from Event in this.DataContext.Events
                    where Event.Nom.Equals(oldName)
                    select Event.DateFin).Single();
        }

        public List<String> showEventsDescription()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.Description
                    select Event.Description).ToList();
        }

        public String showEventsDescription(String oldName)
        {
            return (from Event in this.DataContext.Events
                    where Event.Nom.Equals(oldName)
                    select Event.Description).Single();
        }

        public List<String> showEventsPhoto()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.Photo
                    select Event.Photo).ToList();
        }

        public String showEventsPhoto(String oldName)
        {
            return (from Event in this.DataContext.Events
                    where Event.Nom.Equals(oldName)
                    select Event.Photo).Single();
        }

        public List<String> showEventsState()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.Statut
                    select Event.Statut).ToList();
        }

        public String showEventsState(String oldName)
        {
            return (from Event in this.DataContext.Events
                    where Event.Nom.Equals(oldName)
                    select Event.Statut).Single();
        }

        public List<String> showEventsUser()
        {
            return (from Event in this.DataContext.Events
                    orderby Event.User
                    select Event.User).ToList();
        }

        public String showEventsUser(String oldName)
        {
            return (from Event in this.DataContext.Events
                    where Event.Nom.Equals(oldName)
                    select Event.User).Single();
        }

        // Users

        public List<User> showUsers()
        {
            return (from User in this.DataContext.Users
                    orderby User.Pseudo
                    select User).ToList();
        }

        public User showUsers(String oldNick)
        {
            return (from User in this.DataContext.Users
                    where User.Pseudo.Equals(oldNick)
                    select User).Single();
        }

        public Boolean insertUsers(User newUser)
        {
            try
            {
                this.DataContext.Users.InsertOnSubmit(newUser);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean editUsers(String oldNick, User newUser)
        {
            try
            {
                User editableUser = this.DataContext.Users.Single(u => u.Pseudo == oldNick);
                editableUser.Nom = newUser.Nom;
                editableUser.Prenom = newUser.Prenom;
                editableUser.Pseudo = newUser.Pseudo;
                editableUser.Password = newUser.Password;
                editableUser.Avatar = newUser.Avatar;
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean deleteUsers(User oldUser)
        {
            try
            {
                this.DataContext.Users.DeleteOnSubmit(oldUser);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public List<String> showUsersNick()
        {
            return (from User in this.DataContext.Users
                    orderby User.Pseudo
                    select User.Pseudo).ToList();
        }

        public List<String> showUsersFirstname()
        {
            return (from User in this.DataContext.Users
                    orderby User.Nom
                    select User.Nom).ToList();
        }

        public String showUsersFirstname(String oldNick)
        {
            return (from User in this.DataContext.Users
                    where User.Pseudo.Equals(oldNick)
                    select User.Nom).Single();
        }

        public List<String> showUsersLastname()
        {
            return (from User in this.DataContext.Users
                    orderby User.Prenom
                    select User.Prenom).ToList();
        }

        public String showUsersLastname(String oldNick)
        {
            return (from User in this.DataContext.Users
                    where User.Pseudo.Equals(oldNick)
                    select User.Prenom).Single();
        }

        public List<String> showUsersPassword()
        {
            return (from User in this.DataContext.Users
                    orderby User.Password
                    select User.Password).ToList();
        }

        public String showUsersPassword(String oldNick)
        {
            return (from User in this.DataContext.Users
                    where User.Pseudo.Equals(oldNick)
                    select User.Password).Single();
        }

        public List<String> showUsersAvatar()
        {
            return (from User in this.DataContext.Users
                    orderby User.Avatar
                    select User.Avatar).ToList();
        }

        public String showUsersAvatar(String oldNick)
        {
            return (from User in this.DataContext.Users
                    where User.Pseudo.Equals(oldNick)
                    select User.Avatar).Single();
        }

        // Records

        public List<Record> showRecords()
        {
            return (from Record in this.DataContext.Records
                    orderby Record.Event
                    select Record).ToList();
        }

        public Record showRecords(String oldEvent, String oldUser)
        {
            return (from Record in this.DataContext.Records
                    where Record.Event.Equals(oldEvent) &&
                        Record.User.Equals(oldUser)
                    select Record).Single();
        }

        public List<Record> showRelatedRecords(String oldUser)
        {
            return (from Record in this.DataContext.Records
                    where Record.User.Equals(oldUser)
                    orderby Record.Event
                    select Record).ToList();
        }

        public Boolean insertRecords(Record newRecord)
        {
            try
            {
                this.DataContext.Records.InsertOnSubmit(newRecord);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean editRecords(String oldEvent, String oldUser, Record newRecord)
        {
            try
            {
                Record editableRecord = this.DataContext.Records.Single(c => (c.Event == oldEvent) && (c.User == oldUser));
                editableRecord.Event = newRecord.Event;
                editableRecord.User = newRecord.User;
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean deleteRecords(Record oldRecord)
        {
            try
            {
                this.DataContext.Records.DeleteOnSubmit(oldRecord);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        // Comments

        public List<Comment> showComments()
        {
            return (from Comment in this.DataContext.Comments
                    orderby Comment.Event
                    select Comment).ToList();
        }

        public Comment showComments(String oldEvent, String oldUser)
        {
            return (from Comment in this.DataContext.Comments
                    where Comment.Event.Equals(oldEvent) &&
                        Comment.User.Equals(oldUser)
                    select Comment).Single();
        }

        public List<Comment> showRelatedComments(String oldUser)
        {
            return (from Comment in this.DataContext.Comments
                    where Comment.User.Equals(oldUser)
                    orderby Comment.Event
                    select Comment).ToList();
        }

        public Boolean insertComments(Comment newComment)
        {
            try
            {
                this.DataContext.Comments.InsertOnSubmit(newComment);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean editComments(String oldEvent, String oldUser, Comment newComment)
        {
            try
            {
                Comment editableComment = this.DataContext.Comments.Single(c => (c.Event == oldEvent) && (c.User == oldUser));
                editableComment.Event = newComment.Event;
                editableComment.User = newComment.User;
                editableComment.Photo = newComment.Photo;
                editableComment.Commentaire = newComment.Commentaire;
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }

        public Boolean deleteComments(Comment oldComment)
        {
            try
            {
                this.DataContext.Comments.DeleteOnSubmit(oldComment);
                this.DataContext.SubmitChanges();
                return true;
            }
            catch (Exception) /*FIXME*/
            {
                return false;
            }
        }
    }
}