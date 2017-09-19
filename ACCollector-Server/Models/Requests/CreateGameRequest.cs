using ACCollector_Server.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateGameRequest
	{
		[Required]
		[StringLength(60)]
		public string Name { get; }

		[Required]
		public List<CreateReleaseRequest> Releases { get; }

		[JsonConstructor]
		public CreateGameRequest(string name, IReadOnlyList<CreateReleaseRequest> releases)
		{
			Name = name;
			Releases = new List<CreateReleaseRequest>(releases);
		}

		public class CreateReleaseRequest
		{
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
			[DataType(DataType.Date)]
			[JsonConverter(typeof(DateConverter))]
			public DateTime ReleaseDate { get; }

			[JsonConstructor]
			private CreateReleaseRequest(Region region, string title, Platform platform, DateTime releaseDate)
			{
				Region = region;
				Title = title;
				Platform = platform;
				ReleaseDate = releaseDate;
			}

			public CreateReleaseRequest(Requests.CreateReleaseRequest copy)
				: this(copy.Region, copy.Title, copy.Platform, copy.ReleaseDate)
			{
			}
		}
	}
}