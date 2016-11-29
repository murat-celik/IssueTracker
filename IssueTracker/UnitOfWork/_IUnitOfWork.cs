using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.UnitOfWork
{
    public interface IUnitOfWork  : IDisposable
    {
        void Save();
    }
}