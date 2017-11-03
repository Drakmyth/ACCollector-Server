using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
{
	[Table("Availability", Schema = "dbo")]
	public class AvailabilityEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid AvailabilityId { get; set; }

		[Required]
		public int StartMonth { get; set; }

		[Required]
		public int StartHour { get; set; }

		[Required]
		public int EndMonth { get; set; }

		[Required]
		public int EndHour { get; set; }

		[Required]
		public bool StartsMidMonth { get; set; }

		[Required]
		public bool EndsMidMonth { get; set; }
	}
}