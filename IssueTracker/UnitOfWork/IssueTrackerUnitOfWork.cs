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
            catch (Exception ex)
            {
                this.oIssueTrackerContext.Database.CurrentTransaction.Rollback();
                return false;
            }
        }

        public string GetValidationErrors()
        {
            string ErrorMessage = "";
            if (this.oIssueTrackerContext.GetValidationErrors() != null)
            {
                ErrorMessage = "<ul>";

                foreach (var item in this.oIssueTrackerContext.GetValidationErrors())
                {
                    foreach (var error in item.ValidationErrors)
                    {
                        ErrorMessage = ErrorMessage + "<li>" + error.ErrorMessage + " </li> ";
                    }

                }

                ErrorMessage = ErrorMessage + "</ul>";
            }

            return ErrorMessage;
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