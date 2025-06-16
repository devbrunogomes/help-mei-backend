using HelpMEI.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpMEI.Infrastructure.Repositories.Base;
public class BaseRepository<T> : IBaseRepository<T> where T : class {
	private DbSet<T> Entity { get; set; }
	protected readonly ApplicationDbContext _context;

	public BaseRepository(DbSet<T> entity, ApplicationDbContext context) {
		Entity = entity;
		_context = context;
	}

	private IQueryable<T> Query(params Expression<Func<T, object>>[] includes) {
		var query = Entity.AsQueryable();

		if (includes != null) {
			foreach (var include in includes)
				if (include != null)
					query = query.Include(include);
		}
		return query;
	}

	public T? Get(Expression<Func<T, bool>> filters, params Expression<Func<T, object>>[] includes) {
		var query = Query(includes).AsNoTracking();

		if (filters != null)
			return query.Where(filters).SingleOrDefault();

		return query.SingleOrDefault();
	}

	public IQueryable<T> GetQueryable(Expression<Func<T, bool>>? filters = null,
		 params Expression<Func<T, object>>[] includes) {
		var query = Query(includes).AsNoTracking();

		if (filters != null)
			query = query.Where(filters);

		return query;
	}

	public List<T> GetAll(Expression<Func<T, bool>>? filters = null,
		 Func<IQueryable<T>, IOrderedQueryable<T>>? sortedBy = null,
		 params Expression<Func<T, object>>[] includes) {
		var query = Query(includes).AsNoTracking();

		if (filters != null)
			query = query.Where(filters);

		if (sortedBy != null)
			query = sortedBy(query);

		return query.ToList();
	}

	public async Task AddAsync(T Entity) {
		await _context.AddAsync(Entity);
	}
}
