using Newtonsoft.Json;
using System.Collections.Generic;

namespace ACCollector_Server.Models.Requests
{
	public class CreateGameRequest
	{
		public string Name { get; }

		public List<CreateReleaseRequest> Releases { get; }

		[JsonConstructor]
		public CreateGameRequest(string name, IEnumerable<CreateReleaseRequest> releases)
		{
			Name = name;
			Releases = new List<CreateReleaseRequest>(releases);
		}

		public CreateGameRequest(CreateGameRequest copy) : this(copy.Name, copy.Releases.AsReadOnly())
		{
		}
	}
}