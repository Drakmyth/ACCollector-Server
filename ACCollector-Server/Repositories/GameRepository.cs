using ACCollector_Server.Models;
using ACCollector_Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ACCollector_Server.Repositories
{
	public sealed class GameRepository : DbContext
	{
		public DbSet<GameEntity> Games { get; set; }

		public GameRepository(DbContextOptions<GameRepository> options) : base(options)
		{
			Games = Set<GameEntity>();
		}

		public GameEntity CreateGame(CreateGameRequest request)
		{
			var entity = new GameEntity
			{
				Id = Guid.Empty,
				Name = request.Name,
//				Releases = Enumerable.Empty<string>().ToList()
			};
			Games.Add(entity);

			SaveChanges();

			return entity;
		}
	}
}