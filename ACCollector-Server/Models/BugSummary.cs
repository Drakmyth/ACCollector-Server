using System;

namespace ACCollector_Server.Models
{
	public class BugSummary
	{
		public Guid BugId { get; }
		public string Name { get; }

		public BugSummary(Guid bugId, string name)
		{
			BugId = bugId;
			Name = name;
		}
	}
}