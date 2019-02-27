using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyHealth.Models;

namespace MyHealth.DAL
{
    public class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var user = new List<User>
            {
            new User{FirstName="Greg",LastName="Auger", ID=1},
             new User{FirstName="Adalei",LastName="Auger", ID=2},

            };

            user.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }  
    }
}