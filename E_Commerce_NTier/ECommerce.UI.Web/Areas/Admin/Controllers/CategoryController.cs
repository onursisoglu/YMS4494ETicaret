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
        CategoryRepository katRepo = new CategoryRepository();
        // GET: Admin/Category
        public ActionResult Index()
        {

            return View(katRepo.GetAll());
        }

        public ActionResult AddCategory()
        {
            // Kullanıcıya sayfayı göstermek için var.
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Category model)
        {

            katRepo.Add(model);
            return View();
        }


        //varsayılan olarak zaten HttpGet (sayfayı kullanıcıya göstermek içindir.)
        public ActionResult Edit(Guid id)
        {
            Category bulunanKat = katRepo.Find(id);

            return View(bulunanKat);
        }

        [HttpPost]
        public ActionResult Edit(Category yeniModel)
        {
            // verinin veritabanındaki ilk (eski) halini bulmamız gereklidir.
            Category orjinalKat = katRepo.Find(yeniModel.ID);
            orjinalKat.Name = yeniModel.Name;
            orjinalKat.Description = yeniModel.Description;

            katRepo.Save();

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        public ActionResult Delete(Guid id)
        {
            katRepo.Delete(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }




    }
}