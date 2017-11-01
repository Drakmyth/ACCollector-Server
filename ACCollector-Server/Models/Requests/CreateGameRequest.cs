using Newtonsoft.Json;
using System.Collections.Generic;

namespace ACCollector_Server.Models.Requests
{
	public class CreateGameRequest
	{
		public string Name { get; }

		private readonly List<CreateReleaseRequest> _releases;
		public IReadOnlyList<CreateReleaseRequest> Releases => _releases.AsReadOnly();

		[JsonConstructor]
		public CreateGameRequest(string name, IEnumerable<CreateReleaseRequest> releases)
		{
			Name = name;
			_releases = new List<CreateReleaseRequest>(releases);
		}
	}
}