using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class FossilSummaryViewModel
	{
		[JsonProperty]
		public Guid FossilId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public string Name { get; }

		[JsonProperty]
		public FossilGroup Group { get; }

		public FossilSummaryViewModel(FossilSummary summary, Uri href)
		{
			FossilId = summary.FossilId;
			Href = href;
			Name = summary.Name;
			Group = summary.Group;
		}
	}
}