using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Team : AppCode.BaseEntity
    {
        [Required,StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required,Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }


        public virtual List<Project> Projects { get; set; }
        public virtual List<TeamCollobrator> TeamCollobrators { get; set; }
       
    }
}