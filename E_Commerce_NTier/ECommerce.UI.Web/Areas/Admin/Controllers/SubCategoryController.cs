using ECommerce.Business.Repository;
using ECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.Web.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        SubCategoryRepository altKategoriRepo = new SubCategoryRepository();

        // GET: Admin/SubCategory
        public ActionResult Index()
        {

            return View(altKategoriRepo.GetAll());
        }


        public ActionResult Add()
        {
            CategoryRepository katRepo = new CategoryRepository();
            ViewBag.Kategoriler = katRepo.GetActive();
            return View();
        }


        [HttpPost]
        public ActionResult Add(SubCategory model)
        {
            
            altKategoriRepo.Add(model);

            return RedirectToAction("Index","SubCategory",new {area="Admin"});
        }


        public ActionResult Edit(Guid id)
        {
            SubCategory secilenKat = altKategoriRepo.Find(id);
            CategoryRepository katRepo = new CategoryRepository();
            ViewBag.Kategoriler = katRepo.GetActive();

            return View(secilenKat);
        }

        [HttpPost]
        public ActionResult Edit(SubCategory model,Guid id)
        {
            SubCategory secilenKat = altKategoriRepo.Find(id);
            secilenKat.Name = model.Name;
            secilenKat.Description = model.Description;
            secilenKat.MainCategoryID = model.MainCategoryID;
            altKategoriRepo.Save();

            return RedirectToAction("Index", "SubCategory", new { area = "Admin" });
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                altKategoriRepo.Delete(id);
                TempData["OnayMesaji"] = "Silme işlemi başarılıdır";               
            }
            catch (Exception)
            {
                TempData["HataMesaji"] = "Silme İşlemi sırasında hata oluştu";
            }

            return RedirectToAction("Index", "SubCategory", new { area = "Admin" });

        }


    }
}