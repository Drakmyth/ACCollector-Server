using ACCollector_Server.DataAccess.Repositories;
using ACCollector_Server.Models;
using ACCollector_Server.Models.Entities;
using EntityFramework.DbContextScope.Interfaces;
using System.Collections.Generic;

namespace ACCollector_Server.Services
{
	public class GameService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly GameRepository _gameRepository;

		public GameService(IDbContextScopeFactory dbContextScopeFactory, GameRepository gameRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_gameRepository = gameRepository;
		}

		public IReadOnlyList<GameSummary> GetGameSummaries()
		{
			return null;
		}

		public Game CreateGame(CreateGameRequest request)
		{
			using (IDbContextScope dbContextScope = _dbContextScopeFactory.Create())
			{
				GameEntity gameEntity = _gameRepository.CreateGame(request);
				dbContextScope.SaveChanges();
				return gameEntity.ToModel();
			}
		}
	}
}