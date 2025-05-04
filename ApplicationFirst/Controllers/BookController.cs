using ApplicationFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationFirst.Controllers
{
    public class BookController : Controller
    {
        public IActionResult List()
        { 
            List<Book> books = new List<Book>()
            {
                new Book() { Id=1,Name="Java",Author="Jemes Gosling",Price=1000},
                new Book() { Id=2,Name="C#",Author="Jon Skeet",Price=1200},
                new Book() { Id=3,Name="Python",Author="Mark Lutz",Price=890}
            };
        ViewBag.Books=books;
            return View();
        }
    }
}
