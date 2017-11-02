using ACCollector_Server.Exceptions;
using System;
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
		public string RegionCode { get; set; }

		[NotMapped]
		public Region Region
		{
			get => RegionExtensions.Lookup(RegionCode);
			set => RegionCode = value.GetCode();
		}

		[Required]
		public string Title { get; set; }

		[Required]
		public string PlatformCode { get; set; }

		[NotMapped]
		public Platform Platform
		{
			get => PlatformExtensions.Lookup(PlatformCode);
			set => PlatformCode = value.GetCode();
		}

		[Required]
		public DateTime ReleaseDate { get; set; }

		public Release ToModel()
		{
			return new Release(ReleaseId, GameId, Region, Title, Platform, ReleaseDate);
		}

		public ReleaseSummary ToSummary()
		{
			return new ReleaseSummary(ReleaseId, Region, Title);
		}
	}
}