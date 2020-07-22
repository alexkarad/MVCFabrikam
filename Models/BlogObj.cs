using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFabrikam.Models
{
    public class BlogObj
    {
        public int ID { get; set; }
        public string Post { get; set; }
        public List<BlogObj> Posts { get; set; }
    }
}