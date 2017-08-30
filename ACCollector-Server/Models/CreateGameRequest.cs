using System.Collections.Generic;

namespace ACCollector_Server.Models
{
	public class CreateGameRequest
	{
		public string Name { get; set; }

		public List<Release> Releases { get; set; }

		public CreateGameRequest()
		{
			Releases = new List<Release>();
		}
	}
}