namespace Softwash.Infrastructure.GenericRepository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly MainContext _context;
    private DbSet<T> _dbSet;

    public Repository(MainContext _context)
    {
        this._context = _context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        await _dbSet.AddAsync(entity);
        return entity;
    }
    public async Task<T> AddEntity(T entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        await _dbSet.AddAsync(entity);
        return entity;
    }
    public async Task<List<T>> AddRangeEntity(List<T> entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        await _dbSet.AddRangeAsync(entity);
        return entity;
    }

    public IQueryable<T> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<long> Count(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).LongCountAsync();
    }

    public async Task<T> Get(long id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<T> Get(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public void Remove(T entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");

        _dbSet.Remove(entity);
    }
    public void Remove(List<T> entities)
    {
        if (entities.Any())
        {
            _dbSet.RemoveRange(entities);
        }
        else
            throw new ArgumentNullException("entities");
    }

    public void UpdateEntity(T entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        _dbSet.UpdateRange(entity);
    }
    public async Task<List<T>> UpdateRangeEntity(List<T> entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");

        _dbSet.UpdateRange(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        if (entity is null) throw new ArgumentNullException("entity");
        _dbSet.Update(entity);
        return entity;
    }
}
