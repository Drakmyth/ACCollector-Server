using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class GameSummaryViewModel
	{
		[JsonProperty]
		public Guid GameId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public string Title { get; }

		public GameSummaryViewModel(GameSummary summary, Uri href)
		{
			GameId = summary.GameId;
			Href = href;
			Title = summary.Title;
		}
	}
}