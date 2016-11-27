using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.AppCode
{
    public class IssueTrackerFacede
    {
        public IssueTrackerFacede()
        {
            this.IssueTrackerRepositorys = new Hashtable();
        }

        public IssueTrackerUnitOfWork oIssueTrackerUnitOfWork = new IssueTrackerUnitOfWork();

        private Hashtable IssueTrackerRepositorys;

        public EntityController<T> Model<T>() where T : class, IBaseEntity
        {
            EntityController<T> oIssueTrackerRepositorys;
            if (this.IssueTrackerRepositorys[typeof(T).FullName] != null)
            {
                oIssueTrackerRepositorys = (EntityController<T>)this.IssueTrackerRepositorys[typeof(T).FullName];
            }
            else
            {
                oIssueTrackerRepositorys = new EntityController<T>(this);
                this.IssueTrackerRepositorys.Add(typeof(T).FullName, oIssueTrackerRepositorys);
            }
            return oIssueTrackerRepositorys;
        }


    }
}