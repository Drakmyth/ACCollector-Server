using EntityFramework.DbContextScope.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACCollector_Server.DataAccess
{
	public class ACCollectorDbContextFactory : IDbContextFactory
	{
		private readonly DbContextOptions<ACCollectorDbContext> _contextOptions;

		public ACCollectorDbContextFactory(DbContextOptions<ACCollectorDbContext> contextOptions)
		{
			_contextOptions = contextOptions;
		}

		public TDbContext CreateDbContext<TDbContext>() where TDbContext : class, IDbContext
		{
			return new ACCollectorDbContext(_contextOptions) as TDbContext;
		}
	}
}