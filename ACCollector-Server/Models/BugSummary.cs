using System;

namespace ACCollector_Server.Models
{
	public class BugSummary
	{
		public Guid BugId { get; }
		public int InGameId { get; }
		public string Name { get; }

		public BugSummary(Guid bugId, int inGameId, string name)
		{
			BugId = bugId;
			InGameId = inGameId;
			Name = name;
		}
	}
}