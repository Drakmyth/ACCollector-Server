﻿using ACCollector_Server.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class ReleaseViewModel
	{
		public Guid ReleaseId { get; }

		public Uri Href { get; }

		public Guid GameId { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; }

		public string Title { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public Platform Platform { get; }

		[JsonConverter(typeof(DateConverter))]
		public DateTime ReleaseDate { get; }

		[JsonConstructor]
		public ReleaseViewModel(Guid releaseId, Uri href, Guid gameId, Region region, string title, Platform platform, DateTime releaseDate)
		{
			ReleaseId = releaseId;
			Href = href;
			GameId = gameId;
			Region = region;
			Title = title;
			Platform = platform;
			ReleaseDate = releaseDate;
		}

		public ReleaseViewModel(ReleaseViewModel copy)
			: this(copy.ReleaseId, copy.Href, copy.GameId, copy.Region, copy.Title, copy.Platform, copy.ReleaseDate)
		{
		}

		public ReleaseViewModel(Release release, Uri href)
			: this(release.ReleaseId, href, release.GameId, release.Region, release.Title, release.Platform, release.ReleaseDate)
		{
		}
	}
}