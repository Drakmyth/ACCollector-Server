using Newtonsoft.Json;

namespace ACCollector_Server.Models
{
	public class Release
	{
		public Region Region { get; }
		public string Title { get; }
		public Platform Platform { get; }
		public string ReleaseDate { get; }

		[JsonConstructor]
		public Release(Region region, string title, Platform platform, string releaseDate)
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