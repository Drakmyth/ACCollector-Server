using System.Collections.Generic;

namespace ACCollector_Server.Models.Entities
{
	public class GameEntity
	{
		public string Id { get; set; }

		public List<string> Releases { get; set; }
	}
}