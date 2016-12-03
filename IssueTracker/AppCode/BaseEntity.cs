using System;
using System.ComponentModel.DataAnnotations;
using IssueTracker.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Collections.Generic;

namespace IssueTracker.AppCode
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key Column(Order = 0)]
        public int ID { get; set; }

        public int? UserCreatedID { get; set; }
        public int? UserUpdatedID { get; set; }

        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeUpdated { get; set; }

        public StatusEnum Status { get; set; }

        [ForeignKey("UserCreatedID"), Column(Order = 1)]
        public User UserCreated { get; set; }
        [ForeignKey("UserUpdatedID"), Column(Order = 2)]
        public User UserUpdated { get; set; }

        public virtual bool IsNewRecord()
        {
            return this.ID == 0 ? true : false;
        }
    }
}
