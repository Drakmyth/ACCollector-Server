using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class ReleaseSummaryViewModel
	{
		[JsonProperty]
		public Guid ReleaseId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public Region Region { get; }

		[JsonProperty]
		public string Title { get; }

		private ReleaseSummaryViewModel(Guid releaseId, Uri href, Region region, string title)
		{
			ReleaseId = releaseId;
			Href = href;
			Region = region;
			Title = title;
		}

		public ReleaseSummaryViewModel(ReleaseSummary summary, Uri href) : this(summary.ReleaseId, href, summary.Region, summary.Title)
		{
		}
	}
}