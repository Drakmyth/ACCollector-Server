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
			var entity = new GameEntity(request);
			var context = _contextLocator.Get<ACCollectorDbContext>();
			EntityEntry<GameEntity> entry = context.Games.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<GameSummary> GetGameSummaries(Region preferredRegion)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Games // TODO: Consider making Summaries a DB view
				.Include(g => g.Releases)
				.ToList()
				.Select(g => g.ToSummary(preferredRegion))
				.ToList()
				.AsReadOnly();
		}

		public Game GetGame(Guid gameId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Games
				.Where(g => g.GameId == gameId)
				.Include(g => g.Releases)
				.Single()
				.ToModel();
		}
	}
}