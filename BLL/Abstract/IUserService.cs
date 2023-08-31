using DTOs.UserDtos;
using Entity.MemberShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IUserService
    {
        Task<UserUpdateDto> GetAsync(int userId);
        Task Update(UserUpdateDto userUpdateDto);
        Task<List<UserToListDto>> GetAllAsync();
        Task AddRole(int userId,string roleName);
        
    }
}
