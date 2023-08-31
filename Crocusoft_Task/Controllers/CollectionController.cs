using Microsoft.AspNetCore.Mvc;

namespace Crocusoft_Task.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
