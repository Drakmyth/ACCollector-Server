using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	[JsonConverter(typeof(PlatformStringEnumConverter))]
	public enum Platform
	{
		N64,
		GCN,
		iQue,
		NDS,
		Wii,
		N3DS
	}

	public class PlatformStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var platform = (Platform)value;
			string code = platform.GetCode();
			serializer.Serialize(writer, code);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var code = serializer.Deserialize<string>(reader);
			return PlatformExtensions.Lookup(code);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(Platform).IsAssignableFrom(objectType);
		}
	}

	public static class PlatformExtensions
	{
		private static readonly Dictionary<Platform, (string Code, string Description)> _platforms = new Dictionary<Platform, (string Code, string Description)>()
		{
			{Platform.N64, ("N64", "Nintendo 64")},
			{Platform.GCN, ("GCN", "Nintendo Gamecube")},
			{Platform.iQue, ("iQue", "iQue Player")},
			{Platform.NDS, ("NDS", "Nintendo DS")},
			{Platform.Wii, ("Wii", "Nintendo Wii")},
			{Platform.N3DS, ("3DS", "Nintendo 3DS")}
		};

		public static string GetCode(this Platform platform)
		{
			return _platforms[platform].Code;
		}

		public static string GetDescription(this Platform platform)
		{
			return _platforms[platform].Description;
		}

		public static Platform Lookup(string code)
		{
			KeyValuePair<Platform, (string Code, string Description)> platformKvp = _platforms.Where(kvp => kvp.Value.Code == code).SingleOrDefault();

			if (platformKvp.Equals(default(KeyValuePair<Platform, (string Code, string Description)>)))
			{
				throw new ArgumentOutOfRangeException(nameof(code), code, "Unknown Platform Code");
			}

			return platformKvp.Key;
		}
	}
}