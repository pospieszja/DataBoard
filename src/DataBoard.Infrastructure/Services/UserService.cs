using System;
using System.Collections.Generic;
using AutoMapper;
using DataBoard.Core.Domain;
using DataBoard.Core.Repositories;
using DataBoard.Infrastructure.DTO;

namespace DataBoard.Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);
            return _mapper.Map<User,UserDto>(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<User>,IEnumerable<UserDto>>(users);
        }

        public void Register(string email, string password)
        {
            var user = _userRepository.Get(email);

            if(user != null)
            {
                throw new Exception($"User with {email} already exist.");
            }

            user = new User(email, password);
            _userRepository.Add(user);
        }
    }
}