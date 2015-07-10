using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KempsTuroTuro.Data.Interface;

namespace KempsTuroTuro.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private KempsContext _dbContext;
        private readonly IDatabaseFactory _dbFactory;
        protected KempsContext DbContext
        {
            get
            {
                return _dbContext ?? (_dbContext = _dbFactory.Get());
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
