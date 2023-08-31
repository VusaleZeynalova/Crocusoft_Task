using BLL.AuthServices.Abstract;
using DTOs.AuthDto;
using Entity.MemberShip;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AuthServices.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<AppUser> Login(UserLoginDto userLoginDto)
        {
            AppUser? user = null;
            user = await userManager.FindByNameAsync(userLoginDto.Username);
            if (user == null)
            {
                goto end;
            }
            var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, true, true);
            if (!result.Succeeded)
            {
                user = null;
                goto end;
            }
            end:
            return user;
     
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task Register(RegisterUserDto registerUserDto)
        {
            var user = new AppUser();
            user.UserName = registerUserDto.Username;
            user.Email = registerUserDto.Email;
            user.EmailConfirmed = true;
            var result = await userManager.CreateAsync(user, registerUserDto.Password);
        }
    }
}
