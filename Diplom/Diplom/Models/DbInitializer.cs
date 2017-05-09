using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Diplom.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<MyContext>
    {
        List<string> lessons = new List<string>
        {
            "Математика", "Ин. яз", "Программирование", "Экономика", "История", "Культурология", "Философия"
        };
        List<string> groups = new List<string>
        {
            "КН-10", "БП-20", "ФИО-14", "АБВ-220", "ККД-2", "ДУ-21", "ОСТ-3"
        };
        List<string> lectors = new List<string>
        {
            "Иванов Иван Иванович", "Владимиров Владимир Владимирович", "Александров Александр Александрович", "Евгенов Евген Евгенович", "Бобрынин Бобрын Бобрнович"
        };
        List<string> rooms = new List<string>
        {
            "101", "202", "107", "018", "204", "207",
        };
        List<string> comments = new List<string>
        {
            "Пары не будет",
            "Будет КР",
            "Сделать двадцатое задание",
            "Переносим в 207 аудиторию",
            null,
            "Тестовый комментарий",
            null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null
        };



        private Random gen = new Random();
        DateTime RandomDay(TimeSpan ts)
        {
            DateTime start = new DateTime(2017, 5, 1);
            int range = (new DateTime(2017, 6, 30) - start).Days;
            //TimeSpan ts = new TimeSpan(8, 30, 0);
            start = start.AddDays(gen.Next(range));
            start = start.Date + ts;
            return start;
        }

        protected override void Seed(MyContext db)
        {
            for(int i = 0; i < 30; i++)
            {
                db.Schedule.Add(new Schedule
                {
                    time = RandomDay(new TimeSpan(8, 30, 0)),
                    name = lessons[gen.Next(lessons.Count)],
                    group = groups[gen.Next(groups.Count)],
                    prof = lectors[gen.Next(lectors.Count)],
                    room = rooms[gen.Next(rooms.Count)],
                    comment = comments[gen.Next(comments.Count)]
                });
            }
            for(int i = 0; i < 30; i++)
            {
                db.Schedule.Add(new Schedule
                {
                    time = RandomDay(new TimeSpan(10, 00, 0)),
                    name = lessons[gen.Next(lessons.Count)],
                    group = groups[gen.Next(groups.Count)],
                    prof = lectors[gen.Next(lectors.Count)],
                    room = rooms[gen.Next(rooms.Count)],
                    comment = comments[gen.Next(comments.Count)]
                });
            }
            for(int i = 0; i < 30; i++)
            {
                db.Schedule.Add(new Schedule
                {
                    time = RandomDay(new TimeSpan(11, 40, 0)),
                    name = lessons[gen.Next(lessons.Count)],
                    group = groups[gen.Next(groups.Count)],
                    prof = lectors[gen.Next(lectors.Count)],
                    room = rooms[gen.Next(rooms.Count)],
                    comment = comments[gen.Next(comments.Count)]
                });
            }
            for(int i = 0; i < 30; i++)
            {
                db.Schedule.Add(new Schedule
                {
                    time = RandomDay(new TimeSpan(13, 05, 0)),
                    name = lessons[gen.Next(lessons.Count)],
                    group = groups[gen.Next(groups.Count)],
                    prof = lectors[gen.Next(lectors.Count)],
                    room = rooms[gen.Next(rooms.Count)],
                    comment = comments[gen.Next(comments.Count)]
                });
            }


            db.Clients.Add(new ClientId { Group = "KN-13", PhoneId = "qwerty1234", IsProf = false });
            base.Seed(db);
        }
    }
}