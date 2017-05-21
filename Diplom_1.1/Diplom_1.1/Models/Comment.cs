using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }// кто сделал комментарий
        public int LessonId { get; set; }
        public string Commentary { get; set; }
    }
}