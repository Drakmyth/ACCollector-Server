﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateArtRequest
	{
		[Required]
		public string Name { get; }

		[Required]
		public int SalePrice { get; }

		[Required]
		public int PurchasePrice { get; }

		[Required]
		public ArtType Type { get; }

		[Required]
		public ArtSource AvailableFrom { get; }

		[JsonConstructor]
		public CreateArtRequest(string name, int salePrice, int purchasePrice, ArtType type, ArtSource availableFrom)
		{
			Name = name;
			SalePrice = salePrice;
			PurchasePrice = purchasePrice;
			Type = type;
			AvailableFrom = availableFrom;
		}
	}
}