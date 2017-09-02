using System;
using System.Runtime.Serialization;

namespace ACCollector_Server.Exceptions
{
	[Serializable]
	public class EnumMappingException : Exception
	{
		public EnumMappingException()
		{
		}

		public EnumMappingException(string message) : base(message)
		{
		}

		public EnumMappingException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected EnumMappingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}