using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class User 
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(64), Column(TypeName = "varchar")]
        public string Firstname { get; set; }
        [Required, StringLength(64), Column(TypeName = "varchar")]
        public string Lastname { get; set; }
    }
}