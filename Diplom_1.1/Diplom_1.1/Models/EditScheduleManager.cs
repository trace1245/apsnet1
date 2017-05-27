using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;
using Diplom_1._1.ViewModels;
using System.Web.Mvc;

namespace Diplom_1._1.Models
{
    public class EditScheduleManager
    {
        public static EditScheduleChoseGroupViewModel GetSchedule(MyContext db, EditScheduleChoseGroupViewModel model)
        {
            List<Schedule> result = new List<Schedule>();

            DateTime StartDate = new DateTime(DateTime.Now.Year, model.ChosenTime, 1);
            DateTime EndDate = new DateTime(DateTime.Now.Year, model.ChosenTime + 1, 1);

            string ChosenGroup = "";
            SelectList ListGroups = new SelectList(db.Groups, "Id", "Name");
            foreach(SelectListItem i in ListGroups)
            {
                if(i.Value == model.ChosenGroup)
                {
                    ChosenGroup = i.Text;
                }

            }

            foreach(Schedule s in db.Schedule)
            {

                if((s.group == ChosenGroup) && (s.time > StartDate && s.time < EndDate))
                {
                    result.Add(s);
                }
            }

            return new EditScheduleChoseGroupViewModel
            {
                ChosenGroup = model.ChosenGroup,
                ChosenTime = model.ChosenTime,
                filled = true,
                schedule = result
            };
        }
        public static void AddDeleteChangeLesson(MyContext db, AddDeleteLessonModel model)
        {
            if(model.Name == null && model.Id != null)
            {
                foreach(Schedule s in db.Schedule)
                {
                    if(s.id == model.Id)
                    {
                        db.Schedule.Remove(s);
                    }
                }
            }
            else if(model.Name != null && model.Id == null)
            {
                db.Schedule.Add(new Schedule
                {
                    time = model.Time.Value,
                    name = model.Name,
                    group = model.Group,
                    prof = model.Prof,
                    room = model.Room
                });
            }
            else if(model.Name != null && model.Id != null)
            {
                var result = db.Schedule.SingleOrDefault(b => b.id == model.Id);
                result.time = model.Time.Value;
                result.name = model.Name;
                result.group = model.Group;
                result.prof = model.Prof;
                result.room = model.Room;
            }
            db.SaveChanges();

        }
    }
}