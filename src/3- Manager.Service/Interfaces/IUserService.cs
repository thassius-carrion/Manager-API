using Manager.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);  
        Task Remove(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> GetAll();
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<List<UserDTO>> SearchByName(string name);
        Task<UserDTO> GetByEmail(string email);
    }
}
