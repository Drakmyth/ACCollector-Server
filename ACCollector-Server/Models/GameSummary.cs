using System;

namespace ACCollector_Server.Models
{
	public class GameSummary
	{
		public Guid Id { get; }
		public string Title { get; }

		public GameSummary(Guid id, string title)
		{
			Id = id;
			Title = title;
		}

		public GameSummary(GameSummary copy) : this(copy.Id, copy.Title)
		{
		}
	}
}