using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crocusoft_Task.Controllers
{
    [AllowAnonymous]
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name= User.Identity.Name;
            return View();
        }
    }
}
