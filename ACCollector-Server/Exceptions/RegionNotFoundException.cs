using ACCollector_Server.Models;
using System;
using System.Runtime.Serialization;

namespace ACCollector_Server.Exceptions
{
	[Serializable]
	public class RegionNotFoundException : Exception
	{
		public RegionNotFoundException(string message) : base(message)
		{
		}

		protected RegionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}