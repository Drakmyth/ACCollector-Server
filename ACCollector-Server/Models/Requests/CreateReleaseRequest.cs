using ACCollector_Server.Converters;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateReleaseRequest
	{
		[Required]
		public Region Region { get; }

		[Required]
		public string Title { get; }

		[Required]
		public Platform Platform { get; }

		[Required]
		[JsonConverter(typeof(DateConverter))]
		public DateTime ReleaseDate { get; }

		[JsonConstructor]
		public CreateReleaseRequest(Region region, string title, Platform platform, DateTime releaseDate)
		{
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}
	}
}