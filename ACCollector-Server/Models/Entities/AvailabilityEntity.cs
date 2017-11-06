using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ACCollector_Server.Models.Requests;

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

		private AvailabilityEntity()
		{
			// EF Constructor
		}

		public AvailabilityEntity(CreateAvailabilityRequest request)
		{
			AvailabilityId = Guid.Empty;
			StartMonth = request.StartMonth;
			StartHour = request.StartHour;
			EndMonth = request.EndMonth;
			EndHour = request.EndHour;
			StartsMidMonth = request.StartsMidMonth;
			EndsMidMonth = request.EndsMidMonth;
		}

		public Availability ToModel()
		{
			var builder = new Availability.Builder(AvailabilityId)
				.WithMonthRange(StartMonth, EndMonth)
				.WithHourRange(StartHour, EndHour)
				.DoesStartMidMonth(StartsMidMonth)
				.DoesEndMidMonth(EndsMidMonth);

			return builder.Build();
		}
	}
}