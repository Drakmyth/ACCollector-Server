using System;

namespace ACCollector_Server.Models
{
	public class FossilSummary
	{
		public Guid FossilId { get; }
		public string Name { get; }
		public FossilGroup Group { get; }

		public FossilSummary(Guid fossilId, string name, FossilGroup group)
		{
			FossilId = fossilId;
			Name = name;
			Group = group;
		}
	}
}