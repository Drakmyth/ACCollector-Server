using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public class Fish
	{
		public Guid FishId { get; }
		public Guid GameId { get; }
		public string Name { get; }
		public int SalePrice { get; private set; }
		public FishSize Size { get; private set; }
		public FishLocation Location { get; private set; }
		public IslandStatus IslandStatus { get; private set; }

		private readonly List<Availability> _availabilities;
		public IReadOnlyList<Availability> Availabilities => _availabilities.AsReadOnly();

		private readonly List<Note> _notes;
		public IReadOnlyList<Note> Notes => _notes.AsReadOnly();

		private Fish(Guid fishId, Guid gameId, string name)
		{
			FishId = fishId;
			GameId = gameId;
			Name = name;
			SalePrice = 0;
			Size = FishSize.Medium;
			Location = FishLocation.River;
			IslandStatus = IslandStatus.None;
			_availabilities = new List<Availability>();
			_notes = new List<Note>();
		}

		private Fish(Fish copy) : this(copy.FishId, copy.GameId, copy.Name)
		{
			SalePrice = copy.SalePrice;
			Size = copy.Size;
			Location = copy.Location;
			IslandStatus = copy.IslandStatus;
			_availabilities.AddRange(copy.Availabilities.Select(availability => new Availability(availability)));
			_notes.AddRange(copy.Notes.Select(note => new Note(note)));
		}

		public class Builder : Fish
		{
			public Builder(Guid fishId, Guid gameId, string name) : base(fishId, gameId, name)
			{
			}

			public Builder WithSalePrice(int salePrice)
			{
				SalePrice = salePrice;
				return this;
			}

			public Builder WithSize(FishSize size)
			{
				Size = size;
				return this;
			}

			public Builder WithLocation(FishLocation location)
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

			public Builder WithNote(Note note)
			{
				_notes.Add(new Note(note));
				return this;
			}

			public Fish Build()
			{
				if (!Availabilities.Any())
				{
					throw new InvalidOperationException("Fish must have at least one Availability.");
				}

				return new Fish(this);
			}
		}
	}
}