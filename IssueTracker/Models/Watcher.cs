using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Watcher : AppCode.BaseEntity
    {
        public int? CollobratorID { get; set; }
        [ForeignKey("CollobratorID")]
        public Collobrator Collobrator { get; set; }

        public int? IssueID { get; set; }
        [ForeignKey("IssueID")]
        public Issue Issue { get; set; }

    }
}