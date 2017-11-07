using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	[JsonConverter(typeof(ArtTypeStringEnumConverter))]
	public enum ArtType
	{
		Painting,
		Sculpture
	}

	public class ArtTypeStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var artType = (ArtType)value;
			string type = artType.GetArtType();
			serializer.Serialize(writer, type);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var artType = serializer.Deserialize<string>(reader);
			return ArtTypeExtensions.Lookup(artType);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(ArtType).IsAssignableFrom(objectType);
		}
	}

	public static class ArtTypeExtensions
	{
		private static readonly Dictionary<ArtType, string> _artTypes = new Dictionary<ArtType, string>
		{
			{ArtType.Painting, "Painting"},
			{ArtType.Sculpture, "Sculpture"}
		};

		public static string GetArtType(this ArtType artType)
		{
			return _artTypes[artType];
		}

		public static ArtType Lookup(string artType)
		{
			KeyValuePair<ArtType, string> artTypeKvp = _artTypes.Where(kvp => kvp.Value == artType).SingleOrDefault();

			if (artTypeKvp.Equals(default(KeyValuePair<ArtType, string>)))
			{
				throw new ArgumentOutOfRangeException(nameof(artType), artType, "Unknown Art Type");
			}

			return artTypeKvp.Key;
		}
	}
}