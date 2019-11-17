using ECommerce.Business.Repository;
using ECommerce.Data.Entities;
using ECommerce.UI.Web.Areas.Admin.Models.Methodlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.Web.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        AppUserRepository userRepo = new AppUserRepository();

        // GET: Admin/AppUser
        public ActionResult Index()
        {
            // Kullanıcı Listeleme
            return View(userRepo.GetAll());
        }


        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Add(AppUser kullanici, HttpPostedFileBase image)
        {
            kullanici.ProfilePicturePath = UploadImage.ImageAdd(image, "/UserImages/");

            if(kullanici.ProfilePicturePath=="0" || kullanici.ProfilePicturePath == "1")
            {
                kullanici.ProfilePicturePath = "/ProductImages/user.png";
            }

            userRepo.Add(kullanici);

            return RedirectToAction("Index", "Appuser", new { area = "Admin" });
        }

        public ActionResult Edit(Guid id)
        {
            AppUser orjinalUser = userRepo.Find(id);
            if (orjinalUser != null)
            {
                return View(orjinalUser);
            }
            else
            {
                TempData["HataMesaji"] = "Kullanıcı Bulunamadı";
                return RedirectToAction("Index", "Appuser", new { area = "Admin" });
            }
        }

        [HttpPost]
        public ActionResult Edit(AppUser kullanici,HttpPostedFileBase image)
        {
            AppUser orjinalUser = userRepo.Find(kullanici.ID);
            if (orjinalUser != null)
            {
                orjinalUser.Name = kullanici.Name;
                orjinalUser.SurName = kullanici.SurName;
                orjinalUser.UserName = kullanici.UserName;
                orjinalUser.BirthDate = kullanici.BirthDate;
                orjinalUser.EmailAddress = kullanici.EmailAddress;

                orjinalUser.ProfilePicturePath = UploadImage.ImageAdd(image, "/UserImages/");

                if (orjinalUser.ProfilePicturePath == "0" || orjinalUser.ProfilePicturePath == "1")
                {
                    orjinalUser.ProfilePicturePath = "/ProductImages/user.png";
                }
               
                orjinalUser.Role = kullanici.Role;
                orjinalUser.Password = kullanici.Password;
                userRepo.Update(orjinalUser);
            }
            else
            {
                TempData["HataMesaji"] = "Kullanıcı Bulunamadı";
               
            }
            return RedirectToAction("Index", "Appuser", new { area = "Admin" });
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                userRepo.Delete(id);
                TempData["OnayMesaji"] = "Silme Başarılı";
            }
            catch 
            {
                TempData["HataMesaji"] = "Silme sırasında hata oluştu";
                
            }
            return RedirectToAction("Index", "Appuser", new { area = "Admin" });
        }
    }
}