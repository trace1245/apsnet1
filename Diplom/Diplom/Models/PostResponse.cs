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
        public static List<Comment> GetComments(MyContext db, string group, string StartDate, string EndDate)
        {
            DateTime StartDateD = StrToDate(StartDate);
            DateTime EndDateD = StrToDate(EndDate);

            List<Comment> coms = new List<Comment>();
            foreach(Schedule s in db.Schedule)
            {
                if((s.group == group) && (s.time >= StartDateD && s.time <= EndDateD))
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
                foreach(ProfEmails email in db.Profs)
                {
                    if(args[0] == email.ProfEmail)//TODO повторяющиеся мейлы
                    {
                        exist = true;
                        if(email.Password == null)
                        {
                            id = email.Id;
                            noPass = true;
                            break;
                        }

                    }
                }
                if(noPass)
                {
                    var result = db.Profs.SingleOrDefault(b => b.Id == id); // меняем пароль для лектора
                    if(result != null)
                    {
                        result.Password = args[1];
                        db.SaveChanges();
                    }
                    db.Clients.Add(new ClientId { Group = null, PhoneId = args[2], IsProf = true }); // добавляем Id телефона лектора в список телефонов
                    return new { State = "true", ProfName = result.ProfName };
                }
                if(exist)// всегда должен быть после if(noPass)
                    return new { State = "false", Info = "1 Prof already registered" };

                return new { State = "false", Info = "2 Such Email does not exist" };

            }
            if(who == "Student")//Post: string “Register” string “Student” string “Group” string “Id”
            {
                db.Clients.Add(new ClientId { Group = args[0], PhoneId = args[1], IsProf = false });
                db.SaveChanges();
                return new { State = "true"};
            }
            return new { State = "false", Info = "0 Wrong 'who' argument. Meant to be 'Student' or 'Prof'" };
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
        public static List<Group> GetGroups(MyContext db)
        {
            List<Group> groups = new List<Group>();
            foreach(Group g in db.Groups)
            {
                groups.Add(g);
            }
            return groups;
        }
        public static List<Lesson> GetLessons(MyContext db)
        {
            List<Lesson> lessonss = new List<Lesson>();
            foreach(Lesson l in db.Lessons)
            {
                lessonss.Add(l);
            }
            return lessonss;
        }
        public static List<Room> GetRooms(MyContext db)
        {
            List<Room> rooms = new List<Room>();
            foreach(Room r in db.Rooms)
            {
                rooms.Add(r);
            }
            return rooms;
        }
        public static List<object> GetLectors(MyContext db)
        {
            List<object> profNames = new List<object>();
            foreach(ProfEmails prof in db.Profs)
            {
                profNames.Add(new { Name = prof.ProfName });
            }
            return profNames;
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