using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Collobrator : AppCode.BaseEntity
    {
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }


        public virtual List<Issue> Issues { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}