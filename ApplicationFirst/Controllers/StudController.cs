using ApplicationFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationFirst.Controllers
{
    public class StudController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly StudentDAL studentDAL;
        

        public StudController(IConfiguration configuration)
        {
            this.configuration = configuration;
            studentDAL = new StudentDAL(configuration);
         
        }
        // GET: StudController
        public ActionResult Index1()
        {
            var model = studentDAL.GetStudents();
            //option 1
            //ViewBag.Employee = model
            //option 2
            return View(model);
           
        }

        // GET: StudController/Details/5
        public ActionResult Details(int id)
        {
            var model = studentDAL.GetStudentById(id);
            return View();
        }

        // GET: StudController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stud)
        {
            try
            {
                int result = studentDAL.AddStudent(stud);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error while adding new student";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: StudController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = studentDAL.GetStudentById(id);
            if (model.Id <= 0)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
        }

        // POST: StudController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stud)
        {
            try
            {
                int result = studentDAL.UpdateEmployee(stud);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error while updating Student";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        // GET: StudController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = studentDAL.GetStudentById(id);
            return View(model);
        }

        // POST: StudController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                int result = studentDAL.DeleteStudent(id);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Deleted employee";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }
    }
}
