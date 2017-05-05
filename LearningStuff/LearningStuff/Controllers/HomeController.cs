using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningStuff.Models;

namespace LearningStuff.Controllers
{
    public class HomeController : Controller
    {
        private List<Table> Tables = new List<Table> {
            new Table {id = "1", time = "08:30", name = "Теория теоретических теорий", group = "kn-13", prof = "Препод 1", room = "202"},
            new Table {id = "2", time = "099:30", name = "Para 2", group = "kn-14", prof = "Препод 2", room = "242"},
            new Table {id = "3", time = "18:30", name = "Теория теорий", group = "kn-13", prof = "Препод 3", room = "203"},
            new Table {id = "4", time = "06:30", name = "теорий нет", group = "kn-18", prof = "Препод препод", room = "102"}
        };


        // GET: Home
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            //ViewBag.Greeting = hour < 12 ? "Доброе утро" : "Доброго дня";
            //ViewBag.Hello = 10;
            return View();
        }

        [HttpPost]
        public JsonResult Index(string req)
        {
            return Json(Tables);
        }

        //[HttpGet]
        //public ViewResult RspvForm()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ViewResult RspvForm(GuestResponse guest)
        //{
        //    if(ModelState.IsValid)
        //        return View("Thanks", guest);
        //    else
        //        return View();
        //}
    }
}