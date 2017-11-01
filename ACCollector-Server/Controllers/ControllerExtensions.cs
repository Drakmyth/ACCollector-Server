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

			return BuildUri(url, location);
		}

		private static Uri BuildUri(IUrlHelper url, string location)
		{
			HttpRequest request = url.ActionContext.HttpContext.Request;
			return new Uri($"{request.Scheme}://{request.Host}{location}");
		}
	}
}