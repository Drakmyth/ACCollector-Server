using ACCollector_Server.DataAccess.Repositories;
using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using System;

namespace ACCollector_Server.Services
{
	[UsedImplicitly]
	public class ReleaseService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly ReleaseRepository _releaseRepository;

		public ReleaseService(IDbContextScopeFactory dbContextScopeFactory, ReleaseRepository releaseRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_releaseRepository = releaseRepository;
		}

		public Release CreateRelease(CreateReleaseRequest request)
		{
			using (IDbContextScope scope = _dbContextScopeFactory.Create())
			{
				Release release = _releaseRepository.CreateRelease(request);
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