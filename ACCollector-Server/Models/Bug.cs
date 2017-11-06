using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public class Bug
	{
		public Guid BugId { get; }
		public Guid GameId { get; }
		public string Name { get; }
		public int SalePrice { get; private set; }
		public BugLocation Location { get; private set; }
		public IslandStatus IslandStatus { get; private set; }

		private readonly List<Availability> _availabilities;
		public IReadOnlyList<Availability> Availabilities => _availabilities.AsReadOnly();

		private readonly List<Note> _notes;
		public IReadOnlyList<Note> Notes => _notes.AsReadOnly();

		private Bug(Guid bugId, Guid gameId, string name)
		{
			BugId = bugId;
			GameId = gameId;
			Name = name;
			SalePrice = 0;
			Location = BugLocation.Air;
			IslandStatus = IslandStatus.None;
			_availabilities = new List<Availability>();
			_notes = new List<Note>();
		}

		private Bug(Bug copy) : this(copy.BugId, copy.GameId, copy.Name)
		{
			SalePrice = copy.SalePrice;
			Location = copy.Location;
			IslandStatus = copy.IslandStatus;
			_availabilities.AddRange(copy.Availabilities.Select(availability => new Availability(availability)));
			_notes.AddRange(copy.Notes.Select(note => new Note(note)));
		}

		public class Builder : Bug
		{
			public Builder(Guid bugId, Guid gameId, string name) : base(bugId, gameId, name)
			{
			}

			public Builder WithSalePrice(int salePrice)
			{
				SalePrice = salePrice;
				return this;
			}

			public Builder WithLocation(BugLocation location)
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

			public Bug Build()
			{
				if (!Availabilities.Any())
				{
					throw new InvalidOperationException("Bug must have at least one Availability.");
				}

				return new Bug(this);
			}
		}
	}
}