using System;

namespace ACCollector_Server.Models
{
	public class GameSummary
	{
		public Guid GameId { get; }
		public string Name { get; }
		public string Title { get; }

		public GameSummary(Guid gameId, string name, string title)
		{
			GameId = gameId;
			Name = name;
			Title = title;
		}

		public GameSummary(GameSummary copy) : this(copy.GameId, copy.Name, copy.Title)
		{
		}
	}
}