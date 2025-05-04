using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationFirst.Controllers
{
    public class AddEmpController : Controller
    {
         

            [HttpGet]
        public IActionResult AddEmployee()
        {

            
                //using Microsoft.AspNetCore.Mvc.Rendering;
                //SelectList  --> single selection  (dropdown)
                //MultiSelectList --> multiple selection (checkbox, listbox)
                List<string> Cities = new List<string>() { "Select City", "Pune", "Mumbai", "Nagpur", "Nashik", "Aurangabad" };
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

