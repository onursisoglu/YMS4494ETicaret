using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.UI.Web.Models.VM
{
    public class AppUserVM
    {
        [Required(ErrorMessage ="Ad Boş Bırakılamaz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Boş Bırakılamaz")]
        public string SurName { get; set; }

        public string ProfilePicturePath { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        [MinLength(4,ErrorMessage ="En Az 4 karakter girmelisiniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrarı Boş Bırakılamaz")]
        [Compare("Password",ErrorMessage ="Şifre ve Şifre Tekrarları Uyuşmuyor.")]
        public string ComparePassword { get; set; }

        [Required(ErrorMessage = "Email Adresi Boş Bırakılamaz")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Cinsiyet Seçmediniz.")]
        public char Gender { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }
    }
}