using System;
using System.Collections;

using IssueTracker.AppCode;
using IssueTracker.Repository;
using IssueTracker.Models;

namespace IssueTracker.UnitOfWork
{
    public class IssueTrackerUnitOfWork
    {
        private IssueTrackerContext oIssueTrackerContext = new IssueTrackerContext();
        private bool _disposed = false;


        private IssueTrackerRepository<Team> _teamRepository;

        public IssueTrackerRepository<Team> TeamRepository
        {
            get
            {
                if (_teamRepository == null)
                    _teamRepository = new IssueTrackerRepository<Team>(oIssueTrackerContext);
                return _teamRepository;
            }
        }


        public bool Save()
        {
            try
            {
                if (this.oIssueTrackerContext.Database.CurrentTransaction == null)
                {
                    this.oIssueTrackerContext.Database.BeginTransaction();
                }

                this.oIssueTrackerContext.SaveChanges();
                this.oIssueTrackerContext.Database.CurrentTransaction.Commit();
                return true;
            }
            catch (Exception)
            {
                this.oIssueTrackerContext.Database.CurrentTransaction.Rollback();
                return false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    oIssueTrackerContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}