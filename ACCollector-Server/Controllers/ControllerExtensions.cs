using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ACCollector_Server.Controllers
{
	public static class ControllerExtensions
	{
		public static Uri ActionUri(this IUrlHelper url, string action, object values)
		{
			string location = url.Action(action, values);
			HttpRequest request = url.ActionContext.HttpContext.Request;
			return new Uri($"{request.Scheme}://{request.Host}{location}");
		}
	}
}