using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class IssueTag : AppCode.BaseEntity
    {
        public int IssueID { get; set; }
        [ForeignKey("IssueID")]
        public Issue Issue { get; set; }

        public int TagID { get; set; }
        [ForeignKey("TagID")]
        public Tag Tag { get; set; }
    }
}