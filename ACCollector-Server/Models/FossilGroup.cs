using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.Models
{
	[JsonConverter(typeof(FossilGroupStringEnumConverter))]
	public enum FossilGroup
	{
		Ankylosaurus,
		Apatosaurus,
		Archelon,
		Dimetrodon,
		Diplodocus,
		Ichthyosaur,
		Iguanodon,
		Mammoth,
		Megacerops,
		Pachycephalosaurus,
		Parasaur,
		Plesiosaur,
		Pteranodon,
		SabretoothTiger,
		Seismosaur,
		Stegosaur,
		Spinosaurus,
		Styracosaurus,
		Triceratops,
		TyrannosaurusRex,
		Velociraptor,
		Standalone
	}

	public class FossilGroupStringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var fossilGroup = (FossilGroup)value;
			string group = fossilGroup.GetGroup();
			serializer.Serialize(writer, group);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var fossilGroup = serializer.Deserialize<string>(reader);
			return FossilGroupExtensions.Lookup(fossilGroup);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(FossilGroup).IsAssignableFrom(objectType);
		}
	}

	public static class FossilGroupExtensions
	{
		private static readonly Dictionary<FossilGroup, string> _groups = new Dictionary<FossilGroup, string>
		{
			{FossilGroup.Ankylosaurus, "Ankylosaurus"},
			{FossilGroup.Apatosaurus, "Apatosaurus"},
			{FossilGroup.Archelon, "Archelon"},
			{FossilGroup.Dimetrodon, "Dimetrodon"},
			{FossilGroup.Diplodocus, "Diplodocus"},
			{FossilGroup.Ichthyosaur, "Ichthyosaur"},
			{FossilGroup.Iguanodon, "Iguanodon"},
			{FossilGroup.Mammoth, "Mammoth"},
			{FossilGroup.Megacerops, "Megacerops"},
			{FossilGroup.Pachycephalosaurus, "Pachycephalosaurus"},
			{FossilGroup.Parasaur, "Parasaur"},
			{FossilGroup.Plesiosaur, "Plesiosaur"},
			{FossilGroup.Pteranodon, "Pteranodon"},
			{FossilGroup.SabretoothTiger, "Sabretooth Tiger"},
			{FossilGroup.Seismosaur, "Seismosaur"},
			{FossilGroup.Stegosaur, "Stegosaur"},
			{FossilGroup.Spinosaurus, "Spinosaurus"},
			{FossilGroup.Styracosaurus, "Styracosaurus"},
			{FossilGroup.Triceratops, "Triceratops"},
			{FossilGroup.TyrannosaurusRex, "Tyrannosaurus Rex"},
			{FossilGroup.Velociraptor, "Velociraptor"},
			{FossilGroup.Standalone, "Standalone"}
		};

		public static string GetGroup(this FossilGroup group)
		{
			return _groups[group];
		}

		public static FossilGroup Lookup(string group)
		{
			KeyValuePair<FossilGroup, string> groupKvp = _groups.Where(kvp => kvp.Value == group).SingleOrDefault();

			if (groupKvp.Equals(default(KeyValuePair<FossilGroup, string>)))
			{
				throw new ArgumentOutOfRangeException(nameof(group), group, "Unknown Fossil Group");
			}

			return groupKvp.Key;
		}
	}
}