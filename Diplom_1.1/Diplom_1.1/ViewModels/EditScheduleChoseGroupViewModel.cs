using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;
using Diplom_1._1.Models;
using System.Web.Mvc;
using System.Globalization;

namespace Diplom_1._1.ViewModels
{
    public class EditScheduleChoseGroupViewModel
    {
        public string ChosenGroup { get; set; }
        public int ChosenTime { get; set; }
        public bool filled { get; set; }
        public List<Schedule> schedule { get; set; }
        public int IdForChange { get; set; }


    }
}