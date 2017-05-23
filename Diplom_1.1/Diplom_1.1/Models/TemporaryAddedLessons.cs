using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom_1._1.Models
{
    public class TemporaryAddedLessons //хранит расписания, созданные в модуле создания расписаний, но не добавленые в общие расписания
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public string name { get; set; }
        public string group { get; set; }// здесь будет работать как ChosenGroup
        public string prof { get; set; }
        public string room { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool AddedToTable { get; set; }
    }
}