using ACCollector_Server.DataAccess.Repositories;
using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Services
{
	public class FishService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly FishRepository _fishRepository;

		public FishService(IDbContextScopeFactory dbContextScopeFactory, FishRepository fishRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_fishRepository = fishRepository;
		}

		public IReadOnlyList<FishSummary> GetFishSummaries()
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _fishRepository.GetFishSummaries();
			}
		}

		public Fish CreateFishForGame(Guid gameId, CreateFishRequest request)
		{
			using (IDbContextScope scope = _dbContextScopeFactory.Create())
			{
				Fish fish = _fishRepository.CreateFishForGame(gameId, request);
				scope.SaveChanges();
				return fish;
			}
		}

		public IReadOnlyList<Fish> GetFishForGame(Guid gameId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _fishRepository.GetFishForGame(gameId);
			}
		}

		public Fish GetFish(Guid fishId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _fishRepository.GetFish(fishId);
			}
		}
	}
}