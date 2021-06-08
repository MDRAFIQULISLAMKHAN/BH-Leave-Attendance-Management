using System.Web.Mvc;
using BH.BusinessLayer;
using BH.Models;
using Vereyon.Web;

namespace BhWeb.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.UserName == null || user.Password == null)
            {
                FlashMessage.Danger("Insert Username or Password");
            }
            else
            {
                var data = UserManager.GetUserByUserNameNPassword(user.UserName.Trim(), user.Password.Trim());
                if (data != null)
                {
                    Session["UserID"] = data.UserId.ToString();
                    Session["UserName"] = data.UserName.ToString();
                    Session["Name"] = "Site Admin";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    FlashMessage.Danger("Username or Password Incorrect");
                }
            }


            return View(user);
         }
    }
}