using System;

namespace ACCollector_Server.Models
{
	public class DeepSeaCreatureSummary
	{
		public Guid DeepSeaCreatureId { get; }
		public string Name { get; }

		public DeepSeaCreatureSummary(Guid deepSeaCreatureId, string name)
		{
			DeepSeaCreatureId = deepSeaCreatureId;
			Name = name;
		}
	}
}