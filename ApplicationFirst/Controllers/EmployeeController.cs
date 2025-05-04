using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationFirst.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Show()
        {
            List<string> names=new List<string>(){ "Amol","Rohini","Pooja","vijay","Ovi"};
            ViewData["names"] = names;
            ViewBag.Names = names;//ViewBag create property with the name "Names"

            return View();
        }
        [HttpGet]
        public IActionResult AddEmployee()
        { 
        List<string> Cities=new List<string>()
        { "Select City","pune","Mumbai", "Nagpur", "Nashik", "Aurangabad" };
            ViewData["Cities"] = new SelectList(Cities);
            return View();

        }
        // when form get submitted

        [HttpPost]
        public IActionResult AddEmployee(IFormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.City = form["Cities"];
            ViewBag.Gender = form["Gender"];
            return View("Display");
        }

    }

}

