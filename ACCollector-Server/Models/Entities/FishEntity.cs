using ACCollector_Server.Models.Entities.Mapping;
using ACCollector_Server.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ACCollector_Server.Models.Entities
{
	[Table("Fish", Schema = "dbo")]
	public class FishEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid FishId { get; set; }

		[Required]
		public Guid GameId { get; set; }

		[Required]
		public int InGameId { get; set; }

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
		[Column(nameof(Location))]
		public string LocationString { get; set; }

		[NotMapped]
		public FishLocation Location
		{
			get => FishLocationExtensions.Lookup(LocationString);
			set => LocationString = value.GetLocation();
		}

		[Required]
		[Column(nameof(IslandStatus))]
		public string IslandStatusString { get; set; }

		[NotMapped]
		public IslandStatus IslandStatus
		{
			get => IslandStatusExtensions.Lookup(IslandStatusString);
			set => IslandStatusString = value.GetIslandStatus();
		}

		public ICollection<FishAvailabilityEntity> AvailabilityMappings { get; } = new List<FishAvailabilityEntity>();

		[NotMapped]
		public ICollection<AvailabilityEntity> Availabilities => AvailabilityMappings.Select(am => am.Availability).ToList();

		public ICollection<FishNoteEntity> NoteMappings { get; } = new List<FishNoteEntity>();

		[NotMapped]
		public ICollection<NoteEntity> Notes => NoteMappings.Select(nm => nm.Note).ToList();

		private FishEntity()
		{
			// EF Constructor
		}

		public FishEntity(Guid gameId, CreateFishRequest request)
		{
			FishId = Guid.Empty;
			GameId = gameId;
			InGameId = request.InGameId;
			Name = request.Name;
			SalePrice = request.SalePrice;
			Size = request.Size;
			Location = request.Location;
			IslandStatus = request.IslandStatus;

			foreach (CreateAvailabilityRequest availabilityRequest in request.Availabilities)
			{
				var availability = new AvailabilityEntity(availabilityRequest);
				Availabilities.Add(availability);
				AvailabilityMappings.Add(new FishAvailabilityEntity(this, availability));
			}

			foreach (string noteRequest in request.Notes)
			{
				var note = new NoteEntity(noteRequest);
				Notes.Add(note);
				NoteMappings.Add(new FishNoteEntity(this, note));
			}
		}

		public Fish ToModel()
		{
			var builder = new Fish.Builder(FishId, GameId, InGameId, Name)
				.WithSalePrice(SalePrice)
				.WithSize(Size)
				.WithLocation(Location)
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

		public FishSummary ToSummary()
		{
			return new FishSummary(FishId, InGameId, Name);
		}
	}
}