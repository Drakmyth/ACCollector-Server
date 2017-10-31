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
	public sealed class ReleaseRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public ReleaseRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public Release CreateRelease(CreateReleaseRequest request)
		{
			var entity = new ReleaseEntity
			{
				ReleaseId = Guid.Empty,
				GameId = Guid.Empty,
				Platform = request.Platform,
				Region = request.Region,
				Title = request.Title,
				ReleaseDate = request.ReleaseDate
			};

			var context = _contextLocator.Get<ACCollectorDbContext>();
			DbSet<ReleaseEntity> dbSet = context.Set<ReleaseEntity>();
			EntityEntry<ReleaseEntity> entry = dbSet.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<ReleaseSummary> GetReleaseSummaries()
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			DbSet<ReleaseEntity> dbSet = context.Set<ReleaseEntity>();
			return dbSet
				.ToList()
				.Select(re => re.ToSummary())
				.ToList()
				.AsReadOnly();
		}

		public Release GetRelease(Guid releaseId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			DbSet<ReleaseEntity> dbSet = context.Set<ReleaseEntity>();
			return dbSet
				.Where(r => r.ReleaseId == releaseId)
				.Single()
				.ToModel();
		}
	}
}