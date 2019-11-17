using ECommerce.Business.Repository;
using ECommerce.Data.Entities;
using ECommerce.UI.Web.Areas.Admin.Models.Methodlar;
using ECommerce.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        SubCategoryRepository altKategoriRepo = new SubCategoryRepository();
        ProductRepository urunRepo = new ProductRepository();

        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(urunRepo.GetAll());
        }

        public ActionResult Add()
        {
            ProductVM vm = new ProductVM();
            vm.AltKategoriler = altKategoriRepo.GetActive();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(Product model, HttpPostedFileBase image)
        {
            model.PicturePath = UploadImage.ImageAdd(image, "/ProductImages");

            if(model.PicturePath=="0" || model.PicturePath == "1")
            {
                model.PicturePath = "/ProductImages/user.png";
            }

            urunRepo.Add(model);
            TempData["OnayMesaji"] = "ürün Ekleme başarıyla gerçekleşti";

            return RedirectToAction("Index","Product",new { area="Admin"});
        }

    }
}