using System;

namespace ACCollector_Server.Models
{
	public class GameSummary
	{
		public string Id { get; }
		public Uri Href { get; }
		public string Title { get; }

		public GameSummary(string id, Uri href, string title)
		{
			Id = id;
			Href = href;
			Title = title;
		}

		public GameSummary(GameSummary copy) : this(copy.Id, copy.Href, copy.Title)
		{
		}
	}
}