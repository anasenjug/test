using example.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Xml.Schema;


namespace example.common
{
    public class Paging
    {
        public int? PageSize { get; set; } = 5;
        public int? PageNumber { get; set; } = 1;
    }
}
