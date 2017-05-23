using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom_1._1.Controllers
{
    public class EditScheduleController : Controller
    {
        MyContext db = new MyContext();

        // GET: EditSchedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}