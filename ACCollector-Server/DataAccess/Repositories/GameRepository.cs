using ACCollector_Server.Models;
using ACCollector_Server.Models.Entities;
using EntityFramework.DbContextScope.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ACCollector_Server.DataAccess.Repositories
{
	public sealed class GameRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public GameRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public GameEntity CreateGame(CreateGameRequest request)
		{
			var entity = new GameEntity
			{
				Id = Guid.Empty,
				Name = request.Name,
//				Releases = Enumerable.Empty<string>().ToList()
			};

			ACCollectorDbContext context = _contextLocator.Get<ACCollectorDbContext>();
			DbSet<GameEntity> dbSet = context.Set<GameEntity>();
			EntityEntry<GameEntity> entry = dbSet.Add(entity);
			return entry.Entity;
		}
	}
}