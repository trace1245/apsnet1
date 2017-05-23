using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Diplom_1._1.Models;

namespace Diplom.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<MyContext>
    {
        List<string> lessons = new List<string>
        {
            "Математика", "Ин. яз", "Программирование", "Экономика", "История", "Культурология", "Философия", "Основы теоретических теорий в малых экосистемах"
        };
        List<string> groups = new List<string>
        {
            "КН-10", "БП-20", "ФИО-14", "АБВ-220", "ККД-2", "ДУ-21", "ОСТ-3"
        };
        List<string> lectors = new List<string>
        {
            "Ковалэнко В.В.",
            "Бондарэнко В.В.",
            "Евэнко В.В.",
            "Злэнко В.В.",
            "Лучэнко В.В.",
            "Майстрэнко В.В.",
            "Ткачэнко В.В.",
            "Петрэнко В.В.",
            "Павлэнко В.В.",
            "Шевчэнко В.В.",
            "Галаенко В.В.",
            "Мотриенко В.В.",
            "Саенко В.В.",
            "Стратиенко В.В.",
            "Витребэнько В.В.",
            "Опэнько В.В.",
            "Потебэнько В.В.",
            "Бутэйко В.В.",
            "Ламэйко В.В."
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
            "Тестовый комментарий"
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
            for(int i = 0; i < 300; i++)
            {
                db.Schedule.Add(new Schedule
                {
                    time = RandomDay(new TimeSpan(8, 30, 0)),
                    name = lessons[gen.Next(lessons.Count)],
                    group = groups[gen.Next(groups.Count)],
                    prof = lectors[gen.Next(lectors.Count)],
                    room = rooms[gen.Next(rooms.Count)]
                });
            }
            for(int i = 0; i < 300; i++)
            {
                db.Schedule.Add(new Schedule
                {
                    time = RandomDay(new TimeSpan(10, 00, 0)),
                    name = lessons[gen.Next(lessons.Count)],
                    group = groups[gen.Next(groups.Count)],
                    prof = lectors[gen.Next(lectors.Count)],
                    room = rooms[gen.Next(rooms.Count)]
                });
            }
            for(int i = 0; i < 300; i++)
            {
                db.Schedule.Add(new Schedule
                {
                    time = RandomDay(new TimeSpan(11, 40, 0)),
                    name = lessons[gen.Next(lessons.Count)],
                    group = groups[gen.Next(groups.Count)],
                    prof = lectors[gen.Next(lectors.Count)],
                    room = rooms[gen.Next(rooms.Count)]
                });
            }
            for(int i = 0; i < 300; i++)
            {
                db.Schedule.Add(new Schedule
                {
                    time = RandomDay(new TimeSpan(13, 05, 0)),
                    name = lessons[gen.Next(lessons.Count)],
                    group = groups[gen.Next(groups.Count)],
                    prof = lectors[gen.Next(lectors.Count)],
                    room = rooms[gen.Next(rooms.Count)]
                });
            }
            for(int i = 0; i < 300; i++)
            {
                db.Comments.Add(new Comment
                {
                    Name = lectors[gen.Next(lectors.Count)],
                    LessonId = gen.Next(1000),
                    Commentary = comments[gen.Next(comments.Count)]
                });
            }


            db.Clients.Add(new ClientId { Group = "KN-13", PhoneId = "qwerty1234", IsProf = false });

            char c = 'a';
            for(int i = 0; i < 19; i++, c++)
            {
                db.Profs.Add(new ProfEmails { Name = lectors[i], ProfEmail = c.ToString() + "@mail.me" });
            }

            foreach(string str in groups)
            {
                db.Groups.Add(new Group { Name = str });
            }

            foreach(string str in rooms)
            {
                db.Rooms.Add(new Room { Name = str });
            }

            foreach(string str in lessons)
            {
                db.Lessons.Add(new Lesson { Name = str });
            }

            db.TLessons.Add(new TemporaryAddedLessons
            {
                time = DateTime.Today,
                name = lessons[gen.Next(lessons.Count)],
                group = null,
                prof = lectors[gen.Next(lectors.Count)],
                room = rooms[gen.Next(rooms.Count)],
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            });

            base.Seed(db);
        }
    }
}