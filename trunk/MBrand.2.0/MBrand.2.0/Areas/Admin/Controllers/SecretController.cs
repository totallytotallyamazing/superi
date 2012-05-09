using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;
using MBrand.Helpers;
using System.Drawing;

namespace MBrand.Areas.Admin.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        //
        // GET: /Admin/Secret/
        private readonly ContentContainer _db = new ContentContainer();


        public ActionResult AddSecret()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddSecret(HttpPostedFileBase secretImage, int sortOrder)
        {
            Secret secret = new Secret();
            if (secretImage != null)
            {
                string fileName = Path.GetFileName(secretImage.FileName);
                fileName = IOHelper.GetUniqueFileName("~/Content/secret/", secretImage.FileName);
                secretImage.SaveFile("~/Content/secret/", fileName);
                secret.FileName = fileName;
                secret.SortOrder = sortOrder;
                _db.AddToSecrets(secret);
                _db.SaveChanges();
                return PartialView(secret);
            }

            ModelState.AddModelError("secretImage", "Вы не указали файл с изображением");
            return PartialView();
        }

        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult MakeThumbnail(int id)
        {
            var secret = _db.Secrets.First(s => s.Id == id);
            return PartialView(secret);
        }

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public void MakeThumbnail(int x, int y, int id)
        {
            var secret = _db.Secrets.First(s => s.Id == id);
            var sourceFile = Bitmap.FromFile(IOHelper.CreateAbsolutePath("~/Content/secret", secret.FileName));
            var bitmap = new Bitmap(180, 180);
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(sourceFile, new Rectangle(0, 0, 180, 180), new Rectangle(x, y, 180, 180),
                               GraphicsUnit.Pixel);
            bitmap.Save(IOHelper.CreateAbsolutePath("~/Content/secret/preview", secret.FileName));

            //return  //(true, "application/json");
        }

        public JsonResult Delete(int id)
        {
            var secret = _db.Secrets.First(s => s.Id == id);
            _db.DeleteObject(secret);
            return Json(true);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}