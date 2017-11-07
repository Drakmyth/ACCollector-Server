using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models.ViewModels
{
	public class FishViewModel
	{
		[JsonProperty]
		public Guid FishId { get; }

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
		public FishLocation Location { get; }

		[JsonProperty]
		public IslandStatus IslandStatus { get; }

		private readonly List<AvailabilityViewModel> _availabilities;

		[JsonProperty]
		public IReadOnlyList<AvailabilityViewModel> Availabilities => _availabilities.AsReadOnly();

		private readonly List<string> _notes;

		[JsonProperty]
		public IReadOnlyList<string> Notes => _notes.AsReadOnly();

		public FishViewModel(Fish fish, Uri href)
		{
			FishId = fish.FishId;
			GameId = fish.GameId;
			Href = href;
			Name = fish.Name;
			SalePrice = fish.SalePrice;
			Size = fish.Size;
			Location = fish.Location;
			IslandStatus = fish.IslandStatus;

			_availabilities = fish.Availabilities.Select(availability => new AvailabilityViewModel(availability)).ToList();
			_notes = fish.Notes.Select(note => note.Message).ToList();
		}
	}
}