using System;

namespace ACCollector_Server.Models
{
	public class Note
	{
		public Guid NoteId { get; }
		public string Message { get; }

		public Note(Guid noteId, string message)
		{
			NoteId = noteId;
			Message = message;
		}

		public Note(Note copy) : this(copy.NoteId, copy.Message)
		{
		}
	}
}