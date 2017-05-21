using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class ClientId // список зарегистрированых телефонов, для пулл запросов
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string PhoneId { get; set; }
        public bool IsProf { get; set; }
    }
}