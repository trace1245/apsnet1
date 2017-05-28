using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom_1._1.ViewModels;
using Diplom_1._1.Models;
using Diplom.Models;

namespace Diplom_1._1.Controllers
{
    public class ProfRegisterController : Controller
    {
        MyContext db = new MyContext();

        // GET: ProfRegister
        [HttpGet]
        public ActionResult Index()
        {
            List<ProfEmails> l = new List<ProfEmails>();
            foreach(ProfEmails p in db.Profs)
            {
                l.Add(p);
            }
            ProfRegisterViewModel model = new ProfRegisterViewModel
            {
                profs = l
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProfRegisterViewModel model)
        {
            db.Profs.Add(new ProfEmails
            {
                ProfEmail = model.NewProfEmail,
                Name = model.NewProfName
            });
            db.SaveChanges();
            List<ProfEmails> l = new List<ProfEmails>();
            foreach(ProfEmails p in db.Profs)
            {
                l.Add(p);
            }
            model = new ProfRegisterViewModel
            {
                profs = l
            };
            return View(model);
        }
    }
}