using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class CollobratorQualification : AppCode.BaseEntity
    {
        public int? CollobratorID { get; set; }
        public int? QualificationID { get; set; }

        [ForeignKey("CollobratorID")]
        public User Collobrator { get; set; }
        [ForeignKey("QualificationID")]
        public User Qualification { get; set; }
    }
}