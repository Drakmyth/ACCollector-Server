using ACCollector_Server.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public class Game
	{
		public Guid Id { get; }
		public Uri Href { get; }
		public string Name { get; }

		private readonly List<Release> _releases;
		public IReadOnlyList<Release> Releases => _releases.AsReadOnly();

		private Game(Guid id, Uri href, string name)
		{
			Id = id;
			Href = href;
			Name = name;
			_releases = new List<Release>();
		}

		public Game(Game copy) : this(copy.Id, copy.Href, copy.Name)
		{
			_releases.AddRange(copy.Releases.Select(release => new Release(release)));
		}

		public GameSummary AsSummary(Region preferredRegion = Region.NA)
		{
			if (!_releases.Any())
			{
				throw new RegionNotFoundException($"Game '{Id}' has no releases.");
			}

			Release release = _releases.Where(r => r.Region == preferredRegion).SingleOrDefault() // Try preferred region first
							  ?? _releases.Where(r => r.Region == Region.NA).SingleOrDefault() // preferred region not found, fallback to NA
							  ?? _releases.Where(r => r.Region == Region.JP).SingleOrDefault() // NA region not found, fallback to JP
							  ?? _releases.First(); // JP region not found, fallback to anything

			return new GameSummary(Id, Href, release.Title);
		}

		public class Builder : Game
		{
			public Builder(Guid id, Uri href, string name) : base(id, href, name)
			{
			}

			public Builder WithRelease(Release release)
			{
				_releases.Add(new Release(release));
				return this;
			}

			public Game Build()
			{
				return new Game(this);
			}
		}
	}
}