namespace CompanyPost.Application.Abstraction;
public interface IGenericRepository<T> where T : BaseEntity , IEntity
{
	Task<T> FindAsync(Expression<Func<T, bool>> predicate , CancellationToken cancellationToken = default);
	Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default );
	Task AddAsync(T entity);
	void UpdateAsync(T entity);
	void DeleteAsync(T entity);
}