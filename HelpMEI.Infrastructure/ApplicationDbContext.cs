using Microsoft.EntityFrameworkCore;

namespace HelpMEI.Infrastructure;
public class ApplicationDbContext : DbContext {
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
