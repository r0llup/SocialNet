using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SocialNetDAL
{
    [DatabaseAttribute(Name = "SocialNet")]
    public partial class SocialNetDataContext : DataContext
    {
        public Table<Categories> Categories;
        public Table<Events> Events;
        public Table<Users> Users;
        public SocialNetDataContext(String con) : base(con) { }
    }
}