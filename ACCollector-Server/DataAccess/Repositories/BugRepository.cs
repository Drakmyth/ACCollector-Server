using ACCollector_Server.Models;
using ACCollector_Server.Models.Entities;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ACCollector_Server.DataAccess.Repositories
{
	[UsedImplicitly]
	public sealed class BugRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public BugRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public Bug CreateBugForGame(Guid gameId, CreateBugRequest request)
		{
			var entity = new BugEntity(gameId, request);
			var context = _contextLocator.Get<ACCollectorDbContext>();
			EntityEntry<BugEntity> entry = context.Bugs.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<BugSummary> GetBugSummaries()
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Bugs // TODO: Consider making Summaries a DB view
				.ToList()
				.Select(b => b.ToSummary())
				.ToList()
				.AsReadOnly();
		}

		public IReadOnlyList<Bug> GetBugsForGame(Guid gameId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Bugs
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

		public Bug GetBug(Guid bugId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Bugs
				.Where(b => b.BugId == bugId)
				.Include(b => b.AvailabilityMappings)
				.ThenInclude(am => am.Availability)
				.Include(b => b.NoteMappings)
				.ThenInclude(nm => nm.Note)
				.Single()
				.ToModel();
		}
	}
}