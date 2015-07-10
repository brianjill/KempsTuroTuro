using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KempsTuroTuro.Data.Interface
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void Dispose();
    }
}
