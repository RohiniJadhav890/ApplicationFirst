using ApplicationFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationFirst.Controllers
{
    public class EmpController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly EmployeeDAL employeeDAL;
        //  private object employeDAL;

        public EmpController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeeDAL = new EmployeeDAL(configuration);
            //  employeDAL = employeeDAL;
        }
        // GET:ALL Emp
        public ActionResult Index()
        {
            var model = employeeDAL.GetEmployees();
            //option 1
            //ViewBag.Employee = model
            //option 2
            return View(model);
            // return View();
        }

        // GET: EmpController/Details/5
        public ActionResult Details(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
            // return View();
        }

        // GET: EmpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {

            try
            {
                int result = employeeDAL.AddEmployee(emp);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error while adding new employee";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        // GET: EmpController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            if (model.empid <= 0)
            {
                return NotFound();
            }
            else {
                return View(model);
            }
                
            //return View();
        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = employeeDAL.UpdateEmployee(emp);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error while updating employee";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        // GET: EmpController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
            //return View();
        }

        // POST: EmpController/Delete/5
        [HttpPost]
         [ValidateAntiForgeryToken]
        [ActionName("Delete")]//this is the info for app that delete is get req & deleteconfirm is post req

        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = employeeDAL.DeleteEmployee(id);
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