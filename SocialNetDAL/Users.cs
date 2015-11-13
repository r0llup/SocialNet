using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace SocialNetDAL
{
    [Table(Name = "Users")]
    [DataContractAttribute]
    public class Users
    {
        [Column(IsPrimaryKey = true, Storage = "Pseudo")]
        [DataMemberAttribute]
        public String Pseudo { get; set; }

        [Column(Storage = "Nom")]
        [DataMemberAttribute]
        public String Nom { get; set; }

        [Column(Storage = "Prenom")]
        [DataMemberAttribute]
        public String Prenom { get; set; }

        [Column(Storage = "Password")]
        [DataMemberAttribute]
        public String Password { get; set; }

        [Column(Storage = "Avatar")]
        [DataMemberAttribute]
        public String Avatar { get; set; }

        public Users(String pseudo, String nom, String prenom,
            String password, String avatar)
        {
            this.Pseudo = pseudo;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Password = password;
            this.Avatar = avatar;
        }
    }
}