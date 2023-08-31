using BLL.AuthServices.Abstract;
using DTOs.AuthDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crocusoft_Task.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            try
            {
                var result = await _authService.Login(userLoginDto);
                ViewBag.LoginMessage = "";
                if (result == null)
                {
                    ViewBag.LoginMessage = "Dogru deyil.";
                    return View();

                }
                return RedirectToAction("Index","About");

            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterUserDto registerUserDTo)
        {
            try
            {
                await _authService.Register(registerUserDTo);
                return RedirectToAction("SignIn");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        public async Task<IActionResult> LogOut()
        {
            await _authService.LogOut();
            return RedirectToAction("SignIn");
        }

    }
}
