using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities.Mapping
{
	[Table("BugNote", Schema = "dbo")]
	public class BugNoteEntity
	{
		[Key]
		[Required]
		public Guid BugId { get; set; }

		[Key]
		[Required]
		public Guid NoteId { get; set; }

		public BugEntity Bug { get; set; }

		public NoteEntity Note { get; set; }

		private BugNoteEntity()
		{
			// EF Constructor
		}

		public BugNoteEntity(BugEntity bug, NoteEntity note)
		{
			BugId = bug.BugId;
			NoteId = note.NoteId;

			Bug = bug;
			Note = note;
		}
	}
}