using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class ArtSummaryViewModel
	{
		[JsonProperty]
		public Guid ArtId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public string Name { get; }

		[JsonProperty]
		public ArtType Type { get; }

		public ArtSummaryViewModel(ArtSummary summary, Uri href)
		{
			ArtId = summary.ArtId;
			Href = href;
			Name = summary.Name;
			Type = summary.Type;
		}
	}
}