using Abp.Runtime.Security;
using BLL.Abstract;
using DTOs.AboutDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crocusoft_Task.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = (int)User.Identity.GetUserId();
            return View(await _aboutService.GetAsync(userId));
        }
        public IActionResult Add()
        {
            return PartialView("_MyAboutPartialView");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AboutToAddDto aboutToAddDto)
        {
            aboutToAddDto.UserId= (int)User.Identity.GetUserId();
            await _aboutService.AddAsync(aboutToAddDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateForm(int id)
        {
            return View(await _aboutService.GetByAboutId(id));
        }

        public async Task<IActionResult> Edit(AboutToUpdateDto aboutToUpdateDto)
        {
            await _aboutService.Update(aboutToUpdateDto);
            return RedirectToAction("Index");
        }
    }
}
