using Newtonsoft.Json;

namespace ACCollector_Server.Models.ViewModels
{
	public class AvailabilityViewModel
	{
		[JsonProperty]
		public int StartMonth { get; private set; }

		[JsonProperty]
		public int StartHour { get; private set; }

		[JsonProperty]
		public int EndMonth { get; private set; }

		[JsonProperty]
		public int EndHour { get; private set; }

		[JsonProperty]
		public bool StartsMidMonth { get; private set; }

		[JsonProperty]
		public bool EndsMidMonth { get; private set; }

		public AvailabilityViewModel(Availability availability)
		{
			StartMonth = (int)availability.StartMonth;
			StartHour = availability.StartHour;
			EndMonth = (int)availability.EndMonth;
			EndHour = availability.EndHour;
			StartsMidMonth = availability.StartsMidMonth;
			EndsMidMonth = availability.EndsMidMonth;
		}
	}
}