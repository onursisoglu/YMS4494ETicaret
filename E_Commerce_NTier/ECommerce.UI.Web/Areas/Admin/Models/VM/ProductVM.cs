using ECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.UI.Web.Areas.Admin.Models.VM
{
    public class ProductVM
    {
        public Guid ID { get; set; }


        [Required(ErrorMessage ="Ürün Adı Boş Geçilemez")]
        [MinLength(3,ErrorMessage ="Ürün Adı Minimum 3 karakter olmalıdır. Daha az girilemez.")]
        [Display(Name ="Ürün Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fiyat Boş Geçilemez")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Stok Miktarı")]
        public short UnitsInStock { get; set; }

        [Display(Name = "Ürüne Ait Resim")]
        public string PicturePath { get; set; }

        public Guid SubCategoryID { get; set; }


        public List<SubCategory> AltKategoriler { get; set; }
    }
}