using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using BH.Models;

namespace TwAdmin.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            AdminViewModel av = new AdminViewModel();
            av.ProjectList = ProjectManager.GetAllProject();
            return View(av);
        }

        public ActionResult Create()
        {
            AdminViewModel av = new AdminViewModel();
            av.Project = new Project();
            _loadProjects();
            return View(av);
        }

        public ActionResult GalleryList(int Id)
        {
            if (Id != 0)
            {
                ViewBag.ProjectId = Id;
                AdminViewModel av = new AdminViewModel();
                av.ProjectGalleryList = ProjectManager.GetProjectGalleryById(Id);
                return View(av);
            }

            return View("Index");
        }

        public ActionResult CreateGallery(long Id)
        {
            AdminViewModel av = new AdminViewModel();
            ProjectGallery gallery = new ProjectGallery
            {
                ProjectId = Id
            };
            av.ProjectGallery = gallery;
            return View(av);
        }

        public ActionResult DeleteGalleryItem(long Id)
        {
            ProjectManager.DeleteProjectGallery(Id);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProject(int Id)
        {
            if (Id > 0)
            {
                AdminViewModel av = new AdminViewModel();
                av.ProjectGallery = ProjectManager.GetGalleryById(Id);
                if (av.ProjectGallery != null)
                {
                    return View("~/Views/Projects/UpdateGalleryItem.cshtml", av);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetProjectImgById(long Id)
        {
            if (Id > 0)
            {
                _loadProjects();
                AdminViewModel av = new AdminViewModel();
                av.Project = ProjectManager.GetProjectById(Id);
                if (av.Project != null)
                {
                    return View("~/Views/Projects/UpdateProject.cshtml", av);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(long Id)
        {
            ProjectManager.DeleteProject(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(AdminViewModel av, HttpPostedFileBase image)
        {
            av.Project.ImageUrl = _UploadSingleImage(av, image);
            av.Project.IsActive = true;
            av.Project.CreatedBy = "Admin";
            av.Project.CreatedDate = DateTime.Today;
            av.Project.ImageUrl = _UploadSingleImage(av, image);

            var projectId = ProjectManager.InsertProject(av.Project);

            if (projectId > 0)
            {
                //av.ProjectCategory.ImageUrl = _UploadSingleImage(av, image);
                //av.ProjectCategory.IsActive = true;
                //var categoryId = ProjectManager.InsertProjectCategory(av.ProjectCategory);

                _Gallery(projectId, av);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProject(AdminViewModel av, long Id, HttpPostedFileBase image)
        {
            av.Project.IsActive = true;
            av.Project.CreatedBy = "Admin";
            av.Project.CreatedDate = DateTime.Today;
            av.Project.ImageUrl = _UploadSingleImage(av, image);

            bool isUpdateProject = ProjectManager.UpdateProject(av.Project);
            bool isUpdateProjectCategoty = CategoryManager.UpdateProjectCategory(av.ProjectCategory);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProjectG(AdminViewModel av)
        {
            av.ProjectGallery.IsActive = true;
            av.ProjectGallery.CreatedBy = "Admin";
            av.ProjectGallery.CreatedDate = DateTime.Today;
           

            bool isUpdateProject = ProjectManager.UpdateProjectGallery(av.ProjectGallery);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateGallery(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av != null)
            {
                foreach (var file in av.Files)
                {
                    if (Request.Url != null)
                    {
                        string pathUrl = "";

                        if (file.ContentLength > 0)
                        {
                            string savepath, savefile;
                            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                            if (!Directory.Exists(savepath))
                                Directory.CreateDirectory(savepath);
                            savefile = Path.Combine(savepath, filename);
                            file.SaveAs(savefile);
                            pathUrl = "/img/Offices/" + filename;
                        }

                        var gallery = new ProjectGallery
                        {
                            ImageUrl = pathUrl,
                            ProjectId = av.ProjectGallery.ProjectId,
                            CreatedBy = "Admin",
                            CreatedDate = DateTime.Now,
                            IsActive = true
                        };
                        var galleryId = ProjectManager.InsertProjectGallery(gallery);
                    }
                }
            }
            return RedirectToAction("GalleryList", new
            {
                Id = av.ProjectGallery.ProjectId
            });
        }

        private void _Gallery(long projectId, AdminViewModel av)
        {
            if (av != null)
            {
                foreach (var file in av.Files)
                {
                    string pathUrl = "";

                    if (file.ContentLength > 0)
                    {
                        string savepath, savefile;
                        var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                        savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                        if (!Directory.Exists(savepath))
                            Directory.CreateDirectory(savepath);
                        savefile = Path.Combine(savepath, filename);
                        file.SaveAs(savefile);
                        pathUrl = "/img/Offices/" + filename;
                    }

                    var gallery = new ProjectGallery
                    {
                        ImageUrl = pathUrl,
                        ProjectId = projectId,
                        IsActive = true, 
                        CreatedBy = "Admin",
                        CreatedDate = DateTime.Now
                    };
                    var galleryId = ProjectManager.InsertProjectGallery(gallery);
                }
            }
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

        public void _loadProjects()
        {
            List<ProjectCategory> dataList = CategoryManager.GetAllProjectCategory();
            ViewBag.CategoryList = new SelectList(dataList, "Id", "Name");
        }

       
    }
}