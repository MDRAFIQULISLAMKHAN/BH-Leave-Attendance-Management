using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TW.BusinessLayer;
using TW.Models;
using Vereyon.Web;

namespace TwAdmin.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult Index()
        {
            AdminViewModel av = new AdminViewModel();
            av.ClientList = ClientManager.GetAllClients();
            return View(av);
        }

        public ActionResult InsertClient()
        {
            AdminViewModel av = new AdminViewModel();
            av.Clients = new OurClient();
            return View(av);
        }

        public ActionResult UpdateClient(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.Clients = ClientManager.GetClientById(Id);
                if (av.Clients != null)
                {
                    return View("~/Views/Clients/InsertClient.cshtml", av);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClient(long Id)
        {
            ClientManager.DeleteClient(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult InsertClient(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.Clients != null && av.Clients.Id > 0)
            {
                if (av.File != null)
                {
                    _UploadSingleImage(av, image);
                }

                av.Clients.IsActive = true;
                av.Clients.CreatedBy = "Admin";
                av.Clients.CreatedDate = DateTime.Now;
                ClientManager.UpdateClient(av.Clients);
            }
            else
            {
                if (av.File != null)
                {
                    _UploadSingleImage(av, image);
                    av.Clients.IsActive = true;
                    av.Clients.CreatedBy = "Admin";
                    av.Clients.CreatedDate = DateTime.Now;
                    ClientManager.InsertClient(av.Clients);
                }
                else
                {
                    FlashMessage.Danger("Image Required");
                    return View(av);
                }
            }

            return RedirectToAction("Index");
        }

        private void _UploadImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            foreach (var file in adminVwModel.Files.Take(1))
            {
                string pathUrl = "";

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
                    adminVwModel.Clients.ImageUrl = pathUrl;
                }
            }
        }

        private void _UploadSingleImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
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
            adminVwModel.Clients.ImageUrl = pathUrl;
        }

    }
}