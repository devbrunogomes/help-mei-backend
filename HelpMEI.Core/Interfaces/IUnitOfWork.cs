namespace HelpMEI.Core.Interfaces;
public interface IUnitOfWork {
	Task<int> SaveChangesAsync();
}
