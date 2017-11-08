using System;

namespace ACCollector_Server.Models
{
	public class DeepSeaCreatureSummary
	{
		public Guid DeepSeaCreatureId { get; }
		public int InGameId { get; }
		public string Name { get; }

		public DeepSeaCreatureSummary(Guid deepSeaCreatureId, int inGameId, string name)
		{
			DeepSeaCreatureId = deepSeaCreatureId;
			InGameId = inGameId;
			Name = name;
		}
	}
}