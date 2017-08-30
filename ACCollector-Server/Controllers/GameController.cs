using ACCollector_Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	[Route("api/[controller]")]
	public class GameController : Controller
	{
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
		public Game CreateGame([FromBody] CreateGameRequest request)
		{
			throw new NotImplementedException();
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