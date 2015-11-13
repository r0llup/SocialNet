using System;
using System.Collections.Generic;
using System.ServiceModel;
using SocialNetDAL;

namespace SocialNetService
{
    [ServiceContract]
    public interface ISocialNetService
    {
        // Categories

        [OperationContract]
        Boolean AddCategories(String newName, String newDescription);

        [OperationContract]
        Boolean UpdateCategories(String oldName, String newName, String newDescription);

        [OperationContract]
        Boolean DeleteCategories(String oldName);

        [OperationContract]
        Category GetCategories(String oldName);

        [OperationContract]
        List<Category> ListCategories();

        // Events

        [OperationContract]
        Boolean AddEvents(String newName, String newCategory, DateTime newStartDate,
            DateTime newEndDate, String newDescription, String newPhoto,
            String newState, String newUser);

        [OperationContract]
        Boolean UpdateEvents(String oldName, String newName, String newCategory,
            DateTime newStartDate, DateTime newEndDate, String newDescription,
            String newPhoto, String newState, String newUser);

        [OperationContract]
        Boolean DeleteEvents(String oldName);

        [OperationContract]
        Event GetEvents(String oldName);

        [OperationContract]
        List<Event> ListEvents();

        [OperationContract]
        List<Event> ListPublicEvents();

        [OperationContract]
        List<Event> ListPrivateEvents();

        [OperationContract]
        List<Event> ListRelatedEvents(String oldNick);

        [OperationContract]
        Dictionary<String, String> ListEventsNamePhoto();

        [OperationContract]
        List<String> ListEventsName();

        [OperationContract]
        List<String> ListEventsPhoto();

        // Users

        [OperationContract]
        Boolean AddUsers(String newNick, String newFirstname, String newLastname,
            String newPassword, String newAvatar);

        [OperationContract]
        Boolean UpdateUsers(String oldNick, String newNick, String newFirstname,
            String newLastname, String newPassword, String newAvatar);

        [OperationContract]
        Boolean DeleteUsers(String oldNick);

        [OperationContract]
        User GetUsers(String oldNick);

        [OperationContract]
        List<User> ListUsers();

        // Records

        [OperationContract]
        Boolean AddRecords(String newEvent, String newUser);

        [OperationContract]
        Boolean UpdateRecords(String oldEvent, String oldUser, String newEvent, String newUser);

        [OperationContract]
        Boolean DeleteRecords(String oldEvent, String oldUser);

        [OperationContract]
        Record GetRecords(String oldEvent, String oldUser);

        [OperationContract]
        List<Record> ListRecords();

        [OperationContract]
        List<Record> ListRelatedRecords(String oldUser);

        // Comments

        [OperationContract]
        Boolean AddComments(String newEvent, String newUser, String newPhoto, String newComment);

        [OperationContract]
        Boolean UpdateComments(String oldEvent, String oldUser, String newEvent,
            String newUser, String newPhoto, String newComment);

        [OperationContract]
        Boolean DeleteComments(String oldEvent, String oldUser);

        [OperationContract]
        Comment GetComments(String oldEvent, String oldUser);

        [OperationContract]
        List<Comment> ListComments();

        [OperationContract]
        List<Comment> ListRelatedComments(String oldUser);
    }
}