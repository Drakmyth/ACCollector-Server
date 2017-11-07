using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class ArtViewModel
	{
		[JsonProperty]
		public Guid ArtId { get; }

		[JsonProperty]
		public Guid GameId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public string Name { get; }

		[JsonProperty]
		public int SalePrice { get; }

		[JsonProperty]
		public int PurchasePrice { get; }

		[JsonProperty]
		public ArtType Type { get; }

		[JsonProperty]
		public ArtSource AvailableFrom { get; }

		public ArtViewModel(Art art, Uri href)
		{
			ArtId = art.ArtId;
			GameId = art.GameId;
			Href = href;
			Name = art.Name;
			SalePrice = art.SalePrice;
			PurchasePrice = art.PurchasePrice;
			Type = art.Type;
			AvailableFrom = art.Source;
		}
	}
}