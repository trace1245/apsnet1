using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom_1._1.ViewModels;
using Diplom_1._1.Models;
using Diplom.Models;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        MyContext db = new MyContext();

        // GET: Home
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public JsonResult Index(params string[] args)
        {
            if(args[0] == "GetSchedule")//Post: String “GetSchedule” String ”Group” String "StartDate" String "EndDate"
            {                           //StartDate(EndDate)  -   dd-MM-yyyy
                return Json(PostResponse.GetSchedule(db, args[1], args[2], args[3]), JsonRequestBehavior.AllowGet);
            }
            else if(args[0] == "GetComments")// Post: String “GetComments” String ”Group” String "StartDate" String "EndDate"
            {
                return Json(PostResponse.GetComments(db, args[1], args[2], args[3]), JsonRequestBehavior.AllowGet);
            }
            else if(args[0] == "Check")//Post: string “Check” string “Email” string “Password” // return bool // проверка на существование такого преподавателя
            {
                IEnumerable<ProfEmails> profs = db.Profs;
                return Json(PostResponse.Check(db, args[1], args[2]), JsonRequestBehavior.AllowGet);
            }
            else if(args[0] == "Register")//Post: string “Register” string “Prof” string “Email” string “Password” string “Id”
            {                               //Post: string “Register” string “Student” string “Group” string “Id”
                if(args[1] == "Prof")
                    return Json(PostResponse.Register(db, args[1], args[2], args[3], args[4]), JsonRequestBehavior.AllowGet);
                else
                    return Json(PostResponse.Register(db, args[1], args[2], args[3]), JsonRequestBehavior.AllowGet);

            }
            else if(args[0] == "AddComment")// Post: String “AddComment” String “LessonId” String “Message” String "Name"
            {
                return Json(PostResponse.AddComment(db, args[1], args[2], args[3]), JsonRequestBehavior.AllowGet);
            }
            else if(args[0] == "GetRooms")
            {
                return Json(PostResponse.GetRooms(db), JsonRequestBehavior.AllowGet);
            }
            else if(args[0] == "GetGroups")
            {
                return Json(PostResponse.GetGroups(db), JsonRequestBehavior.AllowGet);
            }
            else if(args[0] == "GetLectors")
            {
                return Json(PostResponse.GetLectors(db), JsonRequestBehavior.AllowGet);
            }
            else if(args[0] == "GetGRL")
            {
                return Json(PostResponse.GetGRL(db), JsonRequestBehavior.AllowGet);
            }
            return Json(new { State = "false", Info = "wrong arguments" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(model.Login == "admin" && model.Password == "123" )
            return RedirectToAction("Index", "AddSchedule");
            else
                return RedirectToAction("Index", "Home");
        }
    }
}