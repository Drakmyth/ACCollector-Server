using ACCollector_Server.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models.ViewModels
{
	public class GameViewModel
	{
		public Guid GameId { get; }
		public Uri Href { get; }
		public string Name { get; }

		private readonly List<ReleaseViewModel> _releases;
		public IReadOnlyList<ReleaseViewModel> Releases => _releases.AsReadOnly();

		private GameViewModel(Guid gameId, Uri href, string name)
		{
			GameId = gameId;
			Href = href;
			Name = name;
			_releases = new List<ReleaseViewModel>();
		}

		public GameViewModel(GameViewModel copy) : this(copy.GameId, copy.Href, copy.Name)
		{
			_releases.AddRange(copy.Releases.Select(release => new ReleaseViewModel(release)));
		}

		public GameViewModel(Game game, Uri href) : this(game.GameId, href, game.Name)
		{
			_releases.AddRange(game.Releases.Select(release => new ReleaseViewModel(release)));
		}

		public GameSummaryViewModel AsSummary(Region preferredRegion = Region.NA)
		{
			if (!_releases.Any())
			{
				throw new RegionNotFoundException($"Game '{GameId}' has no releases.");
			}

			ReleaseViewModel releaseViewModel = _releases.Where(r => r.Region == preferredRegion).SingleOrDefault() // Try preferred region first
												?? _releases.Where(r => r.Region == Region.NA).SingleOrDefault() // preferred region not found, fallback to NA
												?? _releases.Where(r => r.Region == Region.JP).SingleOrDefault() // NA region not found, fallback to JP
												?? _releases.First(); // JP region not found, fallback to anything

			return new GameSummaryViewModel(GameId, Href, releaseViewModel.Title);
		}

		public class Builder : GameViewModel
		{
			public Builder(Guid gameId, Uri href, string name) : base(gameId, href, name)
			{
			}

			public Builder WithRelease(ReleaseViewModel releaseViewModel)
			{
				_releases.Add(new ReleaseViewModel(releaseViewModel));
				return this;
			}

			public GameViewModel Build()
			{
				return new GameViewModel(this);
			}
		}
	}
}