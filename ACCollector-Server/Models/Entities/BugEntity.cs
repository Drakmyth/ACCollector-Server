using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
	}
}