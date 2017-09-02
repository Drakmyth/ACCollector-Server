using ACCollector_Server.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ACCollector_Server.Models.Requests
{
	public class CreateReleaseRequest
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; }

		public string Title { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public Platform Platform { get; }

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

		public CreateReleaseRequest(CreateReleaseRequest copy)
			: this(copy.Region, copy.Title, copy.Platform, copy.ReleaseDate)
		{
		}
	}
}