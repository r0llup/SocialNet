using System;
using System.Collections.Generic;
using SocialNetDAL;

namespace SocialNetService
{
    public class SocialNetService : ISocialNetService
    {
        public DALib DalLib { get; private set; }

        public SocialNetService()
        {
            this.DalLib = new DALib();
        }

        // Categories

        public Boolean AddCategories(String newName, String newDescription)
        {
            return this.DalLib.insertCategories(
                new Category()
                {
                    Nom = newName,
                    Description = newDescription
                });
        }

        public Boolean UpdateCategories(String oldName, String newName, String newDescription)
        {
            return this.DalLib.editCategories(oldName,
                new Category()
                {
                    Nom = newName,
                    Description = newDescription
                });
        }

        public Boolean DeleteCategories(String oldName)
        {
            return this.DalLib.deleteCategories(this.DalLib.showCategories(oldName));
        }

        public Category GetCategories(String oldName)
        {
            return this.DalLib.showCategories(oldName);
        }

        public List<Category> ListCategories()
        {
            return this.DalLib.showCategories();
        }

        // Events

        public Boolean AddEvents(String newName, String newCategory, DateTime newStartDate,
            DateTime newEndDate, String newDescription, String newPhoto,
            String newState, String newUser)
        {
            return this.DalLib.insertEvents(
                new Event()
                {
                    Nom = newName,
                    Categorie = newCategory,
                    DateDebut = newStartDate,
                    DateFin = newEndDate,
                    Description = newDescription,
                    Photo = newPhoto,
                    Statut = newState,
                    User = newUser
                });
        }

        public Boolean UpdateEvents(String oldName, String newName, String newCategory,
            DateTime newStartDate, DateTime newEndDate, String newDescription,
            String newPhoto, String newState, String newUser)
        {
            return this.DalLib.editEvents(oldName,
                new Event()
                {
                    Nom = newName,
                    Categorie = newCategory,
                    DateDebut = newStartDate,
                    DateFin = newEndDate,
                    Description = newDescription,
                    Photo = newPhoto,
                    Statut = newState,
                    User = newUser
                });
        }

        public Boolean DeleteEvents(String oldName)
        {
            return this.DalLib.deleteEvents(this.DalLib.showEvents(oldName));
        }

        public Event GetEvents(String oldName)
        {
            return this.DalLib.showEvents(oldName);
        }

        public List<Event> ListEvents()
        {
            return this.DalLib.showEvents();
        }

        public List<Event> ListPublicEvents()
        {
            return this.DalLib.showPublicEvents();
        }

        public List<Event> ListPrivateEvents()
        {
            return this.DalLib.showPrivateEvents();
        }

        public List<Event> ListRelatedEvents(String oldNick)
        {
            return this.DalLib.showRelatedEvents(oldNick);
        }

        public Dictionary<String, String> ListEventsNamePhoto()
        {
            return this.DalLib.showEventsNamePhoto();
        }

        public List<String> ListEventsName()
        {
            return this.DalLib.showEventsName();
        }

        public List<String> ListEventsPhoto()
        {
            return this.DalLib.showEventsPhoto();
        }

        // Users

        public Boolean AddUsers(String newNick, String newFirstname, String newLastname,
            String newPassword, String newAvatar)
        {
            return this.DalLib.insertUsers(
                new User()
                {
                    Pseudo = newNick,
                    Nom = newFirstname,
                    Prenom = newLastname,
                    Password = newPassword,
                    Avatar = newAvatar
                });
        }

        public Boolean UpdateUsers(String oldNick, String newNick, String newFirstname,
            String newLastname, String newPassword, String newAvatar)
        {
            return this.DalLib.editUsers(oldNick,
                new User()
                {
                    Pseudo = newNick,
                    Nom = newFirstname,
                    Prenom = newLastname,
                    Password = newPassword,
                    Avatar = newAvatar
                });
        }

        public Boolean DeleteUsers(String oldNick)
        {
            return this.DalLib.deleteUsers(this.DalLib.showUsers(oldNick));
        }

        public User GetUsers(String oldNick)
        {
            return this.DalLib.showUsers(oldNick);
        }

        public List<User> ListUsers()
        {
            return this.DalLib.showUsers();
        }

        // Records

        public Boolean AddRecords(String newEvent, String newUser)
        {
            return this.DalLib.insertRecords(new Record()
            {
                Event = newEvent,
                User = newUser
            });
        }

        public Boolean UpdateRecords(String oldEvent, String oldUser, String newEvent, String newUser)
        {
            return this.DalLib.editRecords(oldEvent, oldUser,
                new Record()
                {
                    Event = newEvent,
                    User = newUser
                });
        }

        public Boolean DeleteRecords(String oldEvent, String oldUser)
        {
            return this.DalLib.deleteRecords(this.DalLib.showRecords(oldEvent, oldUser));
        }

        public Record GetRecords(String oldEvent, String oldUser)
        {
            return this.DalLib.showRecords(oldEvent, oldUser);
        }

        public List<Record> ListRecords()
        {
            return this.DalLib.showRecords();
        }

        public List<Record> ListRelatedRecords(String oldUser)
        {
            return this.DalLib.showRelatedRecords(oldUser);
        }

        // Comments

        public Boolean AddComments(String newEvent, String newUser, String newPhoto, String newComment)
        {
            return this.DalLib.insertComments(new Comment()
            {
                Event = newEvent,
                User = newUser,
                Photo = newPhoto,
                Commentaire = newComment
            });
        }

        public Boolean UpdateComments(String oldEvent, String oldUser, String newEvent,
            String newUser, String newPhoto, String newComment)
        {
            return this.DalLib.editComments(oldEvent, oldUser,
                new Comment()
                {
                    Event = newEvent,
                    User = newUser,
                    Photo = newPhoto,
                    Commentaire = newComment
                });
        }

        public Boolean DeleteComments(String oldEvent, String oldUser)
        {
            return this.DalLib.deleteComments(this.DalLib.showComments(oldEvent, oldUser));
        }

        public Comment GetComments(String oldEvent, String oldUser)
        {
            return this.DalLib.showComments(oldEvent, oldUser);
        }

        public List<Comment> ListComments()
        {
            return this.DalLib.showComments();
        }

        public List<Comment> ListRelatedComments(String oldUser)
        {
            return this.DalLib.showRelatedComments(oldUser);
        }
    }
}