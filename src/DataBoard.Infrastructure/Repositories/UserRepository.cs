using System;
using System.Collections.Generic;
using System.Linq;
using DataBoard.Core.Domain;
using DataBoard.Core.Repositories;

namespace DataBoard.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataboardContext _context;

        // private static ISet<User> _users = new HashSet<User>
        // {
        //     new User("user1email.com", "secret"),
        //     new User("user2@email.com", "secret"),
        //     new User("user3@email.com", "secret")
        // };
        public UserRepository(DataboardContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Get(Guid userId)
        {
            throw new NotImplementedException();
        }

        public User Get(string email)
        {
            return _context.Users.FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Remove(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}