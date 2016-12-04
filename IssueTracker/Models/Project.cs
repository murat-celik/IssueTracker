using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Project : AppCode.BaseEntity
    {
        public int TeamID { get; set; }
        [Required, StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }

        [ForeignKey("TeamID")]
        public Team Team { get; set; }

        public virtual List<Board> Boards { get; set; }
        public virtual List<Issue> Issues { get; set; }
        public virtual List<Tag> Tags { get; set; }
}
}