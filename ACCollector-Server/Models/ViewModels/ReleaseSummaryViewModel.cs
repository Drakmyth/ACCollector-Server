using ACCollector_Server.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class ReleaseSummaryViewModel
	{
		public Guid ReleaseId { get; }

		public Uri Href { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; }

		public string Title { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public Platform Platform { get; }

		[JsonConverter(typeof(DateConverter))]
		public DateTime ReleaseDate { get; }

		[JsonConstructor]
		public ReleaseSummaryViewModel(Guid releaseId, Uri href, Region region, string title, Platform platform, DateTime releaseDate)
		{
			ReleaseId = releaseId;
			Href = href;
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}

		public ReleaseSummaryViewModel(ReleaseSummaryViewModel copy)
			: this(copy.ReleaseId, copy.Href, copy.Region, copy.Title, copy.Platform, copy.ReleaseDate)
		{
		}

		public ReleaseSummaryViewModel(ReleaseSummary summary, Uri href)
			: this(summary.ReleaseId, href, summary.Region, summary.Title, summary.Platform, summary.ReleaseDate)
		{
		}
	}
}