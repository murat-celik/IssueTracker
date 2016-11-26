using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.App_Code
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeUpdate { get; set; }
    }
}