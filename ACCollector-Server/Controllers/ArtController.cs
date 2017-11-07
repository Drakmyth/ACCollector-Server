using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	public class ArtController : Controller
	{
		private readonly ArtService _artService;

		public ArtController(ArtService artService)
		{
			_artService = artService;
		}

		[HttpGet("api/art")]
		public IActionResult GetArtSummaries()
		{
			IReadOnlyList<ArtSummary> summaries = _artService.GetArtSummaries();
			var views = new List<ArtSummaryViewModel>();

			foreach (ArtSummary summary in summaries)
			{
				Uri location = Url.ArtUri(summary.ArtId);
				views.Add(new ArtSummaryViewModel(summary, location));
			}

			return Ok(views);
		}

		[HttpGet("api/art/{artId}")]
		public IActionResult GetArt([FromRoute] Guid artId)
		{
			Art art = _artService.GetArt(artId);
			Uri location = Url.ArtUri(art.ArtId);
			return Ok(new ArtViewModel(art, location));
		}

		[HttpGet("api/games/{gameId}/art")]
		public IActionResult GetArtForGame([FromRoute] Guid gameId)
		{
			IReadOnlyList<Art> arts = _artService.GetArtForGame(gameId);
			var views = new List<ArtViewModel>();

			foreach (Art art in arts)
			{
				Uri location = Url.ArtUri(art.ArtId);
				views.Add(new ArtViewModel(art, location));
			}

			return Ok(views);
		}

		[HttpPost("api/games/{gameId}/art")]
		public IActionResult CreateArtForGame([FromRoute] Guid gameId, [FromBody] CreateArtRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Art art = _artService.CreateArtForGame(gameId, request);
			Uri location = Url.ArtUri(art.ArtId);
			return Created(location, new ArtViewModel(art, location));
		}
	}
}