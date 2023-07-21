using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace example.webapi.Controllers
{
    public class Play
    {
		
		public Guid id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string genre { get; set; }
		public DateTime date { get; set; }
		public DateTime startTime { get; set; }
		public DateTime endTime { get; set; }


    }
}