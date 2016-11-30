using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IssueTracker.Models
{
    public class Qualification : AppCode.BaseEntity
    {
        [Required, StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Desription { get; set; }
    }
}