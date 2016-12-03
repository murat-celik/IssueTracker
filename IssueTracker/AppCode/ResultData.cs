using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.AppCode
{
    public class ResultData
    {
        public StatusEnum Status { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
   
}