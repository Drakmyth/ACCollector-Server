using ACCollector_Server.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class ReleaseViewModel
	{
		[JsonProperty]
		public Guid ReleaseId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public Guid GameId { get; }

		[JsonProperty]
		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; }

		[JsonProperty]
		public string Title { get; }

		[JsonProperty]
		public Platform Platform { get; }

		[JsonProperty]
		[JsonConverter(typeof(DateConverter))]
		public DateTime ReleaseDate { get; }

		private ReleaseViewModel(Guid releaseId, Uri href, Guid gameId, Region region, string title, Platform platform, DateTime releaseDate)
		{
			ReleaseId = releaseId;
			Href = href;
			GameId = gameId;
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}

		public ReleaseViewModel(Release release, Uri href) : this(release.ReleaseId, href, release.GameId, release.Region, release.Title, release.Platform, release.ReleaseDate)
		{
		}
	}
}