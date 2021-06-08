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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(AdminViewModel av, long Id = 1)
        {
            av.AboutUs = HomeManager.GetAboutUs(Id);
            return View(av);
        }

        public ActionResult ClientsBanner(AdminViewModel av, long Id = 1)
        {
            av.ClientsBanner = HomeManager.GetClientsBanner(Id);
            return View(av);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateAbout(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.File != null)
            {
                av.ClientsBanner.ImageUrl = _UploadSingleImage(av, image);
            }

            av.AboutUs.CreatedBy = "Admin";
            av.AboutUs.CreatedDate = DateTime.Now;
            HomeManager.UpdateAbout(av.AboutUs);
            return RedirectToAction("About");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateOurClientsBanner(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.File != null)
            {
                av.ClientsBanner.ImageUrl = _UploadSingleImage(av, image);
            }

            av.ClientsBanner.CreatedBy = "Admin";
            av.ClientsBanner.CreatedDate = DateTime.Now;
            HomeManager.UpdateClientsBanner(av.ClientsBanner);
            return RedirectToAction("ClientsBanner");
        }

        public ActionResult Banner()
        {
            List<Banner> allBanners = HomeManager.GetAllBanners();
            return View(allBanners);
        }

        public ActionResult InsertBanner()
        {
            AdminViewModel av = new AdminViewModel();
            av.Banner = new Banner();
            return View(av);
        }

        public ActionResult UpdateBanner(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.Banner = HomeManager.GetBannerDetails(Id);
                if (av.Banner != null)
                {
                    return View("~/Views/Home/InsertBanner.cshtml", av);
                }
            }
            return RedirectToAction("Banner");
        }

        public ActionResult DeleteBanner(long Id)
        {
            HomeManager.DeleteBanner(Id);
            return RedirectToAction("Banner");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertBanner(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.Banner != null && av.Banner.Id > 0)
            {
                if (av.File != null)
                {
                    av.Banner.ImageUrl = _UploadSingleImage(av, image);
                }
                if (av.SliderBgImgUrl.File != null)
                {
                    av.Banner.SliderBgImgUrl = _UploadSliderImg(av, image);
                }

                av.Banner.IsActive = true;
                av.Banner.CreatedBy = "Admin";
                av.Banner.CreatedDate = DateTime.Now;
                HomeManager.UpdateBanner(av.Banner);
            }
            else
            {
                if (av.Banner != null)
                {
                    if (av.File != null)
                    {
                        av.Banner.ImageUrl = _UploadSingleImage(av, image);
                        av.Banner.SliderBgImgUrl = _UploadSliderImg(av, image);
                    }

                    

                    av.Banner.IsActive = true;
                    av.Banner.CreatedBy = "Admin";
                    av.Banner.CreatedDate = DateTime.Now;
                    HomeManager.InsertBanner(av.Banner);
                }
            }

            return RedirectToAction("Banner");
        }

        private string _UploadImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            string pathUrl = "";
            foreach (var file in adminVwModel.Files.Take(1))
            {
                

                if (file.ContentLength > 0)
                {
                    string savepath, savefile;
                    var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                    savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Images/");
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);
                    savefile = Path.Combine(savepath, filename);
                    file.SaveAs(savefile);
                    pathUrl = "/img/Images/" + filename;
                }
            }
            return pathUrl;
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

        private string _UploadSliderImg(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = adminVwModel.SliderBgImgUrl.File;
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