using ACCollector_Server.Models.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ACCollector_Server.Models.Requests;

namespace ACCollector_Server.Models.Entities
{
	[Table("Bug", Schema = "dbo")]
	public class BugEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid BugId { get; set; }

		[Required]
		public Guid GameId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int SalePrice { get; set; }

		[Required]
		[Column(nameof(Location))]
		public string LocationString { get; set; }

		[NotMapped]
		public BugLocation Location
		{
			get => BugLocationExtensions.Lookup(LocationString);
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

		public ICollection<BugAvailabilityEntity> AvailabilityMappings { get; } = new List<BugAvailabilityEntity>();

		[NotMapped]
		public ICollection<AvailabilityEntity> Availabilities => AvailabilityMappings.Select(am => am.Availability).ToList();

		public ICollection<BugNoteEntity> NoteMappings { get; } = new List<BugNoteEntity>();

		[NotMapped]
		public ICollection<NoteEntity> Notes => NoteMappings.Select(nm => nm.Note).ToList();

		private BugEntity()
		{
			// EF Constructor
		}

		public BugEntity(Guid gameId, CreateBugRequest request)
		{
			BugId = Guid.Empty;
			GameId = gameId;
			Name = request.Name;
			SalePrice = request.SalePrice;
			Location = request.Location;
			IslandStatus = request.IslandStatus;

			foreach (CreateAvailabilityRequest availabilityRequest in request.Availabilities)
			{
				var availability = new AvailabilityEntity(availabilityRequest);
				Availabilities.Add(availability);
				AvailabilityMappings.Add(new BugAvailabilityEntity(this, availability));
			}

			foreach (string noteRequest in request.Notes)
			{
				var note = new NoteEntity(noteRequest);
				Notes.Add(note);
				NoteMappings.Add(new BugNoteEntity(this, note));
			}
		}

		public Bug ToModel()
		{
			var builder = new Bug.Builder(BugId, GameId, Name)
				.WithSalePrice(SalePrice)
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

		public BugSummary ToSummary()
		{
			return new BugSummary(BugId, Name);
		}
	}
}