using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Model;
using Model.DAL;

namespace Model
{
    public class UnitOfWork : IDisposable
    {
        private CGControlPanelContext context = new CGControlPanelContext();
        private JobsRepository _jobsRepository;
        private JobTriggersRepository _jobTriggersRepository;

        public JobsRepository JobsRepository
        {
            get
            {

                if (this._jobsRepository == null)
                {
                    this._jobsRepository = new JobsRepository(context);
                }
                return _jobsRepository;
            }
        }

        public JobTriggersRepository JobTriggerRepository
        {
            get
            {
                if(this._jobTriggersRepository== null)
                {
                    this._jobTriggersRepository = new JobTriggersRepository(context);
                }
                return _jobTriggersRepository;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();    
            }
            catch(DbEntityValidationException  ex)
            {
                
            }
            
        }

        public IList<Job> GetJobs()
        {
           return context.Jobs.ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}