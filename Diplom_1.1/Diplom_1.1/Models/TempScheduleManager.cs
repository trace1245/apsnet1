﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;
using Diplom_1._1.ViewModels;
using System.Web.Mvc;

namespace Diplom_1._1.Models
{
    public class TempScheduleManager//отвечает за работу с бд для модуля добавления расписаний
    {
        public static AddScheduleViewModel GetTempInfo(MyContext db)
        {
            List<TemporaryAddedLessons> TempList = new List<TemporaryAddedLessons>();
            List<Group> groups = new List<Group>();
            foreach(TemporaryAddedLessons t in db.TLessons)
            {
                TempList.Add(t);
            }
            foreach(Group g in db.Groups)
            {
                groups.Add(g);
            }
            bool fil = false;
            if(TempList[0].group != null)
            {
                fil = true;
            }

            AddScheduleViewModel MyModel = new AddScheduleViewModel
            {
                ChosenGroup = TempList[0].group,
                StartDate = TempList[0].StartDate,
                EndDate = TempList[0].EndDate,
                AddedLessons = TempList,
                AllGroups = groups,
                filled = fil
                
            };

            return MyModel;
        }
        public static AddScheduleViewModel FixateChange(MyContext db, AddScheduleViewModel model)
        {
            var result = db.TLessons.SingleOrDefault((b => b.id == 1));
            SelectList ListGroups = new SelectList(db.Groups, "Id", "Name");
            foreach(SelectListItem i in ListGroups)
            {
                if(i.Value == model.ChosenGroup)
                {
                    result.group = i.Text;
                }

            }
            result.StartDate = model.StartDate;
            result.EndDate = model.EndDate;
            db.SaveChanges();

            List<TemporaryAddedLessons> TempList = new List<TemporaryAddedLessons>();
            List<Group> groups = new List<Group>();
            foreach(TemporaryAddedLessons t in db.TLessons)
            {
                TempList.Add(t);
            }
            foreach(Group g in db.Groups)
            {
                groups.Add(g);
            }

            return new AddScheduleViewModel
            {
                ChosenGroup = TempList[0].group,
                StartDate = TempList[0].StartDate,
                EndDate = TempList[0].EndDate,
                AddedLessons = TempList,
                AllGroups = groups,
                filled = true
            };
        }
        public static void AddTempSchedule(MyContext db, AddLessonFormViewModel model)
        {
            DateTime time = model.FineDate;
            TimeSpan hours = model.Lesson.time.TimeOfDay;
            time = time.Add(hours);
            var result = db.TLessons.SingleOrDefault((b => b.id == 1));

            db.TLessons.Add(new TemporaryAddedLessons
            {
                time = time,
                name = model.Lesson.name,
                group = result.group,
                prof = model.Lesson.prof,
                room = model.Lesson.room,
                StartDate = result.StartDate,
                EndDate = result.EndDate
            });

                db.SaveChanges();
            result = db.TLessons.SingleOrDefault((b => b.id == 2));

        }
        public static void AddPermSchedule(MyContext db)
        {
            foreach(TemporaryAddedLessons lesson in db.TLessons)
            {
                if(lesson.id == 1)
                    continue;
                db.Schedule.Add(new Schedule
                {
                    time = lesson.time,
                    name = lesson.name,
                    group = lesson.group,
                    prof = lesson.prof,
                    room = lesson.room
                });
            }
        }
    }
}