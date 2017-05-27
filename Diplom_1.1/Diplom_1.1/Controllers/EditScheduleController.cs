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
    public class EditScheduleController : Controller
    {
        MyContext db = new MyContext();

        // GET: EditSchedule
        [HttpGet]
        public ActionResult Index()
        {
            SelectList groups = new SelectList(db.Groups, "Id", "Name");
            ViewBag.Groups = groups;
            EditScheduleChoseGroupViewModel model = new EditScheduleChoseGroupViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(EditScheduleChoseGroupViewModel model)
        {
            return View(EditScheduleManager.GetSchedule(db, model));
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    SelectList groups = new SelectList(db.Groups, "Id", "Name");
        //    ViewBag.Groups = groups;
        //    AddScheduleViewModel model = TempScheduleManager.GetTempInfo(db);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Index(AddScheduleViewModel FilledMTempModel)
        //{
        //    AddScheduleViewModel model = TempScheduleManager.FixateChange(db, FilledMTempModel);
        //    return View(model);
        //}
    }
}