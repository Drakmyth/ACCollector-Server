using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
{
	[Table("BugAvailability", Schema = "dbo")]
	public class BugAvailabilityEntity
	{
		[Key]
		[Required]
		public Guid BugId { get; set; }

		[Key]
		[Required]
		public Guid AvailabilityId { get; set; }

		public BugEntity Bug { get; set; }

		public AvailabilityEntity Availability { get; set; }
	}
}