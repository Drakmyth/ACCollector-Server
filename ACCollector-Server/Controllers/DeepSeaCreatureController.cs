using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	public class DeepSeaCreatureController : Controller
	{
		private readonly DeepSeaCreatureService _deepSeaCreatureService;

		public DeepSeaCreatureController(DeepSeaCreatureService deepSeaCreatureService)
		{
			_deepSeaCreatureService = deepSeaCreatureService;
		}

		[HttpGet("api/deepseacreatures")]
		public IActionResult GetDeepSeaCreatureSummaries()
		{
			IReadOnlyList<DeepSeaCreatureSummary> summaries = _deepSeaCreatureService.GetDeepSeaCreatureSummaries();
			var views = new List<DeepSeaCreatureSummaryViewModel>();

			foreach (DeepSeaCreatureSummary summary in summaries)
			{
				Uri location = Url.DeepSeaCreatureUri(summary.DeepSeaCreatureId);
				views.Add(new DeepSeaCreatureSummaryViewModel(summary, location));
			}

			return Ok(views);
		}

		[HttpGet("api/deepseacreatures/{deepSeaCreatureId}")]
		public IActionResult GetDeepSeaCreature([FromRoute] Guid deepSeaCreatureId)
		{
			DeepSeaCreature deepSeaCreature = _deepSeaCreatureService.GetDeepSeaCreature(deepSeaCreatureId);
			Uri location = Url.DeepSeaCreatureUri(deepSeaCreature.DeepSeaCreatureId);
			return Ok(new DeepSeaCreatureViewModel(deepSeaCreature, location));
		}

		[HttpGet("api/games/{gameId}/deepseacreatures")]
		public IActionResult GetDeepSeaCreatureForGame([FromRoute] Guid gameId)
		{
			IReadOnlyList<DeepSeaCreature> deepSeaCreaturees = _deepSeaCreatureService.GetDeepSeaCreatureForGame(gameId);
			var views = new List<DeepSeaCreatureViewModel>();

			foreach (DeepSeaCreature deepSeaCreature in deepSeaCreaturees)
			{
				Uri location = Url.DeepSeaCreatureUri(deepSeaCreature.DeepSeaCreatureId);
				views.Add(new DeepSeaCreatureViewModel(deepSeaCreature, location));
			}

			return Ok(views);
		}

		[HttpPost("api/games/{gameId}/deepseacreatures")]
		public IActionResult CreateDeepSeaCreatureForGame([FromRoute] Guid gameId, [FromBody] CreateDeepSeaCreatureRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			DeepSeaCreature deepSeaCreature = _deepSeaCreatureService.CreateDeepSeaCreatureForGame(gameId, request);
			Uri location = Url.DeepSeaCreatureUri(deepSeaCreature.DeepSeaCreatureId);
			return Created(location, new DeepSeaCreatureViewModel(deepSeaCreature, location));
		}
	}
}