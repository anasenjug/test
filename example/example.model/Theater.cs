using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace example.webapi.Controllers
{
    public class Theater
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}