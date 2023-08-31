using AutoMapper;
using BLL.Abstract;
using DTOs.UserDtos;
using Entity.MemberShip;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class UserService : IUserService
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        private RoleManager<AppRole> roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, IMapper mapper,RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            _mapper = mapper;
            this.roleManager = roleManager;
        }

        public async Task<UserUpdateDto> GetAsync(int userId)
        {
            AppUser appUser = await userManager.FindByIdAsync(Convert.ToString(userId));
            UserUpdateDto userUpdateDto = _mapper.Map<UserUpdateDto>(appUser);
            return userUpdateDto;
        }

        public async Task Update(UserUpdateDto userUpdateDto)
        {
            AppUser? user = await userManager.FindByIdAsync(Convert.ToString(userUpdateDto.Id));
            if (user != null)
            {
                if (userUpdateDto.Email != user.Email)
                    user.Email = userUpdateDto.Email;
                if (!string.IsNullOrEmpty(userUpdateDto.Password))
                    user.PasswordHash = passwordHasher.HashPassword(user, userUpdateDto.Password);
                if (userUpdateDto.Username != user.UserName)
                    user.UserName = userUpdateDto.Username;
                IdentityResult result = await userManager.UpdateAsync(user);

            }
        }

        public async Task<List<UserToListDto>> GetAllAsync()
        {
            List<AppUser> appUsers = await userManager.Users.ToListAsync();
            List<UserToListDto> userToListDtos = _mapper.Map<List<UserToListDto>>(appUsers);
            return userToListDtos;
        }

        public async Task AddRole(int userId, string roleName)
        {
            AppUser appUser = await userManager.FindByIdAsync(Convert.ToString(userId));
            if (appUser != null)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    var result = await roleManager.CreateAsync(new AppRole(roleName));

                }
               var addToRoleResult=await userManager.AddToRoleAsync(appUser, roleName);
              
            }
        }
    }
}
