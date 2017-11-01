using System;

namespace ACCollector_Server.Models
{
	public class ReleaseSummary
	{
		public Guid ReleaseId { get; }
		public Region Region { get; }
		public string Title { get; }

		public ReleaseSummary(Guid releaseId, Region region, string title)
		{
			ReleaseId = releaseId;
			Region = region;
			Title = title;
		}
	}
}