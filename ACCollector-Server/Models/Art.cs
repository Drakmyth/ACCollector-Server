using System;

namespace ACCollector_Server.Models
{
	public class Art
	{
		public Guid ArtId { get; }
		public Guid GameId { get; }
		public string Name { get; }
		public int SalePrice { get; private set; }
		public int PurchasePrice { get; private set; }
		public ArtType Type { get; private set; }
		public ArtSource Source { get; private set; }

		private Art(Guid artId, Guid gameId, string name)
		{
			ArtId = artId;
			GameId = gameId;
			Name = name;
			SalePrice = 0;
			PurchasePrice = 0;
			Type = ArtType.Painting;
			Source = ArtSource.CrazyRedd;
		}

		private Art(Art copy) : this(copy.ArtId, copy.GameId, copy.Name)
		{
			SalePrice = copy.SalePrice;
			PurchasePrice = copy.PurchasePrice;
			Type = copy.Type;
			Source = copy.Source;
		}

		public class Builder : Art
		{
			public Builder(Guid artId, Guid gameId, string name) : base(artId, gameId, name)
			{
			}

			public Builder WithSalePrice(int salePrice)
			{
				SalePrice = salePrice;
				return this;
			}

			public Builder WithPurchasePrice(int purchasePrice)
			{
				PurchasePrice = purchasePrice;
				return this;
			}

			public Builder AsType(ArtType type)
			{
				Type = type;
				return this;
			}

			public Builder FromSource(ArtSource source)
			{
				Source = source;
				return this;
			}

			public Art Build()
			{
				return new Art(this);
			}
		}
	}
}