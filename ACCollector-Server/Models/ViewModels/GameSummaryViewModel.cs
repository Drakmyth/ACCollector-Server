using System;
using Newtonsoft.Json;

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

		private GameSummaryViewModel(Guid gameId, Uri href, string title)
		{
			GameId = gameId;
			Href = href;
			Title = title;
		}

		public GameSummaryViewModel(GameSummary summary, Uri href) : this(summary.GameId, href, summary.Title)
		{
		}
	}
}