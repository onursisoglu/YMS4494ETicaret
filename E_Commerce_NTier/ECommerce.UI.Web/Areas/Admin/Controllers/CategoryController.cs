using ECommerce.Business.Repository;
using ECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            // Kullanıcıya sayfayı göstermek için var.
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            CategoryRepository katRepo = new CategoryRepository();

            katRepo.Add(model);

            return View();
        }


    }
}