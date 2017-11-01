using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	public class GameController : Controller
	{
		private readonly GameService _gameService;

		public GameController(GameService gameService)
		{
			_gameService = gameService;
		}

		[HttpGet("api/games")]
		public IActionResult GetGameSummaries([FromQuery] Region preferredRegion = Region.NA)
		{
			IReadOnlyList<GameSummary> summaries = _gameService.GetGameSummaries(preferredRegion);
			var views = new List<GameSummaryViewModel>();

			foreach (GameSummary summary in summaries)
			{
				Uri location = Url.GameUri(summary.GameId);
				views.Add(new GameSummaryViewModel(summary, location));
			}

			return Ok(views);
		}

		[HttpGet("api/games/{gameId}")]
		public IActionResult GetGame([FromRoute] Guid gameId)
		{
			Game game = _gameService.GetGame(gameId);
			Uri location = Url.GameUri(game.GameId);
			return Ok(new GameViewModel(game, location, Url.ReleaseUri));
		}

		[HttpPost("api/games")]
		public IActionResult CreateGame([FromBody] CreateGameRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Game game = _gameService.CreateGame(request);
			Uri location = Url.GameUri(game.GameId);
			return Created(location, new GameViewModel(game, location, Url.ReleaseUri));
		}
	}
}