using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Newtonsoft.Json;
using TW.Models;
using Vereyon.Web;

namespace TwWeb.Controllers
{
    public class HomeController : Controller
    {





        /*public ActionResult Index()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            publicViewModel.OurClients = ClientManager.GetAllClients();
            publicViewModel.Banners = HomeManager.GetAllBanners();
            publicViewModel.OurMachines = MachineManager.GetAllMachines();
            publicViewModel.ProjectCategories = CategoryManager.GetAllProjectCategory();
            return View(publicViewModel);
        }

        public ActionResult About()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            publicViewModel.OurClients = ClientManager.GetAllClients();
            publicViewModel.AboutUs = HomeManager.GetAboutUs(1);
            return View(publicViewModel);
        }

        public ActionResult ProductCategory()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            publicViewModel.ProjectCategories = CategoryManager.GetAllProjectCategory();
            if (publicViewModel.ProjectCategories.Any() && publicViewModel.ProjectCategories.Count > 0)
            {
                return View(publicViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult SubCategory(long id = 0)
        {
            PublicViewModel pv = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                pv.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                pv.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            if (id > 0)
            {
                pv.ProjectSubCategories = CategoryManager.GetSubCategoryByCategoryId(id);
                pv.ProjectCategory = CategoryManager.GetProjectCategoryById(id);
                return View(pv);
            }
            return RedirectToAction("ProductCategory");
        }

        public ActionResult Products(long id = 0)
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                if (id == 0)
                {
                    publicViewModel.Projects = ProjectManager.GetAllProject();
                }
                else
                {
                    publicViewModel.Projects = CategoryManager.GetAllProjectsBySubCategoryId(id);
                }

                publicViewModel.ProjectSubCategory = CategoryManager.GetProjectSubCategoryById(id);
                return View(publicViewModel);
            }

            return RedirectToAction("ProductCategory");
        }

        public ActionResult ProductDetails(long? id)
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                publicViewModel.Project = ProjectManager.GetProjectById(id);
                if (publicViewModel.Project != null)
                {
                    return View(publicViewModel);
                }
            }

            return RedirectToAction("ProductCategory");
        }

        public ActionResult Gallery(int id)
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            publicViewModel.ProjectGalleries = ProjectManager.GetAllProjectGalleriesByProjectId(id);
            publicViewModel.Project = ProjectManager.GetProjectById(id);
            return View(publicViewModel);
        }

        public ActionResult Contact()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            return View(publicViewModel);
        }

        public ActionResult Clients()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
                publicViewModel.ClientsBanner = HomeManager.GetClientsBanner(1);
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);

            }

            return View(publicViewModel);
        }

        [HttpPost]
        public ActionResult Contact(PublicViewModel pv)
        {

            if (Session["CompanySetting"] != null)
            {
                pv.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                pv.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            var jsonString = JsonConvert.SerializeObject(pv.Feedback);
            pv.Feedback = JsonConvert.DeserializeObject<Feedback>(jsonString);
            FeedbackManager.InsertFeedback(pv.Feedback);

            try
            {
                string body = string.Empty;
                body += "Hi Team,";
                body += "<br/> This is from ByteHeart Contact us enquiry:";
                body += "<br/>Name: " + pv.Feedback.Name;
                body += "<br/>Email: " + pv.Feedback.Email;
                body += "<br/>Subject: " + pv.Feedback.Subject;
                body += "<br/>Message: " + pv.Feedback.Message;
                body += "<br/> Date: " + DateTime.Now.ToString("dd MMM yyyy");

                bool hasWords = HasBadWords(pv.Feedback.Message);

                if (hasWords == false)
                {
                    SendEmailFromGoDaddy("MazedaMart contact us inquiry", body, "hello@thebyteheart.com", "robin.byteheart@gmail.com", "robineasin@gmail.com", true,
                        "hello@thebyteheart.com", "He11o@S1tec0re");
                }
                
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div class=\"alert alert-success\" id=\"contactSuccess\">");
                sb.AppendFormat("<strong>Success!</strong> Your message has been sent to us.");
                sb.AppendFormat("</div>");
                pv.EmailStatus = sb.ToString();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div class=\"alert alert-success\" id=\"contactSuccess\">");
                sb.AppendFormat(" <strong>Error!</strong> There was an error sending your message.{0} - {1}", ex.Message, ex.InnerException?.Message);
                sb.AppendFormat("<span class=\"font-size-xs mt-sm display-block\" id=\"mailErrorMessage\"></span>");
                sb.AppendFormat("</div>");
                pv.EmailStatus = sb.ToString();
            }

            return View(pv);
        }

        public bool HasBadWords(string inputWords)
        {
            Regex wordFilter = new Regex("(eаrn mоnеy оnlinе|mystrikingly|makemoney|earnmoney|sеx|adult|fucк|dating|woman|girls)");
            return wordFilter.IsMatch(inputWords.ToLower());
        }

        private string SendEmailFromGoDaddy(string subject, string body, string sender, string recipient, string bcc, bool isHTML, string smtpUsername, string smtpPassword)
        {
            string msg = null;

            try
            {
                MailMessage mailMsg = new MailMessage(sender, recipient);
                mailMsg.Bcc.Add(bcc);
                mailMsg.Subject = subject;
                mailMsg.Body = body;
                mailMsg.IsBodyHtml = isHTML;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtpout.asia.secureserver.net";
                smtp.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
                smtp.Port = 80;
                smtp.EnableSsl = false;
                smtp.Send(mailMsg);
            }

            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;   // If msg == null then the e-mail was sent without errors
        }*/
    }
}