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
            model.PicturePath = UploadImage.ImageAdd(image, "/ProductImages/");

            if(model.PicturePath=="0" || model.PicturePath == "1")
            {
                model.PicturePath = "/ProductImages/user.png";
            }

            urunRepo.Add(model);
            TempData["OnayMesaji"] = "ürün Ekleme başarıyla gerçekleşti";

            return RedirectToAction("Index","Product",new { area="Admin"});
        }

        public ActionResult Edit(Guid id)
        {
            ProductVM vm = new ProductVM();
            Product orjUrun = urunRepo.Find(id);

            if (orjUrun != null)
            {
                vm.Name = orjUrun.Name;
                vm.Price = orjUrun.Price;
                vm.UnitsInStock = orjUrun.UnitsInStock;
                vm.PicturePath = orjUrun.PicturePath;
                vm.SubCategoryID = orjUrun.SubCategoryID;
                vm.ID = orjUrun.ID;

                vm.AltKategoriler = altKategoriRepo.GetActive();

                return View(vm);
            }


            TempData["HataMesaji"] = "İstenilen ürün bulunamadı.";
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }

        [HttpPost]

        public ActionResult Edit(Product guncelUrun,HttpPostedFileBase image)
        {
            Product orjinalUrun = urunRepo.Find(guncelUrun.ID);

            if (orjinalUrun != null)
            {
                orjinalUrun.Name = guncelUrun.Name;
                orjinalUrun.Price = guncelUrun.Price;
                orjinalUrun.PicturePath = UploadImage.ImageAdd(image, "/ProductImages/");

                if (orjinalUrun.PicturePath == "0" || orjinalUrun.PicturePath == "1")
                {
                    orjinalUrun.PicturePath = "/ProductImages/user.png";
                }

                orjinalUrun.SubCategoryID = guncelUrun.SubCategoryID;
                orjinalUrun.UnitsInStock = guncelUrun.UnitsInStock;

                urunRepo.Save();

                TempData["OnayMesaji"] = "Ürün Güncelleme Başarılı";

            }
            else
            {
                TempData["HataMesaji"] = "Ürün Güncelleme Sırasında Hata Oluştu";
            }

            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }


        public ActionResult Delete(Guid id)
        {
            try
            {
                urunRepo.Delete(id);
                TempData["OnayMesaji"] = "Ürün Başarılı Bir Şekilde Silindi";
            }
            catch 
            {
                TempData["HataMesaji"] = "Ürün Silinemedi";
                
            }

            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }
    }
}