using System.Linq.Expressions;

namespace HelpMEI.Core.Interfaces;
public interface IBaseRepository<T> {
	T? Get(Expression<Func<T, bool>> filters, params Expression<Func<T, object>>[] includes);

	List<T> GetAll(Expression<Func<T, bool>>? filters = null,
		 Func<IQueryable<T>, IOrderedQueryable<T>>? sortedBy = null,
		 params Expression<Func<T, object>>[] includes);

	IQueryable<T> GetQueryable(Expression<Func<T, bool>>? filters = null,
		 params Expression<Func<T, object>>[] includes);

	Task AddAsync(T Entity);
}
