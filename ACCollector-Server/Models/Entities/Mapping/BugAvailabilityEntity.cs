using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities.Mapping
{
	[Table("BugAvailability", Schema = "dbo")]
	public class BugAvailabilityEntity
	{
		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid BugId { get; set; }

		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid AvailabilityId { get; set; }

		public BugEntity Bug { get; set; }

		public AvailabilityEntity Availability { get; set; }

		private BugAvailabilityEntity()
		{
			// EF Constructor
		}

		public BugAvailabilityEntity(BugEntity bug, AvailabilityEntity availability)
		{
			BugId = bug.BugId;
			AvailabilityId = availability.AvailabilityId;
			Bug = bug;
			Availability = availability;
		}
	}
}