using System.Collections.Generic;
using DataBoard.Infrastructure.DTO;

namespace DataBoard.Infrastructure.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto Get(string email);
    }
}