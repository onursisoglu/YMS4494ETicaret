using ECommerce.Business.Repository;
using ECommerce.Data.Entities;
using ECommerce.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.Web.Controllers
{
    public class AppUserController : Controller
    {
        AppUserRepository userRepo = new AppUserRepository();
        // GET: AppUser
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUserVM kullanici)
        {
            if (ModelState.IsValid)
            {
                AppUser entity = new AppUser();
                entity.Name = kullanici.Name;
                entity.SurName = kullanici.SurName;
                entity.BirthDate = kullanici.BirthDate;
                entity.Address = kullanici.Address;
                entity.UserName = kullanici.UserName;
                entity.Password = kullanici.Password;
                entity.EmailAddress = kullanici.EmailAddress;
                entity.Gender = kullanici.Gender;
                entity.ProfilePicturePath = kullanici.ProfilePicturePath;
                // Register(Kullanıcı kayıt sayfasından kayıt olan herkes müşteri(Kullanicidir.))
                entity.Role = "Kullanici";
                userRepo.Add(entity);

                return RedirectToAction("Login", "AppUser");
            }
            return View();
        }
    }
}