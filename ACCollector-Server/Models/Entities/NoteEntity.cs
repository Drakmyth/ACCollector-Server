using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
{
	[Table("Note", Schema = "dbo")]
	public class NoteEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid NoteId { get; set; }

		[Required]
		public string Message { get; set; }

		private NoteEntity()
		{
			// EF Constructor
		}

		public NoteEntity(string message)
		{
			NoteId = Guid.Empty;
			Message = message;
		}

		public Note ToModel()
		{
			return new Note(NoteId, Message);
		}
	}
}