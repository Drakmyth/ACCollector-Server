using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	[JsonConverter(typeof(BugLocationStringEnumConverter))]
	public enum BugLocation
	{
		Air,
		Trees,
		Ground,
		Flowers,
		Grass,
		Water,
		Rocks,
		Trash,
		Candy,
		Villagers,
		Snowballs,
		OutdoorLights
	}

	public class BugLocationStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var bugLocation = (BugLocation)value;
			string location = bugLocation.GetLocation();
			serializer.Serialize(writer, location);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var location = serializer.Deserialize<string>(reader);
			return BugLocationExtensions.Lookup(location);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(BugLocation).IsAssignableFrom(objectType);
		}
	}

	public static class BugLocationExtensions
	{
		private static readonly Dictionary<BugLocation, string> _locations = new Dictionary<BugLocation, string>
		{
			{BugLocation.Air, "Air"},
			{BugLocation.Trees, "Trees"},
			{BugLocation.Ground, "Ground"},
			{BugLocation.Flowers, "Flowers"},
			{BugLocation.Grass, "Grass"},
			{BugLocation.Water, "Water"},
			{BugLocation.Rocks, "Rocks"},
			{BugLocation.Trash, "Trash"},
			{BugLocation.Candy, "Candy"},
			{BugLocation.Villagers, "Villagers"},
			{BugLocation.Snowballs, "Snowballs"},
			{BugLocation.OutdoorLights, "Outdoor Lights"}
		};

		public static string GetLocation(this BugLocation bugLocation)
		{
			return _locations[bugLocation];
		}

		public static BugLocation Lookup(string location)
		{
			KeyValuePair<BugLocation, string> bugLocationKvp = _locations.Where(kvp => kvp.Value == location).SingleOrDefault();

			if (bugLocationKvp.Equals(default(KeyValuePair<BugLocation, string>)))
			{
				throw new ArgumentOutOfRangeException(nameof(location), location, "Unknown Location");
			}

			return bugLocationKvp.Key;
		}
	}
}