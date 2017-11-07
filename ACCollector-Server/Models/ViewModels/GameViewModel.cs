using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models.ViewModels
{
	public class GameViewModel
	{
		[JsonProperty]
		public Guid GameId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public string Name { get; }

		private readonly List<ReleaseViewModel> _releases;

		[JsonProperty]
		public IReadOnlyList<ReleaseViewModel> Releases => _releases.AsReadOnly();

		public GameViewModel(Game game, Uri href, Func<Guid, Uri> releaseUriGenerator)
		{
			GameId = game.GameId;
			Href = href;
			Name = game.Name;
			_releases = game.Releases.Select(release => new ReleaseViewModel(release, releaseUriGenerator(release.ReleaseId))).ToList();
		}
	}
}