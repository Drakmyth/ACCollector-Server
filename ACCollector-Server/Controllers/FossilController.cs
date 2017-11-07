using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	public class FossilController : Controller
	{
		private readonly FossilService _fossilService;

		public FossilController(FossilService fossilService)
		{
			_fossilService = fossilService;
		}

		[HttpGet("api/fossils")]
		public IActionResult GetFossilSummaries()
		{
			IReadOnlyList<FossilSummary> summaries = _fossilService.GetFossilSummaries();
			var views = new List<FossilSummaryViewModel>();

			foreach (FossilSummary summary in summaries)
			{
				Uri location = Url.FossilUri(summary.FossilId);
				views.Add(new FossilSummaryViewModel(summary, location));
			}

			return Ok(views);
		}

		[HttpGet("api/fossils/{fossilId}")]
		public IActionResult GetFossil([FromRoute] Guid fossilId)
		{
			Fossil fossil = _fossilService.GetFossil(fossilId);
			Uri location = Url.FossilUri(fossil.FossilId);
			return Ok(new FossilViewModel(fossil, location));
		}

		[HttpGet("api/games/{gameId}/fossils")]
		public IActionResult GetFossilForGame([FromRoute] Guid gameId)
		{
			IReadOnlyList<Fossil> fossils = _fossilService.GetFossilForGame(gameId);
			var views = new List<FossilViewModel>();

			foreach (Fossil fossil in fossils)
			{
				Uri location = Url.FossilUri(fossil.FossilId);
				views.Add(new FossilViewModel(fossil, location));
			}

			return Ok(views);
		}

		[HttpPost("api/games/{gameId}/fossils")]
		public IActionResult CreateFossilForGame([FromRoute] Guid gameId, [FromBody] CreateFossilRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Fossil fossil = _fossilService.CreateFossilForGame(gameId, request);
			Uri location = Url.FossilUri(fossil.FossilId);
			return Created(location, new FossilViewModel(fossil, location));
		}
	}
}