using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ACCollector_Server.Controllers
{
	public static class ControllerExtensions
	{
		public static Uri GameUri(this IUrlHelper url, Guid gameId)
		{
			string location = url.RouteUrl(new
			{
				controller = "Game",
				action = "GetGame",
				gameId
			});

			return url.ToAbsoluteUri(location);
		}

		public static Uri ReleaseUri(this IUrlHelper url, Guid releaseId)
		{
			string location = url.RouteUrl(new
			{
				controller = "Release",
				action = "GetRelease",
				releaseId
			});

			return url.ToAbsoluteUri(location);
		}

		public static Uri BugUri(this IUrlHelper url, Guid bugId)
		{
			string location = url.RouteUrl(new
			{
				controller = "Bug",
				action = "GetBug",
				bugId
			});

			return url.ToAbsoluteUri(location);
		}

		private static Uri ToAbsoluteUri(this IUrlHelper url, string location)
		{
			HttpRequest request = url.ActionContext.HttpContext.Request;
			return new Uri($"{request.Scheme}://{request.Host}{location}");
		}
	}
}