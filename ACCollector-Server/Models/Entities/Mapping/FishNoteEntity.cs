using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities.Mapping
{
	[Table("FishNote", Schema = "dbo")]
	public class FishNoteEntity
	{
		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid FishId { get; set; }

		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid NoteId { get; set; }

		public FishEntity Fish { get; set; }

		public NoteEntity Note { get; set; }

		private FishNoteEntity()
		{
			// EF Constructor
		}

		public FishNoteEntity(FishEntity fish, NoteEntity note)
		{
			FishId = fish.FishId;
			NoteId = note.NoteId;
			Fish = fish;
			Note = note;
		}
	}
}