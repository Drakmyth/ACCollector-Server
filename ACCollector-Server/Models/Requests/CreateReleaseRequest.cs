using ACCollector_Server.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateReleaseRequest
	{
		[Required]
		public Guid GameId { get; }

		[Required]
		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; }

		[Required]
		[StringLength(60)]
		public string Title { get; }

		[Required]
		[JsonConverter(typeof(StringEnumConverter))]
		public Platform Platform { get; }

		[Required]
		[JsonConverter(typeof(DateConverter))]
		public DateTime ReleaseDate { get; }

		[JsonConstructor]
		public CreateReleaseRequest(Guid gameId, Region region, string title, Platform platform, DateTime releaseDate)
		{
			GameId = gameId;
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}

		public CreateReleaseRequest(CreateReleaseRequest copy)
			: this(copy.GameId, copy.Region, copy.Title, copy.Platform, copy.ReleaseDate)
		{
		}
	}
}