using System;

namespace ACCollector_Server.Models
{
	public class ArtSummary
	{
		public Guid ArtId { get; }
		public string Name { get; }
		public ArtType Type { get; }

		public ArtSummary(Guid artId, string name, ArtType type)
		{
			ArtId = artId;
			Name = name;
			Type = type;
		}
	}
}