using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public class Bug
	{
		public string Id { get; }
		public Uri Href { get; }
		public string Name { get; }
		public GameSummary Game { get; }
		public int SalePrice { get; private set; }
		public string Location { get; private set; }
		public IslandStatus IslandStatus { get; private set; }

		private readonly List<Availability> _availabilities;
		public IReadOnlyList<Availability> Availabilities => _availabilities.AsReadOnly();

		private Bug(string id, Uri href, GameSummary game, string name)
		{
			Id = id;
			Href = href;
			Name = name;
			Game = game;
			SalePrice = 0;
			Location = "";
			IslandStatus = IslandStatus.None;
			_availabilities = new List<Availability>();
		}

		public Bug(Bug copy) : this(copy.Id, copy.Href, new GameSummary(copy.Game), copy.Name)
		{
			SalePrice = copy.SalePrice;
			Location = copy.Location;
			IslandStatus = copy.IslandStatus;
			_availabilities.AddRange(copy.Availabilities.Select(a => new Availability(a)));
		}

		public class Builder : Bug
		{
			public Builder(string id, Uri href, GameSummary game, string name) : base(id, href, game, name)
			{
			}

			public Builder WithSalePrice(int salePrice)
			{
				SalePrice = salePrice;
				return this;
			}

			public Builder AtLocation(string location)
			{
				Location = location;
				return this;
			}

			public Builder WithIslandStatus(IslandStatus islandStatus)
			{
				IslandStatus = islandStatus;
				return this;
			}

			public Builder WithAvailability(Availability availability)
			{
				_availabilities.Add(new Availability(availability));
				return this;
			}

			public Bug Build()
			{
				return new Bug(this);
			}
		}
	}
}