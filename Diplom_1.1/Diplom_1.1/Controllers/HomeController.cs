using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        MyContext db = new MyContext();

        // GET: Home
        public ActionResult Index()
        {
            //db.Clients.Add(new ClientId {Group = "KN-14", PhoneId = "qwerty1234", IsProf = false });
            //db.SaveChanges();

            // получаем из бд все объекты 
            IEnumerable<ClientId> clients = db.Clients;
            // передаем все полученный объекты в ViewBag
            ViewBag.Clients = clients;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public JsonResult Indexx(params string[] args)
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
            else if(args[0] == "GetLessons")
            {
                return Json(PostResponse.GetLessons(db), JsonRequestBehavior.AllowGet);
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
            return Json(new { State = "false", Info = "wrong arguments" }, JsonRequestBehavior.AllowGet);
        }
    }
}