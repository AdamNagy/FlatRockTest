using Microsoft.AspNetCore.Mvc;

namespace Nadam.FlatRockTest.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
