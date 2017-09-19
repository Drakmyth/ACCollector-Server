using System;

namespace ACCollector_Server.Models
{
	public class ReleaseSummary
	{
		public Guid ReleaseId { get; }

		public Region Region { get; }

		public string Title { get; }

		public Platform Platform { get; }

		public DateTime ReleaseDate { get; }

		public ReleaseSummary(Guid releaseId, Region region, string title, Platform platform, DateTime releaseDate)
		{
			ReleaseId = releaseId;
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}

		public ReleaseSummary(ReleaseSummary copy)
			: this(copy.ReleaseId, copy.Region, copy.Title, copy.Platform, copy.ReleaseDate)
		{
		}
	}
}