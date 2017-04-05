using System;
using System.Collections.Generic;
using DataBoard.Core.Domain;

namespace DataBoard.Core.Repositories
{
    public interface IDatabaseRepository
    {
         Database Get(Guid databaseId);
         IEnumerable<Database> GetAll();
         void Add(Database database);
         void Update(Database database);
         void Remove(Guid databaseId);
    }
}