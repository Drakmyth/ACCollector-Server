using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
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
	}
}