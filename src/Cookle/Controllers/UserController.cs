using Microsoft.AspNetCore.Mvc;

namespace Cookle.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}