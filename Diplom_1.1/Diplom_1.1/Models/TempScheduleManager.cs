using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;
using Diplom_1._1.ViewModels;

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

            AddScheduleViewModel MyModel = new AddScheduleViewModel
            {
                ChosenGroup = TempList[0].group,
                StartDate = TempList[0].StartDate,
                EndDate = TempList[0].EndDate,
                AddedLessons = TempList,
                AllGroups = groups,
                filled = false
                
            };

            return MyModel;
        }
    }
}