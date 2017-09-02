using System.Collections.Generic;

namespace ACCollector_Server.Models.Requests
{
	public class CreateGameRequest
	{
		public string Name { get; set; }

		public List<CreateReleaseRequest> Releases { get; set; }

		public CreateGameRequest()
		{
			Releases = new List<CreateReleaseRequest>();
		}
	}
}