using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TW.BusinessLayer;
using TW.Models;

namespace TwAdmin.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult CompanySettings(AdminViewModel av, long Id = 1)
        {
            av.CompanySetting = CompanySettingsManager.GetCompanySettings(Id);
            return View(av);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateCompanySettings(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.File != null)
            {
                av.CompanySetting.LogoUrl = _UploadSingleImage(av, image);
            }
            if (av.OwnerImage.File != null)
            {
                av.CompanySetting.ImgUrl = _UploadSingleImg(av, image);
            }
            CompanySettingsManager.UpdateSettings(av.CompanySetting);
            return RedirectToAction("CompanySettings");
        }

        private string _UploadSingleImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = adminVwModel.File;
            string pathUrl = "";
            string savepath, savefile;
            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Images/");
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            savefile = Path.Combine(savepath, filename);
            file.SaveAs(savefile);
            pathUrl = "/img/Images/" + filename;
            return pathUrl;
        }

        private string _UploadSingleImg(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = adminVwModel.OwnerImage.File;
            string pathUrl = "";
            string savepath, savefile;
            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Images/");
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            savefile = Path.Combine(savepath, filename);
            file.SaveAs(savefile);
            pathUrl = "/img/Images/" + filename;
            return pathUrl;
        }
    }
}