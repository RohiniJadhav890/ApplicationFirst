using Microsoft.AspNetCore.Mvc;

namespace ApplicationFirst.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
