using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.AppCode
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int UserCreatedId { get; set; }
        public int UserUpdatedId { get; set; }

        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeUpdated { get; set; }
    }
}