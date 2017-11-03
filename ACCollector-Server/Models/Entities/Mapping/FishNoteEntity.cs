using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
{
	[Table("FishNote", Schema = "dbo")]
	public class FishNoteEntity
	{
		[Key]
		[Required]
		public Guid FishId { get; set; }

		[Key]
		[Required]
		public Guid NoteId { get; set; }

		public FishEntity Fish { get; set; }

		public NoteEntity Note { get; set; }
	}
}