using System;

namespace ACCollector_Server.Models
{
	public class Availability
	{
		public Guid AvailabilityId { get; }
		public Month StartMonth { get; private set; }
		public int StartHour { get; private set; }
		public Month EndMonth { get; private set; }
		public int EndHour { get; private set; }
		public bool StartsMidMonth { get; private set; }
		public bool EndsMidMonth { get; private set; }

		private Availability(Guid availabilityId)
		{
			AvailabilityId = availabilityId;
			StartMonth = Month.January;
			StartHour = 0;
			EndMonth = Month.December;
			EndHour = 23;
			StartsMidMonth = false;
			EndsMidMonth = false;
		}

		public Availability(Availability copy) : this(copy.AvailabilityId)
		{
			StartMonth = copy.StartMonth;
			StartHour = copy.StartHour;
			EndMonth = copy.EndMonth;
			EndHour = copy.EndHour;
			StartsMidMonth = copy.StartsMidMonth;
			EndsMidMonth = copy.EndsMidMonth;
		}

		public enum Month
		{
			January = 1,
			February = 2,
			March = 3,
			April = 4,
			May = 5,
			June = 6,
			July = 7,
			August = 8,
			September = 9,
			October = 10,
			November = 11,
			December = 12
		}

		public class Builder : Availability
		{
			public Builder(Guid availabilityId) : base(availabilityId)
			{
			}

			public Builder WithMonthRange(int startMonth, int endMonth)
			{
				var start = (Month)startMonth;
				var end = (Month)endMonth;
				return WithMonthRange(start, end);
			}

			public Builder WithMonthRange(Month startMonth, Month endMonth)
			{
				if (startMonth < Month.January || startMonth > Month.December)
				{
					throw new ArgumentException($"Invalid start month value: {startMonth}", nameof(startMonth));
				}

				if (endMonth < Month.January || endMonth > Month.December)
				{
					throw new ArgumentException($"Invalid end month value: {endMonth}", nameof(endMonth));
				}

				if (endMonth < startMonth)
				{
					throw new ArgumentException("End month cannot be earlier than the start month.");
				}

				StartMonth = startMonth;
				EndMonth = endMonth;
				return this;
			}

			public Builder WithHourRange(int startHour, int endHour)
			{
				if (startHour < 0 || startHour > 23)
				{
					throw new ArgumentException("Start hour must be within range 0-23.", nameof(startHour));
				}

				if (endHour < 0 || endHour > 23)
				{
					throw new ArgumentException("End hour must be within range 0-23.", nameof(endHour));
				}

				if (endHour <= startHour)
				{
					throw new ArgumentException("End hour cannot be the same or less than the start hour.");
				}

				StartHour = startHour;
				EndHour = endHour;
				return this;
			}

			public Builder DoesStartMidMonth(bool startsMidMonth)
			{
				StartsMidMonth = startsMidMonth;
				return this;
			}

			public Builder DoesEndMidMonth(bool endsMidMonth)
			{
				EndsMidMonth = endsMidMonth;
				return this;
			}

			public Availability Build()
			{
				if (StartMonth == EndMonth && StartsMidMonth && EndsMidMonth)
				{
					throw new InvalidOperationException("Availability cannot start mid month and end mid month when start and end month are the same.");
				}

				return new Availability(this);
			}
		}
	}
}