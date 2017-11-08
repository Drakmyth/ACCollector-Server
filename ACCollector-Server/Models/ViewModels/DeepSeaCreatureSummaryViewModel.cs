using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class DeepSeaCreatureSummaryViewModel
	{
		[JsonProperty]
		public Guid DeepSeaCreatureId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public int InGameId { get; }

		[JsonProperty]
		public string Name { get; }

		public DeepSeaCreatureSummaryViewModel(DeepSeaCreatureSummary summary, Uri href)
		{
			DeepSeaCreatureId = summary.DeepSeaCreatureId;
			Href = href;
			InGameId = summary.InGameId;
			Name = summary.Name;
		}
	}
}