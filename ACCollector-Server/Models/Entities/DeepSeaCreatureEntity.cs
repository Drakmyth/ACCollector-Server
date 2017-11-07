using ACCollector_Server.Models.Entities.Mapping;
using ACCollector_Server.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ACCollector_Server.Models.Entities
{
	[Table("DeepSeaCreature", Schema = "dbo")]
	public class DeepSeaCreatureEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid DeepSeaCreatureId { get; set; }

		[Required]
		public Guid GameId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Column(nameof(Size))]
		public string SizeString { get; set; }

		[NotMapped]
		public FishSize Size
		{
			get => FishSizeExtensions.Lookup(SizeString);
			set => SizeString = value.GetSize();
		}

		[Required]
		public int SalePrice { get; set; }

		[Required]
		[Column(nameof(IslandStatus))]
		public string IslandStatusString { get; set; }

		[NotMapped]
		public IslandStatus IslandStatus
		{
			get => IslandStatusExtensions.Lookup(IslandStatusString);
			set => IslandStatusString = value.GetIslandStatus();
		}

		public ICollection<DeepSeaCreatureAvailabilityEntity> AvailabilityMappings { get; } = new List<DeepSeaCreatureAvailabilityEntity>();

		[NotMapped]
		public ICollection<AvailabilityEntity> Availabilities => AvailabilityMappings.Select(am => am.Availability).ToList();

		public ICollection<DeepSeaCreatureNoteEntity> NoteMappings { get; } = new List<DeepSeaCreatureNoteEntity>();

		[NotMapped]
		public ICollection<NoteEntity> Notes => NoteMappings.Select(nm => nm.Note).ToList();

		private DeepSeaCreatureEntity()
		{
			// EF Constructor
		}

		public DeepSeaCreatureEntity(Guid gameId, CreateDeepSeaCreatureRequest request)
		{
			DeepSeaCreatureId = Guid.Empty;
			GameId = gameId;
			Name = request.Name;
			SalePrice = request.SalePrice;
			Size = request.Size;
			IslandStatus = request.IslandStatus;

			foreach (CreateAvailabilityRequest availabilityRequest in request.Availabilities)
			{
				var availability = new AvailabilityEntity(availabilityRequest);
				Availabilities.Add(availability);
				AvailabilityMappings.Add(new DeepSeaCreatureAvailabilityEntity(this, availability));
			}

			foreach (string noteRequest in request.Notes)
			{
				var note = new NoteEntity(noteRequest);
				Notes.Add(note);
				NoteMappings.Add(new DeepSeaCreatureNoteEntity(this, note));
			}
		}

		public DeepSeaCreature ToModel()
		{
			var builder = new DeepSeaCreature.Builder(DeepSeaCreatureId, GameId, Name)
				.WithSalePrice(SalePrice)
				.WithSize(Size)
				.WithIslandStatus(IslandStatus);

			foreach (AvailabilityEntity availability in Availabilities)
			{
				builder.WithAvailability(availability.ToModel());
			}

			foreach (NoteEntity note in Notes)
			{
				builder.WithNote(note.ToModel());
			}

			return builder.Build();
		}

		public DeepSeaCreatureSummary ToSummary()
		{
			return new DeepSeaCreatureSummary(DeepSeaCreatureId, Name);
		}
	}
}