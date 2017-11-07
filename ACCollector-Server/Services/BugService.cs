using ACCollector_Server.DataAccess.Repositories;
using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Services
{
	[UsedImplicitly]
	public class BugService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly BugRepository _bugRepository;

		public BugService(IDbContextScopeFactory dbContextScopeFactory, BugRepository bugRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_bugRepository = bugRepository;
		}

		public IReadOnlyList<BugSummary> GetBugSummaries()
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _bugRepository.GetBugSummaries();
			}
		}

		public Bug CreateBugForGame(Guid gameId, CreateBugRequest request)
		{
			using (IDbContextScope scope = _dbContextScopeFactory.Create())
			{
				Bug bug = _bugRepository.CreateBugForGame(gameId, request);
				scope.SaveChanges();
				return bug;
			}
		}

		public IReadOnlyList<Bug> GetBugsForGame(Guid gameId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _bugRepository.GetBugsForGame(gameId);
			}
		}

		public Bug GetBug(Guid bugId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _bugRepository.GetBug(bugId);
			}
		}
	}
}