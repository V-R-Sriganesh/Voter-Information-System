using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoterDAL;

namespace VoterAppMVC.Controllers
{
    public class voterController : Controller
    {
        VoterRepository Repo = new VoterRepository();
        // GET: voter
        
        public ActionResult Index()
        {
            if(Session["EmailId"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            List<VoterDAL.voter> dalvoterList = Repo.getVoterList();

            List<Models.Voter> mvcvoterList = new List<Models.Voter>();

            foreach (VoterDAL.voter dal_vobj in dalvoterList)
            {
                Models.Voter mvc_vobj = new Models.Voter();
                mvc_vobj.voterid = dal_vobj.voterid;
                mvc_vobj.votername = dal_vobj.votername;
                mvc_vobj.vaddress = dal_vobj.vaddress;

                mvcvoterList.Add(mvc_vobj);
            }
            return View(mvcvoterList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Voter mvc_vobj)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                VoterDAL.voter dal_vobj =new VoterDAL.voter();
                dal_vobj.voterid = mvc_vobj.voterid;
                dal_vobj.votername = mvc_vobj.votername;
                dal_vobj.vaddress = mvc_vobj.vaddress;

                bool result = Repo.addVoter(dal_vobj);

                if (!result)
                {
                    return View("Error");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            VoterDAL.voter dal_vobj = Repo.searchVoter(id);

            Models.Voter mvc_vobj = new Models.Voter();

            mvc_vobj.voterid = dal_vobj.voterid;
            mvc_vobj.votername = dal_vobj.votername;
            mvc_vobj.vaddress = dal_vobj.vaddress;

            return View(mvc_vobj);
        }

        [HttpPost]
        public ActionResult Edit(Models.Voter mvc_vobj)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            VoterDAL.voter dal_vobj = new VoterDAL.voter();
            dal_vobj.voterid = mvc_vobj.voterid;
            dal_vobj.votername = mvc_vobj.votername;
            dal_vobj.vaddress = mvc_vobj.vaddress;

            bool result = Repo.updateVoter(dal_vobj);

            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            VoterDAL.voter dal_vobj = Repo.searchVoter(id);

            Models.Voter mvc_vobj = new Models.Voter();
            mvc_vobj.voterid = dal_vobj.voterid;
            mvc_vobj.votername = dal_vobj.votername;
            mvc_vobj.vaddress = dal_vobj.vaddress;

            return View(mvc_vobj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            bool result = Repo.deleteVoter(id);
            if (result == false)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            VoterDAL.voter dal_vobj = Repo.searchVoter(id);

            Models.Voter mvc_vboj = new Models.Voter();
            mvc_vboj.voterid = dal_vobj.voterid;
            mvc_vboj.votername = dal_vobj.votername;
            mvc_vboj.vaddress = dal_vobj.vaddress;

            return View(mvc_vboj);

        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}