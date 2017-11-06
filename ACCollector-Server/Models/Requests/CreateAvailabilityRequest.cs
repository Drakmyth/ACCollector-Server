using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateAvailabilityRequest
	{
		[Required]
		[Range(1, 12, ErrorMessage = "StartMonth must be in the range 1-12.")]
		public int StartMonth { get; }

		[Required]
		[Range(0, 23, ErrorMessage = "StartHour must be in the range 0-23.")]
		public int StartHour { get; }

		[Required]
		[Range(1, 12, ErrorMessage = "EndMonth must be in the range 1-12.")]
		public int EndMonth { get; }

		[Required]
		[Range(0, 23, ErrorMessage = "EndHour must be in the range 0-23.")]
		public int EndHour { get; }

		[Required]
		public bool StartsMidMonth { get; }

		[Required]
		public bool EndsMidMonth { get; }

		[JsonConstructor]
		public CreateAvailabilityRequest(int startMonth, int startHour, int endMonth, int endHour, bool startsMidMonth, bool endsMidMonth)
		{
			StartMonth = startMonth;
			StartHour = startHour;
			EndMonth = endMonth;
			EndHour = endHour;
			StartsMidMonth = startsMidMonth;
			EndsMidMonth = endsMidMonth;
		}
	}
}