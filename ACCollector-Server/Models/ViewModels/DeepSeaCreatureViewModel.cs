using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models.ViewModels
{
	public class DeepSeaCreatureViewModel
	{
		[JsonProperty]
		public Guid DeepSeaCreatureId { get; }

		[JsonProperty]
		public Guid GameId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public string Name { get; }

		[JsonProperty]
		public int SalePrice { get; }

		[JsonProperty]
		public FishSize Size { get; }

		[JsonProperty]
		public IslandStatus IslandStatus { get; }

		private readonly List<AvailabilityViewModel> _availabilities;

		[JsonProperty]
		public IReadOnlyList<AvailabilityViewModel> Availabilities => _availabilities.AsReadOnly();

		private readonly List<string> _notes;

		[JsonProperty]
		public IReadOnlyList<string> Notes => _notes.AsReadOnly();

		public DeepSeaCreatureViewModel(DeepSeaCreature deepSeaCreature, Uri href)
		{
			DeepSeaCreatureId = deepSeaCreature.DeepSeaCreatureId;
			GameId = deepSeaCreature.GameId;
			Href = href;
			Name = deepSeaCreature.Name;
			SalePrice = deepSeaCreature.SalePrice;
			Size = deepSeaCreature.Size;
			IslandStatus = deepSeaCreature.IslandStatus;

			_availabilities = deepSeaCreature.Availabilities.Select(availability => new AvailabilityViewModel(availability)).ToList();
			_notes = deepSeaCreature.Notes.Select(note => note.Message).ToList();
		}
	}
}