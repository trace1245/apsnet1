﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom_1._1.ViewModels;
using Diplom_1._1.Models;
using Diplom.Models;

namespace Diplom_1._1.Controllers
{
    public class AddScheduleController : Controller
    {
        MyContext db = new MyContext();

        // GET: AddSchedule
        [HttpGet]
        public ActionResult Index()
        {
            SelectList groups = new SelectList(db.Groups, "Id", "Name");
            ViewBag.Groups = groups;
            AddScheduleViewModel model = TempScheduleManager.GetTempInfo(db);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AddScheduleViewModel FilledMTempModel)
        {
            AddScheduleViewModel model = TempScheduleManager.FixateChange(db, FilledMTempModel);
            return View(model);
        }

        [HttpGet]
        public ViewResult AddLessonForm(int day, DateTime date)
        {
            ViewBag.Day = day;
            ViewBag.Date = date;
            return View();
        }

        [HttpPost]
        public ActionResult AddLessonForm(AddLessonFormViewModel model)
        {
            TempScheduleManager.AddTempSchedule(db, model);
            return RedirectToAction("Index", "AddSchedule");

            //return model.FineDate.ToString() + " " + model.Lesson.name + " " + model.Lesson.time;
        }

        public ActionResult Add()
        {
            TempScheduleManager.AddPermSchedule(db);
            return RedirectToAction("Index", "Home");
        }

        //TODO форма, добавляющая созданное расписание в бд 
    }
}