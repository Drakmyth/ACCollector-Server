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

		[NotMapped]
		public List<string> Releases { get; set; } = new List<string>();

		public Game ToModel()
		{
			var builder = new Game.Builder(GameId, new Uri("http://www.stuff.com"), Name);

			foreach (string strRelease in Releases)
			{
				var release = new Release(Region.NA, "title", Platform.N64, "releaseDate");
				builder.WithRelease(release);
			}

			return builder.Build();
		}
	}
}