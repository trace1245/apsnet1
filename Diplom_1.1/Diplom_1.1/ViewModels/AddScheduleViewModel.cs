using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;
using Diplom_1._1.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Diplom_1._1.ViewModels
{
    public class AddScheduleViewModel
    {

        public string ChosenGroup { get; set; }

        //[DisplayName("Start Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? StartDate { get; set; }

        //[DisplayName("Start Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? EndDate { get; set; }

        public List<TemporaryAddedLessons> AddedLessons { get; set; }
        public List<Group> AllGroups { get; set; }
        public bool filled { get; set; }
    }
}