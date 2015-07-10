using System;
using KempsTuroTuro.Data;

namespace KempsTuroTuro.Data.Interface
{
    public interface IDatabaseFactory : IDisposable
    {
        KempsContext Get();
    }
}
