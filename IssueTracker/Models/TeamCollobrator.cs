using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class TeamCollobrator : AppCode.BaseEntity
    {
        public int? TeamID { get; set; }
        [ForeignKey("TeamID")]
        public Team Team { get; set; }

        public int? CollobratorID { get; set; }
        [ForeignKey("CollobratorID")]
        public Collobrator Collobrator { get; set; }
    }
}