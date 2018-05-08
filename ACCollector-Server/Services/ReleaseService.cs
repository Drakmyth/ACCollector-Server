using ACCollector_Server.DataAccess.Repositories;
using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Services
{
	public class ReleaseService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly ReleaseRepository _releaseRepository;

		public ReleaseService(IDbContextScopeFactory dbContextScopeFactory, ReleaseRepository releaseRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_releaseRepository = releaseRepository;
		}

		public IReadOnlyList<Release> GetReleasesForGame(Guid gameId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _releaseRepository.GetReleasesForGame(gameId);
			}
		}

		public IReadOnlyList<ReleaseSummary> GetReleaseSummaries()
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _releaseRepository.GetReleaseSummaries();
			}
		}

		public Release CreateReleaseForGame(Guid gameId, CreateReleaseRequest request)
		{
			using (IDbContextScope scope = _dbContextScopeFactory.Create())
			{
				Release release = _releaseRepository.CreateReleaseForGame(gameId, request);
				scope.SaveChanges();
				return release;
			}
		}

		public Release GetRelease(Guid releaseId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _releaseRepository.GetRelease(releaseId);
			}
		}
	}
}