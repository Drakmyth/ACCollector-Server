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

		public ReleaseSummaryViewModel(ReleaseSummary summary, Uri href)
		{
			ReleaseId = summary.ReleaseId;
			Href = href;
			Region = summary.Region;
			Title = summary.Title;
		}
	}
}