using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateBugRequest
	{
		[Required]
		public string Name { get; }

		[Required]
		public int SalePrice { get; }

		[Required]
		public BugLocation Location { get; }

		[Required]
		public IslandStatus IslandStatus { get; }

		private readonly List<CreateAvailabilityRequest> _availabilities;

		[Required]
		[MinLength(1, ErrorMessage = "Bugs must have at least one Availability.")]
		public IReadOnlyList<CreateAvailabilityRequest> Availabilities => _availabilities.AsReadOnly();

		private readonly List<string> _notes;

		[Required]
		public IReadOnlyList<string> Notes => _notes.AsReadOnly();

		[JsonConstructor]
		public CreateBugRequest(string name, int salePrice, BugLocation location, IslandStatus islandStatus, IEnumerable<CreateAvailabilityRequest> availabilities, IEnumerable<string> notes)
		{
			Name = name;
			SalePrice = salePrice;
			Location = location;
			IslandStatus = islandStatus;
			_availabilities = new List<CreateAvailabilityRequest>(availabilities);
			_notes = new List<string>(notes);
		}
	}
}