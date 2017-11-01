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

		private static Uri ToAbsoluteUri(this IUrlHelper url, string location)
		{
			HttpRequest request = url.ActionContext.HttpContext.Request;
			return new Uri($"{request.Scheme}://{request.Host}{location}");
		}
	}
}