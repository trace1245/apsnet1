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
    public class CommentViewModel
    {
        public string Message { get; set; }
        public string ChosenGroup { get; set; }
        public string Who { get; set; }
        public bool? IsSent { get; set; }
    }
}