using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace IssueTracker.AppCode
{
    public class IssueTrackerUnitOfWork
    {
        public IssueTrackerUnitOfWork()
        {
             this._IssueTrackerRepositorys = new Hashtable();
        }

        private IssueTrackerContext DbContext = new IssueTrackerContext();
        
        public bool Save()
        {
            try
            {
                if (this.DbContext.Database.CurrentTransaction == null)
                    this.DbContext.Database.BeginTransaction();
                this.DbContext.SaveChanges();
                this.DbContext.Database.CurrentTransaction.Commit();
                return true;
            }
            catch (Exception)
            {
                this.DbContext.Database.CurrentTransaction.Rollback();
                return false;
            }
        }

        private Hashtable _IssueTrackerRepositorys;
        public IssueTrackerRepository<T> CreateRepository<T>() where T : class, IBaseEntity
        {
            IssueTrackerRepository<T> oIssueTrackerRepositorys;
            if (this._IssueTrackerRepositorys[typeof(T).FullName] != null)
            {
                oIssueTrackerRepositorys = (IssueTrackerRepository<T>)this._IssueTrackerRepositorys[typeof(T).FullName];
            }
            else
            {
                oIssueTrackerRepositorys = new IssueTrackerRepository<T>(this.DbContext);
                this._IssueTrackerRepositorys.Add(typeof(T).FullName, oIssueTrackerRepositorys);
            }

            return oIssueTrackerRepositorys;
        }

        //public IssueTrackerRepository<T> CreateRepository<T>() where T : class, IBaseEntity
        //{
        //    return new IssueTrackerRepository<T>(this.DbContext);
        //}

    }
}