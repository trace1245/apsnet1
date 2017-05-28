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
    public class ProfRegisterViewModel
    {
        public List<ProfEmails> profs { get; set; }
        public string NewProfEmail { get; set; }
        public string NewProfName { get; set; }
    }
}