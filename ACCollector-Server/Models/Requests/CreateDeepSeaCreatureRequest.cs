using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateDeepSeaCreatureRequest
	{
		[Required]
		public int InGameId { get; }

		[Required]
		public string Name { get; }

		[Required]
		public int SalePrice { get; }

		[Required]
		public FishSize Size { get; }

		[Required]
		public IslandStatus IslandStatus { get; }

		private readonly List<CreateAvailabilityRequest> _availabilities;

		[Required]
		[MinLength(1, ErrorMessage = "Deep Sea Creatures must have at least one Availability.")]
		public IReadOnlyList<CreateAvailabilityRequest> Availabilities => _availabilities.AsReadOnly();

		private readonly List<string> _notes;

		[Required]
		public IReadOnlyList<string> Notes => _notes.AsReadOnly();

		[JsonConstructor]
		public CreateDeepSeaCreatureRequest(int inGameId, string name, int salePrice, FishSize size, IslandStatus islandStatus, IEnumerable<CreateAvailabilityRequest> availabilities, IEnumerable<string> notes)
		{
			InGameId = inGameId;
			Name = name;
			SalePrice = salePrice;
			Size = size;
			IslandStatus = islandStatus;
			_availabilities = new List<CreateAvailabilityRequest>(availabilities);
			_notes = new List<string>(notes);
		}
	}
}