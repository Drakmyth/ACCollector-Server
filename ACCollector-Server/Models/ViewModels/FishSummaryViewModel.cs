using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class FishSummaryViewModel
	{
		[JsonProperty]
		public Guid FishId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public int InGameId { get; }

		[JsonProperty]
		public string Name { get; }

		public FishSummaryViewModel(FishSummary summary, Uri href)
		{
			FishId = summary.FishId;
			Href = href;
			InGameId = summary.InGameId;
			Name = summary.Name;
		}
	}
}