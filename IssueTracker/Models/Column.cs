using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Column : AppCode.BaseEntity
    {
        public int? BoardID { get; set; }
        public int? StateID { get; set; }

        [ForeignKey("BoardID")]
        public Board Board { get; set; }
        [ForeignKey("StateID")]
        public State State { get; set; }

        [NotMapped]
        public List<Issue> Issues { get; set; }
    }
}