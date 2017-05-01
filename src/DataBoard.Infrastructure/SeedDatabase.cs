using System.Collections.Generic;
using System.Linq;
using DataBoard.Core.Domain;

namespace DataBoard.Infrastructure
{
    public static class SeedDatabase
    {
        public static void EnsureSeedData(this DataboardContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new List<User>()
            {
                new User("user1@a.pl", "secret"),
                new User("user2@a.pl", "secret")                
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}