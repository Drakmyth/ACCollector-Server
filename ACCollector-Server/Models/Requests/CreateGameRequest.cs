using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateGameRequest
	{
		[Required(ErrorMessage = "Name is required.")]
		public string Name { get; }

		private readonly List<CreateReleaseRequest> _releases;

		[MinLength(1, ErrorMessage = "Games must have at least 1 release.")]
		public IReadOnlyList<CreateReleaseRequest> Releases => _releases.AsReadOnly();

		[JsonConstructor]
		public CreateGameRequest(string name, IEnumerable<CreateReleaseRequest> releases)
		{
			Name = name;
			_releases = new List<CreateReleaseRequest>(releases);
		}
	}
}