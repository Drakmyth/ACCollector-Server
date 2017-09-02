using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public class Availability
	{
		public int StartMonth { get; }
		public int EndMonth { get; }
		public bool StartsMidMonth { get; private set; }
		public bool EndsMidMonth { get; private set; }

		private readonly List<TimeSpan> _times;
		public IReadOnlyList<TimeSpan> Times => _times.AsReadOnly();

		private Availability(int startMonth, int endMonth)
		{
			StartMonth = startMonth;
			EndMonth = endMonth;
			StartsMidMonth = false;
			EndsMidMonth = false;
			_times = new List<TimeSpan>();
		}

		public Availability(Availability copy) : this(copy.StartMonth, copy.EndMonth)
		{
			StartsMidMonth = copy.StartsMidMonth;
			EndsMidMonth = copy.EndsMidMonth;
			_times.AddRange(copy.Times.Select(time => new TimeSpan(time)));
		}

		public class Builder : Availability
		{
			public Builder(int startMonth, int endMonth) : base(startMonth, endMonth)
			{
			}

			public Builder WithTimeSpan(TimeSpan time)
			{
				_times.Add(new TimeSpan(time));
				return this;
			}

			public Builder MidMonthStart(bool startsMidMonth)
			{
				StartsMidMonth = startsMidMonth;
				return this;
			}

			public Builder MidMonthEnd(bool endsMidMonth)
			{
				EndsMidMonth = endsMidMonth;
				return this;
			}

			public Availability Build()
			{
				return new Availability(this);
			}
		}
	}
}