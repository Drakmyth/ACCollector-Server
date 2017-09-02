using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class GameSummaryViewModel
	{
		public Guid GameId { get; }
		public Uri Href { get; }
		public string Name { get; }
		public string Title { get; }

		public GameSummaryViewModel(Guid gameId, Uri href, string name, string title)
		{
			GameId = gameId;
			Href = href;
			Name = name;
			Title = title;
		}

		public GameSummaryViewModel(GameSummaryViewModel copy) : this(copy.GameId, copy.Href, copy.Name, copy.Title)
		{
		}

		public GameSummaryViewModel(GameSummary summary, Uri href) : this(summary.GameId, href, summary.Name, summary.Title)
		{
		}
	}
}