using System;
using KempsTuroTuro.DAL;

namespace KempsTuroTuro.Interface
{
    public interface IDatabaseFactory : IDisposable
    {
        KempsContext Get();
    }
}
