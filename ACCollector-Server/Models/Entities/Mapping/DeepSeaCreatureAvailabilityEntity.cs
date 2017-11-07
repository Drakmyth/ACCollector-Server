using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities.Mapping
{
	[Table("DeepSeaCreatureAvailability", Schema = "dbo")]
	public class DeepSeaCreatureAvailabilityEntity
	{
		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid DeepSeaCreatureId { get; set; }

		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid AvailabilityId { get; set; }

		public DeepSeaCreatureEntity DeepSeaCreature { get; set; }

		public AvailabilityEntity Availability { get; set; }

		private DeepSeaCreatureAvailabilityEntity()
		{
			// EF Constructor
		}

		public DeepSeaCreatureAvailabilityEntity(DeepSeaCreatureEntity deepSeaCreature, AvailabilityEntity availability)
		{
			DeepSeaCreatureId = deepSeaCreature.DeepSeaCreatureId;
			AvailabilityId = availability.AvailabilityId;
			DeepSeaCreature = deepSeaCreature;
			Availability = availability;
		}
	}
}