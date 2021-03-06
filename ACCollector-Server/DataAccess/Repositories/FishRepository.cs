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
	public sealed class FishRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public FishRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public Fish CreateFishForGame(Guid gameId, CreateFishRequest request)
		{
			var entity = new FishEntity(gameId, request);
			var context = _contextLocator.Get<ACCollectorDbContext>();
			EntityEntry<FishEntity> entry = context.Fish.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<FishSummary> GetFishSummaries()
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Fish // TODO: Consider making Summaries a DB view
				.ToList()
				.Select(f => f.ToSummary())
				.ToList()
				.AsReadOnly();
		}

		public IReadOnlyList<Fish> GetFishForGame(Guid gameId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Fish
				.Where(f => f.GameId == gameId)
				.Include(f => f.AvailabilityMappings)
				.ThenInclude(am => am.Availability)
				.Include(f => f.NoteMappings)
				.ThenInclude(nm => nm.Note)
				.ToList()
				.Select(f => f.ToModel())
				.ToList()
				.AsReadOnly();
		}

		public Fish GetFish(Guid fishId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Fish
				.Where(f => f.FishId == fishId)
				.Include(f => f.AvailabilityMappings)
				.ThenInclude(am => am.Availability)
				.Include(f => f.NoteMappings)
				.ThenInclude(nm => nm.Note)
				.Single()
				.ToModel();
		}
	}
}