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
	public class FossilService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly FossilRepository _fossilRepository;

		public FossilService(IDbContextScopeFactory dbContextScopeFactory, FossilRepository fossilRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_fossilRepository = fossilRepository;
		}

		public IReadOnlyList<FossilSummary> GetFossilSummaries()
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _fossilRepository.GetFossilSummaries();
			}
		}

		public Fossil CreateFossilForGame(Guid gameId, CreateFossilRequest request)
		{
			using (IDbContextScope scope = _dbContextScopeFactory.Create())
			{
				Fossil fossil = _fossilRepository.CreateFossilForGame(gameId, request);
				scope.SaveChanges();
				return fossil;
			}
		}

		public IReadOnlyList<Fossil> GetFossilForGame(Guid gameId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _fossilRepository.GetFossilForGame(gameId);
			}
		}

		public Fossil GetFossil(Guid fossilId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _fossilRepository.GetFossil(fossilId);
			}
		}
	}
}