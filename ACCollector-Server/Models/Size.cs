using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	public enum Size
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

	public class SizeStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var size = (Size)value;
			string sizeString = size.GetSize();
			serializer.Serialize(writer, sizeString);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var code = serializer.Deserialize<string>(reader);
			return SizeExtensions.Lookup(code);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Size).IsAssignableFrom(objectType);
		}
	}

	public static class SizeExtensions
	{
		private static readonly Dictionary<Size, string> _sizes = new Dictionary<Size, string>
		{
			{Size.Tiny, "Tiny"},
			{Size.Small, "Small"},
			{Size.Medium, "Medium"},
			{Size.Large, "Large"},
			{Size.VeryLarge, "Very Large"},
			{Size.Huge, "Huge"},
			{Size.Long, "Long"},
			{Size.Fin, "Fin"}
		};

		public static string GetSize(this Size size)
		{
			return _sizes[size];
		}

		public static Size Lookup(string size)
		{
			KeyValuePair<Size, string> sizeKvp = _sizes.Where(kvp => kvp.Value == size).SingleOrDefault();

			if (sizeKvp.Equals(default(KeyValuePair<Size, string>)))
			{
				throw new ArgumentOutOfRangeException(nameof(size), size, "Unknown Size");
			}

			return sizeKvp.Key;
		}
	}
}