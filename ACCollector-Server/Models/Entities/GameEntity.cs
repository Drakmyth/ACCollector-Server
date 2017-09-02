using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
{
	[Table("Game", Schema = "dbo")]
	public class GameEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid GameId { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual ICollection<ReleaseEntity> Releases { get; } = new List<ReleaseEntity>();

		public Game ToModel()
		{
			var builder = new Game.Builder(GameId, Name);

			foreach (ReleaseEntity release in Releases)
			{
				builder.WithRelease(release.ToModel());
			}

			return builder.Build();
		}
	}
}