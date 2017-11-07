using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models.ViewModels
{
	public class BugViewModel
	{
		[JsonProperty]
		public Guid BugId { get; }

		[JsonProperty]
		public Guid GameId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public string Name { get; }

		[JsonProperty]
		public int SalePrice { get; }

		[JsonProperty]
		public BugLocation Location { get; }

		[JsonProperty]
		public IslandStatus IslandStatus { get; }

		private readonly List<AvailabilityViewModel> _availabilities;

		[JsonProperty]
		public IReadOnlyList<AvailabilityViewModel> Availabilities => _availabilities.AsReadOnly();

		private readonly List<string> _notes;

		[JsonProperty]
		public IReadOnlyList<string> Notes => _notes.AsReadOnly();

		public BugViewModel(Bug bug, Uri href)
		{
			BugId = bug.BugId;
			GameId = bug.GameId;
			Href = href;
			Name = bug.Name;
			SalePrice = bug.SalePrice;
			Location = bug.Location;
			IslandStatus = bug.IslandStatus;

			_availabilities = bug.Availabilities.Select(availability => new AvailabilityViewModel(availability)).ToList();
			_notes = bug.Notes.Select(note => note.Message).ToList();
		}
	}
}