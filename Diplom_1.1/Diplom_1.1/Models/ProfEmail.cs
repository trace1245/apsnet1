using Diplom_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class ProfEmails : GRL
    {
        public int Id { get; set; }
        public string ProfEmail { get; set; }
        public string Password { get; set; }
    }
}