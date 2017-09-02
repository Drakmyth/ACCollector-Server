using ACCollector_Server.Models;
using ACCollector_Server.Models.Entities;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.DataAccess.Repositories
{
	[UsedImplicitly]
	public sealed class GameRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public GameRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public Game CreateGame(CreateGameRequest request)
		{
			var entity = new GameEntity
			{
				GameId = Guid.Empty,
				Name = request.Name
			};

			foreach (CreateReleaseRequest release in request.Releases)
			{
				entity.Releases.Add(new ReleaseEntity
				{
					GameId = Guid.Empty,
					Platform = release.Platform,
					Region = release.Region,
					Title = release.Title,
					ReleaseId = Guid.Empty,
					ReleaseDate = release.ReleaseDate
				});
			}

			var context = _contextLocator.Get<ACCollectorDbContext>();
			DbSet<GameEntity> dbSet = context.Set<GameEntity>();
			EntityEntry<GameEntity> entry = dbSet.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<GameSummary> GetGameSummaries(Region preferredRegion)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			DbSet<GameEntity> dbSet = context.Set<GameEntity>();
			return dbSet
				.Include(ge => ge.Releases)
				.ToList()
				.Select(ge => ge.ToSummary(preferredRegion))
				.ToList()
				.AsReadOnly();
		}

		public Game GetGame(Guid gameId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			DbSet<GameEntity> dbSet = context.Set<GameEntity>();
			return dbSet
				.Include(g => g.Releases)
				.Where(g => g.GameId == gameId)
				.Single()
				.ToModel();
		}
	}
}