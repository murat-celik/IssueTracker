using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Priority : AppCode.BaseEntity
    {
        [Required, StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }
        [StringLength(32), Column(TypeName = "varchar")]
        public string Color { get; set; }
    }
}