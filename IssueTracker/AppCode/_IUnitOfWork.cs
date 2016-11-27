using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.AppCode
{
    public interface IUnitOfWork  : IDisposable
    {
        void Save();
    }
}