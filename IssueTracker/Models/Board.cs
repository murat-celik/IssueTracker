using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Board : AppCode.BaseEntity
    {
        public int ProjectID { get; set; }
        [Required, StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Desription { get; set; }

        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
        [NotMapped]
        public List<Column> Columns { get; set; }
    }
}