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
        public static List<FormattedSchedule> GetSchedule(MyContext db, string group, string StartDate, string EndDate)
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

            List<Comment> coml;
            foreach(Schedule s in db.Schedule)
            {
                coml = new List<Comment>();
                if((s.group == group) && (s.time >= StartDateD && s.time <= EndDateD))
                {
                    string ntime = s.time.ToString();
                    ntime = ntime.Replace('.', '-');
                    ntime = ntime.Replace('/', '-');
                    ntime = ntime.Substring(0, ntime.Length - 3);

                    foreach(Comment c in db.Comments)
                    {
                        if(c.LessonId == s.id)
                        {
                            coml.Add(c);
                        }
                    }

                    FormattedSchedule sch = new FormattedSchedule
                    {
                        id = s.id,
                        time = ntime,
                        name = s.name,
                        group = s.group,
                        prof = s.prof,
                        room = s.room,
                        comm = coml
                    };
                    result.Add(sch);
                }
            }
            return result;
        }
        public static string Check(IEnumerable<ProfEmails> profs, string email, string pswrd) // возвращает true если логин пароль верный и такой преподаватель зарегестрирован
        {//TODO MyContext db in arguments
            foreach(ProfEmails prof in profs)
            {
                if(prof.ProfEmail == email && prof.Password == pswrd)
                    return "true";
            }
            return "false";
        }
        public static IEnumerable<string> Register(MyContext db, string who, params string[] args) // для преподавателя - string “Prof” string “Email” string “Password” string “Id”
        {
            List<string> response = new List<string>
            {
                "0 Wrong 'who' argument. Meant to be 'Student' or 'Prof'"
            };
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
                    return response = new List<string> { "true", result.ProfName };
                }
                if(exist)// всегда должен быть после if(noPass)
                    return response = new List<string> { "false", "1 Prof already registered" };

                return response = new List<string> { "false", "2 Such Email does not exist" };

            }
            if(who == "Student")//Post: string “Register” string “Student” string “Group” string “Id”
            {
                db.Clients.Add(new ClientId { Group = args[0], PhoneId = args[1], IsProf = false });
                db.SaveChanges();
                return response = new List<string> { "true"};
            }
            return response;
        }
        public static List<string> AddComment(MyContext db, string LessonId, string Message, string Name)
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
                return new List<string> { "true" };
            }
            return new List<string> { "false", "There is no lesson with such id" };
        }
    }


}