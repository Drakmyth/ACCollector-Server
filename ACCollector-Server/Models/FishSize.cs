using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	[JsonConverter(typeof(FishSizeStringEnumConverter))]
	public enum FishSize
	{
		Tiny,
		Small,
		Medium,
		Large,
		VeryLarge,
		Huge,
		Long,
		Fin
	}

	public class FishSizeStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var fishSize = (FishSize)value;
			string size = fishSize.GetSize();
			serializer.Serialize(writer, size);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var size = serializer.Deserialize<string>(reader);
			return FishSizeExtensions.Lookup(size);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(FishSize).IsAssignableFrom(objectType);
		}
	}

	public static class FishSizeExtensions
	{
		private static readonly Dictionary<FishSize, string> _sizes = new Dictionary<FishSize, string>
		{
			{FishSize.Tiny, "Tiny"},
			{FishSize.Small, "Small"},
			{FishSize.Medium, "Medium"},
			{FishSize.Large, "Large"},
			{FishSize.VeryLarge, "Very Large"},
			{FishSize.Huge, "Huge"},
			{FishSize.Long, "Long"},
			{FishSize.Fin, "Fin"}
		};

		public static string GetSize(this FishSize fishSize)
		{
			return _sizes[fishSize];
		}

		public static FishSize Lookup(string size)
		{
			KeyValuePair<FishSize, string> fishSizeKvp = _sizes.Where(kvp => kvp.Value == size).SingleOrDefault();

			if (fishSizeKvp.Equals(default(KeyValuePair<FishSize, string>)))
			{
				throw new ArgumentOutOfRangeException(nameof(size), size, "Unknown Size");
			}

			return fishSizeKvp.Key;
		}
	}
}