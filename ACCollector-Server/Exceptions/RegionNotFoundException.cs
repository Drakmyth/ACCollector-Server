using System;

namespace ACCollector_Server.Exceptions
{
	[Serializable]
	public class RegionNotFoundException : Exception
	{
		public RegionNotFoundException(string message) : base(message)
		{
		}
	}
}