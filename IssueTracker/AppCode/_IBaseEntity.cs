using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace IssueTracker.AppCode
{
    public interface IBaseEntity
    {
        int ID { get; set; }

        int? UserCreatedID { get; set; }
        int? UserUpdatedID { get; set; }

        DateTime DateTimeCreated { get; set; }
        DateTime DateTimeUpdated { get; set; }

        StatusEnum Status { get; set; }

        bool IsNewRecord();
       
    }
}