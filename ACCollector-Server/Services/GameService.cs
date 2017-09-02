using ACCollector_Server.DataAccess.Repositories;
using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace ACCollector_Server.Services
{
	[UsedImplicitly]
	public class GameService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly GameRepository _gameRepository;

		public GameService(IDbContextScopeFactory dbContextScopeFactory, GameRepository gameRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_gameRepository = gameRepository;
		}

		public IReadOnlyList<GameSummary> GetGameSummaries(Region preferredRegion)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _gameRepository.GetGameSummaries(preferredRegion);
			}
		}

		public Game CreateGame(CreateGameRequest request)
		{
			using (IDbContextScope scope = _dbContextScopeFactory.Create())
			{
				Game game = _gameRepository.CreateGame(request);
				scope.SaveChanges();
				return game;
			}
		}
	}
}