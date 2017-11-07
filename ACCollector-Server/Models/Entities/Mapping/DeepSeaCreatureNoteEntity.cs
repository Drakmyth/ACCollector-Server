using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities.Mapping
{
	[Table("DeepSeaCreatureNote", Schema = "dbo")]
	public class DeepSeaCreatureNoteEntity
	{
		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid DeepSeaCreatureId { get; set; }

		// [Key] Configured in ACCollectorDbContext.cs. EFCore doesn't support composite primary keys via annotations.
		[Required]
		public Guid NoteId { get; set; }

		public DeepSeaCreatureEntity DeepSeaCreature { get; set; }

		public NoteEntity Note { get; set; }

		private DeepSeaCreatureNoteEntity()
		{
			// EF Constructor
		}

		public DeepSeaCreatureNoteEntity(DeepSeaCreatureEntity deepSeaCreature, NoteEntity note)
		{
			DeepSeaCreatureId = deepSeaCreature.DeepSeaCreatureId;
			NoteId = note.NoteId;
			DeepSeaCreature = deepSeaCreature;
			Note = note;
		}
	}
}