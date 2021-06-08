using System.Web.Mvc;
using TW.BusinessLayer;
using TW.Models;

namespace TwAdmin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            AdminViewModel av = new AdminViewModel();
            av.FeedbackList = FeedbackManager.GetAllFeedback();
            return View(av);
        }

        public ActionResult DeleteFeedback(long Id)
        {
            FeedbackManager.DeleteFeedback(Id);
            return RedirectToAction("Index");
        }
    }
}