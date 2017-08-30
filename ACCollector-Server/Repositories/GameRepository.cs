using ACCollector_Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ACCollector_Server.Repositories
{
	public class GameRepository : DbContext
	{
		public DbSet<GameEntity> Games { get; set; }

		public GameRepository(DbContextOptions<GameRepository> options) : base(options)
		{
		}
	}
}