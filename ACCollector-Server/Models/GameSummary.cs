using System;

namespace ACCollector_Server.Models
{
	public class GameSummary
	{
		public Guid GameId { get; }
		public string Title { get; }

		public GameSummary(Guid gameId, string title)
		{
			GameId = gameId;
			Title = title;
		}
	}
}