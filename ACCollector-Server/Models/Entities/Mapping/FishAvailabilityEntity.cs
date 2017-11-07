using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities.Mapping
{
	[Table("FishAvailability", Schema = "dbo")]
	public class FishAvailabilityEntity
	{
		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid FishId { get; set; }

		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid AvailabilityId { get; set; }

		public FishEntity Fish { get; set; }

		public AvailabilityEntity Availability { get; set; }

		private FishAvailabilityEntity()
		{
			// EF Constructor
		}

		public FishAvailabilityEntity(FishEntity fish, AvailabilityEntity availability)
		{
			FishId = fish.FishId;
			AvailabilityId = availability.AvailabilityId;
			Fish = fish;
			Availability = availability;
		}
	}
}