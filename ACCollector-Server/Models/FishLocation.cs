using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	[JsonConverter(typeof(FishLocationStringEnumConverter))]
	public enum FishLocation
	{
		River,
		RiverPool,
		RiverMouth,
		Waterfall,
		HoldingPond,
		Ocean
	}

	public class FishLocationStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var fishLocation = (FishLocation)value;
			string location = fishLocation.GetLocation();
			serializer.Serialize(writer, location);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var location = serializer.Deserialize<string>(reader);
			return FishLocationExtensions.Lookup(location);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(FishLocation).IsAssignableFrom(objectType);
		}
	}

	public static class FishLocationExtensions
	{
		private static readonly Dictionary<FishLocation, string> _locations = new Dictionary<FishLocation, string>
		{
			{FishLocation.River, "River"},
			{FishLocation.RiverPool, "River Pool"},
			{FishLocation.RiverMouth, "River Mouth"},
			{FishLocation.Waterfall, "Waterfall"},
			{FishLocation.HoldingPond, "Holding Pond"},
			{FishLocation.Ocean, "Ocean"}
		};

		public static string GetLocation(this FishLocation fishLocation)
		{
			return _locations[fishLocation];
		}

		public static FishLocation Lookup(string location)
		{
			KeyValuePair<FishLocation, string> fishLocationKvp = _locations.Where(kvp => kvp.Value == location).SingleOrDefault();

			if (fishLocationKvp.Equals(default(KeyValuePair<FishLocation, string>)))
			{
				throw new ArgumentOutOfRangeException(nameof(location), location, "Unknown Location");
			}

			return fishLocationKvp.Key;
		}
	}
}