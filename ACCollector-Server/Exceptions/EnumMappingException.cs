using System;
using System.Runtime.Serialization;

namespace ACCollector_Server.Exceptions
{
	[Serializable]
	public class EnumMappingException : Exception
	{
		public EnumMappingException(string message) : base(message)
		{
		}

		protected EnumMappingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}