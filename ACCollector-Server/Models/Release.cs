using System;

namespace ACCollector_Server.Models
{
	public class Release
	{
		public Region Region { get; }

		public string Title { get; }

		public Platform Platform { get; }

		public DateTime ReleaseDate { get; }

		public Release(Region region, string title, Platform platform, DateTime releaseDate)
		{
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}

		public Release(Release copy)
			: this(copy.Region, copy.Title, copy.Platform, copy.ReleaseDate)
		{
		}
	}
}