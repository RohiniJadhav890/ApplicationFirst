using ApplicationFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationFirst.Controllers
{
    public class ProdController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ProductsDAL productDAL;


        public ProdController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productDAL = new ProductsDAL(configuration);

        }
        // GET: ProdController
        public ActionResult Index3()
        {
            var model = productDAL.GetProducts();

            return View(model);
        }

        // GET: ProdController/Details/5
        public ActionResult Details(int id)
        {
            var model = productDAL.GetProductById(id);
            return View();
        }

        // GET: ProdController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products prod)
        {
            try
            {
                int result = productDAL.AddProduct(prod);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error while adding new Product";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }


          
        }

        // GET: ProdController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = productDAL.GetProductById(id);
            if (model.Pid <= 0)
            {
                return NotFound();
            }
            else
            {
                return View(model);
            }
           // return View();
        }

        // POST: ProdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products prod)
        {
            try
            {
                int result = productDAL.UpdateProduct(prod);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error while updating Product";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }


       
        }

        // GET: ProdController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = productDAL.GetProductById(id);
            return View(model);
        }

        // POST: ProdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                int result = productDAL.DeleteProduct(id);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index3));
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
