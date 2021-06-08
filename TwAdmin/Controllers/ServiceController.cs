using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TW.BusinessLayer;
using TW.Models;
using Vereyon.Web;

namespace TwAdmin.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Services()
        {
            AdminViewModel av = new AdminViewModel();
            av.ServiceList = ServiceManager.GetAllService();
            return View(av);
        }

        public ActionResult InsertService()
        {
            AdminViewModel av = new AdminViewModel();
            av.Service = new OurService();
            return View(av);
        }

        public ActionResult UpdateService(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.Service = ServiceManager.GetServiceById(Id);
                if (av.Service != null)
                {
                    return View("~/Views/Service/InsertService.cshtml", av);
                }
            }

            return RedirectToAction("Services");
        }

        public ActionResult DeleteService(long Id)
        {
            ServiceManager.DeleteService(Id);
            return RedirectToAction("Services");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertService(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.Service != null && av.Service.Id > 0)
            {
                if (av.File != null)
                {
                    av.Service.ImageUrl = _UploadSingleImage(av, image);
                }
                av.Service.IsActive = true;
                av.Service.CreatedDate = DateTime.Today;
                av.Service.CreatedBy = "Admin";
                ServiceManager.UpdateService(av.Service);
            }
            else
            {
                if (av.Service != null)
                {
                    if (av.File != null)
                    {
                        av.Service.ImageUrl = _UploadSingleImage(av, image);
                        av.Service.IsActive = true;
                        av.Service.CreatedDate = DateTime.Today;
                        av.Service.CreatedBy = "Admin";
                        ServiceManager.InsertService(av.Service);
                    }
                    else
                    {
                        FlashMessage.Danger("Image Required");
                        return View(av);
                    }
                }
            }

            return RedirectToAction("Services");
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
    }
}