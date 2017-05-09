using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Diplom.Models
{
    public class PostResponse
    {
        public static List<FormattedSchedule> GetSchedule(IEnumerable<Schedule> schedule, string group, string StartDate, string EndDate)
        {
            List<FormattedSchedule> result = new List<FormattedSchedule>();

            //DateTime start = new DateTime(2017, 5, 1);
            //TimeSpan ts = new TimeSpan(8, 30, 0);
            //start = start.Date + ts;
            string dd, mm, yyyy;
            dd = StartDate[0].ToString() + StartDate[1].ToString();
            mm = StartDate[3].ToString() + StartDate[4].ToString();
            yyyy = StartDate[6].ToString() + StartDate[7].ToString() + StartDate[8].ToString() + StartDate[9].ToString();
            int day = Convert.ToInt32(dd), month = Convert.ToInt32(mm), year = Convert.ToInt32(yyyy);
            DateTime StartDateD = new DateTime(year,month,day);

            dd = EndDate[0].ToString() + EndDate[1].ToString();
            mm = EndDate[3].ToString() + EndDate[4].ToString();
            yyyy = EndDate[6].ToString() + EndDate[7].ToString() + EndDate[8].ToString() + EndDate[9].ToString();
            day = Convert.ToInt32(dd); month = Convert.ToInt32(mm); year = Convert.ToInt32(yyyy);
            DateTime EndDateD = new DateTime(year, month, day);

            foreach(Schedule s in schedule)
            {
                if((s.group == group) && (s.time >= StartDateD && s.time <= EndDateD))
                {
                    string ntime = s.time.ToString();
                    ntime = ntime.Replace('.', '-');
                    ntime = ntime.Replace(':', '-');
                    ntime = ntime.Substring(0, ntime.Length - 3);
                    FormattedSchedule sch = new FormattedSchedule
                    {
                        id = s.id,
                        time = ntime,
                        name = s.name,
                        group = s.group,
                        prof = s.prof,
                        room = s.room,
                        comment = s.comment
                    };
                    result.Add(sch);
                }
            }
            return result;
        }
    }


}