using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	[JsonConverter(typeof(RegionStringEnumConverter))]
	public enum Region
	{
		JP,
		NA,
		EU,
		AU,
		KOR,
		CHN
	}

	public class RegionStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var region = (Region)value;
			string code = region.GetCode();
			serializer.Serialize(writer, code);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var code = serializer.Deserialize<string>(reader);
			return RegionExtensions.Lookup(code);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Region).IsAssignableFrom(objectType);
		}
	}

	public static class RegionExtensions
	{
		private static readonly Dictionary<Region, (string Code, string Description)> _regions = new Dictionary<Region, (string Code, string Description)>()
		{
			{Region.JP, ("JP", "Japan")},
			{Region.NA, ("NA", "North America")},
			{Region.EU, ("EU", "Europe")},
			{Region.AU, ("AU", "Australasia")},
			{Region.KOR, ("KOR", "South Korea")},
			{Region.CHN, ("CHN", "China")}
		};

		public static string GetCode(this Region region)
		{
			return _regions[region].Code;
		}

		public static string GetDescription(this Region region)
		{
			return _regions[region].Description;
		}

		public static Region Lookup(string code)
		{
			KeyValuePair<Region, (string Code, string Description)> regionKvp = _regions.Where(kvp => kvp.Value.Code == code).SingleOrDefault();

			if (regionKvp.Equals(default(KeyValuePair<Region, (string Code, string Description)>)))
			{
				throw new ArgumentOutOfRangeException(nameof(code), code, "Unknown Region Code");
			}

			return regionKvp.Key;
		}
	}
}