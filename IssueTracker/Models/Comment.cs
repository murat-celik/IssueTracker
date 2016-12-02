using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Comment : AppCode.BaseEntity
    {
        public int CollobratorID { get; set; }
        [ForeignKey("CollobratorID")]
        public Collobrator Collobrator { get; set; }

        [Required, Column(TypeName = "varchar(MAX)")]
        public string Desription { get; set; }
    }
}