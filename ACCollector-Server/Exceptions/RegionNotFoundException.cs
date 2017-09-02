using ACCollector_Server.Models;
using System;
using System.Runtime.Serialization;

namespace ACCollector_Server.Exceptions
{
	[Serializable]
	public class RegionNotFoundException : Exception
	{
		public RegionNotFoundException()
		{
		}

		public RegionNotFoundException(string message) : base(message)
		{
		}

		public RegionNotFoundException(Region region) : this($"Region '{region}' not found.")
		{
		}

		public RegionNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected RegionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}