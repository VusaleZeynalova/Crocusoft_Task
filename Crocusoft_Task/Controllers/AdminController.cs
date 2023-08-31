using BLL.Abstract;
using Crocusoft_Task.Models;
using DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crocusoft_Task.Controllers
{
    //[Authorize(Roles ="admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListOfUsers()
        {
            return View(await _userService.GetAllAsync());
        }
        public async Task<IActionResult> AddRole(int id)
        {
            var user=await _userService.GetAsync(id);
            return PartialView("_MyRolePartialView",user);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserUpdateDto userUpdateDto,string roleName)
        {
            await _userService.AddRole(userUpdateDto.Id, roleName);
            return RedirectToAction("ListOfUsers");
        }
    }
}
