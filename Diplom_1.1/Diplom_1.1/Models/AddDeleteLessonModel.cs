using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom_1._1.Models
{
    public class AddDeleteLessonModel
    {
        public DateTime? Time { get; set; }
        public string Name { get; set; }
        public string Prof { get; set; }
        public string Room { get; set; }
        public int? Id { get; set; }
        public string Group { get; set; }
    }
}