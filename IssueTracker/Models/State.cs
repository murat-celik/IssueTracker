using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class State : AppCode.BaseEntity
    {
        [Required, StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        public bool IsResolved { get; set; }
    }
}