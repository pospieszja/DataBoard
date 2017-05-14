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
            return _context.Users.SingleOrDefault(u => u.Email == email);
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