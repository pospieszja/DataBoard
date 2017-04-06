using System;
using System.Collections.Generic;
using DataBoard.Core.Domain;

namespace DataBoard.Core.Repositories
{
    public interface IUserRepository
    {
         User Get(Guid userId);
         User Get(string email);
         IEnumerable<User> GetAll();
         void Add(User user);
         void Update(User user);
         void Remove(Guid userId);
    }
}