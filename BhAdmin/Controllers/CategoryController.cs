using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BH.Models;
using Vereyon.Web;

namespace TwAdmin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Categories()
        {
            AdminViewModel av = new AdminViewModel();
            av.ProjectCategoryList = CategoryManager.GetAllProjectCategory();
            return View(av);
        }

        public ActionResult InsertCategory()
        {
            AdminViewModel av = new AdminViewModel();
            av.ProjectCategory = new ProjectCategory();
            return View(av);
        }

        public ActionResult UpdateCategory(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.ProjectCategory = CategoryManager.GetProjectCategoryById(Id);
                if (av.ProjectCategory != null)
                {
                    return View("~/Views/Category/InsertCategory.cshtml", av);
                }
            }

            return RedirectToAction("Categories");
        }

        public ActionResult DeleteCategory(long Id)
        {
            CategoryManager.DeleteProjectCategory(Id);
            return RedirectToAction("Categories");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertCategory(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.ProjectCategory != null && av.ProjectCategory.Id > 0)
            {
                if (av.File != null)
                {
                    av.Service.ImageUrl = _UploadSingleImage(av, image);
                }
                av.ProjectCategory.IsActive = true;
                av.ProjectCategory.CreatedDate = DateTime.Today;
                av.ProjectCategory.CreatedBy = "Admin";
                CategoryManager.UpdateProjectCategory(av.ProjectCategory);
            }
            else
            {
                if (av.ProjectCategory != null)
                {
                    if (av.File != null)
                    {
                        av.ProjectCategory.ImageUrl = _UploadSingleImage(av, image);
                        av.ProjectCategory.IsActive = true;
                        av.ProjectCategory.CreatedDate = DateTime.Today;
                        av.ProjectCategory.CreatedBy = "Admin";
                        CategoryManager.InsertProjectCategory(av.ProjectCategory);
                    }
                    else
                    {
                        FlashMessage.Danger("Image Required");
                        return View(av);
                    }
                }
            }

            return RedirectToAction("Categories");
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