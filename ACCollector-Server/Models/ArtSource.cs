using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	[JsonConverter(typeof(ArtSourceStringEnumConverter))]
	public enum ArtSource
	{
		CrazyRedd,
		TomNook,
		Spotlight
	}

	public class ArtSourceStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var artSource = (ArtSource)value;
			string source = artSource.GetArtSource();
			serializer.Serialize(writer, source);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var artSource = serializer.Deserialize<string>(reader);
			return ArtSourceExtensions.Lookup(artSource);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(ArtSource).IsAssignableFrom(objectType);
		}
	}

	public static class ArtSourceExtensions
	{
		private static readonly Dictionary<ArtSource, string> _artSources = new Dictionary<ArtSource, string>
		{
			{ArtSource.CrazyRedd, "Crazy Redd"},
			{ArtSource.TomNook, "Tom Nook"},
			{ArtSource.Spotlight, "Spotlight"}
		};

		public static string GetArtSource(this ArtSource artSource)
		{
			return _artSources[artSource];
		}

		public static ArtSource Lookup(string artSource)
		{
			KeyValuePair<ArtSource, string> artSourceKvp = _artSources.Where(kvp => kvp.Value == artSource).SingleOrDefault();

			if (artSourceKvp.Equals(default(KeyValuePair<ArtSource, string>)))
			{
				throw new ArgumentOutOfRangeException(nameof(artSource), artSource, "Unknown Art Source");
			}

			return artSourceKvp.Key;
		}
	}
}