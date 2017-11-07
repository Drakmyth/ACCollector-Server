using System;

namespace ACCollector_Server.Models
{
	public class FishSummary
	{
		public Guid FishId { get; }
		public string Name { get; }

		public FishSummary(Guid fishId, string name)
		{
			FishId = fishId;
			Name = name;
		}
	}
}