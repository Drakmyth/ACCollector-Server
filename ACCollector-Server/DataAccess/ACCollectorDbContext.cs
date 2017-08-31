using ACCollector_Server.Models.Entities;
using EntityFramework.DbContextScope.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACCollector_Server.DataAccess
{
	public class ACCollectorDbContext : DbContext, IDbContext
	{
		public DbSet<GameEntity> Games { get; set; }

		public ACCollectorDbContext(DbContextOptions<ACCollectorDbContext> options) : base(options)
		{
		}
	}
}