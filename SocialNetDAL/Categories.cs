using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace SocialNetDAL
{
    [Table(Name = "Categories")]
    [DataContractAttribute]
    public class Categories
    {
        [Column(IsPrimaryKey = true, Storage = "Nom")]
        [DataMemberAttribute]
        public String Nom { get; set; }

        [Column(Storage = "Description")]
        [DataMemberAttribute]
        public String Description { get; set; }

        public Categories(String nom, String description)
        {
            this.Nom = nom;
            this.Description = description;
        }
    }
}