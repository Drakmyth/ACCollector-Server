using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities.Mapping
{
	[Table("FishAvailability", Schema = "dbo")]
	public class FishAvailabilityEntity
	{
		[Key]
		[Required]
		public Guid FishId { get; set; }

		[Key]
		[Required]
		public Guid AvailabilityId { get; set; }

		public FishEntity Fish { get; set; }

		public AvailabilityEntity Availability { get; set; }
	}
}