using System;

namespace ACCollector_Server.Models
{
	public class FishSummary
	{
		public Guid FishId { get; }
		public int InGameId { get; }
		public string Name { get; }

		public FishSummary(Guid fishId, int inGameId, string name)
		{
			FishId = fishId;
			InGameId = inGameId;
			Name = name;
		}
	}
}