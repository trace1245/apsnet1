using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string ChangedGroup { get; set; }
        public string Date { get; set; }//TODO datetime
    }
}