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
    public class MachinesController : Controller
    {
        // GET: Machines
        public ActionResult Index()
        {
            AdminViewModel av = new AdminViewModel();
            av.MachineList = MachineManager.GetAllMachines();
            return View(av);
        }

        public ActionResult InsertMachines()
        {
            AdminViewModel av = new AdminViewModel();
            av.Machines = new OurMachine();
            return View(av);
        }

        public ActionResult UpdateMachine(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.Machines = MachineManager.GetMachineById(Id);
                if (av.Machines != null)
                {
                    return View("~/Views/Machines/InsertMachines.cshtml", av);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteMachine(long Id)
        {
            MachineManager.DeleteMachine(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertMachines(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.Machines != null && av.Machines.Id > 0)
            {
                if (av.File != null)
                {
                    _UploadSingleImage(av, image);
                }

                av.Machines.IsActive = true;
                av.Machines.CreatedBy = "Admin";
                av.Machines.CreatedDate = DateTime.Now;
                MachineManager.UpdateMachine(av.Machines);
            }
            else
            {
                if (av.File != null)
                {
                    _UploadSingleImage(av, image);
                    av.Machines.IsActive = true;
                    av.Machines.CreatedBy = "Admin";
                    av.Machines.CreatedDate = DateTime.Now;
                    MachineManager.InsertMachine(av.Machines);
                }
                else
                {
                    FlashMessage.Danger("Image Required");
                    return View(av);
                }
            }

            return RedirectToAction("Index");
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
            adminVwModel.Machines.ImageUrl = pathUrl;
        }
    }
}