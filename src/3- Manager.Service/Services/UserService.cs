using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Service.DTO;
using Manager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }
        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExist = await _userRepository.GetByEmail(userDTO.Email);

            if (userExist != null)
                throw new DomainException("Already exist an user with the email informed");
            
            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }
        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExist = await _userRepository.Get(userDTO.Id);

            if (userExist == null)
                throw new DomainException("User do not exist.");

            var user = _mapper.Map<User>(userDTO);

            var userUpdated = await _userRepository.Update(user);
            
            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task<UserDTO> Get(long id)
        {
            var userExist = await _userRepository.Get(id);

            if (userExist == null)
                throw new DomainException("User do not exist.");

            return _mapper.Map<UserDTO>(userExist);

        }

        public async Task<List<UserDTO>> GetAll()
        {
            var allUsers = await _userRepository.GetAll();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var userExist = await _userRepository.GetByEmail(email);

            if (userExist == null)
                throw new DomainException("User do not exist.");

            return _mapper.Map<UserDTO>(userExist);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsers = await _userRepository.SearchByEmail(name);

            return _mapper.Map<List<UserDTO>>(allUsers);

        }

    }
}
