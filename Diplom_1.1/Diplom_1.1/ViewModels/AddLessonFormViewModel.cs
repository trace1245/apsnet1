using Diplom_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;

namespace Diplom_1._1.ViewModels
{
    public class AddLessonFormViewModel
    {
        public TemporaryAddedLessons Lesson { get; set; }
        public DateTime FineDate { get; set; }
    }
}