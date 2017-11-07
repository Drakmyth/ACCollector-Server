using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	public class FishController : Controller
	{
		private readonly FishService _fishService;

		public FishController(FishService fishService)
		{
			_fishService = fishService;
		}

		[HttpGet("api/fish")]
		public IActionResult GetFishSummaries()
		{
			IReadOnlyList<FishSummary> summaries = _fishService.GetFishSummaries();
			var views = new List<FishSummaryViewModel>();

			foreach (FishSummary summary in summaries)
			{
				Uri location = Url.FishUri(summary.FishId);
				views.Add(new FishSummaryViewModel(summary, location));
			}

			return Ok(views);
		}

		[HttpGet("api/fish/{fishId}")]
		public IActionResult GetFish([FromRoute] Guid fishId)
		{
			Fish fish = _fishService.GetFish(fishId);
			Uri location = Url.FishUri(fish.FishId);
			return Ok(new FishViewModel(fish, location));
		}

		[HttpGet("api/games/{gameId}/fish")]
		public IActionResult GetFishForGame([FromRoute] Guid gameId)
		{
			IReadOnlyList<Fish> fishes = _fishService.GetFishForGame(gameId);
			var views = new List<FishViewModel>();

			foreach (Fish fish in fishes)
			{
				Uri location = Url.FishUri(fish.FishId);
				views.Add(new FishViewModel(fish, location));
			}

			return Ok(views);
		}

		[HttpPost("api/games/{gameId}/fish")]
		public IActionResult CreateFishForGame([FromRoute] Guid gameId, [FromBody] CreateFishRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Fish fish = _fishService.CreateFishForGame(gameId, request);
			Uri location = Url.FishUri(fish.FishId);
			return Created(location, new FishViewModel(fish, location));
		}
	}
}