using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
{
	[Table("Release", Schema = "dbo")]
	public class ReleaseEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ReleaseId { get; set; }

		[Required]
		public Guid GameId { get; set; }

		[Required]
		public Region Region { get; set; }

//		public Game ToModel()
//		{
//			var builder = new Release.Builder(ReleaseId, new Uri("http://www.stuff.com"), Name);
//
//			foreach (string strRelease in Releases)
//			{
//				var release = new Release(Region.NA, "title", Platform.N64, "releaseDate");
//				builder.WithRelease(release);
//			}
//
//			return builder.Build();
//		}
	}
}