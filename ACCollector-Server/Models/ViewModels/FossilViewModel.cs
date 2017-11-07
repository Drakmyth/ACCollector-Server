using Newtonsoft.Json;
using System;

namespace ACCollector_Server.Models.ViewModels
{
	public class FossilViewModel
	{
		[JsonProperty]
		public Guid FossilId { get; }

		[JsonProperty]
		public Guid GameId { get; }

		[JsonProperty]
		public Uri Href { get; }

		[JsonProperty]
		public string Name { get; }

		[JsonProperty]
		public int SalePrice { get; }

		[JsonProperty]
		public FossilGroup Group { get; }

		public FossilViewModel(Fossil fossil, Uri href)
		{
			FossilId = fossil.FossilId;
			GameId = fossil.GameId;
			Href = href;
			Name = fossil.Name;
			SalePrice = fossil.SalePrice;
			Group = fossil.Group;
		}
	}
}