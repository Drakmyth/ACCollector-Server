using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class GameSummaryViewModel
	{
		public Guid Id { get; }
		public Uri Href { get; }
		public string Title { get; }

		public GameSummaryViewModel(Guid id, Uri href, string title)
		{
			Id = id;
			Href = href;
			Title = title;
		}

		public GameSummaryViewModel(GameSummaryViewModel copy) : this(copy.Id, copy.Href, copy.Title)
		{
		}
	}
}