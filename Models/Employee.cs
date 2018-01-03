using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Demo.Models
{
    public class Employee
    {
        public int? id { get; set; }
        public Guid? guid { get; set; }
        public string employee { get; set; }
        public decimal salary { get; set; }
        public string jobTitle { get; set; }
    }
}