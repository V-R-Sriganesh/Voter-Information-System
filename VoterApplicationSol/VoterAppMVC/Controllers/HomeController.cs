using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoterDAL;

namespace VoterAppMVC.Controllers
{
    public class HomeController : Controller
    {
        VoterRepository Repo = new VoterRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(FormCollection loginform)
        {
            string emailid = loginform["txtEmailId"];
            string password = loginform["txtPassword"];

            adminuser user = Repo.validateAdmin(emailid, password);

            if(user == null)
            {
                ViewBag.ErrorMsg = "Invalid credentials, please try again";
                return View("Index");
            }
            else
            {
                Session["EmailID"] = emailid;
                Session["AdminId"] = user.id;

                return RedirectToAction("Index", "voter");
            }

        }

    }
}