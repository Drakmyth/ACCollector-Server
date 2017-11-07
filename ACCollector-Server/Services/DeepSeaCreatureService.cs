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
	public class DeepSeaCreatureService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly DeepSeaCreatureRepository _deepSeaCreatureRepository;

		public DeepSeaCreatureService(IDbContextScopeFactory dbContextScopeFactory, DeepSeaCreatureRepository deepSeaCreatureRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_deepSeaCreatureRepository = deepSeaCreatureRepository;
		}

		public IReadOnlyList<DeepSeaCreatureSummary> GetDeepSeaCreatureSummaries()
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _deepSeaCreatureRepository.GetDeepSeaCreatureSummaries();
			}
		}

		public DeepSeaCreature CreateDeepSeaCreatureForGame(Guid gameId, CreateDeepSeaCreatureRequest request)
		{
			using (IDbContextScope scope = _dbContextScopeFactory.Create())
			{
				DeepSeaCreature deepSeaCreature = _deepSeaCreatureRepository.CreateDeepSeaCreatureForGame(gameId, request);
				scope.SaveChanges();
				return deepSeaCreature;
			}
		}

		public IReadOnlyList<DeepSeaCreature> GetDeepSeaCreatureForGame(Guid gameId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _deepSeaCreatureRepository.GetDeepSeaCreatureForGame(gameId);
			}
		}

		public DeepSeaCreature GetDeepSeaCreature(Guid deepSeaCreatureId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _deepSeaCreatureRepository.GetDeepSeaCreature(deepSeaCreatureId);
			}
		}
	}
}