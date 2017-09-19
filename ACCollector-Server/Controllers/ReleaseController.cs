using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ACCollector_Server.Controllers
{
	[Route("api/releases")]
	public class ReleaseController : Controller
	{
		private readonly ReleaseService _releaseService;

		public ReleaseController(ReleaseService releaseService)
		{
			_releaseService = releaseService;
		}

		// GET api/releases
//		[HttpGet]
//		public IActionResult GetGameSummaries(Region preferredRegion = Region.NA)
//		{
//			IReadOnlyList<GameSummary> summaries = _releaseService.GetGameSummaries(preferredRegion);
//			var views = new List<GameSummaryViewModel>();
//
//			foreach (GameSummary summary in summaries)
//			{
//				Uri location = Url.ActionUri(nameof(GetGame), new {gameId = summary.GameId});
//				views.Add(new GameSummaryViewModel(summary, location));
//			}
//
//			return Ok(views);
//		}

		// GET api/releases/5
		[HttpGet("{releaseId}")]
		public IActionResult GetRelease(Guid releaseId)
		{
			Release release = _releaseService.GetRelease(releaseId);
			Uri location = Url.ActionUri(nameof(GetRelease), new {releaseId = release.ReleaseId});
			return Ok(new ReleaseViewModel(release, location));
		}

		// POST api/releases
		[HttpPost]
		public IActionResult CreateRelease([FromBody] CreateReleaseRequest request)
		{
			Release release = _releaseService.CreateRelease(request);
			Uri location = Url.ActionUri(nameof(GetRelease), new {releaseId = release.ReleaseId});
			return Created(location, new ReleaseViewModel(release, location));
		}
	}
}