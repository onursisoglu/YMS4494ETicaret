using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.UI.Web.Areas.Admin.Models.Methodlar
{
    public class UploadImage
    {
        public static string ImageAdd(HttpPostedFileBase resim,string serverPath)
        {
            if (resim != null)
            {
                string[] dosyaParca = resim.FileName.Split('.');

                string dosyaUzantisi = dosyaParca[dosyaParca.Length - 1];

                if (dosyaUzantisi == "jpg" || dosyaUzantisi == "jpeg" || dosyaUzantisi == "png" || dosyaUzantisi == "gif")
                {
                    var uniqueName = Guid.NewGuid();
                    string yeniIsim = uniqueName + "." + dosyaUzantisi;

                    var dosyaYolu = HttpContext.Current.Server.MapPath(serverPath + yeniIsim);
                    resim.SaveAs(dosyaYolu);

                    return serverPath + yeniIsim;

                }
                else
                {
                    return "1"; // resim istenilen formatta değilse
                }
            }
            else
            {
                return "0"; // resim nullsa
            }
            
            

          

        }
    }
}