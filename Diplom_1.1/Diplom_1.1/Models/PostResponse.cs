using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Diplom_1._1.Models;

namespace Diplom.Models
{
    public class PostResponse
    {
        public static List<FormattedSchedule> GetSchedule(MyContext db, string arg, string StartDate, string EndDate)
        {
            List<FormattedSchedule> result = new List<FormattedSchedule>();

            DateTime StartDateD = StrToDate(StartDate);
            DateTime EndDateD = StrToDate(EndDate).AddDays(1);

            foreach(Schedule s in db.Schedule)
            {
                string ntime = s.time.ToString("dd-MM-yyyy HH:mm");

                if((s.group == arg) && (s.time > StartDateD && s.time < EndDateD))
                {
                    FormattedSchedule sch = new FormattedSchedule
                    {
                        id = s.id,
                        time = ntime,
                        name = s.name,
                        group = s.group,
                        prof = s.prof,
                        room = s.room
                    };
                    result.Add(sch);
                }
                else if((s.prof == arg) && (s.time >= StartDateD && s.time <= EndDateD))
                {
                    FormattedSchedule sch = new FormattedSchedule
                    {
                        id = s.id,
                        time = ntime,
                        name = s.name,
                        group = s.group,
                        prof = s.prof,
                        room = s.room
                    };
                    result.Add(sch);
                }
                else if((s.room == arg) && (s.time >= StartDateD && s.time <= EndDateD))
                {
                    FormattedSchedule sch = new FormattedSchedule
                    {
                        id = s.id,
                        time = ntime,
                        name = s.name,
                        group = s.group,
                        prof = s.prof,
                        room = s.room
                    };
                    result.Add(sch);
                }
            }
            return result;
        }
        public static List<Comment> GetComments(MyContext db, string arg, string StartDate, string EndDate)
        {
            DateTime StartDateD = StrToDate(StartDate);
            DateTime EndDateD = StrToDate(EndDate);

            List<Comment> coms = new List<Comment>();
            foreach(Schedule s in db.Schedule)
            {
                if((s.group == arg) && (s.time >= StartDateD && s.time <= EndDateD))
                {
                    foreach(Comment c in db.Comments)
                    {
                        if(c.LessonId == s.id)
                        {
                            coms.Add(c);
                        }
                    }
                }
                else if((s.room == arg) && (s.time >= StartDateD && s.time <= EndDateD))
                {
                    foreach(Comment c in db.Comments)
                    {
                        if(c.LessonId == s.id)
                        {
                            coms.Add(c);
                        }
                    }
                }
                else if((s.prof == arg) && (s.time >= StartDateD && s.time <= EndDateD))
                {
                    foreach(Comment c in db.Comments)
                    {
                        if(c.LessonId == s.id)
                        {
                            coms.Add(c);
                        }
                    }
                }
            }

            return coms;
        }
        public static object Check(MyContext db, string email, string pswrd) // возвращает true если логин пароль верный и такой преподаватель зарегестрирован
        {
            foreach(ProfEmails prof in db.Profs)
            {
                if(prof.ProfEmail == email && prof.Password == pswrd)
                    return new { State = "true" };
            }
            return new { State = "false" };
        }
        public static object Register(MyContext db, string who, params string[] args) // для преподавателя - string “Prof” string “Email” string “Password” string “Id”
        {
            if(who == "Prof") //вернуть 3 типа информации – Успешно, Нет преподавателя с таким мэйлом, аккаунт занят 
            {                       

                int id = 1;
                bool noPass = false;
                bool exist = false;
                string pswrd = "nopass432467823467";
                foreach(ProfEmails email in db.Profs)
                {
                    if(args[0] == email.ProfEmail)//TODO повторяющиеся мейлы
                    {
                        exist = true;
                        id = email.Id;
                        if(email.Password == null)//если такая запись не была активирована
                        {
                            noPass = true;
                            break;
                        }
                        else// если был введен правильный пароль
                        {
                            pswrd = email.Password;
                            break;
                        }

                    }
                }
                var result = db.Profs.SingleOrDefault(b => b.Id == id); // достаем нужного лекстора из бд
                if(noPass)
                {
                    
                    if(result != null)
                    {
                        result.Password = args[1];
                        db.SaveChanges();
                    }
                    db.Clients.Add(new ClientId { Group = null, PhoneId = args[2], IsProf = true }); // добавляем Id телефона лектора в список телефонов
                    return new { State = "true", ProfName = result.Name };
                }
                if(exist)// всегда должен быть после if(noPass)
                {
                    if(args[1] == pswrd)
                    {
                        return new { State = "true", ProfName = result.Name };
                    }
                    return new { State = "false", Info = "Prof already registered" };
                }
                return new { State = "false", Info = "Such Email does not exist" };

            }
            if(who == "Student")//Post: string “Register” string “Student” string “Group” string “Id”
            {
                bool exist = false;
                foreach(Group groups in db.Groups)
                {
                    if(args[0] == groups.Name)
                    {
                        exist = true;
                    }
                }
                if(exist)
                {
                    db.Clients.Add(new ClientId { Group = args[0], PhoneId = args[1], IsProf = false });
                    db.SaveChanges();
                    return new { State = "true" };
                }
                return new { State = "false" };
            }
            return new { State = "false", Info = "Wrong 'who' argument. Meant to be 'Student' or 'Prof'" };
        }
        public static object AddComment(MyContext db, string LessonId, string Message, string Name)
        {
            int LesId = Int32.Parse(LessonId);
            bool ok = false;
            foreach(Schedule s in db.Schedule)
            {
                if(s.id == LesId)
                {
                    ok = true;
                }
            }
            if(ok)
            {
                db.Comments.Add(new Comment { Name = Name, LessonId = LesId, Commentary = Message });
                db.SaveChanges();
                return new { State = "true"};
            }
            return new { State = "false", Info = "There is no lesson with such id" };
            }
        public static List<GRL> GetGroups(MyContext db)
        {
            List<GRL> groups = new List<GRL>();
            foreach(Group g in db.Groups)
            {
                groups.Add(g);
            }
            return groups;
        }
        public static List<GRL> GetRooms(MyContext db)
        {
            List<GRL> rooms = new List<GRL>();
            foreach(Room r in db.Rooms)
            {
                rooms.Add(r);
            }
            return rooms;
        }
        public static List<GRL> GetLectors(MyContext db)
        {
            List<GRL> profNames = new List<GRL>();
            foreach(ProfEmails prof in db.Profs)
            {
                profNames.Add(new GRL { Name = prof.Name});
            }
            return profNames;
        }
        public static List<List<GRL>> GetGRL(MyContext db)
        {
            List<List<GRL>> mylist = new List<List<GRL>>();
            mylist.Add(GetGroups(db));
            mylist.Add(GetRooms(db));
            mylist.Add(GetLectors(db));
            return mylist;
        }


        private static DateTime StrToDate(string Date)
        {
            string dd, mm, yyyy;
            dd = Date[0].ToString() + Date[1].ToString();
            mm = Date[3].ToString() + Date[4].ToString();
            yyyy = Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();
            int day = Convert.ToInt32(dd), month = Convert.ToInt32(mm), year = Convert.ToInt32(yyyy);
            return new DateTime(year, month, day);
        }
    }


}