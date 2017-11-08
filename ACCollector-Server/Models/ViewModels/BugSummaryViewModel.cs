using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class BugSummaryViewModel
	{
		[JsonProperty]
		public Guid BugId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public int InGameId { get; }

		[JsonProperty]
		public string Name { get; }

		public BugSummaryViewModel(BugSummary summary, Uri href)
		{
			BugId = summary.BugId;
			Href = href;
			InGameId = summary.InGameId;
			Name = summary.Name;
		}
	}
}