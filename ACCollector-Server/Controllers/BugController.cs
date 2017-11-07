using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using ACCollector_Server.Models.ViewModels;
using ACCollector_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Controllers
{
	public class BugController : Controller
	{
		private readonly BugService _bugService;

		public BugController(BugService bugService)
		{
			_bugService = bugService;
		}

		[HttpGet("api/bugs")]
		public IActionResult GetBugSummaries()
		{
			IReadOnlyList<BugSummary> summaries = _bugService.GetBugSummaries();
			var views = new List<BugSummaryViewModel>();

			foreach (BugSummary summary in summaries)
			{
				Uri location = Url.BugUri(summary.BugId);
				views.Add(new BugSummaryViewModel(summary, location));
			}

			return Ok(views);
		}

		[HttpGet("api/bugs/{bugId}")]
		public IActionResult GetBug([FromRoute] Guid bugId)
		{
			Bug bug = _bugService.GetBug(bugId);
			Uri location = Url.BugUri(bug.BugId);
			return Ok(new BugViewModel(bug, location));
		}

		[HttpGet("api/games/{gameId}/bugs")]
		public IActionResult GetBugsForGame([FromRoute] Guid gameId)
		{
			IReadOnlyList<Bug> bugs = _bugService.GetBugsForGame(gameId);
			var views = new List<BugViewModel>();

			foreach (Bug bug in bugs)
			{
				Uri location = Url.BugUri(bug.BugId);
				views.Add(new BugViewModel(bug, location));
			}

			return Ok(views);
		}

		[HttpPost("api/games/{gameId}/bugs")]
		public IActionResult CreateBugForGame([FromRoute] Guid gameId, [FromBody] CreateBugRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Bug bug = _bugService.CreateBugForGame(gameId, request);
			Uri location = Url.BugUri(bug.BugId);
			return Created(location, new BugViewModel(bug, location));
		}
	}
}