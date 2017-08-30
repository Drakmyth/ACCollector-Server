using ACCollector_Server.Models;
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
		public IEnumerable<GameSummary> GetGameSummaries()
		{
			throw new NotImplementedException();
		}

		// GET api/games/5
		[HttpGet("{id}")]
		public Game GetGame(string id)
		{
			throw new NotImplementedException();
		}

		// POST api/games
		[HttpPost]
		public IActionResult CreateGame([FromBody] CreateGameRequest request)
		{
			return Created("stuff", _gameService.CreateGame(request));
		}

		// PUT api/games/5
		[HttpPut("{id}")]
		public Game UpdateGame(int id, [FromBody] Game game)
		{
			throw new NotImplementedException();
		}

		// DELETE api/games/5
		[HttpDelete("{id}")]
		public void DeleteGame(int id)
		{
			throw new NotImplementedException();
		}
	}
}