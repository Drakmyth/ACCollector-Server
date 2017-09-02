using ACCollector_Server.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

		public GameSummary ToSummary(Region preferredRegion)
		{
			if (!Releases.Any())
			{
				throw new RegionNotFoundException($"Game '{GameId}' has no releases.");
			}

			ReleaseEntity release = Releases.Where(r => r.Region == preferredRegion).SingleOrDefault() // Try preferred region first
									?? Releases.Where(r => r.Region == Region.NA).SingleOrDefault() // preferred region not found, fallback to NA
									?? Releases.Where(r => r.Region == Region.JP).SingleOrDefault() // NA region not found, fallback to JP
									?? Releases.First(); // JP region not found, fallback to anything

			return new GameSummary(GameId, release.Title);
		}
	}
}