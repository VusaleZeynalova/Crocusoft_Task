using Abp.BackgroundJobs;
using Abp.Runtime.Security;
using BLL.Abstract;
using DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace Crocusoft_Task.Controllers
{
    [Authorize]

    public class EditProfileController : Controller
    {
        private readonly IUserService _userService;

        public EditProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = (int)User.Identity.GetUserId();
            return View(await _userService.GetAsync(userId));
        }

        public async Task<IActionResult> Edit(UserUpdateDto userUpdateDto)
        {
            await _userService.Update(userUpdateDto);
            return RedirectToAction("LogOut","Auth");
        }
    }
}
