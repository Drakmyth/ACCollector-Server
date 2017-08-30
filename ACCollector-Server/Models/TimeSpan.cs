namespace ACCollector_Server.Models
{
	public class TimeSpan
	{
		public string StartTime { get; }
		public string EndTime { get; }

		public TimeSpan(string startTime, string endTime)
		{
			StartTime = startTime;
			EndTime = endTime;
		}

		public TimeSpan(TimeSpan copy) : this(copy.StartTime, copy.EndTime)
		{
		}
	}
}