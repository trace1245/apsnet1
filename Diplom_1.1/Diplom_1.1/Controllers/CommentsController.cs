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
    public class CommentsController : Controller
    {
        MyContext db = new MyContext();

        // GET: Comments
        [HttpGet]
        public ActionResult Index()
        {
            SelectList groups = new SelectList(db.Groups, "Id", "Name");
            ViewBag.Groups = groups;
            List<SelectListItem> list = new List<SelectListItem>() {
                new SelectListItem(){ Value="1", Text="Відправити студентам"},
                new SelectListItem(){ Value="2", Text="Відправити викладачам"},
                new SelectListItem(){ Value="3", Text="Відправити всім"}
            };

            ViewBag.Who = list;

            CommentViewModel model = new CommentViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CommentViewModel model)
        {
            SelectList groups = new SelectList(db.Groups, "Id", "Name");
            ViewBag.Groups = groups;
            List<SelectListItem> list = new List<SelectListItem>() {
                new SelectListItem(){ Value="1", Text="Відправити студентам"},
                new SelectListItem(){ Value="2", Text="Відправити викладачам"},
                new SelectListItem(){ Value="3", Text="Відправити всім"}
            };

            ViewBag.Who = list;
            AndroidGCMPushNotification.SendNotification(db, model);
            model.IsSent = true;
            return View(model);
        }
    }
}