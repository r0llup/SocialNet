using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace SocialNetDAL
{
    [Table(Name = "Events")]
    [DataContractAttribute]
    public class Events
    {
        [Column(IsPrimaryKey = true, Storage = "Nom")]
        [DataMemberAttribute]
        public String Nom { get; set; }

        [Column(Storage = "Categorie")]
        [DataMemberAttribute]
        public String Categorie { get; set; }

        [Column(Storage = "DateDebut")]
        [DataMemberAttribute]
        public DateTime DateDebut { get; set; }

        [Column(Storage = "DateFin")]
        [DataMemberAttribute]
        public DateTime DateFin { get; set; }

        [Column(Storage = "Description")]
        [DataMemberAttribute]
        public String Description { get; set; }

        [Column(Storage = "Photo")]
        [DataMemberAttribute]
        public String Photo { get; set; }

        [Column(Storage = "Statut")]
        [DataMemberAttribute]
        public String Statut { get; set; }

        [Column(Storage = "User")]
        [DataMemberAttribute]
        public String User { get; set; }

        public Events(String nom, String categorie, DateTime dateDebut,
            DateTime dateFin, String description, String photo,
            String statut, String user)
        {
            this.Nom = nom;
            this.Categorie = categorie;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.Description = description;
            this.Photo = photo;
            this.Statut = statut;
            this.User = user;
        }
    }
}