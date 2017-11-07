using ACCollector_Server.Converters;
using Newtonsoft.Json;
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
		public Region Region { get; }

		[JsonProperty]
		public string Title { get; }

		[JsonProperty]
		public Platform Platform { get; }

		[JsonProperty]
		[JsonConverter(typeof(DateConverter))]
		public DateTime ReleaseDate { get; }

		public ReleaseViewModel(Release release, Uri href)
		{
			ReleaseId = release.ReleaseId;
			Href = href;
			GameId = release.GameId;
			Region = release.Region;
			Title = release.Title;
			Platform = release.Platform;
			ReleaseDate = release.ReleaseDate;
		}
	}
}