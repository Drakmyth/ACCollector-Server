using ACCollector_Server.Models;
using ACCollector_Server.Repositories;
using System.Collections.Generic;

namespace ACCollector_Server.Services
{
	public class GameService
	{
		private readonly GameRepository _gameRepository;

		public GameService(GameRepository gameRepository)
		{
			_gameRepository = gameRepository;
		}

		public IReadOnlyList<GameSummary> GetGameSummaries()
		{
			return null;
		}

		public Game CreateGame(CreateGameRequest request)
		{
			return _gameRepository.CreateGame(request).ToModel();
		}
	}
}