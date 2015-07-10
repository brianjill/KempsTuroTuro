using KempsTuroTuro.Data.Interface;

namespace KempsTuroTuro.Data
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private KempsContext _dataContext;
    public KempsContext Get()
    {
        return _dataContext ?? (_dataContext = new KempsContext());
    }
    protected override void DisposeCore()
    {
        if (_dataContext != null)
            _dataContext.Dispose();
    }
}
}
