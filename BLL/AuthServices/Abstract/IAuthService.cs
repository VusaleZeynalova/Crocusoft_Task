using DTOs.AuthDto;
using Entity.MemberShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AuthServices.Abstract
{
    public interface IAuthService
    {
        Task Register(RegisterUserDto registerUserDto);
        Task<AppUser> Login(UserLoginDto userLoginDto);
        Task LogOut();
    }
}
