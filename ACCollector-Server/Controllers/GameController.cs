using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
		public IActionResult GetGameSummaries()
		{
			throw new NotImplementedException();
		}

		// GET api/games/5
		[HttpGet("{gameId}")]
		public IActionResult GetGame(string gameId)
		{
			throw new NotImplementedException();
		}

		// POST api/games
		[HttpPost]
		public IActionResult CreateGame([FromBody] CreateGameRequest request)
		{
			Game game = _gameService.CreateGame(request);
			string location = Url.Action(nameof(GetGame), new {gameId = game.GameId});
			var temp = Url.ActionContext.HttpContext.Request;
			var locationUri = new Uri($"{temp.Scheme}://{temp.Host}{location}");
			return Created(locationUri, new GameViewModel(game, locationUri));
		}

		// PUT api/games/5
		[HttpPut("{gameId}")]
		public IActionResult UpdateGame(int gameId, [FromBody] GameViewModel game)
		{
			throw new NotImplementedException();
		}

		// DELETE api/games/5
		[HttpDelete("{gameId}")]
		public void DeleteGame(int gameId)
		{
			throw new NotImplementedException();
		}
	}
}