using System;

namespace ACCollector_Server.Models
{
	public class Release
	{
		public Guid ReleaseId { get; }
		public Guid GameId { get; }
		public Region Region { get; }
		public string Title { get; }
		public Platform Platform { get; }
		public DateTime ReleaseDate { get; }

		public Release(Guid releaseId, Guid gameId, Region region, string title, Platform platform, DateTime releaseDate)
		{
			ReleaseId = releaseId;
			GameId = gameId;
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}

		public Release(Release copy) : this(copy.ReleaseId, copy.GameId, copy.Region, copy.Title, copy.Platform, copy.ReleaseDate)
		{
		}
	}
}