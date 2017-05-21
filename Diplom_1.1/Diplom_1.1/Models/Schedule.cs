using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public string name { get; set; } // название предмета
        public string group { get; set; }
        public string prof { get; set; }
        public string room { get; set; }
    }
}