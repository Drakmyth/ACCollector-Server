using ACCollector_Server.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public class Game
	{
		public Guid GameId { get; }
		public string Name { get; }

		private readonly List<Release> _releases;
		public IReadOnlyList<Release> Releases => _releases.AsReadOnly();

		private Game(Guid gameId, string name)
		{
			GameId = gameId;
			Name = name;
			_releases = new List<Release>();
		}

		public Game(Game copy) : this(copy.GameId, copy.Name)
		{
			_releases.AddRange(copy.Releases.Select(release => new Release(release)));
		}

		public class Builder : Game
		{
			public Builder(Guid gameId, string name) : base(gameId, name)
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