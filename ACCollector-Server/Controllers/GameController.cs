using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	[Route("api/games")]
	public class GameController : Controller
	{
		private readonly GameService _gameService;

		public GameController(GameService gameService)
		{
			_gameService = gameService;
		}

		// GET api/games
		[HttpGet]
		public IActionResult GetGameSummaries(Region preferredRegion = Region.NA)
		{
			IReadOnlyList<GameSummary> summaries = _gameService.GetGameSummaries(preferredRegion);
			var views = new List<GameSummaryViewModel>();

			foreach (GameSummary summary in summaries)
			{
				Uri location = Url.ActionUri(nameof(GetGame), new {gameId = summary.GameId});
				views.Add(new GameSummaryViewModel(summary, location));
			}

			return Ok(views);
		}

		// GET api/games/5
		[HttpGet("{gameId}")]
		public IActionResult GetGame(Guid gameId)
		{
			Game game = _gameService.GetGame(gameId);
			Uri location = Url.ActionUri(nameof(GetGame), new {gameId = game.GameId});
			return Ok(new GameViewModel(game, location));
		}

		// POST api/games
		[HttpPost]
		public IActionResult CreateGame([FromBody] CreateGameRequest request)
		{
			Game game = _gameService.CreateGame(request);
			Uri location = Url.ActionUri(nameof(GetGame), new {gameId = game.GameId});
			return Created(location, new GameViewModel(game, location));
		}

		// PUT api/games/5
		[HttpPut("{gameId}")]
		public IActionResult UpdateGame(Guid gameId, [FromBody] GameViewModel game)
		{
			throw new NotImplementedException();
		}

		// DELETE api/games/5
		[HttpDelete("{gameId}")]
		public void DeleteGame(Guid gameId)
		{
			throw new NotImplementedException();
		}
	}
}