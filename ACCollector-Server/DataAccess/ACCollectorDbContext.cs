using ACCollector_Server.Models.Entities;
using EntityFramework.DbContextScope.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACCollector_Server.DataAccess
{
	public class ACCollectorDbContext : DbContext, IDbContext
	{
		public DbSet<GameEntity> Games => Set<GameEntity>();
		public DbSet<ReleaseEntity> Releases => Set<ReleaseEntity>();

		public ACCollectorDbContext(DbContextOptions<ACCollectorDbContext> options) : base(options)
		{
		}
	}
}