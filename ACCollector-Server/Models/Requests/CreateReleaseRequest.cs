﻿using ACCollector_Server.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateReleaseRequest
	{
		[Required]
		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; }

		[Required]
		public string Title { get; }

		[Required]
		[JsonConverter(typeof(StringEnumConverter))]
		public Platform Platform { get; }

		[Required]
		[JsonConverter(typeof(DateConverter))]
		public DateTime ReleaseDate { get; }

		[JsonConstructor]
		public CreateReleaseRequest(Region region, string title, Platform platform, DateTime releaseDate)
		{
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}
	}
}