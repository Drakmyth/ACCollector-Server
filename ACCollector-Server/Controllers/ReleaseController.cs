using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	public class ReleaseController : Controller
	{
		private readonly ReleaseService _releaseService;

		public ReleaseController(ReleaseService releaseService)
		{
			_releaseService = releaseService;
		}

		[HttpGet("api/releases")]
		public IActionResult GetReleaseSummaries()
		{
			IReadOnlyList<ReleaseSummary> summaries = _releaseService.GetReleaseSummaries();
			var views = new List<ReleaseSummaryViewModel>();

			foreach (ReleaseSummary summary in summaries)
			{
				Uri location = Url.ReleaseUri(summary.ReleaseId);
				views.Add(new ReleaseSummaryViewModel(summary, location));
			}

			return Ok(views);
		}

		[HttpGet("api/releases/{releaseId}")]
		public IActionResult GetRelease([FromRoute] Guid releaseId)
		{
			Release release = _releaseService.GetRelease(releaseId);
			Uri location = Url.ReleaseUri(release.ReleaseId);
			return Ok(new ReleaseViewModel(release, location));
		}

		[HttpGet("api/games/{gameId}/releases")]
		public IActionResult GetReleasesForGame([FromRoute] Guid gameId)
		{
			IReadOnlyList<Release> releases = _releaseService.GetReleasesForGame(gameId);
			var views = new List<ReleaseViewModel>();

			foreach (Release release in releases)
			{
				Uri location = Url.ReleaseUri(release.ReleaseId);
				views.Add(new ReleaseViewModel(release, location));
			}

			return Ok(views);
		}

		[HttpPost("api/games/{gameId}/releases")]
		public IActionResult CreateRelease([FromRoute] Guid gameId, [FromBody] CreateReleaseRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Release release = _releaseService.CreateReleaseForGame(gameId, request);
			Uri location = Url.ReleaseUri(release.ReleaseId);
			return Created(location, new ReleaseViewModel(release, location));
		}
	}
}