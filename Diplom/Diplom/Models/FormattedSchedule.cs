using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class FormattedSchedule
    {
        public int id { get; set; }
        public string time { get; set; }
        public string name { get; set; }
        public string group { get; set; }
        public string prof { get; set; }
        public string room { get; set; }
    }
}