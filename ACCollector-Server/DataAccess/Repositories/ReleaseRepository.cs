using ACCollector_Server.Models;
using ACCollector_Server.Models.Entities;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
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
				GameId = request.GameId,
				Platform = request.Platform,
				Region = request.Region,
				ReleaseDate = request.ReleaseDate,
				Title = request.Title
			};

			var context = _contextLocator.Get<ACCollectorDbContext>();
			DbSet<ReleaseEntity> dbSet = context.Set<ReleaseEntity>();
			EntityEntry<ReleaseEntity> entry = dbSet.Add(entity);
			return entry.Entity.ToModel();
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