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
			get
			{
				bool success = Enum.TryParse(RegionCode, out Region region);
				if (!success)
				{
					throw new EnumMappingException($"Unknown '{nameof(Region)}' enum value: {RegionCode}");
				}
				return region;
			}

			set => RegionCode = value.ToString();
		}

		[Required]
		public string Title { get; set; }

		[Required]
		public string PlatformCode { get; set; }

		[NotMapped]
		public Platform Platform
		{
			get
			{
				bool success = Enum.TryParse(PlatformCode, out Platform platform);
				if (!success)
				{
					throw new EnumMappingException($"Unknown '{nameof(Platform)}' enum value: {PlatformCode}");
				}
				return platform;
			}

			set => PlatformCode = value.ToString();
		}

		[Required]
		public DateTime ReleaseDate { get; set; }

		public Release ToModel()
		{
			return new Release(Region, Title, Platform, ReleaseDate);
		}
	}
}