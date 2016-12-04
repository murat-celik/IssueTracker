using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Tag : AppCode.BaseEntity
    {
        public int ProjectID { get; set; }
        [Required, StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
    }
}