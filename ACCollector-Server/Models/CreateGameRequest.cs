using System.Collections.Generic;

namespace ACCollector_Server.Models
{
	public class CreateGameRequest
	{
		public List<Release> Releases { get; set; }

		public CreateGameRequest()
		{
			Releases = new List<Release>();
		}
	}
}