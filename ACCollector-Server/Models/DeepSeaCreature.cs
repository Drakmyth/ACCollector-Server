using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public class DeepSeaCreature
	{
		public Guid DeepSeaCreatureId { get; }
		public Guid GameId { get; }
		public int InGameId { get; }
		public string Name { get; }
		public int SalePrice { get; private set; }
		public FishSize Size { get; private set; }
		public IslandStatus IslandStatus { get; private set; }

		private readonly List<Availability> _availabilities;
		public IReadOnlyList<Availability> Availabilities => _availabilities.AsReadOnly();

		private readonly List<Note> _notes;
		public IReadOnlyList<Note> Notes => _notes.AsReadOnly();

		private DeepSeaCreature(Guid deepSeaCreatureId, Guid gameId, int inGameId, string name)
		{
			DeepSeaCreatureId = deepSeaCreatureId;
			GameId = gameId;
			InGameId = inGameId;
			Name = name;
			SalePrice = 0;
			Size = FishSize.Medium;
			IslandStatus = IslandStatus.None;
			_availabilities = new List<Availability>();
			_notes = new List<Note>();
		}

		private DeepSeaCreature(DeepSeaCreature copy) : this(copy.DeepSeaCreatureId, copy.GameId, copy.InGameId, copy.Name)
		{
			SalePrice = copy.SalePrice;
			Size = copy.Size;
			IslandStatus = copy.IslandStatus;
			_availabilities.AddRange(copy.Availabilities.Select(availability => new Availability(availability)));
			_notes.AddRange(copy.Notes.Select(note => new Note(note)));
		}

		public class Builder : DeepSeaCreature
		{
			public Builder(Guid deepSeaCreatureId, Guid gameId, int inGameId, string name) : base(deepSeaCreatureId, gameId, inGameId, name)
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

			public DeepSeaCreature Build()
			{
				if (!Availabilities.Any())
				{
					throw new InvalidOperationException("DeepSeaCreature must have at least one Availability.");
				}

				return new DeepSeaCreature(this);
			}
		}
	}
}