namespace CompanyPost.Infrastructure.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity , IEntity
{
	private readonly CompanyPostDbContext _context;
	private readonly DbSet<T> _dbSet;
	public GenericRepository(CompanyPostDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}
	public async Task AddAsync(T entity)
	{
		await _dbSet.AddAsync(entity);
	}
	public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
	{
		return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
	}
	public void UpdateAsync(T entity) => _dbSet.Update(entity);
	public void DeleteAsync(T entity) => _dbSet.Remove(entity);
	public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, 
		CancellationToken cancellationToken = default)
	{
		return await _dbSet.Where(predicate).FirstOrDefaultAsync(cancellationToken);
	}
}