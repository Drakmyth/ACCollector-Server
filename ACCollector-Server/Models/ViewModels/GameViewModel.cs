using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

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

		private GameViewModel(Guid gameId, Uri href, string name)
		{
			GameId = gameId;
			Href = href;
			Name = name;
			_releases = new List<ReleaseViewModel>();
		}

		public GameViewModel(Game game, Uri href) : this(game.GameId, href, game.Name)
		{
			_releases.AddRange(game.Releases.Select(release => new ReleaseViewModel(release, href))); // TODO: Use release hrefs instead of game href
		}
	}
}