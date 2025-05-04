using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationFirst.Controllers
{


    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection Form
            , ICollection<string> breakfast, ICollection<string> starter)
        {
            ViewBag.Name = Form["name"];
            ViewBag.Contact = Form["contact"];
            ViewBag.Breakfast = breakfast;
            ViewBag.Starter = starter;
            return View("Show1");
            //List<string> Food = new List<string>() { "BreakFast", "starter", "diner" };
            //ViewData["Food"] = new SelectList(Food);
            //   return View();

            //List<string> names = new List<string>() { };
            //ViewData["names"] = names;
            //ViewBag.Names = names;//ViewBag create property with the name "Names"

            //return View();
        }

        // [HttpGet]
 //       [HttpPost]
        // public IActionResult Show1()
        //{
        //using Microsoft.AspNetCore.Mvc.Rendering;
        //SelectList  --> single selection  (dropdown)
        //MultiSelectList --> multiple selection (checkbox, listbox)
        //List<string> Food = new List<string>() { "BreakFast", "starter", "dinner" ,"lunch"};
        //ViewData["Food"] = new SelectList(Food);


        //}
        // when form get submitted





    }
}