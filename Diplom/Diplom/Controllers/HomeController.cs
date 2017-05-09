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
                IEnumerable <Schedule> schedules= db.Schedule;
                return Json(PostResponse.GetSchedule(schedules, args[1], args[2], args[3]), JsonRequestBehavior.AllowGet);
            }
            return Json("afasdfsd", JsonRequestBehavior.AllowGet);
        }
    }
}