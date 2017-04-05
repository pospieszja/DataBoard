using System;
using System.Collections.Generic;

namespace DataBoard.Core.Domain
{
    public class DatabaseAdministrator
    {
        public Guid UserId { get; private set; }
        public IEnumerable<Database> Databases { get; private set; }
        
        public DatabaseAdministrator(Guid userId)
        {
            UserId = userId;
        }
    }
}