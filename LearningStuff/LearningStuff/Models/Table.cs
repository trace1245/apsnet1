using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningStuff.Models
{
    public class Table //ID | Time(hh:mm) | Name | Group | Prof | Room | Comment | 
    {
        public string id { get; set; }
        public string time { get; set; }
        public string name { get; set; }
        public string group { get; set; }
        public string prof { get; set; }
        public string room { get; set; }
        public string comment { get; set; }
    }
}