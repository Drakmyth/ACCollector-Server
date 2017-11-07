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
	public sealed class DeepSeaCreatureRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public DeepSeaCreatureRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public DeepSeaCreature CreateDeepSeaCreatureForGame(Guid gameId, CreateDeepSeaCreatureRequest request)
		{
			var entity = new DeepSeaCreatureEntity(gameId, request);
			var context = _contextLocator.Get<ACCollectorDbContext>();
			EntityEntry<DeepSeaCreatureEntity> entry = context.DeepSeaCreatures.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<DeepSeaCreatureSummary> GetDeepSeaCreatureSummaries()
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.DeepSeaCreatures // TODO: Consider making Summaries a DB view
				.ToList()
				.Select(b => b.ToSummary())
				.ToList()
				.AsReadOnly();
		}

		public IReadOnlyList<DeepSeaCreature> GetDeepSeaCreatureForGame(Guid gameId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.DeepSeaCreatures
				.Where(b => b.GameId == gameId)
				.Include(b => b.AvailabilityMappings)
				.ThenInclude(am => am.Availability)
				.Include(b => b.NoteMappings)
				.ThenInclude(nm => nm.Note)
				.ToList()
				.Select(b => b.ToModel())
				.ToList()
				.AsReadOnly();
		}

		public DeepSeaCreature GetDeepSeaCreature(Guid deepSeaCreatureId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.DeepSeaCreatures
				.Where(b => b.DeepSeaCreatureId == deepSeaCreatureId)
				.Include(b => b.AvailabilityMappings)
				.ThenInclude(am => am.Availability)
				.Include(b => b.NoteMappings)
				.ThenInclude(nm => nm.Note)
				.Single()
				.ToModel();
		}
	}
}