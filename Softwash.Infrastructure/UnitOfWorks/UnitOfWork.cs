using ProjectManagement.Domain.Entities;

namespace Softwash.Infrastructure.UnitOfWorks;
public class UnitOfWork : IDisposable, IUnitOfWork
{
    private bool disposed = false;
    private readonly MainContext _context;
    public UnitOfWork(MainContext context)
    {
        _context = context;
    }

    #region Auth

    private IRepository<Login> _loginRepo;
    private IRepository<User> _userRepo;
    public IRepository<Login> LoginRepo
    {
        get
        {
            return _loginRepo ??
                (_loginRepo = new Repository<Login>(_context));
        }
    }
    public IRepository<User> UserRepo
    {
        get
        {
            return _userRepo ??
                (_userRepo = new Repository<User>(_context));
        }
    }

    #endregion

    #region Project 
    private IRepository<Project> _projectRepo;
    private IRepository<ProjectTask> _projectTaskRepo;
    public IRepository<Project> ProjectRepo
    {
        get
        {
            return _projectRepo ??
                (_projectRepo = new Repository<Project>(_context));
        }
    }
    public IRepository<ProjectTask> ProjectTaskRepo
    {
        get
        {
            return _projectTaskRepo ??
                (_projectTaskRepo = new Repository<ProjectTask>(_context));
        }
    }
    #endregion
    public async Task<int> Save()
    {
        var res = await _context.SaveChangesAsync();
        return res;
    }

    public async Task<int> Delete()
    {
        var res = await _context.SaveChangesAsync();
        return res;
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        this._context.Dispose();
    }
}

