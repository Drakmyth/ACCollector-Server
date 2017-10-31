using System;

namespace ACCollector_Server.Models
{
	public class ReleaseSummary
	{
		public Guid ReleaseId { get; }
		public Guid GameId { get; }
		public string RegionCode { get; }

		public ReleaseSummary(Guid releaseId, Guid gameId, string regionCode)
		{
			ReleaseId = releaseId;
			GameId = gameId;
			RegionCode = regionCode;
		}

		public ReleaseSummary(ReleaseSummary copy) : this(copy.ReleaseId, copy.GameId, copy.RegionCode)
		{
		}
	}
}