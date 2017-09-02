using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ACCollector_Server.Converters
{
	public class DateConverter : DateTimeConverterBase
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var date = (DateTime)value;
			writer.WriteValue(date.ToString("yyyy-MM-dd"));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return DateTime.Parse(reader.Value.ToString());
		}
	}
}