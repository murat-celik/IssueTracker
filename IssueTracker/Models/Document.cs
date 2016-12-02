using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Document : AppCode.BaseEntity
    {
        [Required, Column(TypeName = "varchar(MAX)")]
        public string FilePath { get; set; }
    }
}