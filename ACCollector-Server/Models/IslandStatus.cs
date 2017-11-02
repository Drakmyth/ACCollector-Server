using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public enum IslandStatus
	{
		None,
		Available,
		Exclusive
	}

	public class IslandStatusStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var islandStatus = (IslandStatus)value;
			string islandStatusString = islandStatus.GetIslandStatus();
			serializer.Serialize(writer, islandStatusString);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var code = serializer.Deserialize<string>(reader);
			return IslandStatusExtensions.Lookup(code);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(IslandStatus).IsAssignableFrom(objectType);
		}
	}

	public static class IslandStatusExtensions
	{
		private static readonly Dictionary<IslandStatus, string> _islandStatuses = new Dictionary<IslandStatus, string>
		{
			{IslandStatus.None, "None"},
			{IslandStatus.Available, "Available"},
			{IslandStatus.Exclusive, "Exclusive"}
		};

		public static string GetIslandStatus(this IslandStatus islandStatus)
		{
			return _islandStatuses[islandStatus];
		}

		public static IslandStatus Lookup(string islandStatus)
		{
			KeyValuePair<IslandStatus, string> islandStatusKvp = _islandStatuses.Where(kvp => kvp.Value == islandStatus).SingleOrDefault();

			if (islandStatusKvp.Equals(default(KeyValuePair<IslandStatus, string>)))
			{
				throw new ArgumentOutOfRangeException(nameof(islandStatus), islandStatus, "Unknown Island Status");
			}

			return islandStatusKvp.Key;
		}
	}
}