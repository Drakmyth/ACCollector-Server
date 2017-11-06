using ACCollector_Server.Models;
using ACCollector_Server.Models.Entities;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.DataAccess.Repositories
{
	[UsedImplicitly]
	public sealed class ReleaseRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public ReleaseRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public Release CreateReleaseForGame(Guid gameId, CreateReleaseRequest request)
		{
			var entity = new ReleaseEntity(gameId, request);
			var context = _contextLocator.Get<ACCollectorDbContext>();
			EntityEntry<ReleaseEntity> entry = context.Releases.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<ReleaseSummary> GetReleaseSummaries()
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Releases // TODO: Consider making Summaries a DB view
				.ToList()
				.Select(re => re.ToSummary())
				.ToList()
				.AsReadOnly();
		}

		public Release GetRelease(Guid releaseId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Releases
				.Where(r => r.ReleaseId == releaseId)
				.Single()
				.ToModel();
		}

		public IReadOnlyList<Release> GetReleasesForGame(Guid gameId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Releases
				.Where(re => re.GameId == gameId)
				.ToList()
				.Select(re => re.ToModel())
				.ToList()
				.AsReadOnly();
		}
	}
}